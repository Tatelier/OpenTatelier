using HjsonEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DxLibDLL.DX;

namespace Tatelier
{
    class DrawingOption
    {
        interface IElement
		{
            void Start();
            void Update(DrawingOption option);
		}

        public class Scroll : IElement
        {
            int startTime = -1;

            float moveX;
            float moveY;

            public void Start()
            {
                startTime = Supervision.NowMilliSec;
            }

            public void Update(DrawingOption option)
            {
                int nowTime = Supervision.NowMilliSec - startTime;
                float per = ((float)nowTime / 1000);

				Transform3.Point2DF pivotPoint = option.Transform.PivotPoint;

				GetGraphSizeF(option.Handle, out float w, out float h);

                pivotPoint.X = (pivotPoint.X + moveX * per) % w;
                pivotPoint.Y = (pivotPoint.Y + moveY * per) % h;

                startTime = Supervision.NowMilliSec;
            }

            public Scroll(float xf, float yf)
			{
                moveX = xf;
                moveY = yf;
                startTime = Supervision.NowMilliSec;
			}

            public Scroll(Hjson.JsonValue json)
            {
                moveX = json.EQf("X") ?? moveX;
                moveY = json.EQf("Y") ?? moveY;
                startTime = Supervision.NowMilliSec;
            }
        }

        public class Rotate : IElement
        {
            int startTime = -1;

            float angle;

            public void Start()
            {
                startTime = Supervision.NowMilliSec;
            }

            public void Update(DrawingOption option)
            {
                int nowTime = Supervision.NowMilliSec - startTime;
                float per = ((float)nowTime / 1000);

                option.Transform.Angle += angle * per;
            }

            public Rotate(float angle)
            {
                this.angle = angle;
                startTime = Supervision.NowMilliSec;
            }

            public Rotate(Hjson.JsonValue json)
            {
                angle = json.EQf("Angle") ?? angle;
                startTime = Supervision.NowMilliSec;
            }
        }

        public Transform3 Transform = new Transform3();

        public int Tile = 0;

        public int Handle = -1;

        List<IElement> elements = new List<IElement>();

        public void SetFromJson(Hjson.JsonArray jsonArray)
        {
            foreach(var item in jsonArray)
            {
                var type = item.EQs("Type");
                switch(type)
                {
                    case "Scroll":
                        {
                            elements.Add(new Scroll(item));
                        }
                        break;
                    case "Rotate":
                        {
                            elements.Add(new Rotate(item));
                        }
                        break;
                }
            }
        }

        public void Update()
		{
            foreach(var elem in elements)
			{
                elem.Update(this);
			}
		}

        public void Draw(Transform3 parent)
        {
            if (Tile == 0)
            {
                Transform.Draw(parent, Handle);
            }
			else
			{
                Transform.DrawTile(parent, Handle);
			}
        }
    }
}
