using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tatelier.Common
{
	/// <summary>
	/// シングルスレッドタスク
	/// </summary>
	public class STATask
	{
		static Task Run<T>(Func<T> func)
		{
			var tcs = new TaskCompletionSource<T>();
			var thread = new Thread(() =>
			{
				try
				{
					tcs.SetResult(func());
				}
				catch (Exception e)
				{
					tcs.SetException(e);
				}
			});
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			return tcs.Task;
		}

		/// <summary>
		/// タスク開始
		/// </summary>
		/// <param name="act">実行する処理</param>
		/// <returns></returns>
		public static Task Run(Action act)
		{
			return Run(() =>
			{
				act();
				return true;
			});
		}
	}
}