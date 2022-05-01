#include "CategoryControl.h"
#include "../Error.h"

#include "../hjson/hjson-ex.h"
#include "../hjson/hjson.h"

namespace SongSelect {

	CategoryControl* CategoryControl::Create(const std::string& filePath)
	{
		err.clear();

		auto instance = new CategoryControl();
		instance->Init(filePath);

		return instance;
	}
	std::vector<std::shared_ptr<SongSelect::Category>> CategoryControl::Get(const std::vector<std::string>& names)
	{
		std::vector<std::shared_ptr<Category>> result;

		for (int i = 0; i < names.size(); i++) {
			if (categoryMap.find(names[i]) != categoryMap.end()) {
				result.push_back(categoryMap[names[i]]);
			}
		}

		return result;
	}
	std::vector<std::shared_ptr<SongSelect::Category>> CategoryControl::GetOther()
	{
		std::vector<std::shared_ptr<SongSelect::Category>> vector;
		vector.push_back(categoryMap[OtherCategoryKeyName]);
		return vector;
	}
	const std::string& CategoryControl::GetImageRootFolder()
	{
		return imageRootFolder;
	}
	const std::unordered_map<std::string, std::shared_ptr<SongSelect::Category>>& CategoryControl::GetCategoryMap()
	{
		return categoryMap;
	}
	void CategoryControl::Init(const std::string& filePath)
	{

		Hjson::Value hjson = HjsonEx::Load(filePath);
		HjsonEx::EQs(hjson, "ImageRootFolder", &imageRootFolder, "SongSelect/Genres");

		Hjson::Value arr_result;
		HjsonEx::EQa(hjson, "Genres", &arr_result);

		for (int index = 0; index < int(arr_result.size()); index++) {
			Hjson::Value item = arr_result[index];

			std::string name;
			HjsonEx::EQs(item, "Name", &name);

			auto category = std::shared_ptr<SongSelect::Category>(new SongSelect::Category(item));
			categoryMap.insert_or_assign(name, category);

			Hjson::Value arr_ambiguous;
			HjsonEx::EQa(item, "Ambiguous", &arr_ambiguous);

			for (int index2 = 0; index2 < arr_ambiguous.size(); index2++) {
				std::string amb;
				HjsonEx::EQs(arr_ambiguous[index2], "", &amb);
				categoryMap.insert_or_assign(amb, category);
			}
		}

		// ‚»‚Ì‘¼
		auto category = std::shared_ptr<SongSelect::Category>(new SongSelect::Category());
		categoryMap.insert_or_assign(OtherCategoryKeyName, category);
		categoryMap[OtherCategoryKeyName]->SetName("‚»‚Ì‘¼");
	}

	CategoryControl::~CategoryControl()
	{
	}
}