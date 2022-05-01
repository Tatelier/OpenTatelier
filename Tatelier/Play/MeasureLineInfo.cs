using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score.Component.NoteSystem;

namespace Tatelier.Play
{
    [DebuggerDisplay("{Measure}: [{StartTime} ～ {EndTime}]")]
	class MeasureLineInfo
	{
		public int StartTime { get; set; }
		public int EndTime { get; set; } = int.MaxValue;

		public double Upper { get; set; }

		public double Lower { get; set; }

		public double Measure
        {
			get => Upper * 4 / Lower;
        }

		public List<INote> NoteList = new List<INote>();

		public void SetEndTime(double endTime)
		{
			EndTime = (int)endTime;
		}

		public decimal GetCalc(double val)
		{
			decimal dVal = new decimal(val);
			decimal dUpper = new decimal(Upper);
			decimal dLower = new decimal(Lower);

			return dVal * (dUpper * 4) / dLower;
        }

		public void AddNote(INote note)
		{
			NoteList.Add(note);
		}

		public MeasureLineInfo(double startMillisec, MeasureLineInfo info)
		{
			StartTime = (int)startMillisec;
			Upper = info.Upper;
			Lower = info.Lower;
		}

		public MeasureLineInfo(double startTime, double upper, double lower)
		{
			StartTime = (int)startTime;
			Upper = upper;
			Lower = lower;
		}
	}
}
