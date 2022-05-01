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
	class TransitionToResult
		: SceneBase
	{
		public static TransitionToResult Create()
		{
			return new TransitionToResult();
		}

		public override SceneType SceneType => throw new NotImplementedException();

		public override ResultType CommandSearchAndRun(string command, params string[] args)
		{
			return ResultType.Exit;
		}

		CoroutineControl coroutineControl;


		public IEnumerator GetStart()
		{

			//if (cacheList.Count > 0)
			//{
			//	cacheList.ForEach(v => ImageLoadControl.Singleton.Delete(v));
			//}
			//string course = "";
			//if (names.Length == 1)
			//{
			//	course = names[0];
			//}
			//else if (names.Length > 1 && names.Any(v => v == names[0]))
			//{
			//	course = names[0];
			//}

			//switch (names[0])
			//{
			//	case "Easy":
			//		fileName = "Easy.png";
			//		break;
			//	case "Normal":
			//		fileName = "Normal.png";
			//		break;
			//	case "Hard":
			//		fileName = "Hard.png";
			//		break;
			//	case "Oni":
			//		fileName = "Oni.png";
			//		break;
			//	case "Ura":
			//	case "Edit":
			//		fileName = "Ura.png";
			//		break;
			//	default:
			//		fileName = "Other.png";
			//		break;
			//}
			//handle = ImageLoadControl.Singleton.Load(Path.Combine(MainConfig.Singleton.ThemeFolderPath, $"SongSelectToPlay/Transition/{fileName}"));

			yield break;
		}

		public TransitionToResult()
		{
			coroutineControl = new CoroutineControl();
		}

		public void Begin()
		{
			coroutineControl.StartCoroutine(GetStart());
			coroutineControl.StartCoroutine(GetFadeIn());
		}

		public void End()
		{
			coroutineControl.StartCoroutine(GetFadeOut());
		}

		IEnumerator GetFadeIn()
		{
			alpha = 0;
			yield return null;

			int start = Supervision.NowMilliSec;

			while (true)
			{
				alpha = (int)((Supervision.NowMilliSec - start) * 255 / 1000);
				if (alpha > 255)
				{
					alpha = 255;
					break;
				}
				yield return null;
			}
		}

		IEnumerator GetFadeOut()
		{
			alpha = 255;
			yield return null;

			int start = Supervision.NowMilliSec;

			while (true)
			{
				alpha = 255 - (int)((Supervision.NowMilliSec - start) * 255 / 500);
				if (alpha < 0)
				{
					alpha = 0;
					break;
				}
				yield return null;
			}
		}

		int alpha = 0;


		public override void Start()
		{

		}

		public override void Update()
		{
			coroutineControl.Update();
		}

		public override void Draw()
		{
			const int bodyBackgroundColor = 0x000000;

			using (DrawBlendModeGuard.Create())
			{
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, alpha);
				DrawBoxAA(0, 0, Supervision.ScreenWidth, Supervision.ScreenHeight, bodyBackgroundColor, DX_TRUE);
			}
		}

		public override void Finish()
		{
		}

	}
}
