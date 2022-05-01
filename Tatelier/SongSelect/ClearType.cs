using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
    [Flags]
    enum ClearType : long
    {
        /// <summary>
        /// なし
        /// </summary>
        None = 0,
        /// <summary>
        /// ノルマクリア
        /// </summary>
        NormaClear = 1,
        /// <summary>
        /// 魂
        /// </summary>
        Soul = 2,
        /// <summary>
        /// フルコンボ
        /// </summary>
        FullCombo = 4,
        /// <summary>
        /// 全可
        /// </summary>
        FullGood = 8,
        /// <summary>
        /// 全良
        /// </summary>
        FullGreat = 16,
    }
}
