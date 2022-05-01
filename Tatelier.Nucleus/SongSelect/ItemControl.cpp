#include "ItemControl.h"

#include "../Error.h"

#include "../Utility.h"
#include "ScoreOverview.h"

namespace SongSelect {
	ItemControl* ItemControl::Create(const std::string& folder, std::shared_ptr<CategoryControl> categoryControl)
	{
		err.clear();

		return new ItemControl(folder, categoryControl);
	}
	std::shared_ptr<std::vector<std::shared_ptr<Item>>> ItemControl::GetItemList()
	{
		return itemList;
	}
	const std::string& ItemControl::GetScoreFolder()
	{
		return scoreFolder;
	}
	ItemControl::ItemControl(const std::string& scoreFolder, std::shared_ptr<CategoryControl> categoryControl)
	{

		this->scoreFolder = scoreFolder;
		auto& categoryMap = categoryControl->GetCategoryMap();

		itemList = std::shared_ptr<std::vector<std::shared_ptr<Item>>>(new std::vector<std::shared_ptr<Item>>());

		for (auto category : categoryMap) {
			std::shared_ptr<Item> pointer = std::static_pointer_cast<Item>(category.second);
			if (std::find(itemList->begin(), itemList->end(), pointer) == itemList->end()) {
				itemList->push_back(pointer);
			}
		}

		std::filesystem::path scoreRootFolder;

		scoreRootFolder /= scoreFolder;
		scoreRootFolder /= "Root";

		std::vector<std::string> files;
		if (ttleGetFileNamesRecursive(scoreRootFolder.string(), &files, [](std::string a) {
			return ttleEndWithIndex(a, ".tja|.tlscore") > 0;
			})) {
			for (auto& str : files) {
				ScoreOverview::CreateAndRegist(scoreFolder, str, categoryControl);
			}
		}
	}
}