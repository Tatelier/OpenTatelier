using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.SongSelect
{
    class PlayOptionRendererInfo
    {
        public int Background = -1;
        public int ValueBackground = -1;

        public int LeftArrow = -1;
        public int RightArrow = -1;

        public PlayOptionRendererInfo()
        {
            Background = ImageLoadControl.Singleton.Load(@"Resources\Theme\v1\SongSelect\PlayOption\Background.png");
            ValueBackground = ImageLoadControl.Singleton.Load(@"Resources\Theme\v1\SongSelect\PlayOption\ValueBackground.png");
            LeftArrow = ImageLoadControl.Singleton.Load(@"Resources\Theme\v1\SongSelect\PlayOption\LeftArrow.png");
            RightArrow = ImageLoadControl.Singleton.Load(@"Resources\Theme\v1\SongSelect\PlayOption\RightArrow.png");
        }
    }

    class PlayOptionRenderer
    {
        public PlayOption PlayOption = new PlayOption();

        PlayOptionRendererInfo info;

        int fontHandle = -1;

        uint color = 0xF0F0F0;

        uint edgeColor = 0x222222;

        public bool Enabled = false;

        public void ResetIndex()
        {
            currentIndex = 0;
        }

        /// <summary>
        /// 次の項目に移動する
        /// </summary>
        /// <returns>true: 正常, false: もう次はない</returns>
        public bool MoveNext()
        {
            currentIndex++;
            if(currentIndex < PlayOption.PlayOptionItemList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ItemNext()
        {
            PlayOption.PlayOptionItemList[currentIndex].Next();
        }

        public void ItemPrev()
        {
            PlayOption.PlayOptionItemList[currentIndex].Prev();
        }

        int currentIndex = 0;

        public void Update()
        {

        }

        public void Draw(float x, float y)
        {
            if(!Enabled)
            {
                return;
            }


            int paddingWidth = 16;
            int paddingHeight = 48;
            int itemPadding = 24;

            float valueAreaWidth = 200;

            var optionList = PlayOption.PlayOptionItemList;


            DrawTileGraph(x - paddingWidth
                , y - paddingHeight, x + 360 + paddingWidth
                , y + optionList.Count * (GetFontSizeToHandle(fontHandle) + itemPadding) - itemPadding + paddingHeight
                , 0
                , 0
                , info.Background);

            float itemY;

            for(int i = 0; i < optionList.Count; i++)
            {
                string header = $"{optionList[i].Header}";

                //DrawStringFToHandle(x, y, header, color, fontHandle, edgeColor);
                DrawRotaStringFToHandle(x + 72, y, 1.0, 1.0, GetDrawStringWidthToHandle(header, Encoding.UTF8.GetByteCount(header), fontHandle) / 2, 0, 0, color, fontHandle, edgeColor, 0, header);

                string val = string.Format(optionList[i].ValueFormat, optionList[i].RawValue);
                DrawRotaGraphF(x + 256, y + GetFontSizeToHandle(fontHandle) / 2, 1.0, 0.0, info.ValueBackground, TRUE);
                if (currentIndex == i)
                {
                    DrawRotaGraphF(x + 184, y + GetFontSizeToHandle(fontHandle) / 2, 1.0, 0.0, info.LeftArrow, TRUE);
                    DrawRotaGraphF(x + 328, y + GetFontSizeToHandle(fontHandle) / 2, 1.0, 0.0, info.RightArrow, TRUE);
                }
                DrawRotaStringFToHandle(x + 256, y, 1.0, 1.0, GetDrawStringWidthToHandle(val, Encoding.UTF8.GetByteCount(val), fontHandle) / 2, 0, 0, color, fontHandle, edgeColor, 0, val);
                y += GetFontSizeToHandle(fontHandle) + itemPadding;
            }

        }

        public PlayOptionRenderer()
        {
            fontHandle = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 32, -1, DX_FONTTYPE_ANTIALIASING_EDGE_4X4, -1, 3);
            SetFontSpaceToHandle(-4, fontHandle);
            info = new PlayOptionRendererInfo();
        }
    }
}
