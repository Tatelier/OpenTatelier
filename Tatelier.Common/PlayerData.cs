using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tatelier.Common
{
	public class PlayerData
	{
		public string Name = "Default";

		public string TaikoImage = "Default";

		public bool IsAuto = false;

		public PlayerData()
		{
			Name = "no name";
			TaikoImage = "Default";
		}

		public PlayerData(string filePath)
		{

		}
	}
}
