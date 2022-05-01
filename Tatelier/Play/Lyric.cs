using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tatelier.Play
{
	[DebuggerDisplay("Time : {Time}, Text : {Text}")]
	class LyricItem
	{
		public int Time;
		public string Text;
	}
	class Lyric
	{
		public List<LyricItem> List { get; }

		public bool HasLyric => List.Any();

		public Lyric(string filePath)
		{
			List = new List<LyricItem>();

			string[] lines;

			if (File.Exists(filePath))
			{
				lines = File.ReadAllLines(filePath, Utility.GetEncodingFromFile(filePath) ?? Encoding.UTF8);
			}
			else
			{
				lines = new string[0];
			}

			var regex = new Regex(@"\[(\S+)\](.*)");

			foreach (var line in lines)
			{
				try
				{
					if (regex.IsMatch(line))
					{
						var groups = regex.Match(line).Groups;

						string[] split = groups[1].Value.Split(':', '.');

						int time = 0;

						if (split.Length == 2)
						{
							time += int.Parse(split[0]) * 60000;
							time += int.Parse(split[1]) * 1000;
						}
						else
						{
							time += int.Parse(split[0]) * 60000;
							time += int.Parse(split[1]) * 1000;
							time += int.Parse(split[1]) * 10;
						}

						List.Add(new LyricItem()
						{
							Time = time,
							Text = groups[2].Value,
						});
					}
				}
				catch
				{

				}
			}
		}
	}
}
