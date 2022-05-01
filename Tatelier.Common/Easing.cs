using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Common
{
	public enum EasingType
	{
		/// <summary>
		/// なし
		/// </summary>
		None,

		/// <summary>
		/// 正弦波(In)
		/// </summary>
		SinIn,

		/// <summary>
		/// 正弦波(Out)
		/// </summary>
		SinOut,

		/// <summary>
		/// 
		/// </summary>
		EaseOutElastic,

		/// <summary>
		/// 
		/// </summary>
		EaseInOutQuart,

		/// <summary>
		/// 
		/// </summary>
		EaseOutExpo,
	}

	public static class Easing
	{
		public static float GetEasingValue(float t, EasingType easingType)
		{
			switch (easingType)
			{
				case EasingType.None:
				default:
					return t;
				case EasingType.SinIn:
					return EaseSinIn(t);
				case EasingType.SinOut:
					return EaseSinOut(t);
				case EasingType.EaseInOutQuart:
					return EaseInOutQuart(t);
				case EasingType.EaseOutElastic:
					return EaseOutElastic(t);
				case EasingType.EaseOutExpo:
					return EaseOutExpo(t);
			}
		}

		public static float EaseSinIn(float t)
		{
			return (float)(1 - Math.Cos(t * Math.PI / 2));
		}
		public static float EaseSinOut(float t)
		{
			return (float)Math.Sin(Math.PI * t / 2);
		}
		public static float EaseOutElastic(float t)
		{
			const double c4 = (2 * Math.PI) / 3;

			return t == 0
			  ? 0F
			  : t == 1
			  ? 1F
			  : (float)(Math.Pow(2, -10 * t) * Math.Sin((t * 10 - 0.75) * c4) + 1);
		}
		public static float EaseInOutQuart(float t)
		{
			return (float)(t < 0.5 ? 8 * t * t * t * t : 1 - Math.Pow(-2 * t + 2, 4) / 2);
		}
		public static float EaseOutExpo(float t)
		{
			return (float)(t == 1 ? 1 : 1 - Math.Pow(2, -10 * t));
		}

		public static float EaseOutBack(float t)
		{
			const float c1 = 1.70158F;
			const float c3 = c1 + 1;

			return (float)(1 + c3 * Math.Pow(t - 1, 3) + c1 * Math.Pow(t - 1, 2));
		}

		public static float EaseOutBounce(float x)
		{
			const float n1 = 7.5625F;
			const float d1 = 2.75F;

			if (x < 1 / d1)
			{
				return n1 * x * x;
			}
			else if (x < 2 / d1)
			{
				x -= 1.5F;
				return (float)(n1 * (x / d1) * x + 0.75);
			}
			else if (x < 2.5 / d1)
			{ x -= 2.25F;
				return (float)(n1 * (x / d1) * x + 0.9375);
			}
			else
			{ x -= 2.625F;
				return (float)(n1 * (x / d1) * x + 0.984375);
			}
		}

		public static float EaseOutQuint(float  t)
		{
			return (float)(1 - Math.Pow(1 - t, 5));
		}
	}
}
