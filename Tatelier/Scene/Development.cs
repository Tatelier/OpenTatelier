using System;
using Tatelier.SongSelect;
using static DxLibDLL.DX;
using Tatelier.Interface.Command;
using Tatelier.Interface;

namespace Tatelier.Scene
{
	class Development : SceneBase
	{
		public override SceneType SceneType => SceneType.Develop;

		public static SceneBase Create() => new Development();


		public override ResultType CommandSearchAndRun(string command, params string[] args)
		{
			return 0;
		}


		public override void Start()
		{
			var mainConfig = MainConfig.Singleton;

			mainConfig.Save("A.hjson");

			Supervision.CommandSearchAndRun("/remote");
		}

		public override void Update()
		{

		}
		public override void Draw()
		{

		}

		public override void Finish()
		{

		}
	}
}
