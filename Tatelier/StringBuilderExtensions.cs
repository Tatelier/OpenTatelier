using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	static class StringBuilderExtensions
	{
		public static IEnumerable<StringBuilder> EnumerateSplit(this StringBuilder sb)
		{
			StringBuilder result = new StringBuilder(64);

			for (int i = 0; i < sb.Length; i++)
			{
				if (sb[i] == '\n')
				{
					yield return result;
					result.Clear();
				}
				else
				{
					result.Append(sb[i]);
				}
			}

			yield return result;
		}
	}
}
