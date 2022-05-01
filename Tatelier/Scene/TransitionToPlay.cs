using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Coroutine;
using Tatelier.DxLibDLL;
using static DxLibDLL.DX;
using Tatelier.Interface.Command;

namespace Tatelier.Scene
{
	class TransitionToPlay
		: SceneBase
	{
		public static TransitionToPlay Create()
		{
			return new TransitionToPlay();
		}

		public override SceneType SceneType => throw new NotImplementedException();

		public override ResultType CommandSearchAndRun(string command, params string[] args)
		{
			return ResultType.Exit;
		}

		CoroutineControl coroutineControl;

		int handle;

		float x = 0;

		string fileName;

		public IEnumerator GetStart(string[] names)
		{

			if (cacheList.Count > 0)
			{
				cacheList.ForEach(v => ImageLoadControl.Singleton.Delete(v));
			}
			string course = "";
			if (names.Length == 1)
			{
				course = names[0];
			}
			else if (names.Length > 1 && names.Any(v => v == names[0]))
			{
				course = names[0];
			}

			switch (names[0])
			{
				case "Easy":
					fileName = "Easy.png";
					break;
				case "Normal":
					fileName = "Normal.png";
					break;
				case "Hard":
					fileName = "Hard.png";
					break;
				case "Oni":
					fileName = "Oni.png";
					break;
				case "Ura":
				case "Edit":
					fileName = "Ura.png";
					break;
				default:
					fileName = "Other.png";
					break;
			}
			handle = ImageLoadControl.Singleton.Load(Path.Combine(MainConfig.Singleton.ThemeFolderPath, $"SongSelectToPlay/Transition/{fileName}"));

			yield break;
		}

		public TransitionToPlay()
		{
			coroutineControl = new CoroutineControl();
		}

		public void Begin(string[] names)
		{
			coroutineControl.StartCoroutine(GetStart(names));
			coroutineControl.StartCoroutine(GetFadeIn());
		}

		public void End()
		{
			coroutineControl.StartCoroutine(GetFadeOut());
		}

		IEnumerator GetFadeIn()
		{
			x = 0;
			yield return null;

			int startTime = Supervision.NowMilliSec;
			while (true) 
			{
				x = (float)((Supervision.NowMilliSec - startTime) * 960 / 500.0F);
				if (x >= 960)
				{
					x = 960;
					break;
				}
				yield return null;
			}
			yield break;
		}

		IEnumerator GetFadeOut()
		{
			x = 960;
			yield return null;

			int startTime = Supervision.NowMilliSec;
			while (true)
			{
				x = 960 - (float)((Supervision.NowMilliSec - startTime) * 960 / 500.0F);

				if (x <= 0)
				{
					x = 0;
					break;
				}
				yield return null;
			}
			yield break;
		}

		static List<int> cacheList = new List<int>();

		public override void Start()
		{

		}

		public override void Update()
		{
			coroutineControl.Update();
		}

		public override void Draw()
		{
			using (DrawModeGuard.Create())
			{
				SetDrawMode(DX_DRAWMODE_NEAREST);
				SetDrawArea(0, 0, (int)x, Supervision.ScreenHeight);
				DrawRotaGraph2F(-960 + x, 0, 0, 0, 40, 0.0, handle, DX_TRUE);
				//DrawBoxAA(-960 + x, 0, x, 1080, 0x111144, TRUE);

				SetDrawArea(Supervision.ScreenWidth - (int)x, 0, Supervision.ScreenWidth + Supervision.ScreenWidthHalf - (int)x, Supervision.ScreenHeight);
				DrawRotaGraph2F(Supervision.ScreenWidthHalf - x, 0, 0, 0, 40, 0.0, handle, DX_TRUE);
				//DrawBoxAA(1920 - x, 0, 1920 + 960 - x, 1080, 0x111144, TRUE);

				SetDrawAreaFull();
			}
		}

		public override void Finish()
		{
		}

	}
}
