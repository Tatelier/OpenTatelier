using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Interface.Command;
using Tatelier.Interface.Scene;
using static DxLibDLL.DX;

namespace Tatelier
{

	/// <summary>
	/// シーン管理 ※シングルトン
	/// </summary>
	class SceneControl
		: Interface.Scene.ISceneControl
	{
		static T Construct<T, P1>(P1 p1)
			 where T : IScene, new()
		{
			T instance;
			try
			{
				instance = (T)typeof(T).GetConstructor(new Type[] { typeof(P1) }).Invoke(new object[] { p1 });
			}
			catch
			{
				instance = new T();
			}

			return instance;
		}

		public static SceneControl Singleton { get; private set; } = new SceneControl();

		IScene nowScene;

		public bool IsNowCurrent<T>()
			where T : IScene
		{
			return nowScene is T;
		}

		bool ISceneControl.IsCurrentScene<T>() => IsNowCurrent<T>();

		public bool DebugActive { get; private set; } = false;

		public ResultType CommandSearchAndRun(string command, params string[] args)
		{
			switch (command)
			{
				case "/debug":
					DebugActive = MainConfig.Singleton.Debug;
					break;
				case "/scene":
					{
						LogWindow.Singleton.Insert($"現在利用できないコマンドです。 {command}");
					}
					break;
				default:
					return nowScene.CommandSearchAndRun(command, args);
			}
			return ResultType.Exit;
		}

		Queue<IScene> destroyList = new Queue<IScene>();
		Queue<IScene> createList = new Queue<IScene>();

		LinkedList<(IScene, IEnumerator)> startEnumeratorList = new LinkedList<(IScene, IEnumerator)>();


		List<(float, IScene)> updateAddList = new List<(float, IScene)>();

		SortedDictionary<float, IScene> updateList2 = new SortedDictionary<float, IScene>();

		public int Create<T>(out T scene, params object[] args) where T : IScene, new()
        {
			return Create(null, out scene, args);
		}

		public int Create<T>(string name, out T scene, params object[] args) where T : IScene, new()
		{
#if DEBUG
			scene = name != null ? Construct<T, string>(name) : new T();
#else
			scene = new T();
#endif

            int ret = scene.PreStart(args);

			if (ret != 0)
			{
				scene = default;
				return -2;
			}

			createList.Enqueue(scene);
			startEnumeratorList.AddLast((scene, scene.GetStartIterator()));

			return 0;
		}

		/// <summary>
		/// シーンを破棄する
		/// </summary>
		/// <param name="scene">破棄するシーン</param>
		/// <param name="sender">指示を出したシーン</param>
		public void Destroy(IScene scene, IScene sender = null)
		{
			Unregist(scene);
			destroyList.Enqueue(scene);
		}

		/// <summary>
		/// カレントシーンを切り替える
		/// </summary>
		/// <param name="scene">カレントにするシーン</param>
		/// <param name="sender">指示したシーン</param>
		public void Enter(IScene scene, IScene sender)
		{
			nowScene.OnLeave(sender);
			nowScene = scene;
			scene.OnEnter(sender);
		}

		/// <summary>
		/// 登録する
		/// </summary>
		/// <param name="layer">表示レイヤー</param>
		/// <param name="scene">登録するシーン</param>
		public void Regist(float layer, SceneBase scene)
		{
			updateAddList.Add((layer, scene));
		}

		public void Unregist(IScene scene)
		{
			updateAddList.Add((-1.0F, scene));
		}

		public void Start<T>(object[] args = null)
			where T : IScene, new()
		{
			Create<T>(out var s);
			nowScene = s;
			nowScene.DebugWindow.Start();
			DebugActive = MainConfig.Singleton.Debug;

			Update();
		}

		void UpdateSystem()
		{
			// 破棄
			while (destroyList.Any())
			{
				var item = destroyList.Dequeue();
				item.Finish();
				item.DebugWindow.Finish();
			}

			// 生成
			while (createList.Any())
			{
				var item = createList.Dequeue();
				item.Start();
				item.DebugWindow.Start();
			}

			// 初期化列挙&
			if (startEnumeratorList.Any())
			{
				var node = startEnumeratorList.First;

				while (node != null)
				{
					if (!node.Value.Item2.MoveNext())
					{
						var next = node.Next;
						startEnumeratorList.Remove(node);
						node = next;
					}
					else
					{
						node = node.Next;
					}
				}
			}

			if (updateAddList.Any())
			{
				foreach (var item in updateAddList)
				{
					var first = updateList2.FirstOrDefault(v => v.Value == item.Item2);
					if (first.Value != default)
					{
						updateList2.Remove(first.Key);
					}

					if (item.Item1 > 0)
					{
						updateList2[item.Item1] = item.Item2;
					}
				}
				updateAddList.Clear();
			}
		}

		public void Update()
		{

			UpdateSystem();

			if (updateList2.Any())
			{
				foreach(var item in updateList2.Values)
				{
					item.Update();
				}
			}

			nowScene.DebugWindow.Update();

#if DEBUG
			if (Input.Singleton.GetKeyDown(KEY_INPUT_BACKSLASH))
			{
				throw new NotImplementedException();
			}
#endif
		}

		public void Draw()
		{
			if (updateList2.Any())
			{
				foreach (var item in updateList2.Values)
				{
					item.Draw();
				}
			}
			nowScene.DebugWindow.Draw();
			//int y = 0;

			//foreach(var item in updateList2.Values)
			//{
			//	DrawString(0, y, $"{item}", 0xFFFFFF);
			//	y += 40;
			//}
		}

		public void Reset()
		{
			Singleton = new SceneControl();
		}

		int ISceneControl.CreateScene<T>(string name, out T scene, params object[] args)
		{
			int result = Create<T>(name, out scene, args);
			return result;
		}

		public SceneControl()
		{
		}
	}
}
