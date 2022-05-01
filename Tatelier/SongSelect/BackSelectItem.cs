using Tatelier.DxLibDLL;
using static DxLibDLL.DX;

namespace Tatelier.SongSelect
{
	class BackSelectItem : ISelectItem
	{
		public GenreSelectItem Genre { get; set; } = null;
		public IParentSelectItem Parent { get; set; }
		public int BackgroundImageHandle
		{
			get => Parent.BackgroundImageHandle;
			set { }
		}
		public FrameImage Frame { get; set; }
		public uint ItemBackgroundColor { get; set; }
		public uint FontEdgeColor { get; set; } = 0x3f2200;
		public int TitleImageHandle { get; set; }
		public int SelectIndex { get; set; }

		public ISelectItem Prev { get; set; }
		public ISelectItem Next { get; set; }
		public string Title { get; set; } = "もどる";

		public void Draw(SongSelect.SelectItemRendererItem item)
		{
			Frame.Width = item.Width;
			Frame.Height = item.Height;

			Frame.InnerWidth = item.Width;
			Frame.InnerHeight = item.Height;
			Frame.Draw(item.CXf - item.Width / 2, item.CYf - item.Height / 2, item.CXf - item.Width / 2, item.CYf - item.Height / 2);
			using (DrawBlendModeGuard.Create())
			{
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, item.ContentAlpha);
				DrawRotaGraphF(item.CXf, item.CYf, 1.0, 0.0, TitleImageHandle, DX_TRUE);
			}
		}

		public int SetThemeData(LoadImageHandleInfo info)
		{
			Frame = new FrameImage(System.IO.Path.Combine(info.ThemeCurrentDirectory, @"SongSelect\Genres\もどる"), true);
			ImageLoadControl.Singleton.Delete(TitleImageHandle);
			TitleImageHandle = Utility.GetImageHandleFromText(
				Title,
				info.Title.FontColor,
				info.Title.FontName,
				info.Title.Width,
				info.Title.Height,
				info.Title.FontSize,
				info.Title.FontEdgeSize,
				FontEdgeColor);
			return 0;
		}

		~BackSelectItem()
		{
			ImageLoadControl.Singleton.Delete(TitleImageHandle);
		}
	}
}
