#pragma once

#include "DxLib.h"

class Input {
	static const int BytesLen = 256;

	char bytes[BytesLen];
	int cntBytes[BytesLen];

	Input() { }
	Input(const Input& instance) { }

public:
	static Input& GetInstance();

	int GetCount(int key);

	bool GetKey(int key);

	bool GetKeyUp(int key);

	bool GetKeyDown(int key);

	void Update();
};
