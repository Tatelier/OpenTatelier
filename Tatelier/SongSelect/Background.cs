using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.DxLibDLL;
using static DxLibDLL.DX;
using HjsonEx;
using System.Diagnostics;

namespace Tatelier.SongSelect
{
	class Background
	{
		public Action<string> Logged;

		[DebuggerDisplay("Handle:{Handle}, X:{X}, Y:{Y}")]
		class BackgroundItem
        {
			public int Handle = -1;
			public int FadeStartMillisec = int.MinValue;
			public float X;
			public float Y;
        }

		BackgroundItem[] itemList = new BackgroundItem[5];

		int nowIndex = 0;
		float fadeTime = 300;

		int alphaMax = 255;

		float moveX;
		float moveY;

		int startTime;

		Coroutine.CoroutineControl coroutineControl = new Coroutine.CoroutineControl();

		public void ChangeImage(int imageHandle, bool isFade = true)
		{
			Logged?.Invoke($"imageHandle={imageHandle}, isFade={isFade}");

			if (itemList[nowIndex].Handle != imageHandle)
			{
				Logged?.Invoke("違う画像");
				nowIndex = (nowIndex + 1) % itemList.Length;

				itemList[nowIndex].Handle = imageHandle;

				if (isFade)
				{
					itemList[nowIndex].FadeStartMillisec = Supervision.NowMilliSec;
				}
                else
                {
					itemList[nowIndex].FadeStartMillisec = (int)(Supervision.NowMilliSec - fadeTime);
				}
				if (Logged != null)
				{
					Logged($"nowIndex:{nowIndex}");
					for(var i = 0; i < itemList.Length; i++)
					{
						Logged($"{i}:{itemList[i].Handle}");
					}
				}
			}
			else
			{
				Logged?.Invoke("同じ画像");
			}
		}


		public void Update()
		{
			int nowTime = Supervision.NowMilliSec - startTime;
			float per = ((float)nowTime / 1000);

			float w, h;

			for(int i=0;i< itemList.Length;i++)
			{
				GetGraphSizeF(itemList[i].Handle, out w, out h);

				itemList[i].X = (itemList[i].X + moveX * per) % w;
				itemList[i].Y = (itemList[i].Y + moveY * per) % h;
			}

			startTime = Supervision.NowMilliSec;
		}

		public void Draw()
        {
			coroutineControl.Update();

			int index = nowIndex;

			do
			{
				index = (index + 1) % itemList.Length;
				var item = itemList[index];

				using (DrawBlendModeGuard.Create())
				{
					int per = (int)((Supervision.NowMilliSec - item.FadeStartMillisec) / fadeTime * alphaMax);

					if (per > alphaMax)
					{
						per = alphaMax;
					}

					SetDrawBlendMode(DX_BLENDMODE_ALPHA, per);
					DrawTileGraph(0, 0, Supervision.ScreenWidth, Supervision.ScreenHeight, item.X, item.Y, item.Handle);
				}
			} while (nowIndex != index);
		}

		public Background(string folder, Hjson.JsonValue json)
		{
			moveX = (json.EQf("Move.X") ?? 0);
			moveY = (json.EQf("Move.Y") ?? 0);

			startTime = Supervision.NowMilliSec;

			for (int i = 0; i < itemList.Length; i++)
            {
				itemList[i] = new BackgroundItem();
            }
			nowIndex = itemList.Length - 1;
		}
	}
}
