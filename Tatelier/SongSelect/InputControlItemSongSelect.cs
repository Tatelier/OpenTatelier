using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;
using HjsonEx;

namespace Tatelier.SongSelect
{
	class InputControlItemSongSelect : IInputControlItem
	{
		public const int Prev = -1;
		public const int Next = -2;
		public const int OK = -3;
		public const int Cancel = -4;
		public const int Edit = -5;

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

		public bool OKCancelEnabled { get; set; } = true;

		Input input;

		int[] next;
		int[] prev;
		int[] ok;
		int[] cancel;
		int[] edit;

		public InputControlItemSongSelect(Hjson.JsonValue json, int playerNum)
		{
			input = Input.Singleton;
			var players = json.EQa("Players") ?? HjsonEx.Empty.Array;

			var player = players.FirstOrDefault(v => (v.EQi("Number") ?? 1) == playerNum) ?? HjsonEx.Empty.Value;

			var item = player.EQv("SelectItem") ?? HjsonEx.Empty.Value;

			// OK
			{
				var ok = item.EQa("OK") ?? HjsonEx.Empty.Array;

				this.ok = new int[ok.Count];

				for (int i = 0; i < ok.Count; i++)
				{
					this.ok[i] = input.GetKeyCodeFromText(ok[i]);
				}
			}

			// Prev
			{
				var prev = item.EQa("Prev") ?? HjsonEx.Empty.Array;

				this.prev = new int[prev.Count];

				for (int i = 0; i < prev.Count; i++)
				{
					this.prev[i] = input.GetKeyCodeFromText(prev[i]);
				}
			}

			// Next
			{
				var next = item.EQa("Next") ?? HjsonEx.Empty.Array;

				this.next = new int[next.Count];

				for (int i = 0; i < next.Count; i++)
				{
					this.next[i] = input.GetKeyCodeFromText(next[i]);
				}
			}

			// Cancel
			{
				var cancel = item.EQa("Cancel") ?? HjsonEx.Empty.Array;

				this.cancel = new int[cancel.Count];

				for (int i = 0; i < cancel.Count; i++)
				{
					this.cancel[i] = input.GetKeyCodeFromText(cancel[i]);
				}
			}

			// Edit
			{
				var edit = item.EQa("Edit") ?? HjsonEx.Empty.Array;

				this.edit = new int[edit.Count];

				for (int i = 0; i < edit.Count; i++)
				{
					this.edit[i] = input.GetKeyCodeFromText(edit[i]);
				}
			}
		}

		public InputControlItemSongSelect()
		{
			input = Input.Singleton;

			this.prev = new int[]
			{
				KEY_INPUT_D,
				KEY_INPUT_LEFT,
				KEY_INPUT_UP
			};
			this.next = new int[]
			{
				KEY_INPUT_K,
				KEY_INPUT_RIGHT,
				KEY_INPUT_DOWN
			};
			this.ok = new int[]
			{
				KEY_INPUT_F,
				KEY_INPUT_J,
				KEY_INPUT_SPACE,
				KEY_INPUT_RETURN,
			};
			this.cancel = new int[]
			{
				KEY_INPUT_Q,
				KEY_INPUT_ESCAPE,
			};
			this.edit = new int[]
			{
				KEY_INPUT_E
			};
		}

		public int GetCount(int key)
		{
			return GetCount(key);
		}

		public bool GetKey(int key)
		{
			if (!Enabled) return false;

			switch (key)
			{
				case Prev:
					return input.GetKey(prev);
				case Next:
					return input.GetKey(next);
				case OK:
					return OKCancelEnabled && input.GetKey(ok);
				case Cancel:
					return OKCancelEnabled && input.GetKey(cancel);
				case Edit:
					return input.GetKey(edit);
				default:
					return input.GetKey(key);
			}
		}

		public bool GetKeyDown(int key)
		{
			if (!Enabled) return false;

			switch (key)
			{
				case Prev:
					return input.GetKeyDown(prev);
				case Next:
					return input.GetKeyDown(next);
				case OK:
					return OKCancelEnabled && input.GetKeyDown(ok);
				case Cancel:
					return OKCancelEnabled && input.GetKeyDown(cancel);
				case Edit:
					return input.GetKeyDown(edit);
				default:
					return input.GetKeyDown(key);
			}
		}

		public bool GetKeyUp(int key)
		{
			if (!Enabled) return false;

			switch (key)
			{
				case Prev:
					return input.GetKeyUp(prev);
				case Next:
					return input.GetKeyUp(next);
				case OK:
					return OKCancelEnabled && input.GetKeyUp(ok);
				case Cancel:
					return OKCancelEnabled && input.GetKeyUp(cancel);
				case Edit:
					return input.GetKeyUp(edit);
				default:
					return input.GetKeyUp(key);
			}
		}
	}
}
