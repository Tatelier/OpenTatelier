#include "Category.h"

#include "../hjson/hjson-ex.h"

namespace SongSelect {
	const SongSelectItemType& Category::GetType()
	{
		return SongSelectItemType::Category;
	}

	const std::string& Category::GetName()
	{
		return name;
	}

	void Category::SetName(const std::string& value)
	{
		name = value;
	}

	const std::string& Category::GetDetail()
	{
		return detail;
	}

	const std::string& Category::GetImageFolder()
	{
		return imageFolder;
	}

	std::shared_ptr<std::vector<std::shared_ptr<Item>>> Category::GetItemList()
	{
		return itemList;
	}

	void Category::Add(std::shared_ptr<Item> item, std::string sortText)
	{
		std::string renewSortTextSplit[3];

		itemList->push_back(item);
	}

	const std::string& Category::GetTitle()
	{
		return name;
	}

	Category::Category(const Hjson::Value& json)
	{
		HjsonEx::EQs(json, "Name", &name);
		HjsonEx::EQs(json, "Detail", &detail);
		HjsonEx::EQs(json, "ImageFolder", &imageFolder);
		itemList = std::shared_ptr<std::vector<std::shared_ptr<Item>>>(new std::vector<std::shared_ptr<Item>>());
	}
	Category::Category()
	{
		itemList = std::shared_ptr<std::vector<std::shared_ptr<Item>>>(new std::vector<std::shared_ptr<Item>>());
		imageFolder = "Default";
	}
	Category::~Category()
	{
	}
}
