using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Common.Except
{
	public class UserIllegalException : Exception
	{
		public override string Message { get; }

		public UserIllegalException(int val)
		{
			switch (val)
			{
				case -1:
					{
						Message = @"ユーザー登録がされていません。ウェブサイトから登録してください";
					}
					break;
				case -9:
					{
						Message = "このアカウントは許可されていません。\n\n心当たりのない方はウェブサイトの「お問い合わせ」にご連絡ください。";
					}
					break;
				default:
					{
						Message = @"想定外異常";
					}
					break;
			}
		}
	}
}
