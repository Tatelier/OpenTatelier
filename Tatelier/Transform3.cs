using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;

namespace Tatelier
{
    class Transform3
    {
        public class Point2DF
        {
            public float X;
            public float Y;
        }

        public class Size2DF
        {
            public float Width;
            public float Height;
        }

        public Point2DF PivotPoint = new Point2DF();

        public Point2DF Point = new Point2DF();

        public Size2DF Scale = new Size2DF();

        /// <summary>
        /// 角度 (0.0 ～ 360.0)
        /// </summary>
        public float Angle = 0;

        public Size2DF Size = new Size2DF();        

        public void SetSize(int imageHandle)
        {
            GetGraphSizeF(imageHandle, out Size.Width, out Size.Height);
        }

        public void SetFromRect(RectF rect)
        {
            Point.X = rect.X;
            Point.Y = rect.Y;

            Size.Width = rect.Width;
            Size.Height = rect.Height;
        }

        public void Draw(Transform3 parent, int imageHandle)
        {
            DrawRotaGraphFast3F(Point.X + parent.Point.X, Point.Y + parent.Point.Y, PivotPoint.X, PivotPoint.Y, Scale.Width, Scale.Height, Angle, imageHandle, DX_TRUE);
        }

        public void DrawTile(Transform3 parent, int imageHandle)
        {
            DrawTileGraph(Point.X + parent.Point.X, Point.Y + parent.Point.Y
                , Point.X + parent.Point.X + parent.Size.Width, Point.Y + parent.Point.Y + parent.Size.Height
                , PivotPoint.X, PivotPoint.Y
                , imageHandle);
        }

        public Transform3()
		{
            Scale.Width = 1;
            Scale.Height = 1;
		}
    }
}
