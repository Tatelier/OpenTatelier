using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tatelier.Common.SongSelect
{
	[DebuggerDisplay("Title={Title}")]
	public class ScoreOverview
		: IItem
	{
		/// <summary>
		/// ファイル種別
		/// </summary>
		enum FileType
		{
			/// <summary>
			/// Tatelierフォーマット譜面
			/// </summary>
			TatelierScore,
			/// <summary>
			/// TJA
			/// </summary>
			TJA,
			/// <summary>
			/// OSU
			/// </summary>
			OSU,
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="scoreFolderPath">譜面フォルダパス</param>
		/// <param name="relativeFilePath">相対ファイルパス</param>
		/// <param name="categoryControl">カテゴリ管理クラス</param>
		/// <returns>インスタンス</returns>
		public static ScoreOverview Create(string scoreFolderPath, string relativeFilePath, CategoryControl categoryControl)
		{
			var extension = Path.GetExtension(relativeFilePath);

			FileType type;

			switch (extension)
			{
				case ".tja":
				case ".pts":
					type = FileType.TJA;
					break;
				case ".tlscore":
				default:
					type = FileType.TatelierScore;
					break;
			}

			var score = new ScoreOverview(scoreFolderPath, relativeFilePath, type, categoryControl);

			return score;
		}

		/// <summary>
		/// ファイルパス(相対パス)
		/// </summary>
		public string FilePath;

		/// <summary>
		/// タイトル
		/// </summary>
		public string Title;

		/// <summary>
		/// ID
		/// </summary>
		public string Id;

		/// <summary>
		/// カテゴリ名リスト
		/// </summary>
		public string[] Category;

		/// <summary>
		/// 音源
		/// </summary>
		public string Wave;

		/// <summary>
		/// デモ音源
		/// </summary>
		public string DemoMusicWave;

		/// <summary>
		/// デモ再生開始時間(秒)
		/// </summary>
		public double DemoStart;

		/// <summary>
		/// カテゴリデータ
		/// </summary>
		public Category[] CategoryData;

		public SongSelectItemType Type => SongSelectItemType.Score;

		public string RelativeFilePath => FilePath;

		/// <summary>
		/// TJA読込
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <param name="categoryControl">カテゴリクラス</param>
		void LoadTJA(string filePath, CategoryControl categoryControl)
		{
			using (var sr = new StreamReader(filePath, Encoding.GetEncoding("shift-jis")))
			{
				var regex = new Regex(@"^(\S+):(.+)$");

				while (!sr.EndOfStream)
				{
					var line = sr.ReadLine();

					if (regex.IsMatch(line))
					{
						var match = regex.Match(line);
						var groups = match.Groups;

						switch (groups[1].Value.ToUpper())
						{
							case "TITLE":
								{
									Title = groups[2].Value;
								}
								break;
							case "WAVE":
								{
									Wave = groups[2].Value;
								}
								break;
							case "DEMOWAVE":
								{
									DemoMusicWave = groups[2].Value;
								}
								break;
							case "GENRE":
								{
									Category = groups[2].Value.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
									CategoryData = categoryControl?.Get(Category.Select(v => v.Split(',')[0]).ToArray()) ?? new Category[0];
								}
								break;
						}
					}
				}

				// カテゴリデータがない場合はその他を取得する
				if (CategoryData == null) CategoryData = categoryControl.GetOther();

				for (int i = 0; i < CategoryData.Length; i++)
				{
					CategoryData[i]?.Add(this, "");
				}
			}
		}

		void LoadTatelierScore(string filePath, CategoryControl categoryControl)
		{

		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="scoreFolderPath">譜面フォルダパス</param>
		/// <param name="relativeFilePath">ファイル相対パス</param>
		/// <param name="fileType">ファイル種別</param>
		/// <param name="categoryControl">カテゴリ管理</param>
		ScoreOverview(string scoreFolderPath, string relativeFilePath, FileType fileType, CategoryControl categoryControl)
		{
			string filePath = Path.Combine(scoreFolderPath, relativeFilePath);

			FilePath = relativeFilePath;

			switch (fileType)
			{
				case FileType.TatelierScore:
					LoadTatelierScore(filePath, categoryControl);
					break;
				case FileType.TJA:
					LoadTJA(filePath, categoryControl);
					break;
				case FileType.OSU:
					break;
			}

		}
	}
}
