#include "InputControlItem.h"

#include "Input.h"

int InputControlItem::GetCount(int keyCode)
{
	if (!this->IsEnabled())
		return 0;
	return input->GetCount(keyCode);
}

bool InputControlItem::GetKey(int keyCode)
{
	if (!this->IsEnabled())
		return false;
	return input->GetKey(keyCode);
}

bool InputControlItem::GetKeyDown(int keyCode)
{
	if (!this->IsEnabled())
		return false;
	return input->GetKeyDown(keyCode);
}

bool InputControlItem::GetKeyUp(int keyCode)
{
	if (!this->IsEnabled())
		return false;
	return input->GetKeyUp(keyCode);
}

bool InputControlItem::IsEnabled()
{
	return enabled;
}

void InputControlItem::SetEnbaled(bool value)
{
	enabled = value;
}

InputControlItem::InputControlItem()
{
	input = &Input::GetInstance();
}
