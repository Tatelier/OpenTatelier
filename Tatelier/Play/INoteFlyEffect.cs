using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score.Component.NoteSystem;

namespace Tatelier.Interface.Play
{
    public interface INoteFlyEffect
	{
		void Fly(NoteType noteType, int startTime);
		void Reset();
		void Draw(int nowTime);
	}
}
