using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier
{
    internal class MouseDiff
    {
        int x;
        int y;

        public int X
        {
            get
            {
                GetMousePoint(out var x, out _);
                int result = x - this.x;

                this.x = x;

                return result;
            }
        }

        public int Y
        {
            get
            {
                GetMousePoint(out _, out var y);
                int result = y - this.y;

                this.y = y;

                return result;
            }
        }
    }
}
