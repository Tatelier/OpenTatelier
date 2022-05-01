using Tatelier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.DxLibDLL;

namespace DxLibDLL
{
	public static partial class DX
	{
		/// <summary>
		/// 画像を指定した範囲でタイル描画します
		/// </summary>
		/// <param name="x1"></param>
		/// <param name="y1"></param>
		/// <param name="x2"></param>
		/// <param name="y2"></param>
		/// <param name="txf"></param>
		/// <param name="tyf"></param>
		/// <param name="GrHandle"></param>
		/// <returns></returns>
		public static int DrawTileGraph(float x1, float y1, float x2, float y2, float txf, float tyf, int GrHandle)
		{
			if (GrHandle == -1)
			{
				return -1;
			}

			using (DrawModeGuard.Create())
			using (DrawAreaGuard.Create())
			{
				SetDrawMode(DX_DRAWMODE_BILINEAR);

				// 画像のサイズを得る
				GetGraphSize(GrHandle, out int img_w, out int img_h);
				if (img_w == 0 || img_h == 0) return -1;
				txf = txf % img_w;
				tyf = tyf % img_h;

				GetDrawScreenSize(out int scr_w, out int scr_h);

				SetDrawArea((int)x1, (int)y1, (int)x2, (int)y2);
				for (int y = -1; y < scr_h / img_h + 2; y++)
				{
					for (int x = -1; x < scr_w / img_w + 2; x++)
					{
						DrawGraphF(x1 + x * img_w + txf, y1 + y * img_h + tyf, GrHandle, DX_TRUE);
					}
				}
			}
			return 0;
		}

		public static int Draw9SliceGraphF(float x1, float y1, float width, float height, int[] handles)
		{
			if (handles.Length < 9)
			{
				return -1;
			}

			GetGraphSize(handles[0], out var sliceWidth, out var sliceHeight);

			float x2 = x1 + sliceWidth;
			float x3 = x1 + width - sliceWidth;
			float x4 = x1 + width;

			float y2 = y1 + sliceHeight;
			float y3 = y1 + height - sliceHeight;
			float y4 = y1 + height;

			int prevDrawMode = GetDrawMode();

			SetDrawMode(DX_DRAWMODE_BILINEAR);

			DrawGraphF(x1, y1, handles[0], DX_TRUE);
			DrawExtendGraphF(x2, y1, x3, y2, handles[1], DX_TRUE);
			DrawGraphF(x3, y1, handles[2], DX_TRUE);

			DrawExtendGraphF(x1, y2, x2, y3, handles[3], DX_TRUE);
			DrawExtendGraphF(x2, y2, x3, y3, handles[4], DX_TRUE);
			DrawExtendGraphF(x3, y2, x4, y3, handles[5], DX_TRUE);

			DrawGraphF(x1, y3, handles[6], DX_TRUE);
			DrawExtendGraphF(x2, y3, x3, y4, handles[7], DX_TRUE);
			DrawGraphF(x3, y3, handles[8], DX_TRUE);

			SetDrawMode(prevDrawMode);

			return 0;
		}


		/// <summary>
		/// ナンバリング画像を使って値を描画する
		/// </summary>
		/// <param name="xf">X座標</param>
		/// <param name="yf">Y座標</param>
		/// <param name="val">値</param>
		/// <param name="digit">桁指定</param>
		/// <param name="itemTransform">各数値のTransform</param>
		/// <param name="itemWidth">各数値の幅指定</param>
		/// <param name="itemHeight">各数値の高さ指定</param>
		/// <param name="numbers">ナンバリング画像</param>
		/// <returns></returns>
		public static int DrawNumberImageF(float xf, float yf, int val, int digit, Tatelier.Common.Transform itemTransform, float itemWidth, float itemHeight, int[] numbers)
		{
			SetDrawMode(DX_DRAWMODE_BILINEAR);

			int d = Tatelier.Common.Utility.Digit(val);

			for (int i = digit - d; i < digit; i++)
			{
				int pow = (int)Math.Pow(10, digit - i - 1);
				DrawRotaGraphF(itemWidth / 2 + itemWidth * i + xf, itemHeight / 2 + yf, itemTransform.Scale.X, 0.0, numbers[(val / pow) % 10], DX_TRUE);
			}

			return 0;
		}
	}
}
