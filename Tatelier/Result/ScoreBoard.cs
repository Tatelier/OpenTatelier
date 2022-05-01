using HjsonEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Coroutine;
using Tatelier.Scene;
using static DxLibDLL.DX;


namespace Tatelier.Result
{
	class ScoreBoard
	{
		Common.Transform transform;

		Common.Transform itemGreatTransform;

		Common.Transform itemGoodTransform;

		Common.Transform itemBadTransform;

		Common.Transform itemRollTransform;

		Common.Transform itemMaxComboTransform;

		/// <summary>
		/// 側の画像
		/// </summary>
		int frameHandle = -1;

		/// <summary>
		/// 数字画像の配列
		/// </summary>
		int[] numbersSmall;

		int headingGreatHandle = -1;

		int headingGoodHandle = -1;

		int headingBadHandle = -1;

		int headingRollHandle = -1;

		int headingMaxComboHandle = -1;

		/// <summary>
		/// 
		/// </summary>
		ScoreNumber scoreNumber;

		CoroutineControl coroutineControl;

		#region 各数
		/// <summary>
		/// 良の数
		/// </summary>
		public int Great = 999;

		/// <summary>
		/// 可の数
		/// </summary>
		public int Good = 127;

		/// <summary>
		/// 不可の数
		/// </summary>
		public int Bad = 2;

		/// <summary>
		/// 連打数
		/// </summary>
		public int Roll = 2568;

		/// <summary>
		/// 最大コンボ数
		/// </summary>
		public int MaxCombo = 459;

		#endregion


		public void SetValue(Tatelier.Result.ResultData result)
		{
			Great = result.GreatCount;
			Good = result.GoodCount;
			Bad = result.BadCount;
			Roll = result.Roll;
			MaxCombo = result.MaxCombo;
			scoreNumber.Value = result.ScorePoint;
		}

		void AnimateGood()
		{

		}

		void Animate()
		{
			int animateTime = 250;
			int startWait = 1000;
			int diff = 1000;

			itemGreatTransform.Scale = new Common.Vector2(0, 0);
			coroutineControl.StartCoroutine(itemGreatTransform.AnimateScale(new Common.Vector2(0, 0), 0, startWait + diff * 0, 0, Common.EasingType.SinIn, () =>
			 {
				 itemGreatTransform.Scale = new Common.Vector2(1.25F, 1.25F);
				 coroutineControl.StartCoroutine(itemGreatTransform.AnimateScale(new Common.Vector2(1.0F, 1.0F), animateTime, 0, 0, Common.EasingType.SinIn, null));
			 }));

			coroutineControl.StartCoroutine(itemGoodTransform.AnimateScale(new Common.Vector2(0, 0), 0, startWait + diff * 1, 0, Common.EasingType.SinIn, () =>
			 {
				 itemGoodTransform.Scale = new Common.Vector2(1.25F, 1.25F);
				 coroutineControl.StartCoroutine(itemGoodTransform.AnimateScale(new Common.Vector2(1.0F, 1.0F), animateTime, 0, 0, Common.EasingType.SinIn, null));
			 }));

			coroutineControl.StartCoroutine(itemBadTransform.AnimateScale(new Common.Vector2(0, 0), 0, startWait + diff * 2, 0, Common.EasingType.SinIn, () =>
			{
				itemBadTransform.Scale = new Common.Vector2(1.25F, 1.25F);
				coroutineControl.StartCoroutine(itemBadTransform.AnimateScale(new Common.Vector2(1.0F, 1.0F), animateTime, 0, 0, Common.EasingType.SinIn, null));
			}));

			coroutineControl.StartCoroutine(itemRollTransform.AnimateScale(new Common.Vector2(0, 0), 0, startWait + diff * 3, 0, Common.EasingType.SinIn, () =>
			{
				itemRollTransform.Scale = new Common.Vector2(1.25F, 1.25F);
				coroutineControl.StartCoroutine(itemRollTransform.AnimateScale(new Common.Vector2(1.0F, 1.0F), animateTime, 0, 0, Common.EasingType.SinIn, null));
			}));

			coroutineControl.StartCoroutine(itemMaxComboTransform.AnimateScale(new Common.Vector2(0, 0), 0, startWait + diff * 4, 0, Common.EasingType.SinIn, () =>
			{
				itemMaxComboTransform.Scale = new Common.Vector2(1.25F, 1.25F);
				coroutineControl.StartCoroutine(itemMaxComboTransform.AnimateScale(new Common.Vector2(1.0F, 1.0F), animateTime, 0, 1000, Common.EasingType.SinIn, () =>
				{
					scoreNumber.AnimateStart();
				}));
			}));
		}


		public void StartAnimation()
		{
			Animate();
		}

		public void Update()
		{
			scoreNumber.Update();
			coroutineControl.Update();
		}

		float tempX = 453;
		float tempX2 = 593;

		//float tempY = 19;

		public void Draw(float xf, float yf)
		{
			// ボードの枠
			DrawGraphF(xf, yf, frameHandle, DX_TRUE);

			DrawGraphF(xf + tempX, 331 + 69 * 0, headingGreatHandle, DX_TRUE);
			DrawGraphF(xf + tempX, 331 + 69 * 1, headingGoodHandle, DX_TRUE);
			DrawGraphF(xf + tempX, 331 + 69 * 2, headingBadHandle, DX_TRUE);
			DrawGraphF(xf + tempX, 331 + 69 * 3, headingRollHandle, DX_TRUE);
			DrawGraphF(xf + tempX, 331 + 69 * 4, headingMaxComboHandle, DX_TRUE);

			DrawNumberImageF(xf + tempX2, 331 + 69 * 0, Great, 7, itemGreatTransform, 35, 58, numbersSmall);
			DrawNumberImageF(xf + tempX2, 331 + 69 * 1, Good, 7, itemGoodTransform, 35, 58, numbersSmall);
			DrawNumberImageF(xf + tempX2, 331 + 69 * 2, Bad, 7, itemBadTransform, 35, 58, numbersSmall);
			DrawNumberImageF(xf + tempX2, 331 + 69 * 3, Roll, 7, itemRollTransform, 35, 58, numbersSmall);
			DrawNumberImageF(xf + tempX2, 331 + 69 * 4, MaxCombo, 7, itemMaxComboTransform, 35, 58, numbersSmall);

			scoreNumber.Draw(xf + 53, 360);
		}

		public void Draw()
		{
			// ボードの枠
			DrawGraphF(transform.X, transform.Y, frameHandle, DX_TRUE);

			DrawGraphF(transform.X + tempX, 331 + 69 * 0, headingGreatHandle, DX_TRUE);
			DrawGraphF(transform.X + tempX, 331 + 69 * 1, headingGoodHandle, DX_TRUE);
			DrawGraphF(transform.X + tempX, 331 + 69 * 2, headingBadHandle, DX_TRUE);
			DrawGraphF(transform.X + tempX, 331 + 69 * 3, headingRollHandle, DX_TRUE);
			DrawGraphF(transform.X + tempX, 331 + 69 * 4, headingMaxComboHandle, DX_TRUE);

			DrawNumberImageF(transform.X + tempX2, 331 + 69 * 0, Great, 7, itemGreatTransform, 35, 58, numbersSmall);
			DrawNumberImageF(transform.X + tempX2, 331 + 69 * 1, Good, 7, itemGoodTransform, 35, 58, numbersSmall);
			DrawNumberImageF(transform.X + tempX2, 331 + 69 * 2, Bad, 7, itemBadTransform, 35, 58, numbersSmall);
			DrawNumberImageF(transform.X + tempX2, 331 + 69 * 3, Roll, 7, itemRollTransform, 35, 58, numbersSmall);
			DrawNumberImageF(transform.X + tempX2, 331 + 69 * 4, MaxCombo, 7, itemMaxComboTransform, 35, 58, numbersSmall);

			scoreNumber.Draw();
		}
		~ScoreBoard()
		{
			ImageLoadControl.Singleton.Delete(frameHandle);

			foreach (var item in numbersSmall)
			{
				ImageLoadControl.Singleton.Delete(item);
			}
			ImageLoadControl.Singleton.Delete(headingGreatHandle);
			ImageLoadControl.Singleton.Delete(headingGoodHandle);
			ImageLoadControl.Singleton.Delete(headingBadHandle);
			ImageLoadControl.Singleton.Delete(headingRollHandle);
			ImageLoadControl.Singleton.Delete(headingMaxComboHandle);
		}
		public ScoreBoard(string folder, Hjson.JsonValue json)
		{
			transform = new Common.Transform();

			transform.X = json?.EQi("Frame.Point.X") ?? 47;
			transform.Y = json?.EQi("Frame.Point.Y") ?? 280;

			frameHandle = ImageLoadControl.Singleton.Load(System.IO.Path.Combine(folder, "ScoreBoard/Player001.png"));

			numbersSmall = ImageLoadControl.Singleton.LoadNumbers(System.IO.Path.Combine(folder, "ScoreBoard/NumberSmall"), ".png");

			headingGreatHandle = ImageLoadControl.Singleton.Load(System.IO.Path.Combine(folder, "ScoreBoard/Heading/良.png"));

			headingGoodHandle = ImageLoadControl.Singleton.Load(System.IO.Path.Combine(folder, "ScoreBoard/Heading/可.png"));

			headingBadHandle = ImageLoadControl.Singleton.Load(System.IO.Path.Combine(folder, "ScoreBoard/Heading/不可.png"));

			headingRollHandle = ImageLoadControl.Singleton.Load(System.IO.Path.Combine(folder, "ScoreBoard/Heading/連打数.png"));

			headingMaxComboHandle = ImageLoadControl.Singleton.Load(System.IO.Path.Combine(folder, "ScoreBoard/Heading/最大コンボ数.png"));

			itemGreatTransform = new Common.Transform()
			{
				Scale = new Common.Vector2(0, 0),
			};
			itemGoodTransform = new Common.Transform()
			{
				Scale = new Common.Vector2(0, 0),
			};
			itemBadTransform = new Common.Transform()
			{
				Scale = new Common.Vector2(0, 0),
			};
			itemRollTransform = new Common.Transform()
			{
				Scale = new Common.Vector2(0, 0),
			};
			itemMaxComboTransform = new Common.Transform()
			{
				Scale = new Common.Vector2(0, 0),
			};

			itemGreatTransform.Scale.X = 1.1F;
			itemGreatTransform.Scale.Y = 1.1F;

			scoreNumber = new ScoreNumber(folder);

			coroutineControl = new CoroutineControl();
		}
	}
}
