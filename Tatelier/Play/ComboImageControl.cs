using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tatelier.DxLibDLL;
using static DxLibDLL.DX;
using HjsonEx;

namespace Tatelier.Play
{
	struct ComboNumberInfo
	{
		/// <summary>
		/// 画像ハンドル
		/// </summary>
		public int Handle;

		/// <summary>
		/// 数字単位の幅
		/// </summary>
		public int ChipWidth;

		/// <summary>
		/// 数字単位の高さ
		/// </summary>
		public int ChipHeight;

		/// <summary>
		/// 表示するコンボ数
		/// </summary>
		public int SinceCombo;
	}
	/// <summary>
	/// コンボ数字画像管理クラス
	/// </summary>
	class ComboNumberImageControl
		: IDisposable
	{
		int handle;
		bool disposed;

		float xf = 370;
		float yf = 340;

		int startTime = 0;
		float exRateY = 1;

		float exRateYStart = 1.0F;
		float exRateYEnd = 1.0F;

		int animationMillisec = 0;

		int splitWidth;
		int splitHeight;

		int chipWidth;
		int chipHeight;

		ComboNumberInfo[] InfoList;

		int index = 0;
		int combo;

		IEnumerator animation;

		public int Combo
		{
			get => combo;
			set
			{
				if (combo < value)
				{
					exRateY = exRateYStart;
					startTime = Supervision.NowMilliSec;
				}
				else if (combo > value)
				{

				}
				combo = value;
			}
		}

		public void Update()
		{
			int diffTime = Supervision.NowMilliSec - startTime;
			if (diffTime < animationMillisec)
			{
				exRateY = exRateYStart - ((exRateYStart - exRateYEnd) * diffTime / animationMillisec);
			}
			else
			{
				exRateY = exRateYEnd;
			}
		}


		public void Draw()
		{
			if (combo < 10)
			{
				// 何もしない
			}
			else
			{
				// 桁数取得
				string strCombo = $"{combo}";

				using (DrawModeGuard.Create())
				{
					SetDrawMode(DX_DRAWMODE_BILINEAR);
					for (int i = 0; i < strCombo.Length; i++)
					{
						DrawRectRotaGraphFast3F(xf - ((strCombo.Length * chipWidth) / 2) + (i * chipWidth)
							, yf - chipHeight * (exRateY - exRateYEnd)
							, splitWidth * (strCombo[i] - 0x30)
							, 0
							, splitWidth
							, splitHeight
							, 0
							, 0
							, 1
							, exRateY
							, 0
							, handle
							, DX_TRUE);
					}
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					// un-managed
					ImageLoadControl.Singleton.Delete(handle);
				}

				disposed = true;
			}
		}

		~ComboNumberImageControl()
		{
			Dispose();
		}

		/// <summary>
		/// コンボ数要素をセットする
		/// </summary>
		/// <param name="folderPath"></param>
		/// <param name="sinceComboElems"></param>
		void SetComboNumberItem(string folderPath, IEnumerable<XElement> sinceComboElems)
		{
			var infoList = new ComboNumberInfo[sinceComboElems.Count()];

			for (int i = 0; i < infoList.Length; i++)
			{
				infoList[i] = new ComboNumberInfo();

				var item = sinceComboElems.Skip(i).FirstOrDefault();

				string filePath = Path.Combine(folderPath, (string)item.Attribute("FilePath") ?? "");

				handle = ImageLoadControl.Singleton.Load(filePath);

				GetGraphSize(handle, out var w, out var h);

				infoList[i].Handle = handle;
				infoList[i].ChipWidth = w / 10;
				infoList[i].ChipHeight = h;
				infoList[i].SinceCombo = (int?)item.Element("Since") ?? 10;
			}

			// 設定されているコンボ数順にソートしてから配列化する
			this.InfoList = infoList.OrderBy(v => v.SinceCombo).ToArray();
		}

		public ComboNumberImageControl(string folderPath, Hjson.JsonValue json)
		{
			string folder = Path.Combine(folderPath, json.EQs("FolderPath") ?? "");

			handle = ImageLoadControl.Singleton.Load(Path.Combine(folder, "ComboNumber_1.png"));

			GetGraphSize(handle, out var w, out var h);

			splitWidth = w / 10;
			splitHeight = h;

			chipWidth = json.EQi("Chip.Width") ?? splitWidth;
			chipHeight = json.EQi("Chip.Height") ?? splitHeight;

			xf = json.EQf("PointX") ?? xf;
			yf = json.EQf("PointY") ?? yf;

			// コンボ数毎の処理
			var sinceComboElems = json.EQa("ComboNumberItem");

			if (sinceComboElems?.Any() ?? false)
			{
				//SetComboNumberItem(folderPath, sinceComboElems);
			}
			else
			{
				this.InfoList = new ComboNumberInfo[1]
				{
					new ComboNumberInfo
					{
						SinceCombo = 10,
						ChipWidth = splitWidth,
						ChipHeight = splitHeight,
						Handle = handle,
					}
				};
			}


			// アニメーション設定
			var animElem = json.EQv("Animation");

			if (animElem != null)
			{
				animationMillisec = animElem.EQi("DuringTime") ?? 0;
				exRateYStart = animElem.EQf("StartExRateY") ?? 1.0F;
			}
		}

		[Obsolete("HJSON形式を使ってください")]
		public ComboNumberImageControl(string folderPath, XElement elem)
		{
			string filePath = Path.Combine(folderPath, (string)elem.Attribute("FilePath") ?? "");

			handle = ImageLoadControl.Singleton.Load(filePath);

			GetGraphSize(handle, out var w, out var h);

			splitWidth = w / 10;
			splitHeight = h;

			xf = (float?)elem.Attribute("PointX") ?? xf;
			yf = (float?)elem.Attribute("PointY") ?? yf;

			// コンボ数毎の処理
			var sinceComboElems = elem.Elements("ComboNumberItem");

			if (sinceComboElems?.Any() ?? false)
			{
				SetComboNumberItem(folderPath, sinceComboElems);
			}
			else
			{
				this.InfoList = new ComboNumberInfo[1]
				{
					new ComboNumberInfo
					{
						SinceCombo = 10,
						ChipWidth = splitWidth,
						ChipHeight = splitHeight,
						Handle = handle,
					}
				};
			}


			// アニメーション設定
			var animElem = elem.Element("Animation");

			if (animElem != null)
			{
				animationMillisec = (int?)animElem.Attribute("AnimationTime") ?? 0;
				exRateYStart = (float?)animElem.Attribute("ExRateYStart") ?? 1.0F;
			}
		}

		public ComboNumberImageControl(string filePath)
		{
			handle = ImageLoadControl.Singleton.Load(filePath);

			GetGraphSize(handle, out var w, out var h);

			splitWidth = w / 10;
			splitHeight = h;
		}
	}
}
