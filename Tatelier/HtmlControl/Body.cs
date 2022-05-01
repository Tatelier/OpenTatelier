using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.HtmlControl
{
	class Body
	{
		float[] margin = new float[]
		{
			10, 10, 10, 10
		};

		Checkbox checkbox = new Checkbox();

		public void Draw()
		{
			DrawBox(0, 0, Supervision.ScreenWidth, Supervision.ScreenHeight, 0xFFFFFF, DX_TRUE);

			float xf = margin[0];
			float yf = margin[1];

			checkbox.Draw(xf, yf);
		}

		public Body()
		{

		}
	}
}
