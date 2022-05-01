using HjsonEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score.Component.NoteSystem;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
    /// <summary>
    /// 音符画像管理クラス
    /// </summary>
    internal class NoteImageControl
		: IDisposable
	{
		bool disposed = true;

		int don = -1;
		int kat = -1;
		int donBig = -1;
		int katBig = -1;
		int roll = -1;
		int rollContent = -1;
		int rollBig = -1;
		int rollContentBig = -1;
		int balloon = -1;
		int rollEnd = -1;
		int rollBigEnd = -1;

		/// <summary>
		/// 音符画像ハンドルを取得する
		/// </summary>
		/// <param name="noteType">音符種類</param>
		/// <returns>画像ハンドル</returns>
		public int GetImageHandle(NoteType noteType)
		{
			switch (noteType)
			{
				case NoteType.Don: return don;
				case NoteType.Kat: return kat;
				case NoteType.DonBig: return donBig;
				case NoteType.KatBig: return katBig;
				case NoteType.Roll: return roll;
				case NoteType.RollBig: return rollBig;
				case NoteType.Balloon: return balloon;
				default: return -1;
			}
		}

		/// <summary>
		/// 特殊音符の開始から終了までをつなぐ音符画像ハンドルを取得する	
		/// </summary>
		/// <param name="noteType">音符種類</param>
		/// <returns>画像ハンドル</returns>
		public int GetContentNoteImageHandle(NoteType noteType)
		{
			switch (noteType)
			{
				case NoteType.Roll: return rollContent;
				case NoteType.RollBig: return rollContentBig;
				default: return -1;
			}
		}

		/// <summary>
		/// 特殊音符の終了印譜画像ハンドルを取得する
		/// </summary>
		/// <param name="noteType">音符種類</param>
		/// <returns>画像ハンドル</returns>
		public int GetEndNoteImageHandle(NoteType noteType)
		{
			switch (noteType)
			{
				case NoteType.Roll: return rollEnd;
				case NoteType.RollBig: return rollBigEnd;
				case NoteType.Balloon: return balloon;
				default: return -1;
			}
		}

		void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					// managed
				}

				var img = ImageLoadControl.Singleton;

				// unmanaged
				don = img.Delete(don);
				kat = img.Delete(kat);
				donBig = img.Delete(donBig);
				katBig = img.Delete(katBig);
				roll = img.Delete(roll);
				rollContent = img.Delete(rollContent);
				rollBig = img.Delete(rollBig);
				rollContentBig = img.Delete(rollContentBig);
				rollEnd = img.Delete(rollEnd);
				rollBigEnd = img.Delete(rollBigEnd);

				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~NoteImageControl()
		{
			Dispose();
		}

		/// <summary>
		/// 初期化(DirectXのスレッドで実行すること)
		/// </summary>
		/// <param name="folderPath"></param>
		/// <returns></returns>
		public int Init(string folderPath)
		{
			var iterator = GetInitIterator(folderPath);

			while (iterator.MoveNext())
			{
				_ = iterator.Current;
			}

			return 0;
		}

		/// <summary>
		/// 初期化イテレーター
		/// </summary>
		/// <param name="folderPath">フォルダパス</param>
		/// <returns>イテレーター</returns>
		public IEnumerator GetInitIterator(string folderPath)
		{
			float result = 0.0F;
			float diff = 1.0F / 11;

			if (!disposed)
			{
				Dispose();
				disposed = false;
			}

			var img = ImageLoadControl.Singleton;
			don = img.Load(Path.Combine(folderPath, "Don.png"));
			kat = img.Load(Path.Combine(folderPath, "Kat.png"));
			result += diff * 2;
			yield return result;

			donBig = img.Load(Path.Combine(folderPath, "DonBig.png"));
			katBig = img.Load(Path.Combine(folderPath, "KatBig.png"));
			result += diff * 2;
			yield return result;

			balloon = img.Load(Path.Combine(folderPath, "Balloon.png"));
			roll = img.Load(Path.Combine(folderPath, "Roll.png"));
			result += diff * 2;
			yield return result;

			rollContent = img.Load(Path.Combine(folderPath, "RollContent.png"));
			rollEnd = img.Load(Path.Combine(folderPath, "RollEnd.png"));
			result += diff * 2;
			yield return result;

			rollBig = img.Load(Path.Combine(folderPath, "RollBig.png"));
			rollContentBig = img.Load(Path.Combine(folderPath, "RollContentBig.png"));
			result += diff * 2;
			yield return result;

			rollBigEnd = img.Load(Path.Combine(folderPath, "RollEndBig.png"));

			yield return 1;
		}

		public NoteImageControl()
		{

		}


		public NoteImageControl(string folderPath, Hjson.JsonValue json)
		{
			var img = ImageLoadControl.Singleton;

			if (json == null)
			{
				json = HjsonEx.Empty.Value;
			}

			folderPath = Path.Combine(folderPath, json.EQs("FolderPath") ?? "Note");

			don = img.Load(Path.Combine(folderPath, "Don.png"));
			kat = img.Load(Path.Combine(folderPath, "Kat.png"));
			donBig = img.Load(Path.Combine(folderPath, "DonBig.png"));
			katBig = img.Load(Path.Combine(folderPath, "KatBig.png"));
			balloon = img.Load(Path.Combine(folderPath, "Balloon.png"));
			roll = img.Load(Path.Combine(folderPath, "Roll.png"));
			rollContent = img.Load(Path.Combine(folderPath, "RollContent.png"));
			rollEnd = img.Load(Path.Combine(folderPath, "RollEnd.png"));
			rollBig = img.Load(Path.Combine(folderPath, "RollBig.png"));
			rollContentBig = img.Load(Path.Combine(folderPath, "RollContentBig.png"));
			rollBigEnd = img.Load(Path.Combine(folderPath, "RollEndBig.png"));
		}
	}
}
