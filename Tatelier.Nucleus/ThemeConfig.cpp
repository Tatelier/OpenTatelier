#include "ThemeConfig.h"

#include "hjson/hjson-ex.h"
#include "hjson/hjson.h"

ThemeConfig* ThemeConfig::instance = nullptr;

const Size2D& ThemeConfig::GetDrawMode()
{
	return drawMode;
}

const Size2D& ThemeConfig::GetDrawModeHalf()
{
	return drawModeHalf;
}

const Size2D& ThemeConfig::GetWindow()
{
	return window;
}

ThemeConfig::ThemeConfig()
{
	Hjson::Value hjson = HjsonEx::Load("Resources/Theme/v1/Theme.hjson");

	HjsonEx::EQi(hjson, "DrawMode.Width", &drawMode.Width, 1920);
	HjsonEx::EQi(hjson, "DrawMode.Height", &drawMode.Height, 1080);

	HjsonEx::EQi(hjson, "Window.Width", &window.Width, 960);
	HjsonEx::EQi(hjson, "Window.Height", &window.Height, 540);

	drawModeHalf.Width = drawMode.Width / 2;
	drawModeHalf.Height = drawMode.Height / 2;
}
