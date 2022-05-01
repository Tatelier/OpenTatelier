using static DxLibDLL.DX;

namespace Tatelier
{

	partial class Control
	{
		public abstract class ControlItem
		{
			public float X { get; set; } = 100;
			public float Y { get; set; } = 50;

			public int Width { get; set; } = 50;
			public int Height { get; set; } = 50;

			public bool IsHover { get; protected set; }


			bool MouseHover()
			{
				var mouseX = Mouse.Singleton.X;
				var mouseY = Mouse.Singleton.Y;

				return (X <= mouseX && mouseX <= X + Width) && (Y <= mouseY && mouseY <= Y + Height);
			}

			public virtual void Update()
			{
				IsHover = MouseHover();
			}

			public abstract void Draw();
		}
		public class Button : ControlItem
		{
			const uint BackgroundColor = 0xffd700;
			const uint ForegroundColor = 0xcc7700;

			uint backgroundColor = BackgroundColor;
			uint foregroundColor = ForegroundColor;

			public int BorderRadius = 25;

			int ForeMargin = 6;

			float ForeX = 0;

			public string Text = "Button";

			public override void Update()
			{
				base.Update();
			}

			public override void Draw()
			{
				DrawRoundRectAA(X, Y, X + Width, Y + Height, BorderRadius, BorderRadius, BorderRadius, backgroundColor, DX_TRUE);
			}

			public Button()
			{
				Width = 100;
				Height = 50;
			}
		}
	}
}
