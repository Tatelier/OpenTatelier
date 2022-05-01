using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Sound
{
	class SoundGroupControl
	{
		public static SoundGroupControl Singleton { get; }

		static SoundGroupControl()
		{
			Singleton = new SoundGroupControl();
		}

		public SoundGroup Create(string name)
		{
			var soundGroup = new SoundGroup(name);

			list.Add(soundGroup);

			return soundGroup;
		}

		public void Delete(SoundGroup soundGroup)
		{
			list.Remove(soundGroup);
		}

		List<SoundGroup> list = new List<SoundGroup>();

		public void Update()
		{
			foreach (var item in list)
			{
				item.Update();
			}
		}
	}
}
