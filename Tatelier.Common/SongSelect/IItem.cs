using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Common.SongSelect
{
	/// <summary>
	/// 選択項目インターフェース
	/// </summary>
	public interface IItem
	{
		SongSelectItemType Type { get; }
	}
}
