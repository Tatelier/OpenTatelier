using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;
using Tatelier.APNG;
using System.Diagnostics;
using Tatelier.Common;
using Tatelier.DxLibDLL;

namespace Tatelier.APNG
{
	class IHDR
	{

		// IHDR
		public uint Width;
		public uint Height;
		public byte BitDepth;
		public byte ColorType;
		public byte Compression;
		public byte Filter;
		public byte Interface;

		public byte[] ToByteArray()
		{
			byte[] bytes = new byte[0]
				.Concat(BitConverter.GetBytes(Width).Reverse().ToArray())
				.Concat(BitConverter.GetBytes(Height).Reverse().ToArray())
				.Concat(new byte[] { BitDepth })
				.Concat(new byte[] { ColorType })
				.Concat(new byte[] { Compression })
				.Concat(new byte[] { Filter })
				.Concat(new byte[] { Interface })
				.ToArray();

			return bytes;
		}
	}
}

namespace Tatelier
{
	class APNGImage : IDisposable
	{
		const byte APNG_DISPOSE_OP_NONE = 0;
		const byte APNG_DISPOSE_OP_BACKGROUND = 1;
		const byte APNG_DISPOSE_OP_PREVIOUS = 2;

		bool disposed = false;

		IHDR IHDR;

		int[] screens;
		int handle;

		[DebuggerDisplay("Delay : {DelayNum}/{DelayDen}, DisposeOp : {DisposeOp}, BlendOp : {BlendOp}")]
		class APNGImg : IDisposable
		{
			bool disposed = false;

			public uint SequenceNumber;
			public uint Width;
			public uint Height;
			public uint XOffset;
			public uint YOffset;
			public ushort DelayNum;
			public ushort DelayDen;
			public byte DisposeOp;
			public byte BlendOp;

			public byte[] idat;

			public int Handle;

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
						ImageLoadControl.Singleton.Delete(Handle);
					}

					disposed = true;
				}
			}

			~APNGImg()
			{
				Dispose();
			}
		}
		List<APNGImg> apngImg;

		int scrIdx = 0;

		IEnumerator<int> GGG()
		{
			var start = Supervision.NowMilliSec;

			int end;

			while (true)
			{
				end = Supervision.NowMilliSec;

				int diff = end - start;
				int idx = ((diff / 25) % apngImg.Count);

				yield return idx;
			}
		}

		IEnumerator<int> ggg;

		float ScaleX = 0.5F;
		float ScaleY = 0.5F;

		double bpm;

		long OneFrameTime;

		long MeasureTime;

		public double BPM
		{
			get => bpm;
			set
			{
				if (value <= 0)
				{
					value = 1;
				}
				bpm = value;
				MeasureTime = (long)(60000000 * 1 / bpm);
				OneFrameTime = MeasureTime / (apngImg?.Count ?? 1);
			}
		}


		public void Draw(float xf, float yf)
		{
			if (handle == -1) return;

			using (DrawScreenGuard.Create())
			{
				SetDrawScreen(screens[scrIdx]);
				ClearDrawScreen();
				DrawGraph((int)apngImg[nowIndex].XOffset, (int)apngImg[nowIndex].YOffset, apngImg[nowIndex].Handle, DX_TRUE);
			}

			DrawRotaGraphFast3F(xf, yf, 0, 0, ScaleX, ScaleY, 0.0F, screens[scrIdx], DX_TRUE);

			switch (apngImg[nowIndex].DisposeOp)
			{
				case APNG_DISPOSE_OP_NONE:
					// 次のスクリーン
					scrIdx = (scrIdx + 1) % 2;
					using (DrawScreenGuard.Create())
					{
						SetDrawScreen(screens[scrIdx]);
						ClearDrawScreen();
						DrawGraph(0, 0, screens[(scrIdx + 1) % 2], DX_TRUE);
					}
					break;
				case APNG_DISPOSE_OP_BACKGROUND:
					// 次のスクリーン
					scrIdx = (scrIdx + 1) % 2;
					using (DrawScreenGuard.Create())
					{
						SetDrawScreen(screens[scrIdx]);
						ClearDrawScreen();
					}
					break;
				case APNG_DISPOSE_OP_PREVIOUS:
					using (DrawScreenGuard.Create())
					{
						SetDrawScreen(screens[scrIdx]);
						ClearDrawScreen();
						DrawGraph(0, 0, screens[(scrIdx + 1) % 2], DX_TRUE);
					}
					break;
			}
		}

		long time;
		long diff;

		int nowIndex = 0;

		public void Update()
		{
			if (handle == -1 || MeasureTime == 0) return;
			long oneFrameTime = MeasureTime / apngImg.Count;

			long nowTime = Supervision.NowMicroSec;
			long temp = nowTime - time;
			diff = diff + temp;
			while (oneFrameTime < diff)
			{
				diff -= oneFrameTime;
				nowIndex = (nowIndex + 1) % apngImg.Count;
			}

			time = Supervision.NowMicroSec;
		}

		void Read_header(byte[] bytes)
		{

		}

		void Read_IHDR(byte[] bytes)
		{

			using (var ms = new MemoryStream(bytes))
			using (var br = new BinaryReader(ms))
			{
				IHDR = new IHDR();
				// 幅 (4byte)
				IHDR.Width = BitConverter.ToUInt32(br.ReadBytes(4).Reverse().ToArray(), 0);

				// 高さ (4byte)
				IHDR.Height = BitConverter.ToUInt32(br.ReadBytes(4).Reverse().ToArray(), 0);

				IHDR.BitDepth = br.ReadByte();
				IHDR.ColorType = br.ReadByte();
				IHDR.Compression = br.ReadByte();
				IHDR.Filter = br.ReadByte();
				IHDR.Interface = br.ReadByte();
			}
		}

		uint NumFrames;
		uint NumPlays;

		void Read_acTL(byte[] bytes)
		{
			using (var ms = new MemoryStream(bytes))
			using (var br = new BinaryReader(ms))
			{
				// 幅 (4byte)
				NumFrames = BitConverter.ToUInt32(br.ReadBytes(4).Reverse().ToArray(), 0);

				// 高さ (4byte)
				NumPlays = BitConverter.ToUInt32(br.ReadBytes(4).Reverse().ToArray(), 0);
			}
		}

		void Read_IDAT(byte[] bytes)
		{
			if (apngImg.Count > 0)
			{
				var img = apngImg.Last();

				using (var ms = new MemoryStream(bytes))
				using (var br = new BinaryReader(ms))
				{
					var dat = br.ReadBytes(bytes.Length);

					using (var ms2 = new MemoryStream())
					{
						ms2.Write(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, }, 0, 8);

						var ihdr = new IHDR()
						{
							Width = img.Width,
							Height = img.Height,
							BitDepth = IHDR.BitDepth,
							ColorType = IHDR.ColorType,
							Compression = IHDR.Compression,
							Filter = IHDR.Filter,
							Interface = IHDR.Interface,
						};

						var ihdrBytes = Get("IHDR", ihdr.ToByteArray());
						ms2.Write(ihdrBytes, 0, ihdrBytes.Length);

						var idat = Get("IDAT", dat);
						img.idat = idat;
						ms2.Write(idat, 0, idat.Length);

						var iend = Get("IEND");
						ms2.Write(iend, 0, iend.Length);

						img.Handle = Utility.GetImageHandle(ms2.ToArray());
					}

				}
			}
		}

		List<byte> subChunkData = new List<byte>();

		void CreateHandle()
		{
			foreach (var img in apngImg)
			{
				using (var ms2 = new MemoryStream())
				{
					ms2.Write(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, }, 0, 8);

					var ihdr = new IHDR()
					{
						Width = img.Width,
						Height = img.Height,
						BitDepth = IHDR.BitDepth,
						ColorType = IHDR.ColorType,
						Compression = IHDR.Compression,
						Filter = IHDR.Filter,
						Interface = IHDR.Interface,
					};

					var ihdrBytes = Get("IHDR", ihdr.ToByteArray());
					ms2.Write(ihdrBytes, 0, ihdrBytes.Length);

					ms2.Write(subChunkData.ToArray(), 0, subChunkData.Count);

					var idat = img.idat;
					ms2.Write(idat, 0, idat.Length);

					var iend = Get("IEND");
					ms2.Write(iend, 0, iend.Length);

					img.Handle = Utility.GetImageHandle(ms2.ToArray());
				}
			}
		}

		byte[] Get(string chunk, byte[] data = null)
		{
			if (data == null)
			{
				data = new byte[0];
			}
			uint length = (uint)data.Length;

			IEnumerable<byte> chunkBytes = Encoding.UTF8.GetBytes(chunk);

			var crc = new CRC32().Calc(chunkBytes.Concat(data).ToArray());

			IEnumerable<byte> bytes = new byte[0]
				.Concat(BitConverter.GetBytes(length).Reverse().ToArray())
				.Concat(chunkBytes)
				.Concat(data)
				.Concat(BitConverter.GetBytes(crc).Reverse().ToArray());

			return bytes.ToArray();
		}

		void Read_fdAT(byte[] bytes)
		{
			var img = apngImg.Last();
			var sequenceNumber = BitConverter.ToUInt32(bytes.Take(4).Reverse().ToArray(), 0);
			if (sequenceNumber != img.SequenceNumber + 1) throw new NotImplementedException();

			Read_IDAT(bytes.Skip(4).ToArray());
		}

		void Read_fcTL(byte[] bytes)
		{
			using (var ms = new MemoryStream(bytes))
			using (var br = new BinaryReader(ms))
			{

				// 高さ (4byte)
				var img = new APNGImg();
				img.SequenceNumber = BitConverter.ToUInt32(br.ReadBytes(4).Reverse().ToArray(), 0);
				img.Width = BitConverter.ToUInt32(br.ReadBytes(4).Reverse().ToArray(), 0);
				img.Height = BitConverter.ToUInt32(br.ReadBytes(4).Reverse().ToArray(), 0);
				img.XOffset = BitConverter.ToUInt32(br.ReadBytes(4).Reverse().ToArray(), 0);
				img.YOffset = BitConverter.ToUInt32(br.ReadBytes(4).Reverse().ToArray(), 0);
				img.DelayNum = BitConverter.ToUInt16(br.ReadBytes(2).Reverse().ToArray(), 0);
				img.DelayDen = BitConverter.ToUInt16(br.ReadBytes(2).Reverse().ToArray(), 0);
				img.DisposeOp = br.ReadByte();
				img.BlendOp = br.ReadByte();

				apngImg.Add(img);
			}
		}

		void Read_IEND(byte[] bytes)
		{

		}

		public void Dispose()
		{
			Dispose(true);
		}

		void Dispose(bool disposing)
		{
			if (disposed)
			{
				ImageLoadControl.Singleton.Delete(handle);
				for (int i = 0; i < apngImg?.Count; i++)
				{
					using (apngImg[i]) { }
				}

				ImageLoadControl.Singleton.Delete(screens);
				// un-managed;
			}
			disposed = true;
			// managed
		}
		~APNGImage()
		{
			Dispose();
		}
		public APNGImage(string filePath)
		{
			handle = ImageLoadControl.Singleton.Load(filePath);

			if (handle != -1)
			{
				using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (var br = new BinaryReader(fs))
				{
					#region header
					// シグネチャ (8byte)
					br.ReadBytes(8);
					#endregion

					var funcMap = new Dictionary<string, Action<byte[]>>()
				{
					{ nameof(Read_IHDR).Replace("Read_", ""), Read_IHDR },
					{ nameof(Read_acTL).Replace("Read_", ""), Read_acTL },
					{ nameof(Read_fcTL).Replace("Read_", ""), Read_fcTL },
					{ nameof(Read_IDAT).Replace("Read_", ""), Read_IDAT },
					{ nameof(Read_fdAT).Replace("Read_", ""), Read_fdAT },
					{ nameof(Read_IEND).Replace("Read_", ""), Read_IEND },
				};

					apngImg = new List<APNGImg>();

					List<string> a = new List<string>();
					while (true)
					{
						// 長さ (4byte)

						byte[] lengthBytes = br.ReadBytes(4);
						int length = BitConverter.ToInt32(lengthBytes.Reverse().ToArray(), 0);

						byte[] bytes = br.ReadBytes(length + 4);

						// ChunkType (4byte)
						string chunkType = Encoding.UTF8.GetString(bytes, 0, 4);

						byte[] crcBytes = br.ReadBytes(4);
						uint crc = BitConverter.ToUInt32(crcBytes.Reverse().ToArray(), 0);

						var crcCalc = new CRC32().Calc(bytes);

						a.Add(chunkType);

						if (funcMap.TryGetValue(chunkType, out var func))
						{
							func(bytes.Skip(4).ToArray());
						}
						else
						{
							// 補助チャンクは処理せず保持する
							subChunkData.AddRange(lengthBytes);
							subChunkData.AddRange(bytes);
							subChunkData.AddRange(crcBytes);
						}

						if (chunkType == "IEND")
						{
							break;
						}
					}



					ggg = GGG();

					CreateHandle();

					screens = new int[]
					{
					MakeScreen((int)IHDR.Width, (int)IHDR.Height, DX_TRUE),
					MakeScreen((int)IHDR.Width, (int)IHDR.Height, DX_TRUE),
					};
					return;

					#region IHDR
					{
						// 長さ (4byte)
						int length = BitConverter.ToInt32(br.ReadBytes(4).Reverse().ToArray(), 0);

						// ChunkType (4byte)
						string chunkType = Encoding.UTF8.GetString(br.ReadBytes(4));


						var crc = br.ReadBytes(4);
					}
					#endregion

					#region IDAT
					{
						// 長さ (4byte)
						int length = BitConverter.ToInt32(br.ReadBytes(4).Reverse().ToArray(), 0);

						// ChunkType (4byte)
						string chunkType = Encoding.UTF8.GetString(br.ReadBytes(4));

						//DeflateStream ds = new DeflateStream();
					}
					#endregion
				}

			}
		}
	}
}
