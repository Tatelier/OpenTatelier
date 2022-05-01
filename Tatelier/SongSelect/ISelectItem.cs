using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	interface ISelectItem
	{
		/// <summary>
		/// 親
		/// </summary>
		GenreSelectItem Genre { get; set; }

		/// <summary>
		/// 親
		/// </summary>
		IParentSelectItem Parent { get; set; }

		/// <summary>
		/// 背景画像ハンドル
		/// </summary>
		int BackgroundImageHandle { get; set; }

		/// <summary>
		/// 新背景
		/// </summary>
		FrameImage Frame { get; set; }

		/// <summary>
		/// 
		/// </summary>
		uint FontEdgeColor { get; set; }

		/// <summary>
		/// タイトル画像のハンドル
		/// </summary>
		int TitleImageHandle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		int SetThemeData(LoadImageHandleInfo info);

		/// <summary>
		/// 選択要素番号
		/// </summary>
		int SelectIndex { get; set; }

		/// <summary>
		/// 前の曲
		/// </summary>
		ISelectItem Prev { get; set; }

		/// <summary>
		/// 次の曲
		/// </summary>
		ISelectItem Next { get; set; }

		/// <summary>
		/// タイトル
		/// </summary>
		string Title { get; set; }

		/// <summary>
		/// 描画
		/// </summary>
		/// <param name="cxf"></param>
		/// <param name="cyf"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		void Draw(SongSelect.SelectItemRendererItem item);
	}

	interface IParentSelectItem : ISelectItem
	{
	}
}
