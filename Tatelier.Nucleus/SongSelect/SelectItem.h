#pragma once

#include "../hjson/hjson.h"
#include "Item.h"
#include <memory>
#include <string>

namespace SongSelect {
	class GenreSelectItem;
	class BackgroundInfo;
	class SelectItem : public std::enable_shared_from_this<SelectItem> {
	public:
		std::shared_ptr<SelectItem> GetPrev();
		void SetPrev(std::shared_ptr<SelectItem> prev);
		std::shared_ptr<SelectItem> GetNext();
		void SetNext(std::shared_ptr<SelectItem> next);
		virtual SongSelectItemType GetType() = 0;
		virtual const std::string& GetMainTitle() = 0;
		std::shared_ptr<GenreSelectItem> GetParentGenre();
		void SetParentGenre(std::shared_ptr<GenreSelectItem> parent);
		virtual std::shared_ptr<BackgroundInfo> GetBackgroundInfo() = 0;
		virtual int SetThemeData(std::string imageFolder, const Hjson::Value& data);
		virtual ~SelectItem();
		SelectItem();

	private:
		std::string mainTitle;
		std::shared_ptr<SelectItem> prev;
		std::shared_ptr<SelectItem> next;
		std::shared_ptr<Item> item;
		std::shared_ptr<GenreSelectItem> parentGenre;
	};
}
