using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Common
{
	enum TatelierTextType
	{
		NameToValue,
		Lines,
	}

	/// <summary>
	/// タトリエテキスト
	/// </summary>
	class TatelierText
	{
		public Dictionary<string, StringBuilder>
			TextMap = new Dictionary<string, StringBuilder>();

		public TatelierText(string filePath, string nameOnly)
		{
			var sb = new StringBuilder();

			string name = "";

			var fs = new FileStream(filePath, FileMode.Open);
			byte[] bytes = new byte[256];
			fs.Read(bytes, 0, bytes.Length);
			fs.Position = 0;
			var encoding = Utility.GetCode(bytes);

			bool isOKName = name == nameOnly;

			using (fs)
			using (var sr = new StreamReader(fs))
			{
				string line;
				while (!sr.EndOfStream)
				{
					line = sr.ReadLine();

					int index = line.IndexOf("//");

					if (index != -1)
					{
						line = line.Substring(0, index);
					}

					// 0文字行はパスする
					if (line.Length <= 0)
					{
						continue;
					}

					// []で括られていれば処理する
					if (line[0] == '[' && line.Contains(']'))
					{
						if (isOKName)
						{
							TextMap[name] = sb;

							break;
						}

						int last = line.IndexOf(']');
						name = line.Substring(1, last - 1);

						isOKName = name == nameOnly;
					}
					else
					{
						if (isOKName)
						{
							sb.AppendLine(line);
						}
					}
				}

				TextMap[name] = sb;
			}
		}

		public TatelierText(string filePath)
		{
		}
	}
}
