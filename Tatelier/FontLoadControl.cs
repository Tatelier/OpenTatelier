using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier
{
    class FontLoadInfo
    {
        
    }

    class FontMapItem
    {
        public int Handle = -1;
        public int Count = 0;
    }

    class FontLoadControl
    {
        public FontLoadControl Singleton { get; } = new FontLoadControl();

        public Dictionary<string, FontMapItem> fontMap = new Dictionary<string, FontMapItem>();
        public Dictionary<int, string> fontHandleMap = new Dictionary<int, string>();

        public int Create(string fontName, int size, int thick, int fontType = -1, int charSet = -1, int edgeSize = -1, int italic = DX_FALSE, int handle = -1)
        {
            string key = $"{fontName},{size},{thick},{fontType},{charSet},{edgeSize},{italic},{handle}";

            int h = -1;

            if (fontMap.TryGetValue(key, out var item))
            {
                h = item.Handle;
                item.Count++;
            }
            else
            { 
                h = CreateFontToHandle(fontName, size, thick, fontType, charSet, edgeSize, italic, handle);
                item = new FontMapItem();
                item.Handle = h;
                item.Count = 1;
            }

            return h;
        }

        public void Destroy()
        {
            return;
        }

        FontLoadControl() { }
    }
}
