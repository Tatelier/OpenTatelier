#pragma once

class Input;

class InputControlItem {
	bool enabled;

protected:
	Input* input;

public:
	virtual int GetCount(int keyCode);
	virtual bool GetKey(int keyCode);
	virtual bool GetKeyDown(int keyCode);
	virtual bool GetKeyUp(int keyCode);
	bool IsEnabled();
	void SetEnbaled(bool value);
	InputControlItem();
};
