using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.DxLibDLL;
using static DxLibDLL.DX;
using HjsonEx;
using System.Diagnostics;

namespace Tatelier.Play
{
	/// <summary>
	/// ダンサー画像クラス
	/// </summary>
	class DancerImageItem : IDisposable
	{
		bool disposed = false;

		public int[] Handles;

		public float ScaleRate = 1.0F;

		public void Dispose()
		{
			if (!disposed)
			{
				ImageLoadControl.Singleton.Delete(Handles);
				disposed = true;
			}
		}

		~DancerImageItem()
		{
			Dispose();
		}
	}

	[DebuggerDisplay("State: {State}")]
	class DancerItem
	{
		public DancerImageItem DancerImageItem;
		public int State { get; internal set; } = 0;

		public int NowIndex = 0;

		long time = -1;

		long diff;

		public void Update(long measureTime)
		{
			long oneFrameTime = measureTime / DancerImageItem.Handles.Length;

			long nowTime = Supervision.NowMicroSec;
			long temp = nowTime - time;

			diff = diff + temp;

			while (oneFrameTime < diff)
			{
				diff -= oneFrameTime;
				NowIndex = (NowIndex + 1) % DancerImageItem.Handles.Length;
			}

			time = Supervision.NowMicroSec;
		}
	}


	class Dancer : IDisposable
	{
		bool disposed = false;

		List<DancerImageItem> dancerItems = new List<DancerImageItem>();

		DancerItem[] dancer = new DancerItem[5];

		double bpm;

		public double BPM
		{
			get => bpm;
			set
			{
				if (value <= 0)
				{
					value = 1;
				}
				bpm = value;
				MeasureTime = (long)(60000000 * 2 / bpm);
			}
		}

		long MeasureTime;

		int startNum = 1;

		int cnt = 1;

		int[] indexList;
		int randomListIndex = 0;

		public void Update(int nowGaugeValue)
		{
			cnt = (nowGaugeValue / 1600) + 1;

			if (cnt < startNum) cnt = startNum;

			if (cnt > 5) cnt = 5;

			for (int i = startNum; i < dancer.Length; i++)
			{
				if (dancer[i].State == 0
					&& i < cnt)
				{
					dancer[i].State = 1;
					dancer[i].DancerImageItem = dancerItems[indexList[randomListIndex]];

					randomListIndex = (randomListIndex + 1) % indexList.Length;

					dancer[i].NowIndex = dancer[i - 1].NowIndex;

				}
				else if (dancer[i].State == 1
					&& i >= cnt)
				{
					dancer[i].State = 0;
				}
			}

			for (int i = 0; i < dancer.Length; i++)
			{
				dancer[i].Update(MeasureTime);
			}
		}

		public void Draw()
		{
			using (DrawModeGuard.Create())
			{
				SetDrawMode(DX_DRAWMODE_NEAREST);

				for (int i = 0; i < cnt; i++)
				{
					if (dancer[i].State == 1)
					{
						if (i % 2 == 0)
						{
							DrawRotaGraphF(Supervision.ScreenWidthHalf + 360 * ((i + 1) / 2), 780, 20.0, 0.0, dancer[i].DancerImageItem.Handles[dancer[i].NowIndex], DX_TRUE);
						}
						else
						{
							DrawRotaGraphF(Supervision.ScreenWidthHalf - 360 * ((i + 1) / 2), 780, 20.0, 0.0, dancer[i].DancerImageItem.Handles[dancer[i].NowIndex], DX_TRUE);
						}
					}
				}
			}
		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					// unmanaged
				}

				// managed

				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~Dancer()
		{
			Dispose();
		}


		public Dancer(string folder, Hjson.JsonValue json)
		{
			if(json == null)
			{
				json = new Hjson.JsonObject();
			}

			string dancerFolderPath = Path.Combine(folder, json.EQs("Folder") ?? "Dancer");
			var dancer_config_json = Hjson.HjsonValue.Load(Path.Combine(dancerFolderPath, "DancerConfig.hjson"));

			var random = dancer_config_json.EQb("Dancer.Random");

			int[] handles;

			if (random ?? true)
			{
				var dir = Directory.EnumerateDirectories(dancerFolderPath).RandomAt();
				var dancer_json = Hjson.HjsonValue.Load(Path.Combine(dir, "dancer.hjson"));

				var elements = dancer_json.EQa("Elements") ?? HjsonEx.Empty.Array;
				startNum = dancer_json.EQi("StartNum") ?? 1;

				foreach (var element in elements)
				{
					var path = element.EQs("Path");
					var scaleRate = element.EQf("ScaleRate") ?? 1.0f;
					var itemSplit = element.EQv("ItemSplit");

					string filePath = Path.Combine(dir, path);


					if (itemSplit != null)
					{
						handles = new int[itemSplit.EQi("Count") ?? 1];

						LoadDivGraph(filePath,
							itemSplit.EQi("Count") ?? 1,
							itemSplit.EQi("XNum") ?? 1,
							itemSplit.EQi("YNum") ?? 1,
							itemSplit.EQi("Width") ?? 16,
							itemSplit.EQi("Height") ?? 16,
							handles);
					}
					else
					{
						handles = new int[1];
						handles[0] = ImageLoadControl.Singleton.Load(filePath);
					}

					var item = new DancerImageItem()
					{
						Handles = handles,
						ScaleRate = scaleRate,
					};

					dancerItems.Add(item);
				}

				indexList = new int[dancerItems.Count * 3];
				for (int i = 0; i < indexList.Length; i++)
				{
					indexList[i] = i / 3;
				}

				var r = new Random();

				for (int i = 0; i < indexList.Length; i++)
				{
					int a = r.Next(0, indexList.Length);
					int b = r.Next(0, indexList.Length);

					int temp = indexList[a];
					indexList[a] = indexList[b];
					indexList[b] = temp;
				}

				for (int i = 0; i < dancer.Length; i++)
				{
					dancer[i] = new DancerItem();
				}
			}
			for (int i = 0; i < dancer.Length; i++)
			{
				dancer[i].DancerImageItem = dancerItems.RandomAt();
			}


			for (int i = 0; i < startNum; i++)
			{
				dancer[i].State = 1;
			}
		}
	}
}
