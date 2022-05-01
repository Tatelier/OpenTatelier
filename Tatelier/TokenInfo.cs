using HjsonEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class TokenInfo
	{
		public const int Normal = 0;
		public const int Debugger = 64;
		public const int Admin = -408;

		int role = 0;

		Hjson.JsonValue json;

		public int Role => role;

		bool playable = false;

		public bool Playable => playable;

		public string RoleName => json?.EQs("RoleName") ?? "通常権限";

		public string RoleNameEN => json?.EQs("RoleNameEN") ?? "";

		public int ScoreSaveDataDecrypt => json?.EQi("ScoreSaveDataDecrypt") ?? 0;

		public string EncryptKey => json?.EQs("Encrypt.Key") ?? "Undefined";

		public string EncryptIV => json?.EQs("Encrypt.IV") ?? "Undefined";

		public TokenInfo(Hjson.JsonValue json)
		{
			this.json = json;
			role = json?.EQi("Role") ?? 0;
			playable = (json?.EQi("Playable") ?? 0) == 1;
		}
	}
}
