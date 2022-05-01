using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Hjson;
using HjsonEx;
using Tatelier.Score;

namespace Tatelier.MainConfigElement
{
    public enum SongSelectSaveDataLoadingType
	{
		LoadsWhenSelectedAndUnloadsWhenRemoved,
		LoadWhenSelected,
		AsyncAllData,
		SyncAllData,
	}
	public class SongSelect
	{
		public SongSelectSaveDataLoadingType SaveDataLoadingType = SongSelectSaveDataLoadingType.LoadsWhenSelectedAndUnloadsWhenRemoved;

		public void InputJson(Hjson.JsonValue json)
		{
			SaveDataLoadingType = (SongSelectSaveDataLoadingType)(json?.EQi("SaveData.LoadingType") ?? 0);
		}

		public Hjson.JsonValue OutputJson()
		{
			var json = new Hjson.JsonObject();
			json["SaveData"] = new JsonObject();
			json["SaveData"]["LoadingType"] = (int)SaveDataLoadingType;

			return json;
		}
	}
}
namespace Tatelier
{
    /// <summary>
    /// メイン設定
    /// ※シングルトン
    /// </summary>
    partial class MainConfig
	{
		/// <summary>
		/// シングルトン
		/// </summary>
		public static MainConfig Singleton { get; } = new MainConfig("MainConfig.hjson");

		public IReadOnlyList<string> ScoreExtensionList { get; } = new string[] {
			".tja",
			".pts",
			".tlscore",
		};


		/// <summary>
		/// アップデートチェックをするかどうか
		/// </summary>
		public bool CheckUpdate { get; set; } = true;

		/// <summary>
		/// 音源の有無をチェックするかどうか
		/// </summary>
		public bool CheckExistWave { get; set; } = false;

		/// <summary>
		/// スプラッシュウィンドウを表示するかどうか
		/// </summary>
		public bool ShowSplashWindow { get; set; } = true;

		/// <summary>
		/// プレビュー有無
		/// </summary>
		public bool Preview = false;

		/// <summary>
		/// テーマフォルダパス
		/// </summary>
		public string ThemeFolderPath = @"Resources\Theme\v1";

		/// <summary>
		/// 譜面フォルダパス
		/// </summary>
		public string ScoreFolderPath = @"Resources\Score";

		/// <summary>
		/// デフォルトフォント
		/// </summary>
		public string DefaultFont = @"UD デジタル 教科書体 NK-B";

		/// <summary>
		/// 音楽再生有無
		/// </summary>
		public bool PlaySong = true;

		/// <summary>
		/// プレイヤー最大人数
		/// </summary>
		public int PlayerMaxNum = 16;

		/// <summary>
		/// デバッグモード有無
		/// </summary>
		public bool Debug = false;

		/// <summary>
		/// 譜面フォルダ監視
		/// / true: 監視する, false: しない
		/// </summary>
		public bool ScoreFolderWatch = false;

		/// <summary>
		/// デモ再生
		/// / true: 再生する, false: しない
		/// </summary>
		public bool Demo = false;

		/// <summary>
		/// XAudioを使用する
		/// </summary>
		public bool UseXAudio = false;

		/// <summary>
		/// 
		/// </summary>
		public ScoreType ForceChangeScoreType;

		public MainConfigElement.SongSelect SongSelect = new MainConfigElement.SongSelect();

		/// <summary>
		/// 
		/// </summary>
		public string ScreenshotsOutputFolder = "Screenshots";

		public PlayerInfo[] PlayerInfoList;

		public PlayerInfo[] GetPlayerInfoList(int playerCount)
		{
			return PlayerInfoList.Take(playerCount).ToArray();
		}

		/// <summary>
		/// テーマのルートからのパスを取得する
		/// </summary>
		/// <param name="relativePath">テーマのルートフォルダからの相対パス</param>
		/// <returns></returns>
		public string GetThemePath(string relativePath)
		{
			return Path.Combine(ThemeFolderPath, relativePath);
		}

		/// <summary>
		/// テーマのルートからのパスを取得する
		/// </summary>
		/// <param name="relativeFolderPath">テーマのルートフォルダからの相対パス</param>
		/// <returns></returns>
		public string GetThemePath(params string[] relativePath)
		{
			return Path.Combine(ThemeFolderPath, Path.Combine(relativePath));
		}

		public bool IsScoreFile(string fileName)
		{
			foreach (var item in ScoreExtensionList)
			{
				if (fileName.EndsWith(item))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// 初期化処理
		/// </summary>
		/// <returns></returns>
		public int Initialize()
        {
			return Define.OK;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="playerName"></param>
		/// <param name="scoreFilePath"></param>
		/// <returns></returns>
		public string GetScoreSaveDataFilePath(string playerName, string scoreFilePath)
		{
			string temp;
			string folder;

			var absoluteFilePath = Path.GetFullPath(scoreFilePath).Replace("/", "\\");
			var absoluteScoreFolder = (Path.GetFullPath(ScoreFolderPath) + "\\Root\\").Replace("/", "\\");

			bool excludeScore = false;

			if (absoluteFilePath.StartsWith(absoluteScoreFolder))
			{
				string tjaFilePath;
				tjaFilePath = Path.GetFullPath(scoreFilePath);
				temp = tjaFilePath.Replace(absoluteScoreFolder, "");
				folder = Path.GetDirectoryName(temp);
			}
            else
			{
				excludeScore = true;
				string fileName = Path.GetFileName(scoreFilePath);
				temp = fileName;
				folder = "";

			}

			if (folder.Length > 0)
			{
				folder += "\\";
			}
			string filePath = $"Save\\{playerName}\\Score\\{folder}{Path.GetFileNameWithoutExtension(temp)}.tlrsav";

			return filePath;
		}

		/// <summary>
		/// 遠隔ポート
		/// </summary>
		public int RemotePort = 62000;


		void Set(Hjson.JsonValue json)
        {
			RemotePort = json?.EQi("Remote.Port") ?? RemotePort;
			SongSelect.InputJson(json?.EQv("SongSelect"));
        }

		public void Save(string filePath)
        {
			var json = new Hjson.JsonObject();

			json["Theme"] = new Hjson.JsonObject();
			json["Theme"]["FolderPath"] = ThemeFolderPath;

			json["Score"] = new Hjson.JsonObject();
			json["Score"]["FolderPath"] = ScoreFolderPath;

			json["Font"] = new Hjson.JsonObject();
			json["Font"]["DefaultFont"] = DefaultFont;

			json["UseXAudio"] = UseXAudio;

			json["PlayerMaxNum"] = PlayerMaxNum;


			// PlayerInfoList
			{
				var players = new Hjson.JsonArray();

				for (int i = 0; i < PlayerInfoList.Length; i++)
				{
					players.Add(PlayerInfoList[i].FilePath);
				}

				json["Players"] = players;
			}

			//// Auto
			//{
			//	var autos = new Hjson.JsonArray();

			//	for (int i = 0; i < Auto.Length; i++)
			//	{
			//		autos.Add(Auto[i]);
			//	}

			//	json["Auto"] = autos;
			//}

			json["Demo"] = Demo;
			json["Debug"] = Debug;
			json["CheckUpdate"] = CheckUpdate;

			json["SongSelect"] = new Hjson.JsonObject();
			json["SongSelect"]["CheckWaveExist"] = CheckExistWave;
			json["SongSelect"] = SongSelect.OutputJson();

			json["Play"] = new Hjson.JsonObject();

			json["Remote"] = new Hjson.JsonObject();
			json["Remote"]["Port"] = RemotePort;

			json["Screenshot"] = new Hjson.JsonObject();
			json["Screenshot"]["OutputFolder"] = ScreenshotsOutputFolder;

			json.SaveEx(filePath);
        }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		MainConfig(string filePath)
		{
			JsonValue hj;

			hj = HjsonEx.HjsonEx.LoadEx(filePath);

			ThemeFolderPath = hj.EQs("Theme.FolderPath") ?? ThemeFolderPath;
			ScoreFolderPath = hj.EQs("Score.FolderPath") ?? ScoreFolderPath;
			DefaultFont = hj.EQs("Font.DefaultFont") ?? DefaultFont;
			Preview = hj.EQb("Preview") ?? Preview;
			PlayerMaxNum = hj.EQi("PlayerMaxNum") ?? PlayerMaxNum;
			CheckUpdate = hj.EQb("CheckUpdate") ?? CheckUpdate;
			CheckExistWave = hj.EQb("SongSelect.CheckWaveExist") ?? CheckExistWave;

			//Auto = Enumerable.Repeat(false, PlayerMaxNum).ToArray();
			//Array.Copy(hj?.EQa("Auto")?.Select(v => (bool?)v ?? false)?.ToArray(), Auto, Auto.Length);
			//ScrollSpeedList = Enumerable.Repeat(1.0F, PlayerMaxNum).ToArray();

			Demo = hj.EQb("Demo") ?? Demo;
			UseXAudio = hj.EQb("UseXAudio") ?? UseXAudio;
			Debug = hj.EQb("Debug") ?? Debug;
			ScreenshotsOutputFolder = hj.EQs("Screenshot.OutputFolder") ?? ScreenshotsOutputFolder;

			Set(hj);

			string userMainConfigFilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + ".user.hjson");

			if(!File.Exists(userMainConfigFilePath))
			{
				File.Copy("Defaults\\MainConfig.user.hjson", userMainConfigFilePath, true);
			}
			
			PlayerInfoList = new PlayerInfo[PlayerMaxNum];

			hj = HjsonEx.HjsonEx.LoadEx(userMainConfigFilePath);


			var plys = hj.EQa("Players") ?? new JsonArray();

			for (int i = 0; i < PlayerInfoList.Length; i++)
			{
				if(i < hj.Count)
				{
					PlayerInfoList[i] = new PlayerInfo(plys[i].EQs());
				} 
				else
				{
					PlayerInfoList[i] = new PlayerInfo();
				}
			}
		}
	}
}
