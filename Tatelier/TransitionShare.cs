using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Scene;

namespace Tatelier
{
	class TransitionShare
	{
		public static TransitionShare Singleton = new TransitionShare();

		public TransitionToPlay TransitionToPlay;

		public TransitionToResult TransitionToResult;

		public TransitionFromResultToSongSelect TransitionFromResultToSongSelect;

		public void Start()
		{
			SceneControl.Singleton.Create(out TransitionToPlay);
			TransitionToPlay.Regist(2.0F);

			SceneControl.Singleton.Create(out TransitionToResult);
			TransitionToResult.Regist(2.1F);

			SceneControl.Singleton.Create(out TransitionFromResultToSongSelect);
			TransitionFromResultToSongSelect.Regist(2.2F);
		}

		public void Reset()
		{
			Singleton = new TransitionShare();
		}
	}
}
