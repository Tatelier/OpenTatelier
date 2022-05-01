using HjsonEx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tatelier.Sound;
using Tatelier.Progress;
using static DxLibDLL.DX;
using Tatelier.Interface;
using Tatelier.Engine.Interface;

namespace Tatelier
{
	partial class Supervision : INowTime, IScreenSize, Engine.ISupervision
    {
		/// <summary>
		/// 描画領域幅
		/// </summary>
		public static int ScreenWidth = 1920;

		/// <summary>
		/// 描画領域高さ
		/// </summary>
		public static int ScreenHeight = 1080;

		/// <summary>
		/// 描画領域幅中央
		/// </summary>
		public static readonly int ScreenWidthHalf = 960;

		/// <summary>
		/// 描画領域高さ中央
		/// </summary>
		public static readonly int ScreenHeightHalf = 540;

		/// <summary>
		/// シングルトン
		/// </summary>
		public static Supervision Singleton;

		/// <summary>
		/// 現在時刻(ms)
		/// </summary>
		public static int NowMilliSec { get; private set; }

		/// <summary>
		/// 現在時刻(μs)
		/// </summary>
		public static long NowMicroSec { get; private set; }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Exit()
		{
			CommandSearchAndRun("/exit");
		}

		bool IsExit = false;
		bool IsReboot = false;

		public Engine.Engine Engine { get; private set; }

		/// <summary>
		/// バージョン
		/// </summary>
		public string Version
        {
            get
			{
				var asm = GetType().Assembly;
				var ver = asm.GetName().Version;
				string version = $"{ver.Major}.{ver.Minor}.{ver.Build}";

				return version;
			}
        }

		int INowTime.Millisec => NowMilliSec;
		long INowTime.Microsec => NowMicroSec;

		int IScreenSize.Width => ScreenWidth;
		int IScreenSize.Height => ScreenHeight;

        IEngineFunctionModule Engine.ISupervision.FunctionModule { get; } = new DxLib.FunctionModule();

        int initWindowWidth;
		int initWindowHeight;

		/// <summary>
		/// 初期のDrawModeをセットする
		/// </summary>
		/// <param name="json">json</param>
		void SetInitDrawMode(Hjson.JsonValue json)
		{
			ScreenWidth = json?.EQi("Width") ?? 1920;
			ScreenHeight = json?.EQi("Height") ?? 1080;
			SetGraphMode(ScreenWidth, ScreenHeight, 32);
		}

		/// <summary>
		/// 初期のウィンドウ情報をセットする
		/// </summary>
		/// <param name="json">json</param>
		void SetInitWindow(Hjson.JsonValue json)
		{
			initWindowWidth = json?.EQi("Width") ?? 960;
			initWindowHeight = json?.EQi("Height") ?? 540;
			SetWindowSize(initWindowWidth, initWindowHeight);
		}

		/// <summary>
		/// アップデートの有無を返す
		/// </summary>
		/// <param name="now">現在のバージョン</param>
		/// <param name="latest">最新のバージョン</param>
		/// <returns>true:あり, false:なし</returns>
		bool HasUpdateVersion(string now, string latest)
		{
			try
			{
				var nowVer = int.Parse(now.Replace(".", ""));
				var latestVer = int.Parse(latest?.Replace(".", "") ?? "0");

				return nowVer < latestVer;
			}
			catch
			{
				Error.Add(new ErrorItem()
				{
					Code = Error.CODE_VERSION_COMPARE_FAILURE,
					ErrorTextArgs = new string[] { $"現:{now ?? "null"}, 新:{latest ?? "null"}" }
				});
				return false;
			}
		}

		/// <summary>
		/// カレントディレクトリをリフレッシュする
		/// </summary>
		/// <remarks>
		/// コマンド実行したとき、カレントディレクトリがそのパスになってしまうため、exeのフォルダに変更する。
		/// </remarks>
		void RefreshCurrentDirectory()
		{
			string pass = System.Reflection.Assembly.GetEntryAssembly().Location;
			pass = pass.Replace("Tatelier.exe", "");
			pass = pass.Replace("\\\\", "/");
			Environment.CurrentDirectory = Path.GetFullPath(pass);
		}

		/// <summary>
		/// 現在時間をリフレッシュする
		/// </summary>
		void RefreshNowTime()
		{
			NowMicroSec = GetNowHiPerformanceCount();
			NowMilliSec = (int)(NowMicroSec / 1000);
		}

		/// <summary>
		/// メイン関数(C#用)
		/// </summary>
		/// <param name="args">引数</param>
		void MainRun(string[] args)
		{

			RefreshNowTime();
			ModuleControl.Singleton.Start();

			string Title = $"Tatelier v{Version}";

			var fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
	
			if (fileVersionInfo.Comments.Length > 0)
			{
				Title += $"{fileVersionInfo.Comments}";
			}


			Splash.SplashWindow a = null;

			if (MainConfig.Singleton.ShowSplashWindow)
			{
				a = new Splash.SplashWindow(Version);
				Task.Run(() =>
				{
					a.ShowDialog();
				});
			}

			Engine = new Engine.Engine();
			Engine.Start<DxLib.TempScene>(this);

			MainConfig.Singleton.Initialize();

			SetOutApplicationLogValidFlag(DX_FALSE);
			SetEnableXAudioFlag(MainConfig.Singleton.UseXAudio ? DX_TRUE : DX_FALSE);


			{
				Hjson.JsonValue themeJson;

				string path = Path.Combine(MainConfig.Singleton.ThemeFolderPath, Define.ThemeFileName);

				if (File.Exists(path))
				{
					themeJson = HjsonEx.HjsonEx.LoadEx(path);
				}
				else
				{
					themeJson = new Hjson.JsonObject();

					Error.Add(new ErrorItem()
					{
						Code = Error.CODE_404_THEME_HJSON
					});
				}

				SetInitDrawMode(themeJson.EQv("DrawMode"));
				SetInitWindow(themeJson.EQv("Window"));

				ThemeConfig.Singleton.Load(path);
			}

			ChangeWindowMode(1);
			SetAlwaysRunFlag(1);

			// ＤＸライブラリの WM_PAINT メッセージの処理を行わないようにする
#if OBSERVE_THREAD_ON
			SetUseDxLibWM_PAINTProcess(0);
#endif
			SetWindowStyleMode(7);
			SetWindowSizeChangeEnableFlag(1);
			ChangeFont(MainConfig.Singleton.DefaultFont);

			ChangeFontType(DX_FONTTYPE_ANTIALIASING_4X4);
			SetFontSize(Define.DefaultFontSize);
			SetWindowVisibleFlag(DX_FALSE);
			// ScreenFlip を実行しても垂直同期信号を待たない
			//SetWaitVSyncFlag(FALSE);
			SetDoubleStartValidFlag(DX_TRUE);
#if OBSERVE_THREAD_ON
			SetMultiThreadFlag(TRUE);
#endif
			SetWindowUserCloseEnableFlag(DX_FALSE);

			int ret = 0;
			ret = DxLib_Init();
			SetUseGraphBaseDataBackup(DX_FALSE);

			SetRestoreGraphCallback(() =>
			{
				Error.Add(Error.CODE_DXLIB_CALL_RESTORE);
				throw new Exception();
			});

			if (ret != 0)
			{
				Error.Add(Error.CODE_DXLIB_INIT_FAILURE);
			}

#if OBSERVE_THREAD_ON
			STATask.Run(() =>
			{
#endif
			int screen = -1;

			do
			{
				try
				{
					if (a == null)
					{
						if (MainConfig.Singleton.ShowSplashWindow)
						{
							a = new Splash.SplashWindow(Version);
							Task.Run(() =>
							{
								a.ShowDialog();
							});
						}
					}

					SetWindowVisibleFlag(DX_FALSE);

					IsExit = false;
					IsReboot = false;

					SetDrawScreen(DX_SCREEN_BACK);

					int prevX, prevY;

					GetWindowSize(out prevX, out prevY);

					GetDefaultState(out int desktopWidth, out int desktopHeight, out _, out _, out _, out _, out _, out _, out _, out _);

					Error.AllClear();

					ProgressControl.Singleton.Start();
					MyMessageBox.Singleton.Start();
					Command.Singleton.Start();
					SoundGroupShare.Singleton.Start();
					TransitionShare.Singleton.Start();

					var connect = new Connect.AuthConnect();
					var result = connect.Act(Environment.CurrentDirectory, Version);

					Share.Singleton.TokenInfo = new TokenInfo(result?.EQv("info"));

					Share.Singleton.Start();
					Share.Singleton.Connect = connect;

					if (Error.HasError)
					{
						throw new Exception();
					}

					{
						if (!Share.Singleton.Connect.HasError)
						{
							SceneControl.Singleton.Start<Scene.SongSelect>();
						}
						else
						{
							SceneControl.Singleton.Start<Scene.AuthNG>(null);
						}


						if (MainConfig.Singleton.CheckUpdate
							&& HasUpdateVersion(Version, result?.EQs("latest")))
						{
							LogWindow.Singleton.Insert($"最新バージョンが公開されています。", 0xA4FE63);
							LogWindow.Singleton.Insert($"現:v{Version} 新:v{result?.EQs("latest")}", 0xA4FE63);
						}


						if (!Share.Singleton.TokenInfo.Playable)
						{
							for(int i=0; i< MainConfig.Singleton.PlayerInfoList.Length;i++)
                            {
								MainConfig.Singleton.PlayerInfoList[i].PlayOption.Special.Value = SongSelect.PlayOptionSpecialType.Auto;
                            }
						}

						if(Share.Singleton.TokenInfo.RoleNameEN.Length > 0)
						{
							Title += $" - For {Share.Singleton.TokenInfo.RoleNameEN}";
						}
						SetMainWindowText(Title);
					}

					if (MainConfig.Singleton.ShowSplashWindow)
					{
						a.Invoke(new Action(() =>
						{
							a.Close();
							a = null;
						}));
						Task.Delay(500).Wait();
					}

					screen = MakeScreen(ScreenWidth, ScreenHeight);
					Tatelier.Utility.ForceActive(GetMainWindowHandle());
					SetWindowVisibleFlag(DX_TRUE);
					SetDragFileValidFlag(DX_TRUE);


					RefreshNowTime();
					LogWindow.Singleton.Start();

					while (!IsExit)
					{
#if !OBSERVE_THREAD_ON
						if (ProcessMessage() != 0)
						{
							break;
						}
#endif
						ClearDrawScreen();

						SetDrawScreen(screen);
						ClearDrawScreen();

						RefreshNowTime();

						FileDropObserver.Singleton.Update();
		
						Input.Singleton.Update();
						Mouse.Singleton.Update();
						SoundGroupControl.Singleton.Update();

						if (Input.Singleton.GetKeyDown(KEY_INPUT_F11))
						{
							GetWindowSize(out var w, out var h);

							if (w == desktopWidth)
							{
								SetWindowSize(initWindowWidth, initWindowHeight);
								SetWindowStyleMode(7);
								SetWindowSizeChangeEnableFlag(1);
								SetWindowStyleMode(7);
								SetWindowSize(initWindowWidth, initWindowHeight);
								SetWindowPosition(prevX, prevY);
							}
							else
							{
								GetWindowPosition(out prevX, out prevY);
								SetWindowStyleMode(4);
								SetWindowSizeChangeEnableFlag(0);
								SetWindowSize(desktopWidth, desktopHeight);
								SetWindowPosition((prevX + w / 2)/ 1920 * 1920, 0);
							}
						}

#if !OBSERVE_THREAD_ON
						// ×ボタンが押されたかどうかを取得する
						if (GetWindowUserCloseFlag(DX_TRUE) == 1)
						{
							IsExit = true;
							DxLib_End();
							break;
						}
#endif

						Command.Singleton.Update();
						ImageLoadControl.Singleton.Update();
						ProgressControl.Singleton.Update();
						LogWindow.Singleton.Update();

						SceneControl.Singleton.Update();
						MyMessageBox.Singleton.Update();

						SceneControl.Singleton.Draw();
						Command.Singleton.Draw();
						ProgressControl.Singleton.Draw();

						// スクショは更新処理の部分で行ってしまうと黒画面になってしまうため
						// 特例で描画処理の部分でキー入力を見る
						if (Input.Singleton.GetKeyDown(KEY_INPUT_F12))
						{
							string folder = MainConfig.Singleton.ScreenshotsOutputFolder;
							if(!Directory.Exists(folder))
							{
								Directory.CreateDirectory(folder);
							}
							string fileName = $"{DateTime.Now:yyyy-MM-dd HH-mm-ss}_Tatelier.png";
							SaveDrawScreenToPNG(0, 0, ScreenWidth, ScreenHeight, Path.Combine(folder, fileName));
							LogWindow.Singleton.Insert($"スクリーンショットを保存しました", LogWindow.UpdateNoticeColor);
							LogWindow.Singleton.Insert($"[{fileName}]", LogWindow.UpdateNoticeColor);
						}

						LogWindow.Singleton.Draw();
						MyMessageBox.Singleton.Draw();


						SetDrawScreen(DX_SCREEN_BACK);
						DrawGraph(0, 0, screen, DX_TRUE);

						ScreenFlip();
					}
				}
				catch (Exception e)
				{
					InitGraph();
					InitSoundMem();

					SetWindowVisibleFlag(DX_TRUE);

					StringBuilder errorMessage = new StringBuilder();

					if (Error.HasError)
					{
						foreach (var item in Error.List)
						{
							errorMessage.Append(item);
						}
					}


					var info = new MyMessageBoxInfo()
					{
						MessageType = MessageType.Error,
						Text = $"致命的なエラーが発生しました。\n\n{errorMessage}\n\n{errorMessage}\n\n{errorMessage}\n{e.GetType().FullName}\n----\n{e.Message}\n\n{e.StackTrace}",
						MyMessageBoxItems = new MyMessageBoxItemInfo[]
						{
							new MyMessageBoxItemInfo()
							{
								Name = "終了",
								Callback = () =>
								{
									CommandSearchAndRun("/exit");
								}
							},
							new MyMessageBoxItemInfo()
							{
								Name = "再起動",
								Callback = () =>
								{
									CommandSearchAndRun("/reboot");
								}
							},
							new MyMessageBoxItemInfo()
							{
								Name = "レポートを送信(仮)後、再起動する",
								Callback = () =>
								{
									Report.Singleton.Send(new StringBuilder($"{e}"));
									CommandSearchAndRun("/reboot");
								}
							},
						}
					};
					if (Error.HasError)
					{
						var itemInfo = new MyMessageBoxItemInfo()
						{
							Name = "エラー詳細ページを開く",
							Callback = () =>
							{
								Error.OpenDetailFirstPage();
							},
							DoDialogClose = false
						};


						info.MyMessageBoxItems = info.MyMessageBoxItems.Concat(new MyMessageBoxItemInfo[] { itemInfo }).ToArray();
					}
					MyMessageBox.Singleton.Open(info);

					while (!IsExit && ProcessMessage() == 0)
					{
						SetDrawScreen(DX_SCREEN_BACK);
						ClearDrawScreen();

						NowMilliSec = GetNowCount();
						NowMicroSec = GetNowHiPerformanceCount();
						Input.Singleton.Update();
						MyMessageBox.Singleton.Update();
						MyMessageBox.Singleton.Draw();


#if !OBSERVE_THREAD_ON
						// ×ボタンが押されたかどうかを取得する
						if (GetWindowUserCloseFlag(DX_TRUE) == 1)
						{
							IsExit = true;
							DxLib_End();
							break;
						}
#endif

						ScreenFlip();
					}

					ImageLoadControl.Reset();

					InitGraph();
					InitSoundMem();
					InitMusicMem();
					InitFontToHandle();
					InitIndexBuffer();
					InitKeyInput();
					InitMask();
					InitShader();
					InitShaderConstantBuffer();
					InitSoftImage();
					InitSoftSound();
					InitSoftSoundPlayer();
					InitVertexBuffer();
				}


				MyMessageBox.Singleton.Reset();
				Command.Singleton.Reset();
				LogWindow.Singleton.Reset();
				Input.Singleton.Reset();

				Share.Singleton.Reset();
				SoundGroupShare.Singleton.Reset();
				TransitionShare.Singleton.Reset();

				SceneControl.Singleton.Reset();

			} while (IsReboot);

#if OBSERVE_THREAD_ON
		});
#endif

#if OBSERVE_THREAD_ON
			while (ProcessMessage() == 0)
			{
				// ×ボタンが押されたかどうかを取得する
				if (GetWindowUserCloseFlag(TRUE) == 1)
				{
					IsExit = true;
					DxLib_End();
					break;
				}
				Task.Delay(16).Wait();
			}
#endif
		}

#if CPP_ON
		[DllImport("Tatelier.Nucleus.dll", EntryPoint = "Start")]
		extern static void TatelierStart();

		[DllImport("Tatelier.Nucleus.dll", EntryPoint = "Run")]
		extern static void TatelierRun();

		[DllImport("Tatelier.Nucleus.dll", EntryPoint = "Finish")]
		extern static void TatelierFinish();
#endif


		/// <summary>
		/// メイン関数
		/// </summary>
		/// <param name="args">引数</param>
		static void Main(string[] args)
		{

			try
			{
#if CPP_ON
				int[] a = new int[]
				{
					0,1,2,3,4,5,6,
				};

				for(int i = 0; i < a.Length; i++)
				{
					Trace.WriteLine($"{i} - Next:{a[(i + 1) % a.Length]}, Prev{a[(i + (a.Length - 1)) % a.Length]}");
				}

				TatelierStart();
				TatelierRun();
				TatelierFinish();
#else
				Singleton = new Supervision();
				Singleton.MainRun(args);
#endif
			}
			catch (Exception e)
			{
				var errorMessage = new StringBuilder();

				if (Error.HasError)
				{
					foreach (var item in Error.List)
					{
						errorMessage.Append(item);
					}
				}

				MessageBox.Show($"致命的なエラーが発生しました。\n\n{e.Message}\n\n{e?.InnerException?.Message}\n\n{errorMessage}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        void Engine.ISupervision.AfterModuleStart()
        {

        }

        void Engine.ISupervision.BeforeModuleStart()
        {

        }

        Supervision()
		{
			RefreshCurrentDirectory();
		}
	}
}
