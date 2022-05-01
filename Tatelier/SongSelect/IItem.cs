namespace Tatelier.SongSelect
{
	/// <summary>
	/// 選択項目インターフェース
	/// </summary>
	public interface IItem
	{
		/// <summary>
		/// 選曲項目種別
		/// </summary>
		SongSelectItemType Type { get; }
	}
}
