using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tatelier.DxLibDLL;
using static DxLibDLL.DX;
using HjsonEx;
using Tatelier.Score;

namespace Tatelier.Play
{
    /// <summary>
    /// 判定画像管理クラス
    /// </summary>
    class JudgeImageControl
		: IDisposable
	{
		struct Effect
		{
			public int StartTime;
			public JudgeType JudgeType;
			public Effect(JudgeType judgeType, int startTime)
			{
				JudgeType = judgeType;
				StartTime = startTime;
			}
		}

		bool disposed = false;

		Image3 great;

		Image3 good;

		Image3 bad;

		public float X = 616;
		public float Y = 288;

		int nowIndex = 0;

		Effect[] EffectList;

		public void Reset()
		{
			for (int i = 0; i < EffectList.Length; i++)
			{
				EffectList[i] = new Effect(JudgeType.None, 0);
			}
		}

		public void Update(JudgeType judgeType, int time)
		{
			switch (judgeType)
			{
				case JudgeType.Great:
				case JudgeType.Good:
				case JudgeType.Bad:
					EffectList[nowIndex] = new Effect(judgeType, time);
					nowIndex = (nowIndex + 1) % EffectList.Length;
					break;
			}
		}

		Image3 GetImage(JudgeType judgeType)
		{
			switch (judgeType)
			{
				case JudgeType.Great:
					return great;
				case JudgeType.Good:
					return good;
				case JudgeType.Bad:
					return bad;
				case JudgeType.None:
				default:
					return null; // なしのときは次に進む
			}

		}

		public void Draw(int time)
		{
			Image3 image = null;
			foreach (var item in EffectList)
			{
				image = GetImage(item.JudgeType);

				if (image == null) continue; // ない場合は次のループへ

				float diff;

#warning 入れ子処理をどうにかする

				// 移動アニメ
				int diffTime = (time - item.StartTime);
				diff = diffTime / 200.0F;
				if (diff < 1)
				{
					image.Transform.Point = (X, Y - 20 + (20 * diff));
					image.Draw();
				}
				else
				{
					diffTime -= 200;
					diff = diffTime / (float)200;
					if (diff < 1)
					{
						image.Transform.Point = (X, Y);
						image.Draw();
					}
					else
					{
						diffTime -= 200;
						diff = diffTime / (float)200;
						if (diff < 1)
						{
							using (DrawBlendModeGuard.Create())
							{
								SetDrawBlendMode(DX_BLENDMODE_ALPHA, (int)(255 - (255 * diff)));
								image.Transform.Point = (X, Y);
								image.Draw();
							}
						}
					}
				}
			}
		}

		public void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					using (great) { }
					using (good) { }
					using (bad) { }
				}
				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}
		~JudgeImageControl()
		{
			Dispose();
		}
		public JudgeImageControl(string folder, Hjson.JsonValue json)
		{
			folder = Path.Combine(folder, json.EQs("FolderPath") ?? "");

			great = new Image3(Path.Combine(folder, "Great.png"));
			great.PivotType = Pivot.Center;
			good = new Image3(Path.Combine(folder, "Good.png"));
			good.PivotType = Pivot.Center;
			bad = new Image3(Path.Combine(folder, "Bad.png"));
			bad.PivotType = Pivot.Center;

			X = json.EQf("PointX") ?? X;
			Y = json.EQf("PointY") ?? Y;

			EffectList = Enumerable.Repeat(new Effect(JudgeType.None, 0), 1).ToArray();
		}

		[Obsolete("HSJON形式を使ってください")]
		public JudgeImageControl(string folder, XElement elem)
		{
			folder = Path.Combine(folder, (string)elem.Attribute("FolderPath") ?? "");

			great = new Image3(Path.Combine(folder, "Great.png"));
			great.PivotType = Pivot.Center;
			good = new Image3(Path.Combine(folder, "Good.png"));
			good.PivotType = Pivot.Center;
			bad = new Image3(Path.Combine(folder, "Bad.png"));
			bad.PivotType = Pivot.Center;

			X = (float?)elem.Attribute("PointX") ?? X;
			Y = (float?)elem.Attribute("PointY") ?? Y;

			EffectList = Enumerable.Repeat(new Effect(JudgeType.None, 0), 1).ToArray();
		}
	}
}
