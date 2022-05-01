using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HjsonEx;

namespace Tatelier.Common.SongSelect
{
	/// <summary>
	/// カテゴリ管理クラス
	/// </summary>
	public class CategoryControl
	{
		const string OtherCategoryKeyName = "\r";

		public static CategoryControl Create(string filePath)
		{
			var instance = new CategoryControl();
			instance.Init(filePath);

			return instance;
		}


		/// <summary>
		/// カテゴリマップ
		/// </summary>
		public Dictionary<string, Category> CategoryMap = new Dictionary<string, Category>();

		/// <summary>
		/// その他カテゴリを取得する
		/// ※要素1つの配列
		/// </summary>
		/// <returns>その他カテゴリ</returns>
		public Category[] GetOther()
		{
			return new Category[]
			{
				CategoryMap[OtherCategoryKeyName],
			};
		}

		/// <summary>
		/// 引数で指定された名前のカテゴリ一覧を取得する
		/// </summary>
		/// <param name="names">カテゴリ名(可変長)</param>
		/// <returns>カテゴリ一覧</returns>
		public Category[] Get(params string[] names)
		{
			var categories = new Category[names.Length];

			for (int i = 0; i < categories.Length; i++)
			{
				if (CategoryMap.TryGetValue(names[i], out var category))
				{
					categories[i] = category;
				}
			}

			return categories;
		}

		public string ImageRootFolder;


		void Init(string filePath)
		{
			try
			{
				var hj = HjsonEx.HjsonEx.LoadEx(filePath);

				ImageRootFolder = hj.EQa("ImageRootFolder") ?? "SongSelect/Genres";

				var array = hj.EQa("Genres") ?? HjsonEx.Empty.Array;

				foreach (var item in array)
				{
					string name = item.EQs("Name");
					var category = new Category(item);

					try
					{
						CategoryMap.Add(name, category);
					}
					catch
					{
						//errorList.Add($"・カテゴリ名が重複しています。{name}");
					}

					// 曖昧なものをまとめる
					foreach (var amb in item.EQa("Ambiguous").Select(v => v.EQs()).Where(v => v?.Length > 0))
					{
						try
						{
							CategoryMap.Add(amb, category);
						}
						catch
						{
							//errorList.Add($"・カテゴリ名(曖昧)が重複しています。{amb}");
						}
					}
				}
			}
			catch (Exception e)
			{
				//errorList.Add($"・例外が発生しました。{e.InnerException.Message}");
			}


			// その他カテゴリ
			CategoryMap.Add(OtherCategoryKeyName, new Category()
			{
				Name = "その他",
			});


			//error = errorList.Count > 0 ? errorList.ToArray() : null;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		CategoryControl()
		{
		}
	}
}
