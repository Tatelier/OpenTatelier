using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Module.DiscordRPC
{
	public interface IRichPresence
	{
		string State { get; set; } /* max 128 bytes */
		string Details { get; set; } /* max 128 bytes */
		long StartTimestamp { get; set; }
		long EndTimestamp { get; set; }
		string LargeImageKey { get; set; } /* max 32 bytes */
		string LargeImageText { get; set; } /* max 128 bytes */
		string SmallImageKey { get; set; } /* max 32 bytes */
		string SmallImageText { get; set; } /* max 128 bytes */
		string PartyId { get; set; } /* max 128 bytes */
		int PartySize { get; set; }
		int PartyMax { get; set; }
		string MatchSecret { get; set; } /* max 128 bytes */
		string JoinSecret { get; set; } /* max 128 bytes */
		string SpectateSecret { get; set; } /* max 128 bytes */
		bool Instance { get; set; }
	}
}