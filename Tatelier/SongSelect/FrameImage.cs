using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	class FrameImage
	{
		SliceImage Frame;

		public SliceImage InnerFrame;

		float width;

		public int Handle = -1;

		public float Width
		{
			get => width;
			set
			{
				width = value;
				Frame.Width = value;
			}
		}

		float height;
		public float Height
		{
			get => height;
			set
			{
				height = value;
				Frame.Height = value;
			}
		}

		float innerWidth;
		public float InnerWidth
		{
			get => innerWidth;
			set
			{
				innerWidth = value;
				InnerFrame.Width = value;
			}
		}

		float innerHeight;
		public float InnerHeight
		{
			get => innerHeight;
			set
			{
				innerHeight = value;
				InnerFrame.Height = value;
			}
		}

		public void Draw(float xf, float yf, float innerXf, float innerYf)
		{
			Frame.Draw(xf, yf);
			InnerFrame.Draw(innerXf, innerYf);
		}

		public FrameImage(string folder, bool isNewFormat)
		{
			Frame = new SliceImage(Path.Combine(folder, "ItemBackground01.png"), null);
			InnerFrame = new SliceImage(Path.Combine(folder, "ItemBackground02.png"), null);
			Handle = Frame.Handle;
		}

		public void Dispose()
		{
			using (Frame) { }
			using (InnerFrame) { }
		}
		~FrameImage()
		{
			Dispose();
		}
		public FrameImage(string folder)
		{
			Frame = new SliceImage(Path.Combine(folder, "Frame001.png"));
			InnerFrame = new SliceImage(Path.Combine(folder, "Frame002.png"));
			Handle = Frame.Handle;
		}
	}
}
