using HjsonEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	class SongSelectConfig
	{
		public class Info
		{
			public Hjson.JsonValue Json { get; set; }
			public int PlayerNum = 1;
			public Dictionary<string, Action<int>> DrawActionMap;
			public Dictionary<string, Action<int>> UpdateActionMap;
		}
		public enum Type : int
		{
			Background,
			FixedImage,
			SelectItem,
			SoundEffect,
			Demo,
			KeyConfig,
			CourseSelectCursor,
			Length,
		}

		List<Hjson.JsonValue>[] itemList;

		public List<Hjson.JsonValue> BackgroundList => Get(Type.Background);

		public List<Hjson.JsonValue> SelectItemList => Get(Type.SelectItem);

		public List<Hjson.JsonValue> SoundEffectList => Get(Type.SoundEffect);

		public List<Hjson.JsonValue> DemoList => Get(Type.Demo);

		public List<Hjson.JsonValue> KeyConfigList => Get(Type.KeyConfig);

		/// <summary>
		/// 描画処理順のメソッドリスト
		/// </summary>
		public (int PlayerNumbrt, Action<int> Act)[] DrawActList;

		/// <summary>
		/// 更新処理順のメソッドリスト
		/// </summary>
		public (int PlayerNumbrt, Action<int> Act)[] UpdateActList;


		public List<Hjson.JsonValue> Get(Type type) => itemList[(int)type];

		public SongSelectConfig(SongSelectConfig.Info info)
		{
			itemList = new List<Hjson.JsonValue>[(int)Type.Length];

			for (int i = 0; i < (int)Type.Length; i++)
			{
				itemList[i] = new List<Hjson.JsonValue>();
			}

			var map = new Dictionary<string, Type>()
			{
				{ "Background", Type.Background },
				{ "FixedImage", Type.FixedImage },
				{ "KeyConfig", Type.KeyConfig },
				{ "Demo", Type.Demo },
				{ "SoundEffect", Type.SoundEffect },
				{ "SelectItem", Type.SelectItem },
				{ "CourseSelectCursor", Type.CourseSelectCursor }
			};

			var drawActList = new List<(int, Action<int>)>();
			var updateActList = new List<(int, Action<int>)>();



			try
			{
				var hjson = info.Json;

				foreach (var item in hjson.EQa("Elements"))
				{
					var name = item.EQs("Name").Replace("::", ".");
					Action<int> drawAct = null;
					Action<int> updateAct = null;

					info.DrawActionMap?.TryGetValue(name, out drawAct);
					info.UpdateActionMap?.TryGetValue(name, out updateAct);

					if (map.TryGetValue(name, out var t))
					{
						itemList[(int)t].Add(item);
					}
					else
					{
						continue;
					}

					int num = (item.EQi("Player") ?? 1) - 1;

					if (drawAct != null)
					{
						drawActList.Add((num, drawAct));
					}

					if (updateAct != null)
					{
						updateActList.Add((num, updateAct));
					}
				}
			}
			catch
			{
				//Error.Add()
			}


			DrawActList = drawActList.ToArray();
			UpdateActList = updateActList.ToArray();

		}
	}
}
