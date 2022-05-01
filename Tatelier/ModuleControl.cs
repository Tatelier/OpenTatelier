using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Module.DiscordRPC;

namespace Tatelier
{
	class ModuleControl
	{
		public static ModuleControl Singleton { get; } = new ModuleControl(@".\.ttle_modules");

		List<Assembly> list = new List<Assembly>();


		ITatelierDiscordRPC discordRPC;


		public string DiscordState
		{
			get
			{
				return discordRPC?.Presence.State ?? "";
			}
			set
			{
				if (discordRPC != null)
				{
					discordRPC.Presence.State = value;
					discordRPC.UpdatePresence();
				}
			}
		}


		public void Start()
		{

		}

		public ModuleControl(string moduleFolder)
		{
            if (!Directory.Exists(moduleFolder))
            {
				return;
            }

			var folders = Directory.GetDirectories(moduleFolder);
			foreach (var item in folders)
			{

				var hjson = HjsonEx.HjsonEx.LoadEx(Path.Combine(item, "package.hjson"));
				var dll = Path.Combine(Path.Combine(item, hjson.EQs("Main") ?? "main.dll"));

				var asm = Assembly.LoadFile(Path.GetFullPath(dll));       // アセンブリの読み込み

				var types = asm.GetTypes();

				var t = types.Where(v => v.IsClass && v.IsPublic & !v.IsAbstract)
					.FirstOrDefault(v => v.GetInterfaces().FirstOrDefault(w => w == typeof(Tatelier.Module.DiscordRPC.ITatelierDiscordRPC)) != null);

				if (t != null)
				{
					// CSharpDll.Personクラスをインスタンス化.
					// コンストラクタへ引数を渡すことも可能.
					var p1 = Activator.CreateInstance(t) as Tatelier.Module.DiscordRPC.ITatelierDiscordRPC;
					discordRPC = p1;
					discordRPC.Initialize("836117107736969236");
					DiscordState = $"v{Supervision.Singleton.Version}";
					discordRPC.UpdatePresence();
				}
			}
		}
	}
}
