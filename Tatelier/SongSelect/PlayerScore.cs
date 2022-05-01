using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;
using Tatelier.DxLibDLL;

namespace Tatelier.SongSelect
{
	class PlayerScore
	{
		Task task;

		int startCount = 0;

		bool isNowLoading = false;
		public bool IsNowLoading
		{
			get
			{
				return isNowLoading || Supervision.NowMilliSec - startCount < 1000;
			}
			set
			{
				isNowLoading = value;
			}
		}


		public int NormaClearCount = 0;
		public int FullComboCount = 0;
		public int FullGreatCount = 0;

        public void SetSaveData(PlayerScoreClearTypeCount psctc)
		{
			NormaClearCount = psctc.Norma + psctc.Soul;
			FullComboCount = psctc.FullCombo + psctc.FullGood;
			FullGreatCount = psctc.FullGreat;
		}

		public void LoadAllSaveData(string playerName)
		{
			var result = new PlayerScoreClearTypeCount();
			IsNowLoading = true;
			startCount = Supervision.NowMilliSec;

			task = Task.Run(() =>
			{
				int normaClearCount = 0;
				int fullComboCount = 0;
				int fullGreatCount = 0;

				string folderPath = Path.GetFullPath($"Save\\{playerName}\\Score\\");

				var scoreFolder = Path.Combine(MainConfig.Singleton.ScoreFolderPath + "\\Root\\");

				var sav = new SongSelect.MusicalScoreSaveData();
				if (Directory.Exists(folderPath))
				{
					var files = Directory.EnumerateFiles(folderPath, "*.tlrsav", SearchOption.AllDirectories);

					foreach (var item in files)
					{
						var scoreFilePath = item.Replace(folderPath, scoreFolder).Replace(".tlrsav", "");

						if(!Directory.Exists(Path.GetDirectoryName(scoreFilePath)))
						{
							continue;
						}

						if (!Directory.EnumerateFiles(Path.GetDirectoryName(scoreFilePath), Path.GetFileNameWithoutExtension(scoreFilePath) +".*")
						.Where(v=> MainConfig.Singleton.IsScoreFile(v)).Any())
						{
							continue;
						}

						sav.Load(item);

						ClearType clearType;

						for (int i = 3; i <= 4; i++)
						{
							// 裏譜面のクリア情報
							clearType = sav.CourseList.Where(v => v.CourseID == i).FirstOrDefault()?.ClearType ?? ClearType.None;

							if ((clearType & ClearType.FullGreat) > 0)
							{
								fullGreatCount++;
							}
							else if ((clearType & ClearType.FullCombo) > 0)
							{
								fullComboCount++;
							}
							else if ((clearType & ClearType.NormaClear) > 0)
							{
								normaClearCount++;
							}
						}
					}
				}

				NormaClearCount = normaClearCount;
				FullComboCount = fullComboCount;
				FullGreatCount = fullGreatCount;

				IsNowLoading = false;
			});
		}
	}

	class PlayerScoreRenderer
	{
		public PlayerScore PlayerScore;

		int frame;

		float x = 20;
		float y = 360;

		int fontHandle = -1;

		public void Draw()
		{
			DrawGraphF(x, y, frame, DX_TRUE);

			if (!PlayerScore.IsNowLoading)
			{
				DrawStringFToHandle(x + 60, y + 168, $"{PlayerScore.NormaClearCount}", 0xFFFFFF, fontHandle);
				DrawStringFToHandle(x + 60 + 110, y + 168, $"{PlayerScore.FullComboCount}", 0xFFFFFF, fontHandle);
				DrawStringFToHandle(x + 60 + 220, y + 168, $"{PlayerScore.FullGreatCount}", 0xFFFFFF, fontHandle);
			}
			else
			{
				using (DrawModeGuard.Create())
				{
					SetDrawMode(DX_DRAWMODE_BILINEAR);
					string text = "Now Loading...";
					int width = GetDrawExtendStringWidth(0.5, text, Encoding.Default.GetByteCount(text));
					DrawExtendStringF(x + 180 - width / 2, y + 72, 0.5, 0.5, text, 0xFFFFFF);
				}
			}
		}

		public void Update()
		{

		}

		public PlayerScoreRenderer(string folder, Hjson.JsonValue json)
		{
			frame = ImageLoadControl.Singleton.Load(Path.Combine(folder, "PlayerScoreResult\\Frame.png"));
			fontHandle = CreateFontToHandle("UD デジタル 教科書体 N-B", 26, 0, DX_FONTTYPE_ANTIALIASING);
		}

		~PlayerScoreRenderer()
		{
			ImageLoadControl.Singleton.Delete(frame);
			DeleteFontToHandle(fontHandle);
		}
	}
}
