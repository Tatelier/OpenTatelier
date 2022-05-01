using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Tatelier
{
	public class ErrorItem
	{
		public uint Code = 0x80010001;

		public string[] ErrorTextArgs;

		public override string ToString()
		{
			return $"エラーコード:0x{Code:X8}\n";
		}
	}


	public class Error : ThreadLocal<List<ErrorItem>>
	{
		public const uint CODE_DXLIB_INIT_FAILURE = 0x40000001;
		public const uint CODE_DXLIB_CALL_RESTORE = 0x40000002;

		public const uint CODE_404_MAINCONFIG_HJSON = 0x80000001;
		public const uint CODE_VERSION_COMPARE_FAILURE = 0x80000002;

		public const uint CODE_404_SCORE_HJSON = 0x80010001;
		public const uint CODE_GENRE_DUPLICATE = 0x80010002;
		public const uint CODE_SCORE_EXCEPTION = 0x8001FFFF;

		public const uint CODE_404_THEME_HJSON = 0x80020001;


		static Error instance;

		/// <summary>
		/// エラーリスト
		/// </summary>
		public static List<ErrorItem> List => instance.Value;

		public static void Clear()
		{
			instance.Value.Clear();
		}

		public static void Add(ErrorItem item)
		{
			instance.Value.Add(item);
		}

		public static void Add(uint code)
		{
			instance.Value.Add(new ErrorItem()
			{
				Code = code
			});
		}

		/// <summary>
		/// エラー有無
		/// </summary>
		public static bool HasError => instance.Value.Any();

		public static void OpenDetailFirstPage()
		{
			if (!(List?.Any() ?? false))
			{
				return;
			}
			string errorCodeFolder = "https://github.com/Tatelier/Tatelier/blob/master/Manual/ErrorCode";
			var first = List.First();
			string parentFolder = $"0x{(first.Code & 0xFFFF0000) / 0x00010000:X4}0000-0x{(first.Code & 0xFFFF0000) / 0x00010000:X4}FFFF";
			System.Diagnostics.Process.Start($"{errorCodeFolder}/{parentFolder}/0x{first.Code:X8}.adoc");
		}

		Error() : base(() => new List<ErrorItem>())
		{
		}

		static Error()
		{
			instance = new Error();
		}
	}
}