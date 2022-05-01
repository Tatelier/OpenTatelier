#pragma once

#include <memory>
#include <string>

namespace SongSelect {
	enum class SongSelectItemType {
		Root,
		Score,
		Category,
		Back,
	};
	class Item : public std::enable_shared_from_this<Item> {
	public:
		virtual const std::string& GetTitle() = 0;
		virtual const SongSelectItemType& GetType() = 0;
	};
}
