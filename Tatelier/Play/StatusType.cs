using System;

namespace Tatelier.Play
{
	[Flags]
	/// <summary>
	/// 状態
	/// </summary>
	enum StatusType
	{
		/// <summary>
		/// 通常
		/// </summary>
		Normal = 0x01,
		/// <summary>
		/// クリア
		/// </summary>
		Clear = 0x02,
		/// <summary>
		/// 失敗
		/// </summary>
		Failure = 0x04,
	}
}
