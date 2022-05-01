using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class TatelierServerManager
	{
		static TatelierServerManager singleton = new TatelierServerManager();
		public static TatelierServerManager Singleton => singleton;

		Network.BattleServer server;

		void Accept()
		{

		}

		void RecvInitData(Network.Parser.StartUp data)
		{

		}

		void Send(MemoryStream ms, Network.BattleServerItem ignoreItem)
		{
			foreach (var it in server.ItemList.Where(v => v != ignoreItem))
			{
				it.Send(ms);
			}
		}

		void RecvSystemCommand(Network.BattleServerItem item, MemoryStream ms)
		{
			var bytes = ms.GetBuffer();
			int length = (int)ms.Length;

			var startUp = Network.Parser.StartUp.Default;
			startUp.Parse(bytes, 1);

			item.Name = startUp.PlayerName;
			item.ID = startUp.ID;

			LogWindow.Singleton.Insert($"{item.Name} が参加しました", LogWindow.UpdateNoticeColor);

			Send(ms, item);
		}

		void RecvBattleCommandInit(Network.BattleServerItem item, MemoryStream ms)
		{
			var bytes = ms.GetBuffer();
			int length = (int)ms.Length;

			var startUp = Network.Parser.StartUp.Default;
			startUp.Parse(bytes, 1);

			item.Name = startUp.PlayerName;
			item.ID = startUp.ID;

			LogWindow.Singleton.Insert($"{item.Name} が参加しました", LogWindow.UpdateNoticeColor);
		}

		void RecvBattleCommandComment(Network.BattleServerItem item, MemoryStream ms)
		{

		}

		void RecvBattleCommand(Network.BattleServerItem item, MemoryStream ms)
		{
			ms.Seek(2, SeekOrigin.Begin);

			ushort subCommand = (ushort)(ms.ReadByte() + (ms.ReadByte() << 8));

			if (subCommand == 0x0001)
			{
				RecvBattleCommandInit(item, ms);
			}
			else if (subCommand == 0x0002)
			{
				RecvBattleCommandComment(item, ms);
			}
		}

		void Recv(Network.BattleServerItem item, MemoryStream ms)
		{
			var bytes = ms.GetBuffer();
			int length = (int)ms.Length;

			// ヘッダー部がなければ処理しない
			if(length < 1)
			{
				return;
			}

			switch (bytes[0])
			{
				case 0x00:
					RecvSystemCommand(item, ms);
					break;
				case 0x02:
					RecvBattleCommand(item, ms);
					break;
			}
		}

		void Close(Network.BattleServerItem item)
		{
			LogWindow.Singleton.Insert($"{item.Name} が退出しました", LogWindow.UpdateNoticeColor);
		}

		void Error(int errorCode)
		{

		}

		public void Start(int port)
		{
			server = new Network.BattleServer(port);
			server.OnAccept += Accept;
			server.OnRecv += Recv;
			server.OnClose += Close;
			server.OnError += Error;
			server.Start();
		}
	}
}
