using System.Diagnostics;
using Tatelier.DxLibDLL;
using static DxLibDLL.DX;

namespace Tatelier.SongSelect
{
	/// <summary>
	/// 選曲項目(譜面)
	/// </summary>
	[DebuggerDisplay("Parent : {Parent.Title}, Title : {TJA.Title}, RelativePath : {RelativeFilePath}")]
	class MusicalScoreSelectItem : ISelectItem
	{
		/// <summary>
		/// 親の項目
		/// </summary>
		public GenreSelectItem Genre { get; set; } = null;

		/// <summary>
		/// 親の項目
		/// </summary>
		public IParentSelectItem Parent { get; set; }

		/// <summary>
		/// 次の項目
		/// </summary>
		public ISelectItem Next { get; set; }

		/// <summary>
		/// 前の項目
		/// </summary>
		public ISelectItem Prev { get; set; }

		/// <summary>
		/// 相対パス
		/// </summary>
		public string RelativeFilePath { get; set; } = "";

		/// <summary>
		/// 背景画像ハンドル
		/// </summary>
		public int BackgroundImageHandle
		{
			get => Genre.BackgroundImageHandle;
			set { }
		}

		public FrameImage Frame
		{
			get => Genre.Frame;
			set { }
		}

		public uint FontEdgeColor
		{
			get => Genre.FontEdgeColor;
			set { }
		}

		/// <summary>
		/// タイトル画像ハンドル
		/// </summary>
		public int TitleImageHandle
		{
			get => Image.TitleHandle;
			set { }
		}

		public MusicalScoreSelectItemImage Image;

		public MusicalScore TJA { get; set; }

		/// <summary>
		/// タイトル名
		/// </summary>
		public string Title { get => TJA.Title; set => TJA.Title = value; }

		public void Update()
		{

		}

		public void Draw(SongSelect.SelectItemRendererItem item)
		{
			Frame.Width = item.Width;
			Frame.Height = item.Height;

			Frame.InnerWidth = item.Width;
			Frame.InnerHeight = item.Height;
			Frame.InnerFrame.Pivot = Pivot.Center;
			Frame.Draw(item.CXf - item.Width / 2, item.CYf - item.Height / 2, item.CXf, item.CYf);

			using (DrawBlendModeGuard.Create())
			{
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, item.ContentAlpha);
				DrawRotaGraphF(item.CXf, item.CYf - 60 * ((Frame.Height - 130) / 186), 1.0, 0.0, TitleImageHandle, DX_TRUE);
				if (Frame.Height == item.CurrentlySelectedHeight)
				{
					DrawRotaGraphF(item.CXf, item.CYf - 20, 1.0, 0.0, Image.SubTitleHandle, DX_TRUE);
				}
			}
		}

		/// <summary>
		/// 要素番号 ※MusicalSelectItemでは不使用
		/// </summary>
		public int SelectIndex { get; set; } = -1;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int SetThemeData(LoadImageHandleInfo info)
		{
			Image = new MusicalScoreSelectItemImage();

			Image.TitleHandle = Utility.GetImageHandleFromText(
				Title,
				info.Title.FontColor,
				info.Title.FontName,
				info.Title.Width,
				info.Title.Height,
				info.Title.FontSize,
				info.Title.FontEdgeSize,
				FontEdgeColor);

			Image.SubTitleHandle = Utility.GetImageHandleFromText(
				TJA.SubTitle,
				info.Title.FontColor,
				info.Title.FontName,
				info.Title.Width,
				info.Title.Height,
				2 * info.Title.FontSize / 3,
				2 * info.Title.FontEdgeSize / 3,
				FontEdgeColor);

			return 0;
		}


		~MusicalScoreSelectItem()
		{

		}

		public MusicalScoreSelectItem(MusicalScore tja, GenreSelectItem parent)
		{
			TJA = tja;
			Parent = parent;
			Genre = parent;
			RelativeFilePath = tja.FilePathRelative;
		}

		public MusicalScoreSelectItem(MusicalScore tja, SelectItemControl selectItemControl)
		{
			TJA = tja;
			RelativeFilePath = tja.FilePathRelative;
		}
	}
}
