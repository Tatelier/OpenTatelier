using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TatelierPackageManager
{
	class Program
	{
		const string moduleDirectory = "./.ttle_modules";
		const string manageHjsonFileName = "manage.hjson";

		const string argInstall = "install";
		const string argUninstall = "uninstall";

		static void Main(string[] args)
		{
			string manageHjsonFilePath = Path.Combine(moduleDirectory, manageHjsonFileName);

			if (!File.Exists(manageHjsonFilePath))
			{
				var hjson = new Hjson.JsonObject();
				hjson.SaveEx(manageHjsonFilePath);
			}

			string a = "";
			string packageName = "";

			if (args?.Length > 0)
			{
				foreach (var arg in args)
				{
					switch (arg)
					{
						case "-v":
						case "--version":
							{
								Console.WriteLine("v0.0.1");
							}
							return;
						case "i":
						case argInstall:
							a = argInstall;
							packageName = null;
							break;
						case "ui":
						case argUninstall:
							a = argUninstall;
							packageName = null;
							break;
						default:
							switch (a)
							{
								case argInstall:
								case argUninstall:
									packageName = arg;
									break;
							}
							break;
					}
				}

				byte[] result = null;

				if (a?.Length > 0)
				{

					switch (a)
					{
						case argInstall:
							{
								string path = $@".\\.ttle_modules\\{packageName}";
								if (Directory.Exists(path))
								{
									Console.WriteLine($"{packageName} is already installed.");
									return;
								}

								Task.Run(async () =>
								{
									using (var client = new HttpClient())
									{
										var response = await client.GetAsync($@"https://tlpm.pansystar.net/download/?name={packageName}&version=stable"); // GET

										if (response.StatusCode == System.Net.HttpStatusCode.OK)
										{
											result = await response.Content.ReadAsByteArrayAsync();
										}
									}
								}).Wait();

								if (result?.Length > 0)
								{
									using (var zipArchive = new ZipArchive(new MemoryStream(result)))
									{
										zipArchive.ExtractToDirectory($@".\\.ttle_modules\\{packageName}");
									}
									Console.WriteLine($"{packageName} installed.");
								}
								else
								{
									Console.WriteLine($"{packageName} is not found.");
								}
							}
							break;
						case argUninstall:
						default:
							{
								string path = $@".\\.ttle_modules\\{packageName}";
								if (!Directory.Exists(path))
								{
									Console.WriteLine($"{packageName} is not installed.");
									return;
								}
								else
								{
									Directory.Delete(path, true);
									Console.WriteLine($"{packageName} uninstalled.");
								}
							}
							break;
					}
				}
				else
				{
					Console.WriteLine("please, arguments.");
				}

			}
			else
			{
				Console.WriteLine("Hello!! tlpm is tatelier package manager.");
				Console.WriteLine("please, arguments.");
				Console.WriteLine();
				Console.WriteLine("example");
				Console.WriteLine("> tlpm install discord-rpc");
			}
		}
	}
}
