using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tatelier.Engine.Interface;

using DxLibDLL;
using static DxLibDLL.DX;

namespace Tatelier.DxLib
{
    internal class FunctionModule : IEngineFunctionModule
    {
        string title = "DxLib";
        public string Title
        {
            get => title;
            set
            {
                title = value;
                SetWindowText(value);
            }
        }

        public FunctionModule()
        {
            title = title;
        }

        public bool WindowMode { get => GetWindowModeFlag() == 1; set => ChangeWindowMode(value ? 1 : 0); }

        public int ClearDrawScreen()
        {
            return DX.ClearDrawScreen();
        }

        public int CreateFontToHandle(string fontName, int size = 16, int thick = -1, int fontType = -1, int charSet = -1, int edgeSize = -1, int italic = 0, int handle = -1)
        {
            return DX.CreateFontToHandle(fontName, size, thick, fontType, charSet, edgeSize, italic, handle);
        }

        public int DrawGraph(int x, int y, int grHandle, int transFlag)
        {
            throw new NotImplementedException();
        }

        public int DrawGraphF(float xf, float yf, int grHandle, int transFlag)
        {
            throw new NotImplementedException();
        }

        public int LoadGraph(string FileName, int NotUse3DFlag = 0)
        {
            return DX.LoadGraph(FileName, NotUse3DFlag);
        }

        public int DeleteGraph(int handle)
        {
            return DX.DeleteGraph(handle);
        }

        public int ModuleFinish()
        {
            throw new NotImplementedException();
        }

        public int ModuleStart()
        {
            return 0;
        }

        public int ProcessMessage()
        {
            throw new NotImplementedException();
        }

        public int ScreenFlip()
        {
            throw new NotImplementedException();
        }

        public int SetGraphMode(int width, int height, int colorBitDepth)
        {
            throw new NotImplementedException();
        }

        public int SetWindowSize(int width, int height)
        {
            throw new NotImplementedException();
        }
    }
}
