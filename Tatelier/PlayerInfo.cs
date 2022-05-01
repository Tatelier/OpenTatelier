using HjsonEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.SongSelect;

namespace Tatelier
{
	public class PlayerInfo
	{
		public string FilePath = "";

		/// <summary>
		/// プレイヤーNo
		/// </summary>
		public int PlayerNumber = 1;

		/// <summary>
		/// 名前
		/// </summary>
		public string Name = "";

		/// <summary>
		/// 
		/// </summary>
		public string UniqueID = "";

		public Hjson.JsonValue Json { get; }


		public int? NoteRandomSeed { get; set; } = null;

		public int NoteRandomRatio { get; set; } = 30;

		public PlayOption PlayOption = new PlayOption();

		public PlayerInfo(string filePath)
		{
			FilePath = filePath;

			var hjson = HjsonEx.HjsonEx.LoadEx(filePath) ?? new Hjson.JsonObject();
			Json = hjson;

			Name = hjson?.EQs("Name") ?? "Undefined";
		}

		public PlayerInfo()
		{

		}
	}
}
