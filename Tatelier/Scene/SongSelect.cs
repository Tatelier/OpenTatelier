using HjsonEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tatelier.Coroutine;
using Tatelier.DxLibDLL;
using Tatelier.SongSelect;
using static DxLibDLL.DX;
using Tatelier.Interface.Command;
using Tatelier.Interface.Scene;

namespace Tatelier.Scene
{
	class SongSelect : SceneBase
	{
		public const string SongSelectFolderName = "SongSelect";
		public const string ArgsScoreReload = "ScoreReload";

        public override SceneType SceneType => SceneType.SongSelect;

		int nowPage = 3;

		int playOptionButtonIndex = -1;
		int cancelButtonIndex = -2;

		int selectItemFontHandle;
		int courseSelectFontHandle;

		int backImage;
		int playOptionIconImage;

		/// <summary>
		/// -1…曲なし, 0…項目選択, 1…難易度選択
		/// </summary>
		Status status = 0;

		SelectItemControl tjaCtrl;

		Player[] players;

		Background background;

		ISelectItem nowSelectItem;
		ISelectItem emptySelectItem;

		SelectItemRendererItem centerRenderer;
		SelectItemRendererItem[] prevRendererList;
		SelectItemRendererItem[] nextRendererList;

		Hjson.JsonValue keyConfigValue;

		CourseSelectFrameControl courseSelectFrameControl;
		CourseFrame courseFrame;

		SongSelectConfig config;

		Dictionary<int, int> LevelImages;

		(int PlayerNumbrt, Action<int> Act)[] drawActList;
		(int PlayerNumbrt, Action<int> Act)[] updateActList;

		Demo Demo;

		SoundEffect SoundEffect;

		APNGImage parrot;

		Tatelier.Play.TaikoImageControl taiko;

		PlayerScoreRenderer playerScoreRenderer;

		PlayerMusicalScore playerMusicalScore;

		CoroutineControl coroutineControl = new CoroutineControl();

		IEnumerator GetTransitionToPlay()
		{
			Demo.Enabled = false;
			InputControl.Singleton.ChangeInput();

			yield return new Tatelier.Coroutine.Wait(1000);
			SceneControl.Singleton.Unregist(this);

			SceneControl.Singleton.Create(out Play p);

			p.SongSelect = this;
		}

		IEnumerator GetTransitionFromResult()
		{
			TransitionShare.Singleton.TransitionFromResultToSongSelect.End();
			yield return new Coroutine.Wait(625);
			ResetCourseDicide(players);
			SetPlayers(keyConfigValue, Share.Singleton.PlayerNum);
			Demo.Enabled = MainConfig.Singleton.Demo;
		}

		IEnumerator GetLoadAllSaveDataIterator(IEnumerable<string> playerNameList)
        {
			var progress = new Progress.Progress();
			progress.StatusText = "全譜面のセーブデータをロード中...";

			Progress.ProgressControl.Singleton.Create(progress);

			var task = Task.Run(() =>
			{
				tjaCtrl.LoadAllScoreSaveData(playerNameList, (cnt, max) =>
				{
					progress.Max = max;
					progress.NowValue = cnt;
				});

				progress.NowValue = float.MaxValue;
				progress.Max = 1;
			});

            while (!task.IsCompleted)
            {
				yield return null;
            }

			yield break;
        }

		void LoadAllSaveData(IEnumerable<string> playerNameList)
		{
			var iterator = GetLoadAllSaveDataIterator(playerNameList);

			while (iterator.MoveNext()) ;
		}

		public override void OnEnter(IScene sender)
		{
			status = Status.SongSelect;
            if (!(sender is Result))
            {
				ResetCourseDicide(players);
				SetPlayers(keyConfigValue, Share.Singleton.PlayerNum);
				Demo.Enabled = MainConfig.Singleton.Demo;
            }
            else
			{
				LoadSaveData();
				Share.Singleton.PlayerScore.LoadAllSaveData(MainConfig.Singleton.PlayerInfoList[0].Name);
				coroutineControl.StartCoroutine(GetTransitionFromResult());
			}
		}

		void ResetCourseDicide(Player[] players)
		{
			foreach(var p in players)
			{
				p.Reset();
			}
		}

		void InitSelectItem(Hjson.JsonValue json)
		{

			var dic2 = new Dictionary<string, float>()
			{
				{ "ScreenWidth", Supervision.ScreenWidth },
				{ "ScreenWidthHalf", Supervision.ScreenWidthHalf },
				{ "ScreenHeight", Supervision.ScreenHeight },
				{ "ScreenHeightHalf",Supervision.ScreenHeightHalf },
			};

			// 中心
			centerRenderer = new SelectItemRendererItem(json.EQv("Center"), dic2);
			centerRenderer.CurrentlySelectedHeight = centerRenderer.StartHeight;

			dic2.Add("CurrentlySelectedHeight", centerRenderer.CurrentlySelectedHeight);

			// 前
			prevRendererList = new SelectItemRendererItem[json.EQi("Prev.Num") ?? 1];
			for (int i = 0; i < prevRendererList.Length; i++)
			{
				dic2["Index"] = i;
				prevRendererList[i] = new SelectItemRendererItem(json.EQv("Prev"), dic2);
				prevRendererList[i].CurrentlySelectedHeight = centerRenderer.CurrentlySelectedHeight;
			}

			// 次
			nextRendererList = new SelectItemRendererItem[json.EQi("Next.Num") ?? 1];
			for (int i = 0; i < nextRendererList.Length; i++)
			{
				dic2["Index"] = i;
				nextRendererList[i] = new SelectItemRendererItem(json.EQv("Next"), dic2);
				nextRendererList[i].CurrentlySelectedHeight = centerRenderer.CurrentlySelectedHeight;
			}
		}

		void SetPlayerKeyInput(Player[] players)
		{
			string[] nameList = new string[players.Length];
			for (int i = 0; i < players.Length; i++)
			{
				var player = players[i];
				InputControl.Singleton.Regist($"SelectItem{i:00}", player.Input);
				nameList[i] = $"SelectItem{i:00}";
			}
			InputControl.Singleton.ChangeInput(nameList);
		}

		void SetPlayers(Hjson.JsonValue json, int playerNum)
		{
			var tempPlayers = new Tatelier.SongSelect.Player[playerNum];

			var playerInfoList = MainConfig.Singleton.GetPlayerInfoList(playerNum);

			string folder = MainConfig.Singleton.GetThemePath(SongSelectFolderName);

			for (int i = 0; i < tempPlayers.Length; i++)
			{
				if (i < players.Length
					&& players[i] != null)
				{
					tempPlayers[i] = players[i];
				}
				else
				{
					var temp = new Tatelier.SongSelect.Player(playerInfoList[i]);

					temp.Number = i + 1;
					temp.Input = new InputControlItemSongSelect(config.KeyConfigList.FirstOrDefault(), i + 1);
					temp.CourseIndex = 3;
					temp.Cursor = new CourseSelectCursor(Path.Combine(MainConfig.Singleton.ThemeFolderPath, "SongSelect"), config.Get(SongSelectConfig.Type.CourseSelectCursor).FirstOrDefault(), i + 1, 0);
					temp.PlayerMusicalScore = new PlayerMusicalScore(folder, null, tjaCtrl);

					tempPlayers[i] = temp;
				}
			}

			players = tempPlayers;

			SetPlayerKeyInput(players);
		}

		#region コマンド処理

		ResultType CommandDecrypt(string command, string[] args)
		{
			bool hasDecryptRole = Share.Singleton.TokenInfo.ScoreSaveDataDecrypt == 1;
			if (hasDecryptRole)
			{
				if (nowSelectItem is MusicalScoreSelectItem msi)
				{
					string tjaFilePath = Path.GetFullPath(this.tjaCtrl.GetFilePath(msi));

                    var saveDataDecryptor = new ScoreSaveDataDecryptor
                    {
                        HasDecryptRole = hasDecryptRole,
						PlayerName = MainConfig.Singleton.PlayerInfoList[0].Name,
					};
                    saveDataDecryptor.Execute(tjaFilePath);
				}
				else
				{
					LogWindow.Singleton.Insert("譜面を選択している状態でしか利用できません。", LogWindow.WarningColor);
				}
			}
			else
			{
				LogWindow.Singleton.Insert("復号化可能な権限ではありません。", LogWindow.WarningColor);
			}

			return ResultType.Exit;
		}

		ResultType CommandDemo(string command, string[] args)
		{
			Demo.Enabled = MainConfig.Singleton.Demo;
			return ResultType.Exit;
		}

		ResultType CommandEdit(string command, string[] args)
		{
			if (nowSelectItem is MusicalScoreSelectItem mssi)
			{
				Share.Singleton.ScoreFilePath = tjaCtrl.GetFilePath(mssi);
				Share.Singleton.SelectInfo = new SelectInfo()
				{
					TJASelectItem = (nowSelectItem as MusicalScoreSelectItem),
				};
				Demo.Enabled = false;
				InputControl.Singleton.ChangeInput();
				SceneControl.Singleton.Create(out Multi multi);
				multi.songSelectScene = this;
				EnterTo(multi);				
			}
			else
			{
				LogWindow.Singleton.Insert("譜面を選択している状態でしか利用できません。", LogWindow.WarningColor);
			}

			return ResultType.Exit;
		}

		ResultType CommandEditor(string command, string[] args)
		{
			if (nowSelectItem is MusicalScoreSelectItem mssi)
			{
				Process.Start("notepad", tjaCtrl.GetFilePath(mssi));
			}
			else
			{
				LogWindow.Singleton.Insert("譜面を選択している状態でしか利用できません。", LogWindow.WarningColor);
			}

			return ResultType.Exit;
		}

		ResultType CommandPlayer(string command, string[] args)
		{
			SetPlayers(keyConfigValue, Share.Singleton.PlayerNum);

			return ResultType.Exit;
		}

		ResultType CommandCourse(string command, string[] args)
		{
			if (status != Status.CourseSelect)
			{
				LogWindow.Singleton.Insert("コース選択時でのみ利用できるコマンドです。", LogWindow.WarningColor);
				return ResultType.Exit;
			}

			char t = '\0';
			int courseIndex = -1;
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
							if (courseIndex != -1)
							{
								if (int.TryParse(args[i_arg], out var n)
									&& n - 1 >= 0)
								{
									players[n - 1].IsCourseDecide = true;
									players[n - 1].CourseIndex = courseIndex;
								}
							}
						}
						else
						{
							var courses = (nowSelectItem as MusicalScoreSelectItem)?.TJA.Courses;
							for (int i = 0; i < courses?.Count; i++)
							{
								if (courses[i].OriginalName == args[i_arg])
								{
									courseIndex = i;
									break;
								}
							}
						}
						break;
				}
			}
			return ResultType.Exit;
		}

		IEnumerator GetScoreSelectIterator(ISelectItem ssItem)
		{
			tjaCtrl.Open(ssItem.Parent as GenreSelectItem);
			nowSelectItem = ssItem;
			background.ChangeImage(nowSelectItem.BackgroundImageHandle);

			playerMusicalScore.SelectItem = nowSelectItem;
			UpdateCommonMove();

			yield break;
		}

		ResultType CommandScoreSelect(string command, string[] args)
		{
			if (args.Length > 0)
			{
				if(int.TryParse(args[0], out var index))
				{
					var ssItem = tjaCtrl.GetFromIndex(index);
					if (ssItem != null)
					{
						coroutineControl.StartCoroutine(GetScoreSelectIterator(ssItem));
					}
					else
					{
						LogWindow.Singleton.Insert("見つかりませんでした。", 0xf39189);
					}					
				}
			}
			else
			{
				LogWindow.Singleton.Insert("引数がありません。", 0xf39189);
			}

			return ResultType.Exit;
        }

		ResultType CommandSearch(string command, string[] args)
		{
			if (args.Length > 0)
			{
				foreach (var item in args)
				{
					switch (item)
					{
						case "-n":
						case "--name":
							break;
						default:
							{
								var ssItem = tjaCtrl.GetSearch(item);
								if (ssItem != null)
								{
									tjaCtrl.Open(ssItem.Parent as GenreSelectItem);
									nowSelectItem = ssItem;
									background.ChangeImage(nowSelectItem.BackgroundImageHandle);

									playerMusicalScore.SelectItem = nowSelectItem;
									UpdateCommonMove();
								}
								else
								{
									LogWindow.Singleton.Insert("見つかりませんでした。", 0xf39189);
								}
							}
							break;
					}
				}
			}
			else
			{
				LogWindow.Singleton.Insert("引数がありません。", 0xf39189);
			}

			return ResultType.Exit;
		}

		ResultType CommandDragAndDrop(string command, string[] args)
        {
            if (args.Length > 0)
			{
				foreach(var item in args)
				{
					var dir = Path.GetDirectoryName(item);
					var fileName = Path.GetFileName(item);
					var extension = Path.GetExtension(item);

					if (extension.EndsWith(".tja"))
					{
						var summary = new MusicalScore();
						summary.LoadFromFile(dir, fileName);

						var tjaItem = new MusicalScoreSelectItem(summary, (GenreSelectItem)null);


						Share.Singleton.ScoreFilePath = item;

						ActToPlayTransition(tjaItem);
						InputControl.Singleton.ChangeInput();

						// 譜面読込の場合は以降の処理は行わない
						break;
					}
					else if (extension.EndsWith(".tlrsav"))
					{
						bool hasDecryptRole = Share.Singleton.TokenInfo.ScoreSaveDataDecrypt == 1;
						if (hasDecryptRole)
						{
							var saveDataDecryptor = new ScoreSaveDataDecryptor
							{
								HasDecryptRole = hasDecryptRole
							};
							saveDataDecryptor.ExecuteFromSaveData(item);
						}
						else
						{
							LogWindow.Singleton.Insert("復号化可能な権限ではありません。", LogWindow.WarningColor);
						}
					}
				}
			}

			return ResultType.Exit;
        }

		public override ResultType CommandSearchAndRun(string command, params string[] args)
		{
			if(commandMap.TryGetValue(command, out var func))
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
		#endregion

		#region 固定描画
		IEnumerator fixedImageEnumerator;

		IEnumerator GetFixedImageEnumerator()
		{
			yield break;
		}
		void DrawFixedImage(int playerIndex)
		{
			fixedImageEnumerator.MoveNext();

			return;
		}
		#endregion

		#region 選択項目描画

		/// <summary>
		/// 選択項目を描画する
		/// </summary>
		/// <param name="rendererItem">選択項目描画用データ</param>
		/// <param name="selectItem">選択項目</param>
		void DrawSelectItemF(SelectItemRendererItem rendererItem, ISelectItem selectItem)
		{
			selectItem.Draw(rendererItem);
		}

		/// <summary>
		/// 選択項目すべてを描画する
		/// </summary>
		/// <param name="playerIndex">プレイヤー要素番号 ※未使用</param>
		void DrawAllSelectItem(int playerIndex)
		{
			if (nowSelectItem == null) return;

			// 中央
			var current = nowSelectItem;
			DrawSelectItemF(centerRenderer, current);

			// 前の項目
			current = nowSelectItem;
			for (int i = 0; i < prevRendererList.Length; i++)
			{
				current = current.Prev;
				DrawSelectItemF(prevRendererList[i], current);
			}

			// 次の項目
			current = nowSelectItem;
			for (int i = 0; i < nextRendererList.Length; i++)
			{
				current = current.Next;
				DrawSelectItemF(nextRendererList[i], current);
			}
		}

		#endregion

		#region 更新処理・描画処理マップ関連
		/// <summary>
		/// 更新処理メソッドマップ
		/// </summary>
		/// <returns></returns>
		Dictionary<string, Action<int>> CreateUpdateActionMap()
		{
			return new Dictionary<string, Action<int>>()
			{
				{ "Background", UpdateBackground },
			};
		}

		/// <summary>
		/// 描画処理メソッドマップ
		/// </summary>
		/// <returns></returns>
		Dictionary<string, Action<int>> CreateDrawActionMap()
		{
			return new Dictionary<string, Action<int>>()
			{
				{ "Background", DrawBackground },
				{ "SelectItem", DrawAllSelectItem },
				{ "FixedImage", DrawFixedImage },
			};
		}
        #endregion

		/// <summary>
		/// 現在選択している項目でデモ音源を再読込する
		/// </summary>
		void RefreshDemo()
		{
			if (tjaCtrl.TryGetWaveFilePath(nowSelectItem, out var wavePath, out var demoStart))
			{
				Demo.ResetDelay();
				Demo.Load(wavePath, demoStart, true);
			}
			else
			{
				Demo.LoadDefault();
			}
		}

		void ActToPlayTransition(MusicalScoreSelectItem tjaItem)
		{
			var courseNames = new string[Share.Singleton.PlayerNum];

			for (int i = 0; i < players.Length; i++)
			{
				courseNames[i] = tjaItem.TJA.Courses[players[i].CourseIndex].OriginalName;
			}

			Share.Singleton.SelectInfo = new SelectInfo()
			{
				TJASelectItem = tjaItem,
				PlayerInfoList = players.Select(v => v.Info).ToArray(),
				CourseNames = courseNames
			};

			coroutineControl.StartCoroutine(GetTransitionToPlay());
			TransitionShare.Singleton.TransitionToPlay.Begin(Share.Singleton.SelectInfo.CourseNames);
		}

		#region アニメーション
		void SetMoveAnimation(SelectItemRendererItem[] a, SelectItemRendererItem[] b)
		{
			const int duration = 150;

			// アニメーション中は、操作不可
			foreach (var player in players)
			{
				player.Input.OKCancelEnabled = false;
			}

			// 
			for (int i = 0; i < a.Length - 1; i++) a[i].SetAnimate(
				new IAnimateItem[]
				{
					new AnimatePointItem(a[i])
					{
						StartX = a[i+1].CXf,
						StartY = a[i+1].CYf,
						During = duration
					}
				}
				,
				new IAnimateItem[]
				{
					new AnimateSizeItem(a[i])
					{
						EndWidth = a[i+1].StartWidth,
						EndHeight = a[i+1].StartHeight,
						During = duration,
						EasingType = Common.EasingType.SinIn,
					}
				}
			);

			centerRenderer.SetAnimate(
				new IAnimateItem[]
				{
					new AnimatePointItem(centerRenderer)
					{
						StartX = a[0].CXf,
						StartY = a[0].CYf,
						During = duration
					}
					,
					new AnimateAction()
					{
						Action = () =>
						{
							foreach (var player in players)
							{
								player.Input.OKCancelEnabled = true;
							}
						}
					}
				}
				,
				new IAnimateItem[]
				{
					new AnimateSizeItem(centerRenderer)
					{
						StartWidth = a[0].StartWidth,
						StartHeight = a[0].StartHeight,
						EndWidth = a[0].StartWidth,
						EndHeight = a[0].StartHeight,
					}
					,
					new AnimateWait()
					{
						During = 500
					}
					,
					new AnimateSizeItem(centerRenderer)
					{
						StartWidth = a[0].Width,
						StartHeight = a[0].Height,
						During = 100,
						EasingType = Common.EasingType.SinOut,
					}
					,
					new AnimateAlpha(AnimateType.CourseAlpha)
					{
						StartAlpha = 0,
						EndAlpha = 255,
						During = 50,
					}
				}
				,
				new IAnimateItem[]
				{
					new AnimateAlpha(AnimateType.CourseAlpha)
					{
						StartAlpha = 0,
						EndAlpha = 0,
					}
				}
			);

			b[0].SetAnimate(
				new IAnimateItem[]
				{
					new AnimateSizeItem(b[0])
					{
						StartWidth = centerRenderer.Width,
						StartHeight = centerRenderer.Height,
						During = 100,
						EasingType = Common.EasingType.SinOut,
					}
				}
				,
				new IAnimateItem[]
				{
					new AnimatePointItem(b[0])
					{
						StartX = centerRenderer.CXf,
						StartY = centerRenderer.CYf,
						During = duration
					}
				}
			);

			for (int i = 1; i < b.Length; i++) b[i].SetAnimate(new IAnimateItem[]
			{
				new AnimatePointItem(b[i])
				{
					StartX = b[i - 1].CXf,
					StartY = b[i - 1].CYf,
					During = duration
				}
			});
		}

		void SetOKAnimation(Action changeAction)
		{
			foreach (var player in players)
			{
				player.Input.Enabled = false;
			}

			// 真ん中
			{
				var itemList = new IAnimateItem[]
				{
					new AnimateSizeItem()
					{
						StartWidth = centerRenderer.StartWidth,
						StartHeight = centerRenderer.StartHeight,
						EndWidth = centerRenderer.StartWidth,
						EndHeight = centerRenderer.StartHeight,
						During = 500
					},
					new AnimateSizeItem()
					{
						StartWidth = centerRenderer.StartWidth,
						StartHeight = centerRenderer.StartHeight,
						EndWidth = 0,
						EndHeight = centerRenderer.StartHeight,
						During = 300,
						EasingType = Common.EasingType.SinOut,
					}
					,
					new AnimateAction()
					{
						Action = changeAction,
					}
					,
					new AnimateSizeItem()
					{
						StartWidth = 0,
						StartHeight = centerRenderer.StartHeight,
						EndWidth = centerRenderer.StartWidth,
						EndHeight = centerRenderer.StartHeight,
						During = 300,
						EasingType = Common.EasingType.SinIn,
					}
				};
				centerRenderer.SetAnimate(
					itemList
					,
					new IAnimateItem[]{
					new AnimateWait()
					{
						During = 0,
					}
					,
					new AnimateAlpha(AnimateType.Content)
					{
						StartAlpha = 255,
						EndAlpha = 0,
						During = 150,
					},
					new AnimateWait()
					{
						During = 1000,
					}
					,
					new AnimateAlpha(AnimateType.Content)
					{
						StartAlpha = 0,
						EndAlpha = 255,
						During = 150,
					},
					new AnimateAction()
					{
						Action = () =>
						{
							foreach(var player in players)
							{
								player.Input.Enabled = true;
							}
						}
					}
				});
			}

			// 
			for (int i = 0; i < prevRendererList.Length; i++)
			{
				var itemList = new IAnimateItem[]
				{
					new AnimateWait()
					{
						During = 60 * (prevRendererList.Length - i - 1)
					}
					,
					new AnimatePointItem()
					{
						StartX = prevRendererList[i].StartCXf,
						StartY = prevRendererList[i].StartCYf,
						EndX = Supervision.ScreenWidthHalf - 50 - 50 * (i + 4),
						EndY = Supervision.ScreenHeightHalf - 250 - 144 * (i + 4),
						During = 500,
						EasingType = Common.EasingType.SinIn,
					},
					new AnimatePointItem()
					{
						StartX = Supervision.ScreenWidthHalf - 50 - 50 * (i + 4),
						StartY = Supervision.ScreenHeightHalf - 250 - 144 * (i + 4),
						EndX = Supervision.ScreenWidthHalf - 50 - 50 * (i + 4),
						EndY = Supervision.ScreenHeightHalf - 250 - 144 * (i + 4),
					},
					new AnimateWait()
					{
						During = 120 * i + 300
					}
					,
					new AnimatePointItem()
					{
						StartX = Supervision.ScreenWidthHalf - 50 - 50 * (i + 4),
						StartY = Supervision.ScreenHeightHalf - 250 - 144 * (i + 4),
						EndX = prevRendererList[i].StartCXf,
						EndY = prevRendererList[i].StartCYf,
						During = 500,
						EasingType = Common.EasingType.SinOut,
					}
				};
				prevRendererList[i].SetAnimate(itemList);
			}

			// 
			for (int i = 0; i < nextRendererList.Length; i++)
			{
				var itemList = new IAnimateItem[]
				{
					new AnimateWait()
					{
						During = 60 * (nextRendererList.Length - i - 1)
					}
					,
					new AnimatePointItem()
					{
						StartX = nextRendererList[i].StartCXf,
						StartY = nextRendererList[i].StartCYf,
						EndX = Supervision.ScreenWidthHalf + 50 + 50 * (i + 4),
						EndY = Supervision.ScreenHeightHalf + 250 + 144 * (i + 4),
						During = 500,
						EasingType = Common.EasingType.SinIn,
					},
					new AnimatePointItem()
					{
						StartX = Supervision.ScreenWidthHalf + 50 + 50 * (i + 4),
						StartY = Supervision.ScreenHeightHalf + 250 + 144 * (i + 4),
						EndX = Supervision.ScreenWidthHalf + 50 + 50 * (i + 4),
						EndY = Supervision.ScreenHeightHalf + 250 + 144 * (i + 4),
					},
					new AnimateWait()
					{
						During = 120 * i + 300
					}
					,
					new AnimatePointItem()
					{
						StartX = Supervision.ScreenWidthHalf + 50 + 50 * (i + 4),
						StartY = Supervision.ScreenHeightHalf + 250 + 144 * (i + 4),
						EndX = nextRendererList[i].StartCXf,
						EndY = nextRendererList[i].StartCYf,
						During = 500,
						EasingType = Common.EasingType.SinOut,
					}
				};
				nextRendererList[i].SetAnimate(itemList);
			}
		}
		#endregion

		public override int PreStart(object[] args)
		{
			if (args?.Length > 0)
			{
				if ((string)args[0] == ArgsScoreReload)
				{
					var config2 = new SongSelectConfig(new SongSelectConfig.Info()
					{
						Json = HjsonEx.HjsonEx.LoadEx(Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"SongSelect\SongSelectConfig.hjson"))
					});

					Share.Singleton.SongSelectItemControl = null;

					if (config2?.SelectItemList.Count > 0)
					{
						Share.Singleton.SongSelectItemControl = new SelectItemControl(MainConfig.Singleton.ScoreFolderPath, config2.SelectItemList.FirstOrDefault());
					}
				}
			}

			return 0;
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
				{ "/course", CommandCourse },
				{ "/decrypt", CommandDecrypt },
				{ "/demo", CommandDemo },
				{ "/edit", CommandEdit },
				{ "/editor", CommandEditor },
				{ "/notepad", CommandEditor },
				{ "/player", CommandPlayer },
				{ "/search", CommandSearch },
				{ "/score-select", CommandScoreSelect },
			};
		}

		/// <summary>
		/// デモ関連を初期化する
		/// </summary>
		void InitDemo()
		{
			string folder = MainConfig.Singleton.GetThemePath(SongSelectFolderName);
			Demo = new Demo(Path.Combine(folder), config.DemoList.FirstOrDefault())
			{
				Enabled = MainConfig.Singleton.Demo
			};

			Demo.Start();
			Demo.SetDelayMasterFromFrame(25);
		}

		/// <summary>
		/// レベル画像関連を初期化する
		/// </summary>
		void InitLevelImage()
		{
			LevelImages = new Dictionary<int, int>();

			var levels = tjaCtrl.GetAllLevel();

			for (int i = 0; i < levels.Length; i++)
			{
				LevelImages[levels[i]] = Utility.GetImageHandleFromText($"★{levels[i]}", 0xFFFFFF, MainConfig.Singleton.DefaultFont, 120, 60, 40, 6, 0);
			}

			LevelImages[-1] = Utility.GetImageHandleFromText($"★-", 0xFFFFFF, MainConfig.Singleton.DefaultFont, 120, 60, 40, 6, 0);

		}

		void LoadSaveData()
		{
			switch (MainConfig.Singleton.SongSelect.SaveDataLoadingType)
			{
				case MainConfigElement.SongSelectSaveDataLoadingType.AsyncAllData:
					coroutineControl.StartCoroutine(GetLoadAllSaveDataIterator(MainConfig.Singleton.GetPlayerInfoList(Share.Singleton.PlayerNum).Select(v => v.Name).ToList()));
					break;
				case MainConfigElement.SongSelectSaveDataLoadingType.SyncAllData:
					LoadAllSaveData(MainConfig.Singleton.GetPlayerInfoList(Share.Singleton.PlayerNum).Select(v => v.Name).ToList());
					break;
				default:
					break;
			}
		}

		void UpdateBackground(int playerIndex)
		{
			background.Update();
		}

		void UpdateCourseSelectPlayOption(Player player)
		{
			if (player.Input.GetKeyDown(InputControlItemSongSelect.OK))
			{
				SoundEffect.OK();
				if(!player.PlayOptionRenderer.MoveNext())
				{
					player.Status = Status.None;
					player.PlayOptionRenderer.Enabled = false;
				}
			}

			if (player.Input.GetKeyDown(InputControlItemSongSelect.Prev))
			{
				SoundEffect.Move();
				player.PlayOptionRenderer.ItemPrev();
			}
			else if (player.Input.GetKeyDown(InputControlItemSongSelect.Next))
			{
				SoundEffect.Move();
				player.PlayOptionRenderer.ItemNext();
			}
		}

		/// <summary>
		/// コース選択更新処理
		/// </summary>
		void UpdateCourseSelect()
		{
			// 難易度選択じゃないときは以下の処理をしない
			if (status != Status.CourseSelect) return;

			var tjaItem = (nowSelectItem as MusicalScoreSelectItem);
			var tja = tjaItem.TJA;


			for (int i = 0; i < players.Length; i++)
			{
				var player = players[i];

				if (!player.IsCourseDecide)
				{
					if (player.Status == Status.PlayOption)
					{
						UpdateCourseSelectPlayOption(player);
					}
					else
					{
						if (player.Input.GetKeyDown(InputControlItemSongSelect.Prev))
						{
							SoundEffect.Move();

							if (player.CourseIndex == cancelButtonIndex)
							{

							}
							else if (player.CourseIndex == playOptionButtonIndex)
							{
								player.CourseIndex = cancelButtonIndex;
							}
							else
							{
								int temp = player.CourseIndex;

								int j = temp;
								if (j >= 3)
								{
									j = 3;
								}
								do
								{
									j--;
									if (j < 0) break;

									if (tja.Courses[j].Level != -1)
									{
										break;
									}

								} while (j >= playOptionButtonIndex);

								if (j > cancelButtonIndex)
								{
									player.CourseIndex = j;
								}
							}
						}
						else if (player.Input.GetKeyDown(InputControlItemSongSelect.Next))
						{
							SoundEffect.Move();

							if (player.CourseIndex == cancelButtonIndex)
							{
								player.CourseIndex = playOptionButtonIndex;
							}
							else if (player.CourseIndex == playOptionButtonIndex)
							{
								player.CourseIndex = tja.GetEasiestCourseIndex();
							}
							else
							{
								if (tja.Courses.Count(v => v.Level != -1) == 1)
								{
									// 何もしない
								}
								else
								{
									int temp = player.CourseIndex;

									if (temp < 3)
									{
										int j = temp;

										do
										{
											j++;
											if (j >= tja.Courses.Count) break;

											if (tja.Courses[j].Level != -1)
											{
												break;
											}
										}
										while (j < tja.Courses.Count);

										if (j < tja.Courses.Count)
										{
											player.CourseIndex = j;
										}
									}
									else
									{
										temp = nowPage;

										int j = temp;
										do
										{
											nowPage = ((nowPage - 3) + 1) % (tja.Courses.Count - 3) + 3;
											if (tja.Courses[nowPage].Level != -1)
											{
												break;
											}
										} while (temp != nowPage);

										player.CourseIndex = nowPage;
									}
								}
							}
						}

						if (player.Input.GetKeyDown(InputControlItemSongSelect.OK))
						{
							// コース確定
							SoundEffect.OK();

							if (player.CourseIndex == cancelButtonIndex)
							{
								// 項目選択に戻る
								status = Status.SongSelect;
							}
							else if (player.CourseIndex == playOptionButtonIndex)
							{
								player.Status = Status.PlayOption;
								if (i < 2)
								{
									player.PlayOptionRenderer.Enabled = true;
									player.PlayOptionRenderer.ResetIndex();
								}
                                else
                                {
									LogWindow.Singleton.Insert("現在のバージョンでは、1pと2pのみ設定ができます。");
                                }
							}
							else
							{
								if (player.CourseIndex >= 3)
								{
									player.CourseIndex = nowPage;
								}

								player.IsCourseDecide = true;

								if (!players.Any(v => !v.IsCourseDecide))
								{
									// 音源存在チェック
									if (MainConfig.Singleton.CheckExistWave
										&& !tjaCtrl.TryGetWaveFilePath(nowSelectItem, out var wavePath, out var demoStart))
									{
										string directoryName = "";

										if ((nowSelectItem.Parent as GenreSelectItem).FilePath?.Length > 0)
										{
											directoryName = Path.GetDirectoryName((nowSelectItem.Parent as GenreSelectItem).FilePath);
										}

										var info = new MyMessageBoxInfo()
										{
											MessageType = MessageType.Warning,
											Text = $"音源ファイルが存在しません。\nそのまま演奏画面に移りますか？\n\n"
											+ Path.Combine(
												directoryName
												, (nowSelectItem as MusicalScoreSelectItem).RelativeFilePath),

											MyMessageBoxItems = new MyMessageBoxItemInfo[]
											{
											new MyMessageBoxItemInfo()
											{
												Name = "はい",
												Callback = () =>
												{
													SoundEffect.OK();
													ActToPlayTransition(tjaItem);
													InputControl.Singleton.ChangeInput();
												}
											},
											new MyMessageBoxItemInfo()
											{
												Name = "いいえ",
												Callback = () =>
												{
													SoundEffect.OK();
													ResetCourseDicide(players);
													SetPlayerKeyInput(players);
												}
											},
											}
										};
										MyMessageBox.Singleton.Open(info);
									}
									else
									{
										ActToPlayTransition(tjaItem);
										InputControl.Singleton.ChangeInput();
									}
								}
							}
						}

						if (player.Input.GetKeyDown(InputControlItemSongSelect.Cancel))
						{
							// 項目選択に戻る
							status = Status.SongSelect;
						}

						if (player.Input.GetKeyDown(InputControlItemSongSelect.Edit))
						{
							CommandSearchAndRun("/edit");
						}
					}

				}
				else
				{
					if (player.Input.GetKeyDown(InputControlItemSongSelect.Cancel))
					{
						// 項目選択に戻る
						player.IsCourseDecide = false;
					}
				}
			}
		}

		#region セーブデータのロード・アンロード
		/// <summary>
		/// 選択中曲のセーブデータをロードする
		/// </summary>
		void LoadSaveDataNowSelectItem()
		{
			if (nowSelectItem is MusicalScoreSelectItem mssi)
			{
				switch (MainConfig.Singleton.SongSelect.SaveDataLoadingType)
				{
					case MainConfigElement.SongSelectSaveDataLoadingType.LoadsWhenSelectedAndUnloadsWhenRemoved:
					case MainConfigElement.SongSelectSaveDataLoadingType.LoadWhenSelected:
						{
							mssi.TJA.LoadSaveData(tjaCtrl.ScoreRootFolder, players.Select(v=>v.Info.Name));
						}
						break;
				}
			}
		}

		/// <summary>
		/// 選択中曲のセーブデータをアンロードする
		/// </summary>
		void UnloadSaveDataNowSelectItem()
		{
			if (nowSelectItem is MusicalScoreSelectItem mssi)
			{
				switch (MainConfig.Singleton.SongSelect.SaveDataLoadingType)
				{
					case MainConfigElement.SongSelectSaveDataLoadingType.LoadsWhenSelectedAndUnloadsWhenRemoved:
						{
							mssi.TJA.UnloadSaveData();
						}
						break;
				}
			}
		}
		#endregion

		/// <summary>
		/// 移動更新の共通処理
		/// </summary>
		void UpdateCommonMove()
		{
			background.ChangeImage(nowSelectItem.BackgroundImageHandle);
			playerMusicalScore.SelectItem = nowSelectItem;
			RefreshDemo();
			SoundEffect.Move();
		}

		/// <summary>
		/// 項目選択更新処理
		/// </summary>
		void UpdateItemSelect()
		{
			// 項目選択でないときは以下の処理をしない
			if (status != Status.SongSelect) return;

			// 譜面がないときも処理をしない
			if (!tjaCtrl.HasScore) return;

			for (int i = 0; i < players.Length; i++)
			{
				var player = players[i];

				// 戻る
				if (player.Input.GetKeyDown(InputControlItemSongSelect.Prev))
				{
					UnloadSaveDataNowSelectItem();
					nowSelectItem = nowSelectItem.Prev;
					SetMoveAnimation(prevRendererList, nextRendererList);

					UpdateCommonMove();
					LoadSaveDataNowSelectItem();
				}

				// 進む
				if (player.Input.GetKeyDown(InputControlItemSongSelect.Next))
				{
					UnloadSaveDataNowSelectItem();
					nowSelectItem = nowSelectItem.Next;
					SetMoveAnimation(nextRendererList, prevRendererList);

					UpdateCommonMove();
					LoadSaveDataNowSelectItem();
				}

				// 決定
				if (player.Input.GetKeyDown(InputControlItemSongSelect.OK))
				{
					switch (nowSelectItem)
					{
						case BackSelectItem back:
							{
								SetOKAnimation(() =>
								{
									nowSelectItem = tjaCtrl.Close(back.Parent as GenreSelectItem);
									background.ChangeImage(nowSelectItem.BackgroundImageHandle);
									playerMusicalScore.SelectItem = nowSelectItem;
									LoadSaveDataNowSelectItem();
									RefreshDemo();
								});
							}
							break;
						case GenreSelectItem genre:
							{
								if (!genre.SelectItems.Any())
								{
									var info = new MyMessageBoxInfo()
									{
										MessageType = MessageType.Warning,
										Text = $"選べる譜面がありません。\nフォルダを確認してください。\n\n{Path.Combine(Path.GetDirectoryName(genre.FilePath))}"
										,
										MyMessageBoxItems = new MyMessageBoxItemInfo[]
										{
										new MyMessageBoxItemInfo()
										{
											Name = "確認しない",
										},
										new MyMessageBoxItemInfo()
										{
											Name = "フォルダを開く",
											Callback = () =>
											{
												Process.Start(Path.Combine(Environment.CurrentDirectory,Path.GetDirectoryName(genre.FilePath)));
											}
										},
										}
									};
									MyMessageBox.Singleton.Open(info);
								}
								else
								{
									SetOKAnimation(() =>
									{
                                        if (nowSelectItem is GenreSelectItem g)
										{
											nowSelectItem = tjaCtrl.Open(g);
										}
										background.ChangeImage(nowSelectItem.BackgroundImageHandle);
										playerMusicalScore.SelectItem = nowSelectItem;
										LoadSaveDataNowSelectItem();
										RefreshDemo();
									});
								}
							}
							break;
						case MusicalScoreSelectItem tja:
							{
								Share.Singleton.SelectInfo = new SelectInfo()
								{
									TJASelectItem = tja,
									PlayerInfoList = players.Select(v => v.Info).ToArray(),
								};
								Share.Singleton.ScoreFilePath = tjaCtrl.GetFilePath(tja);

								if (!tja.TJA.Courses.Any(v => v.Level > 0))
								{
									string directoryName = "";

									try
									{
										directoryName = Path.GetDirectoryName((nowSelectItem.Parent as GenreSelectItem)?.FilePath);
									}
									catch
									{

									}

									var filePath = Path.Combine(directoryName, (nowSelectItem as MusicalScoreSelectItem).RelativeFilePath);

									var info = new MyMessageBoxInfo()
									{
										MessageType = MessageType.Warning,
										Text = $"選べるコースがありません。\nファイルを確認してください。\n\n{filePath}"
										,
										MyMessageBoxItems = new MyMessageBoxItemInfo[]
										{
										new MyMessageBoxItemInfo()
										{
											Name = "確認しない",
										},
										new MyMessageBoxItemInfo()
										{
											Name = "既定アプリで開く",
											Callback = () =>
											{
												Process.Start(filePath);
											}
										},
										new MyMessageBoxItemInfo()
										{
											Name = "メモ帳で開く",
											Callback = () =>
											{
												Process.Start("notepad.exe", filePath);
											}
										},
										}
									};
									MyMessageBox.Singleton.Open(info);
								}
								else
								{
									// コース選択へ
									status = Status.CourseSelect;

									{

										var tjaItem = (nowSelectItem as MusicalScoreSelectItem);
										var innerTja = tjaItem.TJA;


										foreach (var player2 in players)
										{
											if (player2.CourseIndex < 0)
											{
												player2.CourseIndex = 3;
											}
											if (innerTja.Courses[player2.CourseIndex].Level == -1)
											{
												int temp = player2.CourseIndex;
												do
												{
													player2.CourseIndex = (player2.CourseIndex + 1) % innerTja.Courses.Count;
													if (innerTja.Courses[player2.CourseIndex].Level != -1)
													{
														break;
													}
												} while (temp != player2.CourseIndex);

											}

											if (nowPage > 3)
											{
												nowPage = 3;
											}

											if (player2.CourseIndex >= 3)
											{
												for (int ic = 3; ic < innerTja.Courses.Count; ic++)
												{
													if (innerTja.Courses[ic].Level != -1)
													{
														player2.CourseIndex = ic;
														nowPage = ic;
														break;
													}
												}
											}
										}
									}
								}
							}
							break;
					}
					SoundEffect.OK();
				}

				// キャンセル
				if (player.Input.GetKeyDown(InputControlItemSongSelect.Cancel))
				{
					switch (nowSelectItem)
					{
						case BackSelectItem back:
							{
								if (back.Parent != null)
								{
									SetOKAnimation(() =>
									{
										nowSelectItem = tjaCtrl.Close(back.Parent as GenreSelectItem);
										background.ChangeImage(nowSelectItem.BackgroundImageHandle);
										playerMusicalScore.SelectItem = nowSelectItem;
										RefreshDemo();
									});
								}
							}
							break;
						case MusicalScoreSelectItem tja:
							{
								if (tja.Parent != null)
								{
									SetOKAnimation(() =>
									{
										nowSelectItem = tjaCtrl.Close(tja.Parent as GenreSelectItem);
										background.ChangeImage(nowSelectItem.BackgroundImageHandle);
										playerMusicalScore.SelectItem = nowSelectItem;
										RefreshDemo();
									});
								}
							}
							break;
					}
				}

				// 編集モードコマンド実行
				if (player.Input.GetKeyDown(InputControlItemSongSelect.Edit))
				{
					CommandSearchAndRun("/edit");
				}
			}
		}

		void UpdatePlayerMusicalScore()
		{
			playerMusicalScore.Update();
		}

		void DrawBackground(int playerIndex)
		{
			background.Draw();
		
			if(!tjaCtrl.HasScore)
			{
				string text = "譜面がありません。";
				DrawStringF(Supervision.ScreenWidthHalf - GetDrawStringWidth(text, Share.Singleton.SJIS.GetByteCount(text)) / 2, Supervision.ScreenHeightHalf - GetFontSize() / 2, text, 0xFFFFFF);
			}
		}

		void DrawCourseSelect()
		{
			const int CourseIndexVeryHard = 3;

			if (status != Status.CourseSelect) return;

			var tja = (nowSelectItem as MusicalScoreSelectItem).TJA;

			// 全体フレーム
			// 選択中のフレームサイズを変更して描画する
			nowSelectItem.Frame.Width = 1216;
			nowSelectItem.Frame.Height = 756;
			nowSelectItem.Frame.InnerWidth = 1308;
			nowSelectItem.Frame.InnerHeight = 256;
			nowSelectItem.Frame.InnerFrame.Pivot = Pivot.TopLeft;
			nowSelectItem.Frame.Draw(352, 58, 306, 72);

			// タイトル描画
			GetGraphSize(nowSelectItem.TitleImageHandle, out int w, out int h);
			Utility.GetCenterPointF(Supervision.ScreenWidthHalf, 192, w, h, out var centerX, out var centerY);
			DrawGraphF(centerX, centerY, nowSelectItem.TitleImageHandle, DX_TRUE);

			string[] courseNames = new string[]
			{
				"かんたん",
				"ふつう",
				"むずかしい",
				"おに",
			};

			const float CourseIndex0PositionX = 648;
			const float CourseMarginX = 20;

			float x = CourseIndex0PositionX;
			float y = 406;

			int courseWidth = 196;
			// 未使用
			//int height = 354;

			int courseNameWidth = courseWidth / 2;

			// 未使用
			//int border = 12;

			// コース難易度
			string levelText;

			// 難易度描画
			for (int i = 0; i < courseNames.Length; i++)
			{
				int tempIndex = i;

				if (tempIndex == CourseIndexVeryHard)
				{
					tempIndex = nowPage;
					x = CourseIndex0PositionX + (courseWidth + CourseMarginX) * CourseIndexVeryHard;
				}
				else if(tempIndex >= 0)
				{
					x = CourseIndex0PositionX + (courseWidth + CourseMarginX) * tempIndex;
				}

				if (tja.Courses[tempIndex].Level > 0)
				{
					using (DrawBrightGuard.Create())
					{
						DrawGraphF(x, y, courseSelectFrameControl.GetHandle(tempIndex), DX_TRUE);
					}

					levelText = $"★{tja.Courses[tempIndex].Level}";
					using (DrawModeGuard.Create())
					{
						SetDrawMode(DX_DRAWMODE_BILINEAR);
						DrawExtendStringFToHandle(x + (courseWidth / 2) - (GetDrawStringWidthToHandle(courseNames[i], Share.Singleton.SJIS.GetByteCount(courseNames[i]), selectItemFontHandle) / 2) * 0.70F, y + 200, 0.70, 0.70, courseNames[i], 0xFFFFFF, selectItemFontHandle, 0x000000);
					}

					DrawStringF(x + 60, y + 246, levelText, 0xFFFFFF);
				}
				else
				{
					levelText = $"★-";
				}
			}

			// 演奏オプションボタン
			DrawGraphF(508, y, playOptionIconImage, DX_TRUE);

			// もどるボタン
			DrawGraphF(388, y, backImage, DX_TRUE);

			x = 470;

			// 難易度
			for (int i = -2; i < 4; i++)
			{
				int tempCourseIndex = i;

				if (tempCourseIndex == CourseIndexVeryHard)
				{
					tempCourseIndex = nowPage;
					x = CourseIndex0PositionX + (courseWidth + CourseMarginX) * CourseIndexVeryHard;
				}
				else if (tempCourseIndex >= 0)
				{
					x = CourseIndex0PositionX + (courseWidth + CourseMarginX) * tempCourseIndex;
				}
				else
				{
					x = 470 + 120 * (i + 1);
				}

				IEnumerable<Player> selectedPlayers;

				if (tempCourseIndex >= CourseIndexVeryHard)
				{
					selectedPlayers = players.Where((v, ind) => v.CourseIndex >= CourseIndexVeryHard);
				}
				else
				{
					selectedPlayers = players.Where((v, ind) => v.CourseIndex == tempCourseIndex);
				}

				var cnt = selectedPlayers.Count();

				int lineIndex = 0;
				int lineMax = 2;
				int lineMax2 = 2;
				int lineCnt = 0;
				float startX = 0;

				if (cnt < lineMax)
				{
					lineMax2 = lineMax - cnt;
				}
				else
				{
					lineMax2 = lineMax;
				}

				startX = (3 - lineMax2) * courseWidth / 4;

				foreach (var item in selectedPlayers.Select((v, ind) => (v, ind)))
				{
					if (lineIndex == lineMax)
					{
						lineIndex = 0;
						lineMax++;
						lineCnt++;
						if (cnt < item.ind + lineMax)
						{
							lineMax2 = cnt - item.ind;
						}
						else
						{
							lineMax2 = lineMax;
						}
						startX = (3 - lineMax2) * courseWidth / 4;
					}

					players[item.v.Number - 1].Cursor.Draw(x + startX + (courseWidth / 2 * lineIndex), 380 - lineCnt * 60);

					lineIndex++;
				}

			}
		}



		void DrawPlayerOption(int playerIndex)
        {
			var player = players[playerIndex];
			int x = 40;
			int y = 656;
			if(playerIndex == 1)
            {
				x = 1520;
            }
			player.PlayOptionRenderer.Draw(x, y);

        }

		void DrawCourse()
		{
			//if (status != 1) return;
			if (!(nowSelectItem is MusicalScoreSelectItem tja)) return;

			using (var d = DrawBlendModeGuard.Create())
			{
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, centerRenderer.CourseAlpha);

				int width = 176;
				int height = 86;

				float x = Supervision.ScreenWidthHalf - 3.5F - width - 7 - width;
				float y = Supervision.ScreenHeightHalf + 32;

				const int marginX = 7;

				string[] courseNames = new string[]
				{
					"かんたん",
					"ふつう",
					"むずかしい",
					"おに",
					"おに",
				};

				int courseNameWidth = width / 2;

				using (DrawBlendModeGuard.Create())
				using (DrawModeGuard.Create())
				{
					SetDrawBlendMode(DX_BLENDMODE_ALPHA, centerRenderer.ContentAlpha);
					SetDrawMode(DX_DRAWMODE_BILINEAR);

					if (centerRenderer.Height == centerRenderer.CurrentlySelectedHeight)
					{
						for (int i = 0; i < 5; i++)
						{
							string levelText;
							int index = i;

							// 表おにがある場合は描画しない
							if (i == 4
								&& tja.TJA.Courses[3].Level > 0)
							{
								continue;
							}

							if (tja.TJA.Courses[i].Level > 0)
							{
								DrawGraphF(x, y, courseFrame.Handles[i], DX_TRUE);

								levelText = $"★{tja.TJA.Courses[i].Level}";

								DrawStringFToHandle(x + (courseNameWidth / 2) - (GetDrawStringWidthToHandle(courseNames[i], Share.Singleton.SJIS.GetByteCount(courseNames[i]), courseSelectFontHandle) / 2), y + height - 32, courseNames[i], 0x000000, courseSelectFontHandle, 0xFFFFFF);
								//DrawStringF(x + 6 + courseNameWidth, y + (height / 2) - (GetFontSize() / 2), levelText, 0xFFFFFF, 0x000000);

								GetGraphSize(LevelImages[(int)tja.TJA.Courses[i].Level], out var w, out var h);
								DrawGraphF(x + 8 + w / 2, y + (height / 2) - h / 2 - 4, LevelImages[(int)tja.TJA.Courses[i].Level], 1);
							}
							else
							{
								levelText = $"★-";
							}

							if (i < 3)
							{
								x = x + width + marginX;
							}
						}

					}
				}
			}
		}

		void DrawPlayerScore()
		{
			playerScoreRenderer.Draw();
		}

		void DrawPlayerMusicalScore(int playerIndex)
		{
			players[playerIndex].PlayerMusicalScore.Draw();
		}


		public override void Start()
		{
			InitCommandMap();

			string folder = MainConfig.Singleton.GetThemePath(SongSelectFolderName);

			config = new SongSelectConfig(new SongSelectConfig.Info()
			{
				Json = HjsonEx.HjsonEx.LoadEx(Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"SongSelect\SongSelectConfig.hjson")),
				DrawActionMap = CreateDrawActionMap(),
				UpdateActionMap = CreateUpdateActionMap(),
			});

			drawActList = config.DrawActList;
			updateActList = config.UpdateActList;


			background = new Background(folder, config.BackgroundList?.FirstOrDefault());

			players = new Player[Share.Singleton.PlayerNum];

			keyConfigValue = config.KeyConfigList.FirstOrDefault();

			courseFrame = new CourseFrame(MainConfig.Singleton.ThemeFolderPath);

			tjaCtrl = Share.Singleton.SongSelectItemControl;

			InitSelectItem(config.SelectItemList.FirstOrDefault());

			courseSelectFrameControl = new CourseSelectFrameControl();

			parrot = new APNGImage("Resources/Theme/v1/Chara/Pink/pink-parrot.png");

			var taikoElem = new XElement("Taiko");
			taikoElem.Add(new XAttribute("PointX", 180));
			taikoElem.Add(new XAttribute("PointY", 200));
			taiko = new Tatelier.Play.TaikoImageControl(Path.Combine(MainConfig.Singleton.ThemeFolderPath, "Play"), taikoElem);

			selectItemFontHandle = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 56, -1, DX_FONTTYPE_ANTIALIASING_EDGE_4X4, -1, 3, 0);
			courseSelectFontHandle = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 20, -1, DX_FONTTYPE_ANTIALIASING_EDGE_4X4, -1, 2, 0);

			SetFontSpaceToHandle(-4, courseSelectFontHandle);
			SetFontSpaceToHandle(-6, selectItemFontHandle);

			playerScoreRenderer = new PlayerScoreRenderer(folder, null);
			playerScoreRenderer.PlayerScore = Share.Singleton.PlayerScore;

			Share.Singleton.PlayerScore.LoadAllSaveData(MainConfig.Singleton.PlayerInfoList[0].Name);

			playerMusicalScore = new PlayerMusicalScore(folder, null, tjaCtrl);

			backImage = ImageLoadControl.Singleton.Load(Path.Combine(folder, @"Back.png"));
			playOptionIconImage = ImageLoadControl.Singleton.Load(Path.Combine(folder, @"PlayOption.png"));

			SoundEffect = new SoundEffect(folder, config.SoundEffectList.FirstOrDefault());


			nowSelectItem = (Share.Singleton.SelectInfo?.TJASelectItem) ?? (tjaCtrl.SelectItemList.Count > 0 ? tjaCtrl.SelectItemList[0] : null);

			playerMusicalScore.SelectItem = nowSelectItem;

			InitDemo();
			RefreshDemo();

			var info = new LoadImageHandleInfo()
			{
				DefaultBackgroundImageHandle = -1,
				ThemeCurrentDirectory = MainConfig.Singleton.ThemeFolderPath,
			};

			info.Title.FontName = MainConfig.Singleton.DefaultFont;
			info.Title.FontSize = 40;

			SetPlayers(keyConfigValue, Share.Singleton.PlayerNum);

			tjaCtrl.SetThemeData(info);
			if (!tjaCtrl.HasScore)
			{
				emptySelectItem = SelectItemControl.CreateOtherGenreSelectItem(MainConfig.Singleton.ScoreFolderPath);
				emptySelectItem.SetThemeData(info);
				background.ChangeImage(emptySelectItem.BackgroundImageHandle, false);

				MyMessageBox.Singleton.Open(new MyMessageBoxInfo
				{
					Text = $"譜面がありません。\n\n譜面ファイルを\n{tjaCtrl.ScoreRootFolder}\n\nに置いてください。",
					MessageType = MessageType.Info,
					MyMessageBoxItems = new MyMessageBoxItemInfo[]
					{
						new MyMessageBoxItemInfo()
						{
							Name = "OK",
						},
						new MyMessageBoxItemInfo()
						{
							Name = "譜面ルートフォルダを開く",
							DoDialogClose = false,
							Callback = () =>
							{
								if (!Directory.Exists(tjaCtrl.ScoreRootFolder))
								{
									Directory.CreateDirectory(tjaCtrl.ScoreRootFolder);
								}
								Process.Start(tjaCtrl.ScoreRootFolder);
							}
						}
					}
				});
			}
			else
			{
				background.ChangeImage(nowSelectItem.BackgroundImageHandle, false);
				InitLevelImage();


				ModuleControl.Singleton.DiscordState = $"選曲中";

			}

			status = Status.SongSelect;

			Regist(1.0F);

			Demo.Enabled = MainConfig.Singleton.Demo;

			LoadSaveData();

			GC.Collect();
		}

		public override void Update()
		{
			coroutineControl.Update();

			foreach (var (PlayerNumbrt, Act) in updateActList)
			{
				Act(PlayerNumbrt);
			}

			#region デバッグ出力
			{
				const int LevelStart = 5;
				DebugWindow.Clear();

				DebugWindow.LeftText[0] = $"Title: \"{nowSelectItem?.Title ?? "null"}\"";
				DebugWindow.LeftText[1] = $"Parent: \"{nowSelectItem?.Parent?.Title ?? "root"}\"";

				switch (nowSelectItem)
				{
					case MusicalScoreSelectItem tja:
						{
							DebugWindow.LeftText[2] = $"Kana: \"{tja?.TJA.Kana ?? "null"}\"";
							DebugWindow.LeftText[3] = $"Path: \"{tja.RelativeFilePath}\"";
							DebugWindow.LeftText[4] = $"Lyric: {(File.Exists(tjaCtrl.GetLyricFilePath(tja)) ? "Exist" : "Not exist")}";
							int i = 0;

							for (i = 0; i < 5; i++)
							{
								DebugWindow.LeftText[LevelStart + i] = "";
							}

							i = 0;

							foreach (var item in tja.TJA.Courses)
							{
								DebugWindow.LeftText[LevelStart + i] = $"- {item.OriginalName}: {item.Level}{(item.HasBranch ? " 分岐あり" : "")}{(item.HasHBSCROLL ? " (HBSCROLL)" : "")}{(status == Status.CourseSelect && players[0].CourseIndex == i ? " <-" : "")}";
								i++;
							}

							DebugWindow.RightText[0] = $"ID: {tja.TJA.Id}";

							i = 1;

							if (tja.TJA.SaveDataList != null)
							{
								foreach (var item in tja.TJA.SaveDataList)
								{
									DebugWindow.RightText[i] = $"MD5:{item.MD5}";
									i++;
								}
							}
						}
						break;
					case GenreSelectItem genre:
						DebugWindow.LeftText[2] = $"Item Count: {genre.SelectItems?.Count}";
						break;
					default:
						{
							for (int i = 0; i < 6; i++)
							{
								DebugWindow.LeftText[2 + i] = "";
							}
						}
						break;
				}

			}
			#endregion

			var input = players.First()?.Input;

			switch (status)
			{
				case Status.SongSelect:
					UpdateItemSelect();
					break;
				case Status.CourseSelect:
					UpdateCourseSelect();
					break;
			}

			centerRenderer.Update();
			foreach (var prev in prevRendererList) prev.Update();
			foreach (var next in nextRendererList) next.Update();

			if (input.GetKeyDown(KEY_INPUT_F5))
			{
				SceneControl.Singleton.Destroy(this);
				SceneControl.Singleton.Create(out SongSelect s, ArgsScoreReload);
			}

			UpdatePlayerMusicalScore();
			Demo.Update();

			parrot.BPM = 120;
			parrot.Update();
		}

		public override void Draw()
		{
			foreach (var (PlayerNumbrt, Act) in drawActList)
			{
				Act(PlayerNumbrt);
			}
			fixedImageEnumerator = GetFixedImageEnumerator();

			DrawCourse();
			DrawCourseSelect();
			parrot.Draw(60, 780);
			parrot.Draw(1920 - 300, 780);
			DrawPlayerScore();
			using (DrawBlendModeGuard.Create())
			{
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, 192);
				DrawRoundRectAA(-60, 50, 360, 320, 40, 40, 20, 0xFFFFFF, DX_TRUE);
			}
			taiko.Draw(Supervision.NowMilliSec);
			for (int i = 0; i < players.Length; i++)
			{
				DrawPlayerMusicalScore(i);
				DrawPlayerOption(i);
			}
		}

		public override void Finish()
		{
			DeleteFontToHandle(selectItemFontHandle);
			DeleteFontToHandle(courseSelectFontHandle);

			ImageLoadControl.Singleton.Delete(backImage);

			if (LevelImages != null)
			{
				foreach (var item in LevelImages)
				{
					ImageLoadControl.Singleton.Delete(item.Value);
				}
			}
			using (Demo) { }
			using (parrot) { }
		}

		public SongSelect() : base() { }

		public SongSelect(string name) : base(name) { }
	}
}
