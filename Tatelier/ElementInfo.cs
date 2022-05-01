using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class ElementInfo
	{
		public string folder;

		public IEnumerable<Hjson.JsonValue> jsonList;

		public Func<Hjson.JsonValue, bool> linqFunc;

		public Hjson.JsonValue json => jsonList.FirstOrDefault(linqFunc);

		public Hjson.JsonObject variableMap;
	}
}
