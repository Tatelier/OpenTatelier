#include "ScoreOverview.h"

#include <fstream>
#include <functional>
#include <iostream>
#include <memory>
#include <sstream>

#include "../Utility.h"

#define ARRAY_SIZE(X) (sizeof(X) / (sizeof(X[0])))

namespace SongSelect {
	void ScoreOverview::LoadTJA(const char* filePath, std::shared_ptr<CategoryControl> categoryControl)
	{

		struct K {
			std::string Name;
			std::function<void(const std::string& text)> Func;
		};
		K k[] = {
			{ "TITLE:", [this](const std::string& text) { this->title = ttleConvertToSjis(text); } },
			{ "WAVE:", [this](const std::string& text) { this->wave = ttleConvertToSjis(text); } },
			{ "GENRE:", [this, categoryControl](const std::string& text) {
				 std::stringstream ss { text };
				 std::string buf;
				 while (std::getline(ss, buf, '|')) {
					 this->categories.push_back(ttleConvertToSjis(buf));
				 }
				 this->categoryData = categoryControl->Get(this->categories);
			 } },
			{ "DEMOWAVE:", [this](const std::string& text) { this->demoMusicWave = ttleConvertToSjis(text); } },
		};

		std::ifstream ifs(filePath);

		//
		if (!ifs) {
			return;
		}

		std::string buf;
		while (!ifs.eof()) {
			if (std::getline(ifs, buf)) {
				for (int i = 0; i < ARRAY_SIZE(k); i++) {
					if (ttleStartWith(buf.c_str(), k[i].Name.c_str())) {
						k[i].Func(buf.replace(buf.find(k[i].Name), k[i].Name.size(), ""));
					}
				}
			}
		}

		if (categoryData.size() == 0) {
			categoryData = categoryControl->GetOther();
		}
		auto selectItem = shared_from_this();
		for (int i = 0; i < categoryData.size(); i++) {
			std::shared_ptr<ScoreOverview> p = std::dynamic_pointer_cast<ScoreOverview>(selectItem);
			categoryData[i]->Add(std::static_pointer_cast<Item>(p), "");
		}
	}
	ScoreOverview::ScoreOverview(const std::filesystem::path& scoreFolderPath, const std::filesystem::path& relativeFilePath, FileType fileType, std::shared_ptr<CategoryControl> categoryControl)
	{
		std::filesystem::path fp = scoreFolderPath / relativeFilePath;
		filePath = relativeFilePath.string();

		auto selectItem = std::shared_ptr<ScoreOverview>(this);

		switch (fileType) {
		case FileType::TatelierScore:
			break;
		case FileType::TJA:
			LoadTJA(filePath.c_str(), categoryControl);
			break;
		case FileType::OSU:
			break;
		}
	}
	const std::string& ScoreOverview::GetTitle()
	{
		return title;
	}
	ScoreOverview* ScoreOverview::CreateAndRegist(const std::filesystem::path& scoreFolderPath, const std::filesystem::path& relativeFilePath, std::shared_ptr<CategoryControl> categoryControl)
	{

		FileType type;
		switch (ttleEndWithIndex(relativeFilePath.string(), ".tja|.tlscore")) {
		case 1:
			type = FileType::TJA;
			break;
		case 2:
			type = FileType::TatelierScore;
			break;
		default:
			return nullptr;
		}

		return new ScoreOverview(scoreFolderPath, relativeFilePath, type, categoryControl);
	}
	const SongSelectItemType& ScoreOverview::GetType()
	{
		return SongSelectItemType::Score;
	}
}