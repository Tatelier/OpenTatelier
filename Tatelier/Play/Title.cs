using HjsonEx;
using System;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
	class Title : IDisposable
	{
		bool disposed = false;

		int handle = -1;

		float pointX;
		float pointY;
		int fontSize = 0;

		public void Draw()
		{
			GetGraphSize(handle, out var w, out var h);
			DrawGraphF(pointX - w, pointY - h, handle, DX_TRUE);
		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					ImageLoadControl.Singleton.Delete(handle);
				}

				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~Title()
		{
			Dispose();
		}

		public void Set(string title)
		{
			ImageLoadControl.Singleton.Delete(handle);

			handle = Utility.GetImageHandleFromText(title, 0xEFEFEF, MainConfig.Singleton.DefaultFont, fontSize);
		}

		public Title(string title, Hjson.JsonValue json)
		{
			if (json == null)
			{
				return;
			}
			pointX = json.EQf("PointX") ?? 0;
			pointY = json.EQf("PointY") ?? 0;
			fontSize = json.EQi("FontSize") ?? 16;

			Set(title);
		}
	}
}
