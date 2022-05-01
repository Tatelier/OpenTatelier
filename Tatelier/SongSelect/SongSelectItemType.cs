using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	/// <summary>
	/// 選曲項目種別
	/// </summary>
	public enum SongSelectItemType
	{
		/// <summary>
		/// ルート
		/// </summary>
		Root,
		/// <summary>
		/// 譜面
		/// </summary>
		Score,
		/// <summary>
		/// ジャンル
		/// </summary>
		Genre,
		/// <summary>
		/// 戻る
		/// </summary>
		Back,
	}
}
