using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.Sound
{
	[DebuggerDisplay("Name: {Name}")]
	class SoundGroup
	{
#if DEBUG
		readonly string Name;
#endif
		SoundGroup parent = null;
		public SoundGroup Parent
        {
			get => parent;
            set
            {
				if (parent != null)
                {
					parent.Children.Remove(this);
                }
				parent = value;

                if (parent != null)
                {
					parent.Children.Add(this);
                }
            }
        }

		List<int> handleList = new List<int>();

		List<SoundGroup> Children = new List<SoundGroup>();

		/// <summary>
		/// DX関数コール用音量 [0～255]
		/// </summary>
		public int VolumePal => (int)(MasterVolume * 255 / 100);

		double volume = 100;

		/// <summary>
		/// 音量 [0.0～100.0]
		/// </summary>
		public double Volume
		{
			get => volume;
			set
			{
				if (value < 0)
				{
					volume = 0;
				}
				else if (value > 100)
				{
					volume = 100;
				}
				else
				{
					volume = value;
				}
				volumeChange = 1;
			}
		}

		public double MasterVolume
		{
			get
			{
				return Parent != null ? Parent.MasterVolume * Volume / 100.0 : Volume;
			}
		}

		byte volumeChange = 0;

		/// <summary>
		/// 音声ファイルを読み込む
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public int Load(string filePath)
		{
			int handle = LoadSoundMem(filePath);
			if (handle != -1)
			{
				Regist(handle);
			}

			return handle;
		}

		/// <summary>
		/// 音声ハンドルをグループに登録する
		/// </summary>
		/// <param name="handle">音声ハンドル</param>
		public void Regist(int handle)
		{
			handleList.Add(handle);
			ChangeVolumeSoundMem(VolumePal, handle);
		}

		/// <summary>
		/// 音声ハンドルを登録する
		/// ※
		/// </summary>
		/// <param name="handle"></param>
		public void RigistOnly(int handle)
		{
			if (handleList.Count > 0)
			{
				handleList[0] = handle;
			}
			else
			{
				handleList.Add(handle);
			}
			ChangeVolumeSoundMem(VolumePal, handle);
		}

		public void Update(bool force = false)
		{
			if (volumeChange != 0
				|| force)
			{
				foreach (var item in handleList)
				{
					ChangeVolumeSoundMem(VolumePal, item);
				}

				foreach(var item in Children)
                {
					item.Update(true);
                }

				volumeChange = 0;
			}
		}

		public SoundGroup(string name)
		{
#if DEBUG
			this.Name = name;
#endif
			Logger.Singleton.Trace($"Create SoundGroup: {name}");
		}
	}
}
