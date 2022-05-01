using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier
{
	sealed class Image3
		 : IDisposable
	{
		public int Handle { get; private set; } = -1;
		public Transform Transform { get; set; }

		public float X1 => Transform.Point.X;

		public float Y1 => Transform.Point.Y;

		public float Y2 => Transform.Point.Y + Size.Height;

		Pivot pivotType = Pivot.TopLeft;

		public Pivot PivotType
		{
			get => pivotType;
			set
			{
				switch (value)
				{
					case Pivot.TopLeft:
						Transform.PivotPoint = (0, 0);
						break;
					case Pivot.Center:
						var size = SizeF;
						Transform.PivotPoint = (size.Width / 2, size.Height / 2);
						break;
				}
			}
		}

		/// <summary>
		/// サイズ(float)
		/// </summary>
		public (float Width, float Height) SizeF
		{
			get
			{
				GetGraphSizeF(Handle, out var w, out var h);
				return (Width: w, Height: h);
			}
		}

		/// <summary>
		/// サイズ(int)
		/// </summary>
		public (int Width, int Height) Size
		{
			get
			{
				GetGraphSize(Handle, out var w, out var h);
				return (Width: w, Height: h);
			}
		}

		public void Draw()
		{
			var size = Size;
			DrawRectRotaGraphFast3F(
				Transform.Point.X, Transform.Point.Y,
				0, 0,
				size.Width, size.Height,
				Transform.PivotPoint.X, Transform.PivotPoint.Y,
				Transform.Scale.X, Transform.Scale.Y,
				0, Handle, DX_TRUE);
		}

		void Dispose(bool disposing)
		{
			if (Handle != -1)
			{
				if (disposing)
				{
					ImageLoadControl.Singleton.Delete(Handle);
				}
				Handle = -1;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~Image3()
		{
			Dispose();
		}

		public void Set(string filePath = "")
		{
			ImageLoadControl.Singleton.Delete(Handle);
			Handle = ImageLoadControl.Singleton.Load(filePath);
		}

		public Image3(string filePath = "")
		{
			Set(filePath);
			Transform = new Transform();
		}
	}
}
