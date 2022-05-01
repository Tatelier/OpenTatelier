using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	static class MusicalScoreSaveDataManaged
	{
		public static AesManaged Create()
		{
			var aes = new AesManaged
			{
				IV = Encoding.UTF8.GetBytes(Share.Singleton.TokenInfo.EncryptIV),
				Key = Encoding.UTF8.GetBytes(Share.Singleton.TokenInfo.EncryptKey)
			};

			return aes;
		}
	}
}
