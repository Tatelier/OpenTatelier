#include "GenreSelectItem.h"
#include "ScoreSelectItem.h"

#include "Category.h"
#include "ScoreOverview.h"

#include "BackgroundInfo.h"

#include "../ImageLoadControl.h"
#include "../hjson/hjson-ex.h"

namespace SongSelect {
	const std::vector<std::shared_ptr<SelectItem>>& GenreSelectItem::GetSelectItemList()
	{
		return selectItemList;
	}

	void GenreSelectItem::SetOpen(bool isOpen)
	{
		this->isOpen = isOpen;
	}

	void GenreSelectItem::SetParent(std::shared_ptr<GenreSelectItem> parent)
	{
		for (int i = 0; i < selectItemList.size(); i++) {
			selectItemList[i]->SetParentGenre(parent);
		}
	}

	std::shared_ptr<SelectItem> GenreSelectItem::GetNowSelectItem()
	{
		if (!isOpen) {
			auto selectItem = shared_from_this();
			std::shared_ptr<GenreSelectItem> item = std::dynamic_pointer_cast<GenreSelectItem>(selectItem);
			return item;
		}
		else {
			return selectItemList[0];
		}
	}

	GenreSelectItem::GenreSelectItem(std::shared_ptr<Category> category)
		: SelectItem()
	{
		isOpen = false;
		genre = category;
		auto itemList = category->GetItemList();

		for (size_t i = 0; i < itemList->size(); i++) {
			std::shared_ptr<Item> item = itemList->at(i);

			switch (item->GetType()) {
			case SongSelectItemType::Category: {
				auto category = std::dynamic_pointer_cast<Category>(item);
				auto genreSelectItem = std::shared_ptr<GenreSelectItem>(new GenreSelectItem(category));
				selectItemList.push_back(std::static_pointer_cast<SelectItem>(genreSelectItem));
			} break;
			case SongSelectItemType::Score: {
				auto score = std::dynamic_pointer_cast<ScoreOverview>(item);
				auto scoreSelectItem = std::shared_ptr<ScoreSelectItem>(new ScoreSelectItem(score));
				selectItemList.push_back(std::static_pointer_cast<SelectItem>(scoreSelectItem));
			} break;
			}
		}

		for (size_t i = 0; i < selectItemList.size(); i++) {
			selectItemList.at(i)->SetNext(selectItemList.at((i + 1) % selectItemList.size()));
			selectItemList.at(i)->SetPrev(selectItemList.at((i + (selectItemList.size() - 1)) % selectItemList.size()));
		}
	}

	std::shared_ptr<Category> GenreSelectItem::GetGenre()
	{
		return genre;
	}

	GenreSelectItem::~GenreSelectItem()
	{
	}
	SongSelectItemType GenreSelectItem::GetType()
	{
		return SongSelectItemType::Category;
	}
	const std::string& GenreSelectItem::GetMainTitle()
	{
		return genre->GetName();
	}
	std::shared_ptr<BackgroundInfo> GenreSelectItem::GetBackgroundInfo()
	{
		return backgroundInfo;
	}
	int GenreSelectItem::SetThemeData(std::string themeFolder, const Hjson::Value& data)
	{
		std::string folder;

		if (this->GetType() != SongSelectItemType::Category) {
			if (GetParentGenre().get() != nullptr) {
				folder = GetParentGenre()->GetGenre()->GetImageFolder();
			}
			else {
				folder = DefaultFolderName;
			}
		}
		else {
			folder = genre->GetImageFolder();
		}

		std::string styleFilePath;

		{
			std::filesystem::path path;

			path /= themeFolder;
			path /= folder;
			path /= "style.hjson";

			styleFilePath = path.string();
		}

		if (std::filesystem::exists(styleFilePath)) {
			auto json = HjsonEx::Load(styleFilePath);
		}

		{
			titleImageHandle = -1;
		}

		{
			detailImageHandle = -1;
		}

		{
			std::filesystem::path path;

			path /= themeFolder;
			path /= folder;
			path /= "Background.png";

			backgroundHandle = ImageLoadControl::GetInstance().Load(path.string());

			backgroundInfo = std::shared_ptr<BackgroundInfo>(new BackgroundInfo());

			backgroundInfo->Handle = backgroundHandle;
		}

		{
			std::filesystem::path path;

			path /= themeFolder;
			path /= folder;

			std::string temp;

			for (int i = 0; i < data.size(); i++) {
				auto& item = data[i];
				HjsonEx::EQs(item, "FileName", &temp);
				itemBackgroundList.push_back(ImageLoadControl::GetInstance().Load((path / temp).string()));
			}
		}

		{
			for (auto& item : selectItemList) {
				item->SetThemeData(themeFolder, data);
			}
		}

		//for (auto it = selectItemList.begin(); it != selectItemList.end(); it++) {
		//	auto& item = *it;
		//	if (item->GetType() == SongSelectItemType::Category) {
		//		item->SetThemeData(themeFolder, data);
		//	}
		//}

		return 0;
	}
}