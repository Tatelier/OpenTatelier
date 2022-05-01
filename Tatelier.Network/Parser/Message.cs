using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Network.Parser
{
	public struct Message
	{
		public string Msg;
		
		public int Parse(byte[] bytes, int startIndex)
        {
			int size = BitConverter.ToUInt16(bytes, startIndex);
			Msg = Encoding.UTF8.GetString(bytes, startIndex + 2, size);


			return 0;
        }

		public byte[] GetByteArray()
        {
			// 文字列をバイト配列にした際の配列
			byte[] msgBytes = Encoding.UTF8.GetBytes(Msg);

			// return配列
			byte[] bytes = new byte[4 + msgBytes.Length];

			// サブコマンドは未使用
			bytes[0] = bytes[1] = 0;

			// 文字列の長さ
			bytes[2] = (byte)(msgBytes.Length & 0x00FF);
			bytes[3] = (byte)((msgBytes.Length & 0xFF00) >> 8);

			// 文字列
			Array.Copy(msgBytes, 0, bytes, 2, bytes.Length);

			return bytes;
        }
	}
}
