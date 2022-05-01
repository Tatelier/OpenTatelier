#pragma once
#include <memory>
#include <string>
#include <vector>

#include "CategoryControl.h"

class CategoryControl;
class Item;

namespace SongSelect {
	class ItemControl {
		std::string scoreFolder;
		std::shared_ptr<std::vector<std::shared_ptr<Item>>> itemList;

	public:
		static ItemControl* Create(const std::string& folder, std::shared_ptr<CategoryControl> categoryControl);
		std::shared_ptr<std::vector<std::shared_ptr<Item>>> GetItemList();
		const std::string& GetScoreFolder();
		ItemControl(const std::string& scoreFolder, std::shared_ptr<CategoryControl> categoryControl);
	};
}
