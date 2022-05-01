using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score.Component.NoteSystem;
using Tatelier.Score.Play.Chart;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
    [DebuggerDisplay("Count: {Count}")]
	class BalloonControlItem
	{
		public int Count = 10;

		public int NowCount = 0;

		public bool BalloonBreak => Count == NowCount;

		/// <summary>
		/// 風船音符の叩いた回数を加算する
		/// </summary>
		/// <returns>true: 風船破裂, false: その他</returns>
		public bool AddCount()
		{
			NowCount++;

			return BalloonBreak;
		}

		public void Reset()
		{
			NowCount = 0;
		}
	}

	/// <summary>
	/// 風船連打管理クラス
	/// </summary>
	class BalloonControl : IDisposable
	{
		bool disposed = false;

		BalloonControlItem[] balloonControlItemList;


		public BalloonControlItem GetBalloon(INote note)
        {
			var balloonData = note.SpecialData as BalloonData;
			return balloonControlItemList[balloonData.Index];
        }

		public void Draw()
		{
			//DrawString(120, 120, $"Now {nowIndex} : {CommonBranchBalloonList[nowIndex].NowCount}/{CommonBranchBalloonList[nowIndex].Count}", GetColor(255, 255, 255));
		}


		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					// un-managed
				}

				// managed

				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		public BalloonControl()
		{

		}

		public BalloonControl(int[] balloonNoteCountList)
		{
			balloonControlItemList = new BalloonControlItem[balloonNoteCountList.Length];

			for(var i = 0; i < balloonControlItemList.Length; i++)
            {
				balloonControlItemList[i] = new BalloonControlItem()
				{
					Count = balloonNoteCountList[i]
				};
			}
		}
	}
}
