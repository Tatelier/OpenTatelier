using HjsonEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score;

namespace Tatelier.Play
{
    class PlayInputItemControl
	{
		PlayInputItem[] playInputItemList;

		int currentIndex = 0;

		public void Add(int time, int key, JudgeType judgeType)
		{
			playInputItemList[currentIndex].Time = time;
			playInputItemList[currentIndex].Key = key;
			playInputItemList[currentIndex].JudgeType = judgeType;

			currentIndex++;
		}

		public void Reset()
		{
			for(int i = 0; i < playInputItemList.Length; i++)
			{
				playInputItemList[i].Time = int.MaxValue;
				playInputItemList[i].Key = 0;
				playInputItemList[i].JudgeType = JudgeType.None;
			}
		}

		public int Load(string filePath)
		{
			return 0;
		}

		public void Save()
		{
			Hjson.JsonObject json = new Hjson.JsonObject();
			json.Add("Elements", new Hjson.JsonArray());

			Hjson.JsonArray elements = json.EQa("Elements");

			for(int i = 0; i < playInputItemList.Length; i++)
			{
				if(playInputItemList[i].Time == int.MaxValue)
				{
					break;
				}
				var obj = new Hjson.JsonObject();
				obj["Time"] = playInputItemList[i].Time;
				obj["Key"] = playInputItemList[i].Key;
				obj["JudgeType"] = (int)playInputItemList[i].JudgeType;

				elements.Add(obj);
			}

			json["Elements"] = elements;
			json.Save("a.ttleprec");
		}

		public PlayInputItemControl()
		{
			playInputItemList = new PlayInputItem[10000];
			for(int i = 0; i < playInputItemList.Length; i++)
			{
				playInputItemList[i] = new PlayInputItem();
			}
		}
	}
}
