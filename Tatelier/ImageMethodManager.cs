using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier
{
	using F = Func<NormalImage, object, bool>;

	class ImageMethodManager
	{
		public static readonly ImageMethodManager Singleton = new ImageMethodManager();

		public Dictionary<string, F> NormalImageSetMethodMap;


		F SetLoad { get; } = (img, obj) =>
		{
			ImageLoadControl.Singleton.Delete(img.Handle);
			img.Handle = ImageLoadControl.Singleton.Load($"{obj}");
			GetGraphSizeF(img.Handle, out var w, out var h);
			img.Width = w;
			img.Height = h;
			return true;
		};

		F SetWidth { get; } = (img, obj) =>
		{
			img.Width = Convert.ToSingle(obj);
			return true;
		};


		public ImageMethodManager()
		{
			NormalImageSetMethodMap
			= new Dictionary<string, F>()
			{
				{ "Load", SetLoad },
				{ "Width", SetWidth },
			};
		}
	}
}
