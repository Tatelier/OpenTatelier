using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score.Play.Chart;

namespace Tatelier.Play
{
	/// <summary>
	/// ゴーゴータイム状態クラス
	/// </summary>
	class GogoCondition
	{
		GogoItem[] gogoArray;

		public int nowIndex = 0;

		/// <summary>
		/// 現在の状態
		/// [true:ゴーゴー状態, false:通常状態]
		/// </summary>
		public bool NowGogo = false;

		/// <summary>
		/// 更新処理
		/// </summary>
		/// <param name="nowTime">演奏経過時間(ms)</param>
		public void Update(int nowTime)
		{

			if (nowIndex >= gogoArray.Length) return;

			if (gogoArray[nowIndex].StartTime <= nowTime)
			{
				NowGogo = gogoArray[nowIndex].Gogo;
				nowIndex++;
			}
		}

		public GogoCondition(GogoItem[] gogoArray)
		{
			this.gogoArray = gogoArray;
			NowGogo = false;
		}
	}
}
