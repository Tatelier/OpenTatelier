using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HjsonEx;

namespace Tatelier.SongSelect
{
	[DebuggerDisplay("Name = {Name}, Count = {ItemList.Count}")]
	public class Genre
		: IItem
	{
		SortedDictionary<string, List<IItem>> items = new SortedDictionary<string, List<IItem>>();

		/// <summary>
		/// 項目リスト
		/// </summary>
		public List<IItem> ItemList
		{
			get
			{
				var list = new List<IItem>();

				foreach (var item in items)
				{
					list.AddRange(item.Value);
				}

				return list;
			}
		}

		/// <summary>
		/// ジャンル名
		/// </summary>
		public string Name { get; set; } = "";

		/// <summary>
		/// 詳細説明
		/// </summary>
		public string Detail { get; set; } = "";

		/// <summary>
		/// 画像フォルダパス
		/// </summary>
		public string ImageFolder { get; set; } = "";

		/// <summary>
		/// 項目種別
		/// </summary>
		public SongSelectItemType Type => SongSelectItemType.Genre;

		/// <summary>
		/// 項目追加
		/// </summary>
		/// <param name="item">項目</param>
		/// <param name="sortText">並び替え判定用文字列</param>
		public void Add(IItem item, string sortText)
		{
			if (!items.ContainsKey(sortText))
			{
				items[sortText] = new List<IItem>();
			}
			items[sortText].Add(item);
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Genre()
		{
			Name = "";
			Detail = "";
			ImageFolder = "";
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="json">json値</param>
		public Genre(Hjson.JsonValue json)
		{
			Name = json.EQs("Name") ?? "";
			Detail = json.EQs("Detail") ?? "";
			ImageFolder = json.EQs("ImageFolder") ?? "";
		}
	}
}