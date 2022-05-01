using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	class CourseSelectFrameControl
	{
		int[] handles = Enumerable.Repeat(-1, 6).ToArray();

		public int GetHandle(int i)
		{
			if (i > 4)
			{
				return handles[5];
			}
			return handles[i];
		}

		public CourseSelectFrameControl()
		{
			string folder = Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"SongSelect/CourseSelectFrame");

			handles[0] = ImageLoadControl.Singleton.Load(Path.Combine(folder, "Easy.png"));
			handles[1] = ImageLoadControl.Singleton.Load(Path.Combine(folder, "Normal.png"));
			handles[2] = ImageLoadControl.Singleton.Load(Path.Combine(folder, "Hard.png"));
			handles[3] = ImageLoadControl.Singleton.Load(Path.Combine(folder, "Oni.png"));
			handles[4] = ImageLoadControl.Singleton.Load(Path.Combine(folder, "Ura.png"));
			handles[5] = ImageLoadControl.Singleton.Load(Path.Combine(folder, "Other.png"));
		}

		~CourseSelectFrameControl()
		{
			ImageLoadControl.Singleton.Delete(handles);
		}
	}
}
