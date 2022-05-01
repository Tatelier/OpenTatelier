using System;
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
	class TaikoImageControl
		: IDisposable
	{
		bool disposed = false;

		int taikoBase = -1;
		int don = -1;
		int kat = -1;
		int bachi = -1;

		public float X = 0;
		public float Y = 0;

		int lDonStartTime = int.MaxValue;
		int rDonStartTime = int.MaxValue;
		int lKatStartTime = int.MaxValue;
		int rKatStartTime = int.MaxValue;

		const float animeTime = 200;

		public void Update(bool ldon, bool rdon, bool lkat, bool rkat, int time)
		{
			if (ldon)
			{
				lDonStartTime = time;
			}
			if (rdon)
			{
				rDonStartTime = time;
			}
			if (lkat)
			{
				lKatStartTime = time;
			}
			if (rkat)
			{
				rKatStartTime = time;
			}
		}

		public void Draw(int time)
		{
			DrawRotaGraphF(X, Y, 1.0, 0.0, taikoBase, DX_TRUE);

			GetGraphSizeF(don, out var dw, out var dh);
			GetGraphSizeF(kat, out var kw, out var kh);

			if (lDonStartTime == int.MaxValue
				&& rDonStartTime == int.MaxValue
				&& lKatStartTime == int.MaxValue
				&& rKatStartTime == int.MaxValue)
			{
				DrawRotaGraphF(X, Y, 1.0, 0.0, bachi, DX_TRUE);
				return;
			}


			if (time - lDonStartTime < animeTime)
			{
				using (DrawBlendModeGuard.Create())
				{
					SetDrawBlendMode(DX_BLENDMODE_ALPHA, (int)(255 - ((time - lDonStartTime) / animeTime) * 255));
					DrawRectRotaGraphF(X - dw / 4, Y, 0, 0, (int)dw / 2, (int)dh, 1.0, 0.0, don, DX_TRUE);
				}
			}

			if (time - rDonStartTime < animeTime)
			{
				using (DrawBlendModeGuard.Create())
				{
					SetDrawBlendMode(DX_BLENDMODE_ALPHA, (int)(255 - ((time - rDonStartTime) / animeTime) * 255));
					DrawRectRotaGraphF(X + dw / 4, Y, (int)dw / 2, 0, (int)dw / 2, (int)dh, 1.0, 0.0, don, DX_TRUE);
				}
			}

			if (time - lKatStartTime < animeTime)
			{
				using (DrawBlendModeGuard.Create())
				{
					SetDrawBlendMode(DX_BLENDMODE_ALPHA, (int)(255 - ((time - lKatStartTime) / animeTime) * 255));
					DrawRectRotaGraphF(X - kw / 4, Y, 0, 0, (int)kw / 2, (int)kh, 1.0, 0.0, kat, DX_TRUE);
				}
			}

			if (time - rKatStartTime < animeTime)
			{
				using (DrawBlendModeGuard.Create())
				{
					SetDrawBlendMode(DX_BLENDMODE_ALPHA, (int)(255 - ((time - rKatStartTime) / animeTime) * 255));
					DrawRectRotaGraphF(X + kw / 4, Y, (int)kw / 2, 0, (int)kw / 2, (int)kh, 1.0, 0.0, kat, DX_TRUE);
				}
			}

			DrawRotaGraphF(X, Y, 1.0, 0.0, bachi, DX_TRUE);

		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					ImageLoadControl.Singleton.Delete(taikoBase);
					ImageLoadControl.Singleton.Delete(don);
					ImageLoadControl.Singleton.Delete(kat);
					ImageLoadControl.Singleton.Delete(bachi);
				}

				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}
		~TaikoImageControl()
		{
			Dispose();
		}

		public TaikoImageControl(string folder, string taikoName, int playerNum, Hjson.JsonValue json)
		{
			var taikoRootFolder = json.EQs("FolderPath") ?? "Taiko";

			var taikoFolder = $@"{folder}\{taikoRootFolder}\{taikoName}";
			var taikoConfigPath = MainConfig.Singleton.GetThemePath($@"{taikoFolder}\Taiko.xml");

			X = json.EQf("PointX") ?? 0.0F;
			Y = json.EQf("PointY") ?? 0.0F;

			// 太鼓フォルダが無い場合はデフォルトフォルダをセットする
			if (!Directory.Exists(taikoFolder))
			{
				taikoFolder = $@"{folder}\{taikoRootFolder}\Default";
			}

			if (File.Exists(taikoConfigPath))
			{
				var taikoConfig = XDocument.Load(taikoConfigPath);

			}
			else
			{
				// 設定ファイルがない場合は固定値でロードする
				taikoBase = ImageLoadControl.Singleton.Load(Path.Combine(taikoFolder, "Base.png"));
				don = ImageLoadControl.Singleton.Load(Path.Combine(taikoFolder, "Don.png"));
				kat = ImageLoadControl.Singleton.Load(Path.Combine(taikoFolder, "Kat.png"));
				bachi = ImageLoadControl.Singleton.Load(Path.Combine(taikoFolder, "Bachi.png"));
			}
		}

		/// <summary>
		/// 太鼓画像コンストラクタ
		/// </summary>
		/// <param name="folder"></param>
		/// <param name="taikoName">太鼓の名前</param>
		/// <param name="elem"></param>
		[Obsolete("HJSON形式を使ってください")]
		public TaikoImageControl(string folder, string taikoName, int playerNum, XElement elem)
		{
			var taikoRootFolder = (string)elem.Attribute("Taiko") ?? "Taiko";

			var taikoFolder = $@"{folder}\{taikoRootFolder}\{taikoName}";
			var taikoConfigPath = MainConfig.Singleton.GetThemePath($@"{taikoFolder}\Taiko.xml");

			X = (float?)elem.Attribute("PointX") ?? 0.0F;
			Y = (float?)elem.Attribute("PointY") ?? 0.0F;

			// 太鼓フォルダが無い場合はデフォルトフォルダをセットする
			if (!Directory.Exists(taikoFolder))
			{
				taikoFolder = $@"{folder}\{taikoRootFolder}\Default";
			}

			if (File.Exists(taikoConfigPath))
			{
				var taikoConfig = XDocument.Load(taikoConfigPath);

			}
			else
			{
				// 設定ファイルがない場合は固定値でロードする
				taikoBase = ImageLoadControl.Singleton.Load(Path.Combine(taikoFolder, "Base.png"));
				don = ImageLoadControl.Singleton.Load(Path.Combine(taikoFolder, "Don.png"));
				kat = ImageLoadControl.Singleton.Load(Path.Combine(taikoFolder, "Kat.png"));
				bachi = ImageLoadControl.Singleton.Load(Path.Combine(taikoFolder, "Bachi.png"));
			}
		}

		/// <summary>
		/// 太鼓画像管理クラス
		/// </summary>
		/// <param name="folder"></param>
		/// <param name="elem"></param>
		public TaikoImageControl(string folder, XElement elem)
		{

			taikoBase = ImageLoadControl.Singleton.Load(MainConfig.Singleton.GetThemePath(@"Play\Taiko\Default\Base.png"));
			don = ImageLoadControl.Singleton.Load(MainConfig.Singleton.GetThemePath(@"Play\Taiko\Default\Don.png"));
			kat = ImageLoadControl.Singleton.Load(MainConfig.Singleton.GetThemePath(@"Play\Taiko\Default\Kat.png"));
			bachi = ImageLoadControl.Singleton.Load(MainConfig.Singleton.GetThemePath(@"Play\Taiko\Default\Bachi.png"));

			X = (float?)elem.Attribute("PointX") ?? 0.0F;
			Y = (float?)elem.Attribute("PointY") ?? 0.0F;
		}
	}
}
