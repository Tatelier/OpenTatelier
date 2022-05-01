using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;
using Tatelier.DxLibDLL;

namespace Tatelier.Progress
{
    class ProgressRendererInfo
    {
        public float X = 1508;
        public float Y = 984;

        public int PerTextFontHandle = -1;
        public int StatusTextFontHandle = -1;

        public int BackgroundHandle = -1;
        public int ForegroundHandle = -1;

        public ProgressRendererInfo()
        {
            BackgroundHandle = ImageLoadControl.Singleton.Load("Resources\\Theme\\System\\Progress\\Background.png");
            ForegroundHandle = ImageLoadControl.Singleton.Load("Resources\\Theme\\System\\Progress\\Frontground.png");

            PerTextFontHandle = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 24, 0, DX_FONTTYPE_ANTIALIASING);
            StatusTextFontHandle = CreateFontToHandle(MainConfig.Singleton.DefaultFont, 16, 0, DX_FONTTYPE_ANTIALIASING);
        }

        ~ProgressRendererInfo()
        {
            ImageLoadControl.Singleton.Delete(BackgroundHandle);
            ImageLoadControl.Singleton.Delete(ForegroundHandle);

            DeleteFontToHandle(PerTextFontHandle);
            DeleteFontToHandle(StatusTextFontHandle);
        }
    }
    class Progress
    {
        public bool Enabled = true;

        public string StatusText = "";

        public float Max = 1;

        public float NowValue = 0;

        public float Ratio
        {
            get
            {
                if (Max <= 0)
                {
                    return 0;
                }
                float v = (NowValue / Max);

                if (v > 1)
                {
                    v = 1;
                }

                return v;
            }
        }

        //public int X = 1508, Y = 984;

        /// <summary>
        /// 終了したかどうか
        /// </summary>
        public bool IsEnd => Max <= NowValue; 

        public Progress()
        {
        }

        ~Progress()
        {
        }

        public void Update()
        {
            //NowValue++;
        }

        public void Draw(ProgressRendererInfo info)
        {
            GetGraphSize(info.BackgroundHandle, out var w, out var h);

            DrawGraphF(info.X, info.Y, info.BackgroundHandle, DX_TRUE);

            using (DrawAreaGuard.Create())
            {
                SetDrawArea((int)info.X, (int)info.Y, (int)(info.X + w * Ratio), (int)info.Y + h);


                DrawGraphF(info.X, info.Y, info.ForegroundHandle, DX_TRUE);
                  
                string per = $"{Ratio * 100:0}%";
                GetDrawStringSizeToHandle(out int fw, out int fh, out _, per, per.Length, info.PerTextFontHandle);

                DrawStringFToHandle(info.X + w * Ratio - fw - 8, info.Y + (h / 2) - (fh / 2) + 1, per, 0xF0F0F0, info.PerTextFontHandle);
            }

            DrawStringFToHandle(info.X, info.Y - 20, StatusText, 0xF0F0F0, info.StatusTextFontHandle);
        }
    }
}
