#include <vector>
#include <windows.h>

#include "DxLib.h"

#include "SceneControlMaster.h"
#include "Supervision.h"

#include "SongSelect/CategoryControl.h"

#include "Input.h"

#include "Utility.h"

#include "MyMessageBox.h"

Supervision& Supervision::GetInstance()
{
	static Supervision instance;
	return instance;
}

int32_t Supervision::CommandSearchAndRun(const char* command, ...)
{
	return 0;
}

void Supervision::Start()
{
	this->sceneControl = &SceneControlMaster::GetInstance();
	this->sceneControl->Start();
	std::vector<std::string> list;
	if (ttleGetFileNamesRecursive("Resources", &list, [](const std::string& a) {
		return ttleEndWithIndex(a, ".tja|.tlscore") > 0;
		})) {
	}
	//MyMessageBox::GetInstance().Start();
	//auto messageInfo = new MyMessageBoxInfo();
	//auto messageItemInfo = MyMessageBoxItemInfo();
	//messageItemInfo.Callback = [this]() {
	//
	//};
	//messageItemInfo.Name = "Undefined2";
	//messageInfo->SetText("—áŠO");
	//messageInfo->SsetMessageType(MyMessageType::Error);
	//messageInfo->Add(messageItemInfo);
	//messageInfo->Add(messageItemInfo);
	//MyMessageBox::GetInstance().Open(std::shared_ptr<MyMessageBoxInfo>(messageInfo));
}

void Supervision::Update()
{
	nowMicroSecTime = GetNowHiPerformanceCount();
	nowMillisecTime = (int)(nowMicroSecTime / 1000);

	this->sceneControl->Update();
	Input::GetInstance().Update();
	MyMessageBox::GetInstance().Update();
}

void Supervision::Draw()
{
	this->sceneControl->Draw();
	MyMessageBox::GetInstance().Draw();
}

int64_t Supervision::GetNowMicroTime()
{
	return nowMicroSecTime;
}

int32_t Supervision::GetNowMillisecTime()
{
	return nowMillisecTime;
}