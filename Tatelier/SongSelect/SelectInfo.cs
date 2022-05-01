using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	class SelectInfo
	{
		public MusicalScoreSelectItem TJASelectItem;

		public PlayerInfo[] PlayerInfoList;


		public string[] CourseNames = Enumerable.Repeat("Oni", 8).ToArray();

		public double Speed { get; set; } = 1.0;
	}
}
