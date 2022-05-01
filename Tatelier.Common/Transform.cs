using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Common
{
	public class Transform
	{
		public float X;
		public float Y;

		public void SetPoint(Common.Vector2 vector2)
		{
			X = vector2.X;
			Y = vector2.Y;
		}

		public Vector2 Scale = Vector2.One;

		public Direction Margin;
	}
}
