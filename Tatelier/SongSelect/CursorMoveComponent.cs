using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
    class CursorMoveCourseComponent
    {
        ICursorMoveCourseComponent component;

        int courseIndex;

        public CursorMoveCourseComponent(ICursorMoveCourseComponent component)
        {
            this.component = component;
        }
    }

    interface ICursorMoveCourseComponent
    {

    }

}
