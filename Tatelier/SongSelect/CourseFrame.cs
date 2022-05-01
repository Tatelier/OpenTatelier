using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	class CourseFrame
	{
		public int[] Handles;
		public CourseFrame(string folder)
		{
			Handles = new int[]
			{
				ImageLoadControl.Singleton.Load(Path.Combine(folder,@"SongSelect\CourseFrame\Easy.png")),
				ImageLoadControl.Singleton.Load(Path.Combine(folder,@"SongSelect\CourseFrame\Normal.png")),
				ImageLoadControl.Singleton.Load(Path.Combine(folder,@"SongSelect\CourseFrame\Hard.png")),
				ImageLoadControl.Singleton.Load(Path.Combine(folder,@"SongSelect\CourseFrame\Oni.png")),
				ImageLoadControl.Singleton.Load(Path.Combine(folder,@"SongSelect\CourseFrame\Ura.png")),
				ImageLoadControl.Singleton.Load(Path.Combine(folder,@"SongSelect\CourseFrame\Other.png")),
			};
		}
		~CourseFrame()
		{
			ImageLoadControl.Singleton.Delete(Handles);
		}
	}
}
