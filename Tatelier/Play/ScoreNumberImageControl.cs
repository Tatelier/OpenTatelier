using System;
using System.IO;
using Tatelier.DxLibDLL;
using static DxLibDLL.DX;
using HjsonEx;

namespace Tatelier.Play
{
	class ScoreNumberImageControl
	{
		bool disposed;

		int[] handles;

		float xf = 11;
		float yf = 288;

		int chipWidth = 30;
		int chipHeight = 60;

		int score = 0;
		string strScore = "0";

		/// <summary>
		/// スコア点数
		/// </summary>
		public int ScorePoint
		{
			get => score;
			set
			{
				if (score != value)
				{
					score = value;
					strScore = $"{value}";
				}
			}
		}

		int Digit(int val)
		{
			// Mathf.Log10(0)はNegativeInfinityを返すため、別途処理する。
			return (val == 0) ? 1 : ((int)Math.Log10(val) + 1);
		}

		/// <summary>
		/// 描画処理
		/// </summary>
		public void Draw()
		{
			using (DrawModeGuard.Create())
			{
				SetDrawMode(DX_DRAWMODE_BILINEAR);

				for (int i = 0; i < strScore.Length; i++)
				{
					DrawRotaGraphFastF(xf - chipWidth * i, yf, 1.0F, 0.0F, handles[strScore[(strScore.Length - 1) - i] - 0x30], DX_TRUE);
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					// un-managed
					ImageLoadControl.Singleton.Delete(handles);
				}

				// managed
				disposed = true;
			}
		}

		~ScoreNumberImageControl()
		{
			Dispose();
		}
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="folderPath">ルートフォルダ</param>
		/// <param name="json"></param>
		public ScoreNumberImageControl(string folderPath, Hjson.JsonValue json)
		{
			if (json == null)
			{
				json = new Hjson.JsonObject();
			}

			handles = new int[10];

			string scoreNumberFolder = json.EQs("FolderPath") ?? "ScoreNumber";

			for(int i = 0; i < handles.Length; i++)
			{
				handles[i] = ImageLoadControl.Singleton.Load(Path.Combine(folderPath, scoreNumberFolder, $"{i}.png"));
			}

			xf = json.EQf("X") ?? xf;
			yf = json.EQf("Y") ?? yf;

			chipWidth = json.EQi("Chip.Width") ?? 30;
			chipHeight = json.EQi("Chip.Height") ?? 60;
		}
	}
}
