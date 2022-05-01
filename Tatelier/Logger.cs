using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class Logger
	{
		public static Logger Singleton = new Logger();


		[Conditional("DEBUG")]
		public void Trace(string text, [CallerMemberName] string memberName = "")
		{
			System.Diagnostics.Trace.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {memberName}() {text}");
		}
	}
}
