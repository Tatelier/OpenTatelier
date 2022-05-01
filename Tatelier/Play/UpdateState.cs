using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Play
{
	struct UpdateState
	{
		[Flags]
		enum StateEnum
		{
			LDon = 1,
			RDon = 2,
			Don = 3,
			LKat = 16,
			RKat = 32,
			Kat = 48,
		}

		StateEnum b;

		void Set(bool enabled, StateEnum state)
		{
			if (enabled)
			{
				b |= state;
			}
			else
			{
				b &= ~state;
			}
		}

		public bool Don
		{
			get => (b & StateEnum.Don) > 0;
			set => Set(value, StateEnum.Don);
		}

		public bool Kat
		{
			get => (b & StateEnum.Kat) > 0;
			set => Set(value, StateEnum.Kat);
		}

		public bool LDon
		{
			get => (b & StateEnum.LDon) > 0;
			set => Set(value, StateEnum.LDon);
		}
		public bool LKat
		{
			get => (b & StateEnum.LKat) > 0;
			set => Set(value, StateEnum.LKat);
		}

		public bool RDon
		{
			get => (b & StateEnum.RDon) > 0;
			set => Set(value, StateEnum.RDon);
		}
		public bool RKat
		{
			get => (b & StateEnum.RKat) > 0;
			set => Set(value, StateEnum.RKat);
		}

		public void Reset()
		{
			b = 0;
		}
	}
}
