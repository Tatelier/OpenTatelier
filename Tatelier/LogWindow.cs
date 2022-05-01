using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tatelier.DxLibDLL;
using Tatelier.Interface;
using static DxLibDLL.DX;

namespace Tatelier
{
	[DebuggerDisplay("{Text}:{HideTime}")]
	struct LogItem
	{
		public string Text { get; set; }

		public int HideTime { get; set; }

		public uint TextColor { get; set; }
	}
	class LogWindow : ILogWindow
	{
		const int ItemHeight = 32;

		public const uint WarningColor = 0xFFD700;
		public const uint UpdateNoticeColor = 0xAADDAA;
		public const uint ErrorColor = 0xF39189;

		public static LogWindow Singleton { get; private set; } = new LogWindow();

		public bool Active = true;
		public bool NowInput = false;

		LogItem[] A;

		int NowIndex = 0;

		int font;

		LogWindow()
		{
			A = Enumerable.Repeat(new LogItem()
			{
				Text = "",
				HideTime = 0,
			}, 64).ToArray();
		}

		public void Start()
		{
			font = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 28, 0, DX_FONTTYPE_ANTIALIASING_4X4);

			for (int i = 0; i < A.Length; i++)
			{
				if (A[i].HideTime != 0)
				{
					A[i].HideTime = Supervision.NowMilliSec + 10000;
				}
			}
		}

		public void Update()
		{
			if (!Active) return;
		}

		public void InsertSystemMessage(string text)
		{
			Insert(text, 0xFFFFCC);
		}

		public void Insert(string text, uint color = 0xFFFFFF)
		{
			lock (A)
			{
				NowIndex = (NowIndex + (A.Length - 1)) % A.Length;
				A[NowIndex] = new LogItem()
				{
					Text = text,
					HideTime = Supervision.NowMilliSec + 10000,
					TextColor = color,
				};
			}
		}

		public void Draw()
		{
			if (!Active) return;

			using (DrawModeGuard.Create())
			{
				using (DrawBlendModeGuard.Create())
				{
					SetDrawMode(DX_DRAWMODE_BILINEAR);
					for (int i = 0; i < 16; i++)
					{
						int b = (i + NowIndex) % A.Length;

						double a = NowInput ? 1 : (A[b].HideTime - Supervision.NowMilliSec) * 0.001;
						if (a > 1)
						{
							a = 1;
						}
						if (A[b].Text.Length > 0)
						{
							SetDrawBlendMode(DX_BLENDMODE_ALPHA, (int)(191 * a));
							int w = GetDrawStringWidthToHandle(A[b].Text, Share.Singleton.SJIS.GetByteCount(A[b].Text), font);
							DrawBox(0, 1000 - (i * ItemHeight), w + 8, 1000 - ((i + 1) * ItemHeight), GetColor(0, 0, 0), DX_TRUE);
							SetDrawBlendMode(DX_BLENDMODE_ALPHA, (int)(255 * a));
							DrawStringFToHandle(4, 1004 - ((i + 1) * ItemHeight), A[b].Text, A[b].TextColor, font, DX_TRUE);
						}
					}
				}
			}
		}

		public void Reset()
		{
			DeleteFontToHandle(font);

			Singleton = new LogWindow();
		}

		void ILogWindow.AddLast(string message, uint color)
		{
			Insert(message, color);
		}
	}
}
