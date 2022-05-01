using HjsonEx;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tatelier.Interface.Command;

namespace Tatelier
{
    class TatelierRemoteManager
    {
        public static TatelierRemoteManager Singleton { get; private set; } = new TatelierRemoteManager();

        Task task;

        HttpListener listener = null;

        Dictionary<string, Func<HttpListenerContext, int>> dic;

        string RootFolder = @".\\RemoteServer";

        public void Start(int port)
        {
			if (listener?.IsListening ?? false)
			{
                Stop();
			}
            task = Task.Run(() => Run(port));
        }

        public void Stop()
        {
            if (listener?.IsListening ?? false)
            {
                listener.Stop();
                task.Wait();
                listener.Close();
                LogWindow.Singleton.Insert("リモートサーバを停止しました。");
            }
			else
            {
                LogWindow.Singleton.Insert("リモートサーバは起動しておりません。", LogWindow.WarningColor);
            }
        }

        public bool TryStartListen(string ip, int port)
        {
            string uri = $"http://{ip}:{port}/";
            string prefix = uri; // 受け付けるURL

            listener = new HttpListener();
            listener.Prefixes.Add(prefix); // プレフィックスの登録

            try
            {
                listener.Start();
            }
            catch
            {
                return false;
            }
            return true;
        }

        int PathInit(HttpListenerContext context)
        {
            var req = context.Request;
            var res = context.Response;

            var hjson = new Hjson.JsonObject();
            var scoreList = new Hjson.JsonArray();

            int index = 0;
            foreach (var score in Share.Singleton.SongSelectItemControl.GetAllMusicalScoreSelectItem())
            {
                scoreList.Add(new Hjson.JsonObject()
                {
                    { "name", score.Title },
                    { "index", index },
                });
                index++;
            }

            var genreList = new Hjson.JsonArray
            {
                new Hjson.JsonObject()
                {
                    { "name", "すべて" },
                    { "scoreList", scoreList }
                }
            };

            hjson["status"] = 0;
            hjson["genreList"] = genreList;

            hjson.Save(res.OutputStream, Hjson.Stringify.Plain);
            return 0;
        }

        int PathCommand(HttpListenerContext context)
        {
            var req = context.Request;
            var res = context.Response;
            var query = HttpUtility.ParseQueryString(req.Url.Query, Encoding.UTF8);

            bool result = Supervision.CommandSearchAndRun($"/{query["command"]}", query["args"].Split(' ')) == ResultType.Exit;
            var hjson = new Hjson.JsonObject()
            {
                { "status", result ? 1 : 0 }
            };

            hjson.Save(res.OutputStream, Hjson.Stringify.Plain);

            return 0;
        }

        int PathScoreSelect(HttpListenerContext context)
        {
            var request = context.Request;
            string text;
            using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                text = reader.ReadToEnd();
            }

            var json = Hjson.HjsonValue.Parse(text);
            Supervision.CommandSearchAndRun("/score-select", $"{json.EQi("index") ?? -1}");

            return 0;
        }

        int PathSearch(HttpListenerContext context)
        {
            var req = context.Request;
            var query = HttpUtility.ParseQueryString(req.Url.Query, Encoding.UTF8);

            Supervision.CommandSearchAndRun("/search", query["name"]);

            return 0;
        }

        int PathPlayerOperation(HttpListenerContext context)
        {
            var req = context.Request;
            var query = HttpUtility.ParseQueryString(req.Url.Query, Encoding.UTF8);

            Supervision.CommandSearchAndRun("player-operation", query["ope"]);

            return 0;
        }

        int Path0(HttpListenerContext context)
        {
            var req = context.Request;
            var res = context.Response;

            string absolutePath = "/index.html";

            // リクエストされたURLからファイルのパスを求める
            string path = RootFolder + absolutePath;

            byte[] content;

            // ファイルが存在すればレスポンス・ストリームに書き出す
            if (File.Exists(path))
            {
                content = File.ReadAllBytes(path);
                res.OutputStream.Write(content, 0, content.Length);
            }

            return 0;
        }

        public void Run(int port)
        {
            string ip = "+";
            if(!TryStartListen(ip, port))
            {
                ip = "127.0.0.1";
                if (!TryStartListen(ip, port))
                {
                    LogWindow.Singleton.Insert($"リモートサーバを起動できませんでした。", LogWindow.ErrorColor);
                    LogWindow.Singleton.Insert($"既にポートが使われいる可能性があります。", LogWindow.ErrorColor);
                    return;
                }
            }
            else
            {
                string hostName = Dns.GetHostName();    // 自身のホスト名を取得
                var addresses = Dns.GetHostAddresses(hostName);

                foreach (var address in addresses)
                {
                    if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ip = address.ToString();
                        break;
                    }
                }
            }

            LogWindow.Singleton.Insert($"リモートサーバを起動しました。", LogWindow.UpdateNoticeColor);
            LogWindow.Singleton.Insert($"IP: {ip}:{port}", LogWindow.UpdateNoticeColor);

            try
            {
                while (true)
                {
                    var context = listener.GetContext();
                    var req = context.Request;
                    var res = context.Response;

                    string absolutePath = req.Url.AbsolutePath;

                    if(dic.TryGetValue(absolutePath, out var func))
                    {
                        func(context);
                    }
                    else
                    {                        
                        // リクエストされたURLからファイルのパスを求める
                        string path = RootFolder + absolutePath;
                        string fullPath = Path.GetFullPath(path);

                        string dir = Path.GetDirectoryName(fullPath);

                        if (dir.Contains(Environment.CurrentDirectory))
                        {
                            byte[] content;
                            // ファイルが存在すればレスポンス・ストリームに書き出す
                            if (File.Exists(path))
                            {
                                content = File.ReadAllBytes(path);
                                if (Path.GetExtension(path.ToLower()) == ".svg")
                                {
                                    res.ContentType = "image/svg+xml";
                                }
                                res.OutputStream.Write(content, 0, content.Length);
                            }
                        }
                    }

                    res.Close();
                }
            }
            catch
            {
            }
        }

        TatelierRemoteManager()
        {
            dic = new Dictionary<string, Func<HttpListenerContext, int>>()
            {
                { "/init", PathInit },
                { "/command", PathCommand },
                { "/search", PathSearch },
                { "/score-select", PathScoreSelect },
                { "/", Path0 },
            };
        }
    }
}
