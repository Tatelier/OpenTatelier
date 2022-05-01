#pragma once

#include <cstdlib>
#include <cstring>

#include "DxLib.h"

namespace SongSelect {

	class Demo {
		static const int PathStrMaxLen = 256;

		enum class DemoStatus {
			Stop,
			PlayOK,
			WaitDelay,
		};

		DemoStatus demoStatus = DemoStatus::Stop;

		bool enabled;

		int handle = -1;
		int startPosition;

		int delayMaster;
		int delay = 0;

		char* path;
		void Stop();

	public:
		void Start();
		void Play();
		void Update();

		/**
			 * @brief
			 */
		void Load(const char* path, int startPosition, bool isForce = false);

		void SetDelayMasterFromFrame(int delayFrame);

		void ResetDelay();

		bool IsPlaying();

		bool IsEnabled();

		void SetEnabled(bool value);

		Demo();
		~Demo();
	};
}