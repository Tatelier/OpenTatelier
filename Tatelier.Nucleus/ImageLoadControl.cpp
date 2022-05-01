#include "ImageLoadControl.h"

#include "DxLib.h"

ImageLoadControl& ImageLoadControl::GetInstance()
{
	static ImageLoadControl instance;

	return instance;
}

int ImageLoadControl::Load(const char* path)
{
	return LoadGraph(path);
}

int ImageLoadControl::Load(const std::string& path)
{
	return Load(path.c_str());
}
