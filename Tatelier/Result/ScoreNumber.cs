using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.Result
{
	class ScoreNumber
	{
		int[] numbers;

		Common.Transform transform;

		Common.Transform itemTransform;

		Common.Vector2 startSize2D;
		Common.Vector2 endSize2D;

		float itemWidth = 50;
		float itemHeight = 80;

		public void AnimateStart()
		{
			itemTransform.Scale = startSize2D;
		}

		public void Update()
		{
		}

		/// <summary>
		/// スコア値
		/// </summary>
		public int Value
		{
			get => val;
			set
			{
				val = value;
				// 右寄せにするため桁数は変更しない
				//digit = Common.Utility.Digit(val);
			}
		}

		int val = 122;
		int digit = 7;

		public void Draw(float xf, float yf)
		{
			using (Tatelier.DxLibDLL.DrawModeGuard.Create())
			{
				SetDrawMode(DX_DRAWMODE_BILINEAR);

				DrawNumberImageF(xf, yf, val, digit, itemTransform, itemWidth, itemHeight, numbers);

				//for (int i = 0; i < digit; i++)
				//{
				//	int pow = (int)Math.Pow(10, digit - i - 1);
				//	DrawRotaGraphF(itemWidth / 2 + itemWidth * i + transform.Point.X, itemHeight / 2 + transform.Point.Y, itemTransform.Scale.X, 0.0, numbers[(val / pow) % 10], TRUE);
				//}
			}
		}

		public void Draw()
		{
			using (Tatelier.DxLibDLL.DrawModeGuard.Create())
			{
				SetDrawMode(DX_DRAWMODE_BILINEAR);

				DrawNumberImageF(transform.X, transform.Y, val, digit, itemTransform, itemWidth, itemHeight, numbers);

				//for (int i = 0; i < digit; i++)
				//{
				//	int pow = (int)Math.Pow(10, digit - i - 1);
				//	DrawRotaGraphF(itemWidth / 2 + itemWidth * i + transform.Point.X, itemHeight / 2 + transform.Point.Y, itemTransform.Scale.X, 0.0, numbers[(val / pow) % 10], TRUE);
				//}
			}
		}
		~ScoreNumber()
		{
			for (int i = 0; i < numbers.Length; i++)
			{
				ImageLoadControl.Singleton.Delete(numbers[i]);
			}
		}
		public ScoreNumber(string folder)
		{
			numbers = new int[10];

			itemTransform = new Common.Transform();
			transform = new Common.Transform();
			transform.X = 110;
			transform.Y = 360;

			startSize2D = itemTransform.Scale * 1.5F;
			endSize2D = itemTransform.Scale;

			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[i] = ImageLoadControl.Singleton.Load(Path.Combine(folder, "ScoreNumber", $"{i}.png"));
			}

			itemTransform.Scale = new Common.Vector2(0, 0);
		}
	}
}
