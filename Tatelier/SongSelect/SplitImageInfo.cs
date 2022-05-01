using System.Linq;
using Tatelier.DxLibDLL;
using static DxLibDLL.DX;
using HjsonEx;

namespace Tatelier.SongSelect
{
	class SplitImageInfo
	{
		public float X = 0;
		public float Y = 0;
		public float[] SplitX;
		public float[] SplitY;
		public float[] SplitWidth;
		public float[] SplitHeight;
		public int ContentAlpha = 255;
		public int Handle = -1;
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

		void RefreshWidth()
		{
			SplitWidth[0] = width;
		}

		void RefreshHeight()
		{
			for (int i = 0; i < SplitHeight.Length; i++)
			{
				SplitHeight[i] = SplitY[i + 1] - SplitY[i];
			}
			SplitHeight[1] = Height - SplitHeight[0] - SplitHeight[2];
		}

		public void Draw(float baseX, float baseY)
		{
			using (DrawModeGuard.Create())
			using (DrawBlendModeGuard.Create())
			{
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, ContentAlpha);
				SetDrawMode(DX_DRAWMODE_BILINEAR);

				float tempX = X;

				var pivot = Pivot.Center;

				switch (pivot)
				{
					case Pivot.Center: tempX -= (float)(Width * 0.5F); break;
				}
				for (int x = 0; x < SplitX.Length - 1; x++)
				{
					float tempY = Y;
					switch (pivot)
					{
						case Pivot.Center: tempY -= (float)(Height * 0.5F); break;
					}
					for (int y = 0; y < SplitY.Length - 1; y++)
					{
						DrawRectModiGraphF(
							tempX + baseX, tempY + baseY,
							tempX + SplitWidth[x] + baseX, tempY + baseY,
							tempX + SplitWidth[x] + baseX, tempY + SplitHeight[y] + baseY,
							tempX + baseX, tempY + SplitHeight[y] + baseY,
							(int)SplitX[x], (int)SplitY[y],
							(int)(SplitX[x + 1] - SplitX[x]), (int)(SplitY[y + 1] - SplitY[y]),
							Handle, DX_TRUE);
						tempY += SplitHeight[y];
					}
					tempX += SplitWidth[x];
				}
			}
		}

		public void DrawCategory(int handle)
		{
			float tempX = X;

			var pivot = Pivot.Center;

			switch (pivot)
			{
				case Pivot.Center: tempX -= (float)(Width * 0.5F); break;
			}
			for (int x = 0; x < SplitX.Length - 1; x++)
			{
				float tempY = Y;
				switch (pivot)
				{
					case Pivot.Center: tempY -= (float)(Height * 0.5F); break;
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
						handle, DX_TRUE);
					tempY += SplitHeight[y];
				}
				tempX += SplitWidth[x];
			}
		}
		~SplitImageInfo()
		{
			ImageLoadControl.Singleton.Delete(Handle);
		}
		public SplitImageInfo(Hjson.JsonValue json)
		{
			int width = json.EQi("Width") ?? 100;
			int height = json.EQi("Height") ?? 100;

			var dic = Share.Singleton.CreateVariableMap();

			dic["Width"] = width;
			dic["Height"] = height;

			var splitX = new float[1].Concat(json.EQa("SplitWidth").Select(v =>
			{
				return Common.Utility.CalcFromString(v.EQs(), dic);
			}));

			var splitY = new float[1].Concat(json.EQa("SplitHeight").Select(v =>
			{
				return Common.Utility.CalcFromString(v.EQs(), dic);
			}));

			SplitX = splitX.ToArray();
			for (int i = 0; i < SplitX.Length - 1; i++)
			{
				SplitX[i + 1] += SplitX[i];
			}

			SplitY = splitY.ToArray();
			for (int i = 0; i < SplitY.Length - 1; i++)
			{
				SplitY[i + 1] += SplitY[i];
			}

			SplitWidth = new float[SplitX.Length - 1];
			SplitHeight = new float[SplitY.Length - 1];

			Width = width;
			Height = height;
		}
	}
}
