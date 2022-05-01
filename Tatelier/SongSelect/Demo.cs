using System;
using System.IO;
using static DxLibDLL.DX;
using HjsonEx;
using Tatelier.Sound;
using System.Diagnostics;

namespace Tatelier.SongSelect
{
	/// <summary>
	/// デモ再生クラス
	/// </summary>
	class Demo : IDisposable
	{
		/// <summary>
		/// デモ再生状態
		/// </summary>
		enum DemoStatus
		{
			/// <summary>
			/// 停止中
			/// </summary>
			Stop,
			/// <summary>
			/// 再生可能
			/// </summary>
			PlayOK,
			/// <summary>
			/// 遅延して待機
			/// </summary>
			WaitDelay,
		}

		bool disposed = false;

		bool enabled = true;

		/// <summary>
		/// 有効／無効
		/// </summary>
		public bool Enabled
		{
			get => enabled;
			set
			{
				enabled = value;
				if (!enabled)
				{
					Stop();
				}
			}
		}


		public string DefaultFilePath { get; set; } = string.Empty;
		public int DefaultSoundVolume = 90;
		string path = string.Empty;
		int startPosition;
		int delayMaster;
		int delay = 0;
		int handle;

		DemoStatus demoStatus = DemoStatus.Stop;

		/// <summary>
		/// デフォルト音声をロード
		/// </summary>
		public void LoadDefault()
		{
			Load(DefaultFilePath, 0);
		}

		/// <summary>
		/// 音声を読み込む。(非同期)
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <param name="startPosition">再生位置(ms)</param>
		/// <param name="isForce">同じファイルでもリセットする。</param>
		public void Load(string filePath, int startPosition, bool isForce = false)
		{
			if (!isForce && filePath.Equals(this.path)) return;

			// 情報を取得
			this.path = filePath;
			this.startPosition = startPosition;
			demoStatus = DemoStatus.Stop;

			DeleteSoundMem(handle);
			handle = -1;

			SetUseASyncLoadFlag(DX_TRUE);
			if (filePath.EndsWith("mp3"))
			{
#warning TODO: mp3のとき形式を変更する
				SetCreateSoundDataType(DX_SOUNDDATATYPE_FILE);
			}
			else
			{
				SetCreateSoundDataType(DX_SOUNDDATATYPE_MEMPRESS);
			}

			handle = SoundGroupShare.Singleton.BGM.Load(filePath);
			SetCreateSoundDataType(DX_SOUNDDATATYPE_MEMNOPRESS);
			SetUseASyncLoadFlag(DX_FALSE);
		}

		/// <summary>
		/// 再生停止
		/// </summary>
		void Stop()
		{
			StopSoundMem(handle);
		}

		public void SetDelayMasterFromFrame(int delayFrame)
		{
			this.delayMaster = delayFrame;
		}
		public void ResetDelay()
		{
			this.delay = delayMaster;
		}

		/// <summary>
		/// 再生中
		/// [true:再生中, false:再生中ではない]
		/// </summary>
		public bool IsPlaying => CheckSoundMem(handle) == 0;

		/// <summary>
		/// 再生
		/// </summary>
		public void Play()
		{
			switch (demoStatus)
			{
				case DemoStatus.PlayOK:
					{
						int check = CheckSoundMem(handle);
						int checkAsync = CheckHandleASyncLoad(handle);

						if (check == 0
							&& checkAsync == FALSE)
						{
							SetSoundCurrentTime(startPosition, handle);
							PlaySoundMem(handle, DX_PLAYTYPE_BACK, 0);
						}
					}
					break;
				case DemoStatus.WaitDelay:
					{
						if (delay == 0)
						{
							demoStatus = DemoStatus.PlayOK;
						}
						else
						{
							delay--;
						}
					}
					break;
				case DemoStatus.Stop:
					{
						demoStatus = DemoStatus.WaitDelay;
					}
					break;
			}
		}

		/// <summary>
		/// 初期化処理
		/// </summary>
		public void Start()
		{

		}

		/// <summary>
		/// 更新処理
		/// </summary>
		public void Update()
		{
			if (enabled)
			{
				Play();
			}
		}

		/// <summary>
		/// 破棄処理
		/// </summary>
		/// <param name="disposing"></param>
		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				Stop();
				Enabled = false;
				if (disposing)
				{
					// unmanaged
					DeleteSoundMem(handle);
					handle = -1;
				}
				// managed
				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~Demo()
		{
			Dispose();
		}

		public Demo()
		{

		}

		public Demo(string currentDirectory, Hjson.JsonValue json) : base()
		{
			if (json == null)
			{
				json = new Hjson.JsonObject();
			}

			DefaultFilePath = Path.Combine(currentDirectory, json.EQs("Default.BGMFilePath") ?? "Default.ogg");
			DefaultSoundVolume = json.EQi("Default.Volume") ?? 100;
		}

	}
}
