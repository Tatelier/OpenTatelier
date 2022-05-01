using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class Report
	{
		public static Report Singleton { get; } = new Report();

		public int Send(StringBuilder sb)
		{
			int result = 0;

			var task = Task.Run(async () =>
			{
				try
				{
					string url = "aHR0cHM6Ly90YXRlbGllci5hdXRoLnBhbnN5c3Rhci5uZXQvcmVwb3J0Lw==";

					HttpClient httpClient = new HttpClient();

					string folder = Path.GetDirectoryName(Path.GetFullPath("Tatelier.exe"));

					string token = "";


					if (File.Exists(Path.Combine(folder, "Auth")))
					{
						token = File.ReadAllText(Path.Combine(folder, "Auth"));
					}
					else
					{
						result = - 1;
					}


					var dic = new Dictionary<string, string>()
					{
						{ "Token", token },
						{ "Content", $"{sb}" },
					};

					var content = new FormUrlEncodedContent(dic);

					var a = await httpClient.PostAsync(Encoding.UTF8.GetString(Convert.FromBase64String(url)), content);

					var c = await a.Content.ReadAsStringAsync();

					var json = Hjson.JsonObject.Parse(c);

					result = json.EQi("result") ?? -1;
				}
				catch
				{
					result = -2;
				}
			});

			return result;
		}
	}
}
