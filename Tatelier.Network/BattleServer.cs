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
    public class BattleServerItem
    {
        bool quit = false;

        TcpClient client;

        Task task;

        BattleServer server;

        public string Name;

        public string ID;

        //      public async void Send()
        //      {
        //          byte[] buffer = new byte[0];
        //          await client.GetStream().WriteAsync(buffer, 0, 0);
        //}

        public async void SendComment(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        public async void Send(MemoryStream ms)
        {
            await client.GetStream().WriteAsync(ms.GetBuffer(), 0, (int)ms.Length);
        }
        
        async void Run()
        {
            Thread thread = Thread.CurrentThread;
            thread.Name = "Server";

            try
            {
                byte[] buffer = new byte[1024];
                var ms = new MemoryStream();

                var stream = client.GetStream();

                while (!quit)
                {
                    if (client.Client.Poll(1000, SelectMode.SelectRead))
                    {
                        if (client.Client.Available <= 0)
                        {
                            break;
                        }
                    }

                    do
                    {
                        int size = await stream.ReadAsync(buffer, 0, buffer.Length);
                        ms.Write(buffer, 0, size);
                    } while (stream.DataAvailable);

                    ms.Seek(0, SeekOrigin.Begin);

                    if (ms.Length > 0)
                    {
                        if (server.OnRecv != null)
                        {
                            server.OnRecv?.Invoke(this, ms);
                        }
                        else
                        {
                            server.OnRecv?.Invoke(this, ms);
                        }
                    }

                    ms.Seek(0, SeekOrigin.Begin);
                    ms.SetLength(0);
                }
            }
            catch(Exception e)
			{
                server.OnError?.Invoke(0);
			}
			finally
            {
                server.OnClose?.Invoke(this);
                server.ItemList.Remove(this);
			}
		}

        public void Start()
		{
            task = Task.Run(Run);
		}

        public void Close()
		{
            quit = true;
		}

        public BattleServerItem(TcpClient client, BattleServer server)
		{
            this.server = server;
            this.client = client;
		}
	}
    public class BattleServer
    {
        bool quit = false;
        Task task;

        int port;

        public Action<Network.BattleServerItem, MemoryStream> OnRecv;
        public Action<Network.BattleServerItem, MemoryStream, Network.Parser.StartUp> OnRecvStartUp;

        public Action<int> OnError;

        public Action<Network.BattleServerItem> OnClose;
        public Action OnListenStart;
        public Action OnAccept;


        public LinkedList<BattleServerItem> ItemList = new LinkedList<BattleServerItem>();

        async void Run()
		{
            try
            {
                var listener = TcpListener.Create(port);
                listener.Start();
                OnListenStart?.Invoke();

                while (!quit)
                {
                    var client = await listener.AcceptTcpClientAsync();

                    OnAccept?.Invoke();
                    var item = new BattleServerItem(client, this);
                    item.Start();
                    ItemList.AddLast(item);
                }
            }
            catch(Exception e)
			{
                OnError?.Invoke(0);
			}
		}

        public void Start()
		{
            task.Start();
		}

        public BattleServer(int port)
		{
            this.port = port;
            task = new Task(Run);
		}
    }
}
