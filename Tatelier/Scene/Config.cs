using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.HtmlControl;
using Tatelier.Interface.Command;
using static DxLibDLL.DX;

namespace Tatelier.Scene
{
	class Config : SceneBase
	{
		public override SceneType SceneType => SceneType.Config;

		Body body;

		public static SceneBase Create() => new Config();

		public override ResultType CommandSearchAndRun(string command, params string[] args)
		{
			return 0;
		}

		public override void Start()
		{
			body = new Body();
		}

		public override void Update()
		{
		}

		public override void Draw()
		{

			body.Draw();
		}

		public override void Finish()
		{
		}

	}
}
