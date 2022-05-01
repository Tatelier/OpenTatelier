using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Common
{
	[DebuggerDisplay("X={X}, Y={Y}")]
	public class Vector2
	{
		public float X { get; set; }
		public float Y { get; set; }

		public static Vector2 One => new Vector2(1, 1);

		public Vector2()
		{

		}

		public Vector2(float x, float y)
		{
			X = x;
			Y = y;
		}

		public static Vector2 operator +(Vector2 a, Vector2 b)
		{
			return new Vector2(a.X + b.X, a.Y + b.Y);
		}

		public static Vector2 operator -(Vector2 a, Vector2 b)
		{
			return new Vector2(a.X - b.X, a.Y - b.Y);
		}

		public static Vector2 operator *(Vector2 a, Vector2 b)
		{
			return new Vector2(a.X * b.X, a.Y * b.Y);
		}

		public static Vector2 operator *(Vector2 a, float b)
		{
			return new Vector2(a.X * b, a.Y * b);
		}
	}
}
