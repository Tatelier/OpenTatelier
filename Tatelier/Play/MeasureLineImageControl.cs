using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score.Component.NoteSystem;

namespace Tatelier.Play
{
    class MeasureLineImageControl
	{
		int normalImage;

		int branchStartImage;

		public int GetHandle(MeasureLineType measureType)
		{
			switch (measureType)
			{
				case MeasureLineType.Normal:
				default:
					return normalImage;
				case MeasureLineType.BranchStart:
					return branchStartImage;
			}
		}

		public MeasureLineImageControl(string folderPath, Hjson.JsonValue json)
		{
			var img = ImageLoadControl.Singleton;

			if (json == null)
			{
				json = new Hjson.JsonObject();
			}

			folderPath = Path.Combine(folderPath, json.EQs("FolderPath") ?? "Bar");

			normalImage = img.Load(Path.Combine(folderPath, "Normal.png"));
			branchStartImage = img.Load(Path.Combine(folderPath, "BranchStart.png"));
		}

		~MeasureLineImageControl()
		{
			ImageLoadControl.Singleton.Delete(normalImage);
			ImageLoadControl.Singleton.Delete(branchStartImage);
		}
	}
}
