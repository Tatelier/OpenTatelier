using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static DxLibDLL.DX;

namespace Tatelier
{
	static class Utility
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);

		public static int ToHalf(int val)
		{
			return val / 2;
		}

		internal static int GetCourseID(string courseName)
		{
			switch (courseName.ToUpper())
			{
				case "EASY":
				case "かんたん":
				case "0":
					return 0;
				case "NORMAL":
				case "ふつう":
				case "1":
					return 1;
				case "HARD":
				case "むずかしい":
				case "2":
					return 2;
				case "ONI":
				case "おに":
				case "3":
				default:
					return 3;
				case "URA":
				case "EDIT":
				case "うら":
				case "4":
					return 4;
			}
		}

		public static int GetCenterPoint(int x, int y, int width, int height, out int centerX, out int centerY)
		{
			centerX = x - width / 2;
			centerY = y - height / 2;

			return 0;
		}

		public static int GetCenterPointF(float xf, float yf, int width, int height, out float centerXf, out float centerYf)
		{
			centerXf = xf - width / 2;
			centerYf = yf - height / 2;

			return 0;
		}

		public static bool TryGetColor(uint color, out int red, out int green, out int blue)
		{
			red = (int)(color & 0x00FF0000) >> 16;
			green = (int)(color & 0x0000FF00) >> 8;
			blue = (int)(color & 0x000000FF);

			return true;
		}

		internal static uint? GetColor(string v)
		{
			if (v == null) return 0x0;

			uint color = 0;
			if (v.StartsWith("0x")
				&& v.Length == 8)
			{
				color += uint.TryParse(v.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, null, out var r) ? r << 16 : 0;
				color += uint.TryParse(v.Substring(4, 2), System.Globalization.NumberStyles.HexNumber, null, out var g) ? g << 8 : 0;
				color += uint.TryParse(v.Substring(6, 2), System.Globalization.NumberStyles.HexNumber, null, out var b) ? b : 0;

				return color;
			}
			return null;
		}

		public static IEnumerator GetCreateBgmIterator(string filePath, Action<int> result)
		{
			// 先頭に無音を挿入
			SetUseASyncLoadFlag(DX_TRUE);
			int soft = LoadSoftSound(filePath);
			SetUseASyncLoadFlag(DX_FALSE);

			while (true)
			{
				int ret = CheckHandleASyncLoad(soft);
				if (ret == -1)
				{
					result(-1);
					yield break;
				}

				if(ret == DX_FALSE)
				{
					break;
				}

				yield return 0;
			}

			long sampleNum = GetSoftSoundSampleNum(soft);
			GetSoftSoundFormat(soft, out var channels, out int bitsPerSample, out int samplesPerSec, out int isFloatType);

			SetUseASyncLoadFlag(DX_TRUE);
			int soft2 = MakeSoftSoundCustom(channels, bitsPerSample, samplesPerSec, sampleNum + samplesPerSec * 2, isFloatType);
			SetUseASyncLoadFlag(DX_FALSE);

            while (CheckHandleASyncLoad(soft2) == DX_TRUE)
			{
				yield return 0;
			}
			yield return 0;

			// 2回目の作成時、キャッシュなのかわからんが、先頭にサンプルが残るため、
			// 空白を0で埋めること。
			for (int i = 0; i < samplesPerSec * 2; i++)
			{
				WriteSoftSoundData(soft2, i, 0, 0);
                if (i == 512)
                {
					yield return 0;
                }
			}
			yield return 0;

			for (int i = 0; i < sampleNum; i++)
			{
				ReadSoftSoundData(soft, i, out var ch1, out var ch2);
				WriteSoftSoundData(soft2, i + samplesPerSec * 2, ch1, ch2);
				if (i == 512)
				{
					yield return 0;
				}
			}
			yield return 0;

			// 先頭に無音を挿入
			SetUseASyncLoadFlag(DX_TRUE);
			int handle = LoadSoundMemFromSoftSound(soft2);
			SetUseASyncLoadFlag(DX_FALSE);

			while (CheckHandleASyncLoad(handle) == DX_TRUE)
			{
				yield return 0;
			}
			yield return 0;

			DeleteSoftSound(soft);
			DeleteSoftSound(soft2);

			result(handle);
		}

		public static int CreateBgm(string filePath)
		{
			if (filePath.EndsWith("mp3"))
			{
#warning TODO: mp3のとき形式を変更する
				SetCreateSoundDataType(DX_SOUNDDATATYPE_FILE);
			}

			// 先頭に無音を挿入
			int soft = LoadSoftSound(filePath);


			SetCreateSoundDataType(DX_SOUNDDATATYPE_MEMNOPRESS);

			if (soft == -1)
			{
				return -1;
			}

			long sampleNum = GetSoftSoundSampleNum(soft);
			GetSoftSoundFormat(soft, out var channels, out int bitsPerSample, out int samplesPerSec, out int isFloatType);
			int soft2 = MakeSoftSoundCustom(channels, bitsPerSample, samplesPerSec, sampleNum + samplesPerSec * 2, isFloatType);

			// 2回目の作成時、キャッシュなのかわからんが、先頭にサンプルが残るため、
			// 空白を0で埋めること。
			for (int i = 0; i < samplesPerSec * 2; i++)
			{
				WriteSoftSoundData(soft2, i, 0, 0);
			}

			for (int i = 0; i < sampleNum; i++)
			{
				ReadSoftSoundData(soft, i, out var ch1, out var ch2);
				WriteSoftSoundData(soft2, i + samplesPerSec * 2, ch1, ch2);
			}

			int handle = -1;
			if (filePath.EndsWith("mp3"))
			{
#warning TODO: mp3のとき形式を変更する
				SetCreateSoundDataType(DX_SOUNDDATATYPE_FILE);
			}

			handle = LoadSoundMemFromSoftSound(soft2);
			SetCreateSoundDataType(DX_SOUNDDATATYPE_MEMNOPRESS);

			DeleteSoftSound(soft);
			DeleteSoftSound(soft2);

			return handle;
		}

		public static void ProcessStart(string path, string args = "")
		{
			IntPtr wow64Value = IntPtr.Zero;

			try
			{
				// WOW64リダイレクトを無効
				Wow64DisableWow64FsRedirection(ref wow64Value);

				// 任意の処理 (WOW64のリダイレクトが必要な処理を行うと危険)
				var info = new ProcessStartInfo(path);
				info.WorkingDirectory = Path.GetDirectoryName(path);
				Process.Start(info);
			}
			finally
			{
				// 必ずリダイレクトを有効に戻す
				Wow64RevertWow64FsRedirection(wow64Value);
			}

		}

		static readonly SHA256CryptoServiceProvider hashProvider = new SHA256CryptoServiceProvider();
		public static string GetSHA256HashedString(string value)
			=> string.Join("", hashProvider.ComputeHash(Encoding.UTF8.GetBytes(value)).Select(x => $"{x:x2}"));

		static readonly MD5 md5 = System.Security.Cryptography.MD5.Create();
		public static string GetMD5FromFile(string filePath)
		{
			var md5Hash = md5.ComputeHash(File.ReadAllBytes(filePath));
			return BitConverter.ToString(md5Hash).Replace("-", "");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string GetCourse(string text)
		{
			switch (text.Replace(" ","").ToUpper())
			{
				case "0":
				case "EASY":
					return "Easy";
				case "1":
				case "NORMAL":
					return "Normal";
				case "2":
				case "HARD":
					return "Hard";
				case "3":
				case "ONI":
					return "Oni";
				case "4":
				case "EDIT":
				case "URA":
					return "Edit";
				default:
					return text;
			}
		}

		public static int GetImageHandleCircle(int width, int height, int color = 0x867457)
		{
			int handle = -1;

			using (var bmp = new Bitmap(width, height))
			using (var gps = Graphics.FromImage(bmp))
			{
				gps.TextRenderingHint = TextRenderingHint.AntiAlias;
				gps.InterpolationMode = InterpolationMode.Bilinear;
				//(アンチエイリアス処理されたレタリング)を指定する
				gps.SmoothingMode = SmoothingMode.AntiAlias;

				gps.DrawEllipse(new Pen(new SolidBrush(Color.FromArgb(color)), 8), 4, 4, width - 8, height - 8);


				// 動的に作成したBitmapからグラフィックを作成
				using (MemoryStream ms = new MemoryStream())
				{
					bmp.Save(ms, ImageFormat.Bmp);
					byte[] buff = ms.ToArray();

					IntPtr parray = Marshal.AllocCoTaskMem(buff.Length);
					Marshal.Copy(buff, 0, parray, buff.Length);
					SetDrawValidGraphCreateFlag(DX_TRUE);
					SetDrawValidAlphaChannelGraphCreateFlag(DX_TRUE);

					handle = CreateGraphFromMem(parray, buff.Length);

					SetDrawValidGraphCreateFlag(DX_FALSE);
					SetDrawValidAlphaChannelGraphCreateFlag(DX_FALSE);

					Marshal.FreeCoTaskMem(parray);
				}
			}

			return handle;
		}

		public static int GetImageHandlePuzzlePiece()
		{
			int handle = -1;

			using (var bmp = new Bitmap(128, 128))
			using (var gps = Graphics.FromImage(bmp))
			{
				gps.TextRenderingHint = TextRenderingHint.AntiAlias;
				gps.InterpolationMode = InterpolationMode.Bilinear;
				//(アンチエイリアス処理されたレタリング)を指定する
				gps.SmoothingMode = SmoothingMode.AntiAlias;

				var color = Color.LimeGreen;

				gps.FillRectangle(new SolidBrush(color), 32, 32, 96, 96);
				gps.FillEllipse(new SolidBrush(color), 56, 0, 48, 48);
				gps.FillEllipse(new SolidBrush(color), 0, 56, 48, 48);
				gps.CompositingMode = CompositingMode.SourceCopy; //gps.FillEllipse(new SolidBrush(Color.FromArgb(0x86, 0x74, 0x57)), 56, 0, 48, 48);
																  //gps.FillEllipse(new SolidBrush(Color.FromArgb(0x00000000)), 56, 128 - 24, 48, 48);
				gps.FillEllipse(new SolidBrush(Color.FromArgb(0x00000000)), 128 - 32, 56, 48, 48);
				//gps.FillEllipse(new SolidBrush(Color.FromArgb(0x00000000)), 96-24, 56, 48, 48);

				//gps.DrawEllipse(new Pen(new SolidBrush(Color.FromArgb(0x00000000)), 8), 4, 4, width - 8, height - 8);


				// 動的に作成したBitmapからグラフィックを作成
				using (MemoryStream ms = new MemoryStream())
				{
					bmp.Save(ms, ImageFormat.Bmp);
					byte[] buff = ms.ToArray();

					IntPtr parray = Marshal.AllocCoTaskMem(buff.Length);
					Marshal.Copy(buff, 0, parray, buff.Length);
					SetDrawValidGraphCreateFlag(DX_TRUE);
					SetDrawValidAlphaChannelGraphCreateFlag(DX_TRUE);

					handle = CreateGraphFromMem(parray, buff.Length);

					SetDrawValidGraphCreateFlag(DX_FALSE);
					SetDrawValidAlphaChannelGraphCreateFlag(DX_FALSE);

					Marshal.FreeCoTaskMem(parray);
				}
			}

			return handle;
		}

		public static int GetImageHandle(byte[] bytes)
		{
			int handle;
			// 動的に作成したBitmapからグラフィックを作成
			using (MemoryStream ms = new MemoryStream(bytes))
			{
				byte[] buff = bytes;

				IntPtr parray = Marshal.AllocCoTaskMem(buff.Length);
				Marshal.Copy(buff, 0, parray, buff.Length);
				SetDrawValidGraphCreateFlag(DX_TRUE);
				SetDrawValidAlphaChannelGraphCreateFlag(DX_TRUE);

				handle = CreateGraphFromMem(parray, buff.Length);

				SetDrawValidGraphCreateFlag(DX_FALSE);
				SetDrawValidAlphaChannelGraphCreateFlag(DX_FALSE);

				Marshal.FreeCoTaskMem(parray);
			}

			return handle;
		}

		public static int GetImageHandleFromText(string text, uint color, string fontName, int fontSize = 20, int edgeSize = 0, uint edgeColor = 0)
		{
			int handle = -1;

			// フォントを生成
			var ff = new Font(fontName, fontSize);

			var gp = new GraphicsPath();
			StringFormat sf = StringFormat.GenericTypographic;

			gp.AddString(text, ff.FontFamily, (int)ff.Style,
				 ff.SizeInPoints, Point.Empty, sf);

			var a = gp.GetBounds();

			float penSize = 1.0f;

			if (a.Width > 0 && a.Height > 0)
			{
				using (Bitmap bmp = new Bitmap((int)a.Width + edgeSize, (int)a.Height + edgeSize))
				using (Graphics gps = Graphics.FromImage(bmp))
				{
					gps.TextRenderingHint = TextRenderingHint.AntiAlias;
					gps.CompositingQuality = CompositingQuality.HighQuality;
					gps.CompositingMode = CompositingMode.SourceOver;
					//(アンチエイリアス処理されたレタリング)を指定する
					gps.SmoothingMode = SmoothingMode.AntiAlias;
					gps.TranslateTransform(-(a.X + penSize) + edgeSize / 2, -(a.Y + penSize) + edgeSize / 2);

					if (edgeSize > 0)
					{
						Pen drawPen = new Pen(Color.FromArgb((int)(edgeColor | 0xFF000000)), edgeSize) { LineJoin = LineJoin.Round };
						Pen drawPenHalf = new Pen(Color.FromArgb((int)(edgeColor | 0xFF000000)), edgeSize / 2.0F) { LineJoin = LineJoin.Round };

						gps.DrawPath(drawPen, gp);
						gps.DrawPath(drawPenHalf, gp);
					}

					Brush fillBrush = new SolidBrush(Color.FromArgb((int)(color | 0xFF000000)));
					gps.FillPath(fillBrush, gp);

					// 動的に作成したBitmapからグラフィックを作成
					using (MemoryStream ms = new MemoryStream())
					{
						bmp.Save(ms, ImageFormat.Bmp);
						byte[] buff = ms.ToArray();

						IntPtr parray = Marshal.AllocCoTaskMem(buff.Length);
						Marshal.Copy(buff, 0, parray, buff.Length);
						SetDrawValidGraphCreateFlag(DX_TRUE);
						SetDrawValidAlphaChannelGraphCreateFlag(DX_TRUE);

						handle = CreateGraphFromMem(parray, buff.Length);

						SetDrawValidGraphCreateFlag(DX_FALSE);
						SetDrawValidAlphaChannelGraphCreateFlag(DX_FALSE);

						Marshal.FreeCoTaskMem(parray);
					}
				}

			}

			return handle;

		}

		public static int GetImageHandleFromText(string text, uint color, string fontName, int width, int height, int fontSize = 20, int edgeSize = 0, uint edgeColor = 0, Pivot pivot = Pivot.Center)
		{
			int handle = -1;

			// 指定された幅, 高さで画像を作成
			using (var bmp = new Bitmap(width, height))
			using (var gps = Graphics.FromImage(bmp))
			{
				gps.TextRenderingHint = TextRenderingHint.AntiAlias;
				gps.InterpolationMode = InterpolationMode.Bilinear;
				//(アンチエイリアス処理されたレタリング)を指定する
				gps.SmoothingMode = SmoothingMode.AntiAlias;

				// フォントを生成
				var ff = new Font(fontName, fontSize);

				var gp = new GraphicsPath();
				StringFormat sf = StringFormat.GenericTypographic;

				gp.AddString(text, ff.FontFamily, (int)ff.Style,
					 ff.SizeInPoints, Point.Empty, sf);

				var a = gp.GetBounds();

				float penSize = 1.0f;

				if (a.Width > 0 && a.Height > 0)
				{
					using (Bitmap bmp2 = new Bitmap((int)a.Width + edgeSize, (int)a.Height + edgeSize))
					using (Graphics gps2 = Graphics.FromImage(bmp2))
					{
						gps2.TextRenderingHint = TextRenderingHint.AntiAlias;
						gps2.CompositingQuality = CompositingQuality.HighQuality;
						gps2.CompositingMode = CompositingMode.SourceOver;
						//(アンチエイリアス処理されたレタリング)を指定する
						gps2.SmoothingMode = SmoothingMode.AntiAlias;
						gps2.TranslateTransform(-(a.X + penSize) + edgeSize / 2, -(a.Y + penSize) + edgeSize / 2);

						if (edgeSize > 0)
						{
							Pen drawPen = new Pen(Color.FromArgb((int)(edgeColor | 0xFF000000)), edgeSize) { LineJoin = LineJoin.Round };
							Pen drawPenHalf = new Pen(Color.FromArgb((int)(edgeColor | 0xFF000000)), edgeSize / 2.0F) { LineJoin = LineJoin.Round };

							// TODO: ここの処理が遅い
							gps2.DrawPath(drawPen, gp);
							gps2.DrawPath(drawPenHalf, gp);
						}

						Brush fillBrush = new SolidBrush(Color.FromArgb((int)(color | 0xFF000000)));
						gps2.FillPath(fillBrush, gp);
						switch (pivot)
						{
							case Pivot.Center:
								gps.DrawImage(bmp2, bmp.Width / 2 - bmp2.Width / 2, bmp.Height / 2 - bmp2.Height / 2);
								break;
							case Pivot.TopLeft:
								gps.DrawImage(bmp2, 0, 0);
								break;
						}
					}

				}

				// 動的に作成したBitmapからグラフィックを作成
				using (MemoryStream ms = new MemoryStream())
				{
					bmp.Save(ms, ImageFormat.Bmp);
					byte[] buff = ms.GetBuffer();
					//byte[] buff = ms.ToArray();

					IntPtr parray = Marshal.AllocCoTaskMem(buff.Length);
					Marshal.Copy(buff, 0, parray, buff.Length);
					SetDrawValidGraphCreateFlag(DX_TRUE);
					SetDrawValidAlphaChannelGraphCreateFlag(DX_TRUE);

					handle = CreateGraphFromMem(parray, buff.Length);

					SetDrawValidGraphCreateFlag(DX_FALSE);
					SetDrawValidAlphaChannelGraphCreateFlag(DX_FALSE);

					Marshal.FreeCoTaskMem(parray);
				}
			}

			return handle;
		}

		public static string ReadLine(this StringBuilder sb, int startPosition)
		{
			int pos = startPosition;
			while (pos < sb.Length
				&& sb[pos] != '\n')
			{
				pos++;
			}

			if (sb[pos - 1] == '\r')
			{
				pos--;
			}

			return sb.ToString(startPosition, pos);
		}

		public static Encoding GetEncodingFromFile(string filePath)
		{
			if (!File.Exists(filePath)) return Encoding.Default;

			return GetCode(File.ReadAllBytes(filePath));
		}

		/// <summary>
		/// 文字コードを判別する
		/// </summary>
		/// <remarks>
		/// Jcode.pmのgetcodeメソッドを移植したものです。
		/// Jcode.pm(http://openlab.ring.gr.jp/Jcode/index-j.html)
		/// Jcode.pmの著作権情報
		/// Copyright 1999-2005 Dan Kogai <dankogai@dan.co.jp>
		/// This library is free software; you can redistribute it and/or modify it
		///  under the same terms as Perl itself.
		/// </remarks>
		/// <param name="bytes">文字コードを調べるデータ</param>
		/// <returns>適当と思われるEncodingオブジェクト。
		/// 判断できなかった時はnull。</returns>
		public static System.Text.Encoding GetCode(byte[] bytes)
		{
			const byte bEscape = 0x1B;
			const byte bAt = 0x40;
			const byte bDollar = 0x24;
			const byte bAnd = 0x26;
			const byte bOpen = 0x28;    //'('
			const byte bB = 0x42;
			const byte bD = 0x44;
			const byte bJ = 0x4A;
			const byte bI = 0x49;

			int len = bytes.Length;
			byte b1, b2, b3, b4;

			//Encode::is_utf8 は無視

			bool isBinary = false;
			for (int i = 0; i < len; i++)
			{
				b1 = bytes[i];
				if (b1 <= 0x06 || b1 == 0x7F || b1 == 0xFF)
				{
					//'binary'
					isBinary = true;
					if (b1 == 0x00 && i < len - 1 && bytes[i + 1] <= 0x7F)
					{
						//smells like raw unicode
						return System.Text.Encoding.Unicode;
					}
				}
			}
			if (isBinary)
			{
				return null;
			}

			//not Japanese
			bool notJapanese = true;
			for (int i = 0; i < len; i++)
			{
				b1 = bytes[i];
				if (b1 == bEscape || 0x80 <= b1)
				{
					notJapanese = false;
					break;
				}
			}
			if (notJapanese)
			{
				return System.Text.Encoding.ASCII;
			}

			for (int i = 0; i < len - 2; i++)
			{
				b1 = bytes[i];
				b2 = bytes[i + 1];
				b3 = bytes[i + 2];

				if (b1 == bEscape)
				{
					if (b2 == bDollar && b3 == bAt)
					{
						//JIS_0208 1978
						//JIS
						return System.Text.Encoding.GetEncoding(50220);
					}
					else if (b2 == bDollar && b3 == bB)
					{
						//JIS_0208 1983
						//JIS
						return System.Text.Encoding.GetEncoding(50220);
					}
					else if (b2 == bOpen && (b3 == bB || b3 == bJ))
					{
						//JIS_ASC
						//JIS
						return System.Text.Encoding.GetEncoding(50220);
					}
					else if (b2 == bOpen && b3 == bI)
					{
						//JIS_KANA
						//JIS
						return System.Text.Encoding.GetEncoding(50220);
					}
					if (i < len - 3)
					{
						b4 = bytes[i + 3];
						if (b2 == bDollar && b3 == bOpen && b4 == bD)
						{
							//JIS_0212
							//JIS
							return System.Text.Encoding.GetEncoding(50220);
						}
						if (i < len - 5 &&
							b2 == bAnd && b3 == bAt && b4 == bEscape &&
							bytes[i + 4] == bDollar && bytes[i + 5] == bB)
						{
							//JIS_0208 1990
							//JIS
							return System.Text.Encoding.GetEncoding(50220);
						}
					}
				}
			}

			//should be euc|sjis|utf8
			//use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
			int sjis = 0;
			int euc = 0;
			int utf8 = 0;
			for (int i = 0; i < len - 1; i++)
			{
				b1 = bytes[i];
				b2 = bytes[i + 1];
				if (((0x81 <= b1 && b1 <= 0x9F) || (0xE0 <= b1 && b1 <= 0xFC)) &&
					((0x40 <= b2 && b2 <= 0x7E) || (0x80 <= b2 && b2 <= 0xFC)))
				{
					//SJIS_C
					sjis += 2;
					i++;
				}
			}
			for (int i = 0; i < len - 1; i++)
			{
				b1 = bytes[i];
				b2 = bytes[i + 1];
				if (((0xA1 <= b1 && b1 <= 0xFE) && (0xA1 <= b2 && b2 <= 0xFE)) ||
					(b1 == 0x8E && (0xA1 <= b2 && b2 <= 0xDF)))
				{
					//EUC_C
					//EUC_KANA
					euc += 2;
					i++;
				}
				else if (i < len - 2)
				{
					b3 = bytes[i + 2];
					if (b1 == 0x8F && (0xA1 <= b2 && b2 <= 0xFE) &&
						(0xA1 <= b3 && b3 <= 0xFE))
					{
						//EUC_0212
						euc += 3;
						i += 2;
					}
				}
			}
			for (int i = 0; i < len - 1; i++)
			{
				b1 = bytes[i];
				b2 = bytes[i + 1];
				if ((0xC0 <= b1 && b1 <= 0xDF) && (0x80 <= b2 && b2 <= 0xBF))
				{
					//UTF8
					utf8 += 2;
					i++;
				}
				else if (i < len - 2)
				{
					b3 = bytes[i + 2];
					if ((0xE0 <= b1 && b1 <= 0xEF) && (0x80 <= b2 && b2 <= 0xBF) &&
						(0x80 <= b3 && b3 <= 0xBF))
					{
						//UTF8
						utf8 += 3;
						i += 2;
					}
				}
			}
			//M. Takahashi's suggestion
			//utf8 += utf8 / 2;

			if (euc > sjis && euc > utf8)
			{
				//EUC
				return System.Text.Encoding.GetEncoding(51932);
			}
			else if (sjis > euc && sjis > utf8)
			{
				//SJIS
				return System.Text.Encoding.GetEncoding(932);
			}
			else if (utf8 > euc && utf8 > sjis)
			{
				//UTF8
				return System.Text.Encoding.UTF8;
			}
			else if (utf8 == euc)
			{
				return System.Text.Encoding.GetEncoding(51932);
			}
			return null;
		}

		public static int GetVol(int par)
		{
			return (par == 0) ? -10000 : ((int)(Math.Log10(par) * 5000.0f) - 10000);
		}
		/// <summary>
		/// リストの中からランダムに要素を取得する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ie"></param>
		/// <returns></returns>
		public static T RandomAt<T>(this IEnumerable<T> ie, int seed)
		{
			Random rand = new Random(seed);
			if (ie.Any() == false) return default(T);
			return ie.ElementAt(rand.Next(0, ie.Count()));
		}

		/// <summary>
		/// リストの中からランダムに要素を取得する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ie"></param>
		/// <returns></returns>
		public static T RandomAt<T>(this IEnumerable<T> ie)
		{
			if (ie.Any() == false) return default(T);
			return ie.ElementAt(GetRand(ie.Count() - 1));
		}

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImport("user32.dll")]
		private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool AttachThreadInput(int idAttach, int idAttachTo, bool fAttach);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

		/// <summary>
		/// Windowフォームアクティブ化処理
		/// </summary>
		/// <param name="handle">フォームハンドル</param>
		/// <returns>true : 成功 / false : 失敗</returns>
		public static bool ForceActive(IntPtr handle)
		{
			const uint SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000;
			const uint SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001;
			const int SPIF_SENDCHANGE = 0x2;

			IntPtr dummy = IntPtr.Zero;
			IntPtr timeout = IntPtr.Zero;

			bool isSuccess = false;

			int processId;
			// フォアグラウンドウィンドウを作成したスレッドのIDを取得
			int foregroundID = GetWindowThreadProcessId(GetForegroundWindow(), out processId);
			// 目的のウィンドウを作成したスレッドのIDを取得
			int targetID = GetWindowThreadProcessId(handle, out processId);

			// スレッドのインプット状態を結び付ける
			AttachThreadInput(targetID, foregroundID, true);

			// 現在の設定を timeout に保存
			SystemParametersInfo(SPI_GETFOREGROUNDLOCKTIMEOUT, 0, timeout, 0);
			// ウィンドウの切り替え時間を 0ms にする
			SystemParametersInfo(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, dummy, SPIF_SENDCHANGE);

			// ウィンドウをフォアグラウンドに持ってくる
			isSuccess = SetForegroundWindow(handle);

			// 設定を元に戻す
			SystemParametersInfo(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, timeout, SPIF_SENDCHANGE);

			// スレッドのインプット状態を切り離す
			AttachThreadInput(targetID, foregroundID, false);

			return isSuccess;
		}
	}
}