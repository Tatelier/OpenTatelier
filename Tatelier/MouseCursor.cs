using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier
{
    internal class MouseCursor
	{
		[DllImport("user32.dll")]
		private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

		[DllImport("user32.dll")]
		static extern IntPtr SetClassLong(IntPtr hInstance, int p, IntPtr hCursor);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SetCursor(IntPtr hCursor);

		private const int IDC_HAND = 32649;
		const int IDC_ARROW = 32512;

		public IntPtr Hand = LoadCursor(IntPtr.Zero, IDC_HAND);
		public IntPtr Arrow = LoadCursor(IntPtr.Zero, IDC_ARROW);

		IntPtr Current { get; set; }

		public void Update()
		{
			SetClassLong(GetMainWindowHandle(), -12, Current);
			SetCursor(Current);
		}

		public MouseCursor()
        {
			Current = Arrow;
        }
	}
}
