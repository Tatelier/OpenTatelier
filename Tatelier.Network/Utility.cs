using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Network
{
	class Utility
	{
		const ushort b0x00FF = 0x00FF;
		const ushort b0xFF00 = 0xFF00;


		public static int Get(out ushort val, byte[] bytes, int startIndex)
		{
			val = BitConverter.ToUInt16(bytes, startIndex);

			return startIndex + 2;
		}

		public static int GetStaticText(out string text, byte length, byte[] bytes, int startIndex)
		{
			text = Encoding.UTF8.GetString(bytes, startIndex, length);

			return startIndex + length;
		}

		public static int GetDynamicText0xFF(out string text, byte[] bytes, int startIndex)
		{
			int size = bytes[startIndex];

			text = Encoding.UTF8.GetString(bytes, startIndex + 1, size);

			return startIndex + 1 + size;
		}

		public static int Set(ushort val, byte[] bytes, int startIndex)
		{
			bytes[startIndex] = (byte)(val & b0x00FF);
			bytes[startIndex + 1] = (byte)((val & b0xFF00) >> 8);

			return startIndex + 2;
		}

		public static int SetStaticText(ref string text, byte length, byte[] bytes, int startIndex)
		{
			Array.Copy(Encoding.UTF8.GetBytes(text), 0, bytes, startIndex, length);

			return startIndex + length;
		}

		public static int SetDynamicText0xFF(ref string text, byte length, byte[] bytes, int startIndex)
		{
			bytes[startIndex] = length;
			Array.Copy(Encoding.UTF8.GetBytes(text), 0, bytes, startIndex + 1, text.Length);

			return startIndex + 1 + length;
		}

		public static int ToByteArray(string content, out byte[] bytes)
		{
			bytes =  Encoding.UTF8.GetBytes(content);

			return 0;
		}
	}
}
