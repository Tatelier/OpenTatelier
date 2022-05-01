using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier
{
	/// <summary>
	/// 画像ロード管理クラス
	/// </summary>
	class ImageLoadControl : LoadControlBase
	{
		public static ImageLoadControl Singleton { get; private set; } = new ImageLoadControl();

		public static void Reset()
		{
            if (Singleton != null)
            {
				Supervision.Singleton.Engine.ImageLoadControl.Reset();
			}
			Singleton = new ImageLoadControl();
		}

		Dictionary<int, Action<int, int>> asyncHandleManageMap = new Dictionary<int, Action<int, int>>();
		List<int> manageMapRemoveValueList = new List<int>(64);

		/// <summary>
		/// 画像を読み込みます。
		/// </summary>
		/// <param name="folder"></param>
		/// <param name="extensions">拡張子 例】".png"</param>
		/// <returns></returns>
		public int[] LoadNumbers(string folder, string extensions)
		{
			int[] array = new int[10];

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Load(Path.Combine(folder, $"{i}{extensions}"));
			}

			return array;
		}

		/// <summary>
		/// 画像を読み込みます。既存データがある場合は使いまわします。
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>ハンドル</returns>
		public int Load(string filePath)
		{
			filePath = filePath.Replace('/', '\\');

			return Supervision.Singleton.Engine.ImageLoadControl.Load(filePath);
		}

		public void Update()
		{
			foreach (var key in asyncHandleManageMap.Keys)
			{
				if(CheckHandleASyncLoad(key) == DX_TRUE)
				{
					asyncHandleManageMap[key](0, key);
					manageMapRemoveValueList.Add(key);
				}
			}

			foreach (var item in manageMapRemoveValueList)
			{
				asyncHandleManageMap.Remove(item);
			}

			manageMapRemoveValueList.Clear();
		}

		/// <summary>
		/// 画像を削除します。既存のデータが使われている場合は削除しません。
		/// </summary>
		/// <param name="handle">ハンドル</param>
		/// <returns>0:使用中のため未削除, 1:削除, -1:存在しない</returns>
		public int Delete(int handle)
		{
			return Supervision.Singleton.Engine.ImageLoadControl.Delete(handle);
		}

		/// <summary>
		/// 画像ハンドルの配列を削除します。
		/// </summary>
		/// <param name="handles"></param>
		/// <returns>TODO</returns>
		public int Delete(IEnumerable<int> handles)
		{
			if (handles == null) return 0;
			foreach(var handle in handles)
			{
				Delete(handle);
			}
			return 0;
		}
	}
}
