using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Interface.Command;
using static DxLibDLL.DX;

namespace Tatelier.Scene
{
	class APNGDevelop : SceneBase
	{
		public static SceneBase Create() => new APNGDevelop();

		public override SceneType SceneType => SceneType.APNGDevelop;

		StringBuilder sb = new StringBuilder();
		public override ResultType CommandSearchAndRun(string command, params string[] args)
		{
			return 0;
		}

		public override void Draw()
		{
			//DrawBox(0, 0, Supervision.ScreenWidth, Supervision.ScreenHeight, 0xFFFFFF, TRUE);
			//image.Draw(0, 0);

			DrawString(0, 0, $"{sb}".Replace("\r", ""), 0xFFFFFF);
		}
		APNGImage image;
		public override void Finish()
		{
		}

		public override void Start()
		{
			image = new APNGImage(System.IO.Path.Combine(MainConfig.Singleton.ThemeFolderPath, "zoo.png"));

			foreach (var item in Enumerable.Repeat(1, 3))
			{
				byte[] ssid = new byte[]
				{
					0x31,
					0x32,
					0x33,
					0x34,
					0x35,
					0x00, //ここかな？
					0x01, //ここかな？
				};

				sb.Append(Encoding.ASCII.GetString(ssid.Where(v => v != 0x00).ToArray()));
				sb.AppendLine();
			}
		}

		public override void Update()
		{
			image.Update();
		}
	}
}
