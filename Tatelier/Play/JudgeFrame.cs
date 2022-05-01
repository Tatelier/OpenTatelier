using static DxLibDLL.DX;
using HjsonEx;
using System.IO;
using System;

namespace Tatelier.Play
{
	class JudgeFrame : IDisposable
	{
		bool disposed = false;

		int handle = -1;

		public void Draw(float cx, float cy)
		{
			DrawRotaGraphF(cx, cy, 1.0, 0.0, handle, DX_TRUE);
		}

		public JudgeFrame(string folder, Hjson.JsonValue json)
		{
			handle = ImageLoadControl.Singleton.Load(Path.Combine(folder, json.EQs("FilePath") ?? "JudgeFrame.png"));
		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if(disposing)
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

		~JudgeFrame()
		{
			Dispose();
		}
	}
}
