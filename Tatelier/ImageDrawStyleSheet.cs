using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	enum B
	{
		Relative,
		Absolute,
		Fixed,
	}

	struct A
	{
		public Common.Transform Transform;

		public B Position;
		public Common.IImage Image;

		public A(Common.Transform transform, B position, Common.IImage image) : this()
		{
			Transform = transform;
			Position = position;
			Image = image;
		}

	}


	class ImageDrawStyleSheet
	{
		A[] list = new A[1];

		public void Draw(float xf, float yf)
		{
			foreach (var item in list)
			{
				switch (item.Position)
				{
					case B.Relative:
						item.Image.Draw(
							item.Transform.X + item.Transform.Margin.Left,
							item.Transform.Y + item.Transform.Margin.Top);

						break;
					case B.Absolute:
						item.Image.Draw(
							item.Transform.X + xf + item.Transform.Margin.Left,
							item.Transform.Y + yf + item.Transform.Margin.Top);
						break;
					case B.Fixed:
						item.Image.Draw(item.Transform.X, item.Transform.Y);
						break;
				}
			}
		}
	}
}
