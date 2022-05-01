using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
	class TaikoSEControlInfo
	{
		public string DonFilePath = "";

		public string KatFilePath = "";

		public string BalloonFilePath = "";
	}

	enum TaikoSEType
	{
		Don,
		Kat,
		Miss,
		Balloon,
	}

	/// <summary>
	/// 太鼓SE管理クラス
	/// </summary>
	class TaikoSEControl
		: IDisposable
	{

		bool disposed = false;

		public int don = -1;

		public int kat = -1;

		public int balloon = -1;

		public int miss = -1;

		public void Play(TaikoSEType seType)
		{
			switch (seType)
			{
				case TaikoSEType.Don:
					PlaySoundMem(don, DX_PLAYTYPE_BACK);
					break;
				case TaikoSEType.Kat:
					PlaySoundMem(kat, DX_PLAYTYPE_BACK);
					break;
				case TaikoSEType.Balloon:
					PlaySoundMem(balloon, DX_PLAYTYPE_BACK);
					break;
				case TaikoSEType.Miss:
					PlaySoundMem(miss, DX_PLAYTYPE_BACK);
					break;
			}
		}

		void Dispose(bool disposing)
		{
			if (disposed)
			{
				if (disposing)
				{
					// unmanaged
					DeleteSoundMem(don);
					DeleteSoundMem(kat);
					DeleteSoundMem(miss);
					DeleteSoundMem(balloon);
				}

				// managed

				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~TaikoSEControl()
		{
			Dispose();
		}

		public TaikoSEControl(ElementInfo info)
		{
			var json = info.json;
			var se = SoundGroupShare.Singleton.SE;
			don = se.Load(Path.Combine(info.folder, Common.Utility.ReplaceFromJson(json.EQs("Don"), info.variableMap) ?? "SoundEffect/Don.wav"));
			kat = se.Load(Path.Combine(info.folder, Common.Utility.ReplaceFromJson(json.EQs("Kat"), info.variableMap) ?? "SoundEffect/Kat.wav"));
			miss = se.Load(Path.Combine(info.folder, Common.Utility.ReplaceFromJson(json.EQs("Miss"), info.variableMap) ?? "SoundEffect/Miss.wav"));
			balloon = se.Load(Path.Combine(info.folder, Common.Utility.ReplaceFromJson(json.EQs("Balloon"), info.variableMap) ?? "SoundEffect/Balloon.wav"));
		}

		public TaikoSEControl(TaikoSEControlInfo info)
		{
			var se = SoundGroupShare.Singleton.SE;
			don = se.Load(info.DonFilePath);
			kat = se.Load(info.KatFilePath);
			miss = -1;
			balloon = se.Load(info.BalloonFilePath);
		}
	}
}
