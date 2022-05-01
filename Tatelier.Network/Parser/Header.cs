using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Network.Parser
{
	public struct Header
	{
		public byte Command;

		public static Header Default 
		{
			get
			{
				var header = new Header();
				header.Init();

				return header;
			}
		}

		void Init()
		{
			Command = 0x00;
		}

		public int Parse(byte[] bytes)
        {
            if (bytes.Length != 1)
            {
				return -1;
            }
			Command = bytes[0];

			return 0;
        }

		public byte[] GetByteArray()
		{
			byte[] bytes = new byte[1];

			bytes[0] = Command;

			return bytes;
		}
	}
}
