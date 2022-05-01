using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Common;
using DxLibDLL;

namespace Tatelier
{
	static class TransformExtensions
	{
		public static IEnumerator AnimatePoint(
			this IReadOnlyList<Common.Transform> transformList,
			IReadOnlyList<Common.Vector2> pointList,
			int duringTime,
			int startWaitTime,
			int finishWaitTime,
			EasingType easingType,
			Action callback)
		{
			var startPointList = transformList.Select(v => new Vector2(v.X, v.Y)).ToArray();

			int start;
			int end;

			// 開始待機
			start = Supervision.NowMilliSec;
			end = start + startWaitTime;
			while (Supervision.NowMilliSec < end) yield return 10;

			// 処理実施
			start = Supervision.NowMilliSec;
			end = start + duringTime;
			while (Supervision.NowMilliSec < end)
			{
				var per = (Supervision.NowMilliSec - start) / (float)duringTime;

				for (int i = 0; i < startPointList?.Length; i++)
				{
					transformList[i].SetPoint(startPointList[i] + (pointList[i] - startPointList[i]) * Common.Easing.GetEasingValue(per, easingType));
				}

				yield return 1;
			}

			for (int i = 0; i < startPointList?.Length; i++)
			{
				transformList[i].SetPoint(pointList[i]);
			}

			// 終了待機
			start = Supervision.NowMilliSec;
			end = start + finishWaitTime;

			while (Supervision.NowMilliSec < end) yield return 20;

			callback?.Invoke();

			yield return null;
		}

		public static IEnumerator AnimatePoint(
			this Common.Transform transform,
			Common.Vector2 to,
			int duringTime,
			int startWaitTime,
			int finishWaitTime,
			EasingType easingType,
			Action callback)
		{
			var startPoint = new Vector2(transform.X, transform.Y);

			int start;
			int end;

			// 開始待機
			start = Supervision.NowMilliSec;
			end = start + startWaitTime;
			while (Supervision.NowMilliSec < end) yield return 10;

			// 処理実施
			start = Supervision.NowMilliSec;
			end = start + duringTime;
			while (Supervision.NowMilliSec < end)
			{
				var per = (Supervision.NowMilliSec - start) / (float)duringTime;

				transform.SetPoint(startPoint + (to - startPoint) * Common.Easing.GetEasingValue(per, easingType));

				yield return 1;
			}
			transform.SetPoint(to);

			// 終了待機
			start = Supervision.NowMilliSec;
			end = start + finishWaitTime;

			while (Supervision.NowMilliSec < end) yield return 20;

			callback?.Invoke();

			yield return null;
		}

		public static IEnumerator AnimateScale(
			this Common.Transform transform,
			Common.Vector2 to,
			int duringTime,
			int startWaitTime,
			int finishWaitTime,
			EasingType easingType,
			Action callback
			)
		{
			var startSize = transform.Scale;

			int start;
			int end;

			// 開始待機
			start = Supervision.NowMilliSec;
			end = start + startWaitTime;
			while (Supervision.NowMilliSec < end) yield return 10;

			// 処理実施
			start = Supervision.NowMilliSec;
			end = start + duringTime;
			while (Supervision.NowMilliSec < end)
			{
				var per = (Supervision.NowMilliSec - start) / (float)duringTime;

				transform.Scale = startSize + (to - startSize) * Common.Easing.GetEasingValue(per, easingType);

				yield return 1;
			}
			transform.Scale = to;

			// 終了待機
			start = Supervision.NowMilliSec;
			end = start + finishWaitTime;

			while (Supervision.NowMilliSec < end) yield return 20;

			callback?.Invoke();

			yield return null;
		}

		public static int DrawGraphF(this Common.Transform transform, float xf, float yf, int handle, int TranFlags = DX.DX_TRUE)
		{
			return DX.DrawGraphF(transform.X + xf, transform.Y + yf, handle, TranFlags);
		}
	}
}
