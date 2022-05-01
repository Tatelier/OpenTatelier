using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;


namespace Tatelier.Result
{
	class Background
	{
		int handle;

		int titleHandle;

		float tx = 0.0F;

		public void Update()
		{
			GetGraphSizeF(handle, out var sx, out _);

			tx += -0.25F % sx;
		}

		public void Draw()
		{
			DrawTileGraph(0, 0, Supervision.ScreenWidth, Supervision.ScreenHeight, tx, 0, handle);
			DrawGraphF(0, 0, titleHandle, DX_TRUE);
		}
		~Background()
		{
			ImageLoadControl.Singleton.Delete(handle);
			ImageLoadControl.Singleton.Delete(titleHandle);
		}
		public Background(string folder, Hjson.JsonValue json)
		{
			handle = ImageLoadControl.Singleton.Load(System.IO.Path.Combine(folder, "Background/Background.png"));
			titleHandle = ImageLoadControl.Singleton.Load(System.IO.Path.Combine(folder, "Background/TitleBackground.png"));
		}
	}
}
