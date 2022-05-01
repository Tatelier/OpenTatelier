#pragma once
class Theme {
	float mag = 1;

public:
	float GetMagnification()
	{
		return mag;
	}
	int GetDrawWidth()
	{
		return 1920;
	}
	int GetDrawHeight()
	{
		return 1080;
	}
	int DrawCircleGaugeF(float CenterX, float CenterY, double Percent, int GrHandle, double StartPercent, double Scale, int ReverseX, int ReverseY);
	int DrawCircleAA(float x, float y, float r, int posnum, unsigned int Color, int FillFlag, float LineThickness);
};

class ThemeControl {
	Theme theme;

public:
	static ThemeControl& GetInstance()
	{
		static ThemeControl instance;
		return instance;
	}
	Theme* GetNowTheme()
	{
		return &theme;
	}
};
