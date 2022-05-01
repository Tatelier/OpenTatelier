using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier
{
	interface IControlItem
	{
	}

	partial class Control
	{
		[DllImport("user32.dll")]
		private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

		[DllImport("user32.dll")]
		static extern IntPtr SetClassLong(IntPtr hInstance, int p, IntPtr hCursor);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SetCursor(IntPtr hCursor);

		private const int IDC_HAND = 32649;
		const int IDC_ARROW = 32512;

		IntPtr hand = LoadCursor(IntPtr.Zero, IDC_HAND);
		IntPtr arrow = LoadCursor(IntPtr.Zero, IDC_ARROW);

		List<Toggle> toggleList = new List<Toggle>();
		List<Button> buttonList = new List<Button>();

		public Toggle CreateToggle()
		{
			var toggle = new Toggle();
			toggleList.Add(toggle);
			return toggle;
		}
		public Toggle CreateToggle(string imageFilePath)
		{
			var toggle = new Toggle(imageFilePath);
			toggleList.Add(toggle);
			return toggle;
		}

		public Button CreateButton()
		{
			var button = new Button();

			buttonList.Add(button);

			return button;
		}

		public void Update()
		{
			SetClassLong(GetMainWindowHandle(), -12, arrow);
			SetCursor(arrow);

			bool changed = false;

			if (!changed)
			{
				foreach (var item in toggleList)
				{
					item.Update();
					if (item.IsHover)
					{
						SetClassLong(GetMainWindowHandle(), -12, hand);
						SetCursor(hand);
						changed = true;
						break;
					}
				}
			}

			if (!changed)
			{
				foreach (var item in buttonList)
				{
					item.Update();
					if (item.IsHover)
					{
						SetClassLong(GetMainWindowHandle(), -12, hand);
						SetCursor(hand);
						changed = true;
						break;
					}
				}
			}
		}

		public Control()
		{

		}
	}
}
