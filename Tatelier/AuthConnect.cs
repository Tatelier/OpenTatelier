using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HjsonEx;

namespace Tatelier.Connect
{
	public class ConnectInfo
	{

	}
	public class AuthConnect
	{
		ulong[] statusList = new ulong[1]
		{
			ulong.MaxValue,
		};

		public bool HasError
		{
			get => statusList.Any(v => v != 0);
		}

		public string ErrorCode
		{
			get => $"0x{statusList[0]:X8}";
		}

		public string Version = "";

		public string Checksum;

		public Hjson.JsonValue Act(string folder, string version)
		{
			Hjson.JsonValue result = new Hjson.JsonObject();

			var authResult = HjsonEx.HjsonEx.LoadEx("AuthResult.json");
            
			if (authResult?.ContainsKey("info") ?? false)
            {
				result = authResult;
				statusList[0] = 0;
				return result;
            }


			var task = Task.Run(async () =>
			{
				try
				{
					bool isManaged = false;

					string product = "empty";
					string mserial = "empty";
					string mmanufacturer = "empty";
					string bserial = "empty";
					string mmcError = "";
					try
					{
						using (var mc = new System.Management.ManagementClass("Win32_BaseBoard"))
						using (var moc = mc.GetInstances())
						{
							foreach (var mo in moc)
							{
								if (!isManaged)
								{
									isManaged = true;
									product = $"{mo["Product"]}";
									mserial = $"{mo["SerialNumber"]}";
									mmanufacturer = $"{mo["Manufacturer"]}";
								}

								mo.Dispose();
							}
						}
						
						isManaged = false;
						using (var mc = new System.Management.ManagementClass("Win32_BIOS"))
						using (var moc = mc.GetInstances())
						{
							foreach (var mo in moc)
							{
								if (!isManaged)
								{
									isManaged = true;
									bserial = $"{mo["SerialNumber"]}";
								}

								mo.Dispose();
							}
						}
					}
					catch
					{
						isManaged = true;
						mmcError = "error";
					}
					HttpClient httpClient = new HttpClient();

					string fullPath = Path.Combine(folder, "Tatelier.exe");

					var bytes = File.ReadAllBytes(fullPath);

					// サイズ
					var size = bytes.Length;
					// サム値
					var sum = File.ReadAllBytes(fullPath).Sum(v => v);
					string token = "";

#if LOCAL_DEBUG || REMOTE_DEBUG
					sum = 26256843;
					size = 389632;
					token = "163B1A09-E348-4F07-B150-08B943899A75";
#endif
					// 
					// authファイルの存在チェックをコメントアウト
					// 
					//string[] authFileNames = new string[]
					//{
					//	"Auth",
					//	"Auth.txt"
					//};

					//foreach(var fileName in authFileNames)
					//{
					//	if (File.Exists(Path.Combine(folder, fileName)))
					//	{
					//		token = File.ReadAllText(Path.Combine(folder, fileName));
					//		break;
					//	}
					//}

     //               if (token.Length == 0)
					//{
					//	statusList[0] = 0x00000101;
					//}

					//// GUID形式かどうか
					//if (!Guid.TryParse(token, out _))
					//{
					//	statusList[0] = 0x00000102;
					//	return;
					//}

					var dic = new Dictionary<string, string>()
					{
						//{ "Debug", $"{1}" },
						{ "AppSize", $"{size}" },
						{ "AppSum", $"{sum}" },
						{ "Token", $"{token}" },
						{ "Version", $"{version}" },
						{ "BSerial", $"{bserial}" },
						{ "MSerial", $"{mserial}" },
						{ "MManufacturer", $"{mmanufacturer}" },
						{ "MProduct", $"{product}" },
						{ "MMCError", $"{mmcError}" },
						{ "CurrentDateTime", $"{DateTime.Now.ToUniversalTime().Ticks}" }
					};

					var content = new FormUrlEncodedContent(dic);

					string u = "http://localhost:8000/Test/";
#if LOCAL_DEBUG
					u = Convert.ToBase64String(Encoding.UTF8.GetBytes("http://localhost:8000/Test/"));
#endif
					//
					// 認証サーバへの問い合わせをコメントアウト
					// 
					// var a = await httpClient.PostAsync(Encoding.UTF8.GetString(Convert.FromBase64String(u)), content);
					// var c = await a.Content.ReadAsStringAsync();
					// var json = Hjson.JsonObject.Parse(c);
					// statusList[0] = json?.EQul("result") ?? 0x00000001;
					var json = new Hjson.JsonObject();
					json["info"] = new Hjson.JsonObject();

					var info = json["info"];

					// 演奏可能フラグ
					info["Playable"] = 1;

					// 権限名
					info["RoleName"] = "管理者権限";
					info["RoleNameEN"] = "Administrator";

					// 演奏結果復号可フラグ
					info["ScoreSaveDataDecrypt"] = 1;


					// 譜面結果の暗号化で使うキーです。
					// 認証サーバでアカウント毎に作成されている値のため、
					// 後日メールにて各アカウントに連絡します。
					// Undefinedでは譜面結果の解凍に失敗します。
					info["Encrypt"] = new Hjson.JsonObject();
					info["Encrypt"]["Key"] = "Undefined";
					info["Encrypt"]["IV"] = "Undefined";


					statusList[0] = 0;
					result = json;
				}
				catch
				{
					statusList[0] = 0x0000FF01;
				}
			});

			task.Wait();

			return result;
		}
	}
}
