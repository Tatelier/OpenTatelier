using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.DxLibDLL;
using Tatelier.Interface;
using static DxLibDLL.DX;

namespace Tatelier
{
	class DebugWindow : IDebugWindow
	{
		public Dictionary<int, string> LeftText { get; } = new Dictionary<int, string>();
		public Dictionary<int, string> RightText { get; } = new Dictionary<int, string>();

		const int ItemHeight = 28;

		int handle;
		int padding = 4;

		public void Start()
		{
			handle = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 28, 0, DX_FONTTYPE_ANTIALIASING_4X4, 0);
		}

		public void Update()
		{
			//if (Input.Singleton.GetKeyDown(KEY_INPUT_F3))
			//{
			//	Active = !Active;
			//}
		}

		public void Clear()
		{
			LeftText.Clear();
			RightText.Clear();
		}

		public void Draw()
		{
			if (SceneControl.Singleton.DebugActive)
			{
				using (DrawBlendModeGuard.Create())
				{
					foreach (var item in LeftText)
					{
						if (item.Value.Length > 0)
						{
							int w = GetDrawStringWidthToHandle(item.Value, Share.Singleton.SJIS.GetByteCount(item.Value), handle);

							SetDrawBlendMode(DX_BLENDMODE_ALPHA, 191);
							DrawBox(0, (ItemHeight + 2 * padding) * item.Key,	w + 2 * padding, (ItemHeight + 2 * padding) * (item.Key + 1), 0x000000, DX_TRUE);

							SetDrawBlendMode(DX_BLENDMODE_NOBLEND, 0);
							DrawStringToHandle(padding, (ItemHeight + 2 * padding) * item.Key + padding, item.Value, 0xFFFFFF, handle);
						}
					}
					foreach (var item in RightText)
					{
						if (item.Value.Length > 0)
						{
							int w = GetDrawStringWidthToHandle(item.Value, Share.Singleton.SJIS.GetByteCount(item.Value), handle);

							SetDrawBlendMode(DX_BLENDMODE_ALPHA, 191);
							DrawBox(Supervision.ScreenWidth, (ItemHeight + 2 * padding) * item.Key, Supervision.ScreenWidth - (w + 2 * padding), (ItemHeight + 2 * padding) * (item.Key + 1), 0x000000, DX_TRUE);

							SetDrawBlendMode(DX_BLENDMODE_NOBLEND, 0);
							DrawStringToHandle(Supervision.ScreenWidth - w - padding, (ItemHeight + 2 * padding) * item.Key + padding, item.Value, 0xFFFFFF, handle);
						}
					}
				}
			}
		}

		public void Finish()
		{
			DeleteFontToHandle(handle);
		}

	}
}
