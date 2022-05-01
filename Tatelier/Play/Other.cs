using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
	class Other
	{
		NormalImage img = new NormalImage();

		public void Draw()
		{
			img.Draw();
		}


		public Other(string folderPath, Hjson.JsonValue json)
		{
			var elements = json.EQa("Elements");

			foreach (var elem in elements ?? HjsonEx.Empty.Array)
			{
				var im = elem.EQv("Image");
				img.Set("Load", Path.Combine(folderPath, im.EQs("FilePath") ?? ""));

				img.PointX = im.EQf("PointX") ?? 0.0F;
				img.PointY = im.EQf("PointY") ?? 0.0F;
			}
		}
	}
}
