using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Sound;

namespace Tatelier
{
    class SoundGroupShare
    {
        public static SoundGroupShare Singleton { get; private set; } = new SoundGroupShare();

        public SoundGroup Master { get; private set; }

        public SoundGroup SE { get; private set; }

        public SoundGroup BGM { get; private set; }

        public void Start()
        {
            Master = SoundGroupControl.Singleton.Create(nameof(Master));
            SE = SoundGroupControl.Singleton.Create(nameof(SE));
            BGM = SoundGroupControl.Singleton.Create(nameof(BGM));

            SE.Parent = Master;
            BGM.Parent = Master;
        }

        public void Reset()
        {
            Singleton = new SoundGroupShare();
        }
    }
}
