using HjsonEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class ThemeConfig
	{
		public static ThemeConfig Singleton = new ThemeConfig();

		public int ReturnWaitTime;

		public void Load(string filePath)
		{
			var json = HjsonEx.HjsonEx.LoadEx(filePath);

			ReturnWaitTime = json.EQi("Play.Pause.ReturnWaitTime") ?? 0;
		}
	}
}
