using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier
{
	class Mouse
	{
		public static Mouse Singleton = new Mouse();

		int x, y;
		public int X => x;
		public int Y => y;


		public float WheelRotF { get; private set; }

		public int LeftButton = 0;

		public void Update()
		{
			GetMousePoint(out x, out y);
			var input = GetMouseInput();
			WheelRotF = GetMouseWheelRotVolF();
			if ((input & MOUSE_INPUT_LEFT) != 0)
			{
				LeftButton++;
			}
			else
			{
				LeftButton = 0;
			}
		}

		public void Draw()
		{

		}
	}
}
