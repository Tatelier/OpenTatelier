#include "Guard.h"

DrawBlendModeGuard::DrawBlendModeGuard()
{
	GetDrawBlendMode(&BlendMode, &BlendParam);
}

DrawBlendModeGuard::~DrawBlendModeGuard()
{
	SetDrawBlendMode(BlendParam, BlendParam);
}

DrawScreenGuard::DrawScreenGuard()
{
	screen = GetDrawScreen();
}

DrawScreenGuard::~DrawScreenGuard()
{
	SetDrawScreen(screen);
}

DrawAreaGuard::DrawAreaGuard()
{
	GetDrawArea(&area);
}

DrawAreaGuard::~DrawAreaGuard()
{
	SetDrawArea(area.left, area.top, area.right, area.bottom);
}

DrawModeGuard::DrawModeGuard()
{
	drawMode = GetDrawMode();
}

DrawModeGuard::~DrawModeGuard()
{
	SetDrawMode(drawMode);
}
