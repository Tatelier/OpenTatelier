using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class Transform
	{
		public (float X, float Y) Point { get; set; } = (0, 0);
		public (float X, float Y) PivotPoint { get; set; } = (0, 0);
		public (float X, float Y) Scale { get; set; } = (1.0F, 1.0F);
	}
}
