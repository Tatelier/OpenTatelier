using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier
{
	class InputControlItem : IInputControlItem
	{
		bool enabled;
		public bool Enabled
        {
            get
            {
				return enabled && InputControl.Singleton.Enabled;
            }
            set
            {
				enabled = value;
            }
        }
		public bool GetKey(int key) => Enabled ? Input.Singleton.GetKey(key) : false;
		public bool GetKeyUp(int key) => Enabled ? Input.Singleton.GetKeyUp(key) : false;
		public bool GetKeyDown(int key) => Enabled ? Input.Singleton.GetKeyDown(key) : false;

		public int GetCount(int key) => Enabled ? Input.Singleton.GetCount(key) : 0;
	}
}
