#pragma once

#include <string>

class ImageLoadControl {
public:
	static ImageLoadControl& GetInstance();
	int Load(const char* path);
	int Load(const std::string& path);
};