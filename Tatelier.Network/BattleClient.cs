using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tatelier.Network
{
	class ClientBase
	{

	}

	public class BattleClient
	{
		bool quit = false;
		Task task;

		public string Url => url;

		string url;
		int port;

		int status = 0;

		TcpClient client;

		public Action<MemoryStream> OnRecv;

		public Action OnOpen;

		public Action<int> OnError;

		public Action<int> OnClose;

		public async void Send(byte[] data, int dataLength)
		{
			await client.GetStream().WriteAsync(data, 0, dataLength);
		}

		public async void SendComment(string content)
		{
			// TODO: プロトコルに倣っていないためコメントアウト
			//byte[] buffer = Encoding.UTF8.GetBytes(content);
			//await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
		}

		async void Run()
		{
			Thread thread = Thread.CurrentThread;
			thread.Name = "Client";
			try
			{
				string[] split = url.Split(':');
				client = new TcpClient(split[0], int.Parse(split[1]));
				OnOpen?.Invoke();

				
				byte[] buffer = new byte[1024];
				var ms = new MemoryStream();

				var stream = client.GetStream();

				if (client.Client.Poll(1000, SelectMode.SelectRead))
				{
					quit = true;
				}

				while (!quit)
				{
					if (client.Client.Poll(1000, SelectMode.SelectRead))
					{
						if (client.Client.Available <= 0)
						{
							quit = true;
							break;
						}
					}

					do
					{
						int size = await stream.ReadAsync(buffer, 0, buffer.Length);
						ms.Write(buffer, 0, size);
					} while (stream.DataAvailable);

					ms.Seek(0, SeekOrigin.Begin);
					OnRecv?.Invoke(ms);
				}
			}
			catch (Exception e)
			{
				OnError?.Invoke(0);
			}

			try
			{
				quit = true;
				client.Client.Shutdown(SocketShutdown.Both);
				client.GetStream().Close();
			}
			catch
			{

			}
			finally
			{
				OnClose?.Invoke(status);
			}
		}

		public void Start()
		{
			task = Task.Run(Run);
		}

		public void Finish()
        {
			status = 1;
			quit = true;
		}

		public BattleClient(string url)
		{
			var split = url.Split(':');

			if(split.Length == 2
				&& string.IsNullOrEmpty(split[0]))
            {
				split[0] = "127.0.0.1";
				url = string.Join(":", split);
            }

			this.url = url;
		}

		~BattleClient()
		{
		}
	}
}
