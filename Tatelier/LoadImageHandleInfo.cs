using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class LoadImageHandleInfo
	{
		public int DefaultBackgroundImageHandle { get; set; } = -1;

		public string ThemeCurrentDirectory = "Resources/Theme/v3";



		public class TitleElem
		{
			public int Width = 800;

			public int Height = 130;

			public int FontSize = 48;

			public int FontEdgeSize = 16;

			public string FontName = "ＭＳ ゴシック";

			public uint FontColor = 0x00FFFFFF;

			public uint FontEdgeColor = 0x00000000;
		}

		public TitleElem Title { get; set; } = new TitleElem();

	}
}
