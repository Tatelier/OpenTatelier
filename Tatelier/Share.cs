using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Common;
using Tatelier.SongSelect;

namespace Tatelier
{
	class Share
	{
		public static Share Singleton { get; private set; }

		public bool DebugDetailShowFlag { get; private set; } = false;

		public bool IsRepeat { get; internal set; } = false;
		public Tatelier.Result.ResultData[] Result { get; internal set; }

		public TokenInfo TokenInfo;

		int playerNum = 1;

		/// <summary>
		/// プレイヤー人数
		/// </summary>
		public int PlayerNum
		{
			get => playerNum;
			set
			{
				var prevPlayerNum = playerNum;
				playerNum = value;
				var playerData = PlayerData;

				for (int i = 0; i < playerData.Length; i++)
				{
					if (PlayerData[i] == null)
					{
						PlayerData[i] = new PlayerData();
					}
				}
			}
		}

		public string ScoreFilePath { get; internal set; }

		public float Speed = 1;

		public readonly Encoding SJIS = Encoding.GetEncoding("SHIFT_JIS");

		public SelectInfo SelectInfo = new SelectInfo();

		public PlayerData[] PlayerData;

		public Tatelier.SongSelect.PlayerScore PlayerScore = new PlayerScore();

		public Tatelier.SongSelect.SelectItemControl SongSelectItemControl;

		public Dictionary<string, float> CommonVariableMap;

		public Dictionary<string, float> CreateVariableMap()
		{
			return new Dictionary<string, float>(CommonVariableMap);
		}

		public Connect.AuthConnect Connect;

		public Task ConfigTask;

		static Share()
		{
			Singleton = new Share();
		}


		public void Start()
		{

			PlayerData = new PlayerData[MainConfig.Singleton.PlayerMaxNum];


			for (int i = 0; i < PlayerNum; i++)
			{
				PlayerData[i] = new PlayerData("Resources/Player/Default.hjson");
			}

			var config2 = new SongSelectConfig(new SongSelectConfig.Info()
			{
				Json = HjsonEx.HjsonEx.LoadEx(Path.Combine(MainConfig.Singleton.ThemeFolderPath, @"SongSelect\SongSelectConfig.hjson"))
			});

			if (config2?.SelectItemList.Count > 0)
			{
				SongSelectItemControl = new SelectItemControl(MainConfig.Singleton.ScoreFolderPath, config2.SelectItemList.FirstOrDefault());
			}

			CommonVariableMap = new Dictionary<string, float>()
			{
				{ "ScreenWidth", Supervision.ScreenWidth },
				{ "ScreenWidthHalf", Supervision.ScreenWidthHalf },
				{ "ScreenHeight", Supervision.ScreenHeight },
				{ "ScreenHeightHalf", Supervision.ScreenHeightHalf },
			};
		}

		public void Reset()
		{
			Singleton = new Share();
		}

		public Share()
		{
		}
	}
}
