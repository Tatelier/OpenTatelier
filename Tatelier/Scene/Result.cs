using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.DxLibDLL;
using Tatelier.Play;
using Tatelier.Interface.Command;
using static DxLibDLL.DX;

namespace Tatelier.Scene
{
	class Result : SceneBase
	{
		public override SceneType SceneType => SceneType.Result;
		InputControlItem input;

		Coroutine.CoroutineControl coroutineControl;

		public SongSelect SongSelect;

		SoulGauge soulGauge;

		Tatelier.Result.Background background;


		Tatelier.Result.Player[] players;

		int title;

		public override ResultType CommandSearchAndRun(string command, params string[] args)
		{
			return 0;
		}

		public override void Draw()
		{
			background.Draw();
			DrawGraph(0, 40, title, DX_TRUE);

			for (int i = 0; i < players.Length; i++)
			{
				players[i].ScoreBoard.Draw(47 + 936 * i, 280);
			}

			//soulGauge.Draw();
		}

		public override void Finish()
		{

		}

		IEnumerator GetTransitionToSongSelect()
		{
			TransitionShare.Singleton.TransitionFromResultToSongSelect.Begin();
			yield return new Coroutine.Wait(625);

			SceneControl.Singleton.Destroy(this);
			SongSelect.Regist(1.0F);

			EnterTo(SongSelect);
		}

		public override void Start()
		{
			coroutineControl = new Coroutine.CoroutineControl();
			TransitionShare.Singleton.TransitionToResult.End();

			players = new Tatelier.Result.Player[Share.Singleton.Result.Length];

			for (int i = 0; i < players.Length; i++)
			{
				players[i] = new Tatelier.Result.Player();

				var player = players[i];
				player.ResultData = Share.Singleton.Result[i];
				player.ScoreBoard = new Tatelier.Result.ScoreBoard(
				Path.Combine(MainConfig.Singleton.ThemeFolderPath, "Result"), null);
			}

			input = new InputControlItem();
			InputControl.Singleton.Regist("Result", input);
			InputControl.Singleton.ChangeInput("Result");

			//titleHandle = Utility.GetImageHandleFromText(resultData.Title, 0xFFFFFF, MainConfig.Singleton.DefaultFont, 1920, 240, 48, 6, 0x000000);

			soulGauge = new SoulGauge(System.IO.Path.Combine(MainConfig.Singleton.ThemeFolderPath, "Result"), "SoulGaugeP1.png", 0, 200);

			background = new Tatelier.Result.Background(
				Path.Combine(MainConfig.Singleton.ThemeFolderPath, "Result"), null);

			title = Utility.GetImageHandleFromText(Share.Singleton.SelectInfo.TJASelectItem.Title, 0xFFFFFF, MainConfig.Singleton.DefaultFont, 1920, 120, 70, 0, 0x000000);

			for (int i = 0; i < players.Length; i++)
			{
				players[i].ScoreBoard.SetValue(players[i].ResultData);
			}

			foreach (var player in players)
			{
				player.ScoreBoard.StartAnimation();
			}

			startCount = Supervision.NowMilliSec;
		}

		int startCount = 0;

		internal static SceneBase Create()
		{
			return new Result();
		}

		public override void Update()
		{
			coroutineControl.Update();
			foreach (var player in players)
			{
				player.ScoreBoard.Update();
			}
			background.Update();

			if (startCount + 2500 < Supervision.NowMilliSec)
			{
				if (input.GetKeyDown(KEY_INPUT_F) || input.GetKeyDown(KEY_INPUT_J) || input.GetKeyDown(KEY_INPUT_SPACE))
				{
					var info = new MyMessageBoxInfo()
					{
						MessageType = MessageType.Info,
						Text = $"選んでください",
						MyMessageBoxItems = new MyMessageBoxItemInfo[]
						{
						new MyMessageBoxItemInfo()
						{
							Name = "選曲画面に戻る",
							Callback = () =>
							{
								coroutineControl.StartCoroutine(GetTransitionToSongSelect());
							}
						},
						new MyMessageBoxItemInfo()
						{
							Name = "もう1回遊ぶ",
							Callback = () =>
							{
								SceneControl.Singleton.Destroy(this);
								SceneControl.Singleton.Create("Retry Play", out Play p);
								p.SongSelect = SongSelect;
							}
						},
						}
					};
					MyMessageBox.Singleton.Open(info);
				}
			}
		}

		public Result() : base() { }

		public Result(string name) : base(name) { }
	}
}
