using HjsonEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tatelier.DxLibDLL;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
	class BalloonNumberImageControl
	{
		bool disposed = false;

		float xf = 430;
		float yf = 150;

		float exRateY = 1.0F;

		int chipWidth = 60;
		int chipHeight = 80;

		int fontHandle = -1;

		bool nowBalloon = false;

		int fadeStartCount = 0;

		public int Count { get; set; }

		public int Number { get; set; }

		public bool NowBalloon
		{
			get => nowBalloon;
			set
			{
				if (nowBalloon != value)
				{
					if (value)
					{
						Number = 0;
					}
				}
				nowBalloon = value;
			}
		}

		public void Draw()
		{
			if (nowBalloon && 0 != Number)
			{
				// 桁数取得
				string strNumber = $"{Count - Number}";

				using (DrawModeGuard.Create())
				{
					SetDrawMode(DX_DRAWMODE_BILINEAR);

					//DrawRectRotaGraphFast3F(xf - ((strNumber.Length * chipWidth) / 2) + (i * chipWidth), yf - chipHeight * (exRateY - 1F), chipWidth * (strCombo[i] - 0x30), 0, chipWidth, chipHeight, 0, 0, 1, exRateY, 0, handle, TRUE);

					for (int i = 0; i < strNumber.Length; i++)
					{
						DrawStringFToHandle(xf - ((strNumber.Length * chipWidth) / 2) + (i * chipWidth), yf - chipHeight * (exRateY - 1F), $"{strNumber[i]}", 0xFFFF77, fontHandle);
					}
				}
			}
		}


		public void Dispose()
		{
			Dispose(true);
		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					DeleteFontToHandle(fontHandle);
				}
				disposed = true;
			}
		}

		~BalloonNumberImageControl()
		{
			Dispose();
		}

		public BalloonNumberImageControl(string folderPath, Hjson.JsonValue json)
		{
			if (json == null)
			{
				json = new Hjson.JsonObject();
			}
			fontHandle = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 80, 0, DX_FONTTYPE_ANTIALIASING_EDGE_4X4, 0, 3, 0);


			xf = json.EQf("X") ?? xf;
			yf = json.EQf("Y") ?? yf;
		}
	}
}
