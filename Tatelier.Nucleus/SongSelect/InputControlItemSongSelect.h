#pragma once

#include "../InputControlItem.h"

namespace SongSelect {
	class InputControlItemSongSelect : InputControlItem {
	public:
		const static int Prev = -1;
		bool GetKey(int keyCode);
		InputControlItemSongSelect();
	};

}
