using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Common;
using Tatelier.DxLibDLL;
using Tatelier.Multi;
using Tatelier.Progress;
using Tatelier.Play;
using static DxLibDLL.DX;
using Tatelier.Interface.Command;
using Tatelier.Score.Play.Chart.TJA;
using Tatelier.Score.Component.NoteSystem;
using Tatelier.Score;

namespace Tatelier.Scene
{
    class Multi : SceneBase
	{
		public override SceneType SceneType => SceneType.Multi;

        const uint bodyBackgroundColor = 0x333333;
		const uint lastLyricColor = 0xFFD700;


		const int StartTime = -2000;

		const int screenWidth = 1920;
		const int screenHeight = 1080;

		static int StartDrawPointX = 1920;
		static int FinishDrawPointX = -480;

		Tatelier.Coroutine.CoroutineControl coroutineControl = new Tatelier.Coroutine.CoroutineControl();

		MouseCursor mouseCursor = new MouseCursor();

		List<MultiItem> multiItemList;
		MultiItemControl multiItemControl = new MultiItemControl();

		Tatelier.Play.NoteImageControl noteImageControl;
		Tatelier.Play.JudgeFrame judgeFrame;
		Control control;

		Control.Button ButtonAddCourse;
		Control.Toggle ToggleBgm;

		public SceneBase songSelectScene;

		int attentionMarkHandle;

		Input input;

		MouseDiff mouseDiff;

		TJA tja;
		Song song;

		float scrollY = 0;

		MeasureLineImageControl barLineImageControl;

		int bgmSoundHandle;
		int bgmSoftHandle;
		int bgmSamplePerSec;

		int startTime = 0;
		int nowMillisec = 0;

		int backgroundHandle = -1;
		int grabMoveImageHandle = -1;

		const int noteFieldWidth = 1088;
		const int noteFieldLeft = 920;

		const int headerHeight = 232;
		const int measureHeight = 32;

		short[,] data;

		int measureLineTextFontHandle = -1;

		IEnumerator<int> GetLoadImage(string filePath)
        {
			SetUseASyncLoadFlag(DX_TRUE);

			int h = LoadGraph(filePath);

			SetUseASyncLoadFlag(DX_FALSE);
			
			while (CheckHandleASyncLoad(h) != DX_FALSE)
            {
				yield return -1;
            }

			yield return CheckHandleASyncLoad(h) == -1 ? -1 : h;
        }

		public static SceneBase Create()
		{
			return new Multi();
		}

		ResultType CommandSpeed(string command, string[] args)
		{
			tja.BuildScoreRendererData(noteFieldWidth, screenWidth, -1000, Share.Singleton.Speed);
			return ResultType.Exit;
		}

		ResultType CommandDragAndDrop(string command, string[] args)
        {
			coroutineControl.StartCoroutine(GetDragAndDropIterator(args[0]));
			return ResultType.Exit;
        }

		Dictionary<string, Func<string, string[], ResultType>> commandMap;

		/// <summary>
		/// コマンド関連を初期化する
		/// </summary>
		void InitCommandMap()
		{
			commandMap = new Dictionary<string, Func<string, string[], ResultType>>()
			{
				{ "drag & drop", CommandDragAndDrop },
				{ "/speed", CommandSpeed },
			};
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
					default:
						return ResultType.NotFound;
				}
			}
		}
		string tjaPath;

		int font;
		int headerFont = -1;

		int infoTextFontHandle = -1;

		TaikoSEControl TaikoSEControl;

		Lyric lyric;

		int escapePressTime = int.MaxValue;

		int currentMeasureIndex;
		readonly uint[] measureBackgroundList = new uint[]
		{
			0x6A4D40,
			0x6C8E86,
		};

		IEnumerator GetMove(int startTime, int endTime, int millisec = 100)
		{
			int start = Supervision.NowMilliSec;
			int end = Supervision.NowMilliSec + millisec;

			while (true)
			{
				int now = Supervision.NowMilliSec;
				float per = (millisec - (end - now)) / (float)millisec;
				if (per >= 1)
				{
					break;
				}
				int temp = (int)(startTime + (endTime - startTime) * Common.Easing.GetEasingValue(per, Common.EasingType.EaseOutExpo));

				song.CurrentTime = temp;
				yield return endTime;
			}

			song.CurrentTime = endTime;
			yield return endTime;

			start = Supervision.NowMilliSec;

			while (true)
			{
				int now = Supervision.NowMilliSec;
				if (now - start > 20) break;
				yield return endTime;
			}

			move = null;
		}

		IEnumerator move = null;

		/// <summary>
		/// 譜面ディレクトリ監視者
		/// </summary>
		FileSystemWatcher watcher = null;

		string watchFilePath = "";

		DateTime changeDateTime;

		async Task LoadTJA(string filePath)
		{
			int retryCount = 3;
			TJA nextTja = null;

			nextTja = await Task.Run(() =>
			{
				TJA t = null;
				do
				{
					try
					{
						t = new TJA();
						t.Load(new TJALoadInfo()
						{
							FilePath = filePath
						});
						break;
					}
					catch (Exception ex)
					{
						System.Diagnostics.Debug.WriteLine($"{ex}");
						Task.Delay(50).Wait();
						retryCount--;
					}
				} while (retryCount > 0);

				t.BuildScoreRendererData(noteFieldWidth, screenWidth, -1000, Share.Singleton.Speed);

				foreach (var score in t.Scores)
				{
					foreach (var bscore in score.BranchScoreControl.GetBranchScoreList())
					{
						foreach (var note in bscore.Notes)
						{
							if (note.StartMillisec < nowMillisec)
							{
								note.Hit = true;
							}
						}
					}
				}
				for (int i = 0; i < t.Scores.Count; i++)
				{
					for (int j = 0; j < multiItemControl.ItemList.Count; j++)
					{
						if (multiItemControl.ItemList[j].Score.CourseName == t.Scores[i].CourseName)
						{
							multiItemControl.ItemList[j].Score = t.Scores[i];
						}
					}
				}

				return t;
			});

			tja = nextTja;
		}

		/// <summary>
		/// 譜面フォルダ内の変化検知イベント
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		async void ChangeScoreFolderEntity(object source, FileSystemEventArgs e)
		{
			if(watchFilePath == e.FullPath && DateTime.Now - changeDateTime < TimeSpan.FromMilliseconds(500))
			{
				return;
			}
			watchFilePath = e.FullPath;
			changeDateTime = DateTime.Now;

			switch (e.ChangeType)
			{
				case WatcherChangeTypes.Changed:
					{
						await LoadTJA(e.FullPath);
						//int retryCount = 3;
						//TJA nextTja = null;
						//do
						//{
						//	try
						//	{
						//		nextTja = new TJA();
						//		nextTja.Load(new TJALoadInfo()
						//		{
						//			FilePath = e.FullPath
						//		});
						//		break;
						//	}
						//	catch (Exception ex)
						//	{
						//		System.Diagnostics.Debug.WriteLine($"{ex}");
						//		Task.Delay(50).Wait();
						//		retryCount--;
						//	}
						//} while (retryCount > 0);

						//nextTja.BuildScoreRendererData(noteFieldWidth, screenWidth, -1000, Share.Singleton.Speed);

						//foreach (var score in nextTja.Scores)
						//{
						//	foreach (var bscore in score.BranchScoreControl.GetBranchScoreList())
						//	{
						//		foreach (var note in bscore.Notes)
						//		{
						//			if (note.StartMillisec < nowMillisec)
						//			{
						//				note.Hit = true;
						//			}
						//		}
						//	}
						//}
						//for (int i = 0; i < nextTja.Scores.Count; i++)
						//{
						//	for(int j = 0; j < multiItemControl.ItemList.Count; j++)
						//	{
						//		if(multiItemControl.ItemList[j].Score.CourseName == nextTja.Scores[i].CourseName)
						//		{
						//			multiItemControl.ItemList[j].Score = nextTja.Scores[i];
						//		}
						//	}
						//}

						//tja = nextTja;
					}
					break;
			}
			LogWindow.Singleton.Insert($"[{DateTime.Now:HH:mm:ss}] 譜面の変更を検知しました。");
		}

		/// <summary>
		/// 譜面フォルダの監視を開始する
		/// </summary>
		void StartScoreWatcher(string tjaFilePath)
		{
			if (watcher != null)
			{
				StopScoreWatcher();
			}

			watcher = new FileSystemWatcher
			{
				NotifyFilter = System.IO.NotifyFilters.LastWrite,
				Filter = Path.GetFileName(tjaFilePath),
				Path = Path.GetDirectoryName(tjaFilePath),
				IncludeSubdirectories = true
			};

			//イベントハンドラの追加
			watcher.Changed += new FileSystemEventHandler(ChangeScoreFolderEntity);
			watcher.Created += new FileSystemEventHandler(ChangeScoreFolderEntity);
			watcher.Deleted += new FileSystemEventHandler(ChangeScoreFolderEntity);

			// 監視開始
			watcher.EnableRaisingEvents = true;

			LogWindow.Singleton.Insert("譜面フォルダの監視を開始しました。");
		}

		void StopScoreWatcher()
		{
			watcher.Dispose();
			watcher = null;
		}

		int State = 0;

		int screen = -1;

		float fadeY = -Supervision.ScreenHeight;


		#region 初期化処理

		void StartWave(int softHandle)
		{
			long sampleNum = GetSoftSoundSampleNum(softHandle);

			if (sampleNum < 0)
			{
				return;
			}

			GetSoftSoundFormat(softHandle, out int channelNum, out int bitsPerSample, out bgmSamplePerSec, out _);
			IntPtr ptr = GetSoftSoundDataImage(softHandle);

			data = new short[channelNum, sampleNum];
			
			for (int i = 0; i < sampleNum; i++)
			{
				for(int j = 0; j < channelNum; j++)
				{
					data[j, i] = Marshal.ReadInt16(ptr, ((channelNum * i) + j)  * sizeof(short));
				}
			}
		}

		public override IEnumerator<float> GetStartIterator()
		{
			yield break;
		}

		IEnumerator GetDragAndDropIterator(string filePath)
        {
			State = 0;
			song.Stop();
			DeleteSoundMem(bgmSoundHandle);
			DeleteSoftSound(bgmSoftHandle);

			var progress = ProgressControl.Singleton.Create(new Tatelier.Progress.Progress());
			progress.StatusText = "D&Dデータ読み込み中...";
			yield return GetLoadScoreIterator(filePath, progress, 1);
			progress.NowValue = 2;
			State = 1;
        }

		IEnumerator GetLoadScoreIterator(string filePath, Progress.Progress progress, float progressBetween)
		{
			float diff = progressBetween / 12;

			var task = Task.Run(() =>
			{
				tjaPath = filePath ?? "";

				tja = new TJA();
				tja.Load(new TJALoadInfo()
				{
					FilePath = tjaPath,
				});
			});
			progress.NowValue += diff;

			while (!task.IsCompleted)
			{
				yield return 0;
			}
			progress.NowValue += diff;

			multiItemControl.Clear();
			foreach (var score in tja.Scores)
			{
				multiItemControl.Add(control, new MultiItemInfo
				{
					CourseName = score.CourseName,
					Score = score,
				});
			}

			progress.NowValue += diff;
			yield return 0;

			var tjaDir = Path.GetDirectoryName(tjaPath);

			yield return Utility.GetCreateBgmIterator(Path.Combine(tjaDir, tja.WaveFileName), (result) =>
			{
				bgmSoundHandle = result;
			});


			progress.NowValue += diff;
			yield return 0;

			// 先頭に無音を挿入
			int soft = LoadSoftSound(Path.Combine(tjaDir, tja.WaveFileName));

			if (soft == -1)
			{
				// error.
			}


			progress.NowValue += diff;
			yield return 0;

			long sampleNum = GetSoftSoundSampleNum(soft);
			GetSoftSoundFormat(soft, out var channels, out int bitsPerSample, out int samplesPerSec, out int isFloatType);
			bgmSoftHandle = MakeSoftSoundCustom(channels, bitsPerSample, samplesPerSec, sampleNum + samplesPerSec * 2, isFloatType);


			progress.NowValue += diff;
			yield return 0;

			// 2回目の作成時、キャッシュなのかわからんが、先頭にサンプルが残るため、
			// 空白を0で埋めること。
			for (int i = 0; i < samplesPerSec * 2; i++)
			{
				WriteSoftSoundData(bgmSoftHandle, i, 0, 0);
				if (i == 100)
				{
					yield return 0;
				}
			}


			progress.NowValue += diff;
			for (int i = 0; i < sampleNum; i++)
			{
				ReadSoftSoundData(soft, i, out var ch1, out var ch2);
				WriteSoftSoundData(bgmSoftHandle, i + samplesPerSec * 2, ch1, ch2);
				if (i == 0)
				{
					yield return 0;
				}
			}


			progress.NowValue += diff;
			if (soft != -1)
			{
				bgmSoundHandle = LoadSoundMemFromSoftSound(bgmSoftHandle);
			}
			else
			{
				bgmSoftHandle = -1;
			}
			DeleteSoftSound(soft);


			progress.NowValue += diff;
			yield return 0;

			song = new Song();
			song.Init(bgmSoundHandle);

			//song.CurrentTime = tja.Scores[0].OffsetMillisec;
			song.CurrentTime = -tja.Scores[0].OffsetMillisec;

			song.Play();
			song.Pause();
			song.CurrentTime = StartTime - tja.Scores[0].OffsetMillisec;


			progress.NowValue += diff;
			yield return 0;

			tja.BuildScoreRendererData(noteFieldWidth, screenWidth, -1000, Share.Singleton.Speed);


			progress.NowValue += diff;
			yield return 0;

			lyric = new Lyric(tja.GetLyricFilePath(tjaDir));


			progress.NowValue += diff;
			yield return 0;

			//
			StartWave(bgmSoftHandle);
		}

		IEnumerator GetS()
		{
			const float add = 0.048F;

			var progress = new Progress.Progress();

			progress.StatusText = "ロード中..";
			ProgressControl.Singleton.Create(progress);

			screen = MakeScreen(1920, 1080, DX_TRUE);
			backgroundHandle = ImageLoadControl.Singleton.Load(@"Resources\Theme\System\Edit\Background.png");
			grabMoveImageHandle = ImageLoadControl.Singleton.Load(@"Resources\Theme\System\Edit\GrabMove.png");

			progress.NowValue += add;
			yield return 0;

			input = Input.Singleton;
			control = new Control();
			ButtonAddCourse = control.CreateButton();

			ToggleBgm = control.CreateToggle();
			ToggleBgm.State = true;
			ToggleBgm.X = 50;
			ToggleBgm.Y = 200;

			// フォント初期化
			font = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 32, -1, DX_FONTTYPE_ANTIALIASING);
			infoTextFontHandle = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 16, -1, DX_FONTTYPE_ANTIALIASING);
			measureLineTextFontHandle = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 24, -1, DX_FONTTYPE_ANTIALIASING_4X4);
			headerFont = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 24, -1, DX_FONTTYPE_ANTIALIASING_4X4);

			progress.NowValue += add;
			yield return 0;

			barLineImageControl = new MeasureLineImageControl(Path.Combine(MainConfig.Singleton.ThemeFolderPath, "Play"), null);

			progress.NowValue += add;
			yield return 0;

			attentionMarkHandle = ImageLoadControl.Singleton.Load(Path.Combine("Resources\\Theme\\System\\Edit", "Attention.png"));
			noteImageControl = new Tatelier.Play.NoteImageControl(MainConfig.Singleton.GetThemePath("ScoreEditMode"), null);

			progress.NowValue += add;
			yield return 0;

			var json = new Hjson.JsonObject
			{
				["FilePath"] = "JudgeFrame.png"
			};
			judgeFrame = new JudgeFrame("Resources\\Theme\\System\\Edit", json);

			progress.NowValue += add;

			yield return GetLoadScoreIterator(Share.Singleton.ScoreFilePath ?? "", progress, 0.4F);

			Hjson.JsonObject dancerJson = new Hjson.JsonObject
			{
				["Dancer"] = "Dancer"
			};

			foreach(var item in multiItemControl.ItemList)
            {
				item.NoteImageControl = noteImageControl;
            }

			multiItemList = multiItemControl.ItemList;

			for (int i = 0; i < multiItemList.Count; i++)
			{
				multiItemList[i].StartDrawPointX = StartDrawPointX;
				multiItemList[i].FinishDrawPointX = FinishDrawPointX;
			}

			multiItemList.OrderByDescending(v => v.CourseID).First().ToggleSEEnabled.State = true;

			//bar = ImageLoadControl.Singleton.Load(Path.Combine(MainConfig.Singleton.ThemeFolderPath, "Play/Bar/Normal.png"));

			startTime = Supervision.NowMilliSec;
			yield return 0;

			TaikoSEControl = new TaikoSEControl(new TaikoSEControlInfo
			{
				DonFilePath = Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"Sound\Taiko\OK.wav"),
				KatFilePath = Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"Sound\Taiko\Move.wav"),
				BalloonFilePath = Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"Sound\Taiko\balloon.wav"),
			});

			progress.NowValue += add;
			yield return 0;

			StartScoreWatcher(tjaPath);

			SceneControl.Singleton.Unregist(songSelectScene);

			State = 1;

			progress.NowValue = 2.0F;
			yield break;
		}

		IEnumerator GetFadeIn()
		{
			fadeY = -Supervision.ScreenHeight;
			yield return null;

			int start = Supervision.NowMilliSec;

			while (true)
			{
				float per = (Supervision.NowMilliSec - start) / 500.0F;
				if(per > 1)
                {
					fadeY = 0;
					break;
                }

				fadeY = -(Supervision.ScreenHeight - (int)(Easing.EaseOutQuint(per) * Supervision.ScreenHeight));

				yield return null;
			}
		}

		IEnumerator GetFadeOut()
		{
			fadeY = 0;
			yield return null;

			int start = Supervision.NowMilliSec;

			while (true)
			{
				float per = (Supervision.NowMilliSec - start) / 500.0F;
				if (per > 1)
				{
					fadeY = -Supervision.ScreenHeight;
					break;
				}

				fadeY = -(int)(Easing.EaseOutQuint(per) * Supervision.ScreenHeight);

				yield return null;
			}
		}

		IEnumerator GetEnd()
		{
			EnterTo(songSelectScene);
			yield return GetFadeOut();

            SceneControl.Singleton.Destroy(this);
		}

		public override void Start()
		{
			InitCommandMap();

			coroutineControl.StartCoroutine(GetS());
			coroutineControl.StartCoroutine(GetFadeIn());

			Regist(1.1F);

			mouseDiff = new MouseDiff();
		}

		#endregion

		#region 更新処理

		int startMouseX;
		int startMouseY;

		bool nowGrab = false;

		public override void Update()
		{
			coroutineControl.Update();

			if (State == 0) return;

			nowMillisec = (int)song.CurrentTime + tja.Scores[0].OffsetMillisec;

			if (ToggleBgm.State)
			{
				SetVolumeSoundMem(10000, bgmSoundHandle);
			}
			else
			{
				SetVolumeSoundMem(0, bgmSoundHandle);
			}

			control.Update();
			
			song.Update();

			move?.MoveNext();
			//mouseCursor.Update();
			if (State == 2)
			{
				return;
            }

			if (Supervision.NowMilliSec - escapePressTime >= 1000)
			{
				coroutineControl.StartCoroutine(GetEnd());
				State = 2;
				songSelectScene.Regist(1.0F);
				EnterTo(songSelectScene);
			}

            if (input.GetKeyDown(KEY_INPUT_F5))
            {
				LoadTJA(Share.Singleton.ScoreFilePath);
			}

			if (!(input.GetKey(KEY_INPUT_LSHIFT) || input.GetKey(KEY_INPUT_RSHIFT)))
			{
				if (Mouse.Singleton.WheelRotF != 0)
				{
					scrollY -= Mouse.Singleton.WheelRotF * 20;
					if (scrollY < 0)
					{
						scrollY = 0;
					}
				}
			}

            if (input.GetKeyDown(KEY_INPUT_ESCAPE))
            {
				escapePressTime = Supervision.NowMilliSec;
            }

            if (input.GetKeyUp(KEY_INPUT_ESCAPE))
            {
				escapePressTime = int.MaxValue;
            }


			if (song.IsNowPause)
			{
				if (Mouse.Singleton.LeftButton == 1)
				{
					GetMousePoint(out var x, out var y);
					startMouseX = x;
					startMouseY = y;
					_ = mouseDiff.X;
					_ = mouseDiff.Y;
				}
                else if(Mouse.Singleton.LeftButton == 0)
				{
					nowGrab = false;
					SetMouseDispFlag(TRUE);
                }

				if(Mouse.Singleton.LeftButton > 0)
				{
					nowGrab = true;
					SetMouseDispFlag(FALSE);
					GetMousePoint(out var x, out var y);
					System.Diagnostics.Trace.WriteLine($"A - X:{x}, Y:{y}");
					var diffX = mouseDiff.X;
					var diffY = mouseDiff.Y;
					if (diffX == 0 && diffY == 0)
					{
						SetMousePoint(startMouseX, startMouseY);
						_ = mouseDiff.X;
						_ = mouseDiff.Y;
					}
					else
					{
						song.CurrentTime += diffX * 4;
						//SetMousePoint(x - diffX, y - diffY);
						System.Diagnostics.Trace.WriteLine($"B - X:{x - diffX}, Y:{y - diffY}");
					}
				}

				if (input.GetKeyDown(KEY_INPUT_SPACE))
				{
					if (Mouse.Singleton.LeftButton == 0)
					{
						song.Play();

						foreach (var score in tja.Scores)
						{
							foreach (var bscore in score.BranchScoreControl.GetBranchScoreList())
							{
								foreach (var note in bscore.Notes)
								{
									note.Hit = false;
								}
								foreach (var note in bscore.Notes)
								{
									if (note.StartMillisec < nowMillisec)
									{
										note.Hit = true;
									}
								}
							}
						}
					}
				}
				else if (input.GetKey(KEY_INPUT_PGUP)
					&& move == null)
				{
					var measures = multiItemList.First().Score.BranchScoreControl.GetBranchScoreList().First().Measures;

					var index = -1;

					for (int i = 0; i < measures.Count; i++)
					{
						int time = measures[i].StartMillisec - tja.Scores[0].OffsetMillisec;

						if (song.CurrentTime < time)
						{
							index = i;
							break;
						}
					}

					if (index != -1)
					{
						move = GetMove(song.CurrentTime, measures[index].StartMillisec - tja.Scores[0].OffsetMillisec);
						//song.CurrentTime = measures[index].StartMillisec - tja.Scores[0].OffsetMillisec;
					}
					else
					{
						move = GetMove(song.CurrentTime, measures.Last().StartMillisec - tja.Scores[0].OffsetMillisec, 200);
					}
				}
				else if (input.GetKey(KEY_INPUT_PGDN)
				   && move == null)
				{
					var measures = multiItemList.First().Score.BranchScoreControl.GetBranchScoreList().First().Measures;

					var index = -1;

					for (int i = measures.Count - 1; i >= 0; i--)
					{
						int time = measures[i].StartMillisec - tja.Scores[0].OffsetMillisec;

						if (time < song.CurrentTime)
						{
							index = i;
							break;
						}
					}

					if (index != -1)
					{
						move = GetMove(song.CurrentTime, measures[index].StartMillisec - tja.Scores[0].OffsetMillisec);
					}
					else
					{
						move = GetMove(song.CurrentTime, StartTime - tja.Scores[0].OffsetMillisec);
					}
				}

				if (input.GetKeyDown(KEY_INPUT_HOME))
				{
					var measures = multiItemList.First().Score.BranchScoreControl.GetBranchScoreList().First().Measures;
					move = GetMove(song.CurrentTime, StartTime - tja.Scores[0].OffsetMillisec);
				}
				else if (input.GetKeyDown(KEY_INPUT_END))
				{
					var measures = multiItemList.First().Score.BranchScoreControl.GetBranchScoreList().First().Measures;
					move = GetMove(song.CurrentTime, measures.Last().StartMillisec - tja.Scores[0].OffsetMillisec, 200);
				}

				if (input.GetKey(KEY_INPUT_LSHIFT) || input.GetKey(KEY_INPUT_RSHIFT))
				{
					if (input.GetKey(KEY_INPUT_LEFT))
					{
						song.CurrentTime -= 50;
					}
					if (input.GetKey(KEY_INPUT_RIGHT))
					{
						song.CurrentTime += 50;
					}

					if (Mouse.Singleton.WheelRotF != 0)
					{
						song.CurrentTime += (int)(50 * Mouse.Singleton.WheelRotF);
					}
				}
				else
				{
					if (input.GetKey(KEY_INPUT_LEFT))
					{
						song.CurrentTime -= 20;
					}
					if (input.GetKey(KEY_INPUT_RIGHT))
					{
						song.CurrentTime += 20;
					}
				}
			}
			else
			{
				if (input.GetKeyDown(KEY_INPUT_SPACE))
				{
					song.Pause();
				}
			}

			int diffTime;

			foreach (var item in multiItemList)
			{
				foreach (var bscore in item.Score.BranchScoreControl.GetBranchScoreList())
				{
					foreach (var noteList1 in bscore.NoteList)
					{
						foreach (var noteList2 in noteList1)
						{
							foreach (var note in noteList2)
							{
								// すでにヒットしている場合は次に進む
								if (note.Hit) continue;

								diffTime = note.StartMillisec - nowMillisec;

								if (note.NoteType != NoteType.End && diffTime > 100) break;

								if (diffTime <= 0)
								{
									switch (note.NoteType)
									{
										case NoteType.Don:
										case NoteType.DonBig:
											if (!song.IsNowPause && item.ToggleSEEnabled.State) TaikoSEControl.Play(TaikoSEType.Don);
											note.Hit = true;
											break;
										case NoteType.Kat:
										case NoteType.KatBig:
											if (!song.IsNowPause && item.ToggleSEEnabled.State) TaikoSEControl.Play(TaikoSEType.Kat);
											note.Hit = true;
											break;
										case NoteType.Balloon:
											break;
										case NoteType.End:
											note.PrevNote.Hit = true;
											note.Hit = true;
											if (note.PrevNote.NoteType == NoteType.Balloon)
											{
											}
											break;
									}

								}
							}
						}
					}
				}
			}
		}

		#endregion

		void DrawHeader()
		{
			const int paddingLeft = 16;
			const uint grayColor = 0xAAAAAA;

			SetDrawArea(0, 0, screenWidth, 232);
			DrawExtendGraph(0, 0, screenWidth, Supervision.ScreenHeight, backgroundHandle, DX_TRUE);


			DrawStringFToHandle(paddingLeft, 16, "タイトル:", grayColor, headerFont);
			DrawString(paddingLeft, 48, tja?.Title ?? "", 0xDDDDDD);

			DrawStringFToHandle(paddingLeft, 180, $"{((lyric?.HasLyric ?? false) ? "Lyric exist." : "")}", grayColor, font);
		}

		void DrawNowMillisec()
		{
			string time = $"{song.CurrentTime}";
			DrawStringF(1830 - GetDrawStringWidth(time, Encoding.GetEncoding("shift_jis").GetByteCount(time)), 180, time, 0xF0F0F0);
			DrawStringF(1830, 180, "ms", 0xF0F0F0);
		}

		void DrawTitle()
		{
		}

		void DrawLyric()
		{
			const int startX = 20;
			const int startY = 848;

			const int marginBottom = 8;

			uint normalColor = 0xFFFFFF;

			// 歌詞
			foreach (var item in lyric.List.Reverse<LyricItem>())
			{
				if (item.Time < song.CurrentTime)
				{
					DrawStringFToHandle(startX, startY, $"{item.Time}ms ～", normalColor, font);
					DrawStringFToHandle(startX, startY + GetFontSizeToHandle(font) + marginBottom, $"\"{item.Text}\"", normalColor, font);
					break;
				}
			}
		}

		void DrawWave()
		{
			const uint backColor = 0x222222;
			const int padding = 8;
			const int pivotX = 104;

			const int width = 1920;
			const int height = 64;

			const int round = 16;

			long millisec = GetSoundCurrentTime(bgmSoundHandle);
			int nowSample = (int)(millisec * (0.001 * bgmSamplePerSec));

			//
			nowSample = (int)(nowSample / 320 * 320);

			int x;


			int sampleNum = data?.GetLength(1) ?? 0;

			int baseY = (Supervision.ScreenHeight - height - padding);


			// 背景描画
			DrawBoxAA(0, Supervision.ScreenHeight - (height + padding) * 2, width, Supervision.ScreenHeight, backColor, DX_TRUE);

			using (DrawModeGuard.Create())
			using (DrawAreaGuard.Create())
			{
				SetDrawMode(DX_DRAWMODE_BILINEAR);

				float a = 5;
				float ind = 0;
				int i = nowSample;

				int prevX = 0;
				int diffY = 0;
				int diffUpperY = 0;
				int diffLowerY = 0;


				if (sampleNum > 0)
				{
					// 現在地よりも後の処理
					for (; i < sampleNum; i += round, ind += a)
					{
						x = (int)ind / 100;

						diffY = i < 0 ? 0 : (int)(height * (double)data[0, i] / short.MaxValue);

						if (diffY < 0)
						{
							if (diffLowerY < -diffY)
							{
								diffLowerY = -diffY;
							}
						}
						else
						{
							if (diffUpperY < diffY)
							{
								diffUpperY = diffY;
							}
						}
						if (prevX == x)
						{
							continue;
						}

						if (0 <= pivotX + x && pivotX + x <= width)
						{
							DrawLine(pivotX + x, baseY - diffLowerY, pivotX + x, baseY + diffUpperY, 0x948989, 1);
							diffUpperY = 0;
							diffLowerY = 0;
						}


						if (pivotX + x > width)
						{
							break;
						}
					}

					// 現在地よりも前の処理
					i = nowSample;
					ind = 0;
					for (; i >= 0; i -= round, ind -= a)
					{
						x = (int)ind / 100;

						if (i < 0)
						{
							diffY = 0;
						}
						else
						{
							diffY = (int)(height * (double)data[0, i] / short.MaxValue);
						}

						if (diffY < 0)
						{
							if (diffLowerY < -diffY)
							{
								diffLowerY = -diffY;
							}
						}
						else
						{
							if (diffUpperY < diffY)
							{
								diffUpperY = diffY;
							}
						}
						if (prevX == x)
						{
							continue;
						}

						if (0 <= pivotX + x && pivotX + x <= width)
						{
							DrawLine(pivotX + x, baseY - diffLowerY, pivotX + x, baseY + diffUpperY, 0x544949, 1);
							diffUpperY = 0;
							diffLowerY = 0;
						}

						if (pivotX + x < 0)
						{
							break;
						}
					}
				}

				SetDrawBlendMode(DX_BLENDMODE_NOBLEND, 0);
				DrawLineAA(0, baseY, width, baseY, 0x645959, 1);
				DrawLineAA(pivotX, baseY - height, pivotX, baseY + height, lastLyricColor, 3);
			}
		}

		void DrawNoteNormal(MultiItem item, float noteCY)
		{
			// 音符描画
			foreach (var bscore in item.Score.BranchScoreControl.GetBranchScoreList().Reverse())
			{
				item.NoteRenderer.DrawNoteBranchScore(bscore, nowMillisec);
			}
		}


		private void DrawNoteHBScroll(MultiItem item, float noteCY)
		{
			// ブランチ層
			foreach (var bscore in item.Score.BranchScoreControl.GetBranchScoreList().Reverse())
			{
				item.NoteRenderer.DrawNoteBranchScore(bscore, nowMillisec);
			}
		}
		#region 描画処理
		public override void Draw()
		{
			int prev = GetDrawScreen();
			SetDrawScreen(screen);

			SetDrawMode(DX_DRAWMODE_NEAREST);

			if (State == 0)
			{
				DrawBoxAA(0, 0, screenWidth, Supervision.ScreenHeight, bodyBackgroundColor, DX_TRUE);

				DrawHeader();

				// ヘッダー部と演奏部の境界線
				DrawLine(0, 232, screenWidth, 232, 0xDDDDDD);

				goto Finally;
			}


			int handle;
			int t, prevT;

			float x, noteCY;
			float prevX;
			float w, h, hHalf;

			currentMeasureIndex = -1;

			DrawBoxAA(0, 0, screenWidth, Supervision.ScreenHeight, bodyBackgroundColor, DX_TRUE);

			// 音符中央起点Y座標
			noteCY = measureHeight + headerHeight + multiItemList[0].NoteFieldHeight / 2 - scrollY;

			foreach (var item in multiItemList)
			{
				float noteFieldY = noteCY - (item.NoteFieldHeight / 2);

				item.JudgeFramePoint.CX = noteFieldLeft;
				item.JudgeFramePoint.CY = noteCY;

				SetDrawArea(0, (int)noteFieldY, screenWidth, (int)(noteFieldY + item.NoteFieldHeight));

				if (item.IsOpen)
				{
					judgeFrame.Draw(noteFieldLeft, noteCY);
				}

				SetDrawArea(0, (int)noteFieldY - measureHeight, screenWidth, (int)noteFieldY + item.NoteFieldHeight);

				if (item.Score.ScoreType == ScoreType.Normal)
				{
					foreach (var bscore in item.Score.BranchScoreControl.GetBranchScoreList())
					{
						// 小節線数
						// ※無駄な処理を省くため描画処理で計算する
						int line = 1;

						for (int i = 0; i < bscore.Measures.Count; i++)
						{
							var measure = bscore.Measures[i];

							t = (measure.StartMillisec - nowMillisec);

							x = noteFieldLeft + (t * measure.MovementPerMillisec) * Share.Singleton.Speed;

							if (item.IsOpen && measure.Visible)
							{
								SetDrawArea(0, (int)noteFieldY, screenWidth, (int)noteFieldY + item.NoteFieldHeight);
								DrawRotaGraphFastF(x, noteCY, 1.0F, 0.0F, barLineImageControl.GetHandle(measure.MeasureLineType), DX_TRUE);
							}

							SetDrawArea(0, (int)noteFieldY - measureHeight, screenWidth, (int)noteFieldY + item.NoteFieldHeight);

							// 小節線数描画
							if (t > 0)
							{
								GetDrawStringSizeToHandle(out int width, out int height, out _, $"{line}", Encoding.UTF8.GetByteCount($"{line}"), measureLineTextFontHandle);
								DrawBoxAA(x, noteFieldY - measureHeight + 1, screenWidth, noteFieldY + 1, measureBackgroundList[line % 2], DX_TRUE);
								DrawLineAA(x, noteFieldY - measureHeight + 1, x, noteFieldY, 0xDDDDDD, DX_TRUE);
								DrawStringFToHandle(x + 8, noteFieldY - 26, $"{line}", (i + 1 == bscore.Measures.Count ? (uint)0xFFFF00 : (uint)0xFFFFFF), measureLineTextFontHandle);
							}
							else
							{
								if (i < bscore.Measures.Count)
								{
									x = noteFieldLeft;

									GetDrawStringSizeToHandle(out int width, out int height, out _, $"{line}", Encoding.UTF8.GetByteCount($"{line}"), measureLineTextFontHandle);
									DrawBoxAA(x, noteFieldY - measureHeight + 1, screenWidth, noteFieldY + 1, measureBackgroundList[line % 2], DX_TRUE);
									DrawLineAA(x, noteFieldY - measureHeight + 1, x, noteFieldY, 0xDDDDDD, DX_TRUE);
									DrawStringFToHandle(x + 8, noteFieldY - 26, $"{line}", (i + 1 == bscore.Measures.Count ? (uint)0xFFFF00 : (uint)0xFFFFFF), measureLineTextFontHandle);

									if (currentMeasureIndex == -1)
									{
										currentMeasureIndex = i;
									}
								}
								else
								{

								}
							}
							line++;
						}
					}
				}
				else if (item.Score.ScoreType == ScoreType.HBScroll)
				{
					double hbscrollPivotX = 0;

					using (DrawAreaGuard.Create())
					{
						foreach (var bscore in item.Score.BranchScoreControl.GetBranchScoreList().Reverse())
						{
							var first = bscore.HBScrollDrawDataControl.ItemList?.LastOrDefault(v => v.IsApplicable(nowMillisec));

							double per = double.MinValue;

							if (first == null)
							{
								break;
							}

							per = first.GetElapsedRate(nowMillisec);

							int i = 0;
							int line = 1;

							// レイヤー層
							foreach (var m in bscore.Measures)
							{
								t = m.StartMillisec - nowMillisec;

								if (t < 0)
								{
									x = noteFieldLeft + (t * m.MovementPerMillisec) * Share.Singleton.Speed;

									if (item.IsOpen && m.Visible)
									{
										DrawRotaGraphFastF(x, noteCY, 1.0F, 0.0F, barLineImageControl.GetHandle(m.MeasureLineType), DX_TRUE);
									}
								}
								else
								{
									hbscrollPivotX = (double)(first.StartPoint + (first.FinishPoint - first.StartPoint) * per);
									x = (float)(noteFieldLeft + (m.HBScrollStartPointX - hbscrollPivotX) * m.ScrollSpeedInfo.Value);

									if (item.IsOpen && m.Visible)
									{
										DrawRotaGraphFastF(x, noteCY, 1.0F, 0.0F, barLineImageControl.GetHandle(m.MeasureLineType), DX_TRUE);
									}
								}
								// 小節線数描画
								if (t > 0)
								{
									GetDrawStringSizeToHandle(out int width, out int height, out _, $"{line}", Encoding.UTF8.GetByteCount($"{line}"), measureLineTextFontHandle);
									DrawBoxAA(x, noteFieldY - measureHeight + 1, screenWidth, noteFieldY + 1, measureBackgroundList[line % 2], DX_TRUE);
									DrawLineAA(x, noteFieldY - measureHeight + 1, x, noteFieldY, 0xDDDDDD, DX_TRUE);
									DrawStringFToHandle(x + 8, noteFieldY - 26, $"{line}", (i + 1 == bscore.Measures.Count ? (uint)0xFFFF00 : (uint)0xFFFFFF), measureLineTextFontHandle);
								}
								else
								{
									if (i < bscore.Measures.Count)
									{
										x = noteFieldLeft;

										GetDrawStringSizeToHandle(out int width, out int height, out _, $"{line}", Encoding.UTF8.GetByteCount($"{line}"), measureLineTextFontHandle);
										DrawBoxAA(x, noteFieldY - measureHeight + 1, screenWidth, noteFieldY + 1, measureBackgroundList[line % 2], DX_TRUE);
										DrawLineAA(x, noteFieldY - measureHeight + 1, x, noteFieldY, 0xDDDDDD, DX_TRUE);
										DrawStringFToHandle(x + 8, noteFieldY - 26, $"{line}", (i + 1 == bscore.Measures.Count ? (uint)0xFFFF00 : (uint)0xFFFFFF), measureLineTextFontHandle);

										if (currentMeasureIndex == -1)
										{
											currentMeasureIndex = i;
										}
									}
									else
									{

									}
								}
								i++;
								line++;
							}
						}
					}
				}

				if (item.IsOpen)
				{
					SetDrawArea(0, (int)noteFieldY, screenWidth, (int)noteFieldY + item.NoteFieldHeight);

					if (item.Score.ScoreType == ScoreType.Normal)
					{
						// 音符描画
						DrawNoteNormal(item, noteCY);
					}
					else if (item.Score.ScoreType == ScoreType.HBScroll)
					{
						DrawNoteHBScroll(item, noteCY);
					}

					SetDrawArea(0, (int)noteFieldY - measureHeight, screenWidth, (int)noteFieldY + item.NoteFieldHeight);
					DrawLineAA(noteFieldLeft - 90, 0, noteFieldLeft - 90, 1080, 0xDDDDDD);


					const int courseInfoWidth = noteFieldLeft - 90;
					int courseInfoHeight = (int)item.NoteFieldHeight;

					using (DrawBlendModeGuard.Create())
					{
						SetDrawBlendMode(DX_BLENDMODE_ALPHA, 191);
						DrawBoxAA(0, noteFieldY + 1, courseInfoWidth, noteFieldY + item.NoteFieldHeight - 1, 0, DX_TRUE);
					}
					DrawBoxAA(-1, noteFieldY, screenWidth + 1, noteFieldY + item.NoteFieldHeight, GetColor(191, 191, 191), DX_FALSE);

					// コース名
					DrawStringF(200, 20 + noteFieldY, item.CourseName, 0xDDDDDD);

					// コース種別
					if (item.Score.ScoreType == ScoreType.HBScroll)
					{
						DrawStringFToHandle(courseInfoWidth - 100, courseInfoHeight - 24 + noteFieldY, "HBSCROLL", 0xDDDDDD, infoTextFontHandle);
					}

					item.ToggleSEEnabled.X = 20;
					item.ToggleSEEnabled.Y = 70 + noteFieldY;
					item.ToggleSEEnabled.Draw();

					if (item.HasAttention)
					{
						DrawGraphF(160, 15 + noteFieldY, attentionMarkHandle, DX_TRUE);
					}
					noteCY += measureHeight + item.NoteFieldHeight - 1;
				}
				else
				{
					noteCY += measureHeight - 1;
				}

				SetDrawAreaFull();
				DrawLineAA(0, noteFieldY - measureHeight, screenWidth, noteFieldY - measureHeight, 0xDDDDDD);
			}

			// ヘッダー部
			DrawHeader();

			// 曲時間
			DrawNowMillisec();

			// タイトル
			DrawTitle();

			SetDrawAreaFull();

			DrawWave();

			// ヘッダー部と演奏部の境界線
			DrawLine(0, 232, screenWidth, 232, 0xDDDDDD);




			DrawLyric();

Finally:
			SetDrawScreen(prev);

			using (DrawModeGuard.Create())
			{
				SetDrawMode(DX_DRAWMODE_BILINEAR);
				DrawRotaGraphFast2F(0, fadeY, 0, 0, 1.0F, 0, screen, DX_TRUE);
			}

            if (nowGrab)
            {
				DrawRotaGraph(startMouseX, startMouseY, 1.0, 0, grabMoveImageHandle, DX_TRUE);
            }
		}
        #endregion

        #region 終了処理
        public override void Finish()
		{
			DeleteFontToHandle(font);
			DeleteFontToHandle(infoTextFontHandle);


			ImageLoadControl.Singleton.Delete(attentionMarkHandle);
			ImageLoadControl.Singleton.Delete(backgroundHandle);
            DeleteSoundMem(bgmSoundHandle);
			DeleteSoftSound(bgmSoftHandle);
		}
		#endregion
	}
}
