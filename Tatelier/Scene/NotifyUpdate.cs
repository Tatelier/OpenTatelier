using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.Scene
{
	class NotifyUpdate
		: SceneBase
	{
		public override int CommandSearchAndRun(string command, params string[] args)
		{
			return 0;
		}
		bool isStart = false;
		public override void Start()
		{


			isStart = true;
		}

		public override void Update()
		{
			if (!isStart)
			{
				Start();
			}
		}

		public override void Draw()
		{
		}

		public override void Finish()
		{
		}

	}
}
