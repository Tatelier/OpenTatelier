using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score;

namespace Tatelier.Play
{
    [DebuggerDisplay("Time = {Time}, Key = {Key}")]
	class PlayInputItem
	{
		public int Time = int.MaxValue;

		public int Key = 0;

		public JudgeType JudgeType = JudgeType.None;
	}
}
