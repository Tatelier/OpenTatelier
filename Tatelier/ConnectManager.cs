using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class ConnectScoreEditInfo
	{
		public string TJAFilePath = "";
	}

	class ConnectManager
	{
		public static ConnectManager Singleton = new ConnectManager();

		FileSystemWatcher watcher = new FileSystemWatcher();

		ConnectScoreEditInfo Info = new ConnectScoreEditInfo();

		//イベントハンドラ
		private void watcher_Changed(System.Object source,
			System.IO.FileSystemEventArgs e)
		{
			if (e.FullPath.EndsWith(Info.TJAFilePath))
			{
				switch (e.ChangeType)
				{
					case System.IO.WatcherChangeTypes.Changed:
						Supervision.CommandSearchAndRun("\nScoreRefresh");
						LogWindow.Singleton.Insert("譜面を更新しました。");
						break;
				}
			}
		}

		public async void ConnectScoreEditor(ConnectScoreEditInfo info)
		{
			var client = new TcpClient();

			if (info.TJAFilePath != string.Empty)
			{
				watcher = new FileSystemWatcher
				{
					Path = Path.GetDirectoryName(info.TJAFilePath),
					NotifyFilter =
					(System.IO.NotifyFilters.LastAccess
					| System.IO.NotifyFilters.FileName
					| System.IO.NotifyFilters.DirectoryName),
					Filter = "",
				};

				//イベントハンドラの追加
				watcher.Changed += new System.IO.FileSystemEventHandler(watcher_Changed);
				watcher.Created += new System.IO.FileSystemEventHandler(watcher_Changed);
				watcher.Deleted += new System.IO.FileSystemEventHandler(watcher_Changed);

				//監視を開始する
				watcher.EnableRaisingEvents = true;

				Info = info;
			}

			try
			{
				await client.ConnectAsync("127.0.0.1", 62010);

				var stream = client.GetStream();

				await stream.WriteAsync(new byte[1], 0, 1);

				LogWindow.Singleton.Insert("[] 連携完了");

				byte[] header = new byte[16];

				while (true)
				{
					if (stream.DataAvailable)
					{
						int size = stream.Read(header, 0, header.Length);
						if (size > 0)
						{
							LogWindow.Singleton.Insert($"[受信]:0x{BitConverter.ToInt32(header, 0):X8}, ContentSize:{BitConverter.ToInt32(header, 12)}");

							// 受信処理後すぐは待機しない
							continue;
						}
					}

					await Task.Delay(50);
				}
			}
			catch
			{
				LogWindow.Singleton.Insert("[] 連携できませんでした。");
			}
		}

		public void CreateServer()
		{
			//TcpListenerオブジェクトを作成する
			System.Net.Sockets.TcpListener listener =
				new System.Net.Sockets.TcpListener(IPAddress.Parse("127.0.0.1"), 62010);
			listener.Start();

			LogWindow.Singleton.Insert($"サーバを立てました。{"127.0.0.1:62010"}");

			TcpClient client = new TcpClient("127.0.0.1", 62010);
			var stream = client.GetStream();

			var bytes = Share.Singleton.SJIS.GetBytes("あいうえお");

			stream.Write(bytes, 0, bytes.Length);
			LogWindow.Singleton.Insert($"Pansystar: こんばんは～");

			var accept = listener.AcceptTcpClient();
			var svr = accept.GetStream();
			byte[] acBytes = new byte[128];
			svr.ReadTimeout = 1;
			int a = svr.Read(acBytes, 0, acBytes.Length);
			string B = Share.Singleton.SJIS.GetString(acBytes);
			LogWindow.Singleton.Insert($"SERVER: {B}");
		}

		public void Update()
		{

		}
	}
}
