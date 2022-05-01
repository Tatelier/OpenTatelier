using System.Collections.Generic;
using System.Linq;

namespace Tatelier.Multi
{
	class MultiItemControl
	{
		public List<MultiItem> ItemList = new List<MultiItem>();

		public void Clear()
        {
			ItemList.Clear();
        }

		public int Add(Control control, MultiItemInfo itemInfo, bool overwrite = false)
		{
			int id = int.MinValue;

			switch (itemInfo.CourseName.ToUpper())
			{
				case "URA":
				case "EDIT":
				case "裏":
				case "うら":
				case "4":
					id = 4;
					break;
				case "ONI":
				case "鬼":
				case "おに":
				case "3":
					id = 3;
					break;
				case "HARD":
				case "難":
				case "むずかしい":
				case "2":
					id = 2;
					break;
				case "NORMAL":
				case "普":
				case "ふつう":
				case "1":
					id = 1;
					break;
				case "EASY":
				case "簡":
				case "かんたん":
				case "0":
					id = 0;
					break;
				default:
					if (itemInfo.CourseName.StartsWith("-"))
					{

					}
					else
					{

					}
					break;
			}

			// 既存の難易度
			if (ItemList.Any(v => v.CourseID == id))
			{
				return -11;
			}
			else
			{
				ItemList.Add(new MultiItem(control, itemInfo)
				{
					CourseID = id,
				});
				return 0;
			}
		}

		public void Update()
		{

		}

		public void Draw()
		{

		}
	}
}
