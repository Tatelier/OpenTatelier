using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Module.DiscordRPC
{
    public interface ITatelierDiscordRPC
    {
        IRichPresence Presence { get; }

        int Initialize(string clientId);

        int UpdatePresence();

        int Shotdown();
    }
}
