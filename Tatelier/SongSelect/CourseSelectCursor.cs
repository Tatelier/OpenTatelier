using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.SongSelect
{
	class CourseSelectCursor
	{
		int frame;
		int playerNumber;

		public void Draw(float xf, float yf)
		{
			DrawRotaGraphF(xf, yf, 1.0, 0.0, frame, DX_TRUE);
			DrawRotaGraphF(xf, yf - 13, 1.0, 0.0, playerNumber, DX_TRUE);
		}


		~CourseSelectCursor()
		{
			ImageLoadControl.Singleton.Delete(frame);
			ImageLoadControl.Singleton.Delete(playerNumber);
		}

		public CourseSelectCursor(string folder, Hjson.JsonValue json, int playerNumber, int side)
		{
			folder = Path.Combine(folder, "CourseSelectCursor");

			var player = json.EQa("Players").FirstOrDefault(v => (v.EQi("Number") ?? 1) == playerNumber);

			this.frame = ImageLoadControl.Singleton.Load(Path.Combine(folder, player.EQs("FrameImageFilePath") ?? "DefaultFrame.png"));
			this.playerNumber = ImageLoadControl.Singleton.Load(Path.Combine(folder, player.EQs("NumberImageFilePath") ?? "DefaultNumber.png"));
		}

		public CourseSelectCursor(string folder)
		{
			frame = ImageLoadControl.Singleton.Load(Path.Combine(folder, @"CourseSelectCursor\CursorFrame\Red.png"));
			playerNumber = ImageLoadControl.Singleton.Load(Path.Combine(folder, @"CourseSelectCursor\Player\1.png"));
		}
	}
}
