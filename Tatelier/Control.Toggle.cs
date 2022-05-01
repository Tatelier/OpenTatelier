using System;
using static DxLibDLL.DX;

namespace Tatelier
{
	partial class Control
	{
		public class Toggle : ControlItem
		{
			private const int WM_SETCURSOR = 0x0020;

			public bool State { get; set; } = false;

			public event Action Hovered;

			public event Action Clicked = () => { };

			public int BorderRadius = 25;

			int ForeMargin = 6;

			float ForeX = 0;

			const uint OffBackgroundColor = 0xDDDDDD;
			const uint OffForegroundColor = 0x888888;

			const uint OnBackgroundColor = 0xffd700;
			const uint OnForegroundColor = 0xcc7700;

			uint backgroundColor = OffBackgroundColor;
			uint foregroundColor = OffForegroundColor;


			public override void Update()
			{
				base.Update();

				if (State)
				{
					ForeX = Width - Height;
					backgroundColor = OnBackgroundColor;
					foregroundColor = OnForegroundColor;
				}
				else
				{
					ForeX = 0;
					backgroundColor = OffBackgroundColor;
					foregroundColor = OffForegroundColor;
				}


				if (IsHover)
				{
					if (Mouse.Singleton.LeftButton == 1)
					{
						Clicked();
						State = !State;
					}
				}
			}

			int imageHandle = -1;

			public override void Draw()
			{
				if (imageHandle == -1)
				{
					DrawRoundRectAA(X, Y, X + Width, Y + Height, BorderRadius, BorderRadius, BorderRadius, backgroundColor, DX_TRUE);
					DrawRoundRectAA(X + ForeMargin + ForeX, Y + ForeMargin, X + Height - ForeMargin + ForeX, Y + Height - ForeMargin, BorderRadius, BorderRadius, BorderRadius, foregroundColor, DX_TRUE);
				}
				else
				{
					GetGraphSize(imageHandle, out var w, out var h);
					DrawRectGraphF(X, Y, (w / 2) * (State ? 1 : 0), 0, w / 2, h, imageHandle, DX_TRUE);
				}
			}

			public Toggle()
			{

			}

			public Toggle(string imageFilePath)
			{
				imageHandle = ImageLoadControl.Singleton.Load(imageFilePath);
				GetGraphSize(imageHandle, out var w, out var h);
				Width = w;
				Height = h;
			}
		}
	}
}
