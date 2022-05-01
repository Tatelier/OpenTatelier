namespace Tatelier.Play
{
	class EmptySong : ISong
	{
		int startTime;

		int currentTime;

		int total;

		bool nowPlaying;

		public int CurrentTime
		{
			get => currentTime;
			set
			{
				currentTime = value;
				startTime = Supervision.NowMilliSec - currentTime;
			}
		}

		public bool IsEnd => currentTime >= (total);

		public bool IsNowPause { get; private set; }

		public void Pause()
		{
			nowPlaying = false;
			IsNowPause = true;
		}

		public void Play()
		{
			nowPlaying = true;
			IsNowPause = false;
		}

		public void Update()
		{
			if (nowPlaying)
			{
				currentTime = Supervision.NowMilliSec - startTime;
			}
			else
			{
				startTime = Supervision.NowMilliSec - currentTime;
			}
		}

		public void Stop()
		{

		}

		public EmptySong(int totalTime)
		{
			total = totalTime;
		}
	}
}
