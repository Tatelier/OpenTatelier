using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Play
{
	[DebuggerDisplay("{ScrollSpeed}: [{StartTime} ～ {EndTime}]")]
	class ScrollSpeedInfo
	{
		public int StartTime;
		public int EndTime = int.MaxValue;

		public double ScrollSpeed = 1.0;

		public void SetEndTime(double endTime)
		{
			EndTime = (int)endTime;
		}

		public ScrollSpeedInfo(double startTime, ScrollSpeedInfo info)
		{
			this.StartTime = (int)startTime;
			this.ScrollSpeed = info.ScrollSpeed;
		}

		public ScrollSpeedInfo(double startTime, double scrollSpeed)
		{
			this.StartTime = (int)startTime;
			this.ScrollSpeed = scrollSpeed;
		}
	}
}
