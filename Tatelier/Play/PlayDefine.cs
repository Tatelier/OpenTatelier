using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Play
{
	/// <summary>
	/// 演奏定義
	/// </summary>
	class PlayDefine
	{
		/// <summary>
		/// 良の点数
		/// </summary>
		public int GreatPoint = 100;

		/// <summary>
		/// 可の点数
		/// </summary>
		public int GoodPoint = 50;

		/// <summary>
		/// 連打ポイント
		/// </summary>
		public int RollPoint = 100;

		/// <summary>
		/// 風船連打ポイント
		/// </summary>
		public int BalloonNumPoint = 100;

		/// <summary>
		/// 風船爆発ポイント
		/// </summary>
		public int BalloonBombPoint = 100;

		/// <summary>
		/// 大音符倍率
		/// </summary>
		public double BigNotePointMag = 1;

		/// <summary>
		/// 音符数から1音符叩いたときの点数を計算しセットする
		/// </summary>
		/// <param name="noteNum">音符数</param>
		/// <param name="maxPoint">最大点数 ※この値を元に理論値を導く</param>
		public void SetDiffPoint(int noteNum, int maxPoint = 1000000)
		{
			double max = maxPoint;

			double onePoint = max / noteNum;

			onePoint = Math.Ceiling(onePoint / 10) * 10;

			GreatPoint = (int)onePoint;

			GoodPoint = (int)(Math.Ceiling(onePoint / 20) * 10);
		}
	}
}
