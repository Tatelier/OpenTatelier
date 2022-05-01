using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static DxLibDLL.DX;

namespace Tatelier
{
	class NormalImage
		: IImage
	{
		public int Handle = -1;

		public Pivot Pivot { get; set; }
		public Repeat Repeat { get; set; }

		float PivotPointX = 0;
		float PivotPointY = 0;

		public float PointX { get; set; }
		public float PointY { get; set; }

		public float ScaleX { get; set; } = 1;
		public float ScaleY { get; set; } = 1;

		public float Width { get; set; } = -1;
		public float Height { get; set; } = -1;

		public float Angle { get; set; } = 0;

		public void Draw()
		{
			switch (Repeat)
			{
				case Repeat.None:
					{
						DrawRectRotaGraphFast3F(
							PointX, PointY,
							0, 0,
							(int)Width, (int)Height,
							PivotPointX, PivotPointY,
							ScaleX, ScaleY,
							Angle, Handle, DX_TRUE);
					}
					break;
				case Repeat.Repeat:
					{
						DrawTileGraph((int)PointX, (int)PointY, (int)PointX + (int)Width, (int)PointY + (int)Height, 0, 0, Handle);
					}
					break;
			}
		}

		public void Set(string name, object val)
		{
			var dic = ImageMethodManager.Singleton.NormalImageSetMethodMap;
			if (dic[name](this, val))
			{

			}
		}

		public void Update(int time)
		{
		}

		public object Get(string name)
		{
			return 0;
		}


		~NormalImage()
		{
			ImageLoadControl.Singleton.Delete(Handle);
		}

		public NormalImage(XElement elem, string folderPath)
		{
			XAttribute attr;

			attr = elem.Attribute("FilePath");
			this.Set("Load", Path.Combine(folderPath, (string)attr ?? ""));

			attr = elem.Attribute("PointX");
			float xf = (float?)attr ?? 0.0F;
			PointX = xf;

			attr = elem.Attribute("PointY");
			float yf = (float?)attr ?? 0.0F;
			PointY = yf;

			attr = elem.Attribute("Pivot");
			var pivotStr = (string)attr ?? "";

			if (Enum.TryParse<Pivot>(pivotStr, out var pivot)) Pivot = pivot;
		}
		public NormalImage()
		{

		}
	}
}
