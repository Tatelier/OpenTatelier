using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HjsonEx;

namespace Tatelier.Common.SongSelect
{
	[DebuggerDisplay("Name = {Name}, Count = {ItemList.Count}")]
	public class Category
		: IItem
	{
		public SortedDictionary<string, List<IItem>> Items = new SortedDictionary<string, List<IItem>>();

		public IList<IItem> ItemList
		{
			get
			{
				var list = new List<IItem>();

				foreach (var item in Items)
				{
					list.AddRange(item.Value);
				}

				return list;
			}
		}

		public bool IsOpen = false;

		public string Name { get; set; }

		public string Detail { get; set; }

		public string ImageFolder { get; set; }

		public SongSelectItemType Type => SongSelectItemType.Category;

		public void Add(IItem item, string sortText)
		{
			string[] renewSortTextSplit = new string[3];

			var split = sortText.Split('-');

			if (split.Length > 3)
			{
#warning Pansystar::警告したい
			}

			for (int i = 0; i < 3; i++)
			{
				if (i < sortText.Length)
				{
					renewSortTextSplit[i] = split[i].PadLeft(5, '0');
				}
				else
				{
					renewSortTextSplit[i] = "ZZZZZ";
				}
			}

			string renewSortText = string.Join("-", renewSortTextSplit);

			if (!Items.ContainsKey(renewSortText))
			{
				Items[renewSortText] = new List<IItem>();
			}
			Items[renewSortText].Add(item);
		}

		public Category()
		{

		}

		public Category(Hjson.JsonValue json)
		{
			Name = json.EQs("Name") ?? "";
			Detail = json.EQs("Detail") ?? "";
			ImageFolder = json.EQs("ImageFolder");
		}
	}
}