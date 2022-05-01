using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tatelier.DxLibDLL;
using Tatelier.Interface.Command;
using static DxLibDLL.DX;

namespace Tatelier
{
	/// <summary>
	/// コマンドクラス
	/// ※シングルトン
	/// </summary>
	class Command
	{
		const int StateNowInput = 0;
		const int StateInputFinish = 1;
		const int StateEscape = 2;

		const int historySize = 16;
		const int InputSize = 256;

		public static Command Singleton { get; private set; } = new Command();

		bool Active { get; set; } = false;

		int font = 0;
		int size = 36;
		int handle = 0;

		StringBuilder sb;

		LinkedList<string> list = new LinkedList<string>();

		LinkedListNode<string> nowNode = null;


		/// <summary>
		/// 初期化処理
		/// </summary>
		public void Start()
		{
			font = CreateFontToHandle(MainConfig.Singleton.DefaultFont, size, -1, DX_FONTTYPE_ANTIALIASING);
			sb = new StringBuilder();
		}

		/// <summary>
		/// 更新処理
		/// </summary>
		public void Update()
		{
			if (Active)
			{
				if (Input.Singleton.GetKeyDown(KEY_INPUT_ESCAPE))
				{
					Active = false;
					LogWindow.Singleton.NowInput = false;
					InputControl.Singleton.NowCommandInput = false;
					InputControl.Singleton.ChangePrevInput();
				}

                if (Input.Singleton.GetKeyDown(KEY_INPUT_UP))
                {
					if (nowNode == null)
					{
						if (list.First != null)
						{
							sb.Clear();
							GetKeyInputString(sb, handle);

							nowNode = list.First;
						}
					}
					else
					{
						if (nowNode.Next != null)
						{
							nowNode = nowNode.Next;
						}
					}

					if(nowNode != null)
					{
						SetKeyInputString($"{nowNode.Value}", handle);
					}
				}
				else if (Input.Singleton.GetKeyDown(KEY_INPUT_DOWN))
				{
					if (nowNode == null)
					{

					}
					else
					{
						if (nowNode.Previous != null)
						{
							nowNode = nowNode.Previous;
						}
                        else
                        {
							nowNode = null;
							SetKeyInputString($"{sb}", handle);
						}
					}


					if (nowNode != null)
					{
						SetKeyInputString($"{nowNode.Value}", handle);
					}
				}
			}
			else
			{
				if (Input.Singleton.GetKeyDown(KEY_INPUT_SLASH)
					|| Input.Singleton.GetKeyDown(KEY_INPUT_T))
				{
					if (!MyMessageBox.Singleton.IsOpen)
					{
						Active = true;
						handle = MakeKeyInput(InputSize, 1, 0, 0);
						SetActiveKeyInput(handle);
						if (Input.Singleton.GetKeyDown(KEY_INPUT_SLASH))
						{
							SetKeyInputString("/", handle);
						}
						SetKeyInputStringFont(font);
						InputControl.Singleton.ChangeInput();
						InputControl.Singleton.NowCommandInput = true;
						LogWindow.Singleton.NowInput = true;
					}

				}
			}
		}
		public void Draw()
		{
			if (Active)
			{
				switch (CheckKeyInput(handle))
				{
					case StateNowInput:
						using (DrawBlendModeGuard.Create())
						{
							SetDrawBlendMode(DX_BLENDMODE_ALPHA, 191);
							DrawBox(
								0
								, Supervision.ScreenHeight - 64
								, Supervision.ScreenWidth
								, Supervision.ScreenHeight
								, 0x000000
								, DX_TRUE
								);
						}
						DrawKeyInputString(12, Supervision.ScreenHeight - size - 12, handle);
						break;
					case StateInputFinish:
						InputControl.Singleton.ChangePrevInput();
						InputControl.Singleton.NowCommandInput = false;

						GetKeyInputString(sb, handle);

						if (sb.Length > 0)
						{
							if (sb[0] == '/')
							{
								string command = $"{sb}";
								string[] commandSplit = command.Split(' ');
								if (commandSplit.Length > 0)
								{
									var result = Supervision.CommandSearchAndRun(commandSplit[0], commandSplit.Skip(1).ToArray());
                                    if (result != ResultType.NotFound)
                                    {
										list.AddFirst(command);
										if(list.Count > historySize)
                                        {
											list.RemoveLast();
                                        }
										nowNode = null;
                                    }
								}

							}
							else
							{
								LogWindow.Singleton.Insert($"{MainConfig.Singleton.PlayerInfoList[0].Name}: {sb}");
								TatelierClientManager.Singleton.Send($"{sb}");
							}
						}
						DeleteKeyInput(handle);
						sb.Clear();
						Active = false;
						LogWindow.Singleton.NowInput = false;
						//Key.SetKeyAcqu(true);
						break;
					case StateEscape:
						InputControl.Singleton.ChangePrevInput();
						InputControl.Singleton.NowCommandInput = false;
						DeleteKeyInput(handle);
						sb.Clear();
						Active = false;
						LogWindow.Singleton.NowInput = false;
						//Key.SetKeyAcqu(true);
						break;
					default:
						break;
				}
			}
		}

		public void Reset()
		{
			DeleteFontToHandle(font);
			Singleton = new Command();
		}
	}
}
