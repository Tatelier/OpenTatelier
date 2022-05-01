using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.DxLibDLL
{
	#region DrawAreaGuard
	public struct DrawAreaGuard : IDisposable
	{
		public static DrawAreaGuard Create()
			=> new DrawAreaGuard(null);

		public readonly RECT RECT;

		DrawAreaGuard(object obj)
		{
			GetDrawArea(out RECT);
		}

		public void Dispose()
		{
			SetDrawArea(RECT.left, RECT.top, RECT.right, RECT.bottom);
		}
	}
	#endregion

	#region DrawBright
	public struct DrawBrightGuard : IDisposable
	{
		public static DrawBrightGuard Create()
			=> new DrawBrightGuard(null);
		public readonly int Red;
		public readonly int Green;
		public readonly int Blue;

		DrawBrightGuard(object obj)
		{
			GetDrawBright(out Red, out Green, out Blue);
		}

		public void Dispose()
		{
			SetDrawBright(Red, Green, Blue);
		}
	}
	#endregion

	#region DrawBlendMode
	public struct DrawBlendModeGuard : IDisposable
	{
		public static DrawBlendModeGuard Create()
			=> new DrawBlendModeGuard(null);

		public readonly int BlendMode;
		public readonly int BlendParam;

		DrawBlendModeGuard(object obj)
		{
			GetDrawBlendMode(out BlendMode, out BlendParam);
		}

		public void Dispose()
		{
			SetDrawBlendMode(BlendParam, BlendParam);
		}
	}
	#endregion

	#region DrawModeGuard
	public struct DrawModeGuard : IDisposable
	{
		public static DrawModeGuard Create()
			=> new DrawModeGuard(null);

		public readonly int Mode;

		DrawModeGuard(object obj)
		{
			Mode = GetDrawMode();
		}

		public void Dispose()
		{
			SetDrawMode(Mode);
		}
	}
	#endregion

	#region DrawScreenGuard
	public struct DrawScreenGuard : IDisposable
	{
		public static DrawScreenGuard Create()
			=> new DrawScreenGuard(null);

		public readonly int Screen;

		DrawScreenGuard(object obj)
		{
			Screen = GetDrawScreen();
		}

		public void Dispose()
		{
			SetDrawScreen(Screen);
		}
	}
	#endregion
}
