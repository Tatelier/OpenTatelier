using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.HtmlControl
{
	class Checkbox
	{
		public bool Checked { get; set; } = false;

		public uint BackgroundColor = 0xd7d7d7;

		public uint ForegroundColor = 0x303030;

		public float Width = 24;

		public float Height = 24;

		public string Text = "Checkbox";

		int fontHandle = -1;

		public Checkbox()
		{
			fontHandle = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 24, 0, DX_FONTTYPE_ANTIALIASING_4X4, 0, 0, 0);
		}

		public void Draw(float xf, float yf)
		{
			DrawBoxAA(xf, yf, xf + Width, yf + Height, BackgroundColor, DX_TRUE);
			DrawLineAA(xf + Width / 8, yf + 2 * Height / 3, xf + Width / 3, yf + 7 * Height / 8, 0, 3);
			DrawLineAA(xf + Width / 3, yf + 8 * Height / 9, xf + 7 * Width / 8, yf + Height / 8, 0, 3);
			DrawStringFToHandle(xf + Width + 8, yf, Text, ForegroundColor, fontHandle);
		}
	}
}
