#include "Demo.h"

namespace SongSelect {
	void Demo::Stop()
	{
		StopSoundMem(handle);
	}
	void Demo::Start()
	{
	}
	void Demo::Play()
	{
		switch (demoStatus) {
		case DemoStatus::PlayOK: {
			int check = CheckSoundMem(handle);
			int checkAsync = CheckHandleASyncLoad(handle);

			if (check == 0) {
				SetSoundCurrentTime(startPosition, handle);
				PlaySoundMem(handle, DX_PLAYTYPE_BACK, 0);
			}
		} break;
		case DemoStatus::WaitDelay: {
			if (delay == 0) {
				demoStatus = DemoStatus::PlayOK;
			}
			else {
				delay--;
			}
		} break;
		case DemoStatus::Stop: {
			demoStatus = DemoStatus::WaitDelay;
		} break;
		}
	}
	void Demo::Update()
	{
		if (enabled) {
			Play();
		}
	}
	void Demo::Load(const char* path, int startPosition, bool isForce)
	{
		if (!isForce && strcmp(path, this->path) == 0)
			return;
		strcpy_s(this->path, PathStrMaxLen, path);
		this->startPosition = startPosition;
		demoStatus = DemoStatus::Stop;

		if (CheckSoundMem(handle) == 1) {
			DeleteSoundMem(handle);
			handle = -1;
		}

		SetUseASyncLoadFlag(TRUE);
		SetCreateSoundDataType(DX_SOUNDDATATYPE_MEMPRESS);
		handle = LoadSoundMem(path);
		SetCreateSoundDataType(DX_SOUNDDATATYPE_MEMNOPRESS);
		SetUseASyncLoadFlag(FALSE);
	}
	void Demo::SetDelayMasterFromFrame(int delayFrame)
	{
		this->delayMaster = delayFrame;
	}
	void Demo::ResetDelay()
	{
		this->delay = delayMaster;
	}
	bool Demo::IsPlaying()
	{
		return CheckSoundMem(handle) == 0;
	}
	bool Demo::IsEnabled()
	{
		return enabled;
	}
	void Demo::SetEnabled(bool value)
	{
		enabled = value;
		if (!enabled) {
			Stop();
		}
	}
	Demo::Demo()
	{
		path = (char*)malloc(PathStrMaxLen);
		memset(path, 0, PathStrMaxLen);
	}
	Demo::~Demo()
	{
		Stop();
		DeleteSoundMem(handle);
		handle = -1;
		free(path);
	}
}
