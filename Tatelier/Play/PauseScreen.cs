using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;
using Tatelier.DxLibDLL;
using System.IO;

namespace Tatelier.Play
{
	enum PauseScreenItemIndex
	{
		Cancel = 0,
		Restart,
		ToEditMode,
		ToSongSelect,
	}

	class PauseScreen
	{
		int frameHandle = -1;
		int menuHandle = -1;

		int alpha = 191;

		int size = 4;

		public bool Enabled { get; internal set; }

		public bool Visible { get; internal set; }

		/// <summary>
		/// 決定したかどうか
		/// </summary>
		public bool IsCollect { get; set; }

		/// <summary>
		/// 演奏画面に復帰して大丈夫かどうか
		/// </summary>
		public bool IsToReturnPlayOK => Supervision.NowMilliSec > pauseToPlayReturnEndTime;

		int pauseToPlayReturnEndTime;

		public void RefreshToReturnPlay()
		{
			pauseToPlayReturnEndTime = Supervision.NowMilliSec + ThemeConfig.Singleton.ReturnWaitTime;
		}

		/// <summary>
		/// 選択している要素の番号
		/// </summary>
		public PauseScreenItemIndex MenuIndex { get; set; } = PauseScreenItemIndex.Cancel;

		public void Next()
		{
			MenuIndex = (PauseScreenItemIndex)(((int)MenuIndex + 1) % size);
		}

		public void Prev()
		{
			MenuIndex = (PauseScreenItemIndex)(((int)MenuIndex + (size - 1)) % size);
		}

		public void Update()
		{

		}

		public void Reset()
		{
			IsCollect = false;
			MenuIndex = PauseScreenItemIndex.Cancel;
		}

		public void Draw()
		{
			if (!Visible) return;

			// 背景
			using (DrawBlendModeGuard.Create())
			{
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, alpha);
				DrawBox(0, 0, 1920, 1080, 0, DX_TRUE);
			}
			DrawRotaGraph(Supervision.ScreenWidthHalf, Supervision.ScreenHeightHalf, 1.0, 0.0, frameHandle, DX_TRUE);
			DrawRotaGraph(Supervision.ScreenWidthHalf, Supervision.ScreenHeightHalf, 1.0, 0.0, menuHandle, DX_TRUE);
			DrawStringToHandle(204, 188 + (int)MenuIndex * 108, "→", 0xDDDDDD, GetDefaultFontHandle());
		}
		~PauseScreen()
		{
			ImageLoadControl.Singleton.Delete(frameHandle);
			ImageLoadControl.Singleton.Delete(menuHandle);
		}
		public PauseScreen(string folder)
		{
			frameHandle = ImageLoadControl.Singleton.Load(Path.Combine(folder, "frame.png"));
			menuHandle = ImageLoadControl.Singleton.Load(Path.Combine(folder, "menu.png"));


		}
	}
}
