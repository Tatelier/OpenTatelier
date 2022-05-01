#pragma once

#include <filesystem>
#include <iostream>
#include <string>

#include "CategoryControl.h"

namespace SongSelect {
	class ScoreOverview : public Item {
		enum class FileType;

		std::string title;
		std::string wave;

		std::vector<std::string> categories;

		std::string demoMusicWave;

		std::string filePath;
		std::vector<std::shared_ptr<Category>> categoryData;

		void LoadTJA(const char* filePath, std::shared_ptr<CategoryControl> categoryControl);
		ScoreOverview(const std::filesystem::path& scoreFolderPath, const std::filesystem::path& relativeFilePath, FileType fileType, std::shared_ptr<CategoryControl> categoryControl);

	public:
		enum class FileType {
			TatelierScore,
			TJA,
			OSU,
		};
		virtual const std::string& GetTitle() override;
		static ScoreOverview* CreateAndRegist(const std::filesystem::path& scoreFolderPath, const std::filesystem::path& relativeFilePath, std::shared_ptr<CategoryControl> categoryControl);
		virtual const SongSelectItemType& GetType() override;
	};
}
