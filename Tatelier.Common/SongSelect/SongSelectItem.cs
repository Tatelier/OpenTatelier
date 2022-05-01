using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Common.SongSelect
{
	[DebuggerDisplay("Type:{Type}")]
	public class SongSelectItem
	{
		public SongSelectItemType Type { get; }

		/// <summary>
		/// データインスタンス
		/// ※Typeにしたがってasキャストして使うこと
		/// </summary>
		object Data;

		/// <summary>
		/// 
		/// </summary>
		public Category Category => Data as Category;

		/// <summary>
		/// 
		/// </summary>
		public ScoreOverview ScoreOverview => Data as ScoreOverview;

		public SongSelectItem Prev { get; set; }
		public SongSelectItem Next { get; set; }

		public bool TryDataFormatCheck()
		{
			bool result = true;
			switch (Type)
			{
				case SongSelectItemType.Score:
					result = Data as ScoreOverview == null;
					break;
				case SongSelectItemType.Category:
					result = Data as Category == null;
					break;
				default:
					result = false;
					break;
			}

			if (!result)
			{

			}

			return result;
		}

		public IItem GetItem(int index)
		{
			return null;
		}

		public SongSelectItem(SongSelectItemType type, object data)
		{
			Type = type;
			Data = data;
		}
	}
}
