using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Interface;
using Tatelier.Interface.Command;
using Tatelier.Interface.Scene;

namespace Tatelier
{
	[DebuggerDisplay("Name: {name}, Type: {ToString()}")]
	abstract class SceneBase : Interface.Scene.IScene
	{
		string name;

		float layer = -1.0F;

		public float Layer
		{
			get
			{
				return layer;
			}
			set
			{
				layer = value;
				if (layer < 0)
				{
					SceneControl.Singleton.Unregist(this);
				}
				else
				{
					SceneControl.Singleton.Regist(layer, this);
				}
			}
		}

		public abstract SceneType SceneType { get; }

		public DebugWindow DebugWindow { get; }

		IDebugWindow IScene.DebugWindow => DebugWindow;

		public abstract ResultType CommandSearchAndRun(string command, params string[] args);

		public int Enter(IScene sender)
		{
			SceneControl.Singleton.Enter(this, sender);
			return 0;
		}

		public int EnterTo(IScene to)
        {
			return (to as SceneBase).Enter(this as IScene);
        }

		int Message(IScene sender, params object[] args)
		{
			OnMessage(sender, args);
			return 0;
		}

		public int MessageTo(IScene to, params object[] args)
		{
			return (to as SceneBase).Message(this, args);
		}

		public void Regist(float layer)
		{
			SceneControl.Singleton.Regist(layer, this);
		}

		public virtual void OnEnter(IScene sender) { }
		public virtual void OnLeave(IScene sender) { }
		public virtual void OnMessage(IScene sender, params object[] args) { }

		/// <summary>
		/// 初期化処理魔の準備処理
		/// </summary>
		/// <param name="args"></param>
		/// <returns>0: 正常, 0以外: 異常</returns>
		public virtual int PreStart(params object[] args)
		{
			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual IEnumerator<float> GetStartIterator()
        {
			yield break;
        }

		/// <summary>
		/// 初期化処理
		/// </summary>
		public abstract void Start();

		/// <summary>
		/// 更新処理
		/// </summary>
		public abstract void Update();

		/// <summary>
		/// 描画処理
		/// </summary>
		public abstract void Draw();

		/// <summary>
		/// 終了処理
		/// </summary>
		public abstract void Finish();

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SceneBase()
		{
			DebugWindow = new DebugWindow();
		}

		public SceneBase(string name) : this()
        {
			this.name = name;
        }
	}
}
