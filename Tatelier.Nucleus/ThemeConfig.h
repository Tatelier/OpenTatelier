#pragma once

#include "Size2D.h"

class ThemeConfig {
public:
	static void Start()
	{
		if (instance == nullptr) {
			instance = new ThemeConfig();
		}
	}
	static ThemeConfig& GetInstance()
	{
		return (*instance);
	}

	const Size2D& GetDrawMode();
	const Size2D& GetDrawModeHalf();
	const Size2D& GetWindow();

private:
	static ThemeConfig* instance;
	ThemeConfig();

	Size2D drawMode;
	Size2D drawModeHalf;
	Size2D window;
};
