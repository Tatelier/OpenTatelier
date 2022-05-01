#include "Input.h"

int Input::GetCount(int key)
{
	return cntBytes[key];
}

Input& Input::GetInstance()
{
	static Input input;
	return input;
}

bool Input::GetKey(int key)
{
	return GetCount(key) > 0;
}

bool Input::GetKeyUp(int key)
{
	return GetCount(key) == -1;
}

bool Input::GetKeyDown(int key)
{
	return GetCount(key) == 1;
}

void Input::Update()
{
	if (GetHitKeyStateAll(bytes) == 0) {
		for (int i = 0; i < BytesLen; i++) {
			if (bytes[i] > 0) {
				cntBytes[i]++;
			}
			else {
				if (cntBytes[i] > 0) {
					cntBytes[i] = -1;
				}
				else {
					cntBytes[i] = 0;
				}
			}
		}
	}
}
