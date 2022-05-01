#include "SelectItemControl.h"

#include "../Error.h"
#include "GenreSelectItem.h"
#include "ItemControl.h"
#include "ScoreOverview.h"
#include "ScoreSelectItem.h"
#include "SelectItem.h"
#include <typeinfo>

#include "../hjson/hjson-ex.h"
#include "../hjson/hjson.h"

namespace SongSelect {

	SelectItemControl::SelectItemControl()
	{
	}
	void SelectItemControl::Set()
	{
		int nowIndex = 0;

		for (auto it = itemList->begin(); it != itemList->end(); it++) {
			auto type = (*it)->GetType();
			switch (type) {
			case SongSelectItemType::Category: {
				std::shared_ptr<Category> genre = std::dynamic_pointer_cast<Category>(*it);
				std::shared_ptr<GenreSelectItem> genreSelectItem(new GenreSelectItem(genre));
				genreSelectItem->SetParent(genreSelectItem);
				rootSelectItem.push_back(std::static_pointer_cast<SelectItem>(genreSelectItem));
			} break;
			case SongSelectItemType::Score: {
				std::shared_ptr<ScoreOverview> score = std::dynamic_pointer_cast<ScoreOverview>(*it);
				std::shared_ptr<ScoreSelectItem> scoreSelectItem(new ScoreSelectItem(score));
				rootSelectItem.push_back(std::static_pointer_cast<SelectItem>(scoreSelectItem));
			} break;
			}
		}

		for (int i = 0; i < rootSelectItem.size(); i++) {
			rootSelectItem.at(i)->SetNext(rootSelectItem.at((i + 1) % rootSelectItem.size()));
			rootSelectItem.at(i)->SetPrev(rootSelectItem.at((i + (rootSelectItem.size() - 1)) % rootSelectItem.size()));
		}

		nowSelectItem = rootSelectItem[nowIndex];
	}
	void SelectItemControl::Init(std::shared_ptr<ItemControl> itemControl, const std::string& imageRootFolder)
	{
		itemList = itemControl->GetItemList();
		this->folder = itemControl->GetScoreFolder();
		this->imageRootFolder = imageRootFolder;
		Set();
	}
	SelectItemControl* SelectItemControl::Create(std::shared_ptr<ItemControl> itemControl, const std::string& imageRootFolder)
	{
		auto instance = new SelectItemControl();
		instance->Init(itemControl, imageRootFolder);
		return instance;
	}
	std::shared_ptr<SelectItem> SelectItemControl::GetNowSelectItem()
	{
		return nowSelectItem;
	}
	void SelectItemControl::Prev()
	{
		nowSelectItem = nowSelectItem->GetPrev();
	}
	void SelectItemControl::Next()
	{
		nowSelectItem = nowSelectItem->GetNext();
	}
	bool SelectItemControl::Open()
	{
		switch (nowSelectItem->GetType()) {
		case SongSelectItemType::Category: {
			auto genre = std::dynamic_pointer_cast<GenreSelectItem>(nowSelectItem);
			if (genre->GetSelectItemList().size() > 0) {
				genre->SetOpen(true);
				if (rootSelectItem.size() > 1) {
					if (genre->GetSelectItemList().size() > 1) {
						auto next = genre->GetNext();
						auto prev = genre->GetPrev();

						next->SetPrev((*(genre->GetSelectItemList().end() - 1)));
						(*(genre->GetSelectItemList().end() - 1))->SetNext(next);

						prev->SetNext((*(genre->GetSelectItemList().begin())));
						(*(genre->GetSelectItemList().begin()))->SetPrev(prev);
					}
					else {
						auto& first = (*(genre->GetSelectItemList().begin()));
						auto next = genre->GetNext();
						auto prev = genre->GetPrev();

						first->SetNext(genre->GetNext());
						first->SetPrev(genre->GetPrev());

						next->SetPrev(first);
						prev->SetNext(first);
					}
				}
				else {
					if (genre->GetSelectItemList().size() > 1) {
						(*(genre->GetSelectItemList().end() - 1))->SetNext((*(genre->GetSelectItemList().begin())));
						(*(genre->GetSelectItemList().begin()))->SetPrev((*(genre->GetSelectItemList().end() - 1)));
					}
					else {
						auto& first = (*(genre->GetSelectItemList().begin()));
						first->SetNext(first);
						first->SetPrev(first);
					}
				}
				nowSelectItem = (*(genre->GetSelectItemList().begin()));
				return true;
			}
			else {
				return false;
			}
		} break;
		case SongSelectItemType::Back: {
			return Close();
		} break;
		default: {
			return true;
		} break;
		}
	}
	bool SelectItemControl::Close()
	{
		std::shared_ptr<ScoreSelectItem> score = std::dynamic_pointer_cast<ScoreSelectItem>(nowSelectItem);
		if (score.get() != nullptr) {
			auto genre = score->GetParentGenre();
			genre->SetOpen(false);
			nowSelectItem = std::shared_ptr<SelectItem>(genre->GetNowSelectItem());

			if (rootSelectItem.size() > 1) {
				auto& first = (*(genre->GetSelectItemList().begin()));
				auto& last = (*(genre->GetSelectItemList().end() - 1));

				first->GetPrev()->SetNext(genre);
				last->GetNext()->SetPrev(genre);

				genre->SetPrev(first->GetPrev());
				genre->SetNext(last->GetNext());
			}
			else {
				auto next = genre->GetNext();
				auto prev = genre->GetPrev();
				next->SetPrev(genre);
				prev->SetNext(genre);
			}
			nowSelectItem = genre;
			return true;
		}
		else {
			return false;
		}
		return false;
	}
	void SelectItemControl::SetThemeData(std::string themeFolder, const Hjson::Value& data)
	{
		std::filesystem::path path;
		path /= themeFolder;
		path /= imageRootFolder;
		std::string imageFolder = path.string();

		for (auto it = rootSelectItem.begin(); it != rootSelectItem.end(); it++) {
			auto& item = *it;
			if (item->GetType() == SongSelectItemType::Category) {
				item->SetThemeData(imageFolder, data);
			}
		}
	}
}