using HjsonEx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Tatelier.DxLibDLL;
using Tatelier.SongSelect;

using static DxLibDLL.DX;

namespace Tatelier.SongSelect
{
	[DebuggerDisplay("Title = {Title}")]
	class GenreSelectItem : IParentSelectItem, IDisposable
	{
		bool disposed = false;

		public readonly string FilePath;

		string ImageFolder;

		public List<ISelectItem> SelectItems = new List<ISelectItem>();

		public GenreSelectItem Genre { get; set; }

		public IParentSelectItem Parent { get; set; }

		public int SelectIndex { get; set; }
		public ISelectItem Prev { get; set; }
		public ISelectItem Next { get; set; }
		public string Title { get; set; }
		/// <summary>
		/// 詳細
		/// </summary>
		public string DetailRaw { get; set; }

		public string Detail { get; set; }

		string backgroundImageFilePath { get; set; } = "";
		public int BackgroundImageHandle { get; set; } = -1;
		public uint ItemBackgroundColor { get; set; } = 0x8d7c72;

		public uint FontEdgeColor { get; set; } = 0x8d7c72;
		public int TitleImageHandle { get; set; } = -1;
		int DetailImageHandle { get; set; } = -1;

		string SelectItemBackgroundFilePath = "";

		public FrameImage Frame { get; set; }

		/// <summary>
		/// 項目の前後を結びつける
		/// </summary>
		/// <param name="json"></param>
		public void TieItemToItem(Hjson.JsonValue json)
		{
			int duration = json.EQi("BackItem.DuringCount") ?? 0;

			// もどる項目の追加
			if (duration > 0)
			{
				for (int i = 0; i < (SelectItems.Count / duration) + 1; i++)
				{
					var back = new BackSelectItem
					{
						Parent = this
					};
					int index = i * duration + i;
					if (index < SelectItems.Count)
					{
						SelectItems.Insert(index, back);
					}
				}

				SelectIndex = 1;
			}

			// 結びつけ
			for (int i = 0; i < SelectItems.Count; i++)
			{
				SelectItems[i].Prev = SelectItems[(i + (SelectItems.Count - 1)) % SelectItems.Count];
				SelectItems[i].Next = SelectItems[(i + 1) % SelectItems.Count];
			}
		}

		/// <summary>
		/// 全譜面を取得する
		/// </summary>
		/// <returns>譜面リスト</returns>
		public IEnumerable<MusicalScoreSelectItem> GetAllMusicalScoreSelectItem()
		{
			IEnumerable<MusicalScoreSelectItem> result = null;

			foreach (var item in SelectItems)
			{
				IEnumerable<MusicalScoreSelectItem> temp;

				switch (item)
				{
					case GenreSelectItem genre:
						{
							temp = genre.GetAllMusicalScoreSelectItem();
							result = result == null ? temp : result.Concat(temp);
						}
						break;
					case MusicalScoreSelectItem tja:
						{
							var tempArray = new MusicalScoreSelectItem[]{
								tja
							};
							result = result == null ? tempArray : result.Concat(tempArray);
						}
						break;
				}
			}

			if (result == null)
			{
				result = new MusicalScoreSelectItem[0];
			}

			return result;
		}


		/// <summary>
		/// テーマデータを取得する
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int SetThemeData(LoadImageHandleInfo info)
		{
			Dispose();

			TitleImageHandle = Utility.GetImageHandleFromText(
				Title,
				info.Title.FontColor,
				info.Title.FontName,
				info.Title.Width,
				info.Title.Height,
				info.Title.FontSize,
				info.Title.FontEdgeSize,
				FontEdgeColor);
			Detail = Common.Utility.ReplaceFromDic(DetailRaw, new Dictionary<string, object>()
			{
				{  "ScoreCount", this.GetAllMusicalScoreSelectItem().Count() }
			});

			DetailImageHandle = Utility.GetImageHandleFromText(
				Detail,
				info.Title.FontColor,
				info.Title.FontName,
				info.Title.Width,
				200,
				2 * info.Title.FontSize / 3,
				2 * info.Title.FontEdgeSize / 3,
				FontEdgeColor,
				Pivot.TopLeft);

			foreach (var item in SelectItems)
			{
				item.SetThemeData(info);
			}

			BackgroundImageHandle = ImageLoadControl.Singleton.Load(System.IO.Path.Combine(info.ThemeCurrentDirectory, backgroundImageFilePath));

			Frame = new FrameImage(System.IO.Path.Combine(info.ThemeCurrentDirectory, SelectItemBackgroundFilePath), true);

			if (BackgroundImageHandle == -1)
			{
				BackgroundImageHandle = info.DefaultBackgroundImageHandle;
			}

			return 0;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="json">ジャンル情報</param>
		/// <param name="imageRootFolder">イメージフォルダ</param>
		public GenreSelectItem(Hjson.JsonValue json, string imageRootFolder)
		{
			Title = json.EQs("Name") ?? "Undefined";
			DetailRaw = json.EQs("Detail") ?? "";

			FilePath = "";

			ImageFolder = json.EQs("ImageFolder");

			var styleHjson = HjsonEx.HjsonEx.LoadEx(Path.Combine(MainConfig.Singleton.ThemeFolderPath, imageRootFolder, ImageFolder, "Style.hjson"));

			backgroundImageFilePath = Path.Combine(imageRootFolder, ImageFolder, "Background.png");
			SelectItemBackgroundFilePath = Path.Combine(Path.Combine(imageRootFolder, ImageFolder));

			ItemBackgroundColor = 0xFFFFFF;
			FontEdgeColor = Convert.ToUInt32(((string)styleHjson?.EQs("TextEdgeColor") ?? "#FFFFFF").Replace("#", ""), 16);
		}



		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <param name="parent">親項目</param>
		public GenreSelectItem(string filePath, GenreSelectItem parent)
		{
			FilePath = filePath;

			Parent = parent;

			XDocument doc = XDocument.Load(filePath);

			XElement elem = doc.Element("Genre");

			XAttribute attr;

			attr = elem.Attribute("Title");

			Title = (string)attr ?? "Unknown";

			foreach (var item in elem.Elements())
			{
				switch (item.Name.LocalName)
				{
					case "Background":
						{
							attr = item.Attribute("ImageFilePath");
							string fpath = (string)attr ?? string.Empty;
							// ここでは画像パスだけを保持し、別メソッドで取得する。
							backgroundImageFilePath = fpath;
						}
						break;
					case "SelectItem":
						{
							attr = item.Attribute("FolderPath");
							string fpath = (string)attr ?? string.Empty;
							SelectItemBackgroundFilePath = fpath;

							foreach (var item2 in item.Elements())
							{
								switch (item2.Name.LocalName)
								{
									case "Background":
										attr = item2.Attribute("Color");
										ItemBackgroundColor = Convert.ToUInt32(((string)attr ?? "#FFFFFF").Replace("#", ""), 16);
										break;
									case "FontEdge":
										attr = item2.Attribute("Color");
										FontEdgeColor = Convert.ToUInt32(((string)attr ?? "#FFFFFF").Replace("#", ""), 16);
										break;
								}
							}
						}
						break;
				}
			}


		}

		/// <summary>
		/// コンストラクタ ※その他用
		/// </summary>
		/// <param name="imageRootFolder">その他ジャンルのイメージフォルダ</param>
		public GenreSelectItem(string imageRootFolder)
		{
			Title = "その他";
			DetailRaw = "何があるかはお楽しみ...\n全{{ScoreCount}}曲!!";
			FilePath = "";
			ImageFolder = "Default";

			var styleHjson = HjsonEx.HjsonEx.LoadEx(Path.Combine(MainConfig.Singleton.ThemeFolderPath, imageRootFolder, ImageFolder, "Style.hjson"));

			backgroundImageFilePath = Path.Combine(imageRootFolder, ImageFolder, "Background.png");
			SelectItemBackgroundFilePath = Path.Combine(Path.Combine(imageRootFolder, ImageFolder));

			ItemBackgroundColor = 0xFFFFFF;
			FontEdgeColor = Convert.ToUInt32(((string)styleHjson?.EQs("TextEdgeColor") ?? "#FFFFFF").Replace("#", ""), 16);
		}

		/// <summary>
		/// コンストラクタ ※ルート用
		/// </summary>
		public GenreSelectItem()
		{

		}


		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{

					ImageLoadControl.Singleton.Delete(TitleImageHandle);
					ImageLoadControl.Singleton.Delete(BackgroundImageHandle);
					ImageLoadControl.Singleton.Delete(DetailImageHandle);
					TitleImageHandle = -1;
					BackgroundImageHandle = -1;
					DetailImageHandle = -1;
					 Frame?.Dispose();
				}
				disposed = true;
			}

		}

		public void Dispose()
		{
			Dispose(true);
		}

		public void Draw(SongSelect.SelectItemRendererItem item)
		{
			Frame.Width = item.Width;
			Frame.Height = item.Height;

			Frame.InnerWidth = item.Width;
			Frame.InnerHeight = 130;
			Frame.InnerFrame.Pivot = Pivot.Center;

			Frame.InnerHeight = Frame.Height - ((Frame.Height - 130) / 186 * 92);

			Frame.Draw(item.CXf - item.Width / 2, item.CYf - item.Height / 2, item.CXf, item.CYf + (Frame.Height - Frame.InnerHeight) / 2);

			using (DrawBlendModeGuard.Create())
			{
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, item.ContentAlpha);
				GetGraphSizeF(TitleImageHandle, out _, out var h);
				DrawRotaGraphF(item.CXf, item.CYf - item.Height / 2 + h / 2, 1.0, 0.0, TitleImageHandle, DX_TRUE);

				if (Frame.Height == item.CurrentlySelectedHeight)
				{
					GetGraphSizeF(DetailImageHandle, out var w, out h);
					DrawGraphF(item.CXf - Frame.InnerWidth / 2 + 120, item.CYf - Frame.InnerHeight / 2 + 100, DetailImageHandle, DX_TRUE);
				}
			}
		}

		/// <summary>
		/// デストラクタ
		/// </summary>
		~GenreSelectItem()
		{
			Dispose();
		}
	}
}
