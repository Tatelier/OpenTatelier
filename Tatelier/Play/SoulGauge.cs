using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static DxLibDLL.DX;
using HjsonEx;
using Tatelier.Score;

namespace Tatelier.Play
{
    class SoulGauge
		: IDisposable
	{
		public class Info
		{
			public double GoodPer = 0.5;

			public double BadPer = -2;

			public int NoteNum = 999;

			public double NormaBorder = 59.465;

			public double SoulBorder = 74.276;

			public string ImageFilePath = "";

			public int X = 730;

			public int Y = 216;
		}

		bool disposed = false;

		int handle = -1;

		/// <summary>
		/// 最大10000点？
		/// </summary>
		public int Max = 10000;

		public int Norma = 8000;

		public int Now = 0;

		Info info;

		int OneNotePoint = 10;

		JudgeType judgeType;

		public bool IsNormaClear => Norma <= Now && Now <= Max;

		public bool IsSoul => Now == Max;
		
		public StatusType NowStatus
		{
			get
			{
				switch (judgeType)
				{
					case JudgeType.Great:
					case JudgeType.Good:
					default:
						return Now < Norma ? StatusType.Normal : StatusType.Clear;
					case JudgeType.Bad:
						return StatusType.Failure;
				}
			}
		}

		/// <summary>
		/// 判定を引数で受け取って魂ゲージの加減算を行う
		/// </summary>
		/// <returns>true:ボーダーに変化があった</returns>
		public bool Add(JudgeType judgeType)
		{
			int prev = Now;
			switch (judgeType)
			{
				case JudgeType.Great:
					Now += OneNotePoint;
					break;
				case JudgeType.Good:
					Now += (int)(OneNotePoint * info.GoodPer);
					break;
				case JudgeType.Bad:
					Now += (int)(OneNotePoint * info.BadPer);
					break;
			}

			// 最大最小を処理
			if (Now < 0)
			{
				Now = 0;
			}
			else if (Now > Max)
			{
				Now = Max;
			}

			bool isChange = (prev < Norma && Now >= Norma) || (prev >= Norma && Now < Norma);

			return isChange;
		}


		float xf;
		float yf;

		public void Draw()
		{
			GetGraphSize(handle, out int w, out int h);

			if (Now < Max)
			{
				DrawRectGraphF(xf, yf, 0, 0, w, h / 3, handle, DX_TRUE);
				DrawRectGraphF(xf, yf, 0, h / 3, (int)(((double)w / 50) * (Now / 200)), h / 3, handle, DX_TRUE);
			}
			else
			{
				DrawRectGraphF(xf, yf, 0, 2 * h / 3, w, h / 3, handle, DX_TRUE);
			}
		}

		public SoulGauge(string folder, string relativeFilePath, float xf, float yf)
		{
			handle = ImageLoadControl.Singleton.Load(Path.Combine(folder, relativeFilePath));

			this.xf = xf;
			this.yf = yf;
		}

		public SoulGauge(string folder, Hjson.JsonValue json, SoulGauge.Info info)
		{
			this.info = info;

			OneNotePoint = (int)((double)Max / (info.NoteNum * info.SoulBorder / 100));

			handle = ImageLoadControl.Singleton.Load(Path.Combine(folder, json.EQs("FolderPath") ?? "", "SoulGauge.png"));

			xf = json.EQf("PointX") ?? xf;
			yf = json.EQf("PointY") ?? yf;
		}

		public void Reset()
		{

		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					ImageLoadControl.Singleton.Delete(handle);
				}

				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~SoulGauge()
		{
			Dispose();
		}
	}
}
