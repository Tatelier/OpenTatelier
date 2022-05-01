using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tatelier
{
	class CalcData
	{
		List<char> calcList;
		List<float> valueList;
		List<char> cclist;
		List<(int Index, Func<float> F)> flist;
		float[] tempValueList;

		float Add(float a, float b) => a + b;
		float Sub(float a, float b) => a - b;
		float Multi(float a, float b) => a * b;
		float W(float a, float b) => a / b;


		public float GetCalcValue()
		{
			// 変数代入
			for (int i = 0; i < flist.Count; i++)
			{
				valueList[flist[i].Index] = flist[i].F();
			}

			int tempValueListIndex = 0;

			var valueIterator = valueList.GetEnumerator();
			var calcIterator = calcList.GetEnumerator();

			for (int i = 0; i < cclist.Count; i++)
			{
				switch (cclist[i])
				{
					case 'c':
						{
							calcIterator.MoveNext();
							var ccc = calcIterator.Current;

							switch (ccc)
							{
								case '+':
									{
										tempValueList[tempValueListIndex - 2] = Add(tempValueList[tempValueListIndex - 2], tempValueList[tempValueListIndex - 1]);
									}
									break;
								case '*':
									{
										tempValueList[tempValueListIndex - 2] = Multi(tempValueList[tempValueListIndex - 2], tempValueList[tempValueListIndex - 1]);
									}
									break;
								case '-':
									{
										tempValueList[tempValueListIndex - 2] = Sub(tempValueList[tempValueListIndex - 2], tempValueList[tempValueListIndex - 1]);
									}
									break;
								case '/':
									{
										tempValueList[tempValueListIndex - 2] = W(tempValueList[tempValueListIndex - 2], tempValueList[tempValueListIndex - 1]);
									}
									break;
							}
							tempValueListIndex--;
						}
						break;
					case 'v':
						{
							valueIterator.MoveNext();
							tempValueList[tempValueListIndex] = valueIterator.Current;
							tempValueListIndex++;
						}
						break;
				}
			}


			return tempValueList[0];
		}

		public static CalcData Create()
		{
			string text = "{{ ScreenWidthHalf }} + 200 * 2";
			Dictionary<string, Func<float>> dic = new Dictionary<string, Func<float>>()
			{
				{ "ScreenWidthHalf", () => Supervision.ScreenWidthHalf }
			};
			var c = new CalcData(text, dic);


			return new CalcData(text, dic);
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
		void Analyze(string text, Dictionary<string, Func<float>> dic)
		{
			flist = new List<(int Index, Func<float>)>();
			calcList = new List<char>();
			cclist = new List<char>();
			valueList = new List<float>();


			// 空白除去
			text = text.Replace(" ", "");

			List<string> aaa = new List<string>();

			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < text.Length; i++)
			{
				switch (text[i])
				{
					case '+':
					case '-':
					case '*':
					case '/':
					case '%':
						aaa.Add($"{sb}");
						aaa.Add($"{text[i]}");
						sb.Clear();
						break;
					default:
						sb.Append(text[i]);
						break;
				}
			}

			aaa.Add($"{sb}");

			Stack<string> numStack = new Stack<string>();
			Stack<string> calcStack = new Stack<string>();


			for (int i = 0; i < aaa.Count; i++)
			{
				var item = aaa[i];
				if (item.Length == 1)
				{
					switch (item[0])
					{
						case '+':
						case '-':
							{
								while (calcStack.Count > 0)
								{
									numStack.Push(calcStack.Pop());

								}
								calcStack.Push(item);
							}
							break;
						case '*':
						case '/':
						case '%':
							{
								calcStack.Push(item);

							}
							break;
						default:
							numStack.Push(item);
							break;
					}
				}
				else
				{
					numStack.Push(item);
				}
			}

			while (calcStack.Count > 0)
			{
				numStack.Push(calcStack.Pop());
			}
			string[] sssss = numStack.Reverse().ToArray();

			foreach (var ssi in sssss)
			{
				if (ssi.Length == 1)
				{
					switch (ssi[0])
					{
						case '+':
						case '-':
						case '*':
						case '/':
						case '%':
							cclist.Add('c');
							calcList.Add(ssi[0]);
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
							cclist.Add('v');
							valueList.Add(float.Parse(ssi));
							break;
						default:
							break;
					}
				}
				else
				{
					cclist.Add('v');

					if (ssi.StartsWith("{{")
						&& ssi.EndsWith("}}")
						&& dic.TryGetValue(ssi.Substring(2, ssi.Length - 4), out var f))
					{
						flist.Add((valueList.Count, f));
						valueList.Add(0);
					}
					else
					{
						if (float.TryParse(ssi, out var v))
						{
							valueList.Add(v);
						}
					}
				}
			}
			tempValueList = new float[cclist.Count];
			//cclist.Reverse();
		}

		public CalcData(string text, Dictionary<string, Func<float>> dic)
		{
			Analyze(text, dic);

		}
	}
}
