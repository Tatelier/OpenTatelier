
#include "Background.h"

#include "BackgroundInfo.h"

#include "../DxLibEx.h"
#include "../Guard.h"
#include "../Supervision.h"
#include "../hjson/hjson.h"
#include "DxLib.h"

#include "../ThemeConfig.h"

#include "../Supervision.h"

namespace SongSelect {

	void Background::Change(std::shared_ptr<BackgroundInfo> info, int time)
	{
		if (info.get() != nullptr) {
			prevHandle = info->Handle;
			Handle = info->Handle;
		}
		else {
			prevHandle = -1;
			Handle = -1;
		}
		endIndex++;
		fadeInfoList[endIndex].Set(Supervision::GetInstance().GetNowMillisecTime(), Handle);
	}

	void Background::Update()
	{
		if (startIndex >= length && endIndex >= length) {
			startIndex = startIndex % length;
			endIndex = endIndex % length;
		}

		xf += (float)((Supervision::GetInstance().GetNowMillisecTime() - start)) / t;
		start = Supervision::GetInstance().GetNowMillisecTime();
	}

	void Background::Draw()
	{
		int index = 0;
		for (int i = startIndex; i <= endIndex; i++) {
			index = i % length;
			{
				DrawBlendModeGuard blendGuard;
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, (int)fadeInfoList[index].GetFadeVal(Supervision::GetInstance().GetNowMillisecTime(), 300));
				//DrawBox(0, 0, 720, 720, 0xFFFFFF, TRUE);
				DrawTileGraph(0, 0, ThemeConfig::GetInstance().GetDrawMode().Width, ThemeConfig::GetInstance().GetDrawMode().Height, xf, yf, Handle);
			}
		}
	}

	Background::Background()
	{
		startIndex = 0;
		endIndex = 0;
		for (int i = 0; i < length; i++) {
			fadeInfoList[i].Set(INT32_MAX, -1);
		}
		fadeInfoList[0].Set(INT32_MAX, -1);

		start = Supervision::GetInstance().GetNowMillisecTime();
	}
}
