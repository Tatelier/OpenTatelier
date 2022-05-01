using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.SongSelect
{
	/// <summary>
	/// 効果音
	/// </summary>
	class SoundEffect
		: IDisposable
	{
		bool disposed = false;

		/// <summary>
		/// 選択音
		/// </summary>
		int ok = -1;

		/// <summary>
		/// 選択音再生
		/// </summary>
		public void OK() => PlaySoundMem(ok, DX_PLAYTYPE_BACK);

		/// <summary>
		/// 移動音
		/// </summary>
		int move = -1;

		/// <summary>
		/// 移動音再生
		/// </summary>
		public void Move() => PlaySoundMem(move, DX_PLAYTYPE_BACK);

		/// <summary>
		/// キャンセル音
		/// </summary>
		int cancel = -1;

		/// <summary>
		/// キャンセル音再生
		/// </summary>
		public void Cancel() => PlaySoundMem(cancel, DX_PLAYTYPE_BACK);

		/// <summary>
		/// ボリュームをセットする
		/// </summary>
		/// <param name="vol"></param>
		public void SetVolume(int vol)
		{
			SetVolumeSoundMem(vol, ok);
			SetVolumeSoundMem(vol, move);
			SetVolumeSoundMem(vol, cancel);
		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					//unmanaged
					DeleteSoundMem(ok);
					DeleteSoundMem(move);
					DeleteSoundMem(cancel);
				}
				//managed
				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~SoundEffect()
		{
			Dispose();
		}


		public SoundEffect(string currentDirectory, Hjson.JsonValue json)
		{
			if (json == null)
			{
				json = new Hjson.JsonObject();
			}

			var se = SoundGroupShare.Singleton.SE;
			ok = se.Load(Path.Combine(currentDirectory, json.EQs("OK.FilePath") ?? "OK.wav"));
			move = se.Load(Path.Combine(currentDirectory, json.EQs("Move.FilePath") ?? "Move.wav"));
			cancel = se.Load(Path.Combine(currentDirectory, json.EQs("Cancel.FilePath") ?? "Cancel.wav"));
		}

	}
}