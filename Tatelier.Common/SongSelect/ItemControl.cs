using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Common.SongSelect
{
	/// <summary>
	/// 選択項目管理クラス
	/// </summary>
	public class ItemControl
	{
		public static ItemControl Create(string folder, CategoryControl categoryControl, out string[] error)
		{
			var instance = new ItemControl(folder, categoryControl);

			error = null;

			return instance;
		}

		/// <summary>
		/// 項目リスト
		/// </summary>
		public List<IItem> ItemList = new List<IItem>();

		/// <summary>
		/// 譜面フォルダ
		/// </summary>
		public string ScoreFolder;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="scorefolder">譜面フォルダ</param>
		/// <param name="categoryControl">カテゴリ管理</param>
		public ItemControl(string scorefolder, CategoryControl categoryControl)
		{
			ScoreFolder = scorefolder;
			ItemList.AddRange(categoryControl.CategoryMap.Values.Distinct());

			var files = Directory.EnumerateFiles(scorefolder, "*", SearchOption.AllDirectories).Where(v =>
			{
				var extension = Path.GetExtension(v);
				switch (extension)
				{
					case ".tja":
					case ".pts":
					case ".tlscore":
						return true;
					default:
						return false;
				}
			});

			foreach (var item in files.Select(v => v.Replace(scorefolder + "\\", "")) ?? new string[0])
			{
				_ = ScoreOverview.Create(scorefolder, item, categoryControl);
			}
		}
	}
}
