using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForTatelier
{
	[TestClass]
	public class UnitTestTatelierCommon
	{
		[TestMethod]
		public void TestCalcForString()
		{
			{
				float val = Tatelier.Common.Utility.CalcFromString("1 + 1", null);
				Assert.AreEqual(val, 2);
			}

			{
				float val = Tatelier.Common.Utility.CalcFromString("13 * 4 + 1 * 0 + 5", null);
				Assert.AreEqual(val, 57);
			}

			{
				float val = Tatelier.Common.Utility.CalcFromString("2/2", null);
				Assert.AreEqual(val, 1);
			}

			{
				float val = Tatelier.Common.Utility.CalcFromString("2/4 + 0.5 + 9", null);
				Assert.AreEqual(val, 10);
			}

			{
				float val = Tatelier.Common.Utility.CalcFromString("(3-1)*((1.5*3)*10)+4", null);
				Assert.AreEqual(val, 94);
			}

			{
				float val = Tatelier.Common.Utility.CalcFromString("{{ ScreenWidthHalf }} + 50 + 50 * {{ Index }}", new System.Collections.Generic.Dictionary<string, float>()
				{
					{ "ScreenWidthHalf", 960 },
					{ "Index", 1 },
				});
				Assert.AreEqual(val, 1060);
			}
		}
	}
}
