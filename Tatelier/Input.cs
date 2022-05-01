using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier
{
	/// <summary>
	/// キー入力クラス
	/// </summary>
	class Input : Interface.IInput
	{
		public static Input Singleton { get; private set; }

		byte[] bytes = new byte[256];
		readonly int[] cntBytes = new int[256];

		readonly Dictionary<string, int> nameKeyMap;

		Input()
		{
			nameKeyMap = new Dictionary<string, int>()
			{
				{ "1", KEY_INPUT_1 },
				{ "2", KEY_INPUT_2 },
				{ "3", KEY_INPUT_3 },
				{ "4", KEY_INPUT_4 },
				{ "5", KEY_INPUT_5 },
				{ "6", KEY_INPUT_6 },
				{ "7", KEY_INPUT_7 },
				{ "8", KEY_INPUT_8 },
				{ "9", KEY_INPUT_9 },
				{ "0", KEY_INPUT_0 },

				{ "A", KEY_INPUT_A },
				{ "B", KEY_INPUT_B },
				{ "C", KEY_INPUT_C },
				{ "D", KEY_INPUT_D },
				{ "E", KEY_INPUT_E },
				{ "F", KEY_INPUT_F },
				{ "G", KEY_INPUT_G },
				{ "H", KEY_INPUT_H },
				{ "I", KEY_INPUT_I },
				{ "J", KEY_INPUT_J },
				{ "K", KEY_INPUT_K },
				{ "L", KEY_INPUT_L },
				{ "M", KEY_INPUT_M },
				{ "N", KEY_INPUT_N },
				{ "O", KEY_INPUT_O },
				{ "P", KEY_INPUT_P },
				{ "Q", KEY_INPUT_Q },
				{ "R", KEY_INPUT_R },
				{ "S", KEY_INPUT_S },
				{ "T", KEY_INPUT_T },
				{ "U", KEY_INPUT_U },
				{ "V", KEY_INPUT_V },
				{ "W", KEY_INPUT_W },
				{ "X", KEY_INPUT_X },
				{ "Y", KEY_INPUT_Y },
				{ "Z", KEY_INPUT_Z },

				{ "NUMPAD1", KEY_INPUT_NUMPAD1 },
				{ "NUMPAD2", KEY_INPUT_NUMPAD2 },
				{ "NUMPAD3", KEY_INPUT_NUMPAD3 },
				{ "NUMPAD4", KEY_INPUT_NUMPAD4 },
				{ "NUMPAD5", KEY_INPUT_NUMPAD5 },
				{ "NUMPAD6", KEY_INPUT_NUMPAD6 },
				{ "NUMPAD7", KEY_INPUT_NUMPAD7 },
				{ "NUMPAD8", KEY_INPUT_NUMPAD8 },
				{ "NUMPAD9", KEY_INPUT_NUMPAD9 },
				{ "NUMPAD0", KEY_INPUT_NUMPAD0 },

				{ "-", KEY_INPUT_MINUS },
				{ "^", KEY_INPUT_PREVTRACK },
				{ "YEN", KEY_INPUT_YEN },
				{ "|", KEY_INPUT_YEN },
				{ "@", KEY_INPUT_AT },
				{ "[", KEY_INPUT_LBRACKET },
				{ "]", KEY_INPUT_RBRACKET },
				{ ";", KEY_INPUT_SEMICOLON },
				{ "+", KEY_INPUT_SEMICOLON },
				{ ":", KEY_INPUT_COLON },
				{ "*", KEY_INPUT_COLON },
				{ ">", KEY_INPUT_PERIOD },
				{ ".", KEY_INPUT_PERIOD },
				{ ",", KEY_INPUT_COMMA },
				{ "<", KEY_INPUT_COMMA },
				{ "/", KEY_INPUT_SLASH },
				{ "?", KEY_INPUT_SLASH },
				{ "_", KEY_INPUT_BACKSLASH },
				{ "\\", KEY_INPUT_BACKSLASH },
				{ "DOWN", KEY_INPUT_DOWN },
				{ "UP", KEY_INPUT_UP },
				{ "LEFT", KEY_INPUT_LEFT },
				{ "RIGHT", KEY_INPUT_RIGHT },
				{ "ENTER", KEY_INPUT_RETURN },
				{ "RETURN", KEY_INPUT_RETURN },
				{ "DELETE", KEY_INPUT_DELETE },
				{ "BACK", KEY_INPUT_BACK },
				{ "SPACE", KEY_INPUT_SPACE },
				{ "LSHIFT", KEY_INPUT_LSHIFT },
				{ "RSHIFT", KEY_INPUT_RSHIFT },
			};
		}

		static Input()
		{
			Singleton = new Input();
		}


		public int GetKeyCodeFromText(string text)
		{
			if (nameKeyMap.TryGetValue(text.ToUpper(), out var key))
			{
				return key;
			}
			else
			{
				return 0;
			}

		}

		/// <summary>
		/// キー押下中かどうか
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool GetKey(int key) => GetCount(key) > 0;

		/// <summary>
		/// キー押下中かどうか
		/// </summary>
		/// <param name="keys">キー配列</param>
		/// <returns></returns>
		public bool GetKey(int[] keys)
		{
			foreach (var key in keys)
			{
				if (GetKey(key)) return true;
			}

			return false;
		}

		/// <summary>
		/// キーから離れた直後かどうか
		/// </summary>
		/// <param name="key">キー</param>
		/// <returns></returns>
		public bool GetKeyUp(int key) => GetCount(key) == -1;

		/// <summary>
		/// キーから離れた直後かどうか
		/// </summary>
		/// <param name="keys">キー配列</param>
		/// <returns></returns>
		public bool GetKeyUp(int[] keys)
		{
			foreach (var key in keys)
			{
				if (GetKeyUp(key)) return true;
			}

			return false;
		}

		/// <summary>
		/// キー押下直後かどうか
		/// </summary>
		/// <param name="key">キー</param>
		/// <returns></returns>
		public bool GetKeyDown(int key) => GetCount(key) == 1;

		/// <summary>
		/// キー押下直後かどうか
		/// </summary>
		/// <param name="keys">キー配列</param>
		/// <returns></returns>
		public bool GetKeyDown(int[] keys)
		{
			foreach (var key in keys)
			{
				if (GetKeyDown(key)) return true;
			}

			return false;
		}

		/// <summary>
		/// キーの押下カウント数を取得する
		/// </summary>
		/// <param name="key">キー</param>
		/// <returns></returns>
		public int GetCount(int key) => cntBytes[key];

		/// <summary>
		/// 入力状態をリセットする
		/// </summary>
		/// <returns>0:正常</returns>
		public int Reset()
		{
			for (int i = 0; i < bytes.Length; i++)
			{
				bytes[i] = 0;
				cntBytes[i] = 0;
			}

			return 0;
		}

		/// <summary>
		/// 更新処理
		/// </summary>
		public void Update()
		{
			if (GetHitKeyStateAll(bytes) == 0)
			{
				for (int i = 0; i < bytes.Length; i++)
				{
					if (bytes[i] > 0)
					{
						cntBytes[i] = cntBytes[i] == -1 ? 1 : (cntBytes[i] + 1);
					}
					else
					{
						cntBytes[i] = cntBytes[i] > 0 ? -1 : 0;
					}
				}
			}
		}
	}
}
