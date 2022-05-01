using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Common.Except
{
	public class NotFoundDefaultDataException
		: Exception
	{
		string descrption;

		public override string Message => descrption;

		public NotFoundDefaultDataException(string description)
		{
			this.descrption = description;
		}
	}
}
