#pragma once

#include <memory>
#include <vector>

#include "SelectItem.h"

namespace SongSelect {
	class Category;
	class GenreSelectItem : public SelectItem {
	public:
		const std::vector<std::shared_ptr<SelectItem>>& GetSelectItemList();
		void SetOpen(bool isOpen);
		void SetParent(std::shared_ptr<GenreSelectItem> parent);
		std::shared_ptr<SelectItem> GetNowSelectItem();
		GenreSelectItem(std::shared_ptr<Category> category);
		std::shared_ptr<Category> GetGenre();
		virtual ~GenreSelectItem() override;
		virtual std::shared_ptr<BackgroundInfo> GetBackgroundInfo() override;
		virtual int SetThemeData(std::string imageFolder, const Hjson::Value& data) override;

	private:
		const std::string DefaultFolderName = "Default";
		bool isOpen = false;
		int titleImageHandle = -1;
		int detailImageHandle = -1;
		int backgroundHandle = -1;
		std::vector<int> itemBackgroundList;
		std::shared_ptr<BackgroundInfo> backgroundInfo;
		std::vector<std::shared_ptr<SelectItem>> selectItemList;
		std::shared_ptr<Category> genre;
		virtual SongSelectItemType GetType() override;
		virtual const std::string& GetMainTitle() override;
	};

}
