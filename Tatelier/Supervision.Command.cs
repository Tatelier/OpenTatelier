using HjsonEx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Interface.Command;

namespace Tatelier
{
    partial class Supervision
	{
		static ResultType CommandAuto(string command, string[] args)
		{
			if (Share.Singleton.TokenInfo.Playable)
			{
				int val;
				var playerInfoList = MainConfig.Singleton.PlayerInfoList;
				if (args.Length == 0)
				{
					val = 1;
					if (playerInfoList[val - 1].PlayOption.Special.Value == SongSelect.PlayOptionSpecialType.Normal)
					{
						playerInfoList[val - 1].PlayOption.Special.Value = SongSelect.PlayOptionSpecialType.Auto;
					}
					else
					{
						playerInfoList[val - 1].PlayOption.Special.Value = SongSelect.PlayOptionSpecialType.Normal;
					}

					LogWindow.Singleton.Insert($"Player {val} の演奏スタイルを {(playerInfoList[val - 1].PlayOption.Special.Value == SongSelect.PlayOptionSpecialType.Auto ? "オート" : "通常")} に変更しました。");
				}
				else
				{
					char t = '\0';
					for (int i_arg = 0; i_arg < args.Length; i_arg++)
					{
						switch (args[i_arg])
						{
							case "on":
								t = 't';
								break;
							case "off":
								t = 'f';
								break;
							case "all":
								{
									for (int i = 0; i < playerInfoList.Length; i++)
									{
										var playerInfo = playerInfoList[i];
																				
										if (t == 't')
										{
											playerInfo.PlayOption.Special.Value = SongSelect.PlayOptionSpecialType.Auto;
										}
										else if (t == 'f')
										{
											playerInfo.PlayOption.Special.Value = SongSelect.PlayOptionSpecialType.Normal;
										}
										else
										{
											if (playerInfo.PlayOption.Special.Value == SongSelect.PlayOptionSpecialType.Normal)
											{
												playerInfo.PlayOption.Special.Value = SongSelect.PlayOptionSpecialType.Auto;
											}
											else
											{
												playerInfo.PlayOption.Special.Value = SongSelect.PlayOptionSpecialType.Normal;
											}
										}
									}
								}

								break;
							default:
								if (int.TryParse(args[i_arg], out val))
								{

									if (t == 't')
									{
										playerInfoList[val - 1].PlayOption.Special.Value = SongSelect.PlayOptionSpecialType.Auto;
									}
									else if (t == 'f')
									{
										playerInfoList[val - 1].PlayOption.Special.Value = SongSelect.PlayOptionSpecialType.Normal;
									}
									else
									{
										if (playerInfoList[val - 1].PlayOption.Special.Value == SongSelect.PlayOptionSpecialType.Normal)
										{
											playerInfoList[val - 1].PlayOption.Special.Value = SongSelect.PlayOptionSpecialType.Auto;
										}
										else
										{
											playerInfoList[val - 1].PlayOption.Special.Value = SongSelect.PlayOptionSpecialType.Normal;
										}
									}

								}
								break;
						}
					}
					LogWindow.Singleton.Insert($"各Playerの演奏スタイルを変更しました。");

				}

				return ResultType.Dispatch;
			}
			else
			{
				LogWindow.Singleton.Insert($"{Share.Singleton.TokenInfo.RoleName}では、演奏スタイルを", LogWindow.WarningColor);
				LogWindow.Singleton.Insert("オートから変更できません。", LogWindow.WarningColor);

				return ResultType.Exit;
			}
		}

		static ResultType CommandConfig(string command, string[] args)
		{
			bool isStart = false;
			string uri = "http://127.0.0.1:4080/";
			if (Share.Singleton.ConfigTask == null)
			{
				Share.Singleton.ConfigTask = Task.Run(() =>
				{
					string root = @"."; // ドキュメント・ルート

					string prefix = uri; // 受け付けるURL
					HttpListener listener = new HttpListener();
					listener.Prefixes.Add(prefix); // プレフィックスの登録
					listener.Start();
					isStart = true;
					while (true)
					{
						HttpListenerContext context = listener.GetContext();
						HttpListenerRequest req = context.Request;
						HttpListenerResponse res = context.Response;

						Console.WriteLine(req.RawUrl);

						// リクエストされたURLからファイルのパスを求める
						string path = root + req.RawUrl.Replace("/", "\\ConfigServer\\index.html");

						// ファイルが存在すればレスポンス・ストリームに書き出す
						if (File.Exists(path))
						{
							byte[] content = File.ReadAllBytes(path);
							res.OutputStream.Write(content, 0, content.Length);
						}
						res.Close();
					}
				});

				while (!isStart) break;
			}

			Process.Start(uri);
			LogWindow.Singleton.Insert($"設定画面をブラウザに表示します。");

			return ResultType.Exit;
		}

		static ResultType CommandConnect(string command, string[] args)
		{
			if (args.Length > 0)
			{
				if (!TatelierClientManager.Singleton.Connected)
				{
					TatelierClientManager.Singleton.Start(args[0]);
				}
				else
				{
					LogWindow.Singleton.Insert("既に接続しているサーバがあります。[]");
				}
			}
			return ResultType.Exit;
		}

		static ResultType CommandDecrypt(string command, string[] args)
		{
			if (SceneControl.Singleton.IsNowCurrent<Scene.SongSelect>())
			{
				return ResultType.Dispatch;
			}
			else
			{
				return ResultType.NotAbleToNowScene;
			}
		}

		static ResultType CommandDemo(string command, string[] args)
		{
			if (args.Length == 0)
			{
				MainConfig.Singleton.Demo = !MainConfig.Singleton.Demo;
			}
			else
			{
				if (bool.TryParse(args[0], out var result))
				{
					MainConfig.Singleton.Demo = result;
				}
			}

			return ResultType.Dispatch;
		}

		static ResultType CommandDebug(string command, string[] args)
		{
			MainConfig.Singleton.Debug = !MainConfig.Singleton.Debug;

			return ResultType.Dispatch;
		}

		static ResultType CommandDir(string command, string[] args)
		{
			if (args.Length > 0
				&& args[0].ToLower() == "%temp%")
			{
				Process.Start("explorer", Path.Combine(Path.GetTempPath(), "Tatelier"));
			}
			else
			{
				Process.Start("explorer", Environment.CurrentDirectory);
			}
			return ResultType.Exit;
		}

		static ResultType CommandExit(string command, string[] args)
		{
			Singleton.IsExit = true;
			Environment.Exit(0);

			return ResultType.Exit;
		}

		static ResultType CommandHelp(string command, string[] args)
		{
			Process.Start("https://tatelier.pansystar.net/docs/topics/command/");
			LogWindow.Singleton.Insert($"コマンドヘルプを既定ブラウザで開きました。");

			return ResultType.Exit;
		}

		static ResultType CommandJudge(string command, string[] args)
		{
#warning 予約されたコマンド
			return ResultType.Exit;
		}

		static ResultType CommandPlayer(string command, string[] args)
		{
			int num = 1;
			if (args.Length == 0)
			{
				num = 1;
			}
			else
			{
				if (int.TryParse(args[0], out var result))
				{
					num = result;
				}
			}
			if (Play.PlayerConfig.Exists(num))
			{
				Share.Singleton.PlayerNum = num;
				LogWindow.Singleton.Insert($"プレイ人数を {Share.Singleton.PlayerNum}人 に変更しました。");
			}
			else
			{
				LogWindow.Singleton.Insert($"Player{num:000}.hjsonがないため、{num}人に変更できませんでした。");
			}
			return ResultType.Dispatch;
		}

		static ResultType CommandReboot(string command, string[] args)
		{
			Singleton.IsReboot = true;
			Singleton.IsExit = true;

			return ResultType.Exit;
		}

		static ResultType CommandRemote(string command, string[] args)
		{
			int defaultPort = MainConfig.Singleton.RemotePort;


			int port = defaultPort;

			bool isStop = false;

			for (int i = 0; i < args.Length; i++)
			{
				switch (args[i])
				{
					case "-p":
					case "--port":
						{
							if (i + 1 < args.Length)
							{
								if (int.TryParse(args[i + 1], out port))
								{
									i++;
								}
								else
								{
									port = defaultPort;
								}
							}
						}
						break;
					case "--stop":
						{
							TatelierRemoteManager.Singleton.Stop();
							i = args.Length;
							isStop = true;
						}
						break;
				}
			}
			if (!isStop)
			{
				TatelierRemoteManager.Singleton.Start(port);
			}

			return ResultType.Exit;
		}

		static ResultType CommandRole(string command, string[] args)
		{
			LogWindow.Singleton.Insert($"このAuthIDは {Share.Singleton.TokenInfo.RoleName} です。");

			return ResultType.Exit;
		}

		static ResultType CommandSearch(string command, string[] args)
		{
			if (SceneControl.Singleton.IsNowCurrent<Scene.SongSelect>())
			{
				return ResultType.Dispatch;
			}
			else
			{
				return ResultType.NotAbleToNowScene;
			}
		}

		static ResultType CommandSpeed(string command, string[] args)
		{
			if (args.Length == 0)
			{
				LogWindow.Singleton.Insert($"引数がありません", LogWindow.WarningColor);

				return ResultType.Exit;
			}
			else
			{
				char t = '\0';
				int playerIndex = -1;
				float speedTemp = 1.0F;
				for (int i_arg = 0; i_arg < args.Length; i_arg++)
				{
					switch (args[i_arg])
					{
						case "-p":
							t = 'p';
							break;
						default:
							if (t == 'p')
							{
								if (int.TryParse(args[i_arg], out var ival))
								{
									playerIndex = ival;
									t = '\0';
								}
								else
								{
									playerIndex = -1;
									t = '\0';
								}
							}
							else
							{
								if (float.TryParse(args[i_arg], out var fval))
								{
									speedTemp = fval;
									if (playerIndex == -1)
									{
										for (int i = 0; i < MainConfig.Singleton.PlayerInfoList.Length; i++)
										{
											MainConfig.Singleton.PlayerInfoList[i].PlayOption.ScrollSpeed.Value = speedTemp;
										}

										LogWindow.Singleton.Insert($"全Player の ScrollSpeed を \"x{speedTemp}\" に変更しました。");
									}
									else if (playerIndex > 0 && playerIndex <= MainConfig.Singleton.PlayerInfoList.Length)
									{
										MainConfig.Singleton.PlayerInfoList[playerIndex - 1].PlayOption.ScrollSpeed.Value = speedTemp;
										LogWindow.Singleton.Insert($"Player{playerIndex:000} の ScrollSpeed を \"x{speedTemp}\" に変更しました。");
									}
									else
									{
										LogWindow.Singleton.Insert($"指定されたPlayer番号が、Player総数の範囲外です。", LogWindow.WarningColor);
									}
								}
								else
								{
									LogWindow.Singleton.Insert($"不正な値です", LogWindow.WarningColor);
								}
							}
							break;
					}
				}

				return ResultType.Dispatch;
			}
		}

		static ResultType CommandServer(string command, string[] args)
		{
			const int defaultPort = 61234;
			int port;
			if (args.Length > 0)
			{
				if (!int.TryParse(args[0], out port))
				{
					port = defaultPort;
				}
			}
			else
			{
				port = defaultPort;
			}
			TatelierServerManager.Singleton.Start(port);

			LogWindow.Singleton.Insert($"対戦サーバを起動しました。{port}");

			return ResultType.Exit;
		}

		static ResultType CommandVersion(string command, string[] args)
		{
			LogWindow.Singleton.Insert($"Tatelier v{Singleton.Version}");

			return ResultType.Exit;
		}

		static Dictionary<string, string> commandShortToChangeMap = new Dictionary<string, string>()
		{
			{ "/p", "/player" },
			{ "/s", "/search" },
			{ "/scrspd", "/speed" },
			{ "/scrollspeed", "/speed" },
		};

		static Dictionary<string, Func<string, string[], ResultType>> commandMap = new Dictionary<string, Func<string, string[], ResultType>>()
		{
			{ "drag & drop", (command, args) => SceneControl.Singleton.CommandSearchAndRun(command, args) },
			{ "/auto", (command, args) => CommandAuto(command, args) },
			{ "/config", (command, args) => CommandConfig(command, args) },
			{ "/connect", (command, args) => CommandConnect(command, args) },
			{ "/debug", (command, args) => CommandDebug(command, args) },
			{ "/decrypt", (command ,args) => CommandDecrypt(command, args) },
			{ "/demo", (command, args) => CommandDemo(command, args) },
			{ "/dir", (command, args) => CommandDir(command, args) },
			{ "/exit", (command, args) => CommandExit(command, args) },
			{ "/help", (command, args) => CommandHelp(command, args) },
			{ "/homepage", (command, args) => { Process.Start("https://tatelier.pansystar.net/"); return ResultType.Exit; } },
			{ "/judge", (command, args) => CommandJudge(command, args) },
			{ "/manual", (command, args) => { Process.Start("https://github.com/Tatelier/Tatelier/blob/master/Manual"); return ResultType.Exit; } },
			{ "/player", (command, args) => CommandPlayer(command, args) },
			{ "/$log", (command, args) => {
				Supervision.Singleton.Engine.ImageLoadControl.OutputLog();
				return ResultType.Exit;
				}
			},
			{ "/reboot", (command, args) => CommandReboot(command, args) },
			{ "/remote", (command, args) => CommandRemote(command, args) },
			{ "/role", (command, args) => CommandRole(command, args) },
			{ "/search", (command, args) => CommandSearch(command, args) },
			{ "/server", (command, args) => CommandServer(command, args) },
			{ "/speed", (command, args) => CommandSpeed(command, args) },
			{ "/version", (command, args) => CommandVersion(command, args) }
		};

#if DEBUG
		public static void OutputAllCommandName()
		{
			Hjson.JsonObject json = new Hjson.JsonObject();

			var shortKeys = new Hjson.JsonArray();

			foreach (var key in commandShortToChangeMap.Keys)
			{
				shortKeys.Add(key);
			}

			json["Shorts"] = shortKeys;

			var commandKeys = new Hjson.JsonArray();

			foreach (var key in commandMap.Keys)
			{
				commandKeys.Add(key);
			}

			json["Commands"] = commandKeys;


			json.SaveEx("Output\\Command.hjson");
		}
#endif
		/// <summary>
		/// コマンド検索&実行
		/// </summary>
		/// <param name="command">コマンド名</param>
		/// <param name="args">引数</param>
		/// <returns></returns>
		public static ResultType CommandSearchAndRun(string command, params string[] args)
		{
			ResultType result = ResultType.NotFound;

			// ショートコマンドを標準のコマンドに変換する
			{
				if (commandShortToChangeMap.TryGetValue(command, out var r))
				{
					command = r;
				}
			}

			// 
			if (commandMap.TryGetValue(command, out var func))
			{
				result = func(command, args);

				switch (result)
				{
					case ResultType.Dispatch:
						SceneControl.Singleton.CommandSearchAndRun(command, args);
						break;
					case ResultType.NotAbleToNowScene:
						LogWindow.Singleton.Insert($"現在のシーンでは利用できないコマンドです: {command}", LogWindow.ErrorColor);
						break;
				}

				return ResultType.Exit;
			}
			else
			{
				// デバッグ用コマンド
				switch (command)
				{
					case "/preview":
						MainConfig.Singleton.Preview = !MainConfig.Singleton.Preview;
						break;
					case "/error":
						{
							if (args[0].StartsWith("0x"))
							{
								args[0] = args[0].Substring(2);
							}

							Error.Add(Convert.ToUInt32(args[0], 16));
							throw new Exception();
						}
					case "/theme":
						{
							if (args.Length > 0)
							{
								string path = Path.Combine(Path.GetDirectoryName(MainConfig.Singleton.ThemeFolderPath), args[0]);
								if (Directory.Exists(path))
								{
									MainConfig.Singleton.ThemeFolderPath = path;
								}
							}
						}
						break;
					case "/watcher":
						if (args.Length == 0)
						{
							MainConfig.Singleton.ScoreFolderWatch = !MainConfig.Singleton.ScoreFolderWatch;
						}
						else
						{
							if (bool.TryParse(args[0], out var r))
							{
								MainConfig.Singleton.ScoreFolderWatch = r;
							}
						}
						SceneControl.Singleton.CommandSearchAndRun(command, args);
						break;
					case "/tlpm":
						{
							ProcessStartInfo info = new ProcessStartInfo();
							info.FileName = "tlpm.exe";
							info.Arguments = string.Join(" ", args);
							info.RedirectStandardOutput = true;

							var process = Process.Start(info);
						}
						break;
					default:
						{
							ResultType subResult = SceneControl.Singleton.CommandSearchAndRun(command, args);

							if (subResult == ResultType.NotFound)
							{
								LogWindow.Singleton.Insert($"不明なコマンド: {command}", LogWindow.ErrorColor);
							}
						}
						break;
				}

				return result;
			}
		}

	}
}
