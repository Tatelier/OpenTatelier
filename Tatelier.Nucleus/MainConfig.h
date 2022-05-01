#pragma once
#include <string>

class MainConfig {
	MainConfig(const MainConfig& a) { }
	MainConfig() { }

	std::string themeFolderPath = "Resources/Theme/v1";

public:
	static MainConfig& GetInstance()
	{
		static MainConfig instance;
		return instance;
	}
	const std::string& GetThemeFolderPath()
	{
		return themeFolderPath;
	}
};
