using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class LoadControlBase
	{
		protected static readonly HashAlgorithm hashProvider = new MD5CryptoServiceProvider();

		/// <summary>
		/// Returns the hash string for the file.
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		protected static bool TryComputeFileHash(string filePath, out string hash)
		{
			if (File.Exists(filePath))
			{
				using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					var bs = hashProvider.ComputeHash(fs);
					hash = BitConverter.ToString(bs).Replace("-", "");
				}
				return true;
			}
			else
			{
				hash = "";
				return false;
			}
		}
	}
}
