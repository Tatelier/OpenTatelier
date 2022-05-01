using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class LoadItemInfo
	{
		public bool CanMultiThread = false;

		public string Name = "";

		public string Text = "";

		public IEnumerator<(float, object)> Iterator;

	}
	class Load
	{
		public float MaxValue;

		public float NowValue;

		public float NowLoadPercent
		{
			get => (NowValue / MaxValue);
		}

		public string Text { get; private set; }

		public bool IsFinish => NowValue >= MaxValue;

		int resultDataIndex = 0;

		(string, object)[] resultData;

		IEnumerator UpdateIterator(LoadItemInfo[] iteratorList)
		{
			float start = 0;
			foreach (var item in iteratorList)
			{
				float now = start;
				Text = item.Name;
				if (item.CanMultiThread)
				{
					throw new NotImplementedException();
				}
				else
				{
					while (item.Iterator.MoveNext())
					{
						now = start + item.Iterator.Current.Item1;
						NowValue = now;
						if (item.Iterator.Current.Item1 < 1)
						{
							yield return now;
						}
						else
						{
							resultData[resultDataIndex].Item2 = item.Iterator.Current.Item2;
							resultDataIndex++;
						}
					}
					start++;
					NowValue = start;
				}
			}
		}

		IEnumerator iterator;

		public void Update()
		{
			if (!iterator.MoveNext())
			{

			}
		}

		public object GetResultObject(string name)
		{
			return resultData.FirstOrDefault(v => v.Item1 == name).Item2;
		}

		public int Set(LoadItemInfo[] iteratorList)
		{
			iterator = UpdateIterator(iteratorList);
			MaxValue = iteratorList.Length;

			resultData = new (string, object)[iteratorList.Length];

			for (int i = 0; i < iteratorList.Length; i++)
			{
				resultData[i].Item1 = iteratorList[i].Name;
			}

			return 0;
		}

		public Load()
		{

		}

		[Obsolete]
		public Load(LoadItemInfo[] iteratorList)
		{
			Set(iteratorList);
		}
	}
}
