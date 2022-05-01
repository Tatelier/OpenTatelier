using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HjsonEx;

namespace Tatelier.Common
{
	public static class Utility
	{
		public static Encoding GetEncoding(FileStream fs)
		{
			var position = fs.Position;
			fs.Position = 0;
			using (var br = new BinaryReader(fs))
			{
				var bytes = br.ReadBytes(256);

				fs.Position = position;
				return GetCode(bytes);
			}
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
		public static Encoding GetCode(byte[] bytes)
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

			return null;
		}


		/// <summary>
		/// 桁数を取得する
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public static int Digit(int val)
		{
			// Mathf.Log10(0)はNegativeInfinityを返すため、別途処理する。
			return (val == 0) ? 1 : ((int)Math.Log10(val) + 1);
		}

		static bool TryCalc(Stack<float> calcValQueue, Stack<char> opeStack, out float result)
		{
			if (calcValQueue.Count <= 1)
			{
				result = (float?)calcValQueue.FirstOrDefault() ?? 0F;
				return false;
			}
			float valA = 0;
			float valB = 0;
			char ope = '+';

			if (opeStack.Any())
			{
				valA = calcValQueue.Pop();
			}

			while (opeStack.Any())
			{
				if (!calcValQueue.Any())
				{
					ope = opeStack.Pop();
					switch (ope)
					{
						case '+':
							valA = +valA;
							break;
						case '-':
							valA = -valA;
							break;
						case '*':
						case '/':
							throw new NotImplementedException();
					}
				}
				else
				{
					valB = calcValQueue.Pop();
					ope = opeStack.Pop();
					switch (ope)
					{
						case '+':
							valA = valB + valA;
							break;
						case '-':
							valA = valB - valA;
							break;
						case '*':
							valA = valB * valA;
							break;
						case '/':
							valA = valB / valA;
							break;
						case '%':
							valA = valB % valA;
							break;
						default:
							throw new NotImplementedException();
					}
				}
			}

			result = valA;
			return true;
		}

		/// <summary>
		/// 計算式文字列を計算する
		/// </summary>
		/// <param name="text">計算式文字列</param>
		/// <param name="dic">変数辞書</param>
		/// <returns></returns>
		public static float CalcFromString(string text, Dictionary<string, float> dic)
		{

			// 空白除去
			text = text.Replace(" ", "");

			// 変数置換
			// {{ }} で括られた変数を値に変更する
			{
				string key = "";
				int startIndex = 0;
				int endIndex = 0;

				for (int i = 0; i < text.Length; i++)
				{
					switch (text[i])
					{
						case '{':
							if (i + 1 < text.Length
								&& text[i + 1] == '{')
							{
								startIndex = i;
								endIndex = 0;
								for (; i < text.Length; i++)
								{
									switch (text[i])
									{
										case '}':
											if (i + 1 < text.Length
												&& text[i + 1] == '}')
											{
												endIndex = (i + 1);
												key = text.Substring(startIndex + 2, endIndex - startIndex - 3);

												float val = 0;
												if (dic?.TryGetValue(key, out val) ?? false)
												{
													text = text.Replace(text.Substring(startIndex, endIndex - startIndex + 1), $"{val}");
													i -= (key.Length + 4) - $"{val}".Length;
												}
											}
											break;
									}
									if (endIndex != 0)
									{
										break;
									}
								}
								endIndex = 0;
							}
							break;
					}
				}
			}


			// 括弧優先処理
			// 
			{
				var startIndex = new List<int>();

				for (int i = 0; i < text.Length; i++)
				{
					switch (text[i])
					{
						case '(':
							startIndex.Add(i);
							break;
						case ')':
							int endIndex = i;
							string a = text.Substring(startIndex.Last() + 1, endIndex - startIndex.Last() - 1);
							var b = CalcFromString(a, null);
							text = text.Replace(text.Substring(startIndex.Last(), endIndex - startIndex.Last() + 1), $"{b}");
							i = startIndex.Last() + $"{b}".Length;
							startIndex.RemoveAt(startIndex.Count - 1);
							break;
					}
				}
			}

			var numSb = new StringBuilder();

			var calcCharStack = new Stack<char>();
			var numValStack = new Stack<float>();

			for (int i = 0; i < text.Length; i++)
			{
				switch (text[i])
				{
					case '+':
					case '-':
						{
							if (float.TryParse($"{numSb}", out var val))
							{
								numValStack.Push(val);
								numSb.Clear();
								if (TryCalc(numValStack, calcCharStack, out var result))
								{
									numValStack.Push(result);
								}
							}
							calcCharStack.Push(text[i]);
						}
						break;
					case '*':
					case '/':
					case '%':
						{
							if (float.TryParse($"{numSb}", out var val))
							{
								numValStack.Push(val);
								numSb.Clear();
								if (calcCharStack.Any())
								{
									switch (calcCharStack.Last())
									{
										case '*':
										case '/':
										case '%':
											if (TryCalc(numValStack, calcCharStack, out var result))
											{
												numValStack.Push(result);
											}
											break;
									}
								}
							}
							calcCharStack.Push(text[i]);
						}
						break;
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
					case '.':
						numSb.Append(text[i]);
						break;
				}
			}

			if (numSb.Length > 0)
			{
				if (float.TryParse($"{numSb}", out var val))
				{
					numValStack.Push(val);
					numSb.Clear();
					if (TryCalc(numValStack, calcCharStack, out var result))
					{
						numValStack.Push(result);
					}
				}
			}

			return numValStack.First();
		}

		public static string ReplaceFromDic(string text, Dictionary<string, object> dic)
		{
			StringBuilder sb = new StringBuilder();
			// 変数置換
			// {{ }} で括られた変数を値に変更する
			{
				for (int i = 0; i < text?.Length; i++)
				{
					switch (text[i])
					{
						case '{':
							if (i + 1 < text.Length
								&& text[i + 1] == '{')
							{
								string key = "";

								int startIndex = 0;
								int endIndex = 0;
								startIndex = i;
								endIndex = 0;

								for (; i < text.Length; i++)
								{
									if (i + 1 < text.Length
										&& text[i] == '}' && text[i + 1] == '}')
									{
										key = text.Substring(startIndex + 2, i - startIndex - 2);
										key = key.Replace(" ", "");
										if (dic.TryGetValue(key, out var v))
										{
											endIndex = (i + 2);
											sb.Append(v);
											i++;
											break;
										}
									}
									if (endIndex != 0)
									{
										break;
									}
								}
								if (endIndex == 0)
								{
									i = startIndex;
									break;
								}
							}
							else
							{
								sb.Append(text[i]);
							}
							break;
						default:
							{
								sb.Append(text[i]);
							}
							break;
					}
				}
			}

			return $"{sb}";
		}


		public static string ReplaceFromJson(string text, Hjson.JsonValue json)
		{
			StringBuilder sb = new StringBuilder();
			// 変数置換
			// {{ }} で括られた変数を値に変更する
			{
				for (int i = 0; i < text?.Length; i++)
				{
					switch (text[i])
					{
						case '{':
							if (i + 1 < text.Length
								&& text[i + 1] == '{')
							{
								string key = "";

								int startIndex = 0;
								int endIndex = 0;
								startIndex = i;
								endIndex = 0;

								for (; i < text.Length; i++)
								{
									if (i + 1 < text.Length
										&& text[i] == '}' && text[i + 1] == '}')
									{
										key = text.Substring(startIndex + 2, i - startIndex - 2);
										key = key.Replace(" ", "");

										var v = json.EQs(key);
										if(v!=null)
										{
											endIndex = (i + 2);
											sb.Append(v);
											i++;
											break;
										}
									}
									if (endIndex != 0)
									{
										break;
									}
								}
								if (endIndex == 0)
								{
									i = startIndex;
									break;
								}
							}
							else
							{
								sb.Append(text[i]);
							}
							break;
						default:
							{
								sb.Append(text[i]);
							}
							break;
					}
				}
			}

			return $"{sb}";
		}

		/// <summary>
		/// Html色コード
		/// #FFFFFF のようなコードを値型にして返す
		/// </summary>
		/// <param name="htmlColor"></param>
		/// <returns></returns>
		public static bool TryGetColor(string htmlColor, out int color)
		{
			string text = htmlColor.Substring(1, 6);

			if (int.TryParse(text, System.Globalization.NumberStyles.HexNumber, null, out color))
			{
				return true;
			}
			else
			{
				color = 0xFFFFFF;
				return false;
			}
		}

	}
}
