using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
	class LyricImageControlItem
	{
		public int Time;
		public int Handle;
	}

	/// <summary>
	/// 歌詞画像管理
	/// </summary>
	class LyricImageControl : IDisposable
	{
		bool disposed = false;

		LinkedList<LyricImageControlItem> lyricItemList;

		bool isVisible = false;

		LinkedListNode<LyricImageControlItem> currentItem;

		float xf;
		float yf;

		public void Draw()
		{
			if (isVisible)
			{
				DrawRotaGraphF(xf, yf, 1.0, 0.0, currentItem.Value.Handle, DX_TRUE);
			}
		}

		public void Update(int nowMillisec)
		{
			if(!isVisible)
			{
				if(currentItem.Value.Time <= nowMillisec)
				isVisible = true;
			}

			if(currentItem != lyricItemList.Last 
				&& currentItem.Next.Value.Time <= nowMillisec)
			{
				currentItem = currentItem.Next;
			}
		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					foreach(var item in lyricItemList)
					{
						ImageLoadControl.Singleton.Delete(item.Handle);
					}
				}
				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~LyricImageControl()
		{
			Dispose();
		}

		public LyricImageControl(string filePath, Hjson.JsonValue json)
		{

			if (json == null)
			{
				json = HjsonEx.Empty.Value;
			}

			lyricItemList = new LinkedList<LyricImageControlItem>();

			int fontSize = json.EQi("Font.Size") ?? 40;
			string fontName = json.EQs("Font.Name") ?? MainConfig.Singleton.DefaultFont;
			uint fontColor = Utility.GetColor(json.EQs("Font.Color")) ?? 0xFFFFFF;
			int edgeSize = json.EQi("Font.Edge.Size") ?? 10;
			uint edgeColor = Utility.GetColor(json.EQs("Font.Edge.Color")) ?? 0x00000;

			xf = json.EQf("PointCX") ?? 0;
			yf = json.EQf("PointCY") ?? 0;

			string[] lines;

			if (File.Exists(filePath))
			{
				lines = File.ReadAllLines(filePath);
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

						lyricItemList.AddLast(new LinkedListNode<LyricImageControlItem>(new LyricImageControlItem()
						{
							Time = time,
							Handle = Utility.GetImageHandleFromText(groups[2].Value, fontColor, fontName, fontSize, edgeSize, edgeColor),
						}));
					}
				}
				catch
				{

				}
			}

			if (lyricItemList.Count == 0)
			{
				lyricItemList.AddLast(new LinkedListNode<LyricImageControlItem>(new LyricImageControlItem()
				{
					Time = 0,
					Handle = -1,
				}));
			}
			currentItem = lyricItemList.First;
		}
	}
}
