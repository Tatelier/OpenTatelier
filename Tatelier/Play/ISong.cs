using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Play
{
	interface ISong
	{
		int CurrentTime { get; set; }

		void Play();

		void Update();

		void Stop();

		void Pause();

		bool IsNowPause { get; }

		bool IsEnd { get; }
	}
}
