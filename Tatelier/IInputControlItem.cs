using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	interface IInputControlItem
	{
		bool Enabled { get; set; }
		bool GetKey(int key);
		bool GetKeyDown(int key);
		bool GetKeyUp(int key);
		int GetCount(int key);
	}
}
