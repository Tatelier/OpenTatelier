using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Interface.Command;

namespace Tatelier.Scene
{
	class AuthNG
		: SceneBase
	{
		public override SceneType SceneType => SceneType.AuthNG;
		public static SceneBase Create() => new AuthNG();

		public override ResultType CommandSearchAndRun(string command, params string[] args)
		{
			return 0;
		}

		string GetMessage(string errorCode)
		{
			return $"認証に失敗しました。\n\nエラーコード:{errorCode}";
		}

		public override void Start()
		{
			var connect = Share.Singleton.Connect;

			string errorCode = "";
			var now = DateTime.Now;

			if (connect.HasError)
			{
				errorCode = connect.ErrorCode;
			}

			Error.Add(Convert.ToUInt32(errorCode, 16));

			var info = new MyMessageBoxInfo()
			{
				MessageType = MessageType.Error,
				Text = GetMessage(errorCode),

				MyMessageBoxItems = new MyMessageBoxItemInfo[]
				{
					new MyMessageBoxItemInfo()
					{
						Name = "終了する",
						Callback = () =>
						{
							Supervision.Singleton.Exit();
						}
					}
					,
					new MyMessageBoxItemInfo()
					{
						Name = "エラー詳細ページを開く",
						Callback = () =>
						{
							Error.OpenDetailFirstPage();
						},
						DoDialogClose = false
					}
					,
				}
			};
			MyMessageBox.Singleton.Open(info);
		}

		public override void Update()
		{
		}

		public override void Draw()
		{
		}

		public override void Finish()
		{
		}
	}
}
