#pragma once

#include <memory>
#include <vector>

namespace SongSelect {
	class BackgroundInfo;
	class Background {
		struct FadeInfo {
			int Handle;
			int StartCount;
			int GetFadeVal(int nowCount, int time)
			{
				return (nowCount - StartCount) * 256.0F / time;
			}
			void Set(int startCount, int handle)
			{
				this->StartCount = startCount;
				this->Handle = handle;
			}
		};
		const int length = 8;
		int prevHandle;
		int Handle;
		int startIndex;
		int endIndex;
		int t = 60;
		int start = 0;
		float xf = 0;
		float yf = 0;
		FadeInfo fadeInfoList[8];

	public:
		void Change(std::shared_ptr<BackgroundInfo> info, int time = 300);
		void Update();
		void Draw();
		Background();
	};
}