using HjsonEx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	[DebuggerDisplay("X: {X}, Y: {Y}, Width: {Width}, Height: {Height}")]
	class RectF
	{
		public float X = 0;
		public float Y = 0;
		public float Width = 0;
		public float Height = 0;

		public void Set(Hjson.JsonValue json)
		{
			X = json?.EQf("X") ?? X;
			Y = json?.EQf("Y") ?? Y;
			Width = json?.EQf("Width") ?? Width;
			Height = json?.EQf("Height") ?? Height;
		}

		public RectF()
		{

		}
	}
}
