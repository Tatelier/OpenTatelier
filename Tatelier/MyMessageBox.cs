using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tatelier.DxLibDLL;
using static DxLibDLL.DX;

namespace Tatelier
{
	class MyMessageBoxItemInfo
	{
		public string Name = "はい";
		public bool DoDialogClose = true;
		public Action Callback;
	}

	class MyMessageBoxInfo
	{
		public MessageType MessageType { get; set; } = MessageType.Info;

		public string Text = "undefined.";

		public MyMessageBoxItemInfo[] MyMessageBoxItems;
	}

	class MyMessageBoxInfo2
    {
		public MyMessageBoxInfo MyMessageBoxInfo;

    }

	public enum MessageType
	{
		Info,
		Warning,
		Error,
	}

	class MyMessageBox
	{
		[Flags]
		enum PlaySoundFlags : int
		{
			SND_SYNC = 0x0000,
			SND_ASYNC = 0x0001,
			SND_NODEFAULT = 0x0002,
			SND_MEMORY = 0x0004,
			SND_LOOP = 0x0008,
			SND_NOSTOP = 0x0010,
			SND_NOWAIT = 0x00002000,
			SND_ALIAS = 0x00010000,
			SND_ALIAS_ID = 0x00110000,
			SND_FILENAME = 0x00020000,
			SND_RESOURCE = 0x00040004,
			SND_PURGE = 0x0040,
			SND_APPLICATION = 0x0080
		}

		[System.Runtime.InteropServices.DllImport("winmm.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		static extern bool PlaySound(string pszSound, IntPtr hmod, PlaySoundFlags fdwSound);

		public static MyMessageBox Singleton { get; private set; } = new MyMessageBox();

		const uint WarningColor = 0xBBBB00;
		const uint WarningDarkColor = 0x888800;
		const uint ErrorColor = 0xFF8888;
		const uint ErrorLightColor = 0xFF8888;
		const uint ErrorDarkColor = 0xBB4444;

		const uint InfoColor = 0x3089CC;
		const uint InfoDarkColor = 0x2570A2;

		const uint ContentColor = 0xF0F0F0;

		const int roundWidth = 20;

		const uint BackgroundColor = 0x222e3f;
		const uint BackgroundInnerLineColor = 0x121e2f;

		const int innerFrameWidth = 15;

		int screen = 0;

		Tatelier.SongSelect.InputControlItemSongSelect input;

		int fontHeaderHandle;
		int fontContentHandle;

		uint color = 0xFFFFFF;
		uint darkColor = 0xDDDDDD;
		string header = "";
		string content = "";

		bool Active = false;
		public bool IsOpen = false;

		const int minWidth = 640;
		const int minHeight = 480;

		const int maxWidth = 1280;
		const int maxHeight = 840;

		const int maxInnerWidth = 1160;
		const int maxInnerHeight = 620;

		const int minInnerWidth = 1080;
		const int minInnerHeight = 80;

		const int buttomFrameHeight = 80;

		int width = maxWidth;
		int height = maxHeight;

		int innerWidth = maxInnerWidth;
		int innerHeight = maxInnerHeight;

		uint backColor = 0;

		uint buttonBackColor;
		uint buttonBackDarkColor;

		LinkedList<MyMessageBoxInfo2> infoList = new LinkedList<MyMessageBoxInfo2>();

		MyMessageBoxInfo2 currentInfo;

		int currentIndex = 0;

		#region アニメーション関連
		IEnumerator colorAnime;
		IEnumerator GetColorAnime(uint start, uint end)
		{
			int startCount = 0;
			uint startRed = (start & 0xFF0000) >> 16;
			uint startGreen = (start & 0x00FF00) >> 8;
			uint startBlue = (start & 0x0000FF);

			uint endRed = (end & 0xFF0000) >> 16;
			uint endGreen = (end & 0x00FF00) >> 8;
			uint endBlue = (end & 0x0000FF);

			int time = 500;

			while (true)
			{
				startCount = Supervision.NowMilliSec;
				while (Supervision.NowMilliSec - startCount < time)
				{
					double ratio = ((double)Supervision.NowMilliSec - startCount) / time;
					backColor =
						((startRed + (uint)((endRed - startRed) * ratio)) << 16)
					| ((startGreen + (uint)((endGreen - startGreen) * ratio)) << 8)
					| ((startBlue + (uint)((endBlue - startBlue) * ratio)));
					yield return null;
				}
				backColor =
					(endRed << 16)
				| (endGreen << 8)
				| (endBlue);
				yield return null;

				startCount = Supervision.NowMilliSec;
				while (Supervision.NowMilliSec - startCount < time)
				{
					double ratio = ((double)Supervision.NowMilliSec - startCount) / time;
					backColor =
						((endRed - (uint)((endRed - startRed) * ratio)) << 16)
					| ((endGreen - (uint)((endGreen - startGreen) * ratio)) << 8)
					| ((endBlue - (uint)((endBlue - startBlue) * ratio)));
					yield return null;
				}
				backColor =
					(startRed << 16)
				| (startGreen << 8)
				| (startBlue);

				yield return null;
			}
		}
		#endregion

		/// <summary>
		/// メッセージボックスを開く
		/// </summary>
		/// <param name="info">メッセージボックス情報</param>
		public void Open(MyMessageBoxInfo info = null)
		{
			if (info == null) 
			{
				if (infoList.Any())
				{
					info = currentInfo.MyMessageBoxInfo;
					Trace.WriteLine($"[{DateTime.Now:HHmmss.fff}] info is null. so use last item.");
				}
                else
				{
					Trace.WriteLine($"[{DateTime.Now:HHmmss.fff}] info is null.");
					return;
				}
			} 

			infoList.AddLast(new MyMessageBoxInfo2{
				MyMessageBoxInfo = info
			});

			InputControl.Singleton.NowMyMessageboxInput = true;

			InputControl.Singleton.ChangeInput("MessageBox");


			if (info.MyMessageBoxItems == null
				|| info.MyMessageBoxItems.Length == 0)
			{
				info.MyMessageBoxItems = new MyMessageBoxItemInfo[]
				{
					new MyMessageBoxItemInfo()
					{
						Name = "OK",
					}
				};
			}

			currentIndex = 0;
			switch (info.MessageType)
			{
				case MessageType.Info:
					{
						color = InfoColor;
						header = "Info";
						buttonBackColor = InfoColor;
						buttonBackDarkColor = InfoDarkColor;
					}
					break;
				case MessageType.Warning:
					{
						color = WarningColor;
						header = "Warning";
						buttonBackColor = WarningColor;
						buttonBackDarkColor = WarningDarkColor;
					}
					break;
				case MessageType.Error:
					{
						color = ErrorColor;
						darkColor = ErrorLightColor;
						buttonBackColor = ErrorColor;
						buttonBackDarkColor = ErrorDarkColor;
						header = "Error";
						PlaySound("SystemHand"
							, IntPtr.Zero
							, PlaySoundFlags.SND_ALIAS | PlaySoundFlags.SND_NODEFAULT | PlaySoundFlags.SND_ASYNC);
					}
					break;
			}

			content = info.Text;

			string[] lines = content.Split('\n');

			int mW = lines.Max(v => GetDrawStringWidthToHandle(v, Share.Singleton.SJIS.GetByteCount(v), fontContentHandle));

			if (mW < minInnerWidth) { mW = minInnerWidth; }
			else if (mW > maxInnerWidth) { mW = maxInnerWidth; }

			int mH = 0;

			foreach (var line in lines)
			{
				mH += ((GetDrawStringWidthToHandle(line, Share.Singleton.SJIS.GetByteCount(line), fontContentHandle) / mW) + 1) * (GetFontSizeToHandle(fontContentHandle) + 4);
			}

			if (mH < minInnerHeight) { mH = minInnerHeight; }
			else if (mH > maxInnerHeight) { mH = maxInnerHeight; }

			innerWidth = mW;
			innerHeight = mH;

			width = innerWidth + (maxWidth - maxInnerWidth);
			height = innerHeight + (maxHeight - maxInnerHeight) + buttomFrameHeight;


			colorAnime = GetColorAnime(buttonBackDarkColor, buttonBackColor);

			if (currentInfo == null)
			{
				currentInfo = infoList.LastOrDefault();
				IsOpen = true;
			}
		}

		void Close()
		{
			Active = false;
			IsOpen = false;
			currentInfo = null;
			InputControl.Singleton.ChangePrevInput();
		}

		/// <summary>
		/// 初期化処理
		/// </summary>
		public void Start()
		{
			screen = MakeScreen(1920, 1080, DX_TRUE);
			fontHeaderHandle = CreateFontToHandle(GetFontName(), 40, 0, DX_FONTTYPE_ANTIALIASING_4X4);
			fontContentHandle = CreateFontToHandle(GetFontName(), 28, 0, DX_FONTTYPE_ANTIALIASING_4X4);
		}

		void PlayMoveSE()
		{
			SetVolumeSoundFile(8500);
			PlaySoundFile(System.IO.Path.Combine(Environment.GetEnvironmentVariable("windir"), "Media", "Windows Battery Low.wav"), DX_PLAYTYPE_BACK);
		}

		/// <summary>
		/// 更新処理
		/// </summary>
		public void Update()
		{
			if (Active)
			{
				var messageBoxItems = currentInfo.MyMessageBoxInfo.MyMessageBoxItems;

				if (input.GetKeyDown(Tatelier.SongSelect.InputControlItemSongSelect.Prev))
				{
					PlayMoveSE();
					currentIndex = (currentIndex + 1) % messageBoxItems.Length;
				}
				if (input.GetKeyDown(Tatelier.SongSelect.InputControlItemSongSelect.Next))
				{
					PlayMoveSE(); 
					currentIndex = (currentIndex + (messageBoxItems.Length - 1)) % messageBoxItems.Length;
				}

				if (input.GetKeyDown(Tatelier.SongSelect.InputControlItemSongSelect.OK))
				{
					if (messageBoxItems[currentIndex].DoDialogClose)
					{
						Close();
					}
					messageBoxItems[currentIndex].Callback?.Invoke();

				}

				if (input.GetKeyDown(Tatelier.SongSelect.InputControlItemSongSelect.Cancel))
				{
					Close();

					messageBoxItems.First().Callback?.Invoke();
				}

				colorAnime.MoveNext();
			}

			Active = IsOpen;
		}

		#region 描画処理関連
		void DrawButtonOther(string text, int x, int y, uint clr)
		{
			int w = GetDrawStringWidthToHandle(text, Share.Singleton.SJIS.GetByteCount(text), fontContentHandle);

			int l = x;
			int t = y;

			DrawStringToHandle(l + 37, t + 20, text, clr, fontContentHandle);
		}

		void DrawButtonNowSelect(string text, int x, int y, uint clr)
		{
			int w = GetDrawStringWidthToHandle(text, Share.Singleton.SJIS.GetByteCount(text), fontContentHandle);

			int l = x;
			int t = y;

			DrawRoundRectAA(
				l
				, t
				, l + w + 74
				, t + GetFontSizeToHandle(fontContentHandle) + 40
				, 30, 30
				, 10
				, backColor, DX_FALSE, 3);

			DrawRoundRectAA(
				l
				, t
				, l + w + 74
				, t + GetFontSizeToHandle(fontContentHandle) + 40
				, 30, 30
				, 10
				, backColor, DX_TRUE, 3);

			DrawStringToHandle(l + 37, t + 20, text, clr, fontContentHandle);
		}

		void DrawAllButton(int right, int bottom)
		{
			uint clr = 0xFFFFFF;
			switch (currentInfo.MyMessageBoxInfo.MessageType)
			{
				case MessageType.Info:
					clr = InfoColor;
					break;
				case MessageType.Warning:
					clr = WarningColor;
					break;
				case MessageType.Error:
					clr = ErrorColor;
					break;
			}

			int l = right;
			int t = bottom + 40 + 20;

			for (int i = 0; i < currentInfo.MyMessageBoxInfo.MyMessageBoxItems.Length; i++)
			{
				var text = currentInfo.MyMessageBoxInfo.MyMessageBoxItems[i].Name;
				var w = GetDrawStringWidthToHandle(text, Share.Singleton.SJIS.GetByteCount(text), fontContentHandle);

				l -= (w + 80);

				if (currentIndex == i)
				{
					DrawButtonNowSelect(text, l, t, 0x222e3f);
				}
				else
				{
					DrawButtonOther(text, l, t, clr);
				}
			}
		}

		void DrawFrame()
		{
			// 背景を半透明の黒で塗りつぶす
			using (DrawBlendModeGuard.Create())
			{
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, 191);
				DrawBox(0, 0, Supervision.ScreenWidth, Supervision.ScreenHeight, 0, DX_TRUE);
			}

			// メッセージボックスの枠を描画
			using (DrawBlendModeGuard.Create())
			using (DrawAreaGuard.Create())
			{
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, 239);

				DrawRoundRectAA(
					Supervision.ScreenWidthHalf - width / 2
					, Supervision.ScreenHeightHalf - height / 2
					, Supervision.ScreenWidthHalf + width / 2
					, Supervision.ScreenHeightHalf + height / 2
					, roundWidth, roundWidth
					, 10
					, BackgroundColor, DX_TRUE);
			}

			// 枠内の線を描画
			DrawRoundRectAA(
				Supervision.ScreenWidthHalf - width / 2 + innerFrameWidth
				, Supervision.ScreenHeightHalf - height / 2 + innerFrameWidth
				, Supervision.ScreenWidthHalf + width / 2 - innerFrameWidth
				, Supervision.ScreenHeightHalf + height / 2 - innerFrameWidth
				, roundWidth, roundWidth
				, 10
				, BackgroundInnerLineColor, DX_FALSE, 5);
		}

		void DrawHeader()
		{
			int x = Supervision.ScreenWidthHalf	- GetDrawStringWidthToHandle(header, Share.Singleton.SJIS.GetByteCount(header), fontHeaderHandle) / 2;
			int y = Supervision.ScreenHeightHalf - (height / 2) + 40;

			DrawStringToHandle(x, y, header, color, fontHeaderHandle);
		}

		void DrawContent(int left, int top, int right, int bottom)
		{
			using (DrawAreaGuard.Create())
			{
				SetDrawArea(left, top, right, bottom);
				DrawObtainsString(0, 0, GetFontSizeToHandle(fontContentHandle) + 4, content, ContentColor, 0x000000, fontContentHandle);
			}
		}

		/// <summary>
		/// 描画処理
		/// </summary>
		public void Draw()
		{
			if (!Active) return;

			// メッセージボックスの枠を描画
			DrawFrame();

			// ヘッダー部を描画
			DrawHeader();

			int left = Supervision.ScreenWidthHalf - (innerWidth / 2);
			int top = Supervision.ScreenHeightHalf - height / 2 + 120;
			int right = left + innerWidth;
			int bottom = top + innerHeight;

			// 内容を描画
			DrawContent(left, top, right, bottom);

			// すべてのボタンを描画
			DrawAllButton(right, bottom);

			// 完成されたダイアログを描画
			DrawModiGraph(0, 0, Supervision.ScreenWidth, 0, Supervision.ScreenWidth, Supervision.ScreenHeight, 0, Supervision.ScreenHeight, screen, DX_TRUE);
		}
		#endregion

		void Dispose()
		{
			DeleteFontToHandle(fontContentHandle);
			DeleteFontToHandle(fontHeaderHandle);
			DeleteGraph(screen);
		}

		public void Reset()
		{
			Dispose();

			Singleton = new MyMessageBox();
		}


		MyMessageBox()
		{
			input = new Tatelier.SongSelect.InputControlItemSongSelect();
			InputControl.Singleton.Regist("MessageBox", input);
		}
	}
}
