#pragma once

#include "Item.h"
#include <memory>
#include <string>
#include <vector>

namespace Hjson {
	class Value;
}

namespace SongSelect {
	class Category : public Item, std::enable_shared_from_this<Category> {
		bool isOpen = false;
		std::string name;
		std::string detail;
		std::string imageFolder;
		std::shared_ptr<std::vector<std::shared_ptr<Item>>> itemList;

	public:
		const SongSelectItemType& GetType();
		const std::string& GetName();
		void SetName(const std::string& value);
		const std::string& GetDetail();
		const std::string& GetImageFolder();
		std::shared_ptr<std::vector<std::shared_ptr<Item>>> GetItemList();
		void Add(std::shared_ptr<Item> item, std::string sortText);
		virtual const std::string& GetTitle() override;
		Category(const Hjson::Value& value);
		Category();
		~Category();
	};
}