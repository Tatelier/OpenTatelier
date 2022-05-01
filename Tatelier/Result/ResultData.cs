using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Play;
using Tatelier.Score;

namespace Tatelier.Result
{
    /// <summary>
    /// 演奏結果クラス
    /// </summary>
    class ResultData
	{
		PlayDefine define;

		public string MD5 = "";

		/// <summary>
		/// 魂ゲージ値(0～10000)
		/// </summary>
		public int SoulGaugeValue = 0;

        public SongSelect.ClearType ClearType { get; set; } = SongSelect.ClearType.None;

		public DateTime PlayStartDateTime;

		/// <summary>
		/// 極(仮)
		/// </summary>
		public int Kiwami;

		/// <summary>
		/// 良の数
		/// </summary>
		public int GreatCount { get; private set; } = 0;

		/// <summary>
		/// 可の数
		/// </summary>
		public int GoodCount { get; private set; } = 0;

		/// <summary>
		/// 不可の数
		/// </summary>
		public int BadCount { get; private set; } = 0;

		/// <summary>
		/// 連打の数
		/// </summary>
		public int Roll { get; private set; } = 0;

		/// <summary>
		/// 最大コンボ数
		/// </summary>
		public int MaxCombo { get; private set; }

		/// <summary>
		/// 演奏用コンボ数
		/// </summary>
		public int Combo { get; private set; }

		/// <summary>
		/// 前回点数
		/// </summary>
		public int PrevScorePoint { get; set; }

		/// <summary>
		/// 点数
		/// </summary>
		public int ScorePoint { get; private set; }

		/// <summary>
		/// 判定種別に加算する
		/// </summary>
		/// <param name="judgeType">判定種別</param>
		/// <param name="num">数</param>
		public void AddCount(JudgeType judgeType, int num = 1)
		{
			switch (judgeType)
			{
				case JudgeType.Great:
					GreatCount++;
					Combo++;
					ScorePoint += define.GreatPoint;
					if (MaxCombo < Combo)
					{
						MaxCombo++;
					}
					break;
				case JudgeType.Good:
					GoodCount++;
					Combo++;
					ScorePoint += define.GoodPoint;
					if (MaxCombo < Combo)
					{
						MaxCombo++;
					}
					break;
				case JudgeType.Bad:
				case JudgeType.None:
					BadCount++;
					Combo = 0;
					break;
			}
		}

		/// <summary>
		/// 連打数を加算する
		/// </summary>
		/// <param name="num"></param>
		public void AddRollCount(int num = 1)
		{
			Roll += num;
			ScorePoint += define.RollPoint;
		}

		/// <summary>
		/// データをクリアする
		/// </summary>
		public void Clear()
		{
			GreatCount = GoodCount = BadCount = 0;
		}

		public ResultData()
		{

		}

		public ResultData(PlayDefine define)
		{
			this.define = define;
		}
	}
}
