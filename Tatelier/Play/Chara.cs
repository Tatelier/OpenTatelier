using HjsonEx;
using System.IO;

namespace Tatelier.Play
{
	class Chara
	{
		public int Player = 1;

		public float X;
		public float Y;

		public bool IsSoul = false;

		public APNGImage NormaChara;
		public APNGImage SoulChara;

		double bpm;

		public double BPM
		{
			get => bpm;
			set
			{
				bpm = value;
				if (NormaChara != null)
				{
					NormaChara.BPM = bpm;
				}
				if (SoulChara != null)
				{
					SoulChara.BPM = bpm;
				}
			}
		}

		public void Update()
		{
			NormaChara?.Update();
			SoulChara?.Update();
		}

		public void Draw()
		{
			if (!IsSoul)
			{
				NormaChara?.Draw(X, Y);
			}
			else
			{
				SoulChara?.Draw(X, Y);
			}
		}


		public Chara(string folder, Hjson.JsonValue json)
		{
			if(json == null)
			{
				json = HjsonEx.Empty.Value;
			}

			X = json.EQf("PointX") ?? 0;
			Y = json.EQf("PointY") ?? 0;
			NormaChara = new APNGImage(Path.Combine(folder, json.EQs("Normal.FilePath") ?? ""));
			SoulChara = new APNGImage(Path.Combine(folder, json.EQs("Soul.FilePath") ?? ""));
		}
	}
}
