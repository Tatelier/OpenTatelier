using System;
using System.Collections.Generic;
using System.Linq;
using HjsonEx;

namespace Tatelier.SongSelect
{
	/// <summary>
	/// カテゴリ管理クラス
	/// </summary>
	public class GenreControl
	{
		/// <summary>
		/// その他ジャンルのキー名
		/// </summary>
		const string OtherGenreKeyName = "\r";

		/// <summary>
		/// カテゴリマップ
		/// </summary>
		public Dictionary<string, Genre> GenreMap = new Dictionary<string, Genre>();

		/// <summary>
		/// 画像ルートフォルダパス
		/// </summary>
		public string ImageRootFolder;

		/// <summary>
		/// その他カテゴリを取得する
		/// ※要素1つの配列
		/// </summary>
		/// <returns>その他カテゴリ</returns>
		public Genre[] GetOther()
		{
			return new Genre[]
			{
				GenreMap[OtherGenreKeyName],
			};
		}

		/// <summary>
		/// 引数で指定された名前のカテゴリ一覧を取得する
		/// </summary>
		/// <param name="names">カテゴリ名(可変長)</param>
		/// <returns>カテゴリ一覧</returns>
		public Genre[] Get(params string[] names)
		{
			var genreList = new Genre[names.Length];

			for (int i = 0; i < genreList.Length; i++)
			{
				if (GenreMap.TryGetValue(names[i], out var genre))
				{
					genreList[i] = genre;
				}
			}

			return genreList;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		public GenreControl(string filePath)
		{
			try
			{
				var hj = HjsonEx.HjsonEx.LoadEx(filePath);

				ImageRootFolder = hj.EQa("ImageRootFolder") ?? "SongSelect/Genres";

				var array = hj.EQa("Genres") ?? HjsonEx.Empty.Array;

				List<string> duplicateSplit = new List<string>();

				foreach (var item in array)
				{
					string name = item.EQs("Name");
					var genre = new Genre(item);

					try
					{
						GenreMap.Add(name, genre);
					}
					catch
					{
						duplicateSplit.Add(name);
					}

					// 曖昧なものをまとめる
					foreach (var amb in item.EQa("Ambiguous").Select(v => v.EQs()).Where(v => v?.Length > 0))
					{
						try
						{
							GenreMap.Add(amb, genre);
						}
						catch
						{
							duplicateSplit.Add(amb);
						}
					}
				}
				if (duplicateSplit.Count > 0)
				{
					Error.Add(new ErrorItem()
					{
						Code = Error.CODE_GENRE_DUPLICATE,
						ErrorTextArgs = new string[]
						{
							string.Join(",", duplicateSplit)
						}
					});
				}
			}
			catch (Exception e)
			{
				Error.Add(new ErrorItem()
				{
					Code = Error.CODE_SCORE_EXCEPTION,
					ErrorTextArgs = new string[]
					{
						$"{e}"
					}
				});
			}


			// その他カテゴリ
			GenreMap.Add(OtherGenreKeyName, new Genre()
			{
				Name = "その他",
			});
		}
	}
}
