using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
    public interface IMusicalScoreSystem
    {
        IMusicalScoreSystem Parent { get; }
        IReadOnlyList<IMusicalScoreSystem> Children { get; }
    }
}
