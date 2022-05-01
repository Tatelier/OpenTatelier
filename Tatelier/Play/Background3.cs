using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
	class Background3
	{
		class Background3Item
		{
			public class Item
			{
				public class Element
				{
					public int State = 0xFFFF;
					public virtual void Update() { }
					public virtual void Draw(Background3 background, Transform3 transform) { }

					public virtual void Init(string folder, Hjson.JsonValue json)
					{

						var stateList = json.EQa("State");

						if (stateList?.Count > 0)
						{
							State = 0;
							foreach (var item in stateList ?? HjsonEx.Empty.Array)
							{
								switch (item.EQs())
								{
									case "Normal":
										State |= 0x0001;
										break;
									case "Clear":
										State |= 0x0002;
										break;
									case "Failure":
										State |= 0x0004;
										break;
								}
							}
						}
					}
				}
				public class ImageElement : Element
				{
					DrawingOption drawingOption;

					public override void Update()
					{
						drawingOption.Update();
					}

					public override void Draw(Background3 background, Transform3 transform)
					{
						if (((State & background.State) == 0)) return;

						drawingOption.Draw(transform);
					}
					public override void Init(string folder, Hjson.JsonValue json)
					{
						base.Init(folder, json);

						drawingOption = new DrawingOption();
						int handle = ImageLoadControl.Singleton.Load(Path.Combine(folder, json.EQs("FilePath") ?? ""));
						drawingOption.SetFromJson(json.EQa("Components") ?? HjsonEx.Empty.Array);

						drawingOption.Tile = (json.EQi("Tile") ?? 0);

					}

					public void Init(string folder, Hjson.JsonValue json, Dictionary<string, object> replaceMap)
					{
						base.Init(folder, json);
						int handle = ImageLoadControl.Singleton.Load(Path.Combine(folder, Common.Utility.ReplaceFromDic(json.EQs("FilePath"), replaceMap) ?? ""));

						drawingOption = new DrawingOption();
						drawingOption.SetFromJson(json.EQa("Components") ?? HjsonEx.Empty.Array);
						drawingOption.Handle = handle;
						drawingOption.Tile = (json.EQi("Tile") ?? 0);
					}

					public ImageElement()
					{

					}
				}

				List<Element> elements = new List<Element>();


				public void Update()
				{
					foreach (var item in elements)
					{
						item.Update();
					}
				}

				public void Draw(Background3 background, Transform3 transform)
				{
					foreach (var item in elements)
					{
						item.Draw(background, transform);
					}
				}

				public void Init(string folder, Hjson.JsonValue json, Dictionary<string, object> replaceMap)
				{
					var elements = json.EQa("Elements") ?? HjsonEx.Empty.Array;

					foreach (var item in elements)
					{
						var itemInstance = new ImageElement();
						itemInstance.Init(folder, item, replaceMap);
						this.elements.Add(itemInstance);
					}
				}
			}

			RectF rect;
			Transform3 transform;

			Item item = new Item();


			public void Update()
			{
				item.Update();
			}

			public void Draw(Background3 background3)
			{
				item.Draw(background3, transform);
			}

			public int Init(string folder, Hjson.JsonValue json, int seed, Dictionary<string, object> replaceMap)
			{
				if (json == null)
				{
					json = HjsonEx.Empty.Value;
				}

				var randomFolder = Path.Combine(folder, "Random");
				if (!Directory.Exists(randomFolder))
				{
					return -1;
				}
				var dir = Directory.EnumerateDirectories(randomFolder).RandomAt(seed);
				var configJson = HjsonEx.HjsonEx.LoadEx(Path.Combine(dir, "config.hjson"));

				if (configJson == null)
				{
					return -2;
				}

				rect = new RectF();
				rect.Set(json.EQv("Rect") ?? HjsonEx.Empty.Value);

				transform = new Transform3();
				transform.SetFromRect(rect);

				item.Init(dir, configJson, replaceMap);
				return 0;
			}

			public Background3Item()
			{
			}
		}

		List<Background3Item> list = new List<Background3Item>();

		int index = 0;

		public int State = 1;

		public void Change(StatusType statusType)
		{
			switch (statusType)
			{
				case StatusType.Normal:
				default:
					State = 0x01;
					break;
				case StatusType.Clear:
					State = 0x02;
					break;
			}
		}

		public void Update()
		{
			index = 0;
			foreach(var item in list)
            {
				item.Update();
            }
		}

		public void Draw()
        {
			if (index < list.Count)
			{
				list[index].Draw(this);
				index++;
			}
        }

		/// <summary>
		/// 初期化処理
		/// </summary>
		/// <param name="folder">カレンドディレクトリパス</param>
		/// <param name="json">設定情報</param>
		/// <param name="seed">シード値</param>
		/// <param name="replaceMap">置換マップ</param>
		public void Init(string folder, Hjson.JsonValue json, int seed, Dictionary<string, object> replaceMap)
        {
			if (json == null)
            {
				return;
            }

			folder = Path.Combine(folder, json.EQs("FolderPath") ?? "Background");
			var split = json?.EQs("Name").Split(new string[] { "::" }, StringSplitOptions.None);

            if (split?.Length < 2)
            {
				return;
            }

			string childName = split[1] ?? "";


			switch (childName)
			{
				case "Upper":
				case "Lower":
				case "Stage":
                    {
						var item = new Background3Item();
                        if (item.Init(Path.Combine(folder, childName), json, seed, replaceMap) == 0)
						{
						}
						list.Add(item);
                    }
					break;
            }
        }

		public Background3(string folder, Hjson.JsonValue json)
		{
			var backgroundJson = HjsonEx.HjsonEx.LoadEx("");
		}
	}
}
