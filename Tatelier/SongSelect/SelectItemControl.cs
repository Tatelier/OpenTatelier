using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
    class PlayerScoreClearTypeCount
    {
		public int Norma = 0;

		public int Soul = 0;

		public int FullCombo = 0;

		public int FullGood = 0;

		public int FullGreat = 0;
    }

	public enum SongSelectOrder
    {
		Normal,
		Level,
		Name,
    }

	/// <summary>
	/// 選曲項目管理クラス
	/// </summary>
	class SelectItemControl
	{
		/// <summary>
		/// その他カテゴリキー名
		/// </summary>
		const string OtherGenreKeyName = "\r";

		class State
		{
			public bool IsAlreadyThemeLoad = false;
		}

		State state = new State();

		Hjson.JsonValue json;

		public SongSelectOrder SongSelectOrder = SongSelectOrder.Normal;


		/// <summary>
		/// 画像ルートフォルダ
		/// </summary>
		string ImageRootFolder;

		/// <summary>
		/// 譜面ルートフォルダ
		/// </summary>
		public string ScoreRootFolder { get; private set; }

		/// <summary>
		/// ジャンルリスト
		/// </summary>
		List<GenreSelectItem> genreList { get; set; } = new List<GenreSelectItem>();

		List<MusicalScore> musicalList = new List<MusicalScore>();

		MusicalScoreSelectItem[] musicalScoreSelectItemList;

		Dictionary<string, GenreSelectItem> genreSelectItemMap = new Dictionary<string, GenreSelectItem>();


		public void LoadAllScoreSaveData(IEnumerable<string> playerNameList, Action<int, int> oneLoadCallback)
        {
            if (oneLoadCallback == null)
            {
				oneLoadCallback = (a, b) => { };
            }

			int length = GetAllMusicalScoreSelectItem()?.Count() ?? 0;

			int cnt = 1;
			foreach (var item in GetAllMusicalScoreSelectItem())
			{
				item.TJA.LoadSaveData(ScoreRootFolder, playerNameList);
				oneLoadCallback(cnt, length);
				cnt++;
			}
        }

		/// <summary>
		/// 項目リスト
		/// </summary>
		public IReadOnlyList<ISelectItem> SelectItemList { get; private set; } = new List<ISelectItem>();

		/// <summary>
		/// 譜面数
		/// </summary>
		public int GetScoreCount() => GetAllMusicalScoreSelectItem()?.Count() ?? 0;

		public bool HasScore => GetAllMusicalScoreSelectItem()?.Any() ?? false;

		/// <summary>
		/// すべての譜面をリストで取得する
		/// </summary>
		/// <returns>譜面リスト</returns>
		public IEnumerable<MusicalScoreSelectItem> GetAllMusicalScoreSelectItem()
		{
			IEnumerable<MusicalScoreSelectItem> result = new MusicalScoreSelectItem[0];

			foreach (var item in SelectItemList)
			{
				if (item is GenreSelectItem genre)
				{
					result = result == null ? genre.GetAllMusicalScoreSelectItem() : result.Concat(genre.GetAllMusicalScoreSelectItem());
				}
				else if (item is MusicalScoreSelectItem tja)
				{
					var tempArray = new MusicalScoreSelectItem[]{
						tja
					};
					result = result == null ? tempArray : result.Concat(tempArray);
				}
			}

			return result;
		}

		public ISelectItem GetSearch(string name)
		{
			return GetAllMusicalScoreSelectItem().Where(v => v.Title.Equals(name)).FirstOrDefault();
		}

		public ISelectItem GetFromIndex(int index)
		{
			if (0 <= index && index < musicalScoreSelectItemList.Length)
			{
				return musicalScoreSelectItemList[index];
			}
            else
            {
				return null;
            }
		}

		/// <summary>
		/// 開く
		/// </summary>
		/// <param name="genre">ジャンル</param>
		/// <returns>開いたジャンルのカレント位置にある項目</returns>
		public ISelectItem Open(GenreSelectItem genre)
		{
			if (genreList.Count > 1)
			{
				if (genre.SelectItems.Count > 1)
				{
					var next = genre.Next;
					var prev = genre.Prev;

					next.Prev = genre.SelectItems.Last();
					genre.SelectItems.Last().Next = next;

					prev.Next = genre.SelectItems.First();
					genre.SelectItems.First().Prev = prev;
				}
				else
				{
					var first = genre.SelectItems.First();
					var next = genre.Next;
					var prev = genre.Prev;

					first.Next = genre.Next;
					first.Prev = genre.Prev;

					next.Prev = first;
					prev.Next = first;
				}
			}
			else
			{
				if (genre.SelectItems.Count > 1)
				{
					genre.SelectItems.Last().Next = genre.SelectItems.First();
					genre.SelectItems.First().Prev = genre.SelectItems.Last();
				}
				else
				{
					var first = genre.SelectItems.First();
					first.Next = first.Prev = first;
				}
			}
			return genre.SelectItems[genre.SelectIndex];
		}

		/// <summary>
		/// 閉じる
		/// </summary>
		/// <param name="genre">ジャンル</param>
		/// <returns>閉じたジャンル</returns>
		public ISelectItem Close(GenreSelectItem genre)
		{
			if (genreList.Count > 1)
			{
				var first = genre.SelectItems.First();
				var last = genre.SelectItems.Last();

				first.Prev.Next = genre;
				last.Next.Prev = genre;

				genre.Prev = first.Prev;
				genre.Next = last.Next;
			}
			else
			{
				var next = genre.Next;
				var prev = genre.Prev;
				next.Prev = genre;
				prev.Next = genre;
			}
			return genre;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int SetThemeData(LoadImageHandleInfo info)
		{
			int result = 0;
			if (!state.IsAlreadyThemeLoad)
			{
				foreach (var item in genreList)
				{
					int ret2 = item.SetThemeData(info);
					if (ret2 != 0)
					{
						Error.Add(0xFFFFFFFF);
						result = -1;
					}
				}
				state.IsAlreadyThemeLoad = true;
			}

			return result;
		}

		/// <summary>
		/// 音源ファイルパス
		/// </summary>
		/// <param name="item"></param>
		/// <param name="result">音源パス</param>
		/// <param name="demoStartMillisec">デモ再生位置</param>
		/// <returns></returns>
		public bool TryGetWaveFilePath(ISelectItem item, out string result, out int demoStartMillisec)
		{
			if (!(item is MusicalScoreSelectItem tja))
			{
				result = string.Empty;
				demoStartMillisec = 0;
				return false;
			}

			var tjaPath = tja.RelativeFilePath;

			var tjaDir = Path.GetDirectoryName(tjaPath);


			result = Path.Combine(ScoreRootFolder, tjaDir, tja.TJA.WaveFilePath);

			demoStartMillisec = tja.TJA.DemoStartMilliseconds;

			return File.Exists(result);
		}

		/// <summary>
		/// すべてのレベルを取得する
		/// </summary>
		/// <returns>レベルリスト</returns>
		public int[] GetAllLevel()
		{
			List<int> levels = new List<int>();
			var tjas = GetAllMusicalScoreSelectItem();

			foreach (var tja in tjas)
			{
				levels.AddRange(tja.TJA.Courses.Select(v => (int)v.Level).Distinct());
			}

			return levels.Where(v => v != -1).Distinct().ToArray();
		}

		/// <summary>
		/// 引数で指定された名前のカテゴリ一覧を取得する
		/// </summary>
		/// <param name="names">カテゴリ名(可変長)</param>
		/// <returns>カテゴリ一覧</returns>
		public GenreSelectItem[] Get(params string[] names)
		{
			var genreList = new GenreSelectItem[names?.Length ?? 0];

			for (int i = 0; i < genreList.Length; i++)
			{
				if (genreSelectItemMap.TryGetValue(names[i], out var genre))
				{
					genreList[i] = genre;
				}
				else
				{
					genreList[i] = genreSelectItemMap[OtherGenreKeyName];
				}
			}

			return genreList;
		}

		/// <summary>
		/// その他ジャンルの選択項目を作成する
		/// </summary>
		/// <param name="folderPath">譜面フォルダ</param>
		/// <returns></returns>
		public static GenreSelectItem CreateOtherGenreSelectItem(string folderPath)
		{
			try
			{
				string filePath = Path.Combine(folderPath, "Score.hjson");
				Hjson.JsonValue json;
				if (File.Exists(filePath))
				{
					json = HjsonEx.HjsonEx.LoadEx(filePath);
				}
				else
				{
					Error.Add(new ErrorItem()
					{
						Code = Error.CODE_404_SCORE_HJSON,
					});

					json = new Hjson.JsonObject();
				}


				string imageRootFolder = json.EQa("ImageRootFolder") ?? "SongSelect/Genres";

				return new GenreSelectItem(imageRootFolder);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 項目の前後をセットする
		/// </summary>
		void TieItemToItem()
		{
			for (int i = 0; i < SelectItemList.Count; i++)
			{
				SelectItemList[i].Prev = SelectItemList[(i + (SelectItemList.Count - 1)) % SelectItemList.Count];
				SelectItemList[i].Next = SelectItemList[(i + 1) % SelectItemList.Count];
			}
		}

		int Load(IEnumerable<string> scoreFilePathList)
		{
			musicalList.Clear();

			if (scoreFilePathList.Any())
			{
				foreach (var filePath in scoreFilePathList)
				{
					var filePathRelative = filePath.Replace(ScoreRootFolder, "");

					try
					{
						uint ret = Error.SUCCESS;
						var tjaItem = new MusicalScore();

						musicalList.Add(tjaItem);

						ret = tjaItem.LoadFromFile(ScoreRootFolder, filePathRelative);
					}
					catch
					{

					}
				}
			}

			return 0;
		}

		public void Tie()
        {
			Tie(json);
        }

		void Tie(Hjson.JsonValue json)
		{

			{
				var distinctSelectItemList = genreSelectItemMap.Values.Distinct().Where(v => v.SelectItems.Count > 0);

				SelectItemList = distinctSelectItemList.Cast<ISelectItem>().ToList();
				genreList = distinctSelectItemList.ToList();
				musicalScoreSelectItemList = GetAllMusicalScoreSelectItem()?.ToArray() ?? Array.Empty<MusicalScoreSelectItem>();

				// Prev, Nextの紐付け
				foreach (var genre in distinctSelectItemList)
				{
					genre.TieItemToItem(json);
				}

				TieItemToItem();
			}

			if(SongSelectOrder == SongSelectOrder.Level)
			{
				var distinctSelectItemList = genreSelectItemMap.Values.Distinct().Where(v => v.SelectItems.Count > 0);

				SelectItemList = distinctSelectItemList.Cast<ISelectItem>().ToList();

				musicalScoreSelectItemList = GetAllMusicalScoreSelectItem()?.ToArray() ?? Array.Empty<MusicalScoreSelectItem>();

				SelectItemList = musicalScoreSelectItemList.OrderBy(v =>
				{
					if (v.TJA.Courses[3].Level == -1
						&& v.TJA.Courses[4].Level > 0)
					{
						return v.TJA.Courses[4].Level;
					}
					else
					{
						return v.TJA.Courses[3].Level;
					}
				}).Cast<ISelectItem>().ToList();

				TieItemToItem();

				foreach (var selectItem in SelectItemList)
				{
					selectItem.Parent = null;
				}
			}
			else if(SongSelectOrder == SongSelectOrder.Name)
			{
				var distinctSelectItemList = genreSelectItemMap.Values.Distinct().Where(v => v.SelectItems.Count > 0);

				SelectItemList = distinctSelectItemList.Cast<ISelectItem>().ToList();

				musicalScoreSelectItemList = GetAllMusicalScoreSelectItem()?.ToArray() ?? Array.Empty<MusicalScoreSelectItem>();

				SelectItemList = musicalScoreSelectItemList.OrderBy(v =>
                {
					string kana;

					if (string.IsNullOrEmpty(v.TJA.Kana))
					{
						kana = v.TJA.Title;
					}
                    else
					{
						kana = v.TJA.Kana;
					}

                    return kana;

                }).Cast<ISelectItem>().ToList();

				TieItemToItem();

				foreach(var selectItem in SelectItemList)
				{
					selectItem.Parent = null;
                }
			}
		}


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="folderPath">譜面フォルダ</param>
		/// <param name="json"></param>
		public SelectItemControl(string folderPath, Hjson.JsonValue json)
		{
			this.json = json;

			string filePath = Path.Combine(Path.GetFullPath(folderPath), "Score.hjson");

			Hjson.JsonValue hj;
			if (File.Exists(filePath))
			{
				hj = HjsonEx.HjsonEx.LoadEx(filePath);
			}
			else
			{
				Error.Add(new ErrorItem()
				{
					Code = Error.CODE_404_SCORE_HJSON,
				});

				hj = new Hjson.JsonObject();
			}

			ImageRootFolder = hj.EQa("ImageRootFolder") ?? "SongSelect/Genres";

			var array = hj.EQa("Genres") ?? HjsonEx.Empty.Array;

			List<string> duplicateNames = new List<string>();

			foreach (var item in array)
			{
				string name = item.EQs("Name");
				var genre = new GenreSelectItem(item, ImageRootFolder);

				try
				{
					genreSelectItemMap.Add(name, genre);
				}
				catch
				{
					duplicateNames.Add(name);
				}

				// 曖昧なものをまとめる
				foreach (var amb in item.EQa("Ambiguous").Select(v => v.EQs()).Where(v => v?.Length > 0))
				{
					try
					{
						genreSelectItemMap.Add(amb, genre);
					}
					catch
					{
						duplicateNames.Add(name);
					}
				}
			}

			// 重複定義されている場合はエラーを追加
			if (duplicateNames.Count > 0)
			{
				Error.Add(new ErrorItem()
				{
					Code = Error.CODE_GENRE_DUPLICATE
					,
					ErrorTextArgs = new string[] { string.Join(",", duplicateNames) }
				});
			}

			var other = new GenreSelectItem(ImageRootFolder);

			// その他カテゴリ
			genreSelectItemMap.Add(OtherGenreKeyName, other);

			ScoreRootFolder = (Path.Combine(folderPath, "Root") + "\\").Replace("/", "\\");

			// ファイル列挙
			IEnumerable<string> scores;

			if (Directory.Exists(ScoreRootFolder))
			{
				scores = Directory.EnumerateFiles(ScoreRootFolder, "*", SearchOption.AllDirectories).Where(v => MainConfig.Singleton.IsScoreFile(v));
			}
			else
			{
				scores = new string[0];
			}

			// ルート
			var root = new GenreSelectItem();
			other.Genre = root;
			other.Parent = root;

			Load(scores);

			foreach(var score in musicalList)
			{
				var scoreSelectItem = new MusicalScoreSelectItem(score, this);

				bool regist = false;

				if (score.Genres?.Length > 0)
				{
					foreach (var genreName in score.Genres)
					{
						if (genreSelectItemMap.TryGetValue(genreName, out var genre))
						{
							genre.SelectItems.Add(new MusicalScoreSelectItem(score, genre));
							regist = true;
						}
					}
				}

				if (!regist || score.Genres?.Length == 0)
				{
					other.SelectItems.Add(scoreSelectItem);
					scoreSelectItem.Parent = other;
					scoreSelectItem.Genre = other;
				}
			}

			Tie(json);
		}


		/// <summary>
		/// ファイルパスを取得する
		/// </summary>
		/// <param name="tja">譜面データ</param>
		/// <returns>ファイルパス</returns>
		public string GetFilePath(MusicalScoreSelectItem tja)
		{
			return Path.Combine(ScoreRootFolder, tja.RelativeFilePath);
		}

		public string GetLyricFilePath(MusicalScoreSelectItem tja)
		{
			return tja.TJA.GetLyricFilePath(ScoreRootFolder);
		}
	}
}