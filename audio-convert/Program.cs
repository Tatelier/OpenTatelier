using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Program
{
	static void Main(string[] args)
	{
		new Program().main(args);
	}

	bool a = false;

	byte[] buffer = new byte[16];
	TcpClient tcpClient = null;

	void Send()
	{
		tcpClient?.GetStream().Write(buffer, 0, buffer.Length);
	}

	void SendStart()
	{
		buffer[0] = 0;
		Send();
	}

	void SendFinish(int result)
	{
		buffer[0] = 2;
		Array.Copy(BitConverter.GetBytes(result), 0, buffer, 1, 4);
		Send();
	}

	void SendPer(int per)
	{
		buffer[0] = 1;
		Array.Copy(BitConverter.GetBytes(per), 0, buffer, 1, 4);
		Send();
	}

	void main(string[] args)
	{
		try
		{
			tcpClient = new TcpClient("127.0.0.1", int.Parse(args[4]));
		}
		catch(Exception e)
		{
			tcpClient = null;
		}

		var audio = new CSAudioConverter.AudioConverter();
		audio.ConvertDone += Audio_ConvertDone;
		audio.ConvertAborted += Audio_ConvertAborted;
		audio.ConvertError += Audio_ConvertError;
		audio.ConvertStart += Audio_ConvertStart;
		audio.ConvertProgress += Audio_ConvertProgress;

		string fpp = args[0];


		string dest = args[2];

		Directory.CreateDirectory(Path.GetDirectoryName(dest));

		audio.Open(fpp);

		var fp = audio.FileProperties;

		var from = new TimeSpan();
		var to = from + new TimeSpan(fp.Length.Hours, fp.Length.Minutes, fp.Length.Seconds);

		audio.OperationState = CSAudioConverter.OperationState.Running;
		audio.DecodeMode = CSAudioConverter.DecodeMode.LocalCodecs;

		audio.Format = CSAudioConverter.Format.OGG;

		audio.SourceFiles.Add(new Options.Core.SourceFile(Path.GetFullPath(fpp), from, to));

		audio.DestinatioFile = Path.GetFullPath(dest);

		audio.Convert();

		while (!a)
		{
			Task.Delay(100).Wait();
		}

		Environment.ExitCode = 0;
	}

	void Audio_ConvertProgress(object sender, CSAudioConverter.PercentArgs e)
	{
		SendPer(e.Number);
	}

	void Audio_ConvertStart(object sender, EventArgs e)
	{
		SendStart();
	}

	void Audio_ConvertError(object sender, CSAudioConverter.MessageArgs e)
	{
		SendFinish(e.Number);
		a = true;
	}

	private void Audio_ConvertAborted()
	{

	}

	private void Audio_ConvertDone(object sender, EventArgs e)
	{
		a = true;
		SendFinish(0);
	}
}
