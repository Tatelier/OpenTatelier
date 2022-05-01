using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	interface IImage
	{
		Pivot Pivot { get; set; }

		float PointX { get; set; }
		float PointY { get; set; }

		float ScaleX { get; set; }
		float ScaleY { get; set; }

		float Width { get; set; }
		float Height { get; set; }

		float Angle { get; set; }

		void Set(string name, object val);
		object Get(string name);

		void Update(int time);
		void Draw();
	}
}
