#pragma once

#include "DxLib.h"

class DrawAreaGuard {
	RECT area;

public:
	DrawAreaGuard();
	~DrawAreaGuard();
};

class DrawModeGuard {
	int drawMode;

public:
	DrawModeGuard();
	~DrawModeGuard();
};

class DrawBlendModeGuard {
	int BlendMode;
	int BlendParam;

public:
	DrawBlendModeGuard();
	~DrawBlendModeGuard();
};

class DrawScreenGuard {
	int screen;

public:
	DrawScreenGuard();
	~DrawScreenGuard();
};