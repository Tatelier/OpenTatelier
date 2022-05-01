using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	class MusicalScoreSaveData
	{
		const string VersionKey = "Version";
		const string DataKey = "Data";

		public string MD5 = "";
		public List<MusicalScoreSaveDataCourse> CourseList { get; private set; } = new List<MusicalScoreSaveDataCourse>();

		int InputJson(Hjson.JsonValue json)
        {
			var courseList = (json[nameof(CourseList)] as Hjson.JsonArray)
				.Select(v => {
					var c = new MusicalScoreSaveDataCourse();
					c.InputJson(v);
					return c;
				}).ToList();
			CourseList = courseList;
			return 0;
        }

		public Hjson.JsonValue OutputJson()
        {
			var json = new Hjson.JsonObject();
			var courseList = new Hjson.JsonArray();

			courseList.AddRange(CourseList.Select(v => v.OutputJson()));

			json[nameof(CourseList)] = courseList;

			return json;
        }

		public int Regist(int courseID, Tatelier.Result.ResultData resultData)
		{
			MD5 = resultData.MD5;

			var course = CourseList.Where(v => v.CourseID == courseID);

			if (course.Any())
			{
				if (course.Count() == 1)
				{
					course.FirstOrDefault()?.Regist(resultData);
				}
				else
				{
					// TODO: 重複エラー
				}
			}
			else
			{
				var m = new MusicalScoreSaveDataCourse();
				m.CourseID = courseID;
				m.Regist(resultData);
				CourseList.Add(m);
			}
			return 0;
		}

		/// <summary>
		/// スコア成績ファイルを読込する
		/// </summary>
		/// <param name="filePath">ファイルパス(*.tlrsav)</param>
		/// <param name="isDecrypt">true: 復号化する, false: しない</param>
		public void Load(string filePath, bool isDecrypt = true)
		{
			CourseList.Clear();

			if (!File.Exists(filePath))
			{
				return;
			}

			Hjson.JsonValue json;

			try
			{
				if (isDecrypt)
				{
					using (var managed = MusicalScoreSaveDataManaged.Create())
					{
						var decryptor = managed.CreateDecryptor();

						using (var mStream = new MemoryStream(File.ReadAllBytes(filePath)))
						{
							using (var ctStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read))
							{
								json = Hjson.HjsonValue.Load(ctStream);
								MD5 = json.EQs("MD5") ?? "";
								InputJson(json[DataKey]);
							}
						}
					}
				}
				else
				{
					using (var mStream = new MemoryStream(File.ReadAllBytes(filePath)))
					{
						json = Hjson.HjsonValue.Load(mStream);
						MD5 = json.EQs("MD5") ?? ""; 
						InputJson(json[DataKey]);
					}
				}
			}
			catch
			{

			}
		}
		
		/// <summary>
		/// スコア成績ファイルを保存する
		/// </summary>
		/// <param name="filePath">ファイルパス(*.tlrsav)</param>
		/// <param name="isEncrypt">true: 暗号化する, false: しない</param>
		public void Save(string filePath, bool isEncrypt = true, Hjson.Stringify stringify = Hjson.Stringify.Plain)
		{
			// 各変数をjsonのデータに格納
			var json = new Hjson.JsonObject();
			json[VersionKey] = 1;
			json["MD5"] = MD5;
			json[DataKey] = OutputJson();

			var ms = new MemoryStream();
			json.Save(ms, stringify);

			if (!Directory.Exists(Path.GetDirectoryName(filePath)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(filePath));
			}


			try
			{
				if (isEncrypt)
				{
					var managed = MusicalScoreSaveDataManaged.Create();
					var encryptor = managed.CreateEncryptor();
					var ofs = new FileStream(filePath, FileMode.Create, FileAccess.Write);

					//暗号化されたデータを書き出すためのCryptoStreamの作成
					var cryptStream = new CryptoStream(ofs, encryptor, CryptoStreamMode.Write);
					var data = ms.ToArray();

					cryptStream.Write(data, 0, data.Length);

					cryptStream.Close();
					encryptor.Dispose();
					ofs.Close();
				}
				else
				{
					File.WriteAllBytes(filePath, ms.ToArray());
				}
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				ms.Close();
			}
		}		
	}
}
