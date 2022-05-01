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
	class TransitionFromResultToSongSelect
		: SceneBase
	{
		public static TransitionFromResultToSongSelect Create()
		{
			return new TransitionFromResultToSongSelect();
		}

		public override SceneType SceneType => throw new NotImplementedException();

		public override ResultType CommandSearchAndRun(string command, params string[] args)
		{
			return ResultType.Exit;
		}

		CoroutineControl coroutineControl;


		public IEnumerator GetStart()
		{

			yield break;
		}

		public TransitionFromResultToSongSelect()
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
				alpha = (int)((Supervision.NowMilliSec - start) * 255 / 500);
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
