using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier
{
	class SliceImage : IDisposable
	{
		bool disposed = false;

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					// unmanaged
					ImageLoadControl.Singleton.Delete(Handle);
				}

				//managed
				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~SliceImage()
		{
			Dispose();
		}


		public int Handle;

		float width;
		public float Width
		{
			get => width;
			set
			{
				width = value;
				RefreshWidth();
			}
		}

		float height;
		public float Height
		{
			get => height;
			set
			{
				height = value;
				RefreshHeight();
			}
		}

		float[] SplitX;
		float[] SplitY;

		float[] SplitWidth;
		float[] SplitHeight;

		public Pivot Pivot = Pivot.TopLeft;

		public float X = 0;
		public float Y = 0;

		int hornSize;

		void RefreshWidth()
		{
			if (SplitWidth.Length == 1)
			{
				SplitWidth[0] = width;
			}
			else
			{
				SplitWidth[0] = hornSize;
				SplitWidth[1] = width - hornSize * 2;
				SplitWidth[2] = hornSize;
			}
		}

		void RefreshHeight()
		{
			SplitHeight[0] = hornSize;
			SplitHeight[1] = height - hornSize * 2;
			SplitHeight[2] = hornSize;
		}

		public void Draw(float xf, float yf)
		{
			float tempX = xf;
			switch (Pivot)
			{
				case Pivot.Center: tempX -= (float)(width * 0.5F); break;
			}
			for (int x = 0; x < SplitX.Length - 1; x++)
			{
				float tempY = yf;
				switch (Pivot)
				{
					case Pivot.Center: tempY -= (float)(height * 0.5F); break;
				}
				for (int y = 0; y < SplitY.Length - 1; y++)
				{
					DrawRectModiGraphF(
						tempX, tempY,
						tempX + SplitWidth[x], tempY,
						tempX + SplitWidth[x], tempY + SplitHeight[y],
						tempX, tempY + SplitHeight[y],
						(int)SplitX[x], (int)SplitY[y],
						(int)(SplitX[x + 1] - SplitX[x]), (int)(SplitY[y + 1] - SplitY[y]),
						Handle, DX_TRUE);
					tempY += SplitHeight[y];
				}
				tempX += SplitWidth[x];
			}
		}

		public SliceImage(string filePath, Hjson.JsonValue json)
		{
			this.hornSize = 48;
			Handle = ImageLoadControl.Singleton.Load(filePath);
			GetGraphSizeF(Handle, out width, out height);

			SplitX = new float[2];
			SplitX[0] = 0;
			SplitX[SplitX.Length - 1] = Width;

			SplitY = new float[4];
			SplitY[0] = 0;
			SplitY[1] = hornSize;
			SplitY[2] = Height - hornSize;
			SplitY[SplitY.Length - 1] = Height;

			SplitWidth = new float[1];
			RefreshWidth();

			SplitHeight = new float[3];
			RefreshHeight();
		}
		public SliceImage(string filePath, int hornSize = 48)
		{
			this.hornSize = hornSize;
			Handle = ImageLoadControl.Singleton.Load(filePath);
			GetGraphSizeF(Handle, out width, out height);

			SplitX = new float[4];
			SplitX[0] = 0;
			SplitX[1] = hornSize;
			SplitX[2] = Width - hornSize;
			SplitX[SplitX.Length - 1] = Width;

			SplitY = new float[4];
			SplitY[0] = 0;
			SplitY[1] = hornSize;
			SplitY[2] = Height - hornSize;
			SplitY[SplitY.Length - 1] = Height;

			SplitWidth = new float[3];
			RefreshWidth();

			SplitHeight = new float[3];
			RefreshHeight();
		}
	}
}
