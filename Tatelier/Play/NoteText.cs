using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score.Component.NoteSystem;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
    class NoteText
		: IDisposable, INoteText
	{
		bool disposed = false;

		int handle = -1;

		int itemWidth = 0;
		int itemHeight = 0;

		float relativePointCY = 0;


		public void Draw(float xf, float yf, NoteTextType noteTextType)
		{
			DrawRectRotaGraphFastF(xf, yf + relativePointCY, 0, ((int)noteTextType) * itemHeight, itemWidth, itemHeight, 1.0F, 0.0F, handle, DX_TRUE);
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
		~NoteText()
		{
			Dispose();
		}
		public NoteText(string folderPath, Hjson.JsonValue json)
		{
			if (json == null)
			{
				return;
			}

			folderPath = Path.Combine(folderPath, json.EQs("FolderPath") ?? "NoteText");

			handle = ImageLoadControl.Singleton.Load(Path.Combine(folderPath, "NoteText.png"));

			relativePointCY = json.EQf("RelativePointCY") ?? 0;

			GetGraphSize(handle, out var w, out var h);
			itemWidth = w;
			itemHeight = h / 9;
		}

		[Obsolete]
		public NoteText(string filePath)
		{
			handle = ImageLoadControl.Singleton.Load(filePath);
			itemHeight = 33;
		}
	}
}
