
namespace Tatelier.Common
{
	public class CRC32
	{
		private const int TABLE_LENGTH = 256;
		private uint[] crcTable;

		public CRC32()
		{
			BuildCRC32Table();
		}

		private void BuildCRC32Table()
		{
			crcTable = new uint[256];
			for (uint i = 0; i < 256; i++)
			{
				var x = i;
				for (var j = 0; j < 8; j++)
				{
					x = (uint)((x & 1) == 0 ? x >> 1 : -306674912 ^ x >> 1);
				}
				crcTable[i] = x;
			}
		}

		public uint Calc(byte[] buf)
		{
			uint num = uint.MaxValue;
			for (var i = 0; i < buf.Length; i++)
			{
				num = crcTable[(num ^ buf[i]) & 255] ^ num >> 8;
			}

			return (uint)(num ^ -1);
		}
	}
}