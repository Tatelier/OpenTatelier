using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Interface;
using Tatelier.Interface.Play;
using Tatelier.Score.Component.NoteSystem;

namespace Tatelier.Empty.Play
{
    public class NoteFlyEffectEmpty : INoteFlyEffect
	{
		public void Draw(int nowTime) { }

		public void Fly(NoteType noteType, int startTime) { }

		public void Reset() { }
	}
}