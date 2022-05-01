using System.Runtime.InteropServices;
namespace DxLibDLL
{
	public static partial class DX
	{
		#if WIN32
		const string DxLibDLLFileName = "DxLib.dll";
		#elif WIN64
		const string DxLibDLLFileName = "DxLib_x64.dll";
		#else
		const string DxLibDLLFileName = "DxLib.dll";
		#endif
		public const int DX_TRUE = 1;
		public const int DX_FALSE = 0;
	}
}