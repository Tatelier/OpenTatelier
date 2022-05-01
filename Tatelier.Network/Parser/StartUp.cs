using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Network.Parser
{
	public struct StartUp
	{
		public static StartUp Default
		{
			get
			{
				var data = new StartUp();
				data.Init();

				return data;
			}
		}

		void Init()
		{
			ID = "00000000";
			PlayerName = "DEFAULT";
		}


		public const ushort SubCommand = 0x0001;

		public const ushort ProtocolVersion = 0x0001;

		/// <summary>
		/// ID (8byte固定)
		/// </summary>
		public string ID;

		/// <summary>
		/// プレイヤー名(動的サイズ)
		/// </summary>
		public string PlayerName;

		public int Parse(byte[] data, int startIndex)
		{
			int pos = startIndex;
			pos = Utility.Get(out ushort subCommand, data, pos);
			pos = Utility.Get(out ushort protocolVersion, data, pos);

			if(subCommand != SubCommand 
				|| protocolVersion != ProtocolVersion)
			{
				return -1;
			}

			pos = Utility.GetStaticText(out ID, 8, data, pos);
			pos = Utility.GetDynamicText0xFF(out PlayerName, data, pos);

			return 0;
		}

		public byte[] GetByteArray()
		{
			byte playerNameSize = (byte)Encoding.UTF8.GetByteCount(PlayerName);

			byte[] bytes = new byte[2 + 2 + 8 + 1 + playerNameSize];

			int pos = 0;

			pos = Utility.Set(SubCommand, bytes, pos);
			pos = Utility.Set(ProtocolVersion, bytes, pos);
			pos = Utility.SetStaticText(ref ID, 8, bytes, pos);
			pos = Utility.SetDynamicText0xFF(ref PlayerName, playerNameSize, bytes, pos);

			return bytes;
		}
	}
}
