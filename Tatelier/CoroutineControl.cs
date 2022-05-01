using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class CoroutineControl
	{
		public static CoroutineControl Singleton { get; }
		static CoroutineControl()
		{
			Singleton = new CoroutineControl();
		}

		public void Update()
		{

		}
	}
}
