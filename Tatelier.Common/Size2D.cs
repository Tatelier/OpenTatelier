using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Common
{
	public struct Size2D
	{
		public float Width;

		public float Height;


		public Size2D(float w, float h)
		{
			Width = w;
			Height = h;
		}

		public Size2D GetScale(float val)
		{
			return new Size2D()
			{
				Width = this.Width * val,
				Height = this.Height * val
			};
		}

		public static Size2D operator +(Size2D a, Size2D b)
		{
			return new Size2D(a.Width + b.Width, a.Height + b.Height);
		}

		public static Size2D operator -(Size2D a, Size2D b)
		{
			return new Size2D(a.Width - b.Width, a.Height - b.Height);
		}

		public static Size2D operator *(Size2D a, Size2D b)
		{
			return new Size2D(a.Width * b.Width, a.Height * b.Height);
		}

		public static Size2D operator *(Size2D a, float b)
		{
			return new Size2D(a.Width * b, a.Height * b);
		}
	}
}
