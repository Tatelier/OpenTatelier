using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Progress
{
    class ProgressControl
    {
        public static ProgressControl Singleton { get; } = new ProgressControl();

        LinkedList<Progress> list = new LinkedList<Progress>();
        Progress progress;

        ProgressRendererInfo rendererInfo;

        public void Update()
        {
            var node = list.First;
            while (node != null)
            {
                var next = node.Next;

                node.Value.Update();
                if (node.Value.IsEnd)
                {
                    list.Remove(node);
                }
                
                node = next;
            }
        }

        public void Draw()
        {
            float y = rendererInfo.Y;
            foreach (var item in list)
            {
                item.Draw(rendererInfo);
                rendererInfo.Y -= 80;
            }
            rendererInfo.Y = y;
        }
        
        public Progress Current => progress;

        public Progress Create(Progress progress)
        {
            list.AddLast(progress);
            return progress;
        }

        public void Start()
        {
            progress = new Progress();
            rendererInfo = new ProgressRendererInfo();
        }

        public ProgressControl()
        {
        }
    }
}
