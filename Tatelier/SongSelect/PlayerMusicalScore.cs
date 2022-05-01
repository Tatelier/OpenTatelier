using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.SongSelect
{
	class PlayerMusicalScore
	{
		int frame = -1;
		int fontHandle = -1;
		int fontHeaderHandle = -1;

		Task task;

		bool visible = false;
		bool scoreVisible = false;

		public ISelectItem selectItem;

		public ISelectItem SelectItem
		{
			get
			{
				return selectItem;
			}
			set
			{
				selectItem = value;
				if (!(SelectItem is MusicalScoreSelectItem mssi))
				{
					visible = false;
				}
				else
				{
					visible = true;
				}
				scoreVisible = false;
				topScore = 0;
				loading = false;
				startCount = Supervision.NowMilliSec;
			}
		}


		int topScore = 0;
		int courseId = -1;
		int startCount = Supervision.NowMilliSec;

		SelectItemControl SelectItemControl;

		MusicalScoreSaveData mssd;

		bool loading = false;
		int diff;

		float x = 20;
		float y = 600;

		public void Update()
		{
			diff = Supervision.NowMilliSec - startCount;
			if (!loading && diff >= 500)
			{
				loading = true;
				task = Task.Run(() =>
				{
					if (SelectItem != null)
					{
						var mssd = new MusicalScoreSaveData();
						if (SelectItem is MusicalScoreSelectItem mssi)
						{
							string filePath = MainConfig.Singleton.GetScoreSaveDataFilePath(MainConfig.Singleton.PlayerInfoList[0].Name, SelectItemControl.GetFilePath(mssi));
							mssd.Load(filePath);
							var course = mssd.CourseList.OrderByDescending(v => v.BestResult?.ScorePoint).FirstOrDefault();
							topScore = course?.BestResult?.ScorePoint ?? 0;
							courseId = course?.CourseID ?? -1;
							this.mssd = mssd;
							visible = true;
							scoreVisible = true;
						}
					}
					else
					{
						visible = false;
					}
				});
			}
		}

		public void Draw()
		{
			if (visible)
			{
				DrawGraphF(x, y, frame, DX_TRUE);
				if (diff >= 500)
				{
					if (scoreVisible)
					{
						string topScoreText = $"{topScore}";
						string courseText = $"";

						switch (courseId)
						{
							case 0:
								courseText = "Easy";
								break;
							case 1:
								courseText = "Normal";
								break;
							case 2:
								courseText = "Hard";
								break;
							case 3:
								courseText = "Oni";
								break;
							case 4:
								courseText = "Ura";
								break;
						}
						

						DrawStringFToHandle(x + 320 - GetDrawStringWidthToHandle(courseText, Encoding.Default.GetByteCount(courseText), fontHeaderHandle), y + 28, courseText, 0xBBBBBB, fontHeaderHandle);
						DrawStringFToHandle(x + 320 - GetDrawStringWidthToHandle(topScoreText, Encoding.Default.GetByteCount(topScoreText), fontHandle), y + 48, topScoreText, 0xFFFFFF, fontHandle);
					}
				}
				else
				{
					// TODO: 何も
				}
			}
		}

		public PlayerMusicalScore(string folder, Hjson.JsonValue json, SelectItemControl selectItemControl)
		{
			this.SelectItemControl = selectItemControl;
			frame = ImageLoadControl.Singleton.Load(Path.Combine(folder, "PlayerMusicalScoreResult\\Frame.png"));
			fontHeaderHandle = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 16, 0, DX_FONTTYPE_ANTIALIASING);
			fontHandle = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 32, 0, DX_FONTTYPE_ANTIALIASING);
		}
		~PlayerMusicalScore()
		{
			ImageLoadControl.Singleton.Delete(frame);
			DeleteFontToHandle(fontHandle);
			DeleteFontToHandle(fontHeaderHandle);
		}
	}
}
