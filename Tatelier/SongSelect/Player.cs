using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	class Player
	{
		public PlayerInfo Info;

		public int Number;
		public int CourseIndex = -1;
		public bool IsCourseDecide = false;
		public InputControlItemSongSelect Input;
		public CourseSelectCursor Cursor;

		public SongSelect.Status Status;

		public PlayerMusicalScore PlayerMusicalScore;

		public PlayOptionRenderer PlayOptionRenderer;

		public Player(PlayerInfo info)
        {
			this.Info = info;
			PlayOptionRenderer = new PlayOptionRenderer();
			PlayOptionRenderer.PlayOption = Info.PlayOption;
		}

		public void Reset()
		{
			IsCourseDecide = false;
		}
	}
}
