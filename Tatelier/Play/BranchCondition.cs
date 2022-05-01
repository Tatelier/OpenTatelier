using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score;
using Tatelier.Score.Play.Chart;

namespace Tatelier.Play
{
    /// <summary>
    /// 譜面分岐状態クラス
    /// </summary>
    class BranchCondition
	{
		int great = 0;

		BranchPlayInfo[] branchPlayInfos;
		int branchPlayInfosIndex = 0;

		int[] sectionTimeList;
		int sectionTimeListIndex = 0;

		/// <summary>
		/// 精度
		/// ※ 0.0 ～ 100.0 の間
		/// </summary>
		/// <returns>精度</returns>
		double GetPerfect()
		{
			double sum = great + good + bad;

			return (((double)great / sum) + ((double)good / sum) * 0.5) * 100;
		}

		public string GetInfo(int nowTime)
		{
			double sum = great + good + bad;
			return $"{great / sum}, {good / sum}, {sum} : $";
		}

		/// <summary>
		/// 良の数
		/// </summary>
		public int Great
		{
			get => great;
			set
			{
				great = value;
				Perfect = GetPerfect();
			}
		}

		int good = 0;

		/// <summary>
		/// 可の数
		/// </summary>
		public int Good
		{
			get => good;
			set
			{
				good = value;
				Perfect = GetPerfect();
			}
		}

		int bad = 0;

		/// <summary>
		/// 不可の数
		/// </summary>
		public int Bad
		{
			get => bad;
			set
			{
				bad = value;
				Perfect = GetPerfect();
			}
		}

		/// <summary>
		/// 精度
		/// ※0.0 ～ 100.0
		/// </summary>
		public double Perfect { get; private set; } = 0;

		int Roll = 0;


		/// <summary>
		/// 分岐保持
		/// true: 有効, false: 無効
		/// </summary>
		public bool LevelHold { get; set; } = false;

		/// <summary>
		/// 加算処理
		/// </summary>
		/// <param name="judgeType">判定種別</param>
		public void AddCount(JudgeType judgeType)
		{
			switch (judgeType)
			{
				case JudgeType.Great:
					Great++;
					break;
				case JudgeType.Good:
					Good++;
					break;
				case JudgeType.Bad:
					Bad++;
					break;
			}
		}

		/// <summary>
		/// 連打数加算処理
		/// </summary>
		public void AddRollCount()
		{
			Roll++;
		}

		/// <summary>
		/// 分岐情報を次のものに切り替える。
		/// </summary>
		public void Next()
		{
			branchPlayInfosIndex++;
		}

		/// <summary>
		/// 分岐種別を取得する
		/// </summary>
		/// <param name="time">時間(ms)</param>
		/// <returns>分岐種別</returns>
		public BranchType GetBranchType(int time)
		{
			var bt = BranchType.Common;

			if (branchPlayInfosIndex >= branchPlayInfos.Length) return bt;

			var nowItem = branchPlayInfos[branchPlayInfosIndex];

			switch (nowItem.Type)
			{
				case '\t':
					{
						if (branchPlayInfosIndex >= 1)
						{
							bt = branchPlayInfos[branchPlayInfosIndex].Prev.BranchType;
						}
						else
						{
							bt = BranchType.Common;
						}
					}
					break;
				case 'p':
					if (nowItem.MasterValue <= Perfect)
					{
						bt = BranchType.Master;
					}
					else if (nowItem.ExpertValue <= Perfect)
					{
						bt = BranchType.Expert;
					}
					else
					{
						bt = BranchType.Normal;
					}
					break;
				case 'r':
					if (nowItem.MasterValue <= Roll)
					{
						bt = BranchType.Master;
					}
					else if (nowItem.ExpertValue <= Roll)
					{
						bt = BranchType.Expert;
					}
					else
					{
						bt = BranchType.Normal;
					}
					break;
			}

			nowItem.BranchType = bt;
			return bt;
		}

		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="time">時間(ms)</param>
		/// <returns></returns>
		public bool TryDataClear(int time)
		{
			if (sectionTimeListIndex >= sectionTimeList.Length) return false;

			if (sectionTimeList[sectionTimeListIndex] <= time)
			{
				Reset();
				sectionTimeListIndex++;

				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// データリセット
		/// </summary>
		public void Reset()
		{
			Great = Good = Bad = Roll = 0;
			Perfect = 0;
		}

		public BranchCondition(BranchPlayInfo[] infoList, int[] sectionTimeList)
		{
			branchPlayInfos = infoList;
			this.sectionTimeList = sectionTimeList;

			Reset();
			Perfect = 0;// GetPerfect();
		}
	}
}
