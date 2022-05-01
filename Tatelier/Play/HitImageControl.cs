using HjsonEx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.DxLibDLL;
using Tatelier.Score;
using Tatelier.Score.Component.NoteSystem;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
    /// <summary>
    /// 音符ヒット画像コントロールクラス
    /// </summary>
    class HitImageControl
		: IDisposable
	{
		bool disposed = false;

		int startTime = -1;

		int normalGreat;
		int normalGood;

		int bigGreat;
		int bigGood;

		int handle = -1;

		float x;
		float y;

		/// <summary>
		/// エフェクトをセットする
		/// </summary>
		/// <param name="nowTime">時間(ms)</param>
		/// <param name="noteType">音符種別</param>
		/// <param name="judgeType">判定種別</param>
		public void Set(int nowTime, NoteType noteType, JudgeType judgeType)
		{
			startTime = nowTime;

			int index = 0;


			switch (judgeType)
			{
				case JudgeType.Great:
					index |= 0x00;
					break;
				case JudgeType.Good:
					index |= 0x01;
					break;
			}

			switch (noteType)
			{
				case NoteType.Don:
				case NoteType.Kat:
					index |= 0x00;
					break;
				case NoteType.DonBig:
				case NoteType.KatBig:
					index |= 0x10;
					break;
			}
			switch (index)
			{
				case 0x00:
					handle = normalGreat;
					break;
				case 0x01:
					handle = normalGood;
					break;
				case 0x10:
					handle = bigGreat;
					break;
				case 0x11:
					handle = bigGood;
					break;
			}
		}

		/// <summary>
		/// 描画
		/// </summary>
		/// <param name="nowTime">時間(ms)</param>
		public void Draw(int nowTime)
		{
			using (DrawBlendModeGuard.Create())
			{
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, 255 - (int)(((nowTime - startTime) / 500.0F) * 255));
				DrawRotaGraphF(x, y, 1.0F, 0.0F, handle, DX_TRUE);
			}
		}

		public void Draw(float cx, float cy, int nowTime)
		{
			using (DrawBlendModeGuard.Create())
			{
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, 255 - (int)(((nowTime - startTime) / 500.0F) * 255));
				DrawRotaGraphF(cx, cy, 1.0F, 0.0F, handle, DX_TRUE);
			}
		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					var imgCtrl = ImageLoadControl.Singleton;

					imgCtrl.Delete(normalGreat);
					imgCtrl.Delete(normalGood);
					imgCtrl.Delete(bigGreat);
					imgCtrl.Delete(bigGood);
				}
				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~HitImageControl()
		{
			Dispose();
		}

		public HitImageControl(string folder, Hjson.JsonValue json)
		{
			folder = Path.Combine(folder, json.EQs("FolderPath") ?? "Hit");

			normalGreat = ImageLoadControl.Singleton.Load(Path.Combine(folder, "NormalGreat.png"));
			normalGood = ImageLoadControl.Singleton.Load(Path.Combine(folder, "NormalGood.png"));

			bigGreat = ImageLoadControl.Singleton.Load(Path.Combine(folder, "BigGreat.png"));
			bigGood = ImageLoadControl.Singleton.Load(Path.Combine(folder, "BigGood.png"));

			handle = -1;
		}

		public HitImageControl(string folder, float x, float y)
		{
			normalGreat = ImageLoadControl.Singleton.Load(Path.Combine(folder, "NormalGreat.png"));
			normalGood = ImageLoadControl.Singleton.Load(Path.Combine(folder, "NormalGood.png"));

			bigGreat = ImageLoadControl.Singleton.Load(Path.Combine(folder, "BigGreat.png"));
			bigGood = ImageLoadControl.Singleton.Load(Path.Combine(folder, "BigGood.png"));

			handle = -1;

			this.x = x;
			this.y = y;
		}
	}
}
