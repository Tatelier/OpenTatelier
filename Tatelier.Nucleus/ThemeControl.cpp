#include "ThemeControl.h"

#include "DxLib.h"

int Theme::DrawCircleGaugeF(float CenterX, float CenterY, double Percent, int GrHandle, double StartPercent, double Scale, int ReverseX, int ReverseY)
{
	return ::DrawCircleGaugeF(CenterX * mag, CenterY * mag, Percent, GrHandle, StartPercent, Scale, ReverseX, ReverseY);
}

int Theme::DrawCircleAA(float x, float y, float r, int posnum, unsigned int Color, int FillFlag = TRUE, float LineThickness = 1.0f)
{
	return ::DrawCircleAA(x * mag, y * mag, r * mag, posnum, Color, FillFlag, LineThickness * mag);
}
