using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class TatelierClientManager
	{
		static TatelierClientManager singleton = new TatelierClientManager();
		public static TatelierClientManager Singleton => singleton;
		

		Tatelier.Network.BattleClient client;

		/// <summary>
		/// 接続状態かどうか
		/// </summary>
		public bool Connected
        {
            get
            {
				return client != null;
            }
        }

		/// <summary>
		/// 接続先URL
		/// </summary>
		public string ConnectUrl
        {
            get
            {
				return client?.Url ?? "None.";
            }
        }

		void Error(int a)
		{
			// とりあえず、何もしないように
			//client = null;
			//LogWindow.Singleton.Insert("切断されました。");
		}

		void Open()
		{
			SendInitData();
			LogWindow.Singleton.Insert("サーバへの接続が完了しました。");
		}

		void Recv(MemoryStream ms)
		{
			var bytes = ms.GetBuffer();
			int length = (int)ms.Length;

			var startUp = Network.Parser.StartUp.Default;
			startUp.Parse(bytes, 1);

			LogWindow.Singleton.Insert($"{startUp.PlayerName} が参加しました", LogWindow.UpdateNoticeColor);
		}

		void Close(int code)
		{
			if (code == 0)
			{
				LogWindow.Singleton.Insert("サーバから切断されました。");
			}
			else if (code == 1)
			{
				LogWindow.Singleton.Insert("切断しました。");
			}
			Finish();
		}

		public int Start(string url)
		{
			client = new Network.BattleClient(url);
			client.OnOpen += Open;
			client.OnError += Error;
			client.OnRecv += Recv;
			client.OnClose += Close;
			client.Start();

			return 0;
		}

		public int Finish()
		{
			client.Finish();
			client = null;
			return 0;
		}

		public void Dispose()
		{

		}

		public int SendInitData()
		{
			string playerName = Share.Singleton.PlayerData[0].Name;

			using (var ms = new MemoryStream())
			using (var bw = new BinaryWriter(ms))
			{
				var header = Network.Parser.Header.Default;
				header.Command = 0x00;
				bw.Write(header.GetByteArray());

				var startUpData = Network.Parser.StartUp.Default;
				startUpData.PlayerName = playerName;
				startUpData.ID = "01234567";

				bw.Write(startUpData.GetByteArray());

				client?.Send(ms.GetBuffer(), (int)ms.Length);
			}

			return 0;
		}

		public int Send(string content)
		{
			client?.SendComment(content);

			return 0;
		}

		~TatelierClientManager()
		{
		}
	}
}
