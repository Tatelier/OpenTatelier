using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score;
using Tatelier.Score.Component;

namespace Tatelier.Play
{
    /// <summary>
    /// BPM状態管理クラス
    /// </summary>
    class BPMStatusControl
	{
		BPM[] BPMInfoList;

		BranchScoreControl branchScoreControl;

		/// <summary>
		/// 
		/// </summary>
		public void Restart()
		{

		}

		/// <summary>
		/// 現在のBPM
		/// </summary>
		public BPM NowBPM;

		public bool TryGetChangeBPM(int millisec, BranchType branchType)
		{
			var nextBPM = branchScoreControl.GetBPMInfo(millisec, branchType);

			if (nextBPM == null)
			{
				return false;
			}

			if(NowBPM != nextBPM)
			{
				NowBPM = nextBPM;
				return true;
			}

			return false;
		}

		public BPMStatusControl(BranchScoreControl branchScoreControl)
		{
			this.branchScoreControl = branchScoreControl;
		}

		public BPMStatusControl(BPM[] infoList)
		{
			BPMInfoList = infoList;
		}
	}
}
