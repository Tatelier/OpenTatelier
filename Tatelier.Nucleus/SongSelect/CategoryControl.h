#pragma once

#include <memory>
#include <string>
#include <unordered_map>
#include <vector>

#include "Category.h"

namespace SongSelect {
	class CategoryControl {
		const char* const OtherCategoryKeyName = "\r";
		std::unordered_map<std::string, std::shared_ptr<SongSelect::Category>> categoryMap;
		std::string imageRootFolder;

	public:
		static CategoryControl* Create(const std::string& filePath);
		std::vector<std::shared_ptr<SongSelect::Category>> Get(const std::vector<std::string>& names);
		std::vector<std::shared_ptr<SongSelect::Category>> GetOther();
		const std::string& GetImageRootFolder();
		const std::unordered_map<std::string, std::shared_ptr<SongSelect::Category>>& GetCategoryMap();
		void Init(const std::string& filePath);
		~CategoryControl();
	};

}
