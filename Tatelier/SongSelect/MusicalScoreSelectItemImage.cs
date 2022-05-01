using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	class MusicalScoreSelectItemImage
	{
		public int TitleHandle { get; set; } = -1;

		public int SubTitleHandle { get; set; } = -1;

		~MusicalScoreSelectItemImage()
		{
			ImageLoadControl.Singleton.Delete(TitleHandle);
			ImageLoadControl.Singleton.Delete(SubTitleHandle);
		}
	}
}
