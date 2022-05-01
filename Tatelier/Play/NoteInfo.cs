using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score;
using Tatelier.Score.Component;
using Tatelier.Score.Component.NoteSystem;
using Tatelier.Score.Play.Chart;

namespace Tatelier.Play
{
    class NotePivotInfo2
	{
		public NotePivotInfo2 BranchPivot = null;

		/// <summary>
		/// 音符ID
		/// </summary>
		public int NoteId = 0;

		/// <summary>
		/// 小節線ID
		/// </summary>
		public int MeasureId = 0;

		/// <summary>
		/// 分岐種別
		/// </summary>
		public BranchType BranchType = BranchType.Common;

		/// <summary>
		/// 小節線状態
		/// 0: 非表示, 1: 表示
		/// </summary>
		public int BarLineState = 1;

		/// <summary>
		/// BPM情報
		/// </summary>
		public BPM BPMInfo = new BPM(-1000, 120);

		/// <summary>
		/// MeasureLine情報
		/// </summary>
		public MeasureLineInfo MeasureInfo = new MeasureLineInfo(-60000, 4, 4);

		/// <summary>
		/// ScrollSpeed情報
		/// </summary>
		public ScrollSpeedInfo ScrollSpeedInfo = new ScrollSpeedInfo(-60000, 1.0);
		
		/// <summary>
		/// 音符の時間
		/// </summary>
		public double PivotMillisec => decimal.ToDouble(PivotMicrosec * 0.001m);

		public decimal PivotMicrosec = 0;

		/// <summary>
		/// 1つ前の音符
		/// </summary>
		public INote PrevNote = null;

		/// <summary>
		/// 1つ前の小節線
		/// </summary>
		public IMeasureLine PrevMeasureLine = null;

		/// <summary>
		/// 演奏用分岐情報
		/// </summary>
		public BranchPlayInfo BranchPlayInfo = null;

		/// <summary>
		/// 
		/// </summary>
		public int NowBalloonIndex = 0;

		public List<int> BalloonValueList = null;

		public NotePivotInfo2() { }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public NotePivotInfo2 Clone()
		{
			return (NotePivotInfo2)MemberwiseClone();
		}
	}
}
