using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tatelier.DxLibDLL;
using Tatelier.Score;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
    /// <summary>
    /// 音符フィールド管理クラス
    /// </summary>
    class NoteFieldControl
		: IJudgeFramePoint
	{
		bool disposed = false;

		public float Width { get; set; } = 1422;

		public float Top { get; set; } = 288;

		public float Left { get; set; } = 498;

		float height = 196;

		public float Height
		{
			get => height;
			set
			{
				height = value;
				HeightHalf = value / 2;
			}
		}

		public float HeightHalf { get; private set; } = 98;

        float IJudgeFramePoint.CX => JudgeFramePointCX;

        float IJudgeFramePoint.CY => JudgeFramePointCY;

        public float JudgeFramePointCX;

		public float JudgeFramePointCY;



		bool hasBranch = false;

		Image3 commonField;
		Image3 normalField;
		Image3 expertField;
		Image3 masterField;

		Image3 gogoField;
		Image3 donEffect;
		Image3 katEffect;

		/// <summary>
		/// 分岐種別
		/// </summary>
		public BranchType BranchType = BranchType.Common;

		/// <summary>
		/// ゴーゴー状態
		/// true: ゴーゴー中, false: 未ゴーゴー
		/// </summary>
		public bool Gogo = false;

		int donStartTime = int.MaxValue;
		int katStartTime = int.MaxValue;

		bool Don = true;
		bool Kat = true;

		public void Reset()
		{
			donStartTime = int.MaxValue;
			katStartTime = int.MaxValue;
		}

		public void Update(bool don, bool kat, bool ok, int time)
		{
			Don = don;
			if (don)
			{
				donStartTime = time;
			}
			Kat = kat;
			if (kat)
			{
				katStartTime = time;
			}
		}

		public void DrawField()
		{
			commonField.Draw();
		}

		public void DrawGogoField()
		{
			if (Gogo)
			{
				gogoField.Draw();
			}
		}

		public void DrawBranchField()
		{
			if (hasBranch)
			{
				switch (BranchType)
				{
					case BranchType.Common:
					case BranchType.Normal:
						normalField.Draw();
						break;
					case BranchType.Expert:
						expertField.Draw();
						break;
					case BranchType.Master:
						masterField.Draw();
						break;
				}
			}
		}

		public void DrawEffect(int time)
		{
			if (donStartTime == int.MaxValue
				&& katStartTime == int.MaxValue)
			{
				return;
			}


			if (time - donStartTime < 150)
			{
				using (DrawBlendModeGuard.Create())
				{
					SetDrawBlendMode(DX_BLENDMODE_ALPHA, (int)(255 - ((time - donStartTime) / 150.0F) * 255));
					donEffect.Draw();
				}
			}
			if (time - katStartTime < 150)
			{
				using (DrawBlendModeGuard.Create())
				{
					SetDrawBlendMode(DX_BLENDMODE_ALPHA, (int)(255 - ((time - katStartTime) / 150.0F) * 255));
					katEffect.Draw();
				}
			}
		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					if (hasBranch)
					{
						// unmanaged
						using (commonField) { }
						using (normalField) { }
						using (expertField) { }
						using (masterField) { }
					}
					else
					{
						using (commonField) { }
					}
					using (donEffect) { }
					using (katEffect) { }
					using (gogoField) { }
				}
				// managed
				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}
		~NoteFieldControl()
		{
			Dispose();
		}
		public NoteFieldControl(string folderPath, bool hasBranch, Hjson.JsonValue json)
		{
			folderPath = Path.Combine(folderPath, json.EQs("FolderPath") ?? "NoteField");
			int x = json.EQi("PointX") ?? 498;
			int y = json.EQi("PointY") ?? 288;

			JudgeFramePointCX = (json.EQi("JudgeRelativePointCX") ?? 0) + x;
			JudgeFramePointCY = (json.EQi("JudgeRelativePointCY") ?? 0) + y;

			Left = x;
			Top = y;

			Height = json.EQi("Height") ?? 196;
			Width = json.EQi("Width") ?? 1422;


			this.hasBranch = hasBranch;
			commonField = new Image3(Path.Combine(folderPath, "Frame.png"));
			commonField.Transform.Point = (x, y);

			if (hasBranch)
			{
				normalField = new Image3(Path.Combine(folderPath, "NormalFrame.png"));
				normalField.Transform.Point = (x, y);
				expertField = new Image3(Path.Combine(folderPath, "ExpertFrame.png"));
				expertField.Transform.Point = (x, y);
				masterField = new Image3(Path.Combine(folderPath, "MasterFrame.png"));
				masterField.Transform.Point = (x, y);
			}
			donEffect = new Image3(Path.Combine(folderPath, "DonEffect.png"));
			donEffect.Transform.Point = (x, y);
			katEffect = new Image3(Path.Combine(folderPath, "KatEffect.png"));
			katEffect.Transform.Point = (x, y);
			gogoField = new Image3(Path.Combine(folderPath, "GogoEffect.png"));
			gogoField.Transform.Point = (x, y);
		}

		[Obsolete("HJSON形式を使ってください")]
		public NoteFieldControl(string folderPath, bool hasBranch, XElement elem)
		{
			int x = (int?)elem.Attribute("PointX") ?? 498;
			int y = (int?)elem.Attribute("PointY") ?? 288;

			Left = x;
			Top = y;

			this.hasBranch = hasBranch;
			commonField = new Image3(Path.Combine(folderPath, "Frame.png"));
			commonField.Transform.Point = (x, y);

			if (hasBranch)
			{
				normalField = new Image3(Path.Combine(folderPath, "NormalFrame.png"));
				normalField.Transform.Point = (x, y);
				expertField = new Image3(Path.Combine(folderPath, "ExpertFrame.png"));
				expertField.Transform.Point = (x, y);
				masterField = new Image3(Path.Combine(folderPath, "MasterFrame.png"));
				masterField.Transform.Point = (x, y);
			}
			donEffect = new Image3(Path.Combine(folderPath, "DonEffect.png"));
			donEffect.Transform.Point = (x, y);
			katEffect = new Image3(Path.Combine(folderPath, "KatEffect.png"));
			katEffect.Transform.Point = (x, y);
			gogoField = new Image3(Path.Combine(folderPath, "GogoEffect.png"));
			gogoField.Transform.Point = (x, y);
		}

		public NoteFieldControl(string folderPath, bool hasBranch = false)
		{
			this.hasBranch = hasBranch;
			commonField = new Image3(Path.Combine(folderPath, "Frame.png"));
			commonField.Transform.Point = (498, 288);

			if (hasBranch)
			{
				normalField = new Image3(Path.Combine(folderPath, "NormalFrame.png"));
				normalField.Transform.Point = commonField.Transform.Point;
				expertField = new Image3(Path.Combine(folderPath, "ExpertFrame.png"));
				expertField.Transform.Point = commonField.Transform.Point;
				masterField = new Image3(Path.Combine(folderPath, "MasterFrame.png"));
				masterField.Transform.Point = commonField.Transform.Point;
			}
			donEffect = new Image3(Path.Combine(folderPath, "DonEffect.png"));
			donEffect.Transform.Point = commonField.Transform.Point;
			katEffect = new Image3(Path.Combine(folderPath, "KatEffect.png"));
			katEffect.Transform.Point = commonField.Transform.Point;

			gogoField = new Image3(Path.Combine(folderPath, "GogoEffect.png"));
			gogoField.Transform.Point = commonField.Transform.Point;
		}
	}
}
