using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Coroutine
{
    class CoroutineControl
    {
        public Coroutine StartCoroutine(IEnumerator enumerator)
        {
            var c = new Coroutine(enumerator);
            llist.AddLast(c);
            return c;
        }

        public Coroutine StartCoroutine(Coroutine coroutine)
        {
            llist.AddLast(coroutine);

            return coroutine;
        }

        public void StopCoroutine(Coroutine coroutine)
        {
            llist.Remove(coroutine);
        }

        LinkedList<Coroutine> llist = new LinkedList<Coroutine>();

        public void Update()
        {
            var node = llist.First;

            while (node != null)
            {
                var nval = node.Value;
                if (!node.Value.Enabled)
                {
                    node = node.Next;
                    continue;
                }

                bool hasNext = nval.MoveNext();

                if (hasNext)
                {
                    if(nval.Current is IEnumerator w)
                    {
                        var c = new Coroutine(w)
                        {
                            Parent = nval
                        };
                        llist.AddAfter(node, c);
                        nval.Enabled = false;
                    }
                    node = node.Next;
                }
                else
                {
                    if (nval.Parent != null)
                    {
                        nval.Parent.Enabled = true;
                    }

                    var next = node.Next;
                    llist.Remove(node);
                    node = next;
                }
            }
        }
    }
    
    class Coroutine
        : IEnumerator
    {
        public bool Enabled = true;

        bool finish = false;

        public bool Finish => finish;

        public Coroutine Parent;

        public object Current => enumerator.Current;

        protected IEnumerator enumerator;

        public virtual bool MoveNext()
        {
            finish = enumerator.MoveNext();

            return finish;
        }

        public virtual void Reset()
        {
            enumerator.Reset();
        }

        public Coroutine()
        {

        }

        public Coroutine(IEnumerator enumerator)
        {
            this.enumerator = enumerator;
        }
    }
    
    class Wait : Coroutine
    {
        int startTime;
        int millisec;

        IEnumerator GetWaitEnumerator()
        {
            while (Supervision.NowMilliSec - startTime < millisec)
            {
                yield return null;
            }
        }

        public Wait(int millisec)
        {
            this.millisec = millisec;
            startTime = Supervision.NowMilliSec;
            enumerator = GetWaitEnumerator();
        }
    }
}