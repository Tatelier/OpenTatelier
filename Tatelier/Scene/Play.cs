using Tatelier.Play;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;
using System.Xml.Linq;
using Tatelier.Interface.Play;
using Tatelier.DxLibDLL;
using HjsonEx;
using Tatelier.Interface.Command;
using System.Net.Sockets;
using System.Threading;
using Tatelier.Progress;
using Tatelier.Score;
using Tatelier.Score.Play.Chart.TJA;
using System.Windows;
using Tatelier.Score.Component.NoteSystem;

namespace Tatelier.Scene
{
    class CommonInfo
	{
		public int GreatRange = 30;
		public int GoodRange = 50;
		public int BadRange = 65;
	}

	partial class Play : SceneBase
	{
		public override SceneType SceneType => SceneType.Play;

		public static SceneBase Create() => new Play();

		const int StartOffset = -2000;

		static int StartDrawPointX = 1920 + 196;
		static int FinishDrawPointX = 0 - 196;

		public SongSelect SongSelect;

		Coroutine.CoroutineControl coroutineControl;

		Dictionary<string, Func<string, string[], ResultType>> commandMap = new Dictionary<string, Func<string, string[], ResultType>>();

		#region コマンド関連
		ResultType CommandAuto(string command, string[] args)
		{
			for (int i = 0; i < players.Length; i++)
			{
				if (i < MainConfig.Singleton.PlayerInfoList.Length
					&& MainConfig.Singleton.PlayerInfoList[i].PlayOption.Special.Value == Tatelier.SongSelect.PlayOptionSpecialType.Auto)
				{
					players[i].PlayStyle = PlayStyle.HyperAuto;
				}
				else
				{
					players[i].PlayStyle = PlayStyle.Yourself;
				}
			}

			LogWindow.Singleton.Insert("演奏中に演奏設定が変更されたため、今回の結果は保存されません。", LogWindow.WarningColor);
			return ResultType.Exit;
        }

		ResultType CommandSpeed(string command, string[] args)
		{
			for (int i = 0; i < players.Length; i++)
			{
				players[i].CanBeSaved = false;
				players[i].PlayOptionScrollSpeed = MainConfig.Singleton.PlayerInfoList[i].PlayOption.ScrollSpeed.Value;
				players[i].Score.BuildScoreRendererData(players[i].NoteFieldControl.Width, StartDrawPointX, FinishDrawPointX, (float)MainConfig.Singleton.PlayerInfoList[i].PlayOption.ScrollSpeed.Value);
			}
			LogWindow.Singleton.Insert("演奏中に演奏設定が変更されたため、今回の結果は保存されません。", LogWindow.WarningColor);

			return ResultType.Exit;
		}

		public override ResultType CommandSearchAndRun(string command, params string[] args)
		{
			if (commandMap.TryGetValue(command, out var func))
			{
				return func(command, args);
			}
			else
			{

				switch (command)
				{
					case "/c":
						{
							ConnectManager.Singleton.ConnectScoreEditor(new ConnectScoreEditInfo()
							{
								TJAFilePath = Share.Singleton.SelectInfo.TJASelectItem.RelativeFilePath
							});
							string[] inputList = new string[players.Length];
							for (int i = 0; i < players.Length; i++)
							{
								string name = $"Player{i + 1:000}";
								inputList[i] = name;
								InputControl.Singleton.Regist(name, players[i].Input);
							}

							InputControl.Singleton.ChangeInput(inputList);
						}
						return ResultType.Exit;
					case "\nScoreRefresh":
						{
							string tjaPath = Share.Singleton.ScoreFilePath;

							var refreshTja = new TJA();
							refreshTja.Load(new TJALoadInfo()
							{
								FilePath = tjaPath,
								TJALoadPlayerInfoList = new TJALoadPlayerInfo[]
								{
									new TJALoadPlayerInfo("Easy"),
									new TJALoadPlayerInfo("Normal"),
									new TJALoadPlayerInfo("Hard"),
									new TJALoadPlayerInfo("Oni"),
								},
							});
							if (!refreshTja.WaveFileName.StartsWith(tja.WaveFileName))
							{
								DeleteSoundMem(bgm);

								SetUseASyncLoadFlag(DX_TRUE);
								SetCreateSoundDataType(DX_SOUNDDATATYPE_MEMPRESS);
								bgm = SoundGroupShare.Singleton.BGM.Load(refreshTja.WaveFileName);
								SetCreateSoundDataType(DX_SOUNDDATATYPE_MEMNOPRESS);
								SetUseASyncLoadFlag(DX_FALSE);

								//while (CheckHandleASyncLoad(bgm) != 0) Task.;

								if (!MainConfig.Singleton.PlaySong)
								{
									ChangeVolumeSoundMem(0, bgm);
								}
							}
							tja = refreshTja;
						}
						return ResultType.Exit;
					case "//result":
						coroutineControl.StartCoroutine(GetTransitionToResult());
						return ResultType.Exit;
					default:
						return ResultType.NotFound;
				}
			}
		}
		#endregion

		InnerStatus status = InnerStatus.Play;

		Player[] players;

		PlayerInfo[] playerInfoList;

		CommonInfo info;

		TaikoSEControl MoveSE;

		LyricImageControl lyric;

		MeasureLineImageControl BarLineImageControl;

        //Image3 stage;
        //Image3 stageBack;

        TJA tja;

		int pauseStartCount = -1;

		int bgm = -1;

		ISong song;

		Dancer dancer;

		Tatelier.SongSelect.SelectItemControl selectItemControl;

		PauseScreen pauseScreen;

		BPMStatusControl bpmStatusControl;

		MeasureStatusControl measureStatusControl;

		Title title;

		(int PlayerNumbrt, Action<int> Act)[] drawActList;
		(int PlayerNumbrt, Action<int> Act)[] updateActList;

		/// <summary>
		/// 描画処理紐付けマップ
		/// </summary>
		/// <returns>マップ</returns>
		Dictionary<string, Action<int>> CreateDrawActionMap()
		{
			return new Dictionary<string, Action<int>>()
			{
				{ PlayerConfig.MapKey.BackgroundUpper, DrawBackgroundUpper },
				{ PlayerConfig.MapKey.BackgroundLower, DrawBackgroundLower },
				{ PlayerConfig.MapKey.BackgroundStage, DrawStage },
				{ PlayerConfig.MapKey.BalloonNumber, DrawBalloonNumber },
				{ PlayerConfig.MapKey.Chara, DrawChara },
				{ PlayerConfig.MapKey.ComboNumber, DrawComboNumber },
				{ PlayerConfig.MapKey.Dancer, DrawDancer },
				{ PlayerConfig.MapKey.DetailInfo, DrawDetailInfo },
				{ PlayerConfig.MapKey.JudgeFrame, DrawJudgeFrame },
				{ PlayerConfig.MapKey.JudgeText, DrawJudgeText },
				{ PlayerConfig.MapKey.Lyric, DrawLyric },
				{ PlayerConfig.MapKey.Measure, DrawMeasure },
				{ PlayerConfig.MapKey.Note, DrawNote },
				{ PlayerConfig.MapKey.NoteHit, DrawNoteHit },
				{ PlayerConfig.MapKey.NoteField, DrawNoteField },
				{ PlayerConfig.MapKey.NoteFieldEffect, DrawNoteFieldEffect },
				{ PlayerConfig.MapKey.NoteFieldGogo, DrawNoteFieldGogo },
				{ PlayerConfig.MapKey.NoteFieldBranch, DrawBranchField },
				{ PlayerConfig.MapKey.NoteFlyEffect, DrawNoteFlyEffect },
				{ PlayerConfig.MapKey.Other, DrawOther },
				{ PlayerConfig.MapKey.RollNumber, DrawRollNumber },
				{ PlayerConfig.MapKey.ScoreNumber, DrawScoreNumber },
				{ PlayerConfig.MapKey.SoulGauge, DrawSoulGauge },
				{ PlayerConfig.MapKey.Taiko, DrawTaiko },
				{ PlayerConfig.MapKey.Title, DrawTitle }
			};
		}

		/// <summary>
		/// 更新処理紐付マップ
		/// </summary>
		/// <returns>マップ</returns>
		Dictionary<string, Action<int>> CreateUpdateActionMap()
		{
			return new Dictionary<string, Action<int>>()
			{
				{ PlayerConfig.MapKey.ComboNumber, UpdateComboNumber },
				{ PlayerConfig.MapKey.Chara, UpdateChara },
				{ PlayerConfig.MapKey.Lyric, UpdateLyric },
			};
		}

		Load load;

		bool IsFinish => song.IsEnd;



		/// <summary>
		/// 設定からを読み込むイテレータ
		/// </summary>
		/// <param name="index">プレイヤー要素番号</param>
		/// <param name="configResult"></param>
		/// <returns></returns>
		IEnumerator<(float, object)> GetLoadPlayerConfigIterator(int index, int seed, PlayerConfig configResult)
		{
			string playFolder = MainConfig.Singleton.GetThemePath("Play");

			var playerInfo = playerInfoList[index];

			var dic = new Dictionary<string, object>()
			{
				{ "PlayerNumber", index + 1 }
			};

			var variableMap = new Hjson.JsonObject()
			{
				{ "SoundEffect", playerInfo.Json?.EQv("Play.SoundEffect") }
			};

			Func<Hjson.JsonValue, bool> linqFunc = new Func<Hjson.JsonValue, bool>(v => (v.EQi("Player") ?? 1) - 1 == index);

			var elementInfo = new ElementInfo()
			{
				linqFunc = linqFunc,
				variableMap = variableMap,
				folder = playFolder,
			};

			// コルーチン用実施済率の計算
			float diff = 1.0F / 2;

			var player = new Player();

			var noteImageControl = new NoteImageControl(playFolder, configResult.Get(PlayerConfig.Type.Note).FirstOrDefault(linqFunc));

			player.Score = tja.Scores[index];
			var define = new PlayDefine();
			define.SetDiffPoint(tja.Scores[index].MaxNoteCount);

			player.BalloonControl = new BalloonControl(player.Score.BalloonCountList);
			player.BPMStatusControl = new BPMStatusControl(tja.Scores[index].BranchScoreControl);

			player.BranchCondition = new BranchCondition(tja.Scores[index].BranchPlayInfoList.ToArray(), tja.Scores[index].SectionList.ToArray());
			player.BranchScoreControl = tja.Scores[index].BranchScoreControl;

			player.Chara = new Chara(playFolder, configResult.Get(PlayerConfig.Type.Chara).FirstOrDefault(linqFunc));
			player.ComboNumberImageControl = new ComboNumberImageControl(playFolder, configResult.Get(PlayerConfig.Type.ComboNumberImageControl).FirstOrDefault(linqFunc));
			 
			player.GogoCondition = new GogoCondition(tja.Scores[index].GogoList.ToArray());

			player.Input = new InputControlItemPlay(configResult.Get(PlayerConfig.Type.KeyConfig).FirstOrDefault(), index + 1);

			player.JudgeFrame = new JudgeFrame(playFolder, configResult.Get(PlayerConfig.Type.JudgeFrame).FirstOrDefault(linqFunc));

			player.JudgeImageControl = new JudgeImageControl(playFolder, configResult.Get(PlayerConfig.Type.JudgeText).FirstOrDefault(linqFunc));

			player.NoteFieldControl = new NoteFieldControl(playFolder, tja.Scores[index].HasBranch, configResult.Get(PlayerConfig.Type.NoteFieldControl).FirstOrDefault(linqFunc));
			player.NoteText = new NoteText(playFolder, configResult.Get(PlayerConfig.Type.Note).FirstOrDefault(linqFunc)?.EQv("NoteText"));
			player.NoteFlyEffect = new NoteFlyEffect(new NoteFlyEffectInfo()
			{
				DonImageHandle = noteImageControl.GetImageHandle(NoteType.Don),
				KatImageHandle = noteImageControl.GetImageHandle(NoteType.Kat),
				DonBigImageHandle = noteImageControl.GetImageHandle(NoteType.DonBig),
				KatBigImageHandle = noteImageControl.GetImageHandle(NoteType.KatBig),
			}, configResult.Get(PlayerConfig.Type.NoteFlyEffect).FirstOrDefault(linqFunc));

			if(player.Score.ScoreType == ScoreType.Normal)
			{
				player.NoteRenderer = new NormalScoreRenderer(player);
			}
            else
			{
				player.NoteRenderer = new HBScrollScoreRenderer(player);
			}
			player.NoteRenderer.IsNoteHide = playerInfo.PlayOption.NoteHide.IsNoteHide;
			player.NoteImageControl = noteImageControl;
			player.BarLineImageControl = BarLineImageControl;

			player.ResultData = new Tatelier.Result.ResultData(define);

			player.RollNumberImageControl = new RollNumberImageControl(playFolder, configResult.Get(PlayerConfig.Type.RollNumber).FirstOrDefault(linqFunc));

			player.BalloonNumberImageControl = new BalloonNumberImageControl(playFolder, configResult.Get(PlayerConfig.Type.BalloonNumber).FirstOrDefault(linqFunc));

			player.PlayInputItemControl = new PlayInputItemControl();

			player.ScoreNumberImageControl = new ScoreNumberImageControl(playFolder, configResult.Get(PlayerConfig.Type.ScoreNumberImageControl).FirstOrDefault(linqFunc));
			player.SoulGauge = new SoulGauge(
				playFolder, configResult.Get(PlayerConfig.Type.SoulGaugeList).FirstOrDefault(linqFunc),
				new SoulGauge.Info()
				{
					NoteNum = tja.Scores[index].MaxNoteCount,
				});

			player.TaikoImageControl = new TaikoImageControl(
				playFolder, Share.Singleton.PlayerData[index].TaikoImage,
				index, configResult.Get(PlayerConfig.Type.TaikoImageControl).FirstOrDefault(linqFunc));


			{
				elementInfo.jsonList = configResult.Get(PlayerConfig.Type.SoundEffect);
				elementInfo.variableMap = variableMap;

				player.TaikoSEControl = new TaikoSEControl(elementInfo);

			}

			yield return (diff, null);

			player.Background3 = new Background3(playFolder, configResult.Get(PlayerConfig.Type.Background).FirstOrDefault(linqFunc));
			player.Background3.Init(playFolder, configResult.Get(PlayerConfig.Type.BackgroundUpper).FirstOrDefault(linqFunc), seed, dic);
			player.Background3.Init(playFolder, configResult.Get(PlayerConfig.Type.BackgroundLower).FirstOrDefault(linqFunc), seed, dic);
			player.Background3.Init(playFolder, configResult.Get(PlayerConfig.Type.BackgroundStage).FirstOrDefault(linqFunc), seed, dic);


			// 
			player.PlayOptionScrollSpeed = MainConfig.Singleton.PlayerInfoList[index].PlayOption.ScrollSpeed.Value;
			player.Score.BuildScoreRendererData(player.NoteFieldControl.Width, StartDrawPointX, FinishDrawPointX, (float)player.PlayOptionScrollSpeed);

			player.HitImageControl = new HitImageControl(playFolder, configResult.Get(PlayerConfig.Type.NoteHit).FirstOrDefault(linqFunc));

			yield return (1, player);
		}

		/// <summary>
		/// ランダム
		/// </summary>
		/// <returns></returns>
		IEnumerator<(float, object)> GetLoadRandomTja()
		{
			// 非同期処理用
			Task task = null;

			// 次の譜面
			TJA nextTja = null;

			// 次のコース
			Tatelier.SongSelect.Course[] nextCourse = null;

			string tjaDir = "";

			// 選曲項目管理がnullの場合は読み込む
			task = Task.Run(() =>
			{
				if (selectItemControl == null)
				{
					var config2 = new Tatelier.SongSelect.SongSelectConfig(new Tatelier.SongSelect.SongSelectConfig.Info()
					{
						Json = HjsonEx.HjsonEx.LoadEx(Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"SongSelect\SongSelectConfig.hjson")),
					});
					selectItemControl = new Tatelier.SongSelect.SelectItemControl(MainConfig.Singleton.ScoreFolderPath, config2.SelectItemList.FirstOrDefault());
				}
			});
			while (!task.IsCompleted) yield return (0, null);
			task = null;

			// 選曲項目管理で取得したすべての譜面から
			// ランダムに譜面を1つ選ぶ
			task = Task.Run(() =>
			{
				var item = selectItemControl.GetAllMusicalScoreSelectItem().Where(v =>
				{
					if (!(v is Tatelier.SongSelect.MusicalScoreSelectItem tja))
					{
						return false;
					}
					return tja.TJA.Courses.Any(W => W.Level > 0);
				}).RandomAt();
				var path = selectItemControl.GetFilePath(item);
				var nextTjaOV = item.TJA;

				nextCourse = new Tatelier.SongSelect.Course[Share.Singleton.PlayerNum];
				var whereList = nextTjaOV.Courses.Where(W => W.Level > 0);
				for (int i = 0; i < nextCourse.Length; i++)
				{
					nextCourse[i] = whereList.RandomAt();
				}

				var courseNames = nextCourse.Select(v => v.OriginalName).ToArray();

				// 譜面部を読み込む
				nextTja = new TJA();

				var tjaLoadPlayerInfoList = new TJALoadPlayerInfo[courseNames.Length];

				for(int i = 0; i < tjaLoadPlayerInfoList.Length; i++)
				{
					var playerInfo = Share.Singleton.SelectInfo.PlayerInfoList[i];

					bool isNoteInverse = playerInfo.PlayOption.Note.Value == Tatelier.SongSelect.PlayOptionNoteType.Inverse;
					bool isNoteRandom = playerInfo.PlayOption.Note.IsRandom;

					int ratio = playerInfo.PlayOption.Note.RandomRatio;

					tjaLoadPlayerInfoList[i] = new TJALoadPlayerInfo(courseNames[i])
					{
						IsNoteInverse = isNoteInverse,
						IsNoteRandom = isNoteRandom,
						NoteRandomSeed = null,
						NoteRandomRatio = ratio
					};
				}

				nextTja.Load(new TJALoadInfo()
				{
					FilePath = path,
					TJALoadPlayerInfoList = tjaLoadPlayerInfoList,
				});

				tjaDir = Path.GetDirectoryName(item.RelativeFilePath);
			});
			while (!task.IsCompleted) yield return (0, null);

			title.Set(tja.Title);

			task = null;

			tja = nextTja;

			yield return (1, 0);
		}

		public override IEnumerator<float> GetStartIterator()
		{
			commandMap = new Dictionary<string, Func<string, string[], ResultType>>()
			{
				{ "/auto", CommandAuto },
				{ "/speed", CommandSpeed },
			};

			EnterTo(this);

			coroutineControl = new Coroutine.CoroutineControl();
			string playFolder = MainConfig.Singleton.GetThemePath("Play");

			playerInfoList = MainConfig.Singleton.GetPlayerInfoList(Share.Singleton.PlayerNum);

			var hjson = Hjson.HjsonValue.Load(MainConfig.Singleton.GetThemePath($@"Play\PlayConfig\Player{Share.Singleton.PlayerNum:000}.hjson"));

			info = new CommonInfo();

			_ = PlayerConfig.TryLoad(new PlayerConfigInfo()
			{
				DrawActionMap = CreateDrawActionMap(),
				UpdateActionMap = CreateUpdateActionMap(),
				PlayerNum = Share.Singleton.PlayerNum,
				Json = hjson,
			}, out var cr);

			players = cr.Players;
			drawActList = cr.DrawActList;
			updateActList = cr.UpdateActList;

			string[] courseNames = new string[players.Length];

			for (int i = 0; i < players.Length; i++)
			{
				courseNames[i] = i < Share.Singleton.SelectInfo.CourseNames.Length
					? Share.Singleton.SelectInfo.CourseNames[i]
					: Share.Singleton.SelectInfo.CourseNames[0];
			}

			tja = new TJA();

			var tjaLoadPlayerInfoList = new TJALoadPlayerInfo[courseNames.Length];

			for (int i = 0; i < tjaLoadPlayerInfoList.Length; i++)
			{
				var playerInfo = Share.Singleton.SelectInfo.PlayerInfoList[i];

				bool isNoteInverse = playerInfo.PlayOption.Note.Value == Tatelier.SongSelect.PlayOptionNoteType.Inverse;
				bool isNoteRandom = playerInfo.PlayOption.Note.IsRandom;

				int ratio = playerInfo.PlayOption.Note.RandomRatio;

				tjaLoadPlayerInfoList[i] = new TJALoadPlayerInfo(courseNames[i])
				{
					IsNoteInverse = isNoteInverse,
					IsNoteRandom = isNoteRandom,
					NoteRandomSeed = null,
					NoteRandomRatio = ratio
				};
			}

			tja.Load(new TJALoadInfo()
			{
				FilePath = Share.Singleton.ScoreFilePath,
				TJALoadPlayerInfoList = tjaLoadPlayerInfoList,
			});

			BarLineImageControl = new MeasureLineImageControl(playFolder, null);

			// プレイヤー毎のデータを作成
			{
				load = new Load();
				var loadInfoArray = new LoadItemInfo[players.Length];

				int seed = GetNowCount();
				for (int i = 0; i < players.Length; i++)
				{
					loadInfoArray[i] = new LoadItemInfo()
					{
						Iterator = GetLoadPlayerConfigIterator(i, seed, cr),
						Text = $"各プレイヤー設定情報{i + 1:00}",
						Name = $"Player{i + 1:00}",
					};
				}
				load.Set(loadInfoArray);
				while (!load.IsFinish) load.Update();

				for (int i = 0; i < loadInfoArray.Length; i++)
				{
					players[i] = load.GetResultObject($"Player{i + 1:00}") as Player;

					players[i].StartDrawPointX = StartDrawPointX;
					players[i].FinishDrawPointX = FinishDrawPointX;
					players[i].PlayOptionScrollSpeed = MainConfig.Singleton.PlayerInfoList[i].PlayOption.ScrollSpeed.Value;
					tja.Scores[i].BuildScoreRendererData(players[i].NoteFieldControl.Width, StartDrawPointX, FinishDrawPointX, (float)players[i].PlayOptionScrollSpeed);
					players[i].Score = tja.Scores[i];
				}
				load = null;
			}

			for (int i = 0; i < players.Length; i++)
			{
				cr.Players[i].PlayerInfo = playerInfoList[i];
			}

			MoveSE = new TaikoSEControl(new TaikoSEControlInfo()
			{
#if DEBUG
				DonFilePath = Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"Sound\Taiko\OK.wav"),
				KatFilePath = Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"Sound\Taiko\Move.wav"),
#else
				DonFilePath = Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"Sound\Taiko\don.wav"),
				KatFilePath = Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"Sound\Taiko\kat.wav"),
#endif
			});

			pauseScreen = new PauseScreen(Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"Play/PauseScreen"));
			title = new Title(tja.Title, cr.Get(PlayerConfig.Type.TitleControl).FirstOrDefault());

			AutoRoll = GetIteratorAutoRoll();
			AddOnUpdate += UpdateAdmirationMode;

			//ConnectManager.Singleton.ConnectScoreEditor(new ConnectScoreEditInfo()
			//{
			//	TJAFilePath = Share.Singleton.ScoreFilePath
			//});

			// BPM状態クラス
			measureStatusControl = new MeasureStatusControl();

			enumDrawOther = GetEnumDrawOther();
			foreach (var item in cr.Get(PlayerConfig.Type.Other))
			{
				otherList.Add(new Other(playFolder, item));
			}

			var tjaDir = Path.GetDirectoryName(Share.Singleton.ScoreFilePath);

			string waveFullPath = Path.Combine(tjaDir, tja.WaveFileName);

			string convertFileContentPath = Path.Combine(Path.GetTempPath(),"Tatelier\\info.txt");

			string prevConvertPath = "";

			if (File.Exists(convertFileContentPath))
			{
				prevConvertPath = Path.GetFullPath(File.ReadAllText(convertFileContentPath));
			}

			if (Path.GetExtension(waveFullPath).EndsWith("mp3"))
			{
				const int PortRangeStart = 65001;
				const int PortRangeEnd = 65020;

				string dest = Path.Combine(Path.GetTempPath(), "Tatelier\\temp.ogg");
				int port = PortRangeStart;

				if (prevConvertPath != Path.GetFullPath(waveFullPath))
				{
					var condition = new AutoResetEvent(false);

					var progress = new Tatelier.Progress.Progress()
					{
						StatusText = "MP3をOGGに変換中...",
						Max = 100,
						NowValue = 0,
					};

					TcpListener listener = null;
					var task = Task.Run(() =>
					{
						while (port < PortRangeEnd)
						{
							try
							{
								listener = TcpListener.Create(port);
								listener.Start();
								break;
							}
							catch
							{
								port++;
								continue;
							}
						}

						if(listener == null)
						{
							MyMessageBox.Singleton.Open(new MyMessageBoxInfo()
							{
								Text = "MP3音源の変換に失敗しました。無音で処理を続けます。",
								MessageType = MessageType.Error,
							});
						}

						condition.Set();
						var client = listener.AcceptTcpClient();

						byte[] buffer = new byte[16];

						try
						{
							bool quit = false;

							while (!quit)
							{
								client.GetStream().Read(buffer, 0, buffer.Length);

								switch (buffer[0])
								{
									case 0:
										ProgressControl.Singleton.Create(progress);
										break;
									case 1:
										progress.NowValue = BitConverter.ToInt32(buffer, 1);
										break;
									case 2:
										quit = true;
										progress.NowValue = progress.Max;
										break;
								}
							}
						}
						catch
						{

						}

						listener.Stop();
					});

					condition.WaitOne();
					var pInfo = new ProcessStartInfo("audio-convert.exe", $"\"{waveFullPath}\" -d \"{dest}\" -p {port}")
					{
						CreateNoWindow = true, // コンソール・ウィンドウを開かない
						UseShellExecute = false // シェル機能を使用しない
					};
					var process = Process.Start(pInfo);

					while (!process.HasExited)
					{
						yield return 0;
					}

					progress.NowValue = progress.Max;

					if (process.ExitCode == 0)
					{
						File.WriteAllText(convertFileContentPath, Path.GetFullPath(waveFullPath));
						waveFullPath = dest;
					}
				}
				else
				{
					waveFullPath = dest;
				}
			}

			bgm = Utility.CreateBgm(waveFullPath);

			if (bgm != -1)
			{
				Song s = new Song();
				s.Init(bgm);
				song = s;

				if (!MainConfig.Singleton.PlaySong)
				{
					ChangeVolumeSoundMem(0, bgm);
				}
			}
			else
			{
				int total = 2000 + (tja.Scores.Select(v => v.Notes.Max(w => w.FinishMillisec)).OrderByDescending(v => v)?.FirstOrDefault() ?? 0) + 5000;
				song = new EmptySong(total);
			}

			string[] inputList = new string[players.Length];
			for (int i = 0; i < players.Length; i++)
			{
				string name = $"Player{i + 1:000}";
				inputList[i] = name;
				InputControl.Singleton.Regist(name, players[i].Input);
			}

			InputControl.Singleton.ChangeInput(inputList);

			dancer = new Dancer(Path.Combine(MainConfig.Singleton.ThemeFolderPath, "Play"), null)
			{
				BPM = tja.StartBPM
			};

			lyric = new LyricImageControl(tja.GetLyricFilePath(tjaDir), cr.Get(PlayerConfig.Type.Lyric).FirstOrDefault());

			foreach (var player in players)
			{
				player.Chara.BPM = tja.StartBPM;
			}

			for (int i = 0; i < players.Length; i++)
			{
				if (i < MainConfig.Singleton.PlayerInfoList.Length
					&& MainConfig.Singleton.PlayerInfoList[i].PlayOption.Special.Value == Tatelier.SongSelect.PlayOptionSpecialType.Auto)
				{
					players[i].PlayStyle = PlayStyle.HyperAuto;
				}
			}

			song.CurrentTime = (tja.Scores[0].OffsetMillisec);

			song.CurrentTime = StartOffset;

			var md5 = Utility.GetMD5FromFile(Share.Singleton.ScoreFilePath);
			var now = DateTime.Now;

			Share.Singleton.Result = players.Select(v => v.ResultData).ToArray();
			foreach (var item in Share.Singleton.Result)
			{
				item.PlayStartDateTime = now;
				item.MD5 = md5;
			}

			GC.Collect();

			Regist(1.1F);
			//SceneControl.Singleton.RegistBefore(this, TransitionToPlay);
			TransitionShare.Singleton.TransitionToPlay.End();

			song.Play();

			ModuleControl.Singleton.DiscordState = $"{tja.Title} を \n{playerInfoList.Length}人で演奏中";

			yield break;
		}

		public override void Start()
		{
		}

		int nowMillisec = 0;

		Action AddOnUpdate;

		IEnumerator<bool> AutoRoll;
		IEnumerator<bool> GetIteratorAutoRoll()
		{
			int delayTime = 50;
			int time = int.MinValue;
			while (true)
			{
				if (time < nowMillisec)
				{
					time = nowMillisec + delayTime;
					yield return true;
				}
				else
				{
					yield return false;
				}
			}
		}

		IEnumerator GetTransitionToResult()
		{
			TransitionShare.Singleton.TransitionToResult.Begin();
			RegistMusicalScoreSaveData();
			yield return new Coroutine.Wait(1250);

			SceneControl.Singleton.Destroy(this);
			SceneControl.Singleton.Create("Result", out Result s);	
			s.SongSelect = SongSelect;
			s.Regist(1.3F);
			EnterTo(s);
		}

		void UpdateAdmirationMode()
		{
			if (song.IsEnd)
			{
				if (Share.Singleton.IsRepeat)
				{
					if (load == null)
					{
						var hjson = Hjson.HjsonValue.Load(Path.Combine(MainConfig.Singleton.ThemeFolderPath, $@"Play\PlayConfig\Player{players.Length:000}.hjson"));

						var cinfo = new PlayerConfigInfo()
						{
							DrawActionMap = CreateDrawActionMap(),
							UpdateActionMap = CreateUpdateActionMap(),
							PlayerNum = players.Length,
							Json = hjson,
						};

						PlayerConfig.TryLoad(cinfo, out var cr);

						load = new Load();

						var loadInfoArray = new LoadItemInfo[players.Length + 1];

						loadInfoArray[0] = new LoadItemInfo
						{
							Iterator = GetLoadRandomTja(),
							Text = "次の譜面",
							Name = "NextScore",
						};

						int seed = GetNowCount();
						for (int i = 0; i < players.Length; i++)
						{
							loadInfoArray[i + 1] = new LoadItemInfo()
							{
								Iterator = GetLoadPlayerConfigIterator(i, seed, cr),
								Text = $"各プレイヤー設定情報{i + 1:00}",
								Name = $"Player{i + 1:00}",
							};
						}

						load.Set(loadInfoArray);
					}

					if (!load.IsFinish)
					{
						load.Update();
					}
					else
					{
						for (int i = 0; i < players.Length; i++)
						{
							players[i] = load.GetResultObject($"Player{i + 1:00}") as Player;
							players[i].Score = tja.Scores[i];
							if (MainConfig.Singleton.PlayerInfoList[i].PlayOption.Special.Value == Tatelier.SongSelect.PlayOptionSpecialType.Auto)
							{
								players[i].PlayStyle = PlayStyle.HyperAuto;
							}
							else
							{
								players[i].PlayStyle = PlayStyle.Yourself;
							}
						}

						DeleteSoundMem(bgm);
						var tjaDir = Path.GetDirectoryName(tja.FilePath);
						bgm = Utility.CreateBgm(Path.Combine(tjaDir, tja.WaveFileName));
						song = new Song();
						(song as Song).Init(bgm);
						song.CurrentTime = (tja.Scores[0].OffsetMillisec);
						song.Play();
						load = null;
					}
				}
				else
				{
					coroutineControl.StartCoroutine(GetTransitionToResult());
					AddOnUpdate -= UpdateAdmirationMode;
				}
			}
			if (song is Song s)
			{
				DebugWindow.LeftText[1] = s.DebugText;
			}
		}
		void UpdatePlayCommon1(Player player)
		{
			player.State.Reset();
		}
		void UpdatePlayCommon2(Player player)
		{
			player.GogoCondition.Update(nowMillisec);
			player.NoteFieldControl.Gogo = player.GogoCondition.NowGogo;

			player.Background3.Change(player.SoulGauge.NowStatus);

			player.ComboNumberImageControl.Combo = player.ResultData.Combo;
			player.ScoreNumberImageControl.ScorePoint = player.ResultData.ScorePoint;
			player.TaikoImageControl.Update(player.State.LDon, player.State.RDon, player.State.LKat, player.State.RKat, nowMillisec);
			player.NoteFieldControl.Update(player.State.Don, player.State.Kat, false, nowMillisec);
			player.Chara.IsSoul = player.SoulGauge.IsSoul;
		}

		#region 演奏処理
		/// <summary>
		/// 絶対に完璧に演奏するオート処理
		/// </summary>
		void UpdateSpecialAuto(int playerIndex)
		{
			JudgeType judgeType = JudgeType.None;

			Player player = players[playerIndex];

			UpdatePlayCommon1(player);

			int diffTime = 0;

			if (!player.BranchCondition.LevelHold)
			{
				if (player.BranchScoreControl.TryChangeDeadline(nowMillisec))
				{
					BranchType bt = player.BranchCondition.GetBranchType(nowMillisec);
					player.BranchCondition.Next();

					player.BranchScoreControl.ChangeBranchType(nowMillisec, bt);
					player.NoteFieldControl.BranchType = bt;
				}
			}

            if (player.BranchScoreControl.TryLevelHold(nowMillisec))
            {
				player.BranchCondition.LevelHold = true;
			}

			if (player.BranchCondition.TryDataClear(nowMillisec))
			{

			}


			foreach (var bscore in player.BranchScoreControl.GetBranchScoreList())
			{
				foreach (var noteList1 in bscore.NoteList)
				{
					foreach (var noteList2 in noteList1)
					{
						foreach (var item in noteList2)
						{
							// すでにヒットしている場合は次に進む
							if (item.Hit) continue;

							diffTime = item.StartMillisec - nowMillisec;

							if (item.NoteType != NoteType.End && diffTime > 100) break;

							if (diffTime <= 0)
							{
								switch (item.NoteType)
								{
									case NoteType.Don:
									case NoteType.DonBig:
										player.TaikoSEControl.Play(TaikoSEType.Don);
										player.State.Don = true;
										item.Hit = true;
										item.Visible = false;
										player.JudgeType = JudgeType.Great;
										player.NoteFlyEffect.Fly(item.NoteType, nowMillisec);
										player.ResultData.AddCount(JudgeType.Great);
										judgeType = JudgeType.Great;
										player.SoulGauge.Add(JudgeType.Great);
										player.HitImageControl.Set(nowMillisec, item.NoteType, JudgeType.Great);
										player.BranchCondition.AddCount(judgeType);
										break;
									case NoteType.Kat:
									case NoteType.KatBig:
										player.TaikoSEControl.Play(TaikoSEType.Kat);
										player.State.Kat = true;
										item.Hit = true;
										item.Visible = false;
										player.JudgeType = JudgeType.Great;
										player.NoteFlyEffect.Fly(item.NoteType, nowMillisec);
										player.ResultData.AddCount(JudgeType.Great);
										judgeType = JudgeType.Great;
										player.SoulGauge.Add(JudgeType.Great);
										player.HitImageControl.Set(nowMillisec, item.NoteType, JudgeType.Great);
										player.BranchCondition.AddCount(judgeType);
										break;
									case NoteType.Roll:
										player.RollNumberImageControl.NowRoll = true;

										if (AutoRoll.Current)
										{
											player.NoteFlyEffect.Fly(NoteType.Don, nowMillisec);
											player.ResultData.AddRollCount();
											player.BranchCondition.AddRollCount();
											player.RollNumberImageControl.Number++;
											player.TaikoSEControl.Play(TaikoSEType.Don);
										}
										break;
									case NoteType.RollBig:
										player.RollNumberImageControl.NowRoll = true;

										if (AutoRoll.Current)
										{
											player.NoteFlyEffect.Fly(NoteType.DonBig, nowMillisec);
											player.ResultData.AddRollCount();
											player.BranchCondition.AddRollCount();
											player.RollNumberImageControl.Number++;
											player.TaikoSEControl.Play(TaikoSEType.Don);
										}
										break;
									case NoteType.Balloon:
										{
											player.BalloonNumberImageControl.NowBalloon = true;
											var balloon = player.BalloonControl.GetBalloon(item);

											player.BalloonNumberImageControl.Count = balloon.Count;

											if (AutoRoll.Current)
											{
												if (balloon.AddCount())
												{
													item.Hit = true;
													item.Visible = false;
													player.NoteFlyEffect.Fly(NoteType.DonBig, nowMillisec);
													player.TaikoSEControl.Play(TaikoSEType.Balloon);
													player.BalloonNumberImageControl.NowBalloon = false;
												}
												player.TaikoSEControl.Play(TaikoSEType.Don);
												player.BalloonNumberImageControl.Number++;
											}
										}
										break;
									case NoteType.End:
										item.PrevNote.Hit = true;
										item.Hit = true;
										player.RollNumberImageControl.NowRoll = false;
										if (item.PrevNote.NoteType == NoteType.Balloon)
										{
											item.PrevNote.Visible = false;
											player.BalloonNumberImageControl.NowBalloon = false;
											//player.NoteFlyEffect.Fly(NoteType.DonBig, nowTime);
										}
										break;
								}

								player.JudgeImageControl.Update(judgeType, nowMillisec);
							}
						}
					}
				}
			}

			UpdatePlayCommon2(player);
		}

		/// <summary>
		/// 自分で演奏する
		/// </summary>
		void UpdateYourself(int playerIndex)
		{
			JudgeType judgeType = JudgeType.None;

			Player player = players[playerIndex];

			UpdatePlayCommon1(player);

			INote nearNote = null;
			int diffTime = 0;

			// 入力時に音声を流す
			if (player.Input.GetKeyDown(InputControlItemPlay.LDon))
			{
				player.State.LDon = true;
				player.PlayInputItemControl.Add(nowMillisec, InputControlItemPlay.LDon, JudgeType.None);
			}
			if (player.Input.GetKeyDown(InputControlItemPlay.RDon))
			{
				player.State.RDon = true;
				player.PlayInputItemControl.Add(nowMillisec, InputControlItemPlay.RDon, JudgeType.None);
			}
			if (player.Input.GetKeyDown(InputControlItemPlay.LKat))
			{
				player.State.LKat = true;
				player.PlayInputItemControl.Add(nowMillisec, InputControlItemPlay.LKat, JudgeType.None);
			}
			if (player.Input.GetKeyDown(InputControlItemPlay.RKat))
			{
				player.State.RKat = true;
				player.PlayInputItemControl.Add(nowMillisec, InputControlItemPlay.RKat, JudgeType.None);
			}

			if (player.Input.GetKeyDown(InputControlItemPlay.Don))
			{
				player.TaikoSEControl.Play(TaikoSEType.Don);
			}
			if (player.Input.GetKeyDown(InputControlItemPlay.Kat))
			{
				player.TaikoSEControl.Play(TaikoSEType.Kat);
			}

			if (!player.BranchCondition.LevelHold)
			{
				if (player.BranchScoreControl.TryChangeDeadline(nowMillisec))
				{
					var bt = player.BranchCondition.GetBranchType(nowMillisec);
					player.BranchCondition.Next();

					player.BranchScoreControl.ChangeBranchType(nowMillisec, bt);
					player.NoteFieldControl.BranchType = bt;
				}
			}

			if (player.BranchScoreControl.TryLevelHold(nowMillisec))
			{
				player.BranchCondition.LevelHold = true;
			}

			if (player.BranchCondition.TryDataClear(nowMillisec))
			{

			}

			player.GogoCondition.Update(nowMillisec);
			player.NoteFieldControl.Gogo = player.GogoCondition.NowGogo;

			// 分岐譜面層
			foreach (var bscore in player.BranchScoreControl.GetBranchScoreList())
			{
				// レイヤー層
				foreach (var layer in bscore.NoteList)
				{
					// セクション層
					foreach (var section in layer)
					{
						// 音符層
						foreach (var item in section)
						{
							// すでにヒットしている場合は次に進む
							if (item.Hit) continue;

							diffTime = item.StartMillisec - nowMillisec;

							// 音符の時間が現在時間より250ミリ秒後の場合は、以降の音符の処理をしない
							if (item.NoteType != NoteType.End && diffTime > 250) break;

							// すでに判定で使う音符が特殊音符以外で確定していたら以下の処理はしない
							if (nearNote != null)
							{
								bool isContinue = false;

								switch (nearNote.NoteType)
								{
									case NoteType.Don:
									case NoteType.DonBig:
									case NoteType.Kat:
									case NoteType.KatBig:
										isContinue = true;
										break;
								}
								if (isContinue) continue;
							}

							// 過ぎ去った不可はさよなら
							if (diffTime <= -info.BadRange)
							{
								switch (item.NoteType)
								{
									case NoteType.Don:
									case NoteType.DonBig:
									case NoteType.Kat:
									case NoteType.KatBig:
										item.Hit = true;
										player.ResultData.AddCount(JudgeType.Bad);
										player.BranchCondition.AddCount(JudgeType.Bad);
										player.SoulGauge.Add(JudgeType.Bad);
										player.TaikoSEControl.Play(TaikoSEType.Miss);
										break;
								}
							}
							// 過ぎ去った可
							else if (diffTime <= -info.GoodRange)
							{
								if (player.State.Don)
								{
									switch (item.NoteType)
									{
										case NoteType.Don:
										case NoteType.DonBig:
											nearNote = item;
											judgeType = JudgeType.Good;
											player.HitImageControl.Set(nowMillisec, item.NoteType, JudgeType.Good);
											break;
									}
								}
								if (player.State.Kat)
								{
									switch (item.NoteType)
									{
										case NoteType.Kat:
										case NoteType.KatBig:
											nearNote = item;
											judgeType = JudgeType.Good;
											player.HitImageControl.Set(nowMillisec, item.NoteType, JudgeType.Good);
											break;
									}
								}
							}
							// 良
							else if (-info.GreatRange <= diffTime && diffTime <= info.GreatRange)
							{
								if (player.State.Don)
								{
									switch (item.NoteType)
									{
										case NoteType.Don:
										case NoteType.DonBig:
											nearNote = item;
											judgeType = JudgeType.Great;
											player.HitImageControl.Set(nowMillisec, item.NoteType, JudgeType.Great);
											break;
									}
								}

								if (player.State.Kat)
								{
									switch (item.NoteType)
									{
										case NoteType.Kat:
										case NoteType.KatBig:
											nearNote = item;
											judgeType = JudgeType.Great;
											player.HitImageControl.Set(nowMillisec, item.NoteType, JudgeType.Great);
											break;
									}
								}
							}
							// 可
							else if (diffTime <= info.GoodRange)
							{
								if (player.State.Don)
								{
									switch (item.NoteType)
									{
										case NoteType.Don:
										case NoteType.DonBig:
											nearNote = item;
											judgeType = JudgeType.Good;
											player.HitImageControl.Set(nowMillisec, item.NoteType, JudgeType.Good);
											break;
									}
								}
								if (player.State.Kat)
								{
									switch (item.NoteType)
									{
										case NoteType.Kat:
										case NoteType.KatBig:
											nearNote = item;
											judgeType = JudgeType.Good;
											player.HitImageControl.Set(nowMillisec, item.NoteType, JudgeType.Good);
											break;
									}
								}
							}
							// 不可
							else if (diffTime <= info.BadRange)
							{
								if (player.State.Don)
								{
									switch (item.NoteType)
									{
										case NoteType.Don:
										case NoteType.DonBig:
											nearNote = item;
											judgeType = JudgeType.Bad;
											break;
									}
								}
								if (player.State.Kat)
								{
									switch (item.NoteType)
									{
										case NoteType.Kat:
										case NoteType.KatBig:
											nearNote = item;
											judgeType = JudgeType.Bad;
											break;
									}
								}
							}

							// 特殊音符を処理する
							if (diffTime < 0)
							{
								switch (item.NoteType)
								{
									case NoteType.Roll:
									case NoteType.RollBig:
									case NoteType.Balloon:
									case NoteType.Dull:
										nearNote = item;
										judgeType = JudgeType.None;
										break;
									case NoteType.End:
										if (!item.PrevNote.Hit)
										{
											player.BalloonNumberImageControl.NowBalloon = false;
										}
										item.PrevNote.Hit = true;
										item.Hit = true;
										player.RollNumberImageControl.NowRoll = false;
										break;
								}
							}
						}

					}
				}
			}


			// 叩かれた音符が確定した段階で判定処理
			if (nearNote != null)
			{
				if (!nearNote.Hit)
				{
					switch (judgeType)
					{
						case JudgeType.Great: // 良
						case JudgeType.Good: // 可
							{
								switch (nearNote.NoteType)
								{
									case NoteType.Don:
									case NoteType.Kat:
									case NoteType.DonBig:
									case NoteType.KatBig:
										nearNote.Hit = true;
										nearNote.Visible = false;
										player.NoteFlyEffect.Fly(nearNote.NoteType, nowMillisec);
										player.ResultData.AddCount(judgeType);
										player.BranchCondition.AddCount(judgeType);
										player.SoulGauge.Add(judgeType);
										break;
								}
							}
							break;
						case JudgeType.Bad: // 不可
							{
								switch (nearNote.NoteType)
								{
									case NoteType.Don:
									case NoteType.Kat:
									case NoteType.DonBig:
									case NoteType.KatBig:
										nearNote.Hit = true;
										nearNote.Visible = false;
										player.ResultData.AddCount(judgeType);
										player.BranchCondition.AddCount(judgeType);
										player.SoulGauge.Add(judgeType);
										player.TaikoSEControl.Play(TaikoSEType.Miss);
										break;
								}
							}
							break;
						default:
							switch (nearNote.NoteType)
							{
								case NoteType.Roll:
									player.RollNumberImageControl.NowRoll = true;
									if (player.State.Don)
									{
										player.NoteFlyEffect.Fly(NoteType.Don, nowMillisec);
										player.ResultData.AddRollCount();
										player.BranchCondition.AddRollCount();

										player.RollNumberImageControl.Number++;
									}
									if (player.State.Kat)
									{
										player.NoteFlyEffect.Fly(NoteType.Kat, nowMillisec);
										player.ResultData.AddRollCount();
										player.BranchCondition.AddRollCount();

										player.RollNumberImageControl.Number++;
									}
									break;
								case NoteType.RollBig:
									player.RollNumberImageControl.NowRoll = true;
									if (player.State.Don)
									{
										player.NoteFlyEffect.Fly(NoteType.DonBig, nowMillisec);
										player.ResultData.AddRollCount();
										player.BranchCondition.AddRollCount();

										player.RollNumberImageControl.Number++;
									}
									if (player.State.Kat)
									{
										player.NoteFlyEffect.Fly(NoteType.KatBig, nowMillisec);
										player.ResultData.AddRollCount();
										player.BranchCondition.AddRollCount();

										player.RollNumberImageControl.Number++;
									}
									break;
								case NoteType.Balloon:
									player.BalloonNumberImageControl.NowBalloon = true;

									var balloon = player.BalloonControl.GetBalloon(nearNote);

									player.BalloonNumberImageControl.Count = balloon.Count;
									if (player.State.Don)
									{
										if (balloon.AddCount())
										{
											nearNote.Hit = true;
											nearNote.Visible = false;
											player.TaikoSEControl.Play(TaikoSEType.Balloon);
											player.NoteFlyEffect.Fly(NoteType.DonBig, nowMillisec);
											player.BalloonNumberImageControl.NowBalloon = false;

										}
										player.BalloonNumberImageControl.Number++;
									}
									break;
								case NoteType.End:
									break;
								case NoteType.Dull:
									nearNote.Hit = true;
									break;
							}
							break;
					}
				}
				player.JudgeImageControl.Update(judgeType, nowMillisec);
			}

			UpdatePlayCommon2(player);
		}

		void UpdatePlayStyle(int playerIndex)
		{
			switch (players[playerIndex].PlayStyle)
			{
				case PlayStyle.Yourself:
					UpdateYourself(playerIndex);
					break;
				case PlayStyle.Record:
					UpdateYourself(playerIndex);
					break;
				case PlayStyle.NormalAuto:
				case PlayStyle.HyperAuto:
					UpdateSpecialAuto(playerIndex);
					break;
			}
		}

		#endregion

		Player statusPlayer;

		#region 更新処理
		void UpdateBackground(int playerIndex)
		{
			players[playerIndex].Background3.Update();
		}

		void UpdateComboNumber(int playerIndex)
		{
			players[playerIndex].ComboNumberImageControl.Update();
		}

		void UpdateChara(int playerIndex)
		{
			if (status != InnerStatus.Play) return;

			players[playerIndex].Chara.Update();
		}

		void UpdateLyric(int playerIndex)
		{
			lyric.Update(song.CurrentTime);
		}

		void UpdateInnerStatusPause()
		{
			if (!pauseScreen.Enabled) return;

			pauseScreen.Update();

			if (!pauseScreen.IsCollect)
			{
				// キャンセルと同じ動作にする
				if (statusPlayer.Input.GetKeyDown(InputControlItemPlay.Cancel))
				{
					pauseScreen.MenuIndex = PauseScreenItemIndex.Cancel;
					pauseScreen.IsCollect = true;
				}

				if (statusPlayer.Input.GetKeyDown(InputControlItemPlay.RKat))
				{
					MoveSE.Play(TaikoSEType.Kat);
					pauseScreen.Next();
				}

				if (statusPlayer.Input.GetKeyDown(InputControlItemPlay.LKat))
				{
					MoveSE.Play(TaikoSEType.Kat);
					pauseScreen.Prev();
				}

				if (statusPlayer.Input.GetKeyDown(InputControlItemPlay.Don))
				{
					MoveSE.Play(TaikoSEType.Don);
					pauseScreen.IsCollect = true;
				}

				if (pauseScreen.IsCollect)
				{
					switch (pauseScreen.MenuIndex)
					{
						case PauseScreenItemIndex.Cancel:
							{
								pauseScreen.RefreshToReturnPlay();
								pauseScreen.Visible = false;
							}
							return;
						case PauseScreenItemIndex.Restart:
							{
								SceneControl.Singleton.Destroy(this);
								SceneControl.Singleton.Create(out Play p);
								p.SongSelect = SongSelect;
								pauseScreen.Enabled = false;
							}
							return;
						case PauseScreenItemIndex.ToEditMode:
							{
								SceneControl.Singleton.Destroy(this);
								SceneControl.Singleton.Create(out Multi multi);
								multi.songSelectScene = SongSelect;
								pauseScreen.Visible = false;
							}
							return;
						case PauseScreenItemIndex.ToSongSelect:
							{
								SceneControl.Singleton.Destroy(this);
								SongSelect.Regist(1.0F);
								EnterTo(SongSelect);
								pauseScreen.Enabled = false;
							}
							break;
						default:
							throw new Exception();
					}
				}
			}

			if (pauseScreen.MenuIndex == PauseScreenItemIndex.Cancel
				&& pauseScreen.IsCollect
				&& pauseScreen.IsToReturnPlayOK)
			{
				pauseScreen.Enabled = false;
				status = InnerStatus.Play;
			}
		}

		void UpdateInnerStatusPlay()
		{
			// F1はメニュー表示
			if (players[0].Input.GetKeyDown(KEY_INPUT_F1))
			{
				statusPlayer = players[0];
				pauseStartCount = Supervision.NowMilliSec;
				song.Pause();
				status = InnerStatus.Pause;
				pauseScreen.Visible = true;
				pauseScreen.Enabled = true;
				pauseScreen.Reset();
				return;
			}

			// F5キー押下でリスタート
			if (players[0].Input.GetKeyDown(KEY_INPUT_F5))
			{
				SceneControl.Singleton.Destroy(this);
				SceneControl.Singleton.Create(out Play p);
				p.SongSelect = SongSelect;
				Logger.Singleton.Trace($"F5 Restart.");
				return;
			}

			// ESCキー長押しで強制的に選曲画面に戻る
			if (players[0].Input.GetCount(KEY_INPUT_ESCAPE) > 60)
			{
				SceneControl.Singleton.Destroy(this);
				SongSelect.Regist(1.0F);
				EnterTo(SongSelect);

				return;
			}

			if (pauseStartCount != -1)
			{
				pauseStartCount = -1;
				song.Play();
			}

			nowMillisec = song.CurrentTime + tja.Scores[0].OffsetMillisec;

			//
			if (players[0].BPMStatusControl.TryGetChangeBPM(nowMillisec, players[0].NoteFieldControl.BranchType))
			{
				dancer.BPM = players[0].BPMStatusControl.NowBPM.Value;

				foreach (var player in players)
				{
					player.Chara.BPM = players[0].BPMStatusControl.NowBPM.Value;
				}
			}

			AutoRoll.MoveNext();

			for (int i = 0; i < players.Length; i++)
			{
				UpdatePlayStyle(i);
			}

			AddOnUpdate?.Invoke();

			dancer.Update(players[0].SoulGauge.Now);

		}

		public override void Update()
		{
			coroutineControl.Update();
			for(int i = 0; i < players.Length; i++)
			{
				UpdateBackground(i);
			}
			foreach (var (PlayerNumbrt, Act) in updateActList)
			{
				Act(PlayerNumbrt);
			}

			// 譜面処理は効率化を図るため、Drawで処理する
			// ここではキー入力と時間の処理を行う

			DebugWindow.RightText[0] = $"Great: {players[0].ResultData.GreatCount}, Good: {players[0].ResultData.GoodCount}, Bad: {players[0].ResultData.BadCount}";
			DebugWindow.RightText[1] = $"Roll: {players[0].ResultData.Roll}";
			DebugWindow.RightText[2] = $"Gauge: {players[0].SoulGauge.Now}/{players[0].SoulGauge.Max}, Clear: {players[0].SoulGauge.IsNormaClear}, Soul: {players[0].SoulGauge.IsSoul}";

			switch (status)
			{
				case InnerStatus.Pause:
					{
						UpdateInnerStatusPause();
					}	
					break;
				case InnerStatus.Play:
					{
						UpdateInnerStatusPlay();
					}
					break;
			}

			song.Update();
		}
		#endregion

		#region 描画処理

		void DrawJudgeText(int playerIndex)
		{
			players[playerIndex].JudgeImageControl.Draw(nowMillisec);
		}

		void DrawJudgeFrame(int playerIndex)
		{
			players[playerIndex].JudgeFrame.Draw(players[playerIndex].NoteFieldControl.JudgeFramePointCX, players[playerIndex].NoteFieldControl.JudgeFramePointCY);
		}

		/// <summary>
		/// 音符の背景
		/// </summary>
		void DrawNoteField(int playerIndex)
		{
			players[playerIndex].NoteFieldControl.DrawField();
		}

		void DrawNoteFieldEffect(int playerIndex)
		{
			players[playerIndex].NoteFieldControl.DrawEffect(nowMillisec);
		}

		void DrawNoteFieldGogo(int playerIndex)
		{
			DebugWindow.LeftText[playerIndex] = $"{playerIndex}:{players[playerIndex].GogoCondition.NowGogo}";
			players[playerIndex].NoteFieldControl.DrawGogoField();
		}

		void DrawSoulGauge(int playerIndex)
		{
			players[playerIndex].SoulGauge.Draw();
		}

		void DrawNoteFlyEffect(int playerIndex)
		{
			players[playerIndex].NoteFlyEffect.Draw(nowMillisec);
		}

		void DrawBackground(int playerIndex)
		{
		}

		void DrawBalloonNumber(int playerIndex)
		{
			players[playerIndex].BalloonNumberImageControl.Draw();
		}

		void DrawBackgroundUpper(int playerIndex)
		{
			players[playerIndex].Background3.Draw();
		}

		void DrawBackgroundLower(int playerIndex)
		{
			players[playerIndex].Background3.Draw();
		}

		void DrawBranchField(int playerIndex)
		{
			players[playerIndex].NoteFieldControl.DrawBranchField();
		}

		void DrawChara(int playerIndex)
		{
			players[playerIndex].Chara.Draw();

		}

		List<Other> otherList = new List<Other>();

		IEnumerator enumDrawOther;

		IEnumerator GetEnumDrawOther()
		{
			while (true)
			{
				if (otherList.Count > 0)
				{
					foreach (var item in otherList)
					{
						item.Draw();
						yield return null;
					}
				}
				else
				{
					yield return null;
				}
			}
		}

		void DrawOther(int playerIndex)
		{
			enumDrawOther.MoveNext();
		}

		void DrawScoreNumber(int playerIndex)
		{
			players[playerIndex].ScoreNumberImageControl.Draw();
		}

		void DrawStage(int playerIndex)
		{
			players[playerIndex].Background3.Draw();
		}

		void DrawPauseScreen()
		{
			pauseScreen.Draw();
		}

		/// <summary>
		/// 描画：小節線
		/// </summary>
		void DrawMeasure(int playerIndex)
		{
			var player = players[playerIndex];

			switch (player.Score.ScoreType)
			{
				case ScoreType.Normal:
					DrawMeasureNormal(playerIndex);
					break;
				case ScoreType.HBScroll:
					DrawMeasureHBScroll(playerIndex);
					break;
			}

		}

		void DrawMeasureNormal(int playerIndex)
		{
			var player = players[playerIndex];
			float y = player.NoteFieldControl.JudgeFramePointCY;

			using (DrawAreaGuard.Create())
			using (DrawModeGuard.Create())
			{
				SetDrawArea((int)player.NoteFieldControl.Left, (int)(y - player.NoteFieldControl.HeightHalf), (int)player.NoteFieldControl.Left + (int)player.NoteFieldControl.Width, (int)(y + player.NoteFieldControl.HeightHalf + 120));
				SetDrawMode(DX_DRAWMODE_BILINEAR);

				foreach (var bscore in player.BranchScoreControl.GetBranchScoreList())
				{
					player.NoteRenderer.DrawMeasureBranchScore(bscore, nowMillisec);
				}
			}
		}

		void DrawMeasureHBScroll(int playerIndex)
		{
			// 終わっていたら音符の描画はしない
			// 普通はUpdateによる処理である必要があるが、
			// 最適化のためここで判定を行う
			if (IsFinish) return;

			var player = players[playerIndex];

			float y = player.NoteFieldControl.JudgeFramePointCY;

			int diffTime;

			double hbscrollPivotX = 0;

			using (DrawModeGuard.Create())
			using (DrawAreaGuard.Create())
			{
				SetDrawArea((int)player.NoteFieldControl.Left, (int)(y - player.NoteFieldControl.HeightHalf), (int)player.NoteFieldControl.Left + (int)player.NoteFieldControl.Width, (int)(y + player.NoteFieldControl.HeightHalf + 120));
				SetDrawMode(DX_DRAWMODE_BILINEAR);

				foreach (var bscore in player.BranchScoreControl.GetBranchScoreList().Reverse())
				{
					player.NoteRenderer.DrawMeasureBranchScore(bscore, nowMillisec);
				}
			}
		}

		void DrawNote(int playerIndex)
		{
			var player = players[playerIndex];

			switch(player.Score.ScoreType)
			{
				case ScoreType.Normal:
					DrawNoteNormal(playerIndex);
					break;
				case ScoreType.HBScroll:
					DrawNoteHBScroll(playerIndex);
					break;
			}
		}

		/// <summary>
		/// 描画：音符(標準)
		/// </summary>
		void DrawNoteNormal(int playerIndex)
		{
			// 終わっていたら音符の描画はしない
			// 普通はUpdateによる処理である必要があるが、
			// 最適化のためここで判定を行う
			if (IsFinish) return;

			float y;

			var player = players[playerIndex];

			y = player.NoteFieldControl.JudgeFramePointCY;

			using (DrawModeGuard.Create())
			using (DrawAreaGuard.Create())
			{
				SetDrawArea((int)player.NoteFieldControl.Left, (int)(y - player.NoteFieldControl.HeightHalf), (int)player.NoteFieldControl.Left + (int)player.NoteFieldControl.Width, (int)(y + player.NoteFieldControl.HeightHalf + 120));
				SetDrawMode(DX_DRAWMODE_BILINEAR);

				// ブランチ層
				foreach (var bscore in player.BranchScoreControl.GetBranchScoreList().Reverse())
				{
					player.NoteRenderer.DrawNoteBranchScore(bscore, nowMillisec);
				}
			}
		}

		/// <summary>
		/// 描画：音符(HBScroll)
		/// </summary>
		void DrawNoteHBScroll(int playerIndex)
		{
			// 終わっていたら音符の描画はしない
			// 普通はUpdateによる処理である必要があるが、
			// 最適化のためここで判定を行う
			if (IsFinish) return;

			int handle;
			int diffTime, prevT;

			float x = 0, y;
			float prevX;
			float w, h, hHalf;

			var player = players[playerIndex];

			y = player.NoteFieldControl.JudgeFramePointCY;

			double hbscrollPivotX = 0;

			using (DrawModeGuard.Create())
			using (DrawAreaGuard.Create())
			{
				SetDrawArea((int)player.NoteFieldControl.Left, (int)(y - player.NoteFieldControl.HeightHalf), (int)player.NoteFieldControl.Left + (int)player.NoteFieldControl.Width, (int)(y + player.NoteFieldControl.HeightHalf + 120));
				SetDrawMode(DX_DRAWMODE_BILINEAR);

				// ブランチ層
				foreach (var bscore in player.BranchScoreControl.GetBranchScoreList().Reverse())
				{
					player.NoteRenderer.DrawNoteBranchScore(bscore, nowMillisec);
				}
			}
		}

		void DrawNoteHit(int playerIndex)
		{
			var player = players[playerIndex];
			player.HitImageControl.Draw(player.NoteFieldControl.JudgeFramePointCX, player.NoteFieldControl.JudgeFramePointCY, nowMillisec);
		}


		void DrawComboNumber(int playerIndex)
		{
			players[playerIndex].ComboNumberImageControl.Draw();

		}

		void DrawRollNumber(int playerIndex)
		{
			players[playerIndex].RollNumberImageControl.Draw();
		}

		void DrawTaiko(int playerIndex)
		{
			players[playerIndex].TaikoImageControl.Draw(nowMillisec);
		}
		void DrawTitle(int playerIndex)
		{
			title.Draw();
			//DrawStringToHandle(1880 - GetDrawStringWidthToHandle(tja.Title, Share.Singleton.SJIS.GetByteCount(tja.Title), comboFont), 60, tja.Title, 0xEFEFEF, comboFont, 0x262626);

		}

		void DrawDetailInfo(int playerIndex)
		{
			using (DrawModeGuard.Create())
			{
				SetDrawMode(DX_DRAWMODE_BILINEAR);

				float xf = 480;
				float yf = 250;

				DrawExtendStringF(xf, yf, 0.25, 0.25, $"BPM", GetColor(255, 255, 255));
				//DrawExtendStringF(xf, yf + GetFontSize() * 0.25F, 0.5, 0.5, $"   {Players[0].BPMStatusControl.NowBPM}", GetColor(255, 255, 255));

				DrawExtendStringF(xf + 80, yf + 0, 0.25, 0.25, $"Measure", GetColor(255, 255, 255));
				DrawExtendStringF(xf + 80, yf + GetFontSize() * 0.25F, 0.5, 0.5, $"   {measureStatusControl.NowMeasure.A}/{measureStatusControl.NowMeasure.B}", GetColor(255, 255, 255));
			}
		}

		void DrawLyric(int playerIndex)
		{
			lyric.Draw();
		}

		/// <summary>
		/// 描画：踊り子
		/// </summary>
		void DrawDancer(int playerIndex)
		{
			dancer.Draw();
		}

		public override void Draw()
		{
			foreach (var (PlayerNumbrt, Act) in drawActList)
			{
				Act(PlayerNumbrt);
			}

			DrawPauseScreen();
		}
#endregion

		void RegistMusicalScoreSaveData()
		{
			for (int i = 0; i < players.Length; i++)
			{
				var result = Share.Singleton.Result[i];

				result.ClearType = Tatelier.SongSelect.ClearType.None;
				result.ClearType |= players[i].SoulGauge.IsNormaClear ? Tatelier.SongSelect.ClearType.NormaClear : Tatelier.SongSelect.ClearType.None;
				result.ClearType |= players[i].SoulGauge.IsSoul ? Tatelier.SongSelect.ClearType.Soul : Tatelier.SongSelect.ClearType.None;

				if (result.BadCount == 0)
				{
					result.ClearType |= Tatelier.SongSelect.ClearType.FullCombo;

					if (result.GreatCount > 0 && result.GoodCount == 0)
					{
						result.ClearType = Tatelier.SongSelect.ClearType.FullGreat;
					}
					else if(result.GoodCount > 0 && result.GreatCount == 0)
					{
						result.ClearType |= Tatelier.SongSelect.ClearType.FullGood;
					}
				}


				if (players[i].CanBeSaved)
				{
					string filePath = MainConfig.Singleton.GetScoreSaveDataFilePath(players[i].PlayerInfo.Name, Path.GetFullPath(Share.Singleton.ScoreFilePath));

					var mssd = new Tatelier.SongSelect.MusicalScoreSaveData();

					mssd.Load(filePath);
					mssd.Regist(players[i].CourseId, result);
					while (true)
					{
						try
						{
							mssd.Save(filePath);
							break;
						}
						catch (Exception e)
						{
							LogWindow.Singleton.Insert("演奏結果を保存できませんでした。", LogWindow.WarningColor);
							var dialogResult = MessageBox.Show($"演奏結果を保存できませんでした。\n\n保存先:\n{filePath}\n\n\n{e}\n\nもう一度試しますか？", "エラー", MessageBoxButton.YesNo);

							if (dialogResult != MessageBoxResult.Yes)
							{
								break;
							}
						}
					}
				}
			}
		}

		public override void Finish()
		{
			DeleteSoundMem(bgm);
		}

		public Play() : base() { }

		public Play(string name) : base(name) { }
	}
}
