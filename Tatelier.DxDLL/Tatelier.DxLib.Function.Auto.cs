using System.Runtime.InteropServices;
namespace DxLibDLL
{
	public static partial class DX
	{
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxLib_Init", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DxLib_Init();
		public static int DxLib_Init() => dx_DxLib_Init();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxLib_End", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DxLib_End();
		public static int DxLib_End() => dx_DxLib_End();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxLib_GlobalStructInitialize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DxLib_GlobalStructInitialize();
		public static int DxLib_GlobalStructInitialize() => dx_DxLib_GlobalStructInitialize();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxLib_IsInit", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DxLib_IsInit();
		public static int DxLib_IsInit() => dx_DxLib_IsInit();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLastErrorCode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLastErrorCode();
		public static int GetLastErrorCode() => dx_GetLastErrorCode();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLastErrorMessage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLastErrorMessage(System.Text.StringBuilder StringBuffer, int StringBufferBytes);
		public static int GetLastErrorMessage(System.Text.StringBuilder StringBuffer, int StringBufferBytes) => dx_GetLastErrorMessage(StringBuffer, StringBufferBytes);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ProcessMessage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ProcessMessage();
		public static int ProcessMessage() => dx_ProcessMessage();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetAlwaysRunFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetAlwaysRunFlag(int Flag);
		public static int SetAlwaysRunFlag(int Flag) => dx_SetAlwaysRunFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_WaitTimer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_WaitTimer(int WaitTime);
		public static int WaitTimer(int WaitTime) => dx_WaitTimer(WaitTime);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_WaitKey", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_WaitKey();
		public static int WaitKey() => dx_WaitKey();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetNowCount", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetNowCount(int UseRDTSCFlag);
		public static int GetNowCount(int UseRDTSCFlag = FALSE) => dx_GetNowCount(UseRDTSCFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetNowHiPerformanceCount", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_GetNowHiPerformanceCount(int UseRDTSCFlag);
		public static long GetNowHiPerformanceCount(int UseRDTSCFlag = FALSE) => dx_GetNowHiPerformanceCount(UseRDTSCFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetNowSysPerformanceCount", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_GetNowSysPerformanceCount();
		public static ulong GetNowSysPerformanceCount() => dx_GetNowSysPerformanceCount();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetSysPerformanceFrequency", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_GetSysPerformanceFrequency();
		public static ulong GetSysPerformanceFrequency() => dx_GetSysPerformanceFrequency();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvSysPerformanceCountToSeconds", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_ConvSysPerformanceCountToSeconds(ulong Count);
		public static ulong ConvSysPerformanceCountToSeconds(ulong Count) => dx_ConvSysPerformanceCountToSeconds(Count);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvSysPerformanceCountToMilliSeconds", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_ConvSysPerformanceCountToMilliSeconds(ulong Count);
		public static ulong ConvSysPerformanceCountToMilliSeconds(ulong Count) => dx_ConvSysPerformanceCountToMilliSeconds(Count);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvSysPerformanceCountToMicroSeconds", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_ConvSysPerformanceCountToMicroSeconds(ulong Count);
		public static ulong ConvSysPerformanceCountToMicroSeconds(ulong Count) => dx_ConvSysPerformanceCountToMicroSeconds(Count);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvSysPerformanceCountToNanoSeconds", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_ConvSysPerformanceCountToNanoSeconds(ulong Count);
		public static ulong ConvSysPerformanceCountToNanoSeconds(ulong Count) => dx_ConvSysPerformanceCountToNanoSeconds(Count);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvSecondsToSysPerformanceCount", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_ConvSecondsToSysPerformanceCount(ulong Seconds);
		public static ulong ConvSecondsToSysPerformanceCount(ulong Seconds) => dx_ConvSecondsToSysPerformanceCount(Seconds);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvMilliSecondsToSysPerformanceCount", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_ConvMilliSecondsToSysPerformanceCount(ulong MilliSeconds);
		public static ulong ConvMilliSecondsToSysPerformanceCount(ulong MilliSeconds) => dx_ConvMilliSecondsToSysPerformanceCount(MilliSeconds);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvMicroSecondsToSysPerformanceCount", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_ConvMicroSecondsToSysPerformanceCount(ulong MicroSeconds);
		public static ulong ConvMicroSecondsToSysPerformanceCount(ulong MicroSeconds) => dx_ConvMicroSecondsToSysPerformanceCount(MicroSeconds);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvNanoSecondsToSysPerformanceCount", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_ConvNanoSecondsToSysPerformanceCount(ulong NanoSeconds);
		public static ulong ConvNanoSecondsToSysPerformanceCount(ulong NanoSeconds) => dx_ConvNanoSecondsToSysPerformanceCount(NanoSeconds);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDateTime", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDateTime(out DATEDATA DateBuf);
		public static int GetDateTime(out DATEDATA DateBuf) => dx_GetDateTime(out DateBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetRand", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetRand(int RandMax);
		public static int GetRand(int RandMax) => dx_GetRand(RandMax);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SRand", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SRand(int Seed);
		public static int SRand(int Seed) => dx_SRand(Seed);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetBatteryLifePercent", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetBatteryLifePercent();
		public static int GetBatteryLifePercent() => dx_GetBatteryLifePercent();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetClipboardText", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetClipboardText(System.Text.StringBuilder DestBuffer);
		public static int GetClipboardText(System.Text.StringBuilder DestBuffer) => dx_GetClipboardText(DestBuffer);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetClipboardText", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetClipboardText(string Text);
		public static int SetClipboardText(string Text) => dx_SetClipboardText(Text);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetClipboardTextWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetClipboardTextWithStrLen(string Text, ulong TextLength);
		public static int SetClipboardTextWithStrLen(string Text, ulong TextLength) => dx_SetClipboardTextWithStrLen(Text, TextLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPrivateProfileStringDx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPrivateProfileStringDx(string AppName, string KeyName, string Default, System.Text.StringBuilder ReturnedStringBuffer, ulong ReturnedStringBufferBytes, string IniFilePath, int IniFileCharCodeFormat);
		public static int GetPrivateProfileStringDx(string AppName, string KeyName, string Default, System.Text.StringBuilder ReturnedStringBuffer, ulong ReturnedStringBufferBytes, string IniFilePath, int IniFileCharCodeFormat = -1) => dx_GetPrivateProfileStringDx(AppName, KeyName, Default, ReturnedStringBuffer, ReturnedStringBufferBytes, IniFilePath, IniFileCharCodeFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPrivateProfileStringDxWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPrivateProfileStringDxWithStrLen(string AppName, ulong AppNameLength, string KeyName, ulong KeyNameLength, string Default, ulong DefaultLength, System.Text.StringBuilder ReturnedStringBuffer, ulong ReturnedStringBufferBytes, string IniFilePath, ulong IniFilePathLength, int IniFileCharCodeFormat);
		public static int GetPrivateProfileStringDxWithStrLen(string AppName, ulong AppNameLength, string KeyName, ulong KeyNameLength, string Default, ulong DefaultLength, System.Text.StringBuilder ReturnedStringBuffer, ulong ReturnedStringBufferBytes, string IniFilePath, ulong IniFilePathLength, int IniFileCharCodeFormat = -1) => dx_GetPrivateProfileStringDxWithStrLen(AppName, AppNameLength, KeyName, KeyNameLength, Default, DefaultLength, ReturnedStringBuffer, ReturnedStringBufferBytes, IniFilePath, IniFilePathLength, IniFileCharCodeFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPrivateProfileIntDx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPrivateProfileIntDx(string AppName, string KeyName, int Default, string IniFilePath, int IniFileCharCodeFormat);
		public static int GetPrivateProfileIntDx(string AppName, string KeyName, int Default, string IniFilePath, int IniFileCharCodeFormat = -1) => dx_GetPrivateProfileIntDx(AppName, KeyName, Default, IniFilePath, IniFileCharCodeFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPrivateProfileIntDxWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPrivateProfileIntDxWithStrLen(string AppName, ulong AppNameLength, string KeyName, ulong KeyNameLength, int Default, string IniFilePath, ulong IniFilePathLength, int IniFileCharCodeFormat);
		public static int GetPrivateProfileIntDxWithStrLen(string AppName, ulong AppNameLength, string KeyName, ulong KeyNameLength, int Default, string IniFilePath, ulong IniFilePathLength, int IniFileCharCodeFormat = -1) => dx_GetPrivateProfileIntDxWithStrLen(AppName, AppNameLength, KeyName, KeyNameLength, Default, IniFilePath, IniFilePathLength, IniFileCharCodeFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPrivateProfileStringDxForMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPrivateProfileStringDxForMem(string AppName, string KeyName, string Default, System.Text.StringBuilder ReturnedStringBuffer, ulong ReturnedStringBufferBytes, System.IntPtr IniFileImage, ulong IniFileImageBytes, int IniFileCharCodeFormat);
		public static int GetPrivateProfileStringDxForMem(string AppName, string KeyName, string Default, System.Text.StringBuilder ReturnedStringBuffer, ulong ReturnedStringBufferBytes, System.IntPtr IniFileImage, ulong IniFileImageBytes, int IniFileCharCodeFormat = -1) => dx_GetPrivateProfileStringDxForMem(AppName, KeyName, Default, ReturnedStringBuffer, ReturnedStringBufferBytes, IniFileImage, IniFileImageBytes, IniFileCharCodeFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPrivateProfileStringDxForMemWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPrivateProfileStringDxForMemWithStrLen(string AppName, ulong AppNameLength, string KeyName, ulong KeyNameLength, string Default, ulong DefaultLength, System.Text.StringBuilder ReturnedStringBuffer, ulong ReturnedStringBufferBytes, System.IntPtr IniFileImage, ulong IniFileImageBytes, int IniFileCharCodeFormat);
		public static int GetPrivateProfileStringDxForMemWithStrLen(string AppName, ulong AppNameLength, string KeyName, ulong KeyNameLength, string Default, ulong DefaultLength, System.Text.StringBuilder ReturnedStringBuffer, ulong ReturnedStringBufferBytes, System.IntPtr IniFileImage, ulong IniFileImageBytes, int IniFileCharCodeFormat = -1) => dx_GetPrivateProfileStringDxForMemWithStrLen(AppName, AppNameLength, KeyName, KeyNameLength, Default, DefaultLength, ReturnedStringBuffer, ReturnedStringBufferBytes, IniFileImage, IniFileImageBytes, IniFileCharCodeFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPrivateProfileIntDxForMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPrivateProfileIntDxForMem(string AppName, string KeyName, int Default, System.IntPtr IniFileImage, ulong IniFileImageBytes, int IniFileCharCodeFormat);
		public static int GetPrivateProfileIntDxForMem(string AppName, string KeyName, int Default, System.IntPtr IniFileImage, ulong IniFileImageBytes, int IniFileCharCodeFormat = -1) => dx_GetPrivateProfileIntDxForMem(AppName, KeyName, Default, IniFileImage, IniFileImageBytes, IniFileCharCodeFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPrivateProfileIntDxForMemWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPrivateProfileIntDxForMemWithStrLen(string AppName, ulong AppNameLength, string KeyName, ulong KeyNameLength, int Default, System.IntPtr IniFileImage, ulong IniFileImageBytes, int IniFileCharCodeFormat);
		public static int GetPrivateProfileIntDxForMemWithStrLen(string AppName, ulong AppNameLength, string KeyName, ulong KeyNameLength, int Default, System.IntPtr IniFileImage, ulong IniFileImageBytes, int IniFileCharCodeFormat = -1) => dx_GetPrivateProfileIntDxForMemWithStrLen(AppName, AppNameLength, KeyName, KeyNameLength, Default, IniFileImage, IniFileImageBytes, IniFileCharCodeFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LogFileAdd", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LogFileAdd(string String);
		public static int LogFileAdd(string String) => dx_LogFileAdd(String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LogFileAddWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LogFileAddWithStrLen(string String, ulong StringLength);
		public static int LogFileAddWithStrLen(string String, ulong StringLength) => dx_LogFileAddWithStrLen(String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LogFileFmtAdd", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LogFileFmtAdd(string FormatString);
		public static int LogFileFmtAdd(string FormatString) => dx_LogFileFmtAdd(FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LogFileTabAdd", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LogFileTabAdd();
		public static int LogFileTabAdd() => dx_LogFileTabAdd();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LogFileTabSub", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LogFileTabSub();
		public static int LogFileTabSub() => dx_LogFileTabSub();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ErrorLogAdd", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ErrorLogAdd(string String);
		public static int ErrorLogAdd(string String) => dx_ErrorLogAdd(String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ErrorLogFmtAdd", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ErrorLogFmtAdd(string FormatString);
		public static int ErrorLogFmtAdd(string FormatString) => dx_ErrorLogFmtAdd(FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ErrorLogTabAdd", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ErrorLogTabAdd();
		public static int ErrorLogTabAdd() => dx_ErrorLogTabAdd();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ErrorLogTabSub", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ErrorLogTabSub();
		public static int ErrorLogTabSub() => dx_ErrorLogTabSub();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseTimeStampFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseTimeStampFlag(int UseFlag);
		public static int SetUseTimeStampFlag(int UseFlag) => dx_SetUseTimeStampFlag(UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AppLogAdd", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AppLogAdd(string String);
		public static int AppLogAdd(string String) => dx_AppLogAdd(String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetOutApplicationLogValidFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetOutApplicationLogValidFlag(int Flag);
		public static int SetOutApplicationLogValidFlag(int Flag) => dx_SetOutApplicationLogValidFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetApplicationLogFileName", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetApplicationLogFileName(string FileName);
		public static int SetApplicationLogFileName(string FileName) => dx_SetApplicationLogFileName(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetApplicationLogFileNameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetApplicationLogFileNameWithStrLen(string FileName, ulong FileNameLength);
		public static int SetApplicationLogFileNameWithStrLen(string FileName, ulong FileNameLength) => dx_SetApplicationLogFileNameWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetApplicationLogSaveDirectory", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetApplicationLogSaveDirectory(string DirectoryPath);
		public static int SetApplicationLogSaveDirectory(string DirectoryPath) => dx_SetApplicationLogSaveDirectory(DirectoryPath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetApplicationLogSaveDirectoryWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetApplicationLogSaveDirectoryWithStrLen(string DirectoryPath, ulong DirectoryPathLength);
		public static int SetApplicationLogSaveDirectoryWithStrLen(string DirectoryPath, ulong DirectoryPathLength) => dx_SetApplicationLogSaveDirectoryWithStrLen(DirectoryPath, DirectoryPathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDateNameLogFile", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDateNameLogFile(int Flag);
		public static int SetUseDateNameLogFile(int Flag) => dx_SetUseDateNameLogFile(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLogDrawOutFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLogDrawOutFlag(int DrawFlag);
		public static int SetLogDrawOutFlag(int DrawFlag) => dx_SetLogDrawOutFlag(DrawFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLogDrawFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLogDrawFlag();
		public static int GetLogDrawFlag() => dx_GetLogDrawFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLogFontSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLogFontSize(int Size);
		public static int SetLogFontSize(int Size) => dx_SetLogFontSize(Size);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLogFontHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLogFontHandle(int FontHandle);
		public static int SetLogFontHandle(int FontHandle) => dx_SetLogFontHandle(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLogDrawArea", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLogDrawArea(int x1, int y1, int x2, int y2);
		public static int SetLogDrawArea(int x1, int y1, int x2, int y2) => dx_SetLogDrawArea(x1, y1, x2, y2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_printfDx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_printfDx(string FormatString);
		public static int printfDx(string FormatString) => dx_printfDx(FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_putsDx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_putsDx(string String, int NewLine);
		public static int putsDx(string String, int NewLine = TRUE) => dx_putsDx(String, NewLine);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_putsDxWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_putsDxWithStrLen(string String, ulong StringLength, int NewLine);
		public static int putsDxWithStrLen(string String, ulong StringLength, int NewLine = TRUE) => dx_putsDxWithStrLen(String, StringLength, NewLine);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_clsDx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_clsDx();
		public static int clsDx() => dx_clsDx();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseASyncLoadFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseASyncLoadFlag(int Flag);
		public static int SetUseASyncLoadFlag(int Flag) => dx_SetUseASyncLoadFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseASyncLoadFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseASyncLoadFlag();
		public static int GetUseASyncLoadFlag() => dx_GetUseASyncLoadFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckHandleASyncLoad", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckHandleASyncLoad(int Handle);
		public static int CheckHandleASyncLoad(int Handle) => dx_CheckHandleASyncLoad(Handle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetHandleASyncLoadResult", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetHandleASyncLoadResult(int Handle);
		public static int GetHandleASyncLoadResult(int Handle) => dx_GetHandleASyncLoadResult(Handle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetASyncLoadFinishDeleteFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetASyncLoadFinishDeleteFlag(int Handle);
		public static int SetASyncLoadFinishDeleteFlag(int Handle) => dx_SetASyncLoadFinishDeleteFlag(Handle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetASyncLoadNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetASyncLoadNum();
		public static int GetASyncLoadNum() => dx_GetASyncLoadNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetASyncLoadThreadNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetASyncLoadThreadNum(int ThreadNum);
		public static int SetASyncLoadThreadNum(int ThreadNum) => dx_SetASyncLoadThreadNum(ThreadNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDeleteHandleFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDeleteHandleFlag(int Handle, out int DeleteFlag);
		public static int SetDeleteHandleFlag(int Handle, out int DeleteFlag) => dx_SetDeleteHandleFlag(Handle, out DeleteFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMouseDispFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMouseDispFlag(int DispFlag);
		public static int SetMouseDispFlag(int DispFlag) => dx_SetMouseDispFlag(DispFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMousePoint", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMousePoint(out int XBuf, out int YBuf);
		public static int GetMousePoint(out int XBuf, out int YBuf) => dx_GetMousePoint(out XBuf, out YBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMousePoint", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMousePoint(int PointX, int PointY);
		public static int SetMousePoint(int PointX, int PointY) => dx_SetMousePoint(PointX, PointY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMouseInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMouseInput();
		public static int GetMouseInput() => dx_GetMouseInput();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMouseWheelRotVol", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMouseWheelRotVol(int CounterReset);
		public static int GetMouseWheelRotVol(int CounterReset = TRUE) => dx_GetMouseWheelRotVol(CounterReset);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMouseHWheelRotVol", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMouseHWheelRotVol(int CounterReset);
		public static int GetMouseHWheelRotVol(int CounterReset = TRUE) => dx_GetMouseHWheelRotVol(CounterReset);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMouseWheelRotVolF", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetMouseWheelRotVolF(int CounterReset);
		public static float GetMouseWheelRotVolF(int CounterReset = TRUE) => dx_GetMouseWheelRotVolF(CounterReset);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMouseHWheelRotVolF", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetMouseHWheelRotVolF(int CounterReset);
		public static float GetMouseHWheelRotVolF(int CounterReset = TRUE) => dx_GetMouseHWheelRotVolF(CounterReset);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMouseInputLog", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMouseInputLog(out int Button, out int ClickX, out int ClickY, int LogDelete);
		public static int GetMouseInputLog(out int Button, out int ClickX, out int ClickY, int LogDelete = TRUE) => dx_GetMouseInputLog(out Button, out ClickX, out ClickY, LogDelete);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMouseInputLog2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMouseInputLog2(out int Button, out int ClickX, out int ClickY, out int LogType, int LogDelete);
		public static int GetMouseInputLog2(out int Button, out int ClickX, out int ClickY, out int LogType, int LogDelete = TRUE) => dx_GetMouseInputLog2(out Button, out ClickX, out ClickY, out LogType, LogDelete);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTouchInputNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTouchInputNum();
		public static int GetTouchInputNum() => dx_GetTouchInputNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTouchInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTouchInput(int InputNo, out int PositionX, out int PositionY, out int ID, out int Device);
		public static int GetTouchInput(int InputNo, out int PositionX, out int PositionY, out int ID, out int Device) => dx_GetTouchInput(InputNo, out PositionX, out PositionY, out ID, out Device);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTouchInputLogNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTouchInputLogNum();
		public static int GetTouchInputLogNum() => dx_GetTouchInputLogNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ClearTouchInputLog", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ClearTouchInputLog();
		public static int ClearTouchInputLog() => dx_ClearTouchInputLog();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTouchInputLogOne", CallingConvention=CallingConvention.StdCall)]
		extern static TOUCHINPUTDATA dx_GetTouchInputLogOne(int PeekFlag);
		public static TOUCHINPUTDATA GetTouchInputLogOne(int PeekFlag = FALSE) => dx_GetTouchInputLogOne(PeekFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTouchInputLog", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTouchInputLog(out TOUCHINPUTDATA TouchData, int GetNum, int PeekFlag);
		public static int GetTouchInputLog(out TOUCHINPUTDATA TouchData, int GetNum, int PeekFlag = FALSE) => dx_GetTouchInputLog(out TouchData, GetNum, PeekFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTouchInputDownLogNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTouchInputDownLogNum();
		public static int GetTouchInputDownLogNum() => dx_GetTouchInputDownLogNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ClearTouchInputDownLog", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ClearTouchInputDownLog();
		public static int ClearTouchInputDownLog() => dx_ClearTouchInputDownLog();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTouchInputDownLogOne", CallingConvention=CallingConvention.StdCall)]
		extern static TOUCHINPUTPOINT dx_GetTouchInputDownLogOne(int PeekFlag);
		public static TOUCHINPUTPOINT GetTouchInputDownLogOne(int PeekFlag = FALSE) => dx_GetTouchInputDownLogOne(PeekFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTouchInputDownLog", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTouchInputDownLog(out TOUCHINPUTPOINT PointData, int GetNum, int PeekFlag);
		public static int GetTouchInputDownLog(out TOUCHINPUTPOINT PointData, int GetNum, int PeekFlag = FALSE) => dx_GetTouchInputDownLog(out PointData, GetNum, PeekFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTouchInputUpLogNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTouchInputUpLogNum();
		public static int GetTouchInputUpLogNum() => dx_GetTouchInputUpLogNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ClearTouchInputUpLog", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ClearTouchInputUpLog();
		public static int ClearTouchInputUpLog() => dx_ClearTouchInputUpLog();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTouchInputUpLogOne", CallingConvention=CallingConvention.StdCall)]
		extern static TOUCHINPUTPOINT dx_GetTouchInputUpLogOne(int PeekFlag);
		public static TOUCHINPUTPOINT GetTouchInputUpLogOne(int PeekFlag = FALSE) => dx_GetTouchInputUpLogOne(PeekFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTouchInputUpLog", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTouchInputUpLog(out TOUCHINPUTPOINT PointData, int GetNum, int PeekFlag);
		public static int GetTouchInputUpLog(out TOUCHINPUTPOINT PointData, int GetNum, int PeekFlag = FALSE) => dx_GetTouchInputUpLog(out PointData, GetNum, PeekFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxAlloc", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_DxAlloc(ulong AllocSize, uint File, int Line);
		public static System.IntPtr DxAlloc(ulong AllocSize, uint File = 0, int Line = -1) => dx_DxAlloc(AllocSize, File, Line);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxAllocAligned", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_DxAllocAligned(ulong AllocSize, ulong Alignment, uint File, int Line);
		public static System.IntPtr DxAllocAligned(ulong AllocSize, ulong Alignment, uint File = 0, int Line = -1) => dx_DxAllocAligned(AllocSize, Alignment, File, Line);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxCalloc", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_DxCalloc(ulong AllocSize, uint File, int Line);
		public static System.IntPtr DxCalloc(ulong AllocSize, uint File = 0, int Line = -1) => dx_DxCalloc(AllocSize, File, Line);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxCallocAligned", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_DxCallocAligned(ulong AllocSize, ulong Alignment, uint File, int Line);
		public static System.IntPtr DxCallocAligned(ulong AllocSize, ulong Alignment, uint File = 0, int Line = -1) => dx_DxCallocAligned(AllocSize, Alignment, File, Line);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxRealloc", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_DxRealloc(System.IntPtr Memory, ulong AllocSize, uint File, int Line);
		public static System.IntPtr DxRealloc(System.IntPtr Memory, ulong AllocSize, uint File = 0, int Line = -1) => dx_DxRealloc(Memory, AllocSize, File, Line);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxReallocAligned", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_DxReallocAligned(System.IntPtr Memory, ulong AllocSize, ulong Alignment, uint File, int Line);
		public static System.IntPtr DxReallocAligned(System.IntPtr Memory, ulong AllocSize, ulong Alignment, uint File = 0, int Line = -1) => dx_DxReallocAligned(Memory, AllocSize, Alignment, File, Line);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxFree", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_DxFree(System.IntPtr Memory);
		public static void DxFree(System.IntPtr Memory) => dx_DxFree(Memory);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxSetAllocSizeTrap", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_DxSetAllocSizeTrap(ulong Size);
		public static ulong DxSetAllocSizeTrap(ulong Size) => dx_DxSetAllocSizeTrap(Size);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxSetAllocPrintFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DxSetAllocPrintFlag(int Flag);
		public static int DxSetAllocPrintFlag(int Flag) => dx_DxSetAllocPrintFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxGetAllocSize", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_DxGetAllocSize();
		public static ulong DxGetAllocSize() => dx_DxGetAllocSize();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxGetAllocNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DxGetAllocNum();
		public static int DxGetAllocNum() => dx_DxGetAllocNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxDumpAlloc", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_DxDumpAlloc();
		public static void DxDumpAlloc() => dx_DxDumpAlloc();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxDrawAlloc", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_DxDrawAlloc(int x, int y, int Width, int Height);
		public static void DxDrawAlloc(int x, int y, int Width, int Height) => dx_DxDrawAlloc(x, y, Width, Height);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxErrorCheckAlloc", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DxErrorCheckAlloc();
		public static int DxErrorCheckAlloc() => dx_DxErrorCheckAlloc();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxSetAllocSizeOutFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DxSetAllocSizeOutFlag(int Flag);
		public static int DxSetAllocSizeOutFlag(int Flag) => dx_DxSetAllocSizeOutFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DxSetAllocMemoryErrorCheckFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DxSetAllocMemoryErrorCheckFlag(int Flag);
		public static int DxSetAllocMemoryErrorCheckFlag(int Flag) => dx_DxSetAllocMemoryErrorCheckFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCharBytes", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCharBytes(int CharCodeFormat, System.IntPtr String);
		public static int GetCharBytes(int CharCodeFormat, System.IntPtr String) => dx_GetCharBytes(CharCodeFormat, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvertStringCharCodeFormat", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ConvertStringCharCodeFormat(int SrcCharCodeFormat, System.IntPtr SrcString, int DestCharCodeFormat, System.IntPtr DestStringBuffer);
		public static int ConvertStringCharCodeFormat(int SrcCharCodeFormat, System.IntPtr SrcString, int DestCharCodeFormat, System.IntPtr DestStringBuffer) => dx_ConvertStringCharCodeFormat(SrcCharCodeFormat, SrcString, DestCharCodeFormat, DestStringBuffer);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseCharCodeFormat", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseCharCodeFormat(int CharCodeFormat);
		public static int SetUseCharCodeFormat(int CharCodeFormat) => dx_SetUseCharCodeFormat(CharCodeFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseCharCodeFormat", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseCharCodeFormat();
		public static int GetUseCharCodeFormat() => dx_GetUseCharCodeFormat();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Get_wchar_t_CharCodeFormat", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Get_wchar_t_CharCodeFormat();
		public static int Get_wchar_t_CharCodeFormat() => dx_Get_wchar_t_CharCodeFormat();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strcpyDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strcpyDx(System.Text.StringBuilder Dest, string Src);
		public static void strcpyDx(System.Text.StringBuilder Dest, string Src) => dx_strcpyDx(Dest, Src);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strcpy_sDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strcpy_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src);
		public static void strcpy_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src) => dx_strcpy_sDx(Dest, DestBytes, Src);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strpcpyDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strpcpyDx(System.Text.StringBuilder Dest, string Src, int Pos);
		public static void strpcpyDx(System.Text.StringBuilder Dest, string Src, int Pos) => dx_strpcpyDx(Dest, Src, Pos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strpcpy_sDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strpcpy_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Pos);
		public static void strpcpy_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Pos) => dx_strpcpy_sDx(Dest, DestBytes, Src, Pos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strpcpy2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strpcpy2Dx(System.Text.StringBuilder Dest, string Src, int Pos);
		public static void strpcpy2Dx(System.Text.StringBuilder Dest, string Src, int Pos) => dx_strpcpy2Dx(Dest, Src, Pos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strpcpy2_sDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strpcpy2_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Pos);
		public static void strpcpy2_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Pos) => dx_strpcpy2_sDx(Dest, DestBytes, Src, Pos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strncpyDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strncpyDx(System.Text.StringBuilder Dest, string Src, int Num);
		public static void strncpyDx(System.Text.StringBuilder Dest, string Src, int Num) => dx_strncpyDx(Dest, Src, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strncpy_sDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strncpy_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Num);
		public static void strncpy_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Num) => dx_strncpy_sDx(Dest, DestBytes, Src, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strncpy2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strncpy2Dx(System.Text.StringBuilder Dest, string Src, int Num);
		public static void strncpy2Dx(System.Text.StringBuilder Dest, string Src, int Num) => dx_strncpy2Dx(Dest, Src, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strncpy2_sDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strncpy2_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Num);
		public static void strncpy2_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Num) => dx_strncpy2_sDx(Dest, DestBytes, Src, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strrncpyDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strrncpyDx(System.Text.StringBuilder Dest, string Src, int Num);
		public static void strrncpyDx(System.Text.StringBuilder Dest, string Src, int Num) => dx_strrncpyDx(Dest, Src, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strrncpy_sDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strrncpy_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Num);
		public static void strrncpy_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Num) => dx_strrncpy_sDx(Dest, DestBytes, Src, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strrncpy2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strrncpy2Dx(System.Text.StringBuilder Dest, string Src, int Num);
		public static void strrncpy2Dx(System.Text.StringBuilder Dest, string Src, int Num) => dx_strrncpy2Dx(Dest, Src, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strrncpy2_sDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strrncpy2_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Num);
		public static void strrncpy2_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Num) => dx_strrncpy2_sDx(Dest, DestBytes, Src, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strpncpyDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strpncpyDx(System.Text.StringBuilder Dest, string Src, int Pos, int Num);
		public static void strpncpyDx(System.Text.StringBuilder Dest, string Src, int Pos, int Num) => dx_strpncpyDx(Dest, Src, Pos, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strpncpy_sDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strpncpy_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Pos, int Num);
		public static void strpncpy_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Pos, int Num) => dx_strpncpy_sDx(Dest, DestBytes, Src, Pos, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strpncpy2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strpncpy2Dx(System.Text.StringBuilder Dest, string Src, int Pos, int Num);
		public static void strpncpy2Dx(System.Text.StringBuilder Dest, string Src, int Pos, int Num) => dx_strpncpy2Dx(Dest, Src, Pos, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strpncpy2_sDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strpncpy2_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Pos, int Num);
		public static void strpncpy2_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src, int Pos, int Num) => dx_strpncpy2_sDx(Dest, DestBytes, Src, Pos, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strcatDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strcatDx(System.Text.StringBuilder Dest, string Src);
		public static void strcatDx(System.Text.StringBuilder Dest, string Src) => dx_strcatDx(Dest, Src);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strcat_sDx", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_strcat_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src);
		public static void strcat_sDx(System.Text.StringBuilder Dest, ulong DestBytes, string Src) => dx_strcat_sDx(Dest, DestBytes, Src);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strlenDx", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_strlenDx(string Str);
		public static ulong strlenDx(string Str) => dx_strlenDx(Str);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strlen2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static ulong dx_strlen2Dx(string Str);
		public static ulong strlen2Dx(string Str) => dx_strlen2Dx(Str);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strcmpDx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_strcmpDx(string Str1, string Str2);
		public static int strcmpDx(string Str1, string Str2) => dx_strcmpDx(Str1, Str2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_stricmpDx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_stricmpDx(string Str1, string Str2);
		public static int stricmpDx(string Str1, string Str2) => dx_stricmpDx(Str1, Str2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strncmpDx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_strncmpDx(string Str1, string Str2, int Num);
		public static int strncmpDx(string Str1, string Str2, int Num) => dx_strncmpDx(Str1, Str2, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strncmp2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_strncmp2Dx(string Str1, string Str2, int Num);
		public static int strncmp2Dx(string Str1, string Str2, int Num) => dx_strncmp2Dx(Str1, Str2, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strpncmpDx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_strpncmpDx(string Str1, string Str2, int Pos, int Num);
		public static int strpncmpDx(string Str1, string Str2, int Pos, int Num) => dx_strpncmpDx(Str1, Str2, Pos, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strpncmp2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_strpncmp2Dx(string Str1, string Str2, int Pos, int Num);
		public static int strpncmp2Dx(string Str1, string Str2, int Pos, int Num) => dx_strpncmp2Dx(Str1, Str2, Pos, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strgetchrDx", CallingConvention=CallingConvention.StdCall)]
		extern static uint dx_strgetchrDx(string Str, int Pos, out int CharNums);
		public static uint strgetchrDx(string Str, int Pos, out int CharNums) => dx_strgetchrDx(Str, Pos, out CharNums);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strgetchr2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static uint dx_strgetchr2Dx(string Str, int Pos, out int CharNums);
		public static uint strgetchr2Dx(string Str, int Pos, out int CharNums) => dx_strgetchr2Dx(Str, Pos, out CharNums);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strputchrDx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_strputchrDx(System.Text.StringBuilder Str, int Pos, uint CharCode);
		public static int strputchrDx(System.Text.StringBuilder Str, int Pos, uint CharCode) => dx_strputchrDx(Str, Pos, CharCode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strputchr2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_strputchr2Dx(System.Text.StringBuilder Str, int Pos, uint CharCode);
		public static int strputchr2Dx(System.Text.StringBuilder Str, int Pos, uint CharCode) => dx_strputchr2Dx(Str, Pos, CharCode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strposDx", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_strposDx(string Str, int Pos);
		public static string strposDx(string Str, int Pos)
		{
			var resultIntPtr = dx_strposDx(Str, Pos);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strpos2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_strpos2Dx(string Str, int Pos);
		public static string strpos2Dx(string Str, int Pos)
		{
			var resultIntPtr = dx_strpos2Dx(Str, Pos);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strstrDx", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_strstrDx(string Str1, string Str2);
		public static string strstrDx(string Str1, string Str2)
		{
			var resultIntPtr = dx_strstrDx(Str1, Str2);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strstr2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_strstr2Dx(string Str1, string Str2);
		public static int strstr2Dx(string Str1, string Str2) => dx_strstr2Dx(Str1, Str2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strrstrDx", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_strrstrDx(string Str1, string Str2);
		public static string strrstrDx(string Str1, string Str2)
		{
			var resultIntPtr = dx_strrstrDx(Str1, Str2);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strrstr2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_strrstr2Dx(string Str1, string Str2);
		public static int strrstr2Dx(string Str1, string Str2) => dx_strrstr2Dx(Str1, Str2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strchrDx", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_strchrDx(string Str, uint CharCode);
		public static string strchrDx(string Str, uint CharCode)
		{
			var resultIntPtr = dx_strchrDx(Str, CharCode);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strchr2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_strchr2Dx(string Str, uint CharCode);
		public static int strchr2Dx(string Str, uint CharCode) => dx_strchr2Dx(Str, CharCode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strrchrDx", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_strrchrDx(string Str, uint CharCode);
		public static string strrchrDx(string Str, uint CharCode)
		{
			var resultIntPtr = dx_strrchrDx(Str, CharCode);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_strrchr2Dx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_strrchr2Dx(string Str, uint CharCode);
		public static int strrchr2Dx(string Str, uint CharCode) => dx_strrchr2Dx(Str, CharCode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_struprDx", CallingConvention=CallingConvention.StdCall)]
		extern static System.Text.StringBuilder dx_struprDx(System.Text.StringBuilder Str);
		public static System.Text.StringBuilder struprDx(System.Text.StringBuilder Str) => dx_struprDx(Str);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_itoaDx", CallingConvention=CallingConvention.StdCall)]
		extern static System.Text.StringBuilder dx_itoaDx(int Value, System.Text.StringBuilder Buffer, int Radix);
		public static System.Text.StringBuilder itoaDx(int Value, System.Text.StringBuilder Buffer, int Radix) => dx_itoaDx(Value, Buffer, Radix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_itoa_sDx", CallingConvention=CallingConvention.StdCall)]
		extern static System.Text.StringBuilder dx_itoa_sDx(int Value, System.Text.StringBuilder Buffer, ulong BufferBytes, int Radix);
		public static System.Text.StringBuilder itoa_sDx(int Value, System.Text.StringBuilder Buffer, ulong BufferBytes, int Radix) => dx_itoa_sDx(Value, Buffer, BufferBytes, Radix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_atoiDx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_atoiDx(string Str);
		public static int atoiDx(string Str) => dx_atoiDx(Str);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_atofDx", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_atofDx(string Str);
		public static double atofDx(string Str) => dx_atofDx(Str);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ProcessNetMessage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ProcessNetMessage(int RunReleaseProcess);
		public static int ProcessNetMessage(int RunReleaseProcess = FALSE) => dx_ProcessNetMessage(RunReleaseProcess);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetHostIPbyName", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetHostIPbyName(string HostName, out IPDATA IPDataBuf, int IPDataBufLength, out int IPDataGetNum);
		public static int GetHostIPbyName(string HostName, out IPDATA IPDataBuf, int IPDataBufLength, out int IPDataGetNum) => dx_GetHostIPbyName(HostName, out IPDataBuf, IPDataBufLength, out IPDataGetNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetHostIPbyNameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetHostIPbyNameWithStrLen(string HostName, ulong HostNameLength, out IPDATA IPDataBuf, int IPDataBufLength, out int IPDataGetNum);
		public static int GetHostIPbyNameWithStrLen(string HostName, ulong HostNameLength, out IPDATA IPDataBuf, int IPDataBufLength, out int IPDataGetNum) => dx_GetHostIPbyNameWithStrLen(HostName, HostNameLength, out IPDataBuf, IPDataBufLength, out IPDataGetNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetHostIPbyName_IPv6", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetHostIPbyName_IPv6(string HostName, out IPDATA_IPv6 IPDataBuf, int IPDataBufLength, out int IPDataGetNum);
		public static int GetHostIPbyName_IPv6(string HostName, out IPDATA_IPv6 IPDataBuf, int IPDataBufLength, out int IPDataGetNum) => dx_GetHostIPbyName_IPv6(HostName, out IPDataBuf, IPDataBufLength, out IPDataGetNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetHostIPbyName_IPv6WithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetHostIPbyName_IPv6WithStrLen(string HostName, ulong HostNameLength, out IPDATA_IPv6 IPDataBuf, int IPDataBufLength, out int IPDataGetNum);
		public static int GetHostIPbyName_IPv6WithStrLen(string HostName, ulong HostNameLength, out IPDATA_IPv6 IPDataBuf, int IPDataBufLength, out int IPDataGetNum) => dx_GetHostIPbyName_IPv6WithStrLen(HostName, HostNameLength, out IPDataBuf, IPDataBufLength, out IPDataGetNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConnectNetWork", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ConnectNetWork(IPDATA IPData, int Port);
		public static int ConnectNetWork(IPDATA IPData, int Port = -1) => dx_ConnectNetWork(IPData, Port);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConnectNetWork_IPv6", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ConnectNetWork_IPv6(IPDATA_IPv6 IPData, int Port);
		public static int ConnectNetWork_IPv6(IPDATA_IPv6 IPData, int Port = -1) => dx_ConnectNetWork_IPv6(IPData, Port);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConnectNetWork_ASync", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ConnectNetWork_ASync(IPDATA IPData, int Port);
		public static int ConnectNetWork_ASync(IPDATA IPData, int Port = -1) => dx_ConnectNetWork_ASync(IPData, Port);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConnectNetWork_IPv6_ASync", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ConnectNetWork_IPv6_ASync(IPDATA_IPv6 IPData, int Port);
		public static int ConnectNetWork_IPv6_ASync(IPDATA_IPv6 IPData, int Port = -1) => dx_ConnectNetWork_IPv6_ASync(IPData, Port);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PreparationListenNetWork", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PreparationListenNetWork(int Port);
		public static int PreparationListenNetWork(int Port = -1) => dx_PreparationListenNetWork(Port);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PreparationListenNetWork_IPv6", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PreparationListenNetWork_IPv6(int Port);
		public static int PreparationListenNetWork_IPv6(int Port = -1) => dx_PreparationListenNetWork_IPv6(Port);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_StopListenNetWork", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_StopListenNetWork();
		public static int StopListenNetWork() => dx_StopListenNetWork();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CloseNetWork", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CloseNetWork(int NetHandle);
		public static int CloseNetWork(int NetHandle) => dx_CloseNetWork(NetHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetNetWorkAcceptState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetNetWorkAcceptState(int NetHandle);
		public static int GetNetWorkAcceptState(int NetHandle) => dx_GetNetWorkAcceptState(NetHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetNetWorkDataLength", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetNetWorkDataLength(int NetHandle);
		public static int GetNetWorkDataLength(int NetHandle) => dx_GetNetWorkDataLength(NetHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetNetWorkSendDataLength", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetNetWorkSendDataLength(int NetHandle);
		public static int GetNetWorkSendDataLength(int NetHandle) => dx_GetNetWorkSendDataLength(NetHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetNewAcceptNetWork", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetNewAcceptNetWork();
		public static int GetNewAcceptNetWork() => dx_GetNewAcceptNetWork();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLostNetWork", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLostNetWork();
		public static int GetLostNetWork() => dx_GetLostNetWork();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetNetWorkIP", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetNetWorkIP(int NetHandle, out IPDATA IpBuf);
		public static int GetNetWorkIP(int NetHandle, out IPDATA IpBuf) => dx_GetNetWorkIP(NetHandle, out IpBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetNetWorkIP_IPv6", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetNetWorkIP_IPv6(int NetHandle, out IPDATA_IPv6 IpBuf);
		public static int GetNetWorkIP_IPv6(int NetHandle, out IPDATA_IPv6 IpBuf) => dx_GetNetWorkIP_IPv6(NetHandle, out IpBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMyIPAddress", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMyIPAddress(out IPDATA IpBuf, int IpBufLength, out int IpNum);
		public static int GetMyIPAddress(out IPDATA IpBuf, int IpBufLength, out int IpNum) => dx_GetMyIPAddress(out IpBuf, IpBufLength, out IpNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMyIPAddress_IPv6", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMyIPAddress_IPv6(out IPDATA_IPv6 IpBuf, int IpBufLength, out int IpNum);
		public static int GetMyIPAddress_IPv6(out IPDATA_IPv6 IpBuf, int IpBufLength, out int IpNum) => dx_GetMyIPAddress_IPv6(out IpBuf, IpBufLength, out IpNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetConnectTimeOutWait", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetConnectTimeOutWait(int Time);
		public static int SetConnectTimeOutWait(int Time) => dx_SetConnectTimeOutWait(Time);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDXNetWorkProtocol", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDXNetWorkProtocol(int Flag);
		public static int SetUseDXNetWorkProtocol(int Flag) => dx_SetUseDXNetWorkProtocol(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseDXNetWorkProtocol", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseDXNetWorkProtocol();
		public static int GetUseDXNetWorkProtocol() => dx_GetUseDXNetWorkProtocol();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDXProtocol", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDXProtocol(int Flag);
		public static int SetUseDXProtocol(int Flag) => dx_SetUseDXProtocol(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseDXProtocol", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseDXProtocol();
		public static int GetUseDXProtocol() => dx_GetUseDXProtocol();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNetWorkCloseAfterLostFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNetWorkCloseAfterLostFlag(int Flag);
		public static int SetNetWorkCloseAfterLostFlag(int Flag) => dx_SetNetWorkCloseAfterLostFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetNetWorkCloseAfterLostFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetNetWorkCloseAfterLostFlag();
		public static int GetNetWorkCloseAfterLostFlag() => dx_GetNetWorkCloseAfterLostFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_NetWorkRecv", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_NetWorkRecv(int NetHandle, System.IntPtr Buffer, int Length);
		public static int NetWorkRecv(int NetHandle, System.IntPtr Buffer, int Length) => dx_NetWorkRecv(NetHandle, Buffer, Length);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_NetWorkRecvToPeek", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_NetWorkRecvToPeek(int NetHandle, System.IntPtr Buffer, int Length);
		public static int NetWorkRecvToPeek(int NetHandle, System.IntPtr Buffer, int Length) => dx_NetWorkRecvToPeek(NetHandle, Buffer, Length);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_NetWorkRecvBufferClear", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_NetWorkRecvBufferClear(int NetHandle);
		public static int NetWorkRecvBufferClear(int NetHandle) => dx_NetWorkRecvBufferClear(NetHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_NetWorkSend", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_NetWorkSend(int NetHandle, System.IntPtr Buffer, int Length);
		public static int NetWorkSend(int NetHandle, System.IntPtr Buffer, int Length) => dx_NetWorkSend(NetHandle, Buffer, Length);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeUDPSocket", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeUDPSocket(int RecvPort);
		public static int MakeUDPSocket(int RecvPort = -1) => dx_MakeUDPSocket(RecvPort);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeUDPSocket_IPv6", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeUDPSocket_IPv6(int RecvPort);
		public static int MakeUDPSocket_IPv6(int RecvPort = -1) => dx_MakeUDPSocket_IPv6(RecvPort);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteUDPSocket", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteUDPSocket(int NetUDPHandle);
		public static int DeleteUDPSocket(int NetUDPHandle) => dx_DeleteUDPSocket(NetUDPHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_NetWorkSendUDP", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_NetWorkSendUDP(int NetUDPHandle, IPDATA SendIP, int SendPort, System.IntPtr Buffer, int Length);
		public static int NetWorkSendUDP(int NetUDPHandle, IPDATA SendIP, int SendPort, System.IntPtr Buffer, int Length) => dx_NetWorkSendUDP(NetUDPHandle, SendIP, SendPort, Buffer, Length);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_NetWorkSendUDP_IPv6", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_NetWorkSendUDP_IPv6(int NetUDPHandle, IPDATA_IPv6 SendIP, int SendPort, System.IntPtr Buffer, int Length);
		public static int NetWorkSendUDP_IPv6(int NetUDPHandle, IPDATA_IPv6 SendIP, int SendPort, System.IntPtr Buffer, int Length) => dx_NetWorkSendUDP_IPv6(NetUDPHandle, SendIP, SendPort, Buffer, Length);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_NetWorkRecvUDP", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_NetWorkRecvUDP(int NetUDPHandle, out IPDATA RecvIP, out int RecvPort, System.IntPtr Buffer, int Length, int Peek);
		public static int NetWorkRecvUDP(int NetUDPHandle, out IPDATA RecvIP, out int RecvPort, System.IntPtr Buffer, int Length, int Peek) => dx_NetWorkRecvUDP(NetUDPHandle, out RecvIP, out RecvPort, Buffer, Length, Peek);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_NetWorkRecvUDP_IPv6", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_NetWorkRecvUDP_IPv6(int NetUDPHandle, out IPDATA_IPv6 RecvIP, out int RecvPort, System.IntPtr Buffer, int Length, int Peek);
		public static int NetWorkRecvUDP_IPv6(int NetUDPHandle, out IPDATA_IPv6 RecvIP, out int RecvPort, System.IntPtr Buffer, int Length, int Peek) => dx_NetWorkRecvUDP_IPv6(NetUDPHandle, out RecvIP, out RecvPort, Buffer, Length, Peek);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckNetWorkRecvUDP", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckNetWorkRecvUDP(int NetUDPHandle);
		public static int CheckNetWorkRecvUDP(int NetUDPHandle) => dx_CheckNetWorkRecvUDP(NetUDPHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_StockInputChar", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_StockInputChar(byte CharCode);
		public static int StockInputChar(byte CharCode) => dx_StockInputChar(CharCode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ClearInputCharBuf", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ClearInputCharBuf();
		public static int ClearInputCharBuf() => dx_ClearInputCharBuf();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetInputChar", CallingConvention=CallingConvention.StdCall)]
		extern static byte dx_GetInputChar(int DeleteFlag);
		public static byte GetInputChar(int DeleteFlag) => dx_GetInputChar(DeleteFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetInputCharWait", CallingConvention=CallingConvention.StdCall)]
		extern static byte dx_GetInputCharWait(int DeleteFlag);
		public static byte GetInputCharWait(int DeleteFlag) => dx_GetInputCharWait(DeleteFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetOneChar", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetOneChar(System.Text.StringBuilder CharBuffer, int DeleteFlag);
		public static int GetOneChar(System.Text.StringBuilder CharBuffer, int DeleteFlag) => dx_GetOneChar(CharBuffer, DeleteFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetOneCharWait", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetOneCharWait(System.Text.StringBuilder CharBuffer, int DeleteFlag);
		public static int GetOneCharWait(System.Text.StringBuilder CharBuffer, int DeleteFlag) => dx_GetOneCharWait(CharBuffer, DeleteFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCtrlCodeCmp", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCtrlCodeCmp(byte Char);
		public static int GetCtrlCodeCmp(byte Char) => dx_GetCtrlCodeCmp(Char);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawIMEInputString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawIMEInputString(int x, int y, int SelectStringNum, int DrawCandidateList);
		public static int DrawIMEInputString(int x, int y, int SelectStringNum, int DrawCandidateList = TRUE) => dx_DrawIMEInputString(x, y, SelectStringNum, DrawCandidateList);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseIMEFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseIMEFlag(int UseFlag);
		public static int SetUseIMEFlag(int UseFlag) => dx_SetUseIMEFlag(UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseIMEFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseIMEFlag();
		public static int GetUseIMEFlag() => dx_GetUseIMEFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetInputStringMaxLengthIMESync", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetInputStringMaxLengthIMESync(int Flag);
		public static int SetInputStringMaxLengthIMESync(int Flag) => dx_SetInputStringMaxLengthIMESync(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetIMEInputStringMaxLength", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetIMEInputStringMaxLength(int Length);
		public static int SetIMEInputStringMaxLength(int Length) => dx_SetIMEInputStringMaxLength(Length);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetStringPoint", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetStringPoint(string String, int Point);
		public static int GetStringPoint(string String, int Point) => dx_GetStringPoint(String, Point);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetStringPointWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetStringPointWithStrLen(string String, ulong StringLength, int Point);
		public static int GetStringPointWithStrLen(string String, ulong StringLength, int Point) => dx_GetStringPointWithStrLen(String, StringLength, Point);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetStringPoint2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetStringPoint2(string String, int Point);
		public static int GetStringPoint2(string String, int Point) => dx_GetStringPoint2(String, Point);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetStringPoint2WithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetStringPoint2WithStrLen(string String, ulong StringLength, int Point);
		public static int GetStringPoint2WithStrLen(string String, ulong StringLength, int Point) => dx_GetStringPoint2WithStrLen(String, StringLength, Point);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetStringLength", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetStringLength(string String);
		public static int GetStringLength(string String) => dx_GetStringLength(String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawObtainsString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawObtainsString(int x, int y, int AddY, string String, uint StrColor, uint StrEdgeColor, int FontHandle, uint SelectBackColor, uint SelectStrColor, uint SelectStrEdgeColor, int SelectStart, int SelectEnd);
		public static int DrawObtainsString(int x, int y, int AddY, string String, uint StrColor, uint StrEdgeColor = 0, int FontHandle = -1, uint SelectBackColor = 0xffffffff, uint SelectStrColor = 0, uint SelectStrEdgeColor = 0xffffffff, int SelectStart = -1, int SelectEnd = -1) => dx_DrawObtainsString(x, y, AddY, String, StrColor, StrEdgeColor, FontHandle, SelectBackColor, SelectStrColor, SelectStrEdgeColor, SelectStart, SelectEnd);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawObtainsNString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawObtainsNString(int x, int y, int AddY, string String, ulong StringLength, uint StrColor, uint StrEdgeColor, int FontHandle, uint SelectBackColor, uint SelectStrColor, uint SelectStrEdgeColor, int SelectStart, int SelectEnd);
		public static int DrawObtainsNString(int x, int y, int AddY, string String, ulong StringLength, uint StrColor, uint StrEdgeColor = 0, int FontHandle = -1, uint SelectBackColor = 0xffffffff, uint SelectStrColor = 0, uint SelectStrEdgeColor = 0xffffffff, int SelectStart = -1, int SelectEnd = -1) => dx_DrawObtainsNString(x, y, AddY, String, StringLength, StrColor, StrEdgeColor, FontHandle, SelectBackColor, SelectStrColor, SelectStrEdgeColor, SelectStart, SelectEnd);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawObtainsString_CharClip", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawObtainsString_CharClip(int x, int y, int AddY, string String, uint StrColor, uint StrEdgeColor, int FontHandle, uint SelectBackColor, uint SelectStrColor, uint SelectStrEdgeColor, int SelectStart, int SelectEnd);
		public static int DrawObtainsString_CharClip(int x, int y, int AddY, string String, uint StrColor, uint StrEdgeColor = 0, int FontHandle = -1, uint SelectBackColor = 0xffffffff, uint SelectStrColor = 0, uint SelectStrEdgeColor = 0xffffffff, int SelectStart = -1, int SelectEnd = -1) => dx_DrawObtainsString_CharClip(x, y, AddY, String, StrColor, StrEdgeColor, FontHandle, SelectBackColor, SelectStrColor, SelectStrEdgeColor, SelectStart, SelectEnd);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawObtainsNString_CharClip", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawObtainsNString_CharClip(int x, int y, int AddY, string String, ulong StringLength, uint StrColor, uint StrEdgeColor, int FontHandle, uint SelectBackColor, uint SelectStrColor, uint SelectStrEdgeColor, int SelectStart, int SelectEnd);
		public static int DrawObtainsNString_CharClip(int x, int y, int AddY, string String, ulong StringLength, uint StrColor, uint StrEdgeColor = 0, int FontHandle = -1, uint SelectBackColor = 0xffffffff, uint SelectStrColor = 0, uint SelectStrEdgeColor = 0xffffffff, int SelectStart = -1, int SelectEnd = -1) => dx_DrawObtainsNString_CharClip(x, y, AddY, String, StringLength, StrColor, StrEdgeColor, FontHandle, SelectBackColor, SelectStrColor, SelectStrEdgeColor, SelectStart, SelectEnd);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetObtainsStringCharPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetObtainsStringCharPosition(int x, int y, int AddY, string String, int StrLen, out int PosX, out int PosY, int FontHandle);
		public static int GetObtainsStringCharPosition(int x, int y, int AddY, string String, int StrLen, out int PosX, out int PosY, int FontHandle = -1) => dx_GetObtainsStringCharPosition(x, y, AddY, String, StrLen, out PosX, out PosY, FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetObtainsStringCharPosition_CharClip", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetObtainsStringCharPosition_CharClip(int x, int y, int AddY, string String, int StrLen, out int PosX, out int PosY, int FontHandle);
		public static int GetObtainsStringCharPosition_CharClip(int x, int y, int AddY, string String, int StrLen, out int PosX, out int PosY, int FontHandle = -1) => dx_GetObtainsStringCharPosition_CharClip(x, y, AddY, String, StrLen, out PosX, out PosY, FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawObtainsBox", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawObtainsBox(int x1, int y1, int x2, int y2, int AddY, uint Color, int FillFlag);
		public static int DrawObtainsBox(int x1, int y1, int x2, int y2, int AddY, uint Color, int FillFlag) => dx_DrawObtainsBox(x1, y1, x2, y2, AddY, Color, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InputStringToCustom", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InputStringToCustom(int x, int y, ulong BufLength, System.Text.StringBuilder StrBuffer, int CancelValidFlag, int SingleCharOnlyFlag, int NumCharOnlyFlag, int DoubleCharOnlyFlag, int EnableNewLineFlag, int DisplayCandidateList);
		public static int InputStringToCustom(int x, int y, ulong BufLength, System.Text.StringBuilder StrBuffer, int CancelValidFlag, int SingleCharOnlyFlag, int NumCharOnlyFlag, int DoubleCharOnlyFlag = FALSE, int EnableNewLineFlag = FALSE, int DisplayCandidateList = TRUE) => dx_InputStringToCustom(x, y, BufLength, StrBuffer, CancelValidFlag, SingleCharOnlyFlag, NumCharOnlyFlag, DoubleCharOnlyFlag, EnableNewLineFlag, DisplayCandidateList);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_KeyInputString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_KeyInputString(int x, int y, ulong CharMaxLength, System.Text.StringBuilder StrBuffer, int CancelValidFlag);
		public static int KeyInputString(int x, int y, ulong CharMaxLength, System.Text.StringBuilder StrBuffer, int CancelValidFlag) => dx_KeyInputString(x, y, CharMaxLength, StrBuffer, CancelValidFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_KeyInputSingleCharString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_KeyInputSingleCharString(int x, int y, ulong CharMaxLength, System.Text.StringBuilder StrBuffer, int CancelValidFlag);
		public static int KeyInputSingleCharString(int x, int y, ulong CharMaxLength, System.Text.StringBuilder StrBuffer, int CancelValidFlag) => dx_KeyInputSingleCharString(x, y, CharMaxLength, StrBuffer, CancelValidFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_KeyInputNumber", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_KeyInputNumber(int x, int y, int MaxNum, int MinNum, int CancelValidFlag);
		public static int KeyInputNumber(int x, int y, int MaxNum, int MinNum, int CancelValidFlag) => dx_KeyInputNumber(x, y, MaxNum, MinNum, CancelValidFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetIMEInputModeStr", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetIMEInputModeStr(System.Text.StringBuilder GetBuffer);
		public static int GetIMEInputModeStr(System.Text.StringBuilder GetBuffer) => dx_GetIMEInputModeStr(GetBuffer);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputStringColor2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputStringColor2(int TargetColor, uint Color);
		public static int SetKeyInputStringColor2(int TargetColor, uint Color) => dx_SetKeyInputStringColor2(TargetColor, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetKeyInputStringColor2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetKeyInputStringColor2(int TargetColor);
		public static int ResetKeyInputStringColor2(int TargetColor) => dx_ResetKeyInputStringColor2(TargetColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputStringFont", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputStringFont(int FontHandle);
		public static int SetKeyInputStringFont(int FontHandle) => dx_SetKeyInputStringFont(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputStringEndCharaMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputStringEndCharaMode(int EndCharaMode);
		public static int SetKeyInputStringEndCharaMode(int EndCharaMode) => dx_SetKeyInputStringEndCharaMode(EndCharaMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawKeyInputModeString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawKeyInputModeString(int x, int y);
		public static int DrawKeyInputModeString(int x, int y) => dx_DrawKeyInputModeString(x, y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitKeyInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitKeyInput();
		public static int InitKeyInput() => dx_InitKeyInput();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeKeyInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeKeyInput(ulong MaxStrLength, int CancelValidFlag, int SingleCharOnlyFlag, int NumCharOnlyFlag, int DoubleCharOnlyFlag, int EnableNewLineFlag);
		public static int MakeKeyInput(ulong MaxStrLength, int CancelValidFlag, int SingleCharOnlyFlag, int NumCharOnlyFlag, int DoubleCharOnlyFlag = FALSE, int EnableNewLineFlag = FALSE) => dx_MakeKeyInput(MaxStrLength, CancelValidFlag, SingleCharOnlyFlag, NumCharOnlyFlag, DoubleCharOnlyFlag, EnableNewLineFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteKeyInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteKeyInput(int InputHandle);
		public static int DeleteKeyInput(int InputHandle) => dx_DeleteKeyInput(InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetActiveKeyInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetActiveKeyInput(int InputHandle);
		public static int SetActiveKeyInput(int InputHandle) => dx_SetActiveKeyInput(InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetActiveKeyInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetActiveKeyInput();
		public static int GetActiveKeyInput() => dx_GetActiveKeyInput();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckKeyInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckKeyInput(int InputHandle);
		public static int CheckKeyInput(int InputHandle) => dx_CheckKeyInput(InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReStartKeyInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReStartKeyInput(int InputHandle);
		public static int ReStartKeyInput(int InputHandle) => dx_ReStartKeyInput(InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ProcessActKeyInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ProcessActKeyInput();
		public static int ProcessActKeyInput() => dx_ProcessActKeyInput();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawKeyInputString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawKeyInputString(int x, int y, int InputHandle, int DrawCandidateList);
		public static int DrawKeyInputString(int x, int y, int InputHandle, int DrawCandidateList = TRUE) => dx_DrawKeyInputString(x, y, InputHandle, DrawCandidateList);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputDrawArea", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputDrawArea(int x1, int y1, int x2, int y2, int InputHandle);
		public static int SetKeyInputDrawArea(int x1, int y1, int x2, int y2, int InputHandle) => dx_SetKeyInputDrawArea(x1, y1, x2, y2, InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputSelectArea", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputSelectArea(int SelectStart, int SelectEnd, int InputHandle);
		public static int SetKeyInputSelectArea(int SelectStart, int SelectEnd, int InputHandle) => dx_SetKeyInputSelectArea(SelectStart, SelectEnd, InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetKeyInputSelectArea", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetKeyInputSelectArea(out int SelectStart, out int SelectEnd, int InputHandle);
		public static int GetKeyInputSelectArea(out int SelectStart, out int SelectEnd, int InputHandle) => dx_GetKeyInputSelectArea(out SelectStart, out SelectEnd, InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputDrawStartPos", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputDrawStartPos(int DrawStartPos, int InputHandle);
		public static int SetKeyInputDrawStartPos(int DrawStartPos, int InputHandle) => dx_SetKeyInputDrawStartPos(DrawStartPos, InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetKeyInputDrawStartPos", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetKeyInputDrawStartPos(int InputHandle);
		public static int GetKeyInputDrawStartPos(int InputHandle) => dx_GetKeyInputDrawStartPos(InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputCursorBrinkTime", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputCursorBrinkTime(int Time);
		public static int SetKeyInputCursorBrinkTime(int Time) => dx_SetKeyInputCursorBrinkTime(Time);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputCursorBrinkFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputCursorBrinkFlag(int Flag);
		public static int SetKeyInputCursorBrinkFlag(int Flag) => dx_SetKeyInputCursorBrinkFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputString(string String, int InputHandle);
		public static int SetKeyInputString(string String, int InputHandle) => dx_SetKeyInputString(String, InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputStringWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputStringWithStrLen(string String, ulong StringLength, int InputHandle);
		public static int SetKeyInputStringWithStrLen(string String, ulong StringLength, int InputHandle) => dx_SetKeyInputStringWithStrLen(String, StringLength, InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputNumber", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputNumber(int Number, int InputHandle);
		public static int SetKeyInputNumber(int Number, int InputHandle) => dx_SetKeyInputNumber(Number, InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputNumberToFloat", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputNumberToFloat(float Number, int InputHandle);
		public static int SetKeyInputNumberToFloat(float Number, int InputHandle) => dx_SetKeyInputNumberToFloat(Number, InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetKeyInputString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetKeyInputString(System.Text.StringBuilder StrBuffer, int InputHandle);
		public static int GetKeyInputString(System.Text.StringBuilder StrBuffer, int InputHandle) => dx_GetKeyInputString(StrBuffer, InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetKeyInputNumber", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetKeyInputNumber(int InputHandle);
		public static int GetKeyInputNumber(int InputHandle) => dx_GetKeyInputNumber(InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetKeyInputNumberToFloat", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetKeyInputNumberToFloat(int InputHandle);
		public static float GetKeyInputNumberToFloat(int InputHandle) => dx_GetKeyInputNumberToFloat(InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyInputCursorPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyInputCursorPosition(int Position, int InputHandle);
		public static int SetKeyInputCursorPosition(int Position, int InputHandle) => dx_SetKeyInputCursorPosition(Position, InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetKeyInputCursorPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetKeyInputCursorPosition(int InputHandle);
		public static int GetKeyInputCursorPosition(int InputHandle) => dx_GetKeyInputCursorPosition(InputHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_open", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_open(string FilePath, int ASync);
		public static int FileRead_open(string FilePath, int ASync = FALSE) => dx_FileRead_open(FilePath, ASync);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_open_WithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_open_WithStrLen(string FilePath, ulong FilePathLength, int ASync);
		public static int FileRead_open_WithStrLen(string FilePath, ulong FilePathLength, int ASync = FALSE) => dx_FileRead_open_WithStrLen(FilePath, FilePathLength, ASync);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_open_mem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_open_mem(System.IntPtr FileImage, ulong FileImageSize);
		public static int FileRead_open_mem(System.IntPtr FileImage, ulong FileImageSize) => dx_FileRead_open_mem(FileImage, FileImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_size", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_FileRead_size(string FilePath);
		public static long FileRead_size(string FilePath) => dx_FileRead_size(FilePath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_size_WithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_FileRead_size_WithStrLen(string FilePath, ulong FilePathLength);
		public static long FileRead_size_WithStrLen(string FilePath, ulong FilePathLength) => dx_FileRead_size_WithStrLen(FilePath, FilePathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_close", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_close(int FileHandle);
		public static int FileRead_close(int FileHandle) => dx_FileRead_close(FileHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_tell", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_FileRead_tell(int FileHandle);
		public static long FileRead_tell(int FileHandle) => dx_FileRead_tell(FileHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_seek", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_seek(int FileHandle, long Offset, int Origin);
		public static int FileRead_seek(int FileHandle, long Offset, int Origin) => dx_FileRead_seek(FileHandle, Offset, Origin);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_read", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_read(System.IntPtr Buffer, int ReadSize, int FileHandle);
		public static int FileRead_read(System.IntPtr Buffer, int ReadSize, int FileHandle) => dx_FileRead_read(Buffer, ReadSize, FileHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_idle_chk", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_idle_chk(int FileHandle);
		public static int FileRead_idle_chk(int FileHandle) => dx_FileRead_idle_chk(FileHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_eof", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_eof(int FileHandle);
		public static int FileRead_eof(int FileHandle) => dx_FileRead_eof(FileHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_set_format", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_set_format(int FileHandle, int CharCodeFormat);
		public static int FileRead_set_format(int FileHandle, int CharCodeFormat) => dx_FileRead_set_format(FileHandle, CharCodeFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_gets", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_gets(System.Text.StringBuilder Buffer, int BufferSize, int FileHandle);
		public static int FileRead_gets(System.Text.StringBuilder Buffer, int BufferSize, int FileHandle) => dx_FileRead_gets(Buffer, BufferSize, FileHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_getc", CallingConvention=CallingConvention.StdCall)]
		extern static byte dx_FileRead_getc(int FileHandle);
		public static byte FileRead_getc(int FileHandle) => dx_FileRead_getc(FileHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_scanf", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_scanf(int FileHandle, string Format);
		public static int FileRead_scanf(int FileHandle, string Format) => dx_FileRead_scanf(FileHandle, Format);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_createInfo", CallingConvention=CallingConvention.StdCall)]
		extern static uint dx_FileRead_createInfo(string ObjectPath);
		public static uint FileRead_createInfo(string ObjectPath) => dx_FileRead_createInfo(ObjectPath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_createInfo_WithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static uint dx_FileRead_createInfo_WithStrLen(string ObjectPath, ulong ObjectPathLength);
		public static uint FileRead_createInfo_WithStrLen(string ObjectPath, ulong ObjectPathLength) => dx_FileRead_createInfo_WithStrLen(ObjectPath, ObjectPathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_getInfoNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_getInfoNum(uint FileInfoHandle);
		public static int FileRead_getInfoNum(uint FileInfoHandle) => dx_FileRead_getInfoNum(FileInfoHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_deleteInfo", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_deleteInfo(uint FileInfoHandle);
		public static int FileRead_deleteInfo(uint FileInfoHandle) => dx_FileRead_deleteInfo(FileInfoHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_fullyLoad", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_fullyLoad(string FilePath);
		public static int FileRead_fullyLoad(string FilePath) => dx_FileRead_fullyLoad(FilePath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_fullyLoad_WithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_fullyLoad_WithStrLen(string FilePath, ulong FilePathLength);
		public static int FileRead_fullyLoad_WithStrLen(string FilePath, ulong FilePathLength) => dx_FileRead_fullyLoad_WithStrLen(FilePath, FilePathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_fullyLoad_delete", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FileRead_fullyLoad_delete(int FLoadHandle);
		public static int FileRead_fullyLoad_delete(int FLoadHandle) => dx_FileRead_fullyLoad_delete(FLoadHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_fullyLoad_getImage", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_FileRead_fullyLoad_getImage(int FLoadHandle);
		public static System.IntPtr FileRead_fullyLoad_getImage(int FLoadHandle) => dx_FileRead_fullyLoad_getImage(FLoadHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FileRead_fullyLoad_getSize", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_FileRead_fullyLoad_getSize(int FLoadHandle);
		public static long FileRead_fullyLoad_getSize(int FLoadHandle) => dx_FileRead_fullyLoad_getSize(FLoadHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetStreamFunctionDefault", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetStreamFunctionDefault();
		public static int GetStreamFunctionDefault() => dx_GetStreamFunctionDefault();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvertFullPath", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ConvertFullPath(string Src, System.Text.StringBuilder Dest, string CurrentDir);
		public static int ConvertFullPath(string Src, System.Text.StringBuilder Dest, string CurrentDir = default) => dx_ConvertFullPath(Src, Dest, CurrentDir);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvertFullPathWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ConvertFullPathWithStrLen(string Src, ulong SrcLength, System.Text.StringBuilder Dest, string CurrentDir, ulong CurrentDirLength);
		public static int ConvertFullPathWithStrLen(string Src, ulong SrcLength, System.Text.StringBuilder Dest, string CurrentDir = default, ulong CurrentDirLength = 0) => dx_ConvertFullPathWithStrLen(Src, SrcLength, Dest, CurrentDir, CurrentDirLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckHitKey", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckHitKey(int KeyCode);
		public static int CheckHitKey(int KeyCode) => dx_CheckHitKey(KeyCode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckHitKeyAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckHitKeyAll(int CheckType);
		public static int CheckHitKeyAll(int CheckType = DX_CHECKINPUT_ALL) => dx_CheckHitKeyAll(CheckType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetHitKeyStateAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetHitKeyStateAll([In, Out] byte[] KeyStateArray);
		public static int GetHitKeyStateAll([In, Out] byte[] KeyStateArray) => dx_GetHitKeyStateAll(KeyStateArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetJoypadNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetJoypadNum();
		public static int GetJoypadNum() => dx_GetJoypadNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetJoypadButtonNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetJoypadButtonNum(int InputType);
		public static int GetJoypadButtonNum(int InputType) => dx_GetJoypadButtonNum(InputType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetJoypadInputState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetJoypadInputState(int InputType);
		public static int GetJoypadInputState(int InputType) => dx_GetJoypadInputState(InputType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetJoypadAnalogInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetJoypadAnalogInput(out int XBuf, out int YBuf, int InputType);
		public static int GetJoypadAnalogInput(out int XBuf, out int YBuf, int InputType) => dx_GetJoypadAnalogInput(out XBuf, out YBuf, InputType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetJoypadAnalogInputRight", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetJoypadAnalogInputRight(out int XBuf, out int YBuf, int InputType);
		public static int GetJoypadAnalogInputRight(out int XBuf, out int YBuf, int InputType) => dx_GetJoypadAnalogInputRight(out XBuf, out YBuf, InputType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetJoypadDirectInputState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetJoypadDirectInputState(int InputType, out DINPUT_JOYSTATE DInputState);
		public static int GetJoypadDirectInputState(int InputType, out DINPUT_JOYSTATE DInputState) => dx_GetJoypadDirectInputState(InputType, out DInputState);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckJoypadXInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckJoypadXInput(int InputType);
		public static int CheckJoypadXInput(int InputType) => dx_CheckJoypadXInput(InputType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetJoypadXInputState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetJoypadXInputState(int InputType, out XINPUT_STATE XInputState);
		public static int GetJoypadXInputState(int InputType, out XINPUT_STATE XInputState) => dx_GetJoypadXInputState(InputType, out XInputState);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetJoypadInputToKeyInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetJoypadInputToKeyInput(int InputType, int PadInput, int KeyInput1, int KeyInput2, int KeyInput3, int KeyInput4);
		public static int SetJoypadInputToKeyInput(int InputType, int PadInput, int KeyInput1, int KeyInput2 = -1, int KeyInput3 = -1, int KeyInput4 = -1) => dx_SetJoypadInputToKeyInput(InputType, PadInput, KeyInput1, KeyInput2, KeyInput3, KeyInput4);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetJoypadDeadZone", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetJoypadDeadZone(int InputType, double Zone);
		public static int SetJoypadDeadZone(int InputType, double Zone) => dx_SetJoypadDeadZone(InputType, Zone);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetJoypadDeadZone", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_GetJoypadDeadZone(int InputType);
		public static double GetJoypadDeadZone(int InputType) => dx_GetJoypadDeadZone(InputType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_StartJoypadVibration", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_StartJoypadVibration(int InputType, int Power, int Time, int EffectIndex);
		public static int StartJoypadVibration(int InputType, int Power, int Time, int EffectIndex = -1) => dx_StartJoypadVibration(InputType, Power, Time, EffectIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_StopJoypadVibration", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_StopJoypadVibration(int InputType, int EffectIndex);
		public static int StopJoypadVibration(int InputType, int EffectIndex = -1) => dx_StopJoypadVibration(InputType, EffectIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetJoypadPOVState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetJoypadPOVState(int InputType, int POVNumber);
		public static int GetJoypadPOVState(int InputType, int POVNumber) => dx_GetJoypadPOVState(InputType, POVNumber);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReSetupJoypad", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReSetupJoypad();
		public static int ReSetupJoypad() => dx_ReSetupJoypad();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseJoypadVibrationFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseJoypadVibrationFlag(int Flag);
		public static int SetUseJoypadVibrationFlag(int Flag) => dx_SetUseJoypadVibrationFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeGraph(int SizeX, int SizeY, int NotUse3DFlag);
		public static int MakeGraph(int SizeX, int SizeY, int NotUse3DFlag = FALSE) => dx_MakeGraph(SizeX, SizeY, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeScreen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeScreen(int SizeX, int SizeY, int UseAlphaChannel);
		public static int MakeScreen(int SizeX, int SizeY, int UseAlphaChannel = FALSE) => dx_MakeScreen(SizeX, SizeY, UseAlphaChannel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DerivationGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DerivationGraph(int SrcX, int SrcY, int Width, int Height, int SrcGraphHandle);
		public static int DerivationGraph(int SrcX, int SrcY, int Width, int Height, int SrcGraphHandle) => dx_DerivationGraph(SrcX, SrcY, Width, Height, SrcGraphHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DerivationGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DerivationGraphF(float SrcX, float SrcY, float Width, float Height, int SrcGraphHandle);
		public static int DerivationGraphF(float SrcX, float SrcY, float Width, float Height, int SrcGraphHandle) => dx_DerivationGraphF(SrcX, SrcY, Width, Height, SrcGraphHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteGraph(int GrHandle, int LogOutFlag);
		public static int DeleteGraph(int GrHandle, int LogOutFlag = FALSE) => dx_DeleteGraph(GrHandle, LogOutFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteSharingGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteSharingGraph(int GrHandle);
		public static int DeleteSharingGraph(int GrHandle) => dx_DeleteSharingGraph(GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetGraphNum();
		public static int GetGraphNum() => dx_GetGraphNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FillGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FillGraph(int GrHandle, int Red, int Green, int Blue, int Alpha);
		public static int FillGraph(int GrHandle, int Red, int Green, int Blue, int Alpha = 255) => dx_FillGraph(GrHandle, Red, Green, Blue, Alpha);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FillRectGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FillRectGraph(int GrHandle, int x, int y, int Width, int Height, int Red, int Green, int Blue, int Alpha);
		public static int FillRectGraph(int GrHandle, int x, int y, int Width, int Height, int Red, int Green, int Blue, int Alpha = 255) => dx_FillRectGraph(GrHandle, x, y, Width, Height, Red, Green, Blue, Alpha);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetGraphLostFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetGraphLostFlag(int GrHandle, out int LostFlag);
		public static int SetGraphLostFlag(int GrHandle, out int LostFlag) => dx_SetGraphLostFlag(GrHandle, out LostFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitGraph(int LogOutFlag);
		public static int InitGraph(int LogOutFlag = FALSE) => dx_InitGraph(LogOutFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadFileGraphAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadFileGraphAll();
		public static int ReloadFileGraphAll() => dx_ReloadFileGraphAll();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeShadowMap", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeShadowMap(int SizeX, int SizeY);
		public static int MakeShadowMap(int SizeX, int SizeY) => dx_MakeShadowMap(SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteShadowMap", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteShadowMap(int SmHandle);
		public static int DeleteShadowMap(int SmHandle) => dx_DeleteShadowMap(SmHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetShadowMapLightDirection", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetShadowMapLightDirection(int SmHandle, VECTOR Direction);
		public static int SetShadowMapLightDirection(int SmHandle, VECTOR Direction) => dx_SetShadowMapLightDirection(SmHandle, Direction);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ShadowMap_DrawSetup", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ShadowMap_DrawSetup(int SmHandle);
		public static int ShadowMap_DrawSetup(int SmHandle) => dx_ShadowMap_DrawSetup(SmHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ShadowMap_DrawEnd", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ShadowMap_DrawEnd();
		public static int ShadowMap_DrawEnd() => dx_ShadowMap_DrawEnd();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseShadowMap", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseShadowMap(int SmSlotIndex, int SmHandle);
		public static int SetUseShadowMap(int SmSlotIndex, int SmHandle) => dx_SetUseShadowMap(SmSlotIndex, SmHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetShadowMapDrawArea", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetShadowMapDrawArea(int SmHandle, VECTOR MinPosition, VECTOR MaxPosition);
		public static int SetShadowMapDrawArea(int SmHandle, VECTOR MinPosition, VECTOR MaxPosition) => dx_SetShadowMapDrawArea(SmHandle, MinPosition, MaxPosition);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetShadowMapDrawArea", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetShadowMapDrawArea(int SmHandle);
		public static int ResetShadowMapDrawArea(int SmHandle) => dx_ResetShadowMapDrawArea(SmHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetShadowMapAdjustDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetShadowMapAdjustDepth(int SmHandle, float Depth);
		public static int SetShadowMapAdjustDepth(int SmHandle, float Depth) => dx_SetShadowMapAdjustDepth(SmHandle, Depth);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetShadowMapViewProjectionMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetShadowMapViewProjectionMatrix(int SmHandle, out MATRIX MatrixBuffer);
		public static int GetShadowMapViewProjectionMatrix(int SmHandle, out MATRIX MatrixBuffer) => dx_GetShadowMapViewProjectionMatrix(SmHandle, out MatrixBuffer);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_TestDrawShadowMap", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_TestDrawShadowMap(int SmHandle, int x1, int y1, int x2, int y2);
		public static int TestDrawShadowMap(int SmHandle, int x1, int y1, int x2, int y2) => dx_TestDrawShadowMap(SmHandle, x1, y1, x2, y2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadBmpToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadBmpToGraph(string FileName, int TextureFlag, int ReverseFlag, int SurfaceMode);
		public static int LoadBmpToGraph(string FileName, int TextureFlag, int ReverseFlag, int SurfaceMode = DX_MOVIESURFACE_NORMAL) => dx_LoadBmpToGraph(FileName, TextureFlag, ReverseFlag, SurfaceMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadBmpToGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadBmpToGraphWithStrLen(string FileName, ulong FileNameLength, int TextureFlag, int ReverseFlag, int SurfaceMode);
		public static int LoadBmpToGraphWithStrLen(string FileName, ulong FileNameLength, int TextureFlag, int ReverseFlag, int SurfaceMode = DX_MOVIESURFACE_NORMAL) => dx_LoadBmpToGraphWithStrLen(FileName, FileNameLength, TextureFlag, ReverseFlag, SurfaceMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadGraph(string FileName, int NotUse3DFlag);
		public static int LoadGraph(string FileName, int NotUse3DFlag = FALSE) => dx_LoadGraph(FileName, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadGraphWithStrLen(string FileName, ulong FileNameLength, int NotUse3DFlag);
		public static int LoadGraphWithStrLen(string FileName, ulong FileNameLength, int NotUse3DFlag = FALSE) => dx_LoadGraphWithStrLen(FileName, FileNameLength, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadReverseGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadReverseGraph(string FileName, int NotUse3DFlag);
		public static int LoadReverseGraph(string FileName, int NotUse3DFlag = FALSE) => dx_LoadReverseGraph(FileName, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadReverseGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadReverseGraphWithStrLen(string FileName, ulong FileNameLength, int NotUse3DFlag);
		public static int LoadReverseGraphWithStrLen(string FileName, ulong FileNameLength, int NotUse3DFlag = FALSE) => dx_LoadReverseGraphWithStrLen(FileName, FileNameLength, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivGraph(string FileName, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray, int NotUse3DFlag);
		public static int LoadDivGraph(string FileName, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray, int NotUse3DFlag = FALSE) => dx_LoadDivGraph(FileName, AllNum, XNum, YNum, XSize, YSize, HandleArray, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivGraphWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray, int NotUse3DFlag);
		public static int LoadDivGraphWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray, int NotUse3DFlag = FALSE) => dx_LoadDivGraphWithStrLen(FileName, FileNameLength, AllNum, XNum, YNum, XSize, YSize, HandleArray, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivGraphF(string FileName, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray, int NotUse3DFlag);
		public static int LoadDivGraphF(string FileName, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray, int NotUse3DFlag = FALSE) => dx_LoadDivGraphF(FileName, AllNum, XNum, YNum, XSize, YSize, HandleArray, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivGraphFWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivGraphFWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray, int NotUse3DFlag);
		public static int LoadDivGraphFWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray, int NotUse3DFlag = FALSE) => dx_LoadDivGraphFWithStrLen(FileName, FileNameLength, AllNum, XNum, YNum, XSize, YSize, HandleArray, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivBmpToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivBmpToGraph(string FileName, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray, int TextureFlag, int ReverseFlag);
		public static int LoadDivBmpToGraph(string FileName, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray, int TextureFlag, int ReverseFlag) => dx_LoadDivBmpToGraph(FileName, AllNum, XNum, YNum, SizeX, SizeY, HandleArray, TextureFlag, ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivBmpToGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivBmpToGraphWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray, int TextureFlag, int ReverseFlag);
		public static int LoadDivBmpToGraphWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray, int TextureFlag, int ReverseFlag) => dx_LoadDivBmpToGraphWithStrLen(FileName, FileNameLength, AllNum, XNum, YNum, SizeX, SizeY, HandleArray, TextureFlag, ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivBmpToGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivBmpToGraphF(string FileName, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray, int TextureFlag, int ReverseFlag);
		public static int LoadDivBmpToGraphF(string FileName, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray, int TextureFlag, int ReverseFlag) => dx_LoadDivBmpToGraphF(FileName, AllNum, XNum, YNum, SizeX, SizeY, HandleArray, TextureFlag, ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivBmpToGraphFWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivBmpToGraphFWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray, int TextureFlag, int ReverseFlag);
		public static int LoadDivBmpToGraphFWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray, int TextureFlag, int ReverseFlag) => dx_LoadDivBmpToGraphFWithStrLen(FileName, FileNameLength, AllNum, XNum, YNum, SizeX, SizeY, HandleArray, TextureFlag, ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadReverseDivGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadReverseDivGraph(string FileName, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray, int NotUse3DFlag);
		public static int LoadReverseDivGraph(string FileName, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray, int NotUse3DFlag = FALSE) => dx_LoadReverseDivGraph(FileName, AllNum, XNum, YNum, XSize, YSize, HandleArray, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadReverseDivGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadReverseDivGraphWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray, int NotUse3DFlag);
		public static int LoadReverseDivGraphWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray, int NotUse3DFlag = FALSE) => dx_LoadReverseDivGraphWithStrLen(FileName, FileNameLength, AllNum, XNum, YNum, XSize, YSize, HandleArray, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadReverseDivGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadReverseDivGraphF(string FileName, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray, int NotUse3DFlag);
		public static int LoadReverseDivGraphF(string FileName, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray, int NotUse3DFlag = FALSE) => dx_LoadReverseDivGraphF(FileName, AllNum, XNum, YNum, XSize, YSize, HandleArray, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadReverseDivGraphFWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadReverseDivGraphFWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray, int NotUse3DFlag);
		public static int LoadReverseDivGraphFWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray, int NotUse3DFlag = FALSE) => dx_LoadReverseDivGraphFWithStrLen(FileName, FileNameLength, AllNum, XNum, YNum, XSize, YSize, HandleArray, NotUse3DFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadBlendGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadBlendGraph(string FileName);
		public static int LoadBlendGraph(string FileName) => dx_LoadBlendGraph(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadBlendGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadBlendGraphWithStrLen(string FileName, ulong FileNameLength);
		public static int LoadBlendGraphWithStrLen(string FileName, ulong FileNameLength) => dx_LoadBlendGraphWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateGraphFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateGraphFromMem(System.IntPtr RGBFileImage, int RGBFileImageSize, System.IntPtr AlphaFileImage, int AlphaFileImageSize, int TextureFlag, int ReverseFlag);
		public static int CreateGraphFromMem(System.IntPtr RGBFileImage, int RGBFileImageSize, System.IntPtr AlphaFileImage = default, int AlphaFileImageSize = 0, int TextureFlag = TRUE, int ReverseFlag = FALSE) => dx_CreateGraphFromMem(RGBFileImage, RGBFileImageSize, AlphaFileImage, AlphaFileImageSize, TextureFlag, ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReCreateGraphFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReCreateGraphFromMem(System.IntPtr RGBFileImage, int RGBFileImageSize, int GrHandle, System.IntPtr AlphaFileImage, int AlphaFileImageSize, int TextureFlag, int ReverseFlag);
		public static int ReCreateGraphFromMem(System.IntPtr RGBFileImage, int RGBFileImageSize, int GrHandle, System.IntPtr AlphaFileImage = default, int AlphaFileImageSize = 0, int TextureFlag = TRUE, int ReverseFlag = FALSE) => dx_ReCreateGraphFromMem(RGBFileImage, RGBFileImageSize, GrHandle, AlphaFileImage, AlphaFileImageSize, TextureFlag, ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateDivGraphFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateDivGraphFromMem(System.IntPtr RGBFileImage, int RGBFileImageSize, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray, int TextureFlag, int ReverseFlag, System.IntPtr AlphaFileImage, int AlphaFileImageSize);
		public static int CreateDivGraphFromMem(System.IntPtr RGBFileImage, int RGBFileImageSize, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray, int TextureFlag = TRUE, int ReverseFlag = FALSE, System.IntPtr AlphaFileImage = default, int AlphaFileImageSize = 0) => dx_CreateDivGraphFromMem(RGBFileImage, RGBFileImageSize, AllNum, XNum, YNum, SizeX, SizeY, HandleArray, TextureFlag, ReverseFlag, AlphaFileImage, AlphaFileImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateDivGraphFFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateDivGraphFFromMem(System.IntPtr RGBFileImage, int RGBFileImageSize, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray, int TextureFlag, int ReverseFlag, System.IntPtr AlphaFileImage, int AlphaFileImageSize);
		public static int CreateDivGraphFFromMem(System.IntPtr RGBFileImage, int RGBFileImageSize, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray, int TextureFlag = TRUE, int ReverseFlag = FALSE, System.IntPtr AlphaFileImage = default, int AlphaFileImageSize = 0) => dx_CreateDivGraphFFromMem(RGBFileImage, RGBFileImageSize, AllNum, XNum, YNum, SizeX, SizeY, HandleArray, TextureFlag, ReverseFlag, AlphaFileImage, AlphaFileImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReCreateDivGraphFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReCreateDivGraphFromMem(System.IntPtr RGBFileImage, int RGBFileImageSize, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray, int TextureFlag, int ReverseFlag, System.IntPtr AlphaFileImage, int AlphaFileImageSize);
		public static int ReCreateDivGraphFromMem(System.IntPtr RGBFileImage, int RGBFileImageSize, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray, int TextureFlag = TRUE, int ReverseFlag = FALSE, System.IntPtr AlphaFileImage = default, int AlphaFileImageSize = 0) => dx_ReCreateDivGraphFromMem(RGBFileImage, RGBFileImageSize, AllNum, XNum, YNum, SizeX, SizeY, HandleArray, TextureFlag, ReverseFlag, AlphaFileImage, AlphaFileImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReCreateDivGraphFFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReCreateDivGraphFFromMem(System.IntPtr RGBFileImage, int RGBFileImageSize, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray, int TextureFlag, int ReverseFlag, System.IntPtr AlphaFileImage, int AlphaFileImageSize);
		public static int ReCreateDivGraphFFromMem(System.IntPtr RGBFileImage, int RGBFileImageSize, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray, int TextureFlag = TRUE, int ReverseFlag = FALSE, System.IntPtr AlphaFileImage = default, int AlphaFileImageSize = 0) => dx_ReCreateDivGraphFFromMem(RGBFileImage, RGBFileImageSize, AllNum, XNum, YNum, SizeX, SizeY, HandleArray, TextureFlag, ReverseFlag, AlphaFileImage, AlphaFileImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateGraph(int Width, int Height, int Pitch, System.IntPtr RGBImage, System.IntPtr AlphaImage, int GrHandle);
		public static int CreateGraph(int Width, int Height, int Pitch, System.IntPtr RGBImage, System.IntPtr AlphaImage = default, int GrHandle = -1) => dx_CreateGraph(Width, Height, Pitch, RGBImage, AlphaImage, GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateDivGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateDivGraph(int Width, int Height, int Pitch, System.IntPtr RGBImage, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray, System.IntPtr AlphaImage);
		public static int CreateDivGraph(int Width, int Height, int Pitch, System.IntPtr RGBImage, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray, System.IntPtr AlphaImage = default) => dx_CreateDivGraph(Width, Height, Pitch, RGBImage, AllNum, XNum, YNum, SizeX, SizeY, HandleArray, AlphaImage);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateDivGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateDivGraphF(int Width, int Height, int Pitch, System.IntPtr RGBImage, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray, System.IntPtr AlphaImage);
		public static int CreateDivGraphF(int Width, int Height, int Pitch, System.IntPtr RGBImage, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray, System.IntPtr AlphaImage = default) => dx_CreateDivGraphF(Width, Height, Pitch, RGBImage, AllNum, XNum, YNum, SizeX, SizeY, HandleArray, AlphaImage);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReCreateGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReCreateGraph(int Width, int Height, int Pitch, System.IntPtr RGBImage, int GrHandle, System.IntPtr AlphaImage);
		public static int ReCreateGraph(int Width, int Height, int Pitch, System.IntPtr RGBImage, int GrHandle, System.IntPtr AlphaImage = default) => dx_ReCreateGraph(Width, Height, Pitch, RGBImage, GrHandle, AlphaImage);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateBlendGraphFromSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateBlendGraphFromSoftImage(int SIHandle);
		public static int CreateBlendGraphFromSoftImage(int SIHandle) => dx_CreateBlendGraphFromSoftImage(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateGraphFromSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateGraphFromSoftImage(int SIHandle);
		public static int CreateGraphFromSoftImage(int SIHandle) => dx_CreateGraphFromSoftImage(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateGraphFromRectSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateGraphFromRectSoftImage(int SIHandle, int x, int y, int SizeX, int SizeY);
		public static int CreateGraphFromRectSoftImage(int SIHandle, int x, int y, int SizeX, int SizeY) => dx_CreateGraphFromRectSoftImage(SIHandle, x, y, SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReCreateGraphFromSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReCreateGraphFromSoftImage(int SIHandle, int GrHandle);
		public static int ReCreateGraphFromSoftImage(int SIHandle, int GrHandle) => dx_ReCreateGraphFromSoftImage(SIHandle, GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReCreateGraphFromRectSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReCreateGraphFromRectSoftImage(int SIHandle, int x, int y, int SizeX, int SizeY, int GrHandle);
		public static int ReCreateGraphFromRectSoftImage(int SIHandle, int x, int y, int SizeX, int SizeY, int GrHandle) => dx_ReCreateGraphFromRectSoftImage(SIHandle, x, y, SizeX, SizeY, GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateDivGraphFromSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateDivGraphFromSoftImage(int SIHandle, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray);
		public static int CreateDivGraphFromSoftImage(int SIHandle, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray) => dx_CreateDivGraphFromSoftImage(SIHandle, AllNum, XNum, YNum, SizeX, SizeY, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateDivGraphFFromSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateDivGraphFFromSoftImage(int SIHandle, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray);
		public static int CreateDivGraphFFromSoftImage(int SIHandle, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray) => dx_CreateDivGraphFFromSoftImage(SIHandle, AllNum, XNum, YNum, SizeX, SizeY, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReCreateDivGraphFromSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReCreateDivGraphFromSoftImage(int SIHandle, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray);
		public static int ReCreateDivGraphFromSoftImage(int SIHandle, int AllNum, int XNum, int YNum, int SizeX, int SizeY, [In, Out] int[] HandleArray) => dx_ReCreateDivGraphFromSoftImage(SIHandle, AllNum, XNum, YNum, SizeX, SizeY, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReCreateDivGraphFFromSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReCreateDivGraphFFromSoftImage(int SIHandle, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray);
		public static int ReCreateDivGraphFFromSoftImage(int SIHandle, int AllNum, int XNum, int YNum, float SizeX, float SizeY, [In, Out] int[] HandleArray) => dx_ReCreateDivGraphFFromSoftImage(SIHandle, AllNum, XNum, YNum, SizeX, SizeY, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadGraph(string FileName, int GrHandle, int ReverseFlag);
		public static int ReloadGraph(string FileName, int GrHandle, int ReverseFlag = FALSE) => dx_ReloadGraph(FileName, GrHandle, ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadGraphWithStrLen(string FileName, ulong FileNameLength, int GrHandle, int ReverseFlag);
		public static int ReloadGraphWithStrLen(string FileName, ulong FileNameLength, int GrHandle, int ReverseFlag = FALSE) => dx_ReloadGraphWithStrLen(FileName, FileNameLength, GrHandle, ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadDivGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadDivGraph(string FileName, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray, int ReverseFlag);
		public static int ReloadDivGraph(string FileName, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray, int ReverseFlag = FALSE) => dx_ReloadDivGraph(FileName, AllNum, XNum, YNum, XSize, YSize, HandleArray, ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadDivGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadDivGraphWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray, int ReverseFlag);
		public static int ReloadDivGraphWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray, int ReverseFlag = FALSE) => dx_ReloadDivGraphWithStrLen(FileName, FileNameLength, AllNum, XNum, YNum, XSize, YSize, HandleArray, ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadDivGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadDivGraphF(string FileName, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray, int ReverseFlag);
		public static int ReloadDivGraphF(string FileName, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray, int ReverseFlag = FALSE) => dx_ReloadDivGraphF(FileName, AllNum, XNum, YNum, XSize, YSize, HandleArray, ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadDivGraphFWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadDivGraphFWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray, int ReverseFlag);
		public static int ReloadDivGraphFWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray, int ReverseFlag = FALSE) => dx_ReloadDivGraphFWithStrLen(FileName, FileNameLength, AllNum, XNum, YNum, XSize, YSize, HandleArray, ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadReverseGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadReverseGraph(string FileName, int GrHandle);
		public static int ReloadReverseGraph(string FileName, int GrHandle) => dx_ReloadReverseGraph(FileName, GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadReverseGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadReverseGraphWithStrLen(string FileName, ulong FileNameLength, int GrHandle);
		public static int ReloadReverseGraphWithStrLen(string FileName, ulong FileNameLength, int GrHandle) => dx_ReloadReverseGraphWithStrLen(FileName, FileNameLength, GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadReverseDivGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadReverseDivGraph(string FileName, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray);
		public static int ReloadReverseDivGraph(string FileName, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray) => dx_ReloadReverseDivGraph(FileName, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadReverseDivGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadReverseDivGraphWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray);
		public static int ReloadReverseDivGraphWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray) => dx_ReloadReverseDivGraphWithStrLen(FileName, FileNameLength, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadReverseDivGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadReverseDivGraphF(string FileName, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray);
		public static int ReloadReverseDivGraphF(string FileName, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray) => dx_ReloadReverseDivGraphF(FileName, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReloadReverseDivGraphFWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReloadReverseDivGraphFWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray);
		public static int ReloadReverseDivGraphFWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray) => dx_ReloadReverseDivGraphFWithStrLen(FileName, FileNameLength, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetGraphColorBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetGraphColorBitDepth(int ColorBitDepth);
		public static int SetGraphColorBitDepth(int ColorBitDepth) => dx_SetGraphColorBitDepth(ColorBitDepth);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphColorBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetGraphColorBitDepth();
		public static int GetGraphColorBitDepth() => dx_GetGraphColorBitDepth();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreateGraphColorBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreateGraphColorBitDepth(int BitDepth);
		public static int SetCreateGraphColorBitDepth(int BitDepth) => dx_SetCreateGraphColorBitDepth(BitDepth);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCreateGraphColorBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCreateGraphColorBitDepth();
		public static int GetCreateGraphColorBitDepth() => dx_GetCreateGraphColorBitDepth();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreateGraphChannelBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreateGraphChannelBitDepth(int BitDepth);
		public static int SetCreateGraphChannelBitDepth(int BitDepth) => dx_SetCreateGraphChannelBitDepth(BitDepth);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCreateGraphChannelBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCreateGraphChannelBitDepth();
		public static int GetCreateGraphChannelBitDepth() => dx_GetCreateGraphChannelBitDepth();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawValidGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawValidGraphCreateFlag(int Flag);
		public static int SetDrawValidGraphCreateFlag(int Flag) => dx_SetDrawValidGraphCreateFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawValidGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawValidGraphCreateFlag();
		public static int GetDrawValidGraphCreateFlag() => dx_GetDrawValidGraphCreateFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawValidFlagOf3DGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawValidFlagOf3DGraph(int Flag);
		public static int SetDrawValidFlagOf3DGraph(int Flag) => dx_SetDrawValidFlagOf3DGraph(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLeftUpColorIsTransColorFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLeftUpColorIsTransColorFlag(int Flag);
		public static int SetLeftUpColorIsTransColorFlag(int Flag) => dx_SetLeftUpColorIsTransColorFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUsePaletteGraphFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUsePaletteGraphFlag(int Flag);
		public static int SetUsePaletteGraphFlag(int Flag) => dx_SetUsePaletteGraphFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseBlendGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseBlendGraphCreateFlag(int Flag);
		public static int SetUseBlendGraphCreateFlag(int Flag) => dx_SetUseBlendGraphCreateFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseBlendGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseBlendGraphCreateFlag();
		public static int GetUseBlendGraphCreateFlag() => dx_GetUseBlendGraphCreateFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseAlphaTestGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseAlphaTestGraphCreateFlag(int Flag);
		public static int SetUseAlphaTestGraphCreateFlag(int Flag) => dx_SetUseAlphaTestGraphCreateFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseAlphaTestGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseAlphaTestGraphCreateFlag();
		public static int GetUseAlphaTestGraphCreateFlag() => dx_GetUseAlphaTestGraphCreateFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseAlphaTestFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseAlphaTestFlag(int Flag);
		public static int SetUseAlphaTestFlag(int Flag) => dx_SetUseAlphaTestFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseAlphaTestFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseAlphaTestFlag();
		public static int GetUseAlphaTestFlag() => dx_GetUseAlphaTestFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCubeMapTextureCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCubeMapTextureCreateFlag(int Flag);
		public static int SetCubeMapTextureCreateFlag(int Flag) => dx_SetCubeMapTextureCreateFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCubeMapTextureCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCubeMapTextureCreateFlag();
		public static int GetCubeMapTextureCreateFlag() => dx_GetCubeMapTextureCreateFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseNoBlendModeParam", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseNoBlendModeParam(int Flag);
		public static int SetUseNoBlendModeParam(int Flag) => dx_SetUseNoBlendModeParam(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawValidAlphaChannelGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawValidAlphaChannelGraphCreateFlag(int Flag);
		public static int SetDrawValidAlphaChannelGraphCreateFlag(int Flag) => dx_SetDrawValidAlphaChannelGraphCreateFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawValidAlphaChannelGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawValidAlphaChannelGraphCreateFlag();
		public static int GetDrawValidAlphaChannelGraphCreateFlag() => dx_GetDrawValidAlphaChannelGraphCreateFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawValidFloatTypeGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawValidFloatTypeGraphCreateFlag(int Flag);
		public static int SetDrawValidFloatTypeGraphCreateFlag(int Flag) => dx_SetDrawValidFloatTypeGraphCreateFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawValidFloatTypeGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawValidFloatTypeGraphCreateFlag();
		public static int GetDrawValidFloatTypeGraphCreateFlag() => dx_GetDrawValidFloatTypeGraphCreateFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawValidGraphCreateZBufferFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawValidGraphCreateZBufferFlag(int Flag);
		public static int SetDrawValidGraphCreateZBufferFlag(int Flag) => dx_SetDrawValidGraphCreateZBufferFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawValidGraphCreateZBufferFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawValidGraphCreateZBufferFlag();
		public static int GetDrawValidGraphCreateZBufferFlag() => dx_GetDrawValidGraphCreateZBufferFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreateDrawValidGraphZBufferBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreateDrawValidGraphZBufferBitDepth(int BitDepth);
		public static int SetCreateDrawValidGraphZBufferBitDepth(int BitDepth) => dx_SetCreateDrawValidGraphZBufferBitDepth(BitDepth);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCreateDrawValidGraphZBufferBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCreateDrawValidGraphZBufferBitDepth();
		public static int GetCreateDrawValidGraphZBufferBitDepth() => dx_GetCreateDrawValidGraphZBufferBitDepth();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreateDrawValidGraphMipLevels", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreateDrawValidGraphMipLevels(int MipLevels);
		public static int SetCreateDrawValidGraphMipLevels(int MipLevels) => dx_SetCreateDrawValidGraphMipLevels(MipLevels);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCreateDrawValidGraphMipLevels", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCreateDrawValidGraphMipLevels();
		public static int GetCreateDrawValidGraphMipLevels() => dx_GetCreateDrawValidGraphMipLevels();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreateDrawValidGraphChannelNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreateDrawValidGraphChannelNum(int ChannelNum);
		public static int SetCreateDrawValidGraphChannelNum(int ChannelNum) => dx_SetCreateDrawValidGraphChannelNum(ChannelNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCreateDrawValidGraphChannelNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCreateDrawValidGraphChannelNum();
		public static int GetCreateDrawValidGraphChannelNum() => dx_GetCreateDrawValidGraphChannelNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreateDrawValidGraphMultiSample", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreateDrawValidGraphMultiSample(int Samples, int Quality);
		public static int SetCreateDrawValidGraphMultiSample(int Samples, int Quality) => dx_SetCreateDrawValidGraphMultiSample(Samples, Quality);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawValidMultiSample", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawValidMultiSample(int Samples, int Quality);
		public static int SetDrawValidMultiSample(int Samples, int Quality) => dx_SetDrawValidMultiSample(Samples, Quality);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMultiSampleQuality", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMultiSampleQuality(int Samples);
		public static int GetMultiSampleQuality(int Samples) => dx_GetMultiSampleQuality(Samples);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseTransColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseTransColor(int Flag);
		public static int SetUseTransColor(int Flag) => dx_SetUseTransColor(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseTransColorGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseTransColorGraphCreateFlag(int Flag);
		public static int SetUseTransColorGraphCreateFlag(int Flag) => dx_SetUseTransColorGraphCreateFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseGraphAlphaChannel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseGraphAlphaChannel(int Flag);
		public static int SetUseGraphAlphaChannel(int Flag) => dx_SetUseGraphAlphaChannel(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseGraphAlphaChannel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseGraphAlphaChannel();
		public static int GetUseGraphAlphaChannel() => dx_GetUseGraphAlphaChannel();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseAlphaChannelGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseAlphaChannelGraphCreateFlag(int Flag);
		public static int SetUseAlphaChannelGraphCreateFlag(int Flag) => dx_SetUseAlphaChannelGraphCreateFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseAlphaChannelGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseAlphaChannelGraphCreateFlag();
		public static int GetUseAlphaChannelGraphCreateFlag() => dx_GetUseAlphaChannelGraphCreateFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseNotManageTextureFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseNotManageTextureFlag(int Flag);
		public static int SetUseNotManageTextureFlag(int Flag) => dx_SetUseNotManageTextureFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseNotManageTextureFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseNotManageTextureFlag();
		public static int GetUseNotManageTextureFlag() => dx_GetUseNotManageTextureFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUsePlatformTextureFormat", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUsePlatformTextureFormat(int PlatformTextureFormat);
		public static int SetUsePlatformTextureFormat(int PlatformTextureFormat) => dx_SetUsePlatformTextureFormat(PlatformTextureFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUsePlatformTextureFormat", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUsePlatformTextureFormat();
		public static int GetUsePlatformTextureFormat() => dx_GetUsePlatformTextureFormat();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTransColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTransColor(int Red, int Green, int Blue);
		public static int SetTransColor(int Red, int Green, int Blue) => dx_SetTransColor(Red, Green, Blue);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransColor(out int Red, out int Green, out int Blue);
		public static int GetTransColor(out int Red, out int Green, out int Blue) => dx_GetTransColor(out Red, out Green, out Blue);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDivGraphFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDivGraphFlag(int Flag);
		public static int SetUseDivGraphFlag(int Flag) => dx_SetUseDivGraphFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseAlphaImageLoadFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseAlphaImageLoadFlag(int Flag);
		public static int SetUseAlphaImageLoadFlag(int Flag) => dx_SetUseAlphaImageLoadFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseMaxTextureSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseMaxTextureSize(int Size);
		public static int SetUseMaxTextureSize(int Size) => dx_SetUseMaxTextureSize(Size);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseGraphBaseDataBackup", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseGraphBaseDataBackup(int Flag);
		public static int SetUseGraphBaseDataBackup(int Flag) => dx_SetUseGraphBaseDataBackup(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseGraphBaseDataBackup", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseGraphBaseDataBackup();
		public static int GetUseGraphBaseDataBackup() => dx_GetUseGraphBaseDataBackup();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseSystemMemGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseSystemMemGraphCreateFlag(int Flag);
		public static int SetUseSystemMemGraphCreateFlag(int Flag) => dx_SetUseSystemMemGraphCreateFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseSystemMemGraphCreateFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseSystemMemGraphCreateFlag();
		public static int GetUseSystemMemGraphCreateFlag() => dx_GetUseSystemMemGraphCreateFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GraphUnLock", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GraphUnLock(int GrHandle);
		public static int GraphUnLock(int GrHandle) => dx_GraphUnLock(GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseGraphZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseGraphZBuffer(int GrHandle, int UseFlag, int BitDepth);
		public static int SetUseGraphZBuffer(int GrHandle, int UseFlag, int BitDepth = -1) => dx_SetUseGraphZBuffer(GrHandle, UseFlag, BitDepth);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CopyGraphZBufferImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CopyGraphZBufferImage(int DestGrHandle, int SrcGrHandle);
		public static int CopyGraphZBufferImage(int DestGrHandle, int SrcGrHandle) => dx_CopyGraphZBufferImage(DestGrHandle, SrcGrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDeviceLostDeleteGraphFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDeviceLostDeleteGraphFlag(int GrHandle, int DeleteFlag);
		public static int SetDeviceLostDeleteGraphFlag(int GrHandle, int DeleteFlag) => dx_SetDeviceLostDeleteGraphFlag(GrHandle, DeleteFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetGraphSize(int GrHandle, out int SizeXBuf, out int SizeYBuf);
		public static int GetGraphSize(int GrHandle, out int SizeXBuf, out int SizeYBuf) => dx_GetGraphSize(GrHandle, out SizeXBuf, out SizeYBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphSizeF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetGraphSizeF(int GrHandle, out float SizeXBuf, out float SizeYBuf);
		public static int GetGraphSizeF(int GrHandle, out float SizeXBuf, out float SizeYBuf) => dx_GetGraphSizeF(GrHandle, out SizeXBuf, out SizeYBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphTextureSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetGraphTextureSize(int GrHandle, out int SizeXBuf, out int SizeYBuf);
		public static int GetGraphTextureSize(int GrHandle, out int SizeXBuf, out int SizeYBuf) => dx_GetGraphTextureSize(GrHandle, out SizeXBuf, out SizeYBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphUseBaseGraphArea", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetGraphUseBaseGraphArea(int GrHandle, out int UseX, out int UseY, out int UseSizeX, out int UseSizeY);
		public static int GetGraphUseBaseGraphArea(int GrHandle, out int UseX, out int UseY, out int UseSizeX, out int UseSizeY) => dx_GetGraphUseBaseGraphArea(GrHandle, out UseX, out UseY, out UseSizeX, out UseSizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphMipmapCount", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetGraphMipmapCount(int GrHandle);
		public static int GetGraphMipmapCount(int GrHandle) => dx_GetGraphMipmapCount(GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphFilePath", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetGraphFilePath(int GrHandle, System.Text.StringBuilder FilePathBuffer);
		public static int GetGraphFilePath(int GrHandle, System.Text.StringBuilder FilePathBuffer) => dx_GetGraphFilePath(GrHandle, FilePathBuffer);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckDrawValidGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckDrawValidGraph(int GrHandle);
		public static int CheckDrawValidGraph(int GrHandle) => dx_CheckDrawValidGraph(GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMaxGraphTextureSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMaxGraphTextureSize(out int SizeX, out int SizeY);
		public static int GetMaxGraphTextureSize(out int SizeX, out int SizeY) => dx_GetMaxGraphTextureSize(out SizeX, out SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetValidRestoreShredPoint", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetValidRestoreShredPoint();
		public static int GetValidRestoreShredPoint() => dx_GetValidRestoreShredPoint();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCreateGraphColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCreateGraphColorData(out COLORDATA ColorData, out IMAGEFORMATDESC Format);
		public static int GetCreateGraphColorData(out COLORDATA ColorData, out IMAGEFORMATDESC Format) => dx_GetCreateGraphColorData(out ColorData, out Format);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphPalette", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetGraphPalette(int GrHandle, int ColorIndex, out int Red, out int Green, out int Blue);
		public static int GetGraphPalette(int GrHandle, int ColorIndex, out int Red, out int Green, out int Blue) => dx_GetGraphPalette(GrHandle, ColorIndex, out Red, out Green, out Blue);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphOriginalPalette", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetGraphOriginalPalette(int GrHandle, int ColorIndex, out int Red, out int Green, out int Blue);
		public static int GetGraphOriginalPalette(int GrHandle, int ColorIndex, out int Red, out int Green, out int Blue) => dx_GetGraphOriginalPalette(GrHandle, ColorIndex, out Red, out Green, out Blue);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetGraphPalette", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetGraphPalette(int GrHandle, int ColorIndex, uint Color);
		public static int SetGraphPalette(int GrHandle, int ColorIndex, uint Color) => dx_SetGraphPalette(GrHandle, ColorIndex, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetGraphPalette", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetGraphPalette(int GrHandle);
		public static int ResetGraphPalette(int GrHandle) => dx_ResetGraphPalette(GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawLine", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawLine(int x1, int y1, int x2, int y2, uint Color, int Thickness);
		public static int DrawLine(int x1, int y1, int x2, int y2, uint Color, int Thickness = 1) => dx_DrawLine(x1, y1, x2, y2, Color, Thickness);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawLineAA", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawLineAA(float x1, float y1, float x2, float y2, uint Color, float Thickness);
		public static int DrawLineAA(float x1, float y1, float x2, float y2, uint Color, float Thickness = default) => dx_DrawLineAA(x1, y1, x2, y2, Color, Thickness);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawBox", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawBox(int x1, int y1, int x2, int y2, uint Color, int FillFlag);
		public static int DrawBox(int x1, int y1, int x2, int y2, uint Color, int FillFlag) => dx_DrawBox(x1, y1, x2, y2, Color, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawBoxAA", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawBoxAA(float x1, float y1, float x2, float y2, uint Color, int FillFlag, float LineThickness);
		public static int DrawBoxAA(float x1, float y1, float x2, float y2, uint Color, int FillFlag, float LineThickness = default) => dx_DrawBoxAA(x1, y1, x2, y2, Color, FillFlag, LineThickness);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFillBox", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFillBox(int x1, int y1, int x2, int y2, uint Color);
		public static int DrawFillBox(int x1, int y1, int x2, int y2, uint Color) => dx_DrawFillBox(x1, y1, x2, y2, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawLineBox", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawLineBox(int x1, int y1, int x2, int y2, uint Color);
		public static int DrawLineBox(int x1, int y1, int x2, int y2, uint Color) => dx_DrawLineBox(x1, y1, x2, y2, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCircle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCircle(int x, int y, int r, uint Color, int FillFlag, int LineThickness);
		public static int DrawCircle(int x, int y, int r, uint Color, int FillFlag = TRUE, int LineThickness = 1) => dx_DrawCircle(x, y, r, Color, FillFlag, LineThickness);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCircleAA", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCircleAA(float x, float y, float r, int posnum, uint Color, int FillFlag, float LineThickness);
		public static int DrawCircleAA(float x, float y, float r, int posnum, uint Color, int FillFlag = TRUE, float LineThickness = default) => dx_DrawCircleAA(x, y, r, posnum, Color, FillFlag, LineThickness);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawOval", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawOval(int x, int y, int rx, int ry, uint Color, int FillFlag, int LineThickness);
		public static int DrawOval(int x, int y, int rx, int ry, uint Color, int FillFlag, int LineThickness = 1) => dx_DrawOval(x, y, rx, ry, Color, FillFlag, LineThickness);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawOvalAA", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawOvalAA(float x, float y, float rx, float ry, int posnum, uint Color, int FillFlag, float LineThickness);
		public static int DrawOvalAA(float x, float y, float rx, float ry, int posnum, uint Color, int FillFlag, float LineThickness = default) => dx_DrawOvalAA(x, y, rx, ry, posnum, Color, FillFlag, LineThickness);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawOval_Rect", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawOval_Rect(int x1, int y1, int x2, int y2, uint Color, int FillFlag);
		public static int DrawOval_Rect(int x1, int y1, int x2, int y2, uint Color, int FillFlag) => dx_DrawOval_Rect(x1, y1, x2, y2, Color, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawTriangle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawTriangle(int x1, int y1, int x2, int y2, int x3, int y3, uint Color, int FillFlag);
		public static int DrawTriangle(int x1, int y1, int x2, int y2, int x3, int y3, uint Color, int FillFlag) => dx_DrawTriangle(x1, y1, x2, y2, x3, y3, Color, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawTriangleAA", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawTriangleAA(float x1, float y1, float x2, float y2, float x3, float y3, uint Color, int FillFlag, float LineThickness);
		public static int DrawTriangleAA(float x1, float y1, float x2, float y2, float x3, float y3, uint Color, int FillFlag, float LineThickness = default) => dx_DrawTriangleAA(x1, y1, x2, y2, x3, y3, Color, FillFlag, LineThickness);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawQuadrangle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawQuadrangle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, int FillFlag);
		public static int DrawQuadrangle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, int FillFlag) => dx_DrawQuadrangle(x1, y1, x2, y2, x3, y3, x4, y4, Color, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawQuadrangleAA", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawQuadrangleAA(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, int FillFlag, float LineThickness);
		public static int DrawQuadrangleAA(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, int FillFlag, float LineThickness = default) => dx_DrawQuadrangleAA(x1, y1, x2, y2, x3, y3, x4, y4, Color, FillFlag, LineThickness);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRoundRect", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRoundRect(int x1, int y1, int x2, int y2, int rx, int ry, uint Color, int FillFlag);
		public static int DrawRoundRect(int x1, int y1, int x2, int y2, int rx, int ry, uint Color, int FillFlag) => dx_DrawRoundRect(x1, y1, x2, y2, rx, ry, Color, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRoundRectAA", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRoundRectAA(float x1, float y1, float x2, float y2, float rx, float ry, int posnum, uint Color, int FillFlag, float LineThickness);
		public static int DrawRoundRectAA(float x1, float y1, float x2, float y2, float rx, float ry, int posnum, uint Color, int FillFlag, float LineThickness = default) => dx_DrawRoundRectAA(x1, y1, x2, y2, rx, ry, posnum, Color, FillFlag, LineThickness);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_BeginAADraw", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_BeginAADraw();
		public static int BeginAADraw() => dx_BeginAADraw();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_EndAADraw", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_EndAADraw();
		public static int EndAADraw() => dx_EndAADraw();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPixel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPixel(int x, int y, uint Color);
		public static int DrawPixel(int x, int y, uint Color) => dx_DrawPixel(x, y, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPixelSet", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPixelSet([In, Out] POINTDATA[] PointDataArray, int Num);
		public static int DrawPixelSet([In, Out] POINTDATA[] PointDataArray, int Num) => dx_DrawPixelSet(PointDataArray, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawLineSet", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawLineSet([In, Out] LINEDATA[] LineDataArray, int Num);
		public static int DrawLineSet([In, Out] LINEDATA[] LineDataArray, int Num) => dx_DrawLineSet(LineDataArray, Num);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPixel3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPixel3D(VECTOR Pos, uint Color);
		public static int DrawPixel3D(VECTOR Pos, uint Color) => dx_DrawPixel3D(Pos, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPixel3DD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPixel3DD(VECTOR_D Pos, uint Color);
		public static int DrawPixel3DD(VECTOR_D Pos, uint Color) => dx_DrawPixel3DD(Pos, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawLine3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawLine3D(VECTOR Pos1, VECTOR Pos2, uint Color);
		public static int DrawLine3D(VECTOR Pos1, VECTOR Pos2, uint Color) => dx_DrawLine3D(Pos1, Pos2, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawLine3DD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawLine3DD(VECTOR_D Pos1, VECTOR_D Pos2, uint Color);
		public static int DrawLine3DD(VECTOR_D Pos1, VECTOR_D Pos2, uint Color) => dx_DrawLine3DD(Pos1, Pos2, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawTriangle3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawTriangle3D(VECTOR Pos1, VECTOR Pos2, VECTOR Pos3, uint Color, int FillFlag);
		public static int DrawTriangle3D(VECTOR Pos1, VECTOR Pos2, VECTOR Pos3, uint Color, int FillFlag) => dx_DrawTriangle3D(Pos1, Pos2, Pos3, Color, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawTriangle3DD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawTriangle3DD(VECTOR_D Pos1, VECTOR_D Pos2, VECTOR_D Pos3, uint Color, int FillFlag);
		public static int DrawTriangle3DD(VECTOR_D Pos1, VECTOR_D Pos2, VECTOR_D Pos3, uint Color, int FillFlag) => dx_DrawTriangle3DD(Pos1, Pos2, Pos3, Color, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCube3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCube3D(VECTOR Pos1, VECTOR Pos2, uint DifColor, uint SpcColor, int FillFlag);
		public static int DrawCube3D(VECTOR Pos1, VECTOR Pos2, uint DifColor, uint SpcColor, int FillFlag) => dx_DrawCube3D(Pos1, Pos2, DifColor, SpcColor, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCube3DD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCube3DD(VECTOR_D Pos1, VECTOR_D Pos2, uint DifColor, uint SpcColor, int FillFlag);
		public static int DrawCube3DD(VECTOR_D Pos1, VECTOR_D Pos2, uint DifColor, uint SpcColor, int FillFlag) => dx_DrawCube3DD(Pos1, Pos2, DifColor, SpcColor, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCubeSet3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCubeSet3D([In, Out] CUBEDATA[] CubeDataArray, int Num, int FillFlag);
		public static int DrawCubeSet3D([In, Out] CUBEDATA[] CubeDataArray, int Num, int FillFlag) => dx_DrawCubeSet3D(CubeDataArray, Num, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawSphere3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawSphere3D(VECTOR CenterPos, float r, int DivNum, uint DifColor, uint SpcColor, int FillFlag);
		public static int DrawSphere3D(VECTOR CenterPos, float r, int DivNum, uint DifColor, uint SpcColor, int FillFlag) => dx_DrawSphere3D(CenterPos, r, DivNum, DifColor, SpcColor, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawSphere3DD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawSphere3DD(VECTOR_D CenterPos, double r, int DivNum, uint DifColor, uint SpcColor, int FillFlag);
		public static int DrawSphere3DD(VECTOR_D CenterPos, double r, int DivNum, uint DifColor, uint SpcColor, int FillFlag) => dx_DrawSphere3DD(CenterPos, r, DivNum, DifColor, SpcColor, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCapsule3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCapsule3D(VECTOR Pos1, VECTOR Pos2, float r, int DivNum, uint DifColor, uint SpcColor, int FillFlag);
		public static int DrawCapsule3D(VECTOR Pos1, VECTOR Pos2, float r, int DivNum, uint DifColor, uint SpcColor, int FillFlag) => dx_DrawCapsule3D(Pos1, Pos2, r, DivNum, DifColor, SpcColor, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCapsule3DD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCapsule3DD(VECTOR_D Pos1, VECTOR_D Pos2, double r, int DivNum, uint DifColor, uint SpcColor, int FillFlag);
		public static int DrawCapsule3DD(VECTOR_D Pos1, VECTOR_D Pos2, double r, int DivNum, uint DifColor, uint SpcColor, int FillFlag) => dx_DrawCapsule3DD(Pos1, Pos2, r, DivNum, DifColor, SpcColor, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCone3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCone3D(VECTOR TopPos, VECTOR BottomPos, float r, int DivNum, uint DifColor, uint SpcColor, int FillFlag);
		public static int DrawCone3D(VECTOR TopPos, VECTOR BottomPos, float r, int DivNum, uint DifColor, uint SpcColor, int FillFlag) => dx_DrawCone3D(TopPos, BottomPos, r, DivNum, DifColor, SpcColor, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCone3DD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCone3DD(VECTOR_D TopPos, VECTOR_D BottomPos, double r, int DivNum, uint DifColor, uint SpcColor, int FillFlag);
		public static int DrawCone3DD(VECTOR_D TopPos, VECTOR_D BottomPos, double r, int DivNum, uint DifColor, uint SpcColor, int FillFlag) => dx_DrawCone3DD(TopPos, BottomPos, r, DivNum, DifColor, SpcColor, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadGraphScreen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadGraphScreen(int x, int y, string GraphName, int TransFlag);
		public static int LoadGraphScreen(int x, int y, string GraphName, int TransFlag) => dx_LoadGraphScreen(x, y, GraphName, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadGraphScreenWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadGraphScreenWithStrLen(int x, int y, string GraphName, ulong GraphNameLength, int TransFlag);
		public static int LoadGraphScreenWithStrLen(int x, int y, string GraphName, ulong GraphNameLength, int TransFlag) => dx_LoadGraphScreenWithStrLen(x, y, GraphName, GraphNameLength, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawGraph(int x, int y, int GrHandle, int TransFlag);
		public static int DrawGraph(int x, int y, int GrHandle, int TransFlag) => dx_DrawGraph(x, y, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendGraph(int x1, int y1, int x2, int y2, int GrHandle, int TransFlag);
		public static int DrawExtendGraph(int x1, int y1, int x2, int y2, int GrHandle, int TransFlag) => dx_DrawExtendGraph(x1, y1, x2, y2, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraph(int x, int y, double ExRate, double Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraph(int x, int y, double ExRate, double Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraph(x, y, ExRate, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraph2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraph2(int x, int y, int cx, int cy, double ExtRate, double Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraph2(int x, int y, int cx, int cy, double ExtRate, double Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraph2(x, y, cx, cy, ExtRate, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraph3", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraph3(int x, int y, int cx, int cy, double ExtRateX, double ExtRateY, double Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraph3(int x, int y, int cx, int cy, double ExtRateX, double ExtRateY, double Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraph3(x, y, cx, cy, ExtRateX, ExtRateY, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraphFast", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraphFast(int x, int y, float ExRate, float Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraphFast(int x, int y, float ExRate, float Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraphFast(x, y, ExRate, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraphFast2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraphFast2(int x, int y, int cx, int cy, float ExtRate, float Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraphFast2(int x, int y, int cx, int cy, float ExtRate, float Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraphFast2(x, y, cx, cy, ExtRate, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraphFast3", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraphFast3(int x, int y, int cx, int cy, float ExtRateX, float ExtRateY, float Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraphFast3(int x, int y, int cx, int cy, float ExtRateX, float ExtRateY, float Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraphFast3(x, y, cx, cy, ExtRateX, ExtRateY, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiGraph(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int GrHandle, int TransFlag);
		public static int DrawModiGraph(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int GrHandle, int TransFlag) => dx_DrawModiGraph(x1, y1, x2, y2, x3, y3, x4, y4, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawTurnGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawTurnGraph(int x, int y, int GrHandle, int TransFlag);
		public static int DrawTurnGraph(int x, int y, int GrHandle, int TransFlag) => dx_DrawTurnGraph(x, y, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawReverseGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawReverseGraph(int x, int y, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawReverseGraph(int x, int y, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawReverseGraph(x, y, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawGraphF(float xf, float yf, int GrHandle, int TransFlag);
		public static int DrawGraphF(float xf, float yf, int GrHandle, int TransFlag) => dx_DrawGraphF(xf, yf, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendGraphF(float x1f, float y1f, float x2f, float y2, int GrHandle, int TransFlag);
		public static int DrawExtendGraphF(float x1f, float y1f, float x2f, float y2, int GrHandle, int TransFlag) => dx_DrawExtendGraphF(x1f, y1f, x2f, y2, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraphF(float xf, float yf, double ExRate, double Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraphF(float xf, float yf, double ExRate, double Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraphF(xf, yf, ExRate, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraph2F", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraph2F(float xf, float yf, float cxf, float cyf, double ExtRate, double Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraph2F(float xf, float yf, float cxf, float cyf, double ExtRate, double Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraph2F(xf, yf, cxf, cyf, ExtRate, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraph3F", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraph3F(float xf, float yf, float cxf, float cyf, double ExtRateX, double ExtRateY, double Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraph3F(float xf, float yf, float cxf, float cyf, double ExtRateX, double ExtRateY, double Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraph3F(xf, yf, cxf, cyf, ExtRateX, ExtRateY, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraphFastF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraphFastF(float xf, float yf, float ExRate, float Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraphFastF(float xf, float yf, float ExRate, float Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraphFastF(xf, yf, ExRate, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraphFast2F", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraphFast2F(float xf, float yf, float cxf, float cyf, float ExtRate, float Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraphFast2F(float xf, float yf, float cxf, float cyf, float ExtRate, float Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraphFast2F(xf, yf, cxf, cyf, ExtRate, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraphFast3F", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraphFast3F(float xf, float yf, float cxf, float cyf, float ExtRateX, float ExtRateY, float Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraphFast3F(float xf, float yf, float cxf, float cyf, float ExtRateX, float ExtRateY, float Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraphFast3F(xf, yf, cxf, cyf, ExtRateX, ExtRateY, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiGraphF(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, int GrHandle, int TransFlag);
		public static int DrawModiGraphF(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, int GrHandle, int TransFlag) => dx_DrawModiGraphF(x1, y1, x2, y2, x3, y3, x4, y4, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawTurnGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawTurnGraphF(float xf, float yf, int GrHandle, int TransFlag);
		public static int DrawTurnGraphF(float xf, float yf, int GrHandle, int TransFlag) => dx_DrawTurnGraphF(xf, yf, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawReverseGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawReverseGraphF(float xf, float yf, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawReverseGraphF(float xf, float yf, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawReverseGraphF(xf, yf, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawTile", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawTile(int x1, int y1, int x2, int y2, int Tx, int Ty, double ExtRate, double Angle, int GrHandle, int TransFlag);
		public static int DrawTile(int x1, int y1, int x2, int y2, int Tx, int Ty, double ExtRate, double Angle, int GrHandle, int TransFlag) => dx_DrawTile(x1, y1, x2, y2, Tx, Ty, ExtRate, Angle, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectGraph(int DestX, int DestY, int SrcX, int SrcY, int Width, int Height, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectGraph(int DestX, int DestY, int SrcX, int SrcY, int Width, int Height, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectGraph(DestX, DestY, SrcX, SrcY, Width, Height, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectExtendGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectExtendGraph(int DestX1, int DestY1, int DestX2, int DestY2, int SrcX, int SrcY, int SrcWidth, int SrcHeight, int GraphHandle, int TransFlag);
		public static int DrawRectExtendGraph(int DestX1, int DestY1, int DestX2, int DestY2, int SrcX, int SrcY, int SrcWidth, int SrcHeight, int GraphHandle, int TransFlag) => dx_DrawRectExtendGraph(DestX1, DestY1, DestX2, DestY2, SrcX, SrcY, SrcWidth, SrcHeight, GraphHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectRotaGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectRotaGraph(int x, int y, int SrcX, int SrcY, int Width, int Height, double ExtRate, double Angle, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectRotaGraph(int x, int y, int SrcX, int SrcY, int Width, int Height, double ExtRate, double Angle, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectRotaGraph(x, y, SrcX, SrcY, Width, Height, ExtRate, Angle, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectRotaGraph2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectRotaGraph2(int x, int y, int SrcX, int SrcY, int Width, int Height, int cx, int cy, double ExtRate, double Angle, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectRotaGraph2(int x, int y, int SrcX, int SrcY, int Width, int Height, int cx, int cy, double ExtRate, double Angle, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectRotaGraph2(x, y, SrcX, SrcY, Width, Height, cx, cy, ExtRate, Angle, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectRotaGraph3", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectRotaGraph3(int x, int y, int SrcX, int SrcY, int Width, int Height, int cx, int cy, double ExtRateX, double ExtRateY, double Angle, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectRotaGraph3(int x, int y, int SrcX, int SrcY, int Width, int Height, int cx, int cy, double ExtRateX, double ExtRateY, double Angle, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectRotaGraph3(x, y, SrcX, SrcY, Width, Height, cx, cy, ExtRateX, ExtRateY, Angle, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectRotaGraphFast", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectRotaGraphFast(int x, int y, int SrcX, int SrcY, int Width, int Height, float ExtRate, float Angle, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectRotaGraphFast(int x, int y, int SrcX, int SrcY, int Width, int Height, float ExtRate, float Angle, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectRotaGraphFast(x, y, SrcX, SrcY, Width, Height, ExtRate, Angle, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectRotaGraphFast2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectRotaGraphFast2(int x, int y, int SrcX, int SrcY, int Width, int Height, int cx, int cy, float ExtRate, float Angle, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectRotaGraphFast2(int x, int y, int SrcX, int SrcY, int Width, int Height, int cx, int cy, float ExtRate, float Angle, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectRotaGraphFast2(x, y, SrcX, SrcY, Width, Height, cx, cy, ExtRate, Angle, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectRotaGraphFast3", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectRotaGraphFast3(int x, int y, int SrcX, int SrcY, int Width, int Height, int cx, int cy, float ExtRateX, float ExtRateY, float Angle, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectRotaGraphFast3(int x, int y, int SrcX, int SrcY, int Width, int Height, int cx, int cy, float ExtRateX, float ExtRateY, float Angle, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectRotaGraphFast3(x, y, SrcX, SrcY, Width, Height, cx, cy, ExtRateX, ExtRateY, Angle, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectModiGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectModiGraph(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int SrcX, int SrcY, int Width, int Height, int GraphHandle, int TransFlag);
		public static int DrawRectModiGraph(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int SrcX, int SrcY, int Width, int Height, int GraphHandle, int TransFlag) => dx_DrawRectModiGraph(x1, y1, x2, y2, x3, y3, x4, y4, SrcX, SrcY, Width, Height, GraphHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectGraphF(float DestX, float DestY, int SrcX, int SrcY, int Width, int Height, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectGraphF(float DestX, float DestY, int SrcX, int SrcY, int Width, int Height, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectGraphF(DestX, DestY, SrcX, SrcY, Width, Height, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectExtendGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectExtendGraphF(float DestX1, float DestY1, float DestX2, float DestY2, int SrcX, int SrcY, int SrcWidth, int SrcHeight, int GraphHandle, int TransFlag);
		public static int DrawRectExtendGraphF(float DestX1, float DestY1, float DestX2, float DestY2, int SrcX, int SrcY, int SrcWidth, int SrcHeight, int GraphHandle, int TransFlag) => dx_DrawRectExtendGraphF(DestX1, DestY1, DestX2, DestY2, SrcX, SrcY, SrcWidth, SrcHeight, GraphHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectRotaGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectRotaGraphF(float x, float y, int SrcX, int SrcY, int Width, int Height, double ExtRate, double Angle, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectRotaGraphF(float x, float y, int SrcX, int SrcY, int Width, int Height, double ExtRate, double Angle, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectRotaGraphF(x, y, SrcX, SrcY, Width, Height, ExtRate, Angle, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectRotaGraph2F", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectRotaGraph2F(float x, float y, int SrcX, int SrcY, int Width, int Height, float cxf, float cyf, double ExtRate, double Angle, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectRotaGraph2F(float x, float y, int SrcX, int SrcY, int Width, int Height, float cxf, float cyf, double ExtRate, double Angle, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectRotaGraph2F(x, y, SrcX, SrcY, Width, Height, cxf, cyf, ExtRate, Angle, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectRotaGraph3F", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectRotaGraph3F(float x, float y, int SrcX, int SrcY, int Width, int Height, float cxf, float cyf, double ExtRateX, double ExtRateY, double Angle, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectRotaGraph3F(float x, float y, int SrcX, int SrcY, int Width, int Height, float cxf, float cyf, double ExtRateX, double ExtRateY, double Angle, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectRotaGraph3F(x, y, SrcX, SrcY, Width, Height, cxf, cyf, ExtRateX, ExtRateY, Angle, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectRotaGraphFastF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectRotaGraphFastF(float x, float y, int SrcX, int SrcY, int Width, int Height, float ExtRate, float Angle, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectRotaGraphFastF(float x, float y, int SrcX, int SrcY, int Width, int Height, float ExtRate, float Angle, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectRotaGraphFastF(x, y, SrcX, SrcY, Width, Height, ExtRate, Angle, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectRotaGraphFast2F", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectRotaGraphFast2F(float x, float y, int SrcX, int SrcY, int Width, int Height, float cxf, float cyf, float ExtRate, float Angle, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectRotaGraphFast2F(float x, float y, int SrcX, int SrcY, int Width, int Height, float cxf, float cyf, float ExtRate, float Angle, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectRotaGraphFast2F(x, y, SrcX, SrcY, Width, Height, cxf, cyf, ExtRate, Angle, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectRotaGraphFast3F", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectRotaGraphFast3F(float x, float y, int SrcX, int SrcY, int Width, int Height, float cxf, float cyf, float ExtRateX, float ExtRateY, float Angle, int GraphHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRectRotaGraphFast3F(float x, float y, int SrcX, int SrcY, int Width, int Height, float cxf, float cyf, float ExtRateX, float ExtRateY, float Angle, int GraphHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRectRotaGraphFast3F(x, y, SrcX, SrcY, Width, Height, cxf, cyf, ExtRateX, ExtRateY, Angle, GraphHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRectModiGraphF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRectModiGraphF(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, int SrcX, int SrcY, int Width, int Height, int GraphHandle, int TransFlag);
		public static int DrawRectModiGraphF(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, int SrcX, int SrcY, int Width, int Height, int GraphHandle, int TransFlag) => dx_DrawRectModiGraphF(x1, y1, x2, y2, x3, y3, x4, y4, SrcX, SrcY, Width, Height, GraphHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawBlendGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawBlendGraph(int x, int y, int GrHandle, int TransFlag, int BlendGraph, int BorderParam, int BorderRange);
		public static int DrawBlendGraph(int x, int y, int GrHandle, int TransFlag, int BlendGraph, int BorderParam, int BorderRange) => dx_DrawBlendGraph(x, y, GrHandle, TransFlag, BlendGraph, BorderParam, BorderRange);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawBlendGraphPos", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawBlendGraphPos(int x, int y, int GrHandle, int TransFlag, int bx, int by, int BlendGraph, int BorderParam, int BorderRange);
		public static int DrawBlendGraphPos(int x, int y, int GrHandle, int TransFlag, int bx, int by, int BlendGraph, int BorderParam, int BorderRange) => dx_DrawBlendGraphPos(x, y, GrHandle, TransFlag, bx, by, BlendGraph, BorderParam, BorderRange);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCircleGauge", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCircleGauge(int CenterX, int CenterY, double Percent, int GrHandle, double StartPercent, double Scale, int ReverseX, int ReverseY);
		public static int DrawCircleGauge(int CenterX, int CenterY, double Percent, int GrHandle, double StartPercent = default, double Scale = default, int ReverseX = FALSE, int ReverseY = FALSE) => dx_DrawCircleGauge(CenterX, CenterY, Percent, GrHandle, StartPercent, Scale, ReverseX, ReverseY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCircleGaugeF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCircleGaugeF(float CenterX, float CenterY, double Percent, int GrHandle, double StartPercent, double Scale, int ReverseX, int ReverseY);
		public static int DrawCircleGaugeF(float CenterX, float CenterY, double Percent, int GrHandle, double StartPercent = default, double Scale = default, int ReverseX = FALSE, int ReverseY = FALSE) => dx_DrawCircleGaugeF(CenterX, CenterY, Percent, GrHandle, StartPercent, Scale, ReverseX, ReverseY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawGraphToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawGraphToZBuffer(int X, int Y, int GrHandle, int WriteZMode);
		public static int DrawGraphToZBuffer(int X, int Y, int GrHandle, int WriteZMode) => dx_DrawGraphToZBuffer(X, Y, GrHandle, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawTurnGraphToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawTurnGraphToZBuffer(int x, int y, int GrHandle, int WriteZMode);
		public static int DrawTurnGraphToZBuffer(int x, int y, int GrHandle, int WriteZMode) => dx_DrawTurnGraphToZBuffer(x, y, GrHandle, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawReverseGraphToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawReverseGraphToZBuffer(int x, int y, int GrHandle, int WriteZMode, int ReverseXFlag, int ReverseYFlag);
		public static int DrawReverseGraphToZBuffer(int x, int y, int GrHandle, int WriteZMode, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawReverseGraphToZBuffer(x, y, GrHandle, WriteZMode, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendGraphToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendGraphToZBuffer(int x1, int y1, int x2, int y2, int GrHandle, int WriteZMode);
		public static int DrawExtendGraphToZBuffer(int x1, int y1, int x2, int y2, int GrHandle, int WriteZMode) => dx_DrawExtendGraphToZBuffer(x1, y1, x2, y2, GrHandle, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraphToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraphToZBuffer(int x, int y, double ExRate, double Angle, int GrHandle, int WriteZMode, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraphToZBuffer(int x, int y, double ExRate, double Angle, int GrHandle, int WriteZMode, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraphToZBuffer(x, y, ExRate, Angle, GrHandle, WriteZMode, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraph2ToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraph2ToZBuffer(int x, int y, int cx, int cy, double ExtRate, double Angle, int GrHandle, int WriteZMode, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraph2ToZBuffer(int x, int y, int cx, int cy, double ExtRate, double Angle, int GrHandle, int WriteZMode, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraph2ToZBuffer(x, y, cx, cy, ExtRate, Angle, GrHandle, WriteZMode, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraph3ToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraph3ToZBuffer(int x, int y, int cx, int cy, double ExtRateX, double ExtRateY, double Angle, int GrHandle, int WriteZMode, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraph3ToZBuffer(int x, int y, int cx, int cy, double ExtRateX, double ExtRateY, double Angle, int GrHandle, int WriteZMode, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraph3ToZBuffer(x, y, cx, cy, ExtRateX, ExtRateY, Angle, GrHandle, WriteZMode, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraphFastToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraphFastToZBuffer(int x, int y, float ExRate, float Angle, int GrHandle, int WriteZMode, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraphFastToZBuffer(int x, int y, float ExRate, float Angle, int GrHandle, int WriteZMode, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraphFastToZBuffer(x, y, ExRate, Angle, GrHandle, WriteZMode, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraphFast2ToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraphFast2ToZBuffer(int x, int y, int cx, int cy, float ExtRate, float Angle, int GrHandle, int WriteZMode, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraphFast2ToZBuffer(int x, int y, int cx, int cy, float ExtRate, float Angle, int GrHandle, int WriteZMode, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraphFast2ToZBuffer(x, y, cx, cy, ExtRate, Angle, GrHandle, WriteZMode, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraphFast3ToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraphFast3ToZBuffer(int x, int y, int cx, int cy, float ExtRateX, float ExtRateY, float Angle, int GrHandle, int WriteZMode, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraphFast3ToZBuffer(int x, int y, int cx, int cy, float ExtRateX, float ExtRateY, float Angle, int GrHandle, int WriteZMode, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraphFast3ToZBuffer(x, y, cx, cy, ExtRateX, ExtRateY, Angle, GrHandle, WriteZMode, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiGraphToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiGraphToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int GrHandle, int WriteZMode);
		public static int DrawModiGraphToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int GrHandle, int WriteZMode) => dx_DrawModiGraphToZBuffer(x1, y1, x2, y2, x3, y3, x4, y4, GrHandle, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawBoxToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawBoxToZBuffer(int x1, int y1, int x2, int y2, int FillFlag, int WriteZMode);
		public static int DrawBoxToZBuffer(int x1, int y1, int x2, int y2, int FillFlag, int WriteZMode) => dx_DrawBoxToZBuffer(x1, y1, x2, y2, FillFlag, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCircleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCircleToZBuffer(int x, int y, int r, int FillFlag, int WriteZMode);
		public static int DrawCircleToZBuffer(int x, int y, int r, int FillFlag, int WriteZMode) => dx_DrawCircleToZBuffer(x, y, r, FillFlag, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawTriangleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawTriangleToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int FillFlag, int WriteZMode);
		public static int DrawTriangleToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int FillFlag, int WriteZMode) => dx_DrawTriangleToZBuffer(x1, y1, x2, y2, x3, y3, FillFlag, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawQuadrangleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawQuadrangleToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int FillFlag, int WriteZMode);
		public static int DrawQuadrangleToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int FillFlag, int WriteZMode) => dx_DrawQuadrangleToZBuffer(x1, y1, x2, y2, x3, y3, x4, y4, FillFlag, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRoundRectToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRoundRectToZBuffer(int x1, int y1, int x2, int y2, int rx, int ry, int FillFlag, int WriteZMode);
		public static int DrawRoundRectToZBuffer(int x1, int y1, int x2, int y2, int rx, int ry, int FillFlag, int WriteZMode) => dx_DrawRoundRectToZBuffer(x1, y1, x2, y2, rx, ry, FillFlag, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygon", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygon([In, Out] VERTEX[] VertexArray, int PolygonNum, int GrHandle, int TransFlag, int UVScaling);
		public static int DrawPolygon([In, Out] VERTEX[] VertexArray, int PolygonNum, int GrHandle, int TransFlag, int UVScaling = FALSE) => dx_DrawPolygon(VertexArray, PolygonNum, GrHandle, TransFlag, UVScaling);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygon2D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygon2D([In, Out] VERTEX2D[] VertexArray, int PolygonNum, int GrHandle, int TransFlag);
		public static int DrawPolygon2D([In, Out] VERTEX2D[] VertexArray, int PolygonNum, int GrHandle, int TransFlag) => dx_DrawPolygon2D(VertexArray, PolygonNum, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygon3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygon3D([In, Out] VERTEX3D[] VertexArray, int PolygonNum, int GrHandle, int TransFlag);
		public static int DrawPolygon3D([In, Out] VERTEX3D[] VertexArray, int PolygonNum, int GrHandle, int TransFlag) => dx_DrawPolygon3D(VertexArray, PolygonNum, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygonIndexed2D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygonIndexed2D([In, Out] VERTEX2D[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int PolygonNum, int GrHandle, int TransFlag);
		public static int DrawPolygonIndexed2D([In, Out] VERTEX2D[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int PolygonNum, int GrHandle, int TransFlag) => dx_DrawPolygonIndexed2D(VertexArray, VertexNum, IndexArray, PolygonNum, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygonIndexed3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygonIndexed3D([In, Out] VERTEX3D[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int PolygonNum, int GrHandle, int TransFlag);
		public static int DrawPolygonIndexed3D([In, Out] VERTEX3D[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int PolygonNum, int GrHandle, int TransFlag) => dx_DrawPolygonIndexed3D(VertexArray, VertexNum, IndexArray, PolygonNum, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygonIndexed3DBase", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygonIndexed3DBase([In, Out] VERTEX_3D[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int IndexNum, int PrimitiveType, int GrHandle, int TransFlag);
		public static int DrawPolygonIndexed3DBase([In, Out] VERTEX_3D[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int IndexNum, int PrimitiveType, int GrHandle, int TransFlag) => dx_DrawPolygonIndexed3DBase(VertexArray, VertexNum, IndexArray, IndexNum, PrimitiveType, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygon3DBase", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygon3DBase([In, Out] VERTEX_3D[] VertexArray, int VertexNum, int PrimitiveType, int GrHandle, int TransFlag);
		public static int DrawPolygon3DBase([In, Out] VERTEX_3D[] VertexArray, int VertexNum, int PrimitiveType, int GrHandle, int TransFlag) => dx_DrawPolygon3DBase(VertexArray, VertexNum, PrimitiveType, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygon3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygon3D([In, Out] VERTEX_3D[] VertexArray, int PolygonNum, int GrHandle, int TransFlag);
		public static int DrawPolygon3D([In, Out] VERTEX_3D[] VertexArray, int PolygonNum, int GrHandle, int TransFlag) => dx_DrawPolygon3D(VertexArray, PolygonNum, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygonBase", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygonBase([In, Out] VERTEX[] VertexArray, int VertexNum, int PrimitiveType, int GrHandle, int TransFlag, int UVScaling);
		public static int DrawPolygonBase([In, Out] VERTEX[] VertexArray, int VertexNum, int PrimitiveType, int GrHandle, int TransFlag, int UVScaling = FALSE) => dx_DrawPolygonBase(VertexArray, VertexNum, PrimitiveType, GrHandle, TransFlag, UVScaling);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitive2D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitive2D([In, Out] VERTEX2D[] VertexArray, int VertexNum, int PrimitiveType, int GrHandle, int TransFlag);
		public static int DrawPrimitive2D([In, Out] VERTEX2D[] VertexArray, int VertexNum, int PrimitiveType, int GrHandle, int TransFlag) => dx_DrawPrimitive2D(VertexArray, VertexNum, PrimitiveType, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitive3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitive3D([In, Out] VERTEX3D[] VertexArray, int VertexNum, int PrimitiveType, int GrHandle, int TransFlag);
		public static int DrawPrimitive3D([In, Out] VERTEX3D[] VertexArray, int VertexNum, int PrimitiveType, int GrHandle, int TransFlag) => dx_DrawPrimitive3D(VertexArray, VertexNum, PrimitiveType, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitiveIndexed2D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitiveIndexed2D([In, Out] VERTEX2D[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int IndexNum, int PrimitiveType, int GrHandle, int TransFlag);
		public static int DrawPrimitiveIndexed2D([In, Out] VERTEX2D[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int IndexNum, int PrimitiveType, int GrHandle, int TransFlag) => dx_DrawPrimitiveIndexed2D(VertexArray, VertexNum, IndexArray, IndexNum, PrimitiveType, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitiveIndexed3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitiveIndexed3D([In, Out] VERTEX3D[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int IndexNum, int PrimitiveType, int GrHandle, int TransFlag);
		public static int DrawPrimitiveIndexed3D([In, Out] VERTEX3D[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int IndexNum, int PrimitiveType, int GrHandle, int TransFlag) => dx_DrawPrimitiveIndexed3D(VertexArray, VertexNum, IndexArray, IndexNum, PrimitiveType, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygon3D_UseVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygon3D_UseVertexBuffer(int VertexBufHandle, int GrHandle, int TransFlag);
		public static int DrawPolygon3D_UseVertexBuffer(int VertexBufHandle, int GrHandle, int TransFlag) => dx_DrawPolygon3D_UseVertexBuffer(VertexBufHandle, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitive3D_UseVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitive3D_UseVertexBuffer(int VertexBufHandle, int PrimitiveType, int GrHandle, int TransFlag);
		public static int DrawPrimitive3D_UseVertexBuffer(int VertexBufHandle, int PrimitiveType, int GrHandle, int TransFlag) => dx_DrawPrimitive3D_UseVertexBuffer(VertexBufHandle, PrimitiveType, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitive3D_UseVertexBuffer2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitive3D_UseVertexBuffer2(int VertexBufHandle, int PrimitiveType, int StartVertex, int UseVertexNum, int GrHandle, int TransFlag);
		public static int DrawPrimitive3D_UseVertexBuffer2(int VertexBufHandle, int PrimitiveType, int StartVertex, int UseVertexNum, int GrHandle, int TransFlag) => dx_DrawPrimitive3D_UseVertexBuffer2(VertexBufHandle, PrimitiveType, StartVertex, UseVertexNum, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygonIndexed3D_UseVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygonIndexed3D_UseVertexBuffer(int VertexBufHandle, int IndexBufHandle, int GrHandle, int TransFlag);
		public static int DrawPolygonIndexed3D_UseVertexBuffer(int VertexBufHandle, int IndexBufHandle, int GrHandle, int TransFlag) => dx_DrawPolygonIndexed3D_UseVertexBuffer(VertexBufHandle, IndexBufHandle, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitiveIndexed3D_UseVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitiveIndexed3D_UseVertexBuffer(int VertexBufHandle, int IndexBufHandle, int PrimitiveType, int GrHandle, int TransFlag);
		public static int DrawPrimitiveIndexed3D_UseVertexBuffer(int VertexBufHandle, int IndexBufHandle, int PrimitiveType, int GrHandle, int TransFlag) => dx_DrawPrimitiveIndexed3D_UseVertexBuffer(VertexBufHandle, IndexBufHandle, PrimitiveType, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitiveIndexed3D_UseVertexBuffer2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitiveIndexed3D_UseVertexBuffer2(int VertexBufHandle, int IndexBufHandle, int PrimitiveType, int BaseVertex, int StartVertex, int UseVertexNum, int StartIndex, int UseIndexNum, int GrHandle, int TransFlag);
		public static int DrawPrimitiveIndexed3D_UseVertexBuffer2(int VertexBufHandle, int IndexBufHandle, int PrimitiveType, int BaseVertex, int StartVertex, int UseVertexNum, int StartIndex, int UseIndexNum, int GrHandle, int TransFlag) => dx_DrawPrimitiveIndexed3D_UseVertexBuffer2(VertexBufHandle, IndexBufHandle, PrimitiveType, BaseVertex, StartVertex, UseVertexNum, StartIndex, UseIndexNum, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawGraph3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawGraph3D(float x, float y, float z, int GrHandle, int TransFlag);
		public static int DrawGraph3D(float x, float y, float z, int GrHandle, int TransFlag) => dx_DrawGraph3D(x, y, z, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendGraph3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendGraph3D(float x, float y, float z, double ExRateX, double ExRateY, int GrHandle, int TransFlag);
		public static int DrawExtendGraph3D(float x, float y, float z, double ExRateX, double ExRateY, int GrHandle, int TransFlag) => dx_DrawExtendGraph3D(x, y, z, ExRateX, ExRateY, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaGraph3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaGraph3D(float x, float y, float z, double ExRate, double Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRotaGraph3D(float x, float y, float z, double ExRate, double Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRotaGraph3D(x, y, z, ExRate, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRota2Graph3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRota2Graph3D(float x, float y, float z, float cx, float cy, double ExtRateX, double ExtRateY, double Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawRota2Graph3D(float x, float y, float z, float cx, float cy, double ExtRateX, double ExtRateY, double Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawRota2Graph3D(x, y, z, cx, cy, ExtRateX, ExtRateY, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiBillboard3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiBillboard3D(VECTOR Pos, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, int GrHandle, int TransFlag);
		public static int DrawModiBillboard3D(VECTOR Pos, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, int GrHandle, int TransFlag) => dx_DrawModiBillboard3D(Pos, x1, y1, x2, y2, x3, y3, x4, y4, GrHandle, TransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawBillboard3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawBillboard3D(VECTOR Pos, float cx, float cy, float Size, float Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawBillboard3D(VECTOR Pos, float cx, float cy, float Size, float Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawBillboard3D(Pos, cx, cy, Size, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawMode(int DrawMode);
		public static int SetDrawMode(int DrawMode) => dx_SetDrawMode(DrawMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawMode();
		public static int GetDrawMode() => dx_GetDrawMode();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawBlendMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawBlendMode(int BlendMode, int BlendParam);
		public static int SetDrawBlendMode(int BlendMode, int BlendParam) => dx_SetDrawBlendMode(BlendMode, BlendParam);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawBlendMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawBlendMode(out int BlendMode, out int BlendParam);
		public static int GetDrawBlendMode(out int BlendMode, out int BlendParam) => dx_GetDrawBlendMode(out BlendMode, out BlendParam);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawAlphaTest", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawAlphaTest(int TestMode, int TestParam);
		public static int SetDrawAlphaTest(int TestMode, int TestParam) => dx_SetDrawAlphaTest(TestMode, TestParam);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawAlphaTest", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawAlphaTest(out int TestMode, out int TestParam);
		public static int GetDrawAlphaTest(out int TestMode, out int TestParam) => dx_GetDrawAlphaTest(out TestMode, out TestParam);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetBlendGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetBlendGraph(int BlendGraph, int BorderParam, int BorderRange);
		public static int SetBlendGraph(int BlendGraph, int BorderParam, int BorderRange) => dx_SetBlendGraph(BlendGraph, BorderParam, BorderRange);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetBlendGraphPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetBlendGraphPosition(int x, int y);
		public static int SetBlendGraphPosition(int x, int y) => dx_SetBlendGraphPosition(x, y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetBlendGraphPositionMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetBlendGraphPositionMode(int BlendGraphPositionMode);
		public static int SetBlendGraphPositionMode(int BlendGraphPositionMode) => dx_SetBlendGraphPositionMode(BlendGraphPositionMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawBright", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawBright(int RedBright, int GreenBright, int BlueBright);
		public static int SetDrawBright(int RedBright, int GreenBright, int BlueBright) => dx_SetDrawBright(RedBright, GreenBright, BlueBright);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawBright", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawBright(out int Red, out int Green, out int Blue);
		public static int GetDrawBright(out int Red, out int Green, out int Blue) => dx_GetDrawBright(out Red, out Green, out Blue);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWriteAlphaChannelFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWriteAlphaChannelFlag(int Flag);
		public static int SetWriteAlphaChannelFlag(int Flag) => dx_SetWriteAlphaChannelFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWriteAlphaChannelFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWriteAlphaChannelFlag();
		public static int GetWriteAlphaChannelFlag() => dx_GetWriteAlphaChannelFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckSeparateAlphaBlendEnable", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckSeparateAlphaBlendEnable();
		public static int CheckSeparateAlphaBlendEnable() => dx_CheckSeparateAlphaBlendEnable();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetIgnoreDrawGraphColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetIgnoreDrawGraphColor(int EnableFlag);
		public static int SetIgnoreDrawGraphColor(int EnableFlag) => dx_SetIgnoreDrawGraphColor(EnableFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMaxAnisotropy", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMaxAnisotropy(int MaxAnisotropy);
		public static int SetMaxAnisotropy(int MaxAnisotropy) => dx_SetMaxAnisotropy(MaxAnisotropy);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMaxAnisotropy", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMaxAnisotropy();
		public static int GetMaxAnisotropy() => dx_GetMaxAnisotropy();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseLarge3DPositionSupport", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseLarge3DPositionSupport(int UseFlag);
		public static int SetUseLarge3DPositionSupport(int UseFlag) => dx_SetUseLarge3DPositionSupport(UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseZBufferFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseZBufferFlag(int Flag);
		public static int SetUseZBufferFlag(int Flag) => dx_SetUseZBufferFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWriteZBufferFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWriteZBufferFlag(int Flag);
		public static int SetWriteZBufferFlag(int Flag) => dx_SetWriteZBufferFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetZBufferCmpType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetZBufferCmpType(int CmpType);
		public static int SetZBufferCmpType(int CmpType) => dx_SetZBufferCmpType(CmpType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetZBias", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetZBias(int Bias);
		public static int SetZBias(int Bias) => dx_SetZBias(Bias);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseZBuffer3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseZBuffer3D(int Flag);
		public static int SetUseZBuffer3D(int Flag) => dx_SetUseZBuffer3D(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWriteZBuffer3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWriteZBuffer3D(int Flag);
		public static int SetWriteZBuffer3D(int Flag) => dx_SetWriteZBuffer3D(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetZBufferCmpType3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetZBufferCmpType3D(int CmpType);
		public static int SetZBufferCmpType3D(int CmpType) => dx_SetZBufferCmpType3D(CmpType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetZBias3D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetZBias3D(int Bias);
		public static int SetZBias3D(int Bias) => dx_SetZBias3D(Bias);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawZ", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawZ(float Z);
		public static int SetDrawZ(float Z) => dx_SetDrawZ(Z);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawArea", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawArea(int x1, int y1, int x2, int y2);
		public static int SetDrawArea(int x1, int y1, int x2, int y2) => dx_SetDrawArea(x1, y1, x2, y2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawArea", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawArea(out RECT Rect);
		public static int GetDrawArea(out RECT Rect) => dx_GetDrawArea(out Rect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawAreaFull", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawAreaFull();
		public static int SetDrawAreaFull() => dx_SetDrawAreaFull();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDraw3DScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDraw3DScale(float Scale);
		public static int SetDraw3DScale(float Scale) => dx_SetDraw3DScale(Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_RunRestoreShred", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_RunRestoreShred();
		public static int RunRestoreShred() => dx_RunRestoreShred();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTransformTo2D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTransformTo2D(out MATRIX Matrix);
		public static int SetTransformTo2D(out MATRIX Matrix) => dx_SetTransformTo2D(out Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTransformTo2DD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTransformTo2DD(out MATRIX_D Matrix);
		public static int SetTransformTo2DD(out MATRIX_D Matrix) => dx_SetTransformTo2DD(out Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetTransformTo2D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetTransformTo2D();
		public static int ResetTransformTo2D() => dx_ResetTransformTo2D();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTransformToWorld", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTransformToWorld(out MATRIX Matrix);
		public static int SetTransformToWorld(out MATRIX Matrix) => dx_SetTransformToWorld(out Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTransformToWorldD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTransformToWorldD(out MATRIX_D Matrix);
		public static int SetTransformToWorldD(out MATRIX_D Matrix) => dx_SetTransformToWorldD(out Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransformToWorldMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransformToWorldMatrix(out MATRIX MatBuf);
		public static int GetTransformToWorldMatrix(out MATRIX MatBuf) => dx_GetTransformToWorldMatrix(out MatBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransformToWorldMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransformToWorldMatrixD(out MATRIX_D MatBuf);
		public static int GetTransformToWorldMatrixD(out MATRIX_D MatBuf) => dx_GetTransformToWorldMatrixD(out MatBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTransformToView", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTransformToView(out MATRIX Matrix);
		public static int SetTransformToView(out MATRIX Matrix) => dx_SetTransformToView(out Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTransformToViewD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTransformToViewD(out MATRIX_D Matrix);
		public static int SetTransformToViewD(out MATRIX_D Matrix) => dx_SetTransformToViewD(out Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransformToViewMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransformToViewMatrix(out MATRIX MatBuf);
		public static int GetTransformToViewMatrix(out MATRIX MatBuf) => dx_GetTransformToViewMatrix(out MatBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransformToViewMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransformToViewMatrixD(out MATRIX_D MatBuf);
		public static int GetTransformToViewMatrixD(out MATRIX_D MatBuf) => dx_GetTransformToViewMatrixD(out MatBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTransformToProjection", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTransformToProjection(out MATRIX Matrix);
		public static int SetTransformToProjection(out MATRIX Matrix) => dx_SetTransformToProjection(out Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTransformToProjectionD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTransformToProjectionD(out MATRIX_D Matrix);
		public static int SetTransformToProjectionD(out MATRIX_D Matrix) => dx_SetTransformToProjectionD(out Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransformToProjectionMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransformToProjectionMatrix(out MATRIX MatBuf);
		public static int GetTransformToProjectionMatrix(out MATRIX MatBuf) => dx_GetTransformToProjectionMatrix(out MatBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransformToProjectionMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransformToProjectionMatrixD(out MATRIX_D MatBuf);
		public static int GetTransformToProjectionMatrixD(out MATRIX_D MatBuf) => dx_GetTransformToProjectionMatrixD(out MatBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTransformToViewport", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTransformToViewport(out MATRIX Matrix);
		public static int SetTransformToViewport(out MATRIX Matrix) => dx_SetTransformToViewport(out Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTransformToViewportD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTransformToViewportD(out MATRIX_D Matrix);
		public static int SetTransformToViewportD(out MATRIX_D Matrix) => dx_SetTransformToViewportD(out Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransformToViewportMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransformToViewportMatrix(out MATRIX MatBuf);
		public static int GetTransformToViewportMatrix(out MATRIX MatBuf) => dx_GetTransformToViewportMatrix(out MatBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransformToViewportMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransformToViewportMatrixD(out MATRIX_D MatBuf);
		public static int GetTransformToViewportMatrixD(out MATRIX_D MatBuf) => dx_GetTransformToViewportMatrixD(out MatBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransformToAPIViewportMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransformToAPIViewportMatrix(out MATRIX MatBuf);
		public static int GetTransformToAPIViewportMatrix(out MATRIX MatBuf) => dx_GetTransformToAPIViewportMatrix(out MatBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransformToAPIViewportMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransformToAPIViewportMatrixD(out MATRIX_D MatBuf);
		public static int GetTransformToAPIViewportMatrixD(out MATRIX_D MatBuf) => dx_GetTransformToAPIViewportMatrixD(out MatBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDefTransformMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDefTransformMatrix();
		public static int SetDefTransformMatrix() => dx_SetDefTransformMatrix();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransformPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransformPosition(out VECTOR LocalPos, out float x, out float y);
		public static int GetTransformPosition(out VECTOR LocalPos, out float x, out float y) => dx_GetTransformPosition(out LocalPos, out x, out y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTransformPositionD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTransformPositionD(out VECTOR_D LocalPos, out double x, out double y);
		public static int GetTransformPositionD(out VECTOR_D LocalPos, out double x, out double y) => dx_GetTransformPositionD(out LocalPos, out x, out y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetBillboardPixelSize", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetBillboardPixelSize(VECTOR WorldPos, float WorldSize);
		public static float GetBillboardPixelSize(VECTOR WorldPos, float WorldSize) => dx_GetBillboardPixelSize(WorldPos, WorldSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetBillboardPixelSizeD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_GetBillboardPixelSizeD(VECTOR_D WorldPos, double WorldSize);
		public static double GetBillboardPixelSizeD(VECTOR_D WorldPos, double WorldSize) => dx_GetBillboardPixelSizeD(WorldPos, WorldSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvWorldPosToViewPos", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_ConvWorldPosToViewPos(VECTOR WorldPos);
		public static VECTOR ConvWorldPosToViewPos(VECTOR WorldPos) => dx_ConvWorldPosToViewPos(WorldPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvWorldPosToViewPosD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_ConvWorldPosToViewPosD(VECTOR_D WorldPos);
		public static VECTOR_D ConvWorldPosToViewPosD(VECTOR_D WorldPos) => dx_ConvWorldPosToViewPosD(WorldPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvWorldPosToScreenPos", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_ConvWorldPosToScreenPos(VECTOR WorldPos);
		public static VECTOR ConvWorldPosToScreenPos(VECTOR WorldPos) => dx_ConvWorldPosToScreenPos(WorldPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvWorldPosToScreenPosD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_ConvWorldPosToScreenPosD(VECTOR_D WorldPos);
		public static VECTOR_D ConvWorldPosToScreenPosD(VECTOR_D WorldPos) => dx_ConvWorldPosToScreenPosD(WorldPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvWorldPosToScreenPosPlusW", CallingConvention=CallingConvention.StdCall)]
		extern static FLOAT4 dx_ConvWorldPosToScreenPosPlusW(VECTOR WorldPos);
		public static FLOAT4 ConvWorldPosToScreenPosPlusW(VECTOR WorldPos) => dx_ConvWorldPosToScreenPosPlusW(WorldPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvWorldPosToScreenPosPlusWD", CallingConvention=CallingConvention.StdCall)]
		extern static DOUBLE4 dx_ConvWorldPosToScreenPosPlusWD(VECTOR_D WorldPos);
		public static DOUBLE4 ConvWorldPosToScreenPosPlusWD(VECTOR_D WorldPos) => dx_ConvWorldPosToScreenPosPlusWD(WorldPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvScreenPosToWorldPos", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_ConvScreenPosToWorldPos(VECTOR ScreenPos);
		public static VECTOR ConvScreenPosToWorldPos(VECTOR ScreenPos) => dx_ConvScreenPosToWorldPos(ScreenPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvScreenPosToWorldPosD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_ConvScreenPosToWorldPosD(VECTOR_D ScreenPos);
		public static VECTOR_D ConvScreenPosToWorldPosD(VECTOR_D ScreenPos) => dx_ConvScreenPosToWorldPosD(ScreenPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvScreenPosToWorldPos_ZLinear", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_ConvScreenPosToWorldPos_ZLinear(VECTOR ScreenPos);
		public static VECTOR ConvScreenPosToWorldPos_ZLinear(VECTOR ScreenPos) => dx_ConvScreenPosToWorldPos_ZLinear(ScreenPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvScreenPosToWorldPos_ZLinearD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_ConvScreenPosToWorldPos_ZLinearD(VECTOR_D ScreenPos);
		public static VECTOR_D ConvScreenPosToWorldPos_ZLinearD(VECTOR_D ScreenPos) => dx_ConvScreenPosToWorldPos_ZLinearD(ScreenPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseCullingFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseCullingFlag(int Flag);
		public static int SetUseCullingFlag(int Flag) => dx_SetUseCullingFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseBackCulling", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseBackCulling(int Flag);
		public static int SetUseBackCulling(int Flag) => dx_SetUseBackCulling(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseBackCulling", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseBackCulling();
		public static int GetUseBackCulling() => dx_GetUseBackCulling();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTextureAddressMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTextureAddressMode(int Mode, int Stage);
		public static int SetTextureAddressMode(int Mode, int Stage = -1) => dx_SetTextureAddressMode(Mode, Stage);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTextureAddressModeUV", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTextureAddressModeUV(int ModeU, int ModeV, int Stage);
		public static int SetTextureAddressModeUV(int ModeU, int ModeV, int Stage = -1) => dx_SetTextureAddressModeUV(ModeU, ModeV, Stage);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTextureAddressTransform", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTextureAddressTransform(float TransU, float TransV, float ScaleU, float ScaleV, float RotCenterU, float RotCenterV, float Rotate);
		public static int SetTextureAddressTransform(float TransU, float TransV, float ScaleU, float ScaleV, float RotCenterU, float RotCenterV, float Rotate) => dx_SetTextureAddressTransform(TransU, TransV, ScaleU, ScaleV, RotCenterU, RotCenterV, Rotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetTextureAddressTransformMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetTextureAddressTransformMatrix(MATRIX Matrix);
		public static int SetTextureAddressTransformMatrix(MATRIX Matrix) => dx_SetTextureAddressTransformMatrix(Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetTextureAddressTransform", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetTextureAddressTransform();
		public static int ResetTextureAddressTransform() => dx_ResetTextureAddressTransform();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFogEnable", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFogEnable(int Flag);
		public static int SetFogEnable(int Flag) => dx_SetFogEnable(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFogEnable", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFogEnable();
		public static int GetFogEnable() => dx_GetFogEnable();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFogMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFogMode(int Mode);
		public static int SetFogMode(int Mode) => dx_SetFogMode(Mode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFogMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFogMode();
		public static int GetFogMode() => dx_GetFogMode();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFogColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFogColor(int r, int g, int b);
		public static int SetFogColor(int r, int g, int b) => dx_SetFogColor(r, g, b);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFogColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFogColor(out int r, out int g, out int b);
		public static int GetFogColor(out int r, out int g, out int b) => dx_GetFogColor(out r, out g, out b);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFogStartEnd", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFogStartEnd(float start, float end);
		public static int SetFogStartEnd(float start, float end) => dx_SetFogStartEnd(start, end);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFogStartEnd", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFogStartEnd(out float start, out float end);
		public static int GetFogStartEnd(out float start, out float end) => dx_GetFogStartEnd(out start, out end);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFogDensity", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFogDensity(float density);
		public static int SetFogDensity(float density) => dx_SetFogDensity(density);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFogDensity", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetFogDensity();
		public static float GetFogDensity() => dx_GetFogDensity();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPixel", CallingConvention=CallingConvention.StdCall)]
		extern static uint dx_GetPixel(int x, int y);
		public static uint GetPixel(int x, int y) => dx_GetPixel(x, y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPixelF", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_GetPixelF(int x, int y);
		public static COLOR_F GetPixelF(int x, int y) => dx_GetPixelF(x, y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetBackgroundColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetBackgroundColor(int Red, int Green, int Blue, int Alpha);
		public static int SetBackgroundColor(int Red, int Green, int Blue, int Alpha = 0) => dx_SetBackgroundColor(Red, Green, Blue, Alpha);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetBackgroundColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetBackgroundColor(out int Red, out int Green, out int Blue, out int Alpha);
		public static int GetBackgroundColor(out int Red, out int Green, out int Blue, out int Alpha) => dx_GetBackgroundColor(out Red, out Green, out Blue, out Alpha);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawScreenGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawScreenGraph(int x1, int y1, int x2, int y2, int GrHandle, int UseClientFlag);
		public static int GetDrawScreenGraph(int x1, int y1, int x2, int y2, int GrHandle, int UseClientFlag = TRUE) => dx_GetDrawScreenGraph(x1, y1, x2, y2, GrHandle, UseClientFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_BltDrawValidGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_BltDrawValidGraph(int TargetDrawValidGrHandle, int x1, int y1, int x2, int y2, int DestX, int DestY, int DestGrHandle);
		public static int BltDrawValidGraph(int TargetDrawValidGrHandle, int x1, int y1, int x2, int y2, int DestX, int DestY, int DestGrHandle) => dx_BltDrawValidGraph(TargetDrawValidGrHandle, x1, y1, x2, y2, DestX, DestY, DestGrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ScreenFlip", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ScreenFlip();
		public static int ScreenFlip() => dx_ScreenFlip();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ScreenCopy", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ScreenCopy();
		public static int ScreenCopy() => dx_ScreenCopy();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_WaitVSync", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_WaitVSync(int SyncNum);
		public static int WaitVSync(int SyncNum) => dx_WaitVSync(SyncNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ClsDrawScreen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ClsDrawScreen();
		public static int ClsDrawScreen() => dx_ClsDrawScreen();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawScreen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawScreen(int DrawScreen);
		public static int SetDrawScreen(int DrawScreen) => dx_SetDrawScreen(DrawScreen);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawScreen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawScreen();
		public static int GetDrawScreen() => dx_GetDrawScreen();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetActiveGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetActiveGraph();
		public static int GetActiveGraph() => dx_GetActiveGraph();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseSetDrawScreenSettingReset", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseSetDrawScreenSettingReset(int UseFlag);
		public static int SetUseSetDrawScreenSettingReset(int UseFlag) => dx_SetUseSetDrawScreenSettingReset(UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseSetDrawScreenSettingReset", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseSetDrawScreenSettingReset();
		public static int GetUseSetDrawScreenSettingReset() => dx_GetUseSetDrawScreenSettingReset();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawZBuffer(int DrawScreen);
		public static int SetDrawZBuffer(int DrawScreen) => dx_SetDrawZBuffer(DrawScreen);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetGraphMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetGraphMode(int ScreenSizeX, int ScreenSizeY, int ColorBitDepth, int RefreshRate);
		public static int SetGraphMode(int ScreenSizeX, int ScreenSizeY, int ColorBitDepth, int RefreshRate = 60) => dx_SetGraphMode(ScreenSizeX, ScreenSizeY, ColorBitDepth, RefreshRate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUserScreenImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUserScreenImage(System.IntPtr Image, int PixelFormat);
		public static int SetUserScreenImage(System.IntPtr Image, int PixelFormat) => dx_SetUserScreenImage(Image, PixelFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFullScreenResolutionMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFullScreenResolutionMode(int ResolutionMode);
		public static int SetFullScreenResolutionMode(int ResolutionMode) => dx_SetFullScreenResolutionMode(ResolutionMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFullScreenResolutionMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFullScreenResolutionMode(out int ResolutionMode, out int UseResolutionMode);
		public static int GetFullScreenResolutionMode(out int ResolutionMode, out int UseResolutionMode) => dx_GetFullScreenResolutionMode(out ResolutionMode, out UseResolutionMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFullScreenScalingMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFullScreenScalingMode(int ScalingMode, int FitScaling);
		public static int SetFullScreenScalingMode(int ScalingMode, int FitScaling = FALSE) => dx_SetFullScreenScalingMode(ScalingMode, FitScaling);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetEmulation320x240", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetEmulation320x240(int Flag);
		public static int SetEmulation320x240(int Flag) => dx_SetEmulation320x240(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetZBufferSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetZBufferSize(int ZBufferSizeX, int ZBufferSizeY);
		public static int SetZBufferSize(int ZBufferSizeX, int ZBufferSizeY) => dx_SetZBufferSize(ZBufferSizeX, ZBufferSizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetZBufferBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetZBufferBitDepth(int BitDepth);
		public static int SetZBufferBitDepth(int BitDepth) => dx_SetZBufferBitDepth(BitDepth);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWaitVSyncFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWaitVSyncFlag(int Flag);
		public static int SetWaitVSyncFlag(int Flag) => dx_SetWaitVSyncFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWaitVSyncFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWaitVSyncFlag();
		public static int GetWaitVSyncFlag() => dx_GetWaitVSyncFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFullSceneAntiAliasingMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFullSceneAntiAliasingMode(int Samples, int Quality);
		public static int SetFullSceneAntiAliasingMode(int Samples, int Quality) => dx_SetFullSceneAntiAliasingMode(Samples, Quality);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetGraphDisplayArea", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetGraphDisplayArea(int x1, int y1, int x2, int y2);
		public static int SetGraphDisplayArea(int x1, int y1, int x2, int y2) => dx_SetGraphDisplayArea(x1, y1, x2, y2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetChangeScreenModeGraphicsSystemResetFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetChangeScreenModeGraphicsSystemResetFlag(int Flag);
		public static int SetChangeScreenModeGraphicsSystemResetFlag(int Flag) => dx_SetChangeScreenModeGraphicsSystemResetFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetScreenState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetScreenState(out int SizeX, out int SizeY, out int ColorBitDepth);
		public static int GetScreenState(out int SizeX, out int SizeY, out int ColorBitDepth) => dx_GetScreenState(out SizeX, out SizeY, out ColorBitDepth);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawScreenSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawScreenSize(out int XBuf, out int YBuf);
		public static int GetDrawScreenSize(out int XBuf, out int YBuf) => dx_GetDrawScreenSize(out XBuf, out YBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetScreenBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetScreenBitDepth();
		public static int GetScreenBitDepth() => dx_GetScreenBitDepth();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetColorBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetColorBitDepth();
		public static int GetColorBitDepth() => dx_GetColorBitDepth();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetChangeDisplayFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetChangeDisplayFlag();
		public static int GetChangeDisplayFlag() => dx_GetChangeDisplayFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetVideoMemorySize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetVideoMemorySize(out int AllSize, out int FreeSize);
		public static int GetVideoMemorySize(out int AllSize, out int FreeSize) => dx_GetVideoMemorySize(out AllSize, out FreeSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetRefreshRate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetRefreshRate();
		public static int GetRefreshRate() => dx_GetRefreshRate();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDisplayNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDisplayNum();
		public static int GetDisplayNum() => dx_GetDisplayNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDisplayInfo", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDisplayInfo(int DisplayIndex, out int DesktopRectX, out int DesktopRectY, out int DesktopSizeX, out int DesktopSizeY, out int IsPrimary);
		public static int GetDisplayInfo(int DisplayIndex, out int DesktopRectX, out int DesktopRectY, out int DesktopSizeX, out int DesktopSizeY, out int IsPrimary) => dx_GetDisplayInfo(DisplayIndex, out DesktopRectX, out DesktopRectY, out DesktopSizeX, out DesktopSizeY, out IsPrimary);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDisplayModeNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDisplayModeNum(int DisplayIndex);
		public static int GetDisplayModeNum(int DisplayIndex = 0) => dx_GetDisplayModeNum(DisplayIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDisplayMode", CallingConvention=CallingConvention.StdCall)]
		extern static DISPLAYMODEDATA dx_GetDisplayMode(int ModeIndex, int DisplayIndex);
		public static DISPLAYMODEDATA GetDisplayMode(int ModeIndex, int DisplayIndex = 0) => dx_GetDisplayMode(ModeIndex, DisplayIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDisplayMaxResolution", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDisplayMaxResolution(out int SizeX, out int SizeY, int DisplayIndex);
		public static int GetDisplayMaxResolution(out int SizeX, out int SizeY, int DisplayIndex = 0) => dx_GetDisplayMaxResolution(out SizeX, out SizeY, DisplayIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDispColorData", CallingConvention=CallingConvention.StdCall)]
		extern static uint dx_GetDispColorData();
		public static uint GetDispColorData() => dx_GetDispColorData();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMultiDrawScreenNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMultiDrawScreenNum();
		public static int GetMultiDrawScreenNum() => dx_GetMultiDrawScreenNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawFloatCoordType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawFloatCoordType();
		public static int GetDrawFloatCoordType() => dx_GetDrawFloatCoordType();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseNormalDrawShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseNormalDrawShader(int Flag);
		public static int SetUseNormalDrawShader(int Flag) => dx_SetUseNormalDrawShader(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseSoftwareRenderModeFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseSoftwareRenderModeFlag(int Flag);
		public static int SetUseSoftwareRenderModeFlag(int Flag) => dx_SetUseSoftwareRenderModeFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNotUse3DFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNotUse3DFlag(int Flag);
		public static int SetNotUse3DFlag(int Flag) => dx_SetNotUse3DFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUse3DFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUse3DFlag(int Flag);
		public static int SetUse3DFlag(int Flag) => dx_SetUse3DFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUse3DFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUse3DFlag();
		public static int GetUse3DFlag() => dx_GetUse3DFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetScreenMemToVramFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetScreenMemToVramFlag(int Flag);
		public static int SetScreenMemToVramFlag(int Flag) => dx_SetScreenMemToVramFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetScreenMemToSystemMemFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetScreenMemToSystemMemFlag();
		public static int GetScreenMemToSystemMemFlag() => dx_GetScreenMemToSystemMemFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowDrawRect", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowDrawRect(out RECT DrawRect);
		public static int SetWindowDrawRect(out RECT DrawRect) => dx_SetWindowDrawRect(out DrawRect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_RestoreGraphSystem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_RestoreGraphSystem();
		public static int RestoreGraphSystem() => dx_RestoreGraphSystem();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseHardwareVertexProcessing", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseHardwareVertexProcessing(int Flag);
		public static int SetUseHardwareVertexProcessing(int Flag) => dx_SetUseHardwareVertexProcessing(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUsePixelLighting", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUsePixelLighting(int Flag);
		public static int SetUsePixelLighting(int Flag) => dx_SetUsePixelLighting(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseOldDrawModiGraphCodeFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseOldDrawModiGraphCodeFlag(int Flag);
		public static int SetUseOldDrawModiGraphCodeFlag(int Flag) => dx_SetUseOldDrawModiGraphCodeFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseVramFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseVramFlag(int Flag);
		public static int SetUseVramFlag(int Flag) => dx_SetUseVramFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseVramFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseVramFlag();
		public static int GetUseVramFlag() => dx_GetUseVramFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetBasicBlendFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetBasicBlendFlag(int Flag);
		public static int SetBasicBlendFlag(int Flag) => dx_SetBasicBlendFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseBasicGraphDraw3DDeviceMethodFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseBasicGraphDraw3DDeviceMethodFlag(int Flag);
		public static int SetUseBasicGraphDraw3DDeviceMethodFlag(int Flag) => dx_SetUseBasicGraphDraw3DDeviceMethodFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDisplayIndex", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDisplayIndex(int Index);
		public static int SetUseDisplayIndex(int Index) => dx_SetUseDisplayIndex(Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_RenderVertex", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_RenderVertex();
		public static int RenderVertex() => dx_RenderVertex();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawCallCount", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawCallCount();
		public static int GetDrawCallCount() => dx_GetDrawCallCount();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFPS", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetFPS();
		public static float GetFPS() => dx_GetFPS();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawScreen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawScreen(int x1, int y1, int x2, int y2, string FileName, int SaveType, int Jpeg_Quality, int Jpeg_Sample2x1, int Png_CompressionLevel);
		public static int SaveDrawScreen(int x1, int y1, int x2, int y2, string FileName, int SaveType = DX_IMAGESAVETYPE_BMP, int Jpeg_Quality = 80, int Jpeg_Sample2x1 = TRUE, int Png_CompressionLevel = -1) => dx_SaveDrawScreen(x1, y1, x2, y2, FileName, SaveType, Jpeg_Quality, Jpeg_Sample2x1, Png_CompressionLevel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawScreenWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawScreenWithStrLen(int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength, int SaveType, int Jpeg_Quality, int Jpeg_Sample2x1, int Png_CompressionLevel);
		public static int SaveDrawScreenWithStrLen(int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength, int SaveType = DX_IMAGESAVETYPE_BMP, int Jpeg_Quality = 80, int Jpeg_Sample2x1 = TRUE, int Png_CompressionLevel = -1) => dx_SaveDrawScreenWithStrLen(x1, y1, x2, y2, FileName, FileNameLength, SaveType, Jpeg_Quality, Jpeg_Sample2x1, Png_CompressionLevel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawScreenToBMP", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawScreenToBMP(int x1, int y1, int x2, int y2, string FileName);
		public static int SaveDrawScreenToBMP(int x1, int y1, int x2, int y2, string FileName) => dx_SaveDrawScreenToBMP(x1, y1, x2, y2, FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawScreenToBMPWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawScreenToBMPWithStrLen(int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength);
		public static int SaveDrawScreenToBMPWithStrLen(int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength) => dx_SaveDrawScreenToBMPWithStrLen(x1, y1, x2, y2, FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawScreenToDDS", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawScreenToDDS(int x1, int y1, int x2, int y2, string FileName);
		public static int SaveDrawScreenToDDS(int x1, int y1, int x2, int y2, string FileName) => dx_SaveDrawScreenToDDS(x1, y1, x2, y2, FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawScreenToDDSWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawScreenToDDSWithStrLen(int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength);
		public static int SaveDrawScreenToDDSWithStrLen(int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength) => dx_SaveDrawScreenToDDSWithStrLen(x1, y1, x2, y2, FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawScreenToJPEG", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawScreenToJPEG(int x1, int y1, int x2, int y2, string FileName, int Quality, int Sample2x1);
		public static int SaveDrawScreenToJPEG(int x1, int y1, int x2, int y2, string FileName, int Quality = 80, int Sample2x1 = TRUE) => dx_SaveDrawScreenToJPEG(x1, y1, x2, y2, FileName, Quality, Sample2x1);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawScreenToJPEGWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawScreenToJPEGWithStrLen(int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength, int Quality, int Sample2x1);
		public static int SaveDrawScreenToJPEGWithStrLen(int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength, int Quality = 80, int Sample2x1 = TRUE) => dx_SaveDrawScreenToJPEGWithStrLen(x1, y1, x2, y2, FileName, FileNameLength, Quality, Sample2x1);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawScreenToPNG", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawScreenToPNG(int x1, int y1, int x2, int y2, string FileName, int CompressionLevel);
		public static int SaveDrawScreenToPNG(int x1, int y1, int x2, int y2, string FileName, int CompressionLevel = -1) => dx_SaveDrawScreenToPNG(x1, y1, x2, y2, FileName, CompressionLevel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawScreenToPNGWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawScreenToPNGWithStrLen(int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength, int CompressionLevel);
		public static int SaveDrawScreenToPNGWithStrLen(int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength, int CompressionLevel = -1) => dx_SaveDrawScreenToPNGWithStrLen(x1, y1, x2, y2, FileName, FileNameLength, CompressionLevel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawValidGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawValidGraph(int GrHandle, int x1, int y1, int x2, int y2, string FileName, int SaveType, int Jpeg_Quality, int Jpeg_Sample2x1, int Png_CompressionLevel);
		public static int SaveDrawValidGraph(int GrHandle, int x1, int y1, int x2, int y2, string FileName, int SaveType = DX_IMAGESAVETYPE_BMP, int Jpeg_Quality = 80, int Jpeg_Sample2x1 = TRUE, int Png_CompressionLevel = -1) => dx_SaveDrawValidGraph(GrHandle, x1, y1, x2, y2, FileName, SaveType, Jpeg_Quality, Jpeg_Sample2x1, Png_CompressionLevel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawValidGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawValidGraphWithStrLen(int GrHandle, int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength, int SaveType, int Jpeg_Quality, int Jpeg_Sample2x1, int Png_CompressionLevel);
		public static int SaveDrawValidGraphWithStrLen(int GrHandle, int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength, int SaveType = DX_IMAGESAVETYPE_BMP, int Jpeg_Quality = 80, int Jpeg_Sample2x1 = TRUE, int Png_CompressionLevel = -1) => dx_SaveDrawValidGraphWithStrLen(GrHandle, x1, y1, x2, y2, FileName, FileNameLength, SaveType, Jpeg_Quality, Jpeg_Sample2x1, Png_CompressionLevel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawValidGraphToBMP", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawValidGraphToBMP(int GrHandle, int x1, int y1, int x2, int y2, string FileName);
		public static int SaveDrawValidGraphToBMP(int GrHandle, int x1, int y1, int x2, int y2, string FileName) => dx_SaveDrawValidGraphToBMP(GrHandle, x1, y1, x2, y2, FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawValidGraphToBMPWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawValidGraphToBMPWithStrLen(int GrHandle, int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength);
		public static int SaveDrawValidGraphToBMPWithStrLen(int GrHandle, int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength) => dx_SaveDrawValidGraphToBMPWithStrLen(GrHandle, x1, y1, x2, y2, FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawValidGraphToDDS", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawValidGraphToDDS(int GrHandle, int x1, int y1, int x2, int y2, string FileName);
		public static int SaveDrawValidGraphToDDS(int GrHandle, int x1, int y1, int x2, int y2, string FileName) => dx_SaveDrawValidGraphToDDS(GrHandle, x1, y1, x2, y2, FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawValidGraphToDDSWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawValidGraphToDDSWithStrLen(int GrHandle, int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength);
		public static int SaveDrawValidGraphToDDSWithStrLen(int GrHandle, int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength) => dx_SaveDrawValidGraphToDDSWithStrLen(GrHandle, x1, y1, x2, y2, FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawValidGraphToJPEG", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawValidGraphToJPEG(int GrHandle, int x1, int y1, int x2, int y2, string FileName, int Quality, int Sample2x1);
		public static int SaveDrawValidGraphToJPEG(int GrHandle, int x1, int y1, int x2, int y2, string FileName, int Quality = 80, int Sample2x1 = TRUE) => dx_SaveDrawValidGraphToJPEG(GrHandle, x1, y1, x2, y2, FileName, Quality, Sample2x1);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawValidGraphToJPEGWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawValidGraphToJPEGWithStrLen(int GrHandle, int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength, int Quality, int Sample2x1);
		public static int SaveDrawValidGraphToJPEGWithStrLen(int GrHandle, int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength, int Quality = 80, int Sample2x1 = TRUE) => dx_SaveDrawValidGraphToJPEGWithStrLen(GrHandle, x1, y1, x2, y2, FileName, FileNameLength, Quality, Sample2x1);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawValidGraphToPNG", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawValidGraphToPNG(int GrHandle, int x1, int y1, int x2, int y2, string FileName, int CompressionLevel);
		public static int SaveDrawValidGraphToPNG(int GrHandle, int x1, int y1, int x2, int y2, string FileName, int CompressionLevel = -1) => dx_SaveDrawValidGraphToPNG(GrHandle, x1, y1, x2, y2, FileName, CompressionLevel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveDrawValidGraphToPNGWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveDrawValidGraphToPNGWithStrLen(int GrHandle, int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength, int CompressionLevel);
		public static int SaveDrawValidGraphToPNGWithStrLen(int GrHandle, int x1, int y1, int x2, int y2, string FileName, ulong FileNameLength, int CompressionLevel = -1) => dx_SaveDrawValidGraphToPNGWithStrLen(GrHandle, x1, y1, x2, y2, FileName, FileNameLength, CompressionLevel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateVertexBuffer(int VertexNum, int VertexType);
		public static int CreateVertexBuffer(int VertexNum, int VertexType) => dx_CreateVertexBuffer(VertexNum, VertexType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteVertexBuffer(int VertexBufHandle);
		public static int DeleteVertexBuffer(int VertexBufHandle) => dx_DeleteVertexBuffer(VertexBufHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitVertexBuffer();
		public static int InitVertexBuffer() => dx_InitVertexBuffer();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVertexBufferData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVertexBufferData(int SetIndex, System.IntPtr VertexArray, int VertexNum, int VertexBufHandle);
		public static int SetVertexBufferData(int SetIndex, System.IntPtr VertexArray, int VertexNum, int VertexBufHandle) => dx_SetVertexBufferData(SetIndex, VertexArray, VertexNum, VertexBufHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetBufferVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetBufferVertexBuffer(int VertexBufHandle);
		public static System.IntPtr GetBufferVertexBuffer(int VertexBufHandle) => dx_GetBufferVertexBuffer(VertexBufHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_UpdateVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_UpdateVertexBuffer(int VertexBufHandle, int UpdateStartIndex, int UpdateVertexNum);
		public static int UpdateVertexBuffer(int VertexBufHandle, int UpdateStartIndex, int UpdateVertexNum) => dx_UpdateVertexBuffer(VertexBufHandle, UpdateStartIndex, UpdateVertexNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateIndexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateIndexBuffer(int IndexNum, int IndexType);
		public static int CreateIndexBuffer(int IndexNum, int IndexType) => dx_CreateIndexBuffer(IndexNum, IndexType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteIndexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteIndexBuffer(int IndexBufHandle);
		public static int DeleteIndexBuffer(int IndexBufHandle) => dx_DeleteIndexBuffer(IndexBufHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitIndexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitIndexBuffer();
		public static int InitIndexBuffer() => dx_InitIndexBuffer();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetIndexBufferData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetIndexBufferData(int SetIndex, System.IntPtr IndexArray, int IndexNum, int IndexBufHandle);
		public static int SetIndexBufferData(int SetIndex, System.IntPtr IndexArray, int IndexNum, int IndexBufHandle) => dx_SetIndexBufferData(SetIndex, IndexArray, IndexNum, IndexBufHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetBufferIndexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetBufferIndexBuffer(int IndexBufHandle);
		public static System.IntPtr GetBufferIndexBuffer(int IndexBufHandle) => dx_GetBufferIndexBuffer(IndexBufHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_UpdateIndexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_UpdateIndexBuffer(int IndexBufHandle, int UpdateStartIndex, int UpdateIndexNum);
		public static int UpdateIndexBuffer(int IndexBufHandle, int UpdateStartIndex, int UpdateIndexNum) => dx_UpdateIndexBuffer(IndexBufHandle, UpdateStartIndex, UpdateIndexNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMaxPrimitiveCount", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMaxPrimitiveCount();
		public static int GetMaxPrimitiveCount() => dx_GetMaxPrimitiveCount();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMaxVertexIndex", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMaxVertexIndex();
		public static int GetMaxVertexIndex() => dx_GetMaxVertexIndex();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetValidShaderVersion", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetValidShaderVersion();
		public static int GetValidShaderVersion() => dx_GetValidShaderVersion();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadVertexShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadVertexShader(string FileName);
		public static int LoadVertexShader(string FileName) => dx_LoadVertexShader(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadVertexShaderWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadVertexShaderWithStrLen(string FileName, ulong FileNameLength);
		public static int LoadVertexShaderWithStrLen(string FileName, ulong FileNameLength) => dx_LoadVertexShaderWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadGeometryShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadGeometryShader(string FileName);
		public static int LoadGeometryShader(string FileName) => dx_LoadGeometryShader(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadGeometryShaderWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadGeometryShaderWithStrLen(string FileName, ulong FileNameLength);
		public static int LoadGeometryShaderWithStrLen(string FileName, ulong FileNameLength) => dx_LoadGeometryShaderWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadPixelShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadPixelShader(string FileName);
		public static int LoadPixelShader(string FileName) => dx_LoadPixelShader(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadPixelShaderWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadPixelShaderWithStrLen(string FileName, ulong FileNameLength);
		public static int LoadPixelShaderWithStrLen(string FileName, ulong FileNameLength) => dx_LoadPixelShaderWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadVertexShaderFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadVertexShaderFromMem(System.IntPtr ImageAddress, int ImageSize);
		public static int LoadVertexShaderFromMem(System.IntPtr ImageAddress, int ImageSize) => dx_LoadVertexShaderFromMem(ImageAddress, ImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadGeometryShaderFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadGeometryShaderFromMem(System.IntPtr ImageAddress, int ImageSize);
		public static int LoadGeometryShaderFromMem(System.IntPtr ImageAddress, int ImageSize) => dx_LoadGeometryShaderFromMem(ImageAddress, ImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadPixelShaderFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadPixelShaderFromMem(System.IntPtr ImageAddress, int ImageSize);
		public static int LoadPixelShaderFromMem(System.IntPtr ImageAddress, int ImageSize) => dx_LoadPixelShaderFromMem(ImageAddress, ImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteShader(int ShaderHandle);
		public static int DeleteShader(int ShaderHandle) => dx_DeleteShader(ShaderHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitShader();
		public static int InitShader() => dx_InitShader();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetConstIndexToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetConstIndexToShader(string ConstantName, int ShaderHandle);
		public static int GetConstIndexToShader(string ConstantName, int ShaderHandle) => dx_GetConstIndexToShader(ConstantName, ShaderHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetConstIndexToShaderWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetConstIndexToShaderWithStrLen(string ConstantName, ulong ConstantNameLength, int ShaderHandle);
		public static int GetConstIndexToShaderWithStrLen(string ConstantName, ulong ConstantNameLength, int ShaderHandle) => dx_GetConstIndexToShaderWithStrLen(ConstantName, ConstantNameLength, ShaderHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetConstCountToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetConstCountToShader(string ConstantName, int ShaderHandle);
		public static int GetConstCountToShader(string ConstantName, int ShaderHandle) => dx_GetConstCountToShader(ConstantName, ShaderHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetConstCountToShaderWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetConstCountToShaderWithStrLen(string ConstantName, ulong ConstantNameLength, int ShaderHandle);
		public static int GetConstCountToShaderWithStrLen(string ConstantName, ulong ConstantNameLength, int ShaderHandle) => dx_GetConstCountToShaderWithStrLen(ConstantName, ConstantNameLength, ShaderHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstSF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstSF(int ConstantIndex, float Param);
		public static int SetVSConstSF(int ConstantIndex, float Param) => dx_SetVSConstSF(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstF(int ConstantIndex, FLOAT4 Param);
		public static int SetVSConstF(int ConstantIndex, FLOAT4 Param) => dx_SetVSConstF(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstFMtx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstFMtx(int ConstantIndex, MATRIX Param);
		public static int SetVSConstFMtx(int ConstantIndex, MATRIX Param) => dx_SetVSConstFMtx(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstFMtxT", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstFMtxT(int ConstantIndex, MATRIX Param);
		public static int SetVSConstFMtxT(int ConstantIndex, MATRIX Param) => dx_SetVSConstFMtxT(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstSI", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstSI(int ConstantIndex, int Param);
		public static int SetVSConstSI(int ConstantIndex, int Param) => dx_SetVSConstSI(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstI", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstI(int ConstantIndex, INT4 Param);
		public static int SetVSConstI(int ConstantIndex, INT4 Param) => dx_SetVSConstI(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstB", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstB(int ConstantIndex, int Param);
		public static int SetVSConstB(int ConstantIndex, int Param) => dx_SetVSConstB(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstSFArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstSFArray(int ConstantIndex, [In, Out] float[] ParamArray, int ParamNum);
		public static int SetVSConstSFArray(int ConstantIndex, [In, Out] float[] ParamArray, int ParamNum) => dx_SetVSConstSFArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstFArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstFArray(int ConstantIndex, [In, Out] FLOAT4[] ParamArray, int ParamNum);
		public static int SetVSConstFArray(int ConstantIndex, [In, Out] FLOAT4[] ParamArray, int ParamNum) => dx_SetVSConstFArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstFMtxArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstFMtxArray(int ConstantIndex, [In, Out] MATRIX[] ParamArray, int ParamNum);
		public static int SetVSConstFMtxArray(int ConstantIndex, [In, Out] MATRIX[] ParamArray, int ParamNum) => dx_SetVSConstFMtxArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstFMtxTArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstFMtxTArray(int ConstantIndex, [In, Out] MATRIX[] ParamArray, int ParamNum);
		public static int SetVSConstFMtxTArray(int ConstantIndex, [In, Out] MATRIX[] ParamArray, int ParamNum) => dx_SetVSConstFMtxTArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstSIArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstSIArray(int ConstantIndex, [In, Out] int[] ParamArray, int ParamNum);
		public static int SetVSConstSIArray(int ConstantIndex, [In, Out] int[] ParamArray, int ParamNum) => dx_SetVSConstSIArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstIArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstIArray(int ConstantIndex, [In, Out] INT4[] ParamArray, int ParamNum);
		public static int SetVSConstIArray(int ConstantIndex, [In, Out] INT4[] ParamArray, int ParamNum) => dx_SetVSConstIArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVSConstBArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVSConstBArray(int ConstantIndex, [In, Out] int[] ParamArray, int ParamNum);
		public static int SetVSConstBArray(int ConstantIndex, [In, Out] int[] ParamArray, int ParamNum) => dx_SetVSConstBArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetVSConstF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetVSConstF(int ConstantIndex, int ParamNum);
		public static int ResetVSConstF(int ConstantIndex, int ParamNum) => dx_ResetVSConstF(ConstantIndex, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetVSConstI", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetVSConstI(int ConstantIndex, int ParamNum);
		public static int ResetVSConstI(int ConstantIndex, int ParamNum) => dx_ResetVSConstI(ConstantIndex, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetVSConstB", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetVSConstB(int ConstantIndex, int ParamNum);
		public static int ResetVSConstB(int ConstantIndex, int ParamNum) => dx_ResetVSConstB(ConstantIndex, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstSF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstSF(int ConstantIndex, float Param);
		public static int SetPSConstSF(int ConstantIndex, float Param) => dx_SetPSConstSF(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstF(int ConstantIndex, FLOAT4 Param);
		public static int SetPSConstF(int ConstantIndex, FLOAT4 Param) => dx_SetPSConstF(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstFMtx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstFMtx(int ConstantIndex, MATRIX Param);
		public static int SetPSConstFMtx(int ConstantIndex, MATRIX Param) => dx_SetPSConstFMtx(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstFMtxT", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstFMtxT(int ConstantIndex, MATRIX Param);
		public static int SetPSConstFMtxT(int ConstantIndex, MATRIX Param) => dx_SetPSConstFMtxT(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstSI", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstSI(int ConstantIndex, int Param);
		public static int SetPSConstSI(int ConstantIndex, int Param) => dx_SetPSConstSI(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstI", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstI(int ConstantIndex, INT4 Param);
		public static int SetPSConstI(int ConstantIndex, INT4 Param) => dx_SetPSConstI(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstB", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstB(int ConstantIndex, int Param);
		public static int SetPSConstB(int ConstantIndex, int Param) => dx_SetPSConstB(ConstantIndex, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstSFArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstSFArray(int ConstantIndex, [In, Out] float[] ParamArray, int ParamNum);
		public static int SetPSConstSFArray(int ConstantIndex, [In, Out] float[] ParamArray, int ParamNum) => dx_SetPSConstSFArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstFArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstFArray(int ConstantIndex, [In, Out] FLOAT4[] ParamArray, int ParamNum);
		public static int SetPSConstFArray(int ConstantIndex, [In, Out] FLOAT4[] ParamArray, int ParamNum) => dx_SetPSConstFArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstFMtxArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstFMtxArray(int ConstantIndex, [In, Out] MATRIX[] ParamArray, int ParamNum);
		public static int SetPSConstFMtxArray(int ConstantIndex, [In, Out] MATRIX[] ParamArray, int ParamNum) => dx_SetPSConstFMtxArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstFMtxTArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstFMtxTArray(int ConstantIndex, [In, Out] MATRIX[] ParamArray, int ParamNum);
		public static int SetPSConstFMtxTArray(int ConstantIndex, [In, Out] MATRIX[] ParamArray, int ParamNum) => dx_SetPSConstFMtxTArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstSIArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstSIArray(int ConstantIndex, [In, Out] int[] ParamArray, int ParamNum);
		public static int SetPSConstSIArray(int ConstantIndex, [In, Out] int[] ParamArray, int ParamNum) => dx_SetPSConstSIArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstIArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstIArray(int ConstantIndex, [In, Out] INT4[] ParamArray, int ParamNum);
		public static int SetPSConstIArray(int ConstantIndex, [In, Out] INT4[] ParamArray, int ParamNum) => dx_SetPSConstIArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPSConstBArray", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPSConstBArray(int ConstantIndex, [In, Out] int[] ParamArray, int ParamNum);
		public static int SetPSConstBArray(int ConstantIndex, [In, Out] int[] ParamArray, int ParamNum) => dx_SetPSConstBArray(ConstantIndex, ParamArray, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetPSConstF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetPSConstF(int ConstantIndex, int ParamNum);
		public static int ResetPSConstF(int ConstantIndex, int ParamNum) => dx_ResetPSConstF(ConstantIndex, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetPSConstI", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetPSConstI(int ConstantIndex, int ParamNum);
		public static int ResetPSConstI(int ConstantIndex, int ParamNum) => dx_ResetPSConstI(ConstantIndex, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetPSConstB", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetPSConstB(int ConstantIndex, int ParamNum);
		public static int ResetPSConstB(int ConstantIndex, int ParamNum) => dx_ResetPSConstB(ConstantIndex, ParamNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetRenderTargetToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetRenderTargetToShader(int TargetIndex, int DrawScreen, int SurfaceIndex, int MipLevel);
		public static int SetRenderTargetToShader(int TargetIndex, int DrawScreen, int SurfaceIndex = 0, int MipLevel = 0) => dx_SetRenderTargetToShader(TargetIndex, DrawScreen, SurfaceIndex, MipLevel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseTextureToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseTextureToShader(int StageIndex, int GraphHandle);
		public static int SetUseTextureToShader(int StageIndex, int GraphHandle) => dx_SetUseTextureToShader(StageIndex, GraphHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseVertexShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseVertexShader(int ShaderHandle);
		public static int SetUseVertexShader(int ShaderHandle) => dx_SetUseVertexShader(ShaderHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseGeometryShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseGeometryShader(int ShaderHandle);
		public static int SetUseGeometryShader(int ShaderHandle) => dx_SetUseGeometryShader(ShaderHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUsePixelShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUsePixelShader(int ShaderHandle);
		public static int SetUsePixelShader(int ShaderHandle) => dx_SetUsePixelShader(ShaderHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CalcPolygonBinormalAndTangentsToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CalcPolygonBinormalAndTangentsToShader([In, Out] VERTEX3DSHADER[] VertexArray, int PolygonNum);
		public static int CalcPolygonBinormalAndTangentsToShader([In, Out] VERTEX3DSHADER[] VertexArray, int PolygonNum) => dx_CalcPolygonBinormalAndTangentsToShader(VertexArray, PolygonNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CalcPolygonIndexedBinormalAndTangentsToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CalcPolygonIndexedBinormalAndTangentsToShader([In, Out] VERTEX3DSHADER[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int PolygonNum);
		public static int CalcPolygonIndexedBinormalAndTangentsToShader([In, Out] VERTEX3DSHADER[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int PolygonNum) => dx_CalcPolygonIndexedBinormalAndTangentsToShader(VertexArray, VertexNum, IndexArray, PolygonNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawBillboard3DToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawBillboard3DToShader(VECTOR Pos, float cx, float cy, float Size, float Angle, int GrHandle, int TransFlag, int ReverseXFlag, int ReverseYFlag);
		public static int DrawBillboard3DToShader(VECTOR Pos, float cx, float cy, float Size, float Angle, int GrHandle, int TransFlag, int ReverseXFlag = FALSE, int ReverseYFlag = FALSE) => dx_DrawBillboard3DToShader(Pos, cx, cy, Size, Angle, GrHandle, TransFlag, ReverseXFlag, ReverseYFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygon2DToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygon2DToShader([In, Out] VERTEX2DSHADER[] VertexArray, int PolygonNum);
		public static int DrawPolygon2DToShader([In, Out] VERTEX2DSHADER[] VertexArray, int PolygonNum) => dx_DrawPolygon2DToShader(VertexArray, PolygonNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygon3DToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygon3DToShader([In, Out] VERTEX3DSHADER[] VertexArray, int PolygonNum);
		public static int DrawPolygon3DToShader([In, Out] VERTEX3DSHADER[] VertexArray, int PolygonNum) => dx_DrawPolygon3DToShader(VertexArray, PolygonNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygonIndexed2DToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygonIndexed2DToShader([In, Out] VERTEX2DSHADER[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int PolygonNum);
		public static int DrawPolygonIndexed2DToShader([In, Out] VERTEX2DSHADER[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int PolygonNum) => dx_DrawPolygonIndexed2DToShader(VertexArray, VertexNum, IndexArray, PolygonNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygonIndexed3DToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygonIndexed3DToShader([In, Out] VERTEX3DSHADER[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int PolygonNum);
		public static int DrawPolygonIndexed3DToShader([In, Out] VERTEX3DSHADER[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int PolygonNum) => dx_DrawPolygonIndexed3DToShader(VertexArray, VertexNum, IndexArray, PolygonNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitive2DToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitive2DToShader([In, Out] VERTEX2DSHADER[] VertexArray, int VertexNum, int PrimitiveType);
		public static int DrawPrimitive2DToShader([In, Out] VERTEX2DSHADER[] VertexArray, int VertexNum, int PrimitiveType) => dx_DrawPrimitive2DToShader(VertexArray, VertexNum, PrimitiveType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitive3DToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitive3DToShader([In, Out] VERTEX3DSHADER[] VertexArray, int VertexNum, int PrimitiveType);
		public static int DrawPrimitive3DToShader([In, Out] VERTEX3DSHADER[] VertexArray, int VertexNum, int PrimitiveType) => dx_DrawPrimitive3DToShader(VertexArray, VertexNum, PrimitiveType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitiveIndexed2DToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitiveIndexed2DToShader([In, Out] VERTEX2DSHADER[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int IndexNum, int PrimitiveType);
		public static int DrawPrimitiveIndexed2DToShader([In, Out] VERTEX2DSHADER[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int IndexNum, int PrimitiveType) => dx_DrawPrimitiveIndexed2DToShader(VertexArray, VertexNum, IndexArray, IndexNum, PrimitiveType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitiveIndexed3DToShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitiveIndexed3DToShader([In, Out] VERTEX3DSHADER[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int IndexNum, int PrimitiveType);
		public static int DrawPrimitiveIndexed3DToShader([In, Out] VERTEX3DSHADER[] VertexArray, int VertexNum, [In, Out] ushort[] IndexArray, int IndexNum, int PrimitiveType) => dx_DrawPrimitiveIndexed3DToShader(VertexArray, VertexNum, IndexArray, IndexNum, PrimitiveType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygon3DToShader_UseVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygon3DToShader_UseVertexBuffer(int VertexBufHandle);
		public static int DrawPolygon3DToShader_UseVertexBuffer(int VertexBufHandle) => dx_DrawPolygon3DToShader_UseVertexBuffer(VertexBufHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPolygonIndexed3DToShader_UseVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPolygonIndexed3DToShader_UseVertexBuffer(int VertexBufHandle, int IndexBufHandle);
		public static int DrawPolygonIndexed3DToShader_UseVertexBuffer(int VertexBufHandle, int IndexBufHandle) => dx_DrawPolygonIndexed3DToShader_UseVertexBuffer(VertexBufHandle, IndexBufHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitive3DToShader_UseVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitive3DToShader_UseVertexBuffer(int VertexBufHandle, int PrimitiveType);
		public static int DrawPrimitive3DToShader_UseVertexBuffer(int VertexBufHandle, int PrimitiveType) => dx_DrawPrimitive3DToShader_UseVertexBuffer(VertexBufHandle, PrimitiveType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitive3DToShader_UseVertexBuffer2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitive3DToShader_UseVertexBuffer2(int VertexBufHandle, int PrimitiveType, int StartVertex, int UseVertexNum);
		public static int DrawPrimitive3DToShader_UseVertexBuffer2(int VertexBufHandle, int PrimitiveType, int StartVertex, int UseVertexNum) => dx_DrawPrimitive3DToShader_UseVertexBuffer2(VertexBufHandle, PrimitiveType, StartVertex, UseVertexNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitiveIndexed3DToShader_UseVertexBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitiveIndexed3DToShader_UseVertexBuffer(int VertexBufHandle, int IndexBufHandle, int PrimitiveType);
		public static int DrawPrimitiveIndexed3DToShader_UseVertexBuffer(int VertexBufHandle, int IndexBufHandle, int PrimitiveType) => dx_DrawPrimitiveIndexed3DToShader_UseVertexBuffer(VertexBufHandle, IndexBufHandle, PrimitiveType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPrimitiveIndexed3DToShader_UseVertexBuffer2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPrimitiveIndexed3DToShader_UseVertexBuffer2(int VertexBufHandle, int IndexBufHandle, int PrimitiveType, int BaseVertex, int StartVertex, int UseVertexNum, int StartIndex, int UseIndexNum);
		public static int DrawPrimitiveIndexed3DToShader_UseVertexBuffer2(int VertexBufHandle, int IndexBufHandle, int PrimitiveType, int BaseVertex, int StartVertex, int UseVertexNum, int StartIndex, int UseIndexNum) => dx_DrawPrimitiveIndexed3DToShader_UseVertexBuffer2(VertexBufHandle, IndexBufHandle, PrimitiveType, BaseVertex, StartVertex, UseVertexNum, StartIndex, UseIndexNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitShaderConstantBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitShaderConstantBuffer();
		public static int InitShaderConstantBuffer() => dx_InitShaderConstantBuffer();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateShaderConstantBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateShaderConstantBuffer(int BufferSize);
		public static int CreateShaderConstantBuffer(int BufferSize) => dx_CreateShaderConstantBuffer(BufferSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteShaderConstantBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteShaderConstantBuffer(int SConstBufHandle);
		public static int DeleteShaderConstantBuffer(int SConstBufHandle) => dx_DeleteShaderConstantBuffer(SConstBufHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetBufferShaderConstantBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetBufferShaderConstantBuffer(int SConstBufHandle);
		public static System.IntPtr GetBufferShaderConstantBuffer(int SConstBufHandle) => dx_GetBufferShaderConstantBuffer(SConstBufHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_UpdateShaderConstantBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_UpdateShaderConstantBuffer(int SConstBufHandle);
		public static int UpdateShaderConstantBuffer(int SConstBufHandle) => dx_UpdateShaderConstantBuffer(SConstBufHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetShaderConstantBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetShaderConstantBuffer(int SConstBufHandle, int TargetShader, int Slot);
		public static int SetShaderConstantBuffer(int SConstBufHandle, int TargetShader, int Slot) => dx_SetShaderConstantBuffer(SConstBufHandle, TargetShader, Slot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetGraphFilterBltBlendMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetGraphFilterBltBlendMode(int BlendMode);
		public static int SetGraphFilterBltBlendMode(int BlendMode) => dx_SetGraphFilterBltBlendMode(BlendMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlayMovie", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlayMovie(string FileName, int ExRate, int PlayType);
		public static int PlayMovie(string FileName, int ExRate, int PlayType) => dx_PlayMovie(FileName, ExRate, PlayType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlayMovieWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlayMovieWithStrLen(string FileName, ulong FileNameLength, int ExRate, int PlayType);
		public static int PlayMovieWithStrLen(string FileName, ulong FileNameLength, int ExRate, int PlayType) => dx_PlayMovieWithStrLen(FileName, FileNameLength, ExRate, PlayType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMovieImageSize_File", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMovieImageSize_File(string FileName, out int SizeX, out int SizeY);
		public static int GetMovieImageSize_File(string FileName, out int SizeX, out int SizeY) => dx_GetMovieImageSize_File(FileName, out SizeX, out SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMovieImageSize_File_WithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMovieImageSize_File_WithStrLen(string FileName, ulong FileNameLength, out int SizeX, out int SizeY);
		public static int GetMovieImageSize_File_WithStrLen(string FileName, ulong FileNameLength, out int SizeX, out int SizeY) => dx_GetMovieImageSize_File_WithStrLen(FileName, FileNameLength, out SizeX, out SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMovieImageSize_Mem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMovieImageSize_Mem(System.IntPtr FileImage, int FileImageSize, out int SizeX, out int SizeY);
		public static int GetMovieImageSize_Mem(System.IntPtr FileImage, int FileImageSize, out int SizeX, out int SizeY) => dx_GetMovieImageSize_Mem(FileImage, FileImageSize, out SizeX, out SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_OpenMovieToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_OpenMovieToGraph(string FileName, int FullColor);
		public static int OpenMovieToGraph(string FileName, int FullColor = TRUE) => dx_OpenMovieToGraph(FileName, FullColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_OpenMovieToGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_OpenMovieToGraphWithStrLen(string FileName, ulong FileNameLength, int FullColor);
		public static int OpenMovieToGraphWithStrLen(string FileName, ulong FileNameLength, int FullColor = TRUE) => dx_OpenMovieToGraphWithStrLen(FileName, FileNameLength, FullColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlayMovieToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlayMovieToGraph(int GraphHandle, int PlayType, int SysPlay);
		public static int PlayMovieToGraph(int GraphHandle, int PlayType = DX_PLAYTYPE_BACK, int SysPlay = 0) => dx_PlayMovieToGraph(GraphHandle, PlayType, SysPlay);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PauseMovieToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PauseMovieToGraph(int GraphHandle, int SysPause);
		public static int PauseMovieToGraph(int GraphHandle, int SysPause = 0) => dx_PauseMovieToGraph(GraphHandle, SysPause);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddMovieFrameToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddMovieFrameToGraph(int GraphHandle, uint FrameNum);
		public static int AddMovieFrameToGraph(int GraphHandle, uint FrameNum) => dx_AddMovieFrameToGraph(GraphHandle, FrameNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SeekMovieToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SeekMovieToGraph(int GraphHandle, int Time);
		public static int SeekMovieToGraph(int GraphHandle, int Time) => dx_SeekMovieToGraph(GraphHandle, Time);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPlaySpeedRateMovieToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPlaySpeedRateMovieToGraph(int GraphHandle, double SpeedRate);
		public static int SetPlaySpeedRateMovieToGraph(int GraphHandle, double SpeedRate) => dx_SetPlaySpeedRateMovieToGraph(GraphHandle, SpeedRate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMovieStateToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMovieStateToGraph(int GraphHandle);
		public static int GetMovieStateToGraph(int GraphHandle) => dx_GetMovieStateToGraph(GraphHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMovieVolumeToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMovieVolumeToGraph(int Volume, int GraphHandle);
		public static int SetMovieVolumeToGraph(int Volume, int GraphHandle) => dx_SetMovieVolumeToGraph(Volume, GraphHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeMovieVolumeToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeMovieVolumeToGraph(int Volume, int GraphHandle);
		public static int ChangeMovieVolumeToGraph(int Volume, int GraphHandle) => dx_ChangeMovieVolumeToGraph(Volume, GraphHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMovieTotalFrameToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMovieTotalFrameToGraph(int GraphHandle);
		public static int GetMovieTotalFrameToGraph(int GraphHandle) => dx_GetMovieTotalFrameToGraph(GraphHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_TellMovieToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_TellMovieToGraph(int GraphHandle);
		public static int TellMovieToGraph(int GraphHandle) => dx_TellMovieToGraph(GraphHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_TellMovieToGraphToFrame", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_TellMovieToGraphToFrame(int GraphHandle);
		public static int TellMovieToGraphToFrame(int GraphHandle) => dx_TellMovieToGraphToFrame(GraphHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SeekMovieToGraphToFrame", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SeekMovieToGraphToFrame(int GraphHandle, int Frame);
		public static int SeekMovieToGraphToFrame(int GraphHandle, int Frame) => dx_SeekMovieToGraphToFrame(GraphHandle, Frame);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetOneFrameTimeMovieToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_GetOneFrameTimeMovieToGraph(int GraphHandle);
		public static long GetOneFrameTimeMovieToGraph(int GraphHandle) => dx_GetOneFrameTimeMovieToGraph(GraphHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLastUpdateTimeMovieToGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLastUpdateTimeMovieToGraph(int GraphHandle);
		public static int GetLastUpdateTimeMovieToGraph(int GraphHandle) => dx_GetLastUpdateTimeMovieToGraph(GraphHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMovieRightImageAlphaFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMovieRightImageAlphaFlag(int Flag);
		public static int SetMovieRightImageAlphaFlag(int Flag) => dx_SetMovieRightImageAlphaFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMovieColorA8R8G8B8Flag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMovieColorA8R8G8B8Flag(int Flag);
		public static int SetMovieColorA8R8G8B8Flag(int Flag) => dx_SetMovieColorA8R8G8B8Flag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMovieUseYUVFormatSurfaceFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMovieUseYUVFormatSurfaceFlag(int Flag);
		public static int SetMovieUseYUVFormatSurfaceFlag(int Flag) => dx_SetMovieUseYUVFormatSurfaceFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraNearFar", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraNearFar(float Near, float Far);
		public static int SetCameraNearFar(float Near, float Far) => dx_SetCameraNearFar(Near, Far);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraNearFarD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraNearFarD(double Near, double Far);
		public static int SetCameraNearFarD(double Near, double Far) => dx_SetCameraNearFarD(Near, Far);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraPositionAndTarget_UpVecY", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraPositionAndTarget_UpVecY(VECTOR Position, VECTOR Target);
		public static int SetCameraPositionAndTarget_UpVecY(VECTOR Position, VECTOR Target) => dx_SetCameraPositionAndTarget_UpVecY(Position, Target);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraPositionAndTarget_UpVecYD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraPositionAndTarget_UpVecYD(VECTOR_D Position, VECTOR_D Target);
		public static int SetCameraPositionAndTarget_UpVecYD(VECTOR_D Position, VECTOR_D Target) => dx_SetCameraPositionAndTarget_UpVecYD(Position, Target);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraPositionAndTargetAndUpVec", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraPositionAndTargetAndUpVec(VECTOR Position, VECTOR TargetPosition, VECTOR UpVector);
		public static int SetCameraPositionAndTargetAndUpVec(VECTOR Position, VECTOR TargetPosition, VECTOR UpVector) => dx_SetCameraPositionAndTargetAndUpVec(Position, TargetPosition, UpVector);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraPositionAndTargetAndUpVecD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraPositionAndTargetAndUpVecD(VECTOR_D Position, VECTOR_D TargetPosition, VECTOR_D UpVector);
		public static int SetCameraPositionAndTargetAndUpVecD(VECTOR_D Position, VECTOR_D TargetPosition, VECTOR_D UpVector) => dx_SetCameraPositionAndTargetAndUpVecD(Position, TargetPosition, UpVector);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraPositionAndAngle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraPositionAndAngle(VECTOR Position, float VRotate, float HRotate, float TRotate);
		public static int SetCameraPositionAndAngle(VECTOR Position, float VRotate, float HRotate, float TRotate) => dx_SetCameraPositionAndAngle(Position, VRotate, HRotate, TRotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraPositionAndAngleD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraPositionAndAngleD(VECTOR_D Position, double VRotate, double HRotate, double TRotate);
		public static int SetCameraPositionAndAngleD(VECTOR_D Position, double VRotate, double HRotate, double TRotate) => dx_SetCameraPositionAndAngleD(Position, VRotate, HRotate, TRotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraViewMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraViewMatrix(MATRIX ViewMatrix);
		public static int SetCameraViewMatrix(MATRIX ViewMatrix) => dx_SetCameraViewMatrix(ViewMatrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraViewMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraViewMatrixD(MATRIX_D ViewMatrix);
		public static int SetCameraViewMatrixD(MATRIX_D ViewMatrix) => dx_SetCameraViewMatrixD(ViewMatrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraScreenCenter", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraScreenCenter(float x, float y);
		public static int SetCameraScreenCenter(float x, float y) => dx_SetCameraScreenCenter(x, y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraScreenCenterD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraScreenCenterD(double x, double y);
		public static int SetCameraScreenCenterD(double x, double y) => dx_SetCameraScreenCenterD(x, y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetupCamera_Perspective", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetupCamera_Perspective(float Fov);
		public static int SetupCamera_Perspective(float Fov) => dx_SetupCamera_Perspective(Fov);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetupCamera_PerspectiveD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetupCamera_PerspectiveD(double Fov);
		public static int SetupCamera_PerspectiveD(double Fov) => dx_SetupCamera_PerspectiveD(Fov);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetupCamera_Ortho", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetupCamera_Ortho(float Size);
		public static int SetupCamera_Ortho(float Size) => dx_SetupCamera_Ortho(Size);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetupCamera_OrthoD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetupCamera_OrthoD(double Size);
		public static int SetupCamera_OrthoD(double Size) => dx_SetupCamera_OrthoD(Size);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetupCamera_ProjectionMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetupCamera_ProjectionMatrix(MATRIX ProjectionMatrix);
		public static int SetupCamera_ProjectionMatrix(MATRIX ProjectionMatrix) => dx_SetupCamera_ProjectionMatrix(ProjectionMatrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetupCamera_ProjectionMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetupCamera_ProjectionMatrixD(MATRIX_D ProjectionMatrix);
		public static int SetupCamera_ProjectionMatrixD(MATRIX_D ProjectionMatrix) => dx_SetupCamera_ProjectionMatrixD(ProjectionMatrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraDotAspect", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraDotAspect(float DotAspect);
		public static int SetCameraDotAspect(float DotAspect) => dx_SetCameraDotAspect(DotAspect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCameraDotAspectD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCameraDotAspectD(double DotAspect);
		public static int SetCameraDotAspectD(double DotAspect) => dx_SetCameraDotAspectD(DotAspect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckCameraViewClip", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckCameraViewClip(VECTOR CheckPos);
		public static int CheckCameraViewClip(VECTOR CheckPos) => dx_CheckCameraViewClip(CheckPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckCameraViewClipD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckCameraViewClipD(VECTOR_D CheckPos);
		public static int CheckCameraViewClipD(VECTOR_D CheckPos) => dx_CheckCameraViewClipD(CheckPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckCameraViewClip_Dir", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckCameraViewClip_Dir(VECTOR CheckPos);
		public static int CheckCameraViewClip_Dir(VECTOR CheckPos) => dx_CheckCameraViewClip_Dir(CheckPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckCameraViewClip_DirD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckCameraViewClip_DirD(VECTOR_D CheckPos);
		public static int CheckCameraViewClip_DirD(VECTOR_D CheckPos) => dx_CheckCameraViewClip_DirD(CheckPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckCameraViewClip_Box", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckCameraViewClip_Box(VECTOR BoxPos1, VECTOR BoxPos2);
		public static int CheckCameraViewClip_Box(VECTOR BoxPos1, VECTOR BoxPos2) => dx_CheckCameraViewClip_Box(BoxPos1, BoxPos2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckCameraViewClip_BoxD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckCameraViewClip_BoxD(VECTOR_D BoxPos1, VECTOR_D BoxPos2);
		public static int CheckCameraViewClip_BoxD(VECTOR_D BoxPos1, VECTOR_D BoxPos2) => dx_CheckCameraViewClip_BoxD(BoxPos1, BoxPos2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraNear", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetCameraNear();
		public static float GetCameraNear() => dx_GetCameraNear();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraNearD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_GetCameraNearD();
		public static double GetCameraNearD() => dx_GetCameraNearD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraFar", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetCameraFar();
		public static float GetCameraFar() => dx_GetCameraFar();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraFarD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_GetCameraFarD();
		public static double GetCameraFarD() => dx_GetCameraFarD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraPosition", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_GetCameraPosition();
		public static VECTOR GetCameraPosition() => dx_GetCameraPosition();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraPositionD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_GetCameraPositionD();
		public static VECTOR_D GetCameraPositionD() => dx_GetCameraPositionD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraTarget", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_GetCameraTarget();
		public static VECTOR GetCameraTarget() => dx_GetCameraTarget();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraTargetD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_GetCameraTargetD();
		public static VECTOR_D GetCameraTargetD() => dx_GetCameraTargetD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraUpVector", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_GetCameraUpVector();
		public static VECTOR GetCameraUpVector() => dx_GetCameraUpVector();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraUpVectorD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_GetCameraUpVectorD();
		public static VECTOR_D GetCameraUpVectorD() => dx_GetCameraUpVectorD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraDownVector", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_GetCameraDownVector();
		public static VECTOR GetCameraDownVector() => dx_GetCameraDownVector();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraDownVectorD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_GetCameraDownVectorD();
		public static VECTOR_D GetCameraDownVectorD() => dx_GetCameraDownVectorD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraRightVector", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_GetCameraRightVector();
		public static VECTOR GetCameraRightVector() => dx_GetCameraRightVector();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraRightVectorD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_GetCameraRightVectorD();
		public static VECTOR_D GetCameraRightVectorD() => dx_GetCameraRightVectorD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraLeftVector", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_GetCameraLeftVector();
		public static VECTOR GetCameraLeftVector() => dx_GetCameraLeftVector();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraLeftVectorD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_GetCameraLeftVectorD();
		public static VECTOR_D GetCameraLeftVectorD() => dx_GetCameraLeftVectorD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraFrontVector", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_GetCameraFrontVector();
		public static VECTOR GetCameraFrontVector() => dx_GetCameraFrontVector();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraFrontVectorD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_GetCameraFrontVectorD();
		public static VECTOR_D GetCameraFrontVectorD() => dx_GetCameraFrontVectorD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraBackVector", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_GetCameraBackVector();
		public static VECTOR GetCameraBackVector() => dx_GetCameraBackVector();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraBackVectorD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_GetCameraBackVectorD();
		public static VECTOR_D GetCameraBackVectorD() => dx_GetCameraBackVectorD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraAngleHRotate", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetCameraAngleHRotate();
		public static float GetCameraAngleHRotate() => dx_GetCameraAngleHRotate();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraAngleHRotateD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_GetCameraAngleHRotateD();
		public static double GetCameraAngleHRotateD() => dx_GetCameraAngleHRotateD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraAngleVRotate", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetCameraAngleVRotate();
		public static float GetCameraAngleVRotate() => dx_GetCameraAngleVRotate();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraAngleVRotateD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_GetCameraAngleVRotateD();
		public static double GetCameraAngleVRotateD() => dx_GetCameraAngleVRotateD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraAngleTRotate", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetCameraAngleTRotate();
		public static float GetCameraAngleTRotate() => dx_GetCameraAngleTRotate();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraAngleTRotateD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_GetCameraAngleTRotateD();
		public static double GetCameraAngleTRotateD() => dx_GetCameraAngleTRotateD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraViewMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_GetCameraViewMatrix();
		public static MATRIX GetCameraViewMatrix() => dx_GetCameraViewMatrix();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraViewMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_GetCameraViewMatrixD();
		public static MATRIX_D GetCameraViewMatrixD() => dx_GetCameraViewMatrixD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraBillboardMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_GetCameraBillboardMatrix();
		public static MATRIX GetCameraBillboardMatrix() => dx_GetCameraBillboardMatrix();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraBillboardMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_GetCameraBillboardMatrixD();
		public static MATRIX_D GetCameraBillboardMatrixD() => dx_GetCameraBillboardMatrixD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraScreenCenter", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCameraScreenCenter(out float x, out float y);
		public static int GetCameraScreenCenter(out float x, out float y) => dx_GetCameraScreenCenter(out x, out y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraScreenCenterD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCameraScreenCenterD(out double x, out double y);
		public static int GetCameraScreenCenterD(out double x, out double y) => dx_GetCameraScreenCenterD(out x, out y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraFov", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetCameraFov();
		public static float GetCameraFov() => dx_GetCameraFov();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraFovD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_GetCameraFovD();
		public static double GetCameraFovD() => dx_GetCameraFovD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraSize", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetCameraSize();
		public static float GetCameraSize() => dx_GetCameraSize();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraSizeD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_GetCameraSizeD();
		public static double GetCameraSizeD() => dx_GetCameraSizeD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraProjectionMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_GetCameraProjectionMatrix();
		public static MATRIX GetCameraProjectionMatrix() => dx_GetCameraProjectionMatrix();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraProjectionMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_GetCameraProjectionMatrixD();
		public static MATRIX_D GetCameraProjectionMatrixD() => dx_GetCameraProjectionMatrixD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraDotAspect", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetCameraDotAspect();
		public static float GetCameraDotAspect() => dx_GetCameraDotAspect();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraDotAspectD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_GetCameraDotAspectD();
		public static double GetCameraDotAspectD() => dx_GetCameraDotAspectD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraViewportMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_GetCameraViewportMatrix();
		public static MATRIX GetCameraViewportMatrix() => dx_GetCameraViewportMatrix();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraViewportMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_GetCameraViewportMatrixD();
		public static MATRIX_D GetCameraViewportMatrixD() => dx_GetCameraViewportMatrixD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraAPIViewportMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_GetCameraAPIViewportMatrix();
		public static MATRIX GetCameraAPIViewportMatrix() => dx_GetCameraAPIViewportMatrix();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCameraAPIViewportMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_GetCameraAPIViewportMatrixD();
		public static MATRIX_D GetCameraAPIViewportMatrixD() => dx_GetCameraAPIViewportMatrixD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseLighting", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseLighting(int Flag);
		public static int SetUseLighting(int Flag) => dx_SetUseLighting(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMaterialUseVertDifColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMaterialUseVertDifColor(int UseFlag);
		public static int SetMaterialUseVertDifColor(int UseFlag) => dx_SetMaterialUseVertDifColor(UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMaterialUseVertSpcColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMaterialUseVertSpcColor(int UseFlag);
		public static int SetMaterialUseVertSpcColor(int UseFlag) => dx_SetMaterialUseVertSpcColor(UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMaterialParam", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMaterialParam(MATERIALPARAM Material);
		public static int SetMaterialParam(MATERIALPARAM Material) => dx_SetMaterialParam(Material);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseSpecular", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseSpecular(int UseFlag);
		public static int SetUseSpecular(int UseFlag) => dx_SetUseSpecular(UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetGlobalAmbientLight", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetGlobalAmbientLight(COLOR_F Color);
		public static int SetGlobalAmbientLight(COLOR_F Color) => dx_SetGlobalAmbientLight(Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeLightTypeDir", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeLightTypeDir(VECTOR Direction);
		public static int ChangeLightTypeDir(VECTOR Direction) => dx_ChangeLightTypeDir(Direction);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeLightTypeSpot", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeLightTypeSpot(VECTOR Position, VECTOR Direction, float OutAngle, float InAngle, float Range, float Atten0, float Atten1, float Atten2);
		public static int ChangeLightTypeSpot(VECTOR Position, VECTOR Direction, float OutAngle, float InAngle, float Range, float Atten0, float Atten1, float Atten2) => dx_ChangeLightTypeSpot(Position, Direction, OutAngle, InAngle, Range, Atten0, Atten1, Atten2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeLightTypePoint", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeLightTypePoint(VECTOR Position, float Range, float Atten0, float Atten1, float Atten2);
		public static int ChangeLightTypePoint(VECTOR Position, float Range, float Atten0, float Atten1, float Atten2) => dx_ChangeLightTypePoint(Position, Range, Atten0, Atten1, Atten2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLightType();
		public static int GetLightType() => dx_GetLightType();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightEnable", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightEnable(int EnableFlag);
		public static int SetLightEnable(int EnableFlag) => dx_SetLightEnable(EnableFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightEnable", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLightEnable();
		public static int GetLightEnable() => dx_GetLightEnable();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightDifColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightDifColor(COLOR_F Color);
		public static int SetLightDifColor(COLOR_F Color) => dx_SetLightDifColor(Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightDifColor", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_GetLightDifColor();
		public static COLOR_F GetLightDifColor() => dx_GetLightDifColor();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightSpcColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightSpcColor(COLOR_F Color);
		public static int SetLightSpcColor(COLOR_F Color) => dx_SetLightSpcColor(Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightSpcColor", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_GetLightSpcColor();
		public static COLOR_F GetLightSpcColor() => dx_GetLightSpcColor();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightAmbColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightAmbColor(COLOR_F Color);
		public static int SetLightAmbColor(COLOR_F Color) => dx_SetLightAmbColor(Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightAmbColor", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_GetLightAmbColor();
		public static COLOR_F GetLightAmbColor() => dx_GetLightAmbColor();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightDirection", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightDirection(VECTOR Direction);
		public static int SetLightDirection(VECTOR Direction) => dx_SetLightDirection(Direction);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightDirection", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_GetLightDirection();
		public static VECTOR GetLightDirection() => dx_GetLightDirection();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightPosition(VECTOR Position);
		public static int SetLightPosition(VECTOR Position) => dx_SetLightPosition(Position);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightPosition", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_GetLightPosition();
		public static VECTOR GetLightPosition() => dx_GetLightPosition();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightRangeAtten", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightRangeAtten(float Range, float Atten0, float Atten1, float Atten2);
		public static int SetLightRangeAtten(float Range, float Atten0, float Atten1, float Atten2) => dx_SetLightRangeAtten(Range, Atten0, Atten1, Atten2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightRangeAtten", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLightRangeAtten(out float Range, out float Atten0, out float Atten1, out float Atten2);
		public static int GetLightRangeAtten(out float Range, out float Atten0, out float Atten1, out float Atten2) => dx_GetLightRangeAtten(out Range, out Atten0, out Atten1, out Atten2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightAngle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightAngle(float OutAngle, float InAngle);
		public static int SetLightAngle(float OutAngle, float InAngle) => dx_SetLightAngle(OutAngle, InAngle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightAngle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLightAngle(out float OutAngle, out float InAngle);
		public static int GetLightAngle(out float OutAngle, out float InAngle) => dx_GetLightAngle(out OutAngle, out InAngle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightUseShadowMap", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightUseShadowMap(int SmSlotIndex, int UseFlag);
		public static int SetLightUseShadowMap(int SmSlotIndex, int UseFlag) => dx_SetLightUseShadowMap(SmSlotIndex, UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateDirLightHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateDirLightHandle(VECTOR Direction);
		public static int CreateDirLightHandle(VECTOR Direction) => dx_CreateDirLightHandle(Direction);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateSpotLightHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateSpotLightHandle(VECTOR Position, VECTOR Direction, float OutAngle, float InAngle, float Range, float Atten0, float Atten1, float Atten2);
		public static int CreateSpotLightHandle(VECTOR Position, VECTOR Direction, float OutAngle, float InAngle, float Range, float Atten0, float Atten1, float Atten2) => dx_CreateSpotLightHandle(Position, Direction, OutAngle, InAngle, Range, Atten0, Atten1, Atten2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreatePointLightHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreatePointLightHandle(VECTOR Position, float Range, float Atten0, float Atten1, float Atten2);
		public static int CreatePointLightHandle(VECTOR Position, float Range, float Atten0, float Atten1, float Atten2) => dx_CreatePointLightHandle(Position, Range, Atten0, Atten1, Atten2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteLightHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteLightHandle(int LHandle);
		public static int DeleteLightHandle(int LHandle) => dx_DeleteLightHandle(LHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteLightHandleAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteLightHandleAll();
		public static int DeleteLightHandleAll() => dx_DeleteLightHandleAll();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightTypeHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightTypeHandle(int LHandle, int LightType);
		public static int SetLightTypeHandle(int LHandle, int LightType) => dx_SetLightTypeHandle(LHandle, LightType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightEnableHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightEnableHandle(int LHandle, int EnableFlag);
		public static int SetLightEnableHandle(int LHandle, int EnableFlag) => dx_SetLightEnableHandle(LHandle, EnableFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightDifColorHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightDifColorHandle(int LHandle, COLOR_F Color);
		public static int SetLightDifColorHandle(int LHandle, COLOR_F Color) => dx_SetLightDifColorHandle(LHandle, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightSpcColorHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightSpcColorHandle(int LHandle, COLOR_F Color);
		public static int SetLightSpcColorHandle(int LHandle, COLOR_F Color) => dx_SetLightSpcColorHandle(LHandle, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightAmbColorHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightAmbColorHandle(int LHandle, COLOR_F Color);
		public static int SetLightAmbColorHandle(int LHandle, COLOR_F Color) => dx_SetLightAmbColorHandle(LHandle, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightDirectionHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightDirectionHandle(int LHandle, VECTOR Direction);
		public static int SetLightDirectionHandle(int LHandle, VECTOR Direction) => dx_SetLightDirectionHandle(LHandle, Direction);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightPositionHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightPositionHandle(int LHandle, VECTOR Position);
		public static int SetLightPositionHandle(int LHandle, VECTOR Position) => dx_SetLightPositionHandle(LHandle, Position);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightRangeAttenHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightRangeAttenHandle(int LHandle, float Range, float Atten0, float Atten1, float Atten2);
		public static int SetLightRangeAttenHandle(int LHandle, float Range, float Atten0, float Atten1, float Atten2) => dx_SetLightRangeAttenHandle(LHandle, Range, Atten0, Atten1, Atten2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightAngleHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightAngleHandle(int LHandle, float OutAngle, float InAngle);
		public static int SetLightAngleHandle(int LHandle, float OutAngle, float InAngle) => dx_SetLightAngleHandle(LHandle, OutAngle, InAngle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLightUseShadowMapHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLightUseShadowMapHandle(int LHandle, int SmSlotIndex, int UseFlag);
		public static int SetLightUseShadowMapHandle(int LHandle, int SmSlotIndex, int UseFlag) => dx_SetLightUseShadowMapHandle(LHandle, SmSlotIndex, UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightTypeHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLightTypeHandle(int LHandle);
		public static int GetLightTypeHandle(int LHandle) => dx_GetLightTypeHandle(LHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightEnableHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLightEnableHandle(int LHandle);
		public static int GetLightEnableHandle(int LHandle) => dx_GetLightEnableHandle(LHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightDifColorHandle", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_GetLightDifColorHandle(int LHandle);
		public static COLOR_F GetLightDifColorHandle(int LHandle) => dx_GetLightDifColorHandle(LHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightSpcColorHandle", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_GetLightSpcColorHandle(int LHandle);
		public static COLOR_F GetLightSpcColorHandle(int LHandle) => dx_GetLightSpcColorHandle(LHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightAmbColorHandle", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_GetLightAmbColorHandle(int LHandle);
		public static COLOR_F GetLightAmbColorHandle(int LHandle) => dx_GetLightAmbColorHandle(LHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightDirectionHandle", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_GetLightDirectionHandle(int LHandle);
		public static VECTOR GetLightDirectionHandle(int LHandle) => dx_GetLightDirectionHandle(LHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightPositionHandle", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_GetLightPositionHandle(int LHandle);
		public static VECTOR GetLightPositionHandle(int LHandle) => dx_GetLightPositionHandle(LHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightRangeAttenHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLightRangeAttenHandle(int LHandle, out float Range, out float Atten0, out float Atten1, out float Atten2);
		public static int GetLightRangeAttenHandle(int LHandle, out float Range, out float Atten0, out float Atten1, out float Atten2) => dx_GetLightRangeAttenHandle(LHandle, out Range, out Atten0, out Atten1, out Atten2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLightAngleHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLightAngleHandle(int LHandle, out float OutAngle, out float InAngle);
		public static int GetLightAngleHandle(int LHandle, out float OutAngle, out float InAngle) => dx_GetLightAngleHandle(LHandle, out OutAngle, out InAngle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetEnableLightHandleNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetEnableLightHandleNum();
		public static int GetEnableLightHandleNum() => dx_GetEnableLightHandleNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetEnableLightHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetEnableLightHandle(int Index);
		public static int GetEnableLightHandle(int Index) => dx_GetEnableLightHandle(Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTexFormatIndex", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetTexFormatIndex(out IMAGEFORMATDESC Format);
		public static int GetTexFormatIndex(out IMAGEFORMATDESC Format) => dx_GetTexFormatIndex(out Format);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateMaskScreen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateMaskScreen();
		public static int CreateMaskScreen() => dx_CreateMaskScreen();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteMaskScreen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteMaskScreen();
		public static int DeleteMaskScreen() => dx_DeleteMaskScreen();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawMaskToDirectData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawMaskToDirectData(int x, int y, int Width, int Height, System.IntPtr MaskData, int TransMode);
		public static int DrawMaskToDirectData(int x, int y, int Width, int Height, System.IntPtr MaskData, int TransMode) => dx_DrawMaskToDirectData(x, y, Width, Height, MaskData, TransMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFillMaskToDirectData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFillMaskToDirectData(int x1, int y1, int x2, int y2, int Width, int Height, System.IntPtr MaskData);
		public static int DrawFillMaskToDirectData(int x1, int y1, int x2, int y2, int Width, int Height, System.IntPtr MaskData) => dx_DrawFillMaskToDirectData(x1, y1, x2, y2, Width, Height, MaskData);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseMaskScreenFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseMaskScreenFlag(int ValidFlag);
		public static int SetUseMaskScreenFlag(int ValidFlag) => dx_SetUseMaskScreenFlag(ValidFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseMaskScreenFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseMaskScreenFlag();
		public static int GetUseMaskScreenFlag() => dx_GetUseMaskScreenFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FillMaskScreen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FillMaskScreen(int Flag);
		public static int FillMaskScreen(int Flag) => dx_FillMaskScreen(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMaskScreenGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMaskScreenGraph(int GraphHandle);
		public static int SetMaskScreenGraph(int GraphHandle) => dx_SetMaskScreenGraph(GraphHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMaskScreenGraphUseChannel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMaskScreenGraphUseChannel(int UseChannel);
		public static int SetMaskScreenGraphUseChannel(int UseChannel) => dx_SetMaskScreenGraphUseChannel(UseChannel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitMask();
		public static int InitMask() => dx_InitMask();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeMask(int Width, int Height);
		public static int MakeMask(int Width, int Height) => dx_MakeMask(Width, Height);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMaskSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMaskSize(out int WidthBuf, out int HeightBuf, int MaskHandle);
		public static int GetMaskSize(out int WidthBuf, out int HeightBuf, int MaskHandle) => dx_GetMaskSize(out WidthBuf, out HeightBuf, MaskHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDataToMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDataToMask(int Width, int Height, System.IntPtr MaskData, int MaskHandle);
		public static int SetDataToMask(int Width, int Height, System.IntPtr MaskData, int MaskHandle) => dx_SetDataToMask(Width, Height, MaskData, MaskHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteMask(int MaskHandle);
		public static int DeleteMask(int MaskHandle) => dx_DeleteMask(MaskHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadMask(string FileName);
		public static int LoadMask(string FileName) => dx_LoadMask(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadMaskWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadMaskWithStrLen(string FileName, ulong FileNameLength);
		public static int LoadMaskWithStrLen(string FileName, ulong FileNameLength) => dx_LoadMaskWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivMask(string FileName, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray);
		public static int LoadDivMask(string FileName, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray) => dx_LoadDivMask(FileName, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivMaskWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivMaskWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray);
		public static int LoadDivMaskWithStrLen(string FileName, ulong FileNameLength, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray) => dx_LoadDivMaskWithStrLen(FileName, FileNameLength, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateMaskFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateMaskFromMem(System.IntPtr FileImage, int FileImageSize);
		public static int CreateMaskFromMem(System.IntPtr FileImage, int FileImageSize) => dx_CreateMaskFromMem(FileImage, FileImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateDivMaskFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateDivMaskFromMem(System.IntPtr FileImage, int FileImageSize, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray);
		public static int CreateDivMaskFromMem(System.IntPtr FileImage, int FileImageSize, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray) => dx_CreateDivMaskFromMem(FileImage, FileImageSize, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawMask(int x, int y, int MaskHandle, int TransMode);
		public static int DrawMask(int x, int y, int MaskHandle, int TransMode) => dx_DrawMask(x, y, MaskHandle, TransMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatStringMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatStringMask(int x, int y, int Flag, string FormatString);
		public static int DrawFormatStringMask(int x, int y, int Flag, string FormatString) => dx_DrawFormatStringMask(x, y, Flag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatStringMaskToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatStringMaskToHandle(int x, int y, int Flag, int FontHandle, string FormatString);
		public static int DrawFormatStringMaskToHandle(int x, int y, int Flag, int FontHandle, string FormatString) => dx_DrawFormatStringMaskToHandle(x, y, Flag, FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawStringMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawStringMask(int x, int y, int Flag, string String);
		public static int DrawStringMask(int x, int y, int Flag, string String) => dx_DrawStringMask(x, y, Flag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNStringMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNStringMask(int x, int y, int Flag, string String, ulong StringLength);
		public static int DrawNStringMask(int x, int y, int Flag, string String, ulong StringLength) => dx_DrawNStringMask(x, y, Flag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawStringMaskToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawStringMaskToHandle(int x, int y, int Flag, int FontHandle, string String);
		public static int DrawStringMaskToHandle(int x, int y, int Flag, int FontHandle, string String) => dx_DrawStringMaskToHandle(x, y, Flag, FontHandle, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNStringMaskToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNStringMaskToHandle(int x, int y, int Flag, int FontHandle, string String, ulong StringLength);
		public static int DrawNStringMaskToHandle(int x, int y, int Flag, int FontHandle, string String, ulong StringLength) => dx_DrawNStringMaskToHandle(x, y, Flag, FontHandle, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFillMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFillMask(int x1, int y1, int x2, int y2, int MaskHandle);
		public static int DrawFillMask(int x1, int y1, int x2, int y2, int MaskHandle) => dx_DrawFillMask(x1, y1, x2, y2, MaskHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMaskReverseEffectFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMaskReverseEffectFlag(int ReverseFlag);
		public static int SetMaskReverseEffectFlag(int ReverseFlag) => dx_SetMaskReverseEffectFlag(ReverseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMaskScreenData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMaskScreenData(int x1, int y1, int x2, int y2, int MaskHandle);
		public static int GetMaskScreenData(int x1, int y1, int x2, int y2, int MaskHandle) => dx_GetMaskScreenData(x1, y1, x2, y2, MaskHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMaskUseFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMaskUseFlag();
		public static int GetMaskUseFlag() => dx_GetMaskUseFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_EnumFontName", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_EnumFontName(System.Text.StringBuilder NameBuffer, int NameBufferNum, int JapanOnlyFlag);
		public static int EnumFontName(System.Text.StringBuilder NameBuffer, int NameBufferNum, int JapanOnlyFlag = TRUE) => dx_EnumFontName(NameBuffer, NameBufferNum, JapanOnlyFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_EnumFontNameEx", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_EnumFontNameEx(System.Text.StringBuilder NameBuffer, int NameBufferNum, int CharSet);
		public static int EnumFontNameEx(System.Text.StringBuilder NameBuffer, int NameBufferNum, int CharSet = -1) => dx_EnumFontNameEx(NameBuffer, NameBufferNum, CharSet);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_EnumFontNameEx2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_EnumFontNameEx2(System.Text.StringBuilder NameBuffer, int NameBufferNum, string EnumFontName, int CharSet);
		public static int EnumFontNameEx2(System.Text.StringBuilder NameBuffer, int NameBufferNum, string EnumFontName, int CharSet = -1) => dx_EnumFontNameEx2(NameBuffer, NameBufferNum, EnumFontName, CharSet);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_EnumFontNameEx2WithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_EnumFontNameEx2WithStrLen(System.Text.StringBuilder NameBuffer, int NameBufferNum, string EnumFontName, ulong EnumFontNameLength, int CharSet);
		public static int EnumFontNameEx2WithStrLen(System.Text.StringBuilder NameBuffer, int NameBufferNum, string EnumFontName, ulong EnumFontNameLength, int CharSet = -1) => dx_EnumFontNameEx2WithStrLen(NameBuffer, NameBufferNum, EnumFontName, EnumFontNameLength, CharSet);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckFontName", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckFontName(string FontName, int CharSet);
		public static int CheckFontName(string FontName, int CharSet = -1) => dx_CheckFontName(FontName, CharSet);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckFontNameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckFontNameWithStrLen(string FontName, ulong FontNameLength, int CharSet);
		public static int CheckFontNameWithStrLen(string FontName, ulong FontNameLength, int CharSet = -1) => dx_CheckFontNameWithStrLen(FontName, FontNameLength, CharSet);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitFontToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitFontToHandle();
		public static int InitFontToHandle() => dx_InitFontToHandle();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateFontToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateFontToHandle(string FontName, int Size, int Thick, int FontType, int CharSet, int EdgeSize, int Italic, int Handle);
		public static int CreateFontToHandle(string FontName, int Size, int Thick, int FontType = -1, int CharSet = -1, int EdgeSize = -1, int Italic = FALSE, int Handle = -1) => dx_CreateFontToHandle(FontName, Size, Thick, FontType, CharSet, EdgeSize, Italic, Handle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateFontToHandleWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateFontToHandleWithStrLen(string FontName, ulong FontNameLength, int Size, int Thick, int FontType, int CharSet, int EdgeSize, int Italic, int Handle);
		public static int CreateFontToHandleWithStrLen(string FontName, ulong FontNameLength, int Size, int Thick, int FontType = -1, int CharSet = -1, int EdgeSize = -1, int Italic = FALSE, int Handle = -1) => dx_CreateFontToHandleWithStrLen(FontName, FontNameLength, Size, Thick, FontType, CharSet, EdgeSize, Italic, Handle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadFontDataToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadFontDataToHandle(string FileName, int EdgeSize);
		public static int LoadFontDataToHandle(string FileName, int EdgeSize = 0) => dx_LoadFontDataToHandle(FileName, EdgeSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadFontDataToHandleWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadFontDataToHandleWithStrLen(string FileName, ulong FileNameLength, int EdgeSize);
		public static int LoadFontDataToHandleWithStrLen(string FileName, ulong FileNameLength, int EdgeSize = 0) => dx_LoadFontDataToHandleWithStrLen(FileName, FileNameLength, EdgeSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadFontDataFromMemToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadFontDataFromMemToHandle(System.IntPtr FontDataImage, int FontDataImageSize, int EdgeSize);
		public static int LoadFontDataFromMemToHandle(System.IntPtr FontDataImage, int FontDataImageSize, int EdgeSize = 0) => dx_LoadFontDataFromMemToHandle(FontDataImage, FontDataImageSize, EdgeSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontSpaceToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontSpaceToHandle(int Pixel, int FontHandle);
		public static int SetFontSpaceToHandle(int Pixel, int FontHandle) => dx_SetFontSpaceToHandle(Pixel, FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontLineSpaceToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontLineSpaceToHandle(int Pixel, int FontHandle);
		public static int SetFontLineSpaceToHandle(int Pixel, int FontHandle) => dx_SetFontLineSpaceToHandle(Pixel, FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontCharCodeFormatToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontCharCodeFormatToHandle(int CharCodeFormat, int FontHandle);
		public static int SetFontCharCodeFormatToHandle(int CharCodeFormat, int FontHandle) => dx_SetFontCharCodeFormatToHandle(CharCodeFormat, FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteFontToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteFontToHandle(int FontHandle);
		public static int DeleteFontToHandle(int FontHandle) => dx_DeleteFontToHandle(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontLostFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontLostFlag(int FontHandle, out int LostFlag);
		public static int SetFontLostFlag(int FontHandle, out int LostFlag) => dx_SetFontLostFlag(FontHandle, out LostFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddFontImageToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddFontImageToHandle(int FontHandle, string Char, int GrHandle, int DrawX, int DrawY, int AddX);
		public static int AddFontImageToHandle(int FontHandle, string Char, int GrHandle, int DrawX, int DrawY, int AddX) => dx_AddFontImageToHandle(FontHandle, Char, GrHandle, DrawX, DrawY, AddX);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddFontImageToHandleWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddFontImageToHandleWithStrLen(int FontHandle, string Char, ulong CharLength, int GrHandle, int DrawX, int DrawY, int AddX);
		public static int AddFontImageToHandleWithStrLen(int FontHandle, string Char, ulong CharLength, int GrHandle, int DrawX, int DrawY, int AddX) => dx_AddFontImageToHandleWithStrLen(FontHandle, Char, CharLength, GrHandle, DrawX, DrawY, AddX);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SubFontImageToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SubFontImageToHandle(int FontHandle, string Char);
		public static int SubFontImageToHandle(int FontHandle, string Char) => dx_SubFontImageToHandle(FontHandle, Char);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SubFontImageToHandleWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SubFontImageToHandleWithStrLen(int FontHandle, string Char, ulong CharLength);
		public static int SubFontImageToHandleWithStrLen(int FontHandle, string Char, ulong CharLength) => dx_SubFontImageToHandleWithStrLen(FontHandle, Char, CharLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddSubstitutionFontToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddSubstitutionFontToHandle(int FontHandle, int SubstitutionFontHandle, int DrawX, int DrawY);
		public static int AddSubstitutionFontToHandle(int FontHandle, int SubstitutionFontHandle, int DrawX, int DrawY) => dx_AddSubstitutionFontToHandle(FontHandle, SubstitutionFontHandle, DrawX, DrawY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SubSubstitutionFontToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SubSubstitutionFontToHandle(int FontHandle, int SubstitutionFontHandle);
		public static int SubSubstitutionFontToHandle(int FontHandle, int SubstitutionFontHandle) => dx_SubSubstitutionFontToHandle(FontHandle, SubstitutionFontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeFont", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeFont(string FontName, int CharSet);
		public static int ChangeFont(string FontName, int CharSet = -1) => dx_ChangeFont(FontName, CharSet);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeFontWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeFontWithStrLen(string FontName, ulong FontNameLength, int CharSet);
		public static int ChangeFontWithStrLen(string FontName, ulong FontNameLength, int CharSet = -1) => dx_ChangeFontWithStrLen(FontName, FontNameLength, CharSet);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeFontType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeFontType(int FontType);
		public static int ChangeFontType(int FontType) => dx_ChangeFontType(FontType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetFontName();
		public static string GetFontName()
		{
			var resultIntPtr = dx_GetFontName();
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontSize(int FontSize);
		public static int SetFontSize(int FontSize) => dx_SetFontSize(FontSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontSize();
		public static int GetFontSize() => dx_GetFontSize();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontEdgeSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontEdgeSize();
		public static int GetFontEdgeSize() => dx_GetFontEdgeSize();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontThickness", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontThickness(int ThickPal);
		public static int SetFontThickness(int ThickPal) => dx_SetFontThickness(ThickPal);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontSpace", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontSpace(int Pixel);
		public static int SetFontSpace(int Pixel) => dx_SetFontSpace(Pixel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontSpace", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontSpace();
		public static int GetFontSpace() => dx_GetFontSpace();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontLineSpace", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontLineSpace(int Pixel);
		public static int SetFontLineSpace(int Pixel) => dx_SetFontLineSpace(Pixel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontLineSpace", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontLineSpace();
		public static int GetFontLineSpace() => dx_GetFontLineSpace();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontCharCodeFormat", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontCharCodeFormat(int CharCodeFormat);
		public static int SetFontCharCodeFormat(int CharCodeFormat) => dx_SetFontCharCodeFormat(CharCodeFormat);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDefaultFontState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDefaultFontState(string FontName, int Size, int Thick, int FontType, int CharSet, int EdgeSize, int Italic);
		public static int SetDefaultFontState(string FontName, int Size, int Thick, int FontType = -1, int CharSet = -1, int EdgeSize = -1, int Italic = FALSE) => dx_SetDefaultFontState(FontName, Size, Thick, FontType, CharSet, EdgeSize, Italic);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDefaultFontStateWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDefaultFontStateWithStrLen(string FontName, ulong FontNameLength, int Size, int Thick, int FontType, int CharSet, int EdgeSize, int Italic);
		public static int SetDefaultFontStateWithStrLen(string FontName, ulong FontNameLength, int Size, int Thick, int FontType = -1, int CharSet = -1, int EdgeSize = -1, int Italic = FALSE) => dx_SetDefaultFontStateWithStrLen(FontName, FontNameLength, Size, Thick, FontType, CharSet, EdgeSize, Italic);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDefaultFontHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDefaultFontHandle();
		public static int GetDefaultFontHandle() => dx_GetDefaultFontHandle();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontMaxCacheCharNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontMaxCacheCharNum();
		public static int GetFontMaxCacheCharNum() => dx_GetFontMaxCacheCharNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontMaxWidth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontMaxWidth();
		public static int GetFontMaxWidth() => dx_GetFontMaxWidth();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontAscent", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontAscent();
		public static int GetFontAscent() => dx_GetFontAscent();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawStringWidth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawStringWidth(string String, int StrLen, int VerticalFlag);
		public static int GetDrawStringWidth(string String, int StrLen, int VerticalFlag = FALSE) => dx_GetDrawStringWidth(String, StrLen, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawNStringWidth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawNStringWidth(string String, ulong StringLength, int VerticalFlag);
		public static int GetDrawNStringWidth(string String, ulong StringLength, int VerticalFlag = FALSE) => dx_GetDrawNStringWidth(String, StringLength, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawFormatStringWidth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawFormatStringWidth(string FormatString);
		public static int GetDrawFormatStringWidth(string FormatString) => dx_GetDrawFormatStringWidth(FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawExtendStringWidth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawExtendStringWidth(double ExRateX, string String, int StrLen, int VerticalFlag);
		public static int GetDrawExtendStringWidth(double ExRateX, string String, int StrLen, int VerticalFlag = FALSE) => dx_GetDrawExtendStringWidth(ExRateX, String, StrLen, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawExtendNStringWidth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawExtendNStringWidth(double ExRateX, string String, ulong StringLength, int VerticalFlag);
		public static int GetDrawExtendNStringWidth(double ExRateX, string String, ulong StringLength, int VerticalFlag = FALSE) => dx_GetDrawExtendNStringWidth(ExRateX, String, StringLength, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawExtendFormatStringWidth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawExtendFormatStringWidth(double ExRateX, string FormatString);
		public static int GetDrawExtendFormatStringWidth(double ExRateX, string FormatString) => dx_GetDrawExtendFormatStringWidth(ExRateX, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawStringSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawStringSize(out int SizeX, out int SizeY, out int LineCount, string String, int StrLen, int VerticalFlag);
		public static int GetDrawStringSize(out int SizeX, out int SizeY, out int LineCount, string String, int StrLen, int VerticalFlag = FALSE) => dx_GetDrawStringSize(out SizeX, out SizeY, out LineCount, String, StrLen, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawNStringSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawNStringSize(out int SizeX, out int SizeY, out int LineCount, string String, ulong StringLength, int VerticalFlag);
		public static int GetDrawNStringSize(out int SizeX, out int SizeY, out int LineCount, string String, ulong StringLength, int VerticalFlag = FALSE) => dx_GetDrawNStringSize(out SizeX, out SizeY, out LineCount, String, StringLength, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawFormatStringSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawFormatStringSize(out int SizeX, out int SizeY, out int LineCount, string FormatString);
		public static int GetDrawFormatStringSize(out int SizeX, out int SizeY, out int LineCount, string FormatString) => dx_GetDrawFormatStringSize(out SizeX, out SizeY, out LineCount, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawExtendStringSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawExtendStringSize(out int SizeX, out int SizeY, out int LineCount, double ExRateX, double ExRateY, string String, int StrLen, int VerticalFlag);
		public static int GetDrawExtendStringSize(out int SizeX, out int SizeY, out int LineCount, double ExRateX, double ExRateY, string String, int StrLen, int VerticalFlag = FALSE) => dx_GetDrawExtendStringSize(out SizeX, out SizeY, out LineCount, ExRateX, ExRateY, String, StrLen, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawExtendNStringSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawExtendNStringSize(out int SizeX, out int SizeY, out int LineCount, double ExRateX, double ExRateY, string String, ulong StringLength, int VerticalFlag);
		public static int GetDrawExtendNStringSize(out int SizeX, out int SizeY, out int LineCount, double ExRateX, double ExRateY, string String, ulong StringLength, int VerticalFlag = FALSE) => dx_GetDrawExtendNStringSize(out SizeX, out SizeY, out LineCount, ExRateX, ExRateY, String, StringLength, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawExtendFormatStringSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawExtendFormatStringSize(out int SizeX, out int SizeY, out int LineCount, double ExRateX, double ExRateY, string FormatString);
		public static int GetDrawExtendFormatStringSize(out int SizeX, out int SizeY, out int LineCount, double ExRateX, double ExRateY, string FormatString) => dx_GetDrawExtendFormatStringSize(out SizeX, out SizeY, out LineCount, ExRateX, ExRateY, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawStringKerningPairInfo", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawStringKerningPairInfo(string PairChar, out int KernAmount);
		public static int GetDrawStringKerningPairInfo(string PairChar, out int KernAmount) => dx_GetDrawStringKerningPairInfo(PairChar, out KernAmount);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawStringKerningPairInfoWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawStringKerningPairInfoWithStrLen(string PairChar, ulong PairCharLength, out int KernAmount);
		public static int GetDrawStringKerningPairInfoWithStrLen(string PairChar, ulong PairCharLength, out int KernAmount) => dx_GetDrawStringKerningPairInfoWithStrLen(PairChar, PairCharLength, out KernAmount);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontNameToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetFontNameToHandle(int FontHandle);
		public static string GetFontNameToHandle(int FontHandle)
		{
			var resultIntPtr = dx_GetFontNameToHandle(FontHandle);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontMaxCacheCharNumToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontMaxCacheCharNumToHandle(int FontHandle);
		public static int GetFontMaxCacheCharNumToHandle(int FontHandle) => dx_GetFontMaxCacheCharNumToHandle(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontMaxWidthToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontMaxWidthToHandle(int FontHandle);
		public static int GetFontMaxWidthToHandle(int FontHandle) => dx_GetFontMaxWidthToHandle(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontAscentToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontAscentToHandle(int FontHandle);
		public static int GetFontAscentToHandle(int FontHandle) => dx_GetFontAscentToHandle(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontSizeToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontSizeToHandle(int FontHandle);
		public static int GetFontSizeToHandle(int FontHandle) => dx_GetFontSizeToHandle(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontEdgeSizeToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontEdgeSizeToHandle(int FontHandle);
		public static int GetFontEdgeSizeToHandle(int FontHandle) => dx_GetFontEdgeSizeToHandle(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontSpaceToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontSpaceToHandle(int FontHandle);
		public static int GetFontSpaceToHandle(int FontHandle) => dx_GetFontSpaceToHandle(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontLineSpaceToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontLineSpaceToHandle(int FontHandle);
		public static int GetFontLineSpaceToHandle(int FontHandle) => dx_GetFontLineSpaceToHandle(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontCharInfo", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontCharInfo(int FontHandle, string Char, out int DrawX, out int DrawY, out int NextCharX, out int SizeX, out int SizeY);
		public static int GetFontCharInfo(int FontHandle, string Char, out int DrawX, out int DrawY, out int NextCharX, out int SizeX, out int SizeY) => dx_GetFontCharInfo(FontHandle, Char, out DrawX, out DrawY, out NextCharX, out SizeX, out SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontCharInfoWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontCharInfoWithStrLen(int FontHandle, string Char, ulong CharLength, out int DrawX, out int DrawY, out int NextCharX, out int SizeX, out int SizeY);
		public static int GetFontCharInfoWithStrLen(int FontHandle, string Char, ulong CharLength, out int DrawX, out int DrawY, out int NextCharX, out int SizeX, out int SizeY) => dx_GetFontCharInfoWithStrLen(FontHandle, Char, CharLength, out DrawX, out DrawY, out NextCharX, out SizeX, out SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawStringWidthToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawStringWidthToHandle(string String, int StrLen, int FontHandle, int VerticalFlag);
		public static int GetDrawStringWidthToHandle(string String, int StrLen, int FontHandle, int VerticalFlag = FALSE) => dx_GetDrawStringWidthToHandle(String, StrLen, FontHandle, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawNStringWidthToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawNStringWidthToHandle(string String, ulong StringLength, int FontHandle, int VerticalFlag);
		public static int GetDrawNStringWidthToHandle(string String, ulong StringLength, int FontHandle, int VerticalFlag = FALSE) => dx_GetDrawNStringWidthToHandle(String, StringLength, FontHandle, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawFormatStringWidthToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawFormatStringWidthToHandle(int FontHandle, string FormatString);
		public static int GetDrawFormatStringWidthToHandle(int FontHandle, string FormatString) => dx_GetDrawFormatStringWidthToHandle(FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawExtendStringWidthToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawExtendStringWidthToHandle(double ExRateX, string String, int StrLen, int FontHandle, int VerticalFlag);
		public static int GetDrawExtendStringWidthToHandle(double ExRateX, string String, int StrLen, int FontHandle, int VerticalFlag = FALSE) => dx_GetDrawExtendStringWidthToHandle(ExRateX, String, StrLen, FontHandle, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawExtendNStringWidthToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawExtendNStringWidthToHandle(double ExRateX, string String, ulong StringLength, int FontHandle, int VerticalFlag);
		public static int GetDrawExtendNStringWidthToHandle(double ExRateX, string String, ulong StringLength, int FontHandle, int VerticalFlag = FALSE) => dx_GetDrawExtendNStringWidthToHandle(ExRateX, String, StringLength, FontHandle, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawExtendFormatStringWidthToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawExtendFormatStringWidthToHandle(double ExRateX, int FontHandle, string FormatString);
		public static int GetDrawExtendFormatStringWidthToHandle(double ExRateX, int FontHandle, string FormatString) => dx_GetDrawExtendFormatStringWidthToHandle(ExRateX, FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawStringSizeToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawStringSizeToHandle(out int SizeX, out int SizeY, out int LineCount, string String, int StrLen, int FontHandle, int VerticalFlag);
		public static int GetDrawStringSizeToHandle(out int SizeX, out int SizeY, out int LineCount, string String, int StrLen, int FontHandle, int VerticalFlag = FALSE) => dx_GetDrawStringSizeToHandle(out SizeX, out SizeY, out LineCount, String, StrLen, FontHandle, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawNStringSizeToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawNStringSizeToHandle(out int SizeX, out int SizeY, out int LineCount, string String, ulong StringLength, int FontHandle, int VerticalFlag);
		public static int GetDrawNStringSizeToHandle(out int SizeX, out int SizeY, out int LineCount, string String, ulong StringLength, int FontHandle, int VerticalFlag = FALSE) => dx_GetDrawNStringSizeToHandle(out SizeX, out SizeY, out LineCount, String, StringLength, FontHandle, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawFormatStringSizeToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawFormatStringSizeToHandle(out int SizeX, out int SizeY, out int LineCount, int FontHandle, string FormatString);
		public static int GetDrawFormatStringSizeToHandle(out int SizeX, out int SizeY, out int LineCount, int FontHandle, string FormatString) => dx_GetDrawFormatStringSizeToHandle(out SizeX, out SizeY, out LineCount, FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawExtendStringSizeToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawExtendStringSizeToHandle(out int SizeX, out int SizeY, out int LineCount, double ExRateX, double ExRateY, string String, int StrLen, int FontHandle, int VerticalFlag);
		public static int GetDrawExtendStringSizeToHandle(out int SizeX, out int SizeY, out int LineCount, double ExRateX, double ExRateY, string String, int StrLen, int FontHandle, int VerticalFlag = FALSE) => dx_GetDrawExtendStringSizeToHandle(out SizeX, out SizeY, out LineCount, ExRateX, ExRateY, String, StrLen, FontHandle, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawExtendNStringSizeToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawExtendNStringSizeToHandle(out int SizeX, out int SizeY, out int LineCount, double ExRateX, double ExRateY, string String, ulong StringLength, int FontHandle, int VerticalFlag);
		public static int GetDrawExtendNStringSizeToHandle(out int SizeX, out int SizeY, out int LineCount, double ExRateX, double ExRateY, string String, ulong StringLength, int FontHandle, int VerticalFlag = FALSE) => dx_GetDrawExtendNStringSizeToHandle(out SizeX, out SizeY, out LineCount, ExRateX, ExRateY, String, StringLength, FontHandle, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawExtendFormatStringSizeToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawExtendFormatStringSizeToHandle(out int SizeX, out int SizeY, out int LineCount, double ExRateX, double ExRateY, int FontHandle, string FormatString);
		public static int GetDrawExtendFormatStringSizeToHandle(out int SizeX, out int SizeY, out int LineCount, double ExRateX, double ExRateY, int FontHandle, string FormatString) => dx_GetDrawExtendFormatStringSizeToHandle(out SizeX, out SizeY, out LineCount, ExRateX, ExRateY, FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawStringKerningPairInfoToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawStringKerningPairInfoToHandle(string PairChar, out int KernAmount, int FontHandle);
		public static int GetDrawStringKerningPairInfoToHandle(string PairChar, out int KernAmount, int FontHandle) => dx_GetDrawStringKerningPairInfoToHandle(PairChar, out KernAmount, FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawStringKerningPairInfoToHandleWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawStringKerningPairInfoToHandleWithStrLen(string PairChar, ulong PairCharLength, out int KernAmount, int FontHandle);
		public static int GetDrawStringKerningPairInfoToHandleWithStrLen(string PairChar, ulong PairCharLength, out int KernAmount, int FontHandle) => dx_GetDrawStringKerningPairInfoToHandleWithStrLen(PairChar, PairCharLength, out KernAmount, FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontStateToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontStateToHandle(System.Text.StringBuilder FontName, out int Size, out int Thick, int FontHandle, out int FontType, out int CharSet, out int EdgeSize, out int Italic);
		public static int GetFontStateToHandle(System.Text.StringBuilder FontName, out int Size, out int Thick, int FontHandle, out int FontType, out int CharSet, out int EdgeSize, out int Italic) => dx_GetFontStateToHandle(FontName, out Size, out Thick, FontHandle, out FontType, out CharSet, out EdgeSize, out Italic);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckFontCacheToTextureFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckFontCacheToTextureFlag(int FontHandle);
		public static int CheckFontCacheToTextureFlag(int FontHandle) => dx_CheckFontCacheToTextureFlag(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckFontChacheToTextureFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckFontChacheToTextureFlag(int FontHandle);
		public static int CheckFontChacheToTextureFlag(int FontHandle) => dx_CheckFontChacheToTextureFlag(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckFontHandleValid", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckFontHandleValid(int FontHandle);
		public static int CheckFontHandleValid(int FontHandle) => dx_CheckFontHandleValid(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ClearFontCacheToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ClearFontCacheToHandle(int FontHandle);
		public static int ClearFontCacheToHandle(int FontHandle) => dx_ClearFontCacheToHandle(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontCacheToTextureFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontCacheToTextureFlag(int Flag);
		public static int SetFontCacheToTextureFlag(int Flag) => dx_SetFontCacheToTextureFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontCacheToTextureFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontCacheToTextureFlag();
		public static int GetFontCacheToTextureFlag() => dx_GetFontCacheToTextureFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontChacheToTextureFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontChacheToTextureFlag(int Flag);
		public static int SetFontChacheToTextureFlag(int Flag) => dx_SetFontChacheToTextureFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontChacheToTextureFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontChacheToTextureFlag();
		public static int GetFontChacheToTextureFlag() => dx_GetFontChacheToTextureFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontCacheTextureColorBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontCacheTextureColorBitDepth(int ColorBitDepth);
		public static int SetFontCacheTextureColorBitDepth(int ColorBitDepth) => dx_SetFontCacheTextureColorBitDepth(ColorBitDepth);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontCacheTextureColorBitDepth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontCacheTextureColorBitDepth();
		public static int GetFontCacheTextureColorBitDepth() => dx_GetFontCacheTextureColorBitDepth();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontCacheCharNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontCacheCharNum(int CharNum);
		public static int SetFontCacheCharNum(int CharNum) => dx_SetFontCacheCharNum(CharNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontCacheCharNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontCacheCharNum();
		public static int GetFontCacheCharNum() => dx_GetFontCacheCharNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontCacheUsePremulAlphaFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontCacheUsePremulAlphaFlag(int Flag);
		public static int SetFontCacheUsePremulAlphaFlag(int Flag) => dx_SetFontCacheUsePremulAlphaFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontCacheUsePremulAlphaFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontCacheUsePremulAlphaFlag();
		public static int GetFontCacheUsePremulAlphaFlag() => dx_GetFontCacheUsePremulAlphaFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFontUseAdjustSizeFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFontUseAdjustSizeFlag(int Flag);
		public static int SetFontUseAdjustSizeFlag(int Flag) => dx_SetFontUseAdjustSizeFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFontUseAdjustSizeFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFontUseAdjustSizeFlag();
		public static int GetFontUseAdjustSizeFlag() => dx_GetFontUseAdjustSizeFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MultiByteCharCheck", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MultiByteCharCheck(uint Buf, int CharSet);
		public static int MultiByteCharCheck(uint Buf, int CharSet) => dx_MultiByteCharCheck(Buf, CharSet);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawString(int x, int y, string String, uint Color, uint EdgeColor);
		public static int DrawString(int x, int y, string String, uint Color, uint EdgeColor = 0) => dx_DrawString(x, y, String, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNString(int x, int y, string String, ulong StringLength, uint Color, uint EdgeColor);
		public static int DrawNString(int x, int y, string String, ulong StringLength, uint Color, uint EdgeColor = 0) => dx_DrawNString(x, y, String, StringLength, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawVString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawVString(int x, int y, string String, uint Color, uint EdgeColor);
		public static int DrawVString(int x, int y, string String, uint Color, uint EdgeColor = 0) => dx_DrawVString(x, y, String, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNVString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNVString(int x, int y, string String, ulong StringLength, uint Color, uint EdgeColor);
		public static int DrawNVString(int x, int y, string String, ulong StringLength, uint Color, uint EdgeColor = 0) => dx_DrawNVString(x, y, String, StringLength, Color, EdgeColor);
			
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatString(int x, int y, uint Color, string FormatString);
		public static int DrawFormatString(int x, int y, uint Color, string FormatString) => dx_DrawFormatString(x, y, Color, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatVString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatVString(int x, int y, uint Color, string FormatString);
		public static int DrawFormatVString(int x, int y, uint Color, string FormatString) => dx_DrawFormatVString(x, y, Color, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendString(int x, int y, double ExRateX, double ExRateY, string String, uint Color, uint EdgeColor);
		public static int DrawExtendString(int x, int y, double ExRateX, double ExRateY, string String, uint Color, uint EdgeColor = 0) => dx_DrawExtendString(x, y, ExRateX, ExRateY, String, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendNString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendNString(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, uint EdgeColor);
		public static int DrawExtendNString(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, uint EdgeColor = 0) => dx_DrawExtendNString(x, y, ExRateX, ExRateY, String, StringLength, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendVString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendVString(int x, int y, double ExRateX, double ExRateY, string String, uint Color, uint EdgeColor);
		public static int DrawExtendVString(int x, int y, double ExRateX, double ExRateY, string String, uint Color, uint EdgeColor = 0) => dx_DrawExtendVString(x, y, ExRateX, ExRateY, String, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendNVString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendNVString(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, uint EdgeColor);
		public static int DrawExtendNVString(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, uint EdgeColor = 0) => dx_DrawExtendNVString(x, y, ExRateX, ExRateY, String, StringLength, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendFormatString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendFormatString(int x, int y, double ExRateX, double ExRateY, uint Color, string FormatString);
		public static int DrawExtendFormatString(int x, int y, double ExRateX, double ExRateY, uint Color, string FormatString) => dx_DrawExtendFormatString(x, y, ExRateX, ExRateY, Color, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendFormatVString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendFormatVString(int x, int y, double ExRateX, double ExRateY, uint Color, string FormatString);
		public static int DrawExtendFormatVString(int x, int y, double ExRateX, double ExRateY, uint Color, string FormatString) => dx_DrawExtendFormatVString(x, y, ExRateX, ExRateY, Color, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaString(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, uint EdgeColor, int VerticalFlag, string String);
		public static int DrawRotaString(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, uint EdgeColor = 0, int VerticalFlag = FALSE, string String = default) => dx_DrawRotaString(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, Color, EdgeColor, VerticalFlag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaNString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaNString(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, uint EdgeColor, int VerticalFlag, string String, ulong StringLength);
		public static int DrawRotaNString(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, uint EdgeColor = 0, int VerticalFlag = FALSE, string String = default, ulong StringLength = 0) => dx_DrawRotaNString(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, Color, EdgeColor, VerticalFlag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaFormatString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaFormatString(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, uint EdgeColor, int VerticalFlag, string FormatString);
		public static int DrawRotaFormatString(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, uint EdgeColor = 0, int VerticalFlag = FALSE, string FormatString = default) => dx_DrawRotaFormatString(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, Color, EdgeColor, VerticalFlag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiString(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, uint EdgeColor, int VerticalFlag, string String);
		public static int DrawModiString(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, uint EdgeColor = 0, int VerticalFlag = FALSE, string String = default) => dx_DrawModiString(x1, y1, x2, y2, x3, y3, x4, y4, Color, EdgeColor, VerticalFlag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiNString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiNString(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, uint EdgeColor, int VerticalFlag, string String, ulong StringLength);
		public static int DrawModiNString(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, uint EdgeColor = 0, int VerticalFlag = FALSE, string String = default, ulong StringLength = 0) => dx_DrawModiNString(x1, y1, x2, y2, x3, y3, x4, y4, Color, EdgeColor, VerticalFlag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiFormatString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiFormatString(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, uint EdgeColor, int VerticalFlag, string FormatString);
		public static int DrawModiFormatString(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, uint EdgeColor = 0, int VerticalFlag = FALSE, string FormatString = default) => dx_DrawModiFormatString(x1, y1, x2, y2, x3, y3, x4, y4, Color, EdgeColor, VerticalFlag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawStringF(float x, float y, string String, uint Color, uint EdgeColor);
		public static int DrawStringF(float x, float y, string String, uint Color, uint EdgeColor = 0) => dx_DrawStringF(x, y, String, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNStringF(float x, float y, string String, ulong StringLength, uint Color, uint EdgeColor);
		public static int DrawNStringF(float x, float y, string String, ulong StringLength, uint Color, uint EdgeColor = 0) => dx_DrawNStringF(x, y, String, StringLength, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawVStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawVStringF(float x, float y, string String, uint Color, uint EdgeColor);
		public static int DrawVStringF(float x, float y, string String, uint Color, uint EdgeColor = 0) => dx_DrawVStringF(x, y, String, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNVStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNVStringF(float x, float y, string String, ulong StringLength, uint Color, uint EdgeColor);
		public static int DrawNVStringF(float x, float y, string String, ulong StringLength, uint Color, uint EdgeColor = 0) => dx_DrawNVStringF(x, y, String, StringLength, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatStringF(float x, float y, uint Color, string FormatString);
		public static int DrawFormatStringF(float x, float y, uint Color, string FormatString) => dx_DrawFormatStringF(x, y, Color, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatVStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatVStringF(float x, float y, uint Color, string FormatString);
		public static int DrawFormatVStringF(float x, float y, uint Color, string FormatString) => dx_DrawFormatVStringF(x, y, Color, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendStringF(float x, float y, double ExRateX, double ExRateY, string String, uint Color, uint EdgeColor);
		public static int DrawExtendStringF(float x, float y, double ExRateX, double ExRateY, string String, uint Color, uint EdgeColor = 0) => dx_DrawExtendStringF(x, y, ExRateX, ExRateY, String, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendNStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendNStringF(float x, float y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, uint EdgeColor);
		public static int DrawExtendNStringF(float x, float y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, uint EdgeColor = 0) => dx_DrawExtendNStringF(x, y, ExRateX, ExRateY, String, StringLength, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendVStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendVStringF(float x, float y, double ExRateX, double ExRateY, string String, uint Color, uint EdgeColor);
		public static int DrawExtendVStringF(float x, float y, double ExRateX, double ExRateY, string String, uint Color, uint EdgeColor = 0) => dx_DrawExtendVStringF(x, y, ExRateX, ExRateY, String, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendNVStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendNVStringF(float x, float y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, uint EdgeColor);
		public static int DrawExtendNVStringF(float x, float y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, uint EdgeColor = 0) => dx_DrawExtendNVStringF(x, y, ExRateX, ExRateY, String, StringLength, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendFormatStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendFormatStringF(float x, float y, double ExRateX, double ExRateY, uint Color, string FormatString);
		public static int DrawExtendFormatStringF(float x, float y, double ExRateX, double ExRateY, uint Color, string FormatString) => dx_DrawExtendFormatStringF(x, y, ExRateX, ExRateY, Color, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendFormatVStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendFormatVStringF(float x, float y, double ExRateX, double ExRateY, uint Color, string FormatString);
		public static int DrawExtendFormatVStringF(float x, float y, double ExRateX, double ExRateY, uint Color, string FormatString) => dx_DrawExtendFormatVStringF(x, y, ExRateX, ExRateY, Color, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaStringF(float x, float y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, uint EdgeColor, int VerticalFlag, string String);
		public static int DrawRotaStringF(float x, float y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, uint EdgeColor = 0, int VerticalFlag = FALSE, string String = default) => dx_DrawRotaStringF(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, Color, EdgeColor, VerticalFlag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaNStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaNStringF(float x, float y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, uint EdgeColor, int VerticalFlag, string String, ulong StringLength);
		public static int DrawRotaNStringF(float x, float y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, uint EdgeColor = 0, int VerticalFlag = FALSE, string String = default, ulong StringLength = 0) => dx_DrawRotaNStringF(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, Color, EdgeColor, VerticalFlag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaFormatStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaFormatStringF(float x, float y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, uint EdgeColor, int VerticalFlag, string FormatString);
		public static int DrawRotaFormatStringF(float x, float y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, uint EdgeColor = 0, int VerticalFlag = FALSE, string FormatString = default) => dx_DrawRotaFormatStringF(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, Color, EdgeColor, VerticalFlag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiStringF(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, uint EdgeColor, int VerticalFlag, string String);
		public static int DrawModiStringF(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, uint EdgeColor = 0, int VerticalFlag = FALSE, string String = default) => dx_DrawModiStringF(x1, y1, x2, y2, x3, y3, x4, y4, Color, EdgeColor, VerticalFlag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiNStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiNStringF(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, uint EdgeColor, int VerticalFlag, string String, ulong StringLength);
		public static int DrawModiNStringF(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, uint EdgeColor = 0, int VerticalFlag = FALSE, string String = default, ulong StringLength = 0) => dx_DrawModiNStringF(x1, y1, x2, y2, x3, y3, x4, y4, Color, EdgeColor, VerticalFlag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiFormatStringF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiFormatStringF(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, uint EdgeColor, int VerticalFlag, string FormatString);
		public static int DrawModiFormatStringF(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, uint EdgeColor = 0, int VerticalFlag = FALSE, string FormatString = default) => dx_DrawModiFormatStringF(x1, y1, x2, y2, x3, y3, x4, y4, Color, EdgeColor, VerticalFlag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNumberToI", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNumberToI(int x, int y, int Num, int RisesNum, uint Color, uint EdgeColor);
		public static int DrawNumberToI(int x, int y, int Num, int RisesNum, uint Color, uint EdgeColor = 0) => dx_DrawNumberToI(x, y, Num, RisesNum, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNumberToF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNumberToF(int x, int y, double Num, int Length, uint Color, uint EdgeColor);
		public static int DrawNumberToF(int x, int y, double Num, int Length, uint Color, uint EdgeColor = 0) => dx_DrawNumberToF(x, y, Num, Length, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNumberPlusToI", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNumberPlusToI(int x, int y, string NoteString, int Num, int RisesNum, uint Color, uint EdgeColor);
		public static int DrawNumberPlusToI(int x, int y, string NoteString, int Num, int RisesNum, uint Color, uint EdgeColor = 0) => dx_DrawNumberPlusToI(x, y, NoteString, Num, RisesNum, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNumberPlusToF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNumberPlusToF(int x, int y, string NoteString, double Num, int Length, uint Color, uint EdgeColor);
		public static int DrawNumberPlusToF(int x, int y, string NoteString, double Num, int Length, uint Color, uint EdgeColor = 0) => dx_DrawNumberPlusToF(x, y, NoteString, Num, Length, Color, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawStringToZBuffer(int x, int y, string String, int WriteZMode);
		public static int DrawStringToZBuffer(int x, int y, string String, int WriteZMode) => dx_DrawStringToZBuffer(x, y, String, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNStringToZBuffer(int x, int y, string String, ulong StringLength, int WriteZMode);
		public static int DrawNStringToZBuffer(int x, int y, string String, ulong StringLength, int WriteZMode) => dx_DrawNStringToZBuffer(x, y, String, StringLength, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawVStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawVStringToZBuffer(int x, int y, string String, int WriteZMode);
		public static int DrawVStringToZBuffer(int x, int y, string String, int WriteZMode) => dx_DrawVStringToZBuffer(x, y, String, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNVStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNVStringToZBuffer(int x, int y, string String, ulong StringLength, int WriteZMode);
		public static int DrawNVStringToZBuffer(int x, int y, string String, ulong StringLength, int WriteZMode) => dx_DrawNVStringToZBuffer(x, y, String, StringLength, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatStringToZBuffer(int x, int y, int WriteZMode, string FormatString);
		public static int DrawFormatStringToZBuffer(int x, int y, int WriteZMode, string FormatString) => dx_DrawFormatStringToZBuffer(x, y, WriteZMode, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatVStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatVStringToZBuffer(int x, int y, int WriteZMode, string FormatString);
		public static int DrawFormatVStringToZBuffer(int x, int y, int WriteZMode, string FormatString) => dx_DrawFormatVStringToZBuffer(x, y, WriteZMode, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendStringToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, int WriteZMode);
		public static int DrawExtendStringToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, int WriteZMode) => dx_DrawExtendStringToZBuffer(x, y, ExRateX, ExRateY, String, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendNStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendNStringToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, int WriteZMode);
		public static int DrawExtendNStringToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, int WriteZMode) => dx_DrawExtendNStringToZBuffer(x, y, ExRateX, ExRateY, String, StringLength, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendVStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendVStringToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, int WriteZMode);
		public static int DrawExtendVStringToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, int WriteZMode) => dx_DrawExtendVStringToZBuffer(x, y, ExRateX, ExRateY, String, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendNVStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendNVStringToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, int WriteZMode);
		public static int DrawExtendNVStringToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, int WriteZMode) => dx_DrawExtendNVStringToZBuffer(x, y, ExRateX, ExRateY, String, StringLength, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendFormatStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendFormatStringToZBuffer(int x, int y, double ExRateX, double ExRateY, int WriteZMode, string FormatString);
		public static int DrawExtendFormatStringToZBuffer(int x, int y, double ExRateX, double ExRateY, int WriteZMode, string FormatString) => dx_DrawExtendFormatStringToZBuffer(x, y, ExRateX, ExRateY, WriteZMode, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendFormatVStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendFormatVStringToZBuffer(int x, int y, double ExRateX, double ExRateY, int WriteZMode, string FormatString);
		public static int DrawExtendFormatVStringToZBuffer(int x, int y, double ExRateX, double ExRateY, int WriteZMode, string FormatString) => dx_DrawExtendFormatVStringToZBuffer(x, y, ExRateX, ExRateY, WriteZMode, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaStringToZBuffer(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, int WriteZMode, int VerticalFlag, string String);
		public static int DrawRotaStringToZBuffer(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, int WriteZMode, int VerticalFlag, string String) => dx_DrawRotaStringToZBuffer(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, WriteZMode, VerticalFlag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaNStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaNStringToZBuffer(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, int WriteZMode, int VerticalFlag, string String, ulong StringLength);
		public static int DrawRotaNStringToZBuffer(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, int WriteZMode, int VerticalFlag, string String, ulong StringLength) => dx_DrawRotaNStringToZBuffer(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, WriteZMode, VerticalFlag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaFormatStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaFormatStringToZBuffer(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, int WriteZMode, int VerticalFlag, string FormatString);
		public static int DrawRotaFormatStringToZBuffer(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, int WriteZMode, int VerticalFlag, string FormatString) => dx_DrawRotaFormatStringToZBuffer(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, WriteZMode, VerticalFlag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiStringToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int WriteZMode, int VerticalFlag, string String);
		public static int DrawModiStringToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int WriteZMode, int VerticalFlag, string String) => dx_DrawModiStringToZBuffer(x1, y1, x2, y2, x3, y3, x4, y4, WriteZMode, VerticalFlag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiNStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiNStringToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int WriteZMode, int VerticalFlag, string String, ulong StringLength);
		public static int DrawModiNStringToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int WriteZMode, int VerticalFlag, string String, ulong StringLength) => dx_DrawModiNStringToZBuffer(x1, y1, x2, y2, x3, y3, x4, y4, WriteZMode, VerticalFlag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiFormatStringToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiFormatStringToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int WriteZMode, int VerticalFlag, string FormatString);
		public static int DrawModiFormatStringToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int WriteZMode, int VerticalFlag, string FormatString) => dx_DrawModiFormatStringToZBuffer(x1, y1, x2, y2, x3, y3, x4, y4, WriteZMode, VerticalFlag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawStringToHandle(int x, int y, string String, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag);
		public static int DrawStringToHandle(int x, int y, string String, uint Color, int FontHandle, uint EdgeColor = 0, int VerticalFlag = FALSE) => dx_DrawStringToHandle(x, y, String, Color, FontHandle, EdgeColor, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNStringToHandle(int x, int y, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag);
		public static int DrawNStringToHandle(int x, int y, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor = 0, int VerticalFlag = FALSE) => dx_DrawNStringToHandle(x, y, String, StringLength, Color, FontHandle, EdgeColor, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawVStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawVStringToHandle(int x, int y, string String, uint Color, int FontHandle, uint EdgeColor);
		public static int DrawVStringToHandle(int x, int y, string String, uint Color, int FontHandle, uint EdgeColor = 0) => dx_DrawVStringToHandle(x, y, String, Color, FontHandle, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNVStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNVStringToHandle(int x, int y, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor);
		public static int DrawNVStringToHandle(int x, int y, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor = 0) => dx_DrawNVStringToHandle(x, y, String, StringLength, Color, FontHandle, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatStringToHandle(int x, int y, uint Color, int FontHandle, string FormatString);
		public static int DrawFormatStringToHandle(int x, int y, uint Color, int FontHandle, string FormatString) => dx_DrawFormatStringToHandle(x, y, Color, FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatVStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatVStringToHandle(int x, int y, uint Color, int FontHandle, string FormatString);
		public static int DrawFormatVStringToHandle(int x, int y, uint Color, int FontHandle, string FormatString) => dx_DrawFormatVStringToHandle(x, y, Color, FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendStringToHandle(int x, int y, double ExRateX, double ExRateY, string String, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag);
		public static int DrawExtendStringToHandle(int x, int y, double ExRateX, double ExRateY, string String, uint Color, int FontHandle, uint EdgeColor = 0, int VerticalFlag = FALSE) => dx_DrawExtendStringToHandle(x, y, ExRateX, ExRateY, String, Color, FontHandle, EdgeColor, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendNStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendNStringToHandle(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag);
		public static int DrawExtendNStringToHandle(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor = 0, int VerticalFlag = FALSE) => dx_DrawExtendNStringToHandle(x, y, ExRateX, ExRateY, String, StringLength, Color, FontHandle, EdgeColor, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendVStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendVStringToHandle(int x, int y, double ExRateX, double ExRateY, string String, uint Color, int FontHandle, uint EdgeColor);
		public static int DrawExtendVStringToHandle(int x, int y, double ExRateX, double ExRateY, string String, uint Color, int FontHandle, uint EdgeColor = 0) => dx_DrawExtendVStringToHandle(x, y, ExRateX, ExRateY, String, Color, FontHandle, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendNVStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendNVStringToHandle(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor);
		public static int DrawExtendNVStringToHandle(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor = 0) => dx_DrawExtendNVStringToHandle(x, y, ExRateX, ExRateY, String, StringLength, Color, FontHandle, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendFormatStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendFormatStringToHandle(int x, int y, double ExRateX, double ExRateY, uint Color, int FontHandle, string FormatString);
		public static int DrawExtendFormatStringToHandle(int x, int y, double ExRateX, double ExRateY, uint Color, int FontHandle, string FormatString) => dx_DrawExtendFormatStringToHandle(x, y, ExRateX, ExRateY, Color, FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendFormatVStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendFormatVStringToHandle(int x, int y, double ExRateX, double ExRateY, uint Color, int FontHandle, string FormatString);
		public static int DrawExtendFormatVStringToHandle(int x, int y, double ExRateX, double ExRateY, uint Color, int FontHandle, string FormatString) => dx_DrawExtendFormatVStringToHandle(x, y, ExRateX, ExRateY, Color, FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaStringToHandle(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String);
		public static int DrawRotaStringToHandle(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String) => dx_DrawRotaStringToHandle(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, Color, FontHandle, EdgeColor, VerticalFlag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaNStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaNStringToHandle(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String, ulong StringLength);
		public static int DrawRotaNStringToHandle(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String, ulong StringLength) => dx_DrawRotaNStringToHandle(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, Color, FontHandle, EdgeColor, VerticalFlag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaFormatStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaFormatStringToHandle(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string FormatString);
		public static int DrawRotaFormatStringToHandle(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string FormatString) => dx_DrawRotaFormatStringToHandle(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, Color, FontHandle, EdgeColor, VerticalFlag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiStringToHandle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String);
		public static int DrawModiStringToHandle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String) => dx_DrawModiStringToHandle(x1, y1, x2, y2, x3, y3, x4, y4, Color, FontHandle, EdgeColor, VerticalFlag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiNStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiNStringToHandle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String, ulong StringLength);
		public static int DrawModiNStringToHandle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String, ulong StringLength) => dx_DrawModiNStringToHandle(x1, y1, x2, y2, x3, y3, x4, y4, Color, FontHandle, EdgeColor, VerticalFlag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiFormatStringToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiFormatStringToHandle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string FormatString);
		public static int DrawModiFormatStringToHandle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string FormatString) => dx_DrawModiFormatStringToHandle(x1, y1, x2, y2, x3, y3, x4, y4, Color, FontHandle, EdgeColor, VerticalFlag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawStringFToHandle(float x, float y, string String, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag);
		public static int DrawStringFToHandle(float x, float y, string String, uint Color, int FontHandle, uint EdgeColor = 0, int VerticalFlag = FALSE) => dx_DrawStringFToHandle(x, y, String, Color, FontHandle, EdgeColor, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNStringFToHandle(float x, float y, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag);
		public static int DrawNStringFToHandle(float x, float y, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor = 0, int VerticalFlag = FALSE) => dx_DrawNStringFToHandle(x, y, String, StringLength, Color, FontHandle, EdgeColor, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawVStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawVStringFToHandle(float x, float y, string String, uint Color, int FontHandle, uint EdgeColor);
		public static int DrawVStringFToHandle(float x, float y, string String, uint Color, int FontHandle, uint EdgeColor = 0) => dx_DrawVStringFToHandle(x, y, String, Color, FontHandle, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNVStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNVStringFToHandle(float x, float y, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor);
		public static int DrawNVStringFToHandle(float x, float y, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor = 0) => dx_DrawNVStringFToHandle(x, y, String, StringLength, Color, FontHandle, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatStringFToHandle(float x, float y, uint Color, int FontHandle, string FormatString);
		public static int DrawFormatStringFToHandle(float x, float y, uint Color, int FontHandle, string FormatString) => dx_DrawFormatStringFToHandle(x, y, Color, FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatVStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatVStringFToHandle(float x, float y, uint Color, int FontHandle, string FormatString);
		public static int DrawFormatVStringFToHandle(float x, float y, uint Color, int FontHandle, string FormatString) => dx_DrawFormatVStringFToHandle(x, y, Color, FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendStringFToHandle(float x, float y, double ExRateX, double ExRateY, string String, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag);
		public static int DrawExtendStringFToHandle(float x, float y, double ExRateX, double ExRateY, string String, uint Color, int FontHandle, uint EdgeColor = 0, int VerticalFlag = FALSE) => dx_DrawExtendStringFToHandle(x, y, ExRateX, ExRateY, String, Color, FontHandle, EdgeColor, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendNStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendNStringFToHandle(float x, float y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag);
		public static int DrawExtendNStringFToHandle(float x, float y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor = 0, int VerticalFlag = FALSE) => dx_DrawExtendNStringFToHandle(x, y, ExRateX, ExRateY, String, StringLength, Color, FontHandle, EdgeColor, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendVStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendVStringFToHandle(float x, float y, double ExRateX, double ExRateY, string String, uint Color, int FontHandle, uint EdgeColor);
		public static int DrawExtendVStringFToHandle(float x, float y, double ExRateX, double ExRateY, string String, uint Color, int FontHandle, uint EdgeColor = 0) => dx_DrawExtendVStringFToHandle(x, y, ExRateX, ExRateY, String, Color, FontHandle, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendNVStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendNVStringFToHandle(float x, float y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor);
		public static int DrawExtendNVStringFToHandle(float x, float y, double ExRateX, double ExRateY, string String, ulong StringLength, uint Color, int FontHandle, uint EdgeColor = 0) => dx_DrawExtendNVStringFToHandle(x, y, ExRateX, ExRateY, String, StringLength, Color, FontHandle, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendFormatStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendFormatStringFToHandle(float x, float y, double ExRateX, double ExRateY, uint Color, int FontHandle, string FormatString);
		public static int DrawExtendFormatStringFToHandle(float x, float y, double ExRateX, double ExRateY, uint Color, int FontHandle, string FormatString) => dx_DrawExtendFormatStringFToHandle(x, y, ExRateX, ExRateY, Color, FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendFormatVStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendFormatVStringFToHandle(float x, float y, double ExRateX, double ExRateY, uint Color, int FontHandle, string FormatString);
		public static int DrawExtendFormatVStringFToHandle(float x, float y, double ExRateX, double ExRateY, uint Color, int FontHandle, string FormatString) => dx_DrawExtendFormatVStringFToHandle(x, y, ExRateX, ExRateY, Color, FontHandle, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaStringFToHandle(float x, float y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String);
		public static int DrawRotaStringFToHandle(float x, float y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, int FontHandle, uint EdgeColor = 0, int VerticalFlag = FALSE, string String = default) => dx_DrawRotaStringFToHandle(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, Color, FontHandle, EdgeColor, VerticalFlag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaNStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaNStringFToHandle(float x, float y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String, ulong StringLength);
		public static int DrawRotaNStringFToHandle(float x, float y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, int FontHandle, uint EdgeColor = 0, int VerticalFlag = FALSE, string String = default, ulong StringLength = 0) => dx_DrawRotaNStringFToHandle(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, Color, FontHandle, EdgeColor, VerticalFlag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaFormatStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaFormatStringFToHandle(float x, float y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string FormatString);
		public static int DrawRotaFormatStringFToHandle(float x, float y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, uint Color, int FontHandle, uint EdgeColor = 0, int VerticalFlag = FALSE, string FormatString = default) => dx_DrawRotaFormatStringFToHandle(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, Color, FontHandle, EdgeColor, VerticalFlag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiStringFToHandle(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String);
		public static int DrawModiStringFToHandle(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String) => dx_DrawModiStringFToHandle(x1, y1, x2, y2, x3, y3, x4, y4, Color, FontHandle, EdgeColor, VerticalFlag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiNStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiNStringFToHandle(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String, ulong StringLength);
		public static int DrawModiNStringFToHandle(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string String, ulong StringLength) => dx_DrawModiNStringFToHandle(x1, y1, x2, y2, x3, y3, x4, y4, Color, FontHandle, EdgeColor, VerticalFlag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiFormatStringFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiFormatStringFToHandle(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string FormatString);
		public static int DrawModiFormatStringFToHandle(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, uint Color, int FontHandle, uint EdgeColor, int VerticalFlag, string FormatString) => dx_DrawModiFormatStringFToHandle(x1, y1, x2, y2, x3, y3, x4, y4, Color, FontHandle, EdgeColor, VerticalFlag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNumberToIToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNumberToIToHandle(int x, int y, int Num, int RisesNum, uint Color, int FontHandle, uint EdgeColor);
		public static int DrawNumberToIToHandle(int x, int y, int Num, int RisesNum, uint Color, int FontHandle, uint EdgeColor = 0) => dx_DrawNumberToIToHandle(x, y, Num, RisesNum, Color, FontHandle, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNumberToFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNumberToFToHandle(int x, int y, double Num, int Length, uint Color, int FontHandle, uint EdgeColor);
		public static int DrawNumberToFToHandle(int x, int y, double Num, int Length, uint Color, int FontHandle, uint EdgeColor = 0) => dx_DrawNumberToFToHandle(x, y, Num, Length, Color, FontHandle, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNumberPlusToIToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNumberPlusToIToHandle(int x, int y, string NoteString, int Num, int RisesNum, uint Color, int FontHandle, uint EdgeColor);
		public static int DrawNumberPlusToIToHandle(int x, int y, string NoteString, int Num, int RisesNum, uint Color, int FontHandle, uint EdgeColor = 0) => dx_DrawNumberPlusToIToHandle(x, y, NoteString, Num, RisesNum, Color, FontHandle, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNumberPlusToFToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNumberPlusToFToHandle(int x, int y, string NoteString, double Num, int Length, uint Color, int FontHandle, uint EdgeColor);
		public static int DrawNumberPlusToFToHandle(int x, int y, string NoteString, double Num, int Length, uint Color, int FontHandle, uint EdgeColor = 0) => dx_DrawNumberPlusToFToHandle(x, y, NoteString, Num, Length, Color, FontHandle, EdgeColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawStringToHandleToZBuffer(int x, int y, string String, int FontHandle, int WriteZMode, int VerticalFlag);
		public static int DrawStringToHandleToZBuffer(int x, int y, string String, int FontHandle, int WriteZMode, int VerticalFlag = FALSE) => dx_DrawStringToHandleToZBuffer(x, y, String, FontHandle, WriteZMode, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNStringToHandleToZBuffer(int x, int y, string String, ulong StringLength, int FontHandle, int WriteZMode, int VerticalFlag);
		public static int DrawNStringToHandleToZBuffer(int x, int y, string String, ulong StringLength, int FontHandle, int WriteZMode, int VerticalFlag = FALSE) => dx_DrawNStringToHandleToZBuffer(x, y, String, StringLength, FontHandle, WriteZMode, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawVStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawVStringToHandleToZBuffer(int x, int y, string String, int FontHandle, int WriteZMode);
		public static int DrawVStringToHandleToZBuffer(int x, int y, string String, int FontHandle, int WriteZMode) => dx_DrawVStringToHandleToZBuffer(x, y, String, FontHandle, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawNVStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawNVStringToHandleToZBuffer(int x, int y, string String, ulong StringLength, int FontHandle, int WriteZMode);
		public static int DrawNVStringToHandleToZBuffer(int x, int y, string String, ulong StringLength, int FontHandle, int WriteZMode) => dx_DrawNVStringToHandleToZBuffer(x, y, String, StringLength, FontHandle, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatStringToHandleToZBuffer(int x, int y, int FontHandle, int WriteZMode, string FormatString);
		public static int DrawFormatStringToHandleToZBuffer(int x, int y, int FontHandle, int WriteZMode, string FormatString) => dx_DrawFormatStringToHandleToZBuffer(x, y, FontHandle, WriteZMode, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawFormatVStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawFormatVStringToHandleToZBuffer(int x, int y, int FontHandle, int WriteZMode, string FormatString);
		public static int DrawFormatVStringToHandleToZBuffer(int x, int y, int FontHandle, int WriteZMode, string FormatString) => dx_DrawFormatVStringToHandleToZBuffer(x, y, FontHandle, WriteZMode, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, int FontHandle, int WriteZMode, int VerticalFlag);
		public static int DrawExtendStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, int FontHandle, int WriteZMode, int VerticalFlag = FALSE) => dx_DrawExtendStringToHandleToZBuffer(x, y, ExRateX, ExRateY, String, FontHandle, WriteZMode, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendNStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendNStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, int FontHandle, int WriteZMode, int VerticalFlag);
		public static int DrawExtendNStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, int FontHandle, int WriteZMode, int VerticalFlag = FALSE) => dx_DrawExtendNStringToHandleToZBuffer(x, y, ExRateX, ExRateY, String, StringLength, FontHandle, WriteZMode, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendVStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendVStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, int FontHandle, int WriteZMode);
		public static int DrawExtendVStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, int FontHandle, int WriteZMode) => dx_DrawExtendVStringToHandleToZBuffer(x, y, ExRateX, ExRateY, String, FontHandle, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendNVStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendNVStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, int FontHandle, int WriteZMode);
		public static int DrawExtendNVStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, string String, ulong StringLength, int FontHandle, int WriteZMode) => dx_DrawExtendNVStringToHandleToZBuffer(x, y, ExRateX, ExRateY, String, StringLength, FontHandle, WriteZMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendFormatStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendFormatStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, int FontHandle, int WriteZMode, string FormatString);
		public static int DrawExtendFormatStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, int FontHandle, int WriteZMode, string FormatString) => dx_DrawExtendFormatStringToHandleToZBuffer(x, y, ExRateX, ExRateY, FontHandle, WriteZMode, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawExtendFormatVStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawExtendFormatVStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, int FontHandle, int WriteZMode, string FormatString);
		public static int DrawExtendFormatVStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, int FontHandle, int WriteZMode, string FormatString) => dx_DrawExtendFormatVStringToHandleToZBuffer(x, y, ExRateX, ExRateY, FontHandle, WriteZMode, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, int FontHandle, int WriteZMode, int VerticalFlag, string String);
		public static int DrawRotaStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, int FontHandle, int WriteZMode, int VerticalFlag, string String) => dx_DrawRotaStringToHandleToZBuffer(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, FontHandle, WriteZMode, VerticalFlag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaNStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaNStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, int FontHandle, int WriteZMode, int VerticalFlag, string String, ulong StringLength);
		public static int DrawRotaNStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, int FontHandle, int WriteZMode, int VerticalFlag, string String, ulong StringLength) => dx_DrawRotaNStringToHandleToZBuffer(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, FontHandle, WriteZMode, VerticalFlag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawRotaFormatStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawRotaFormatStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, int FontHandle, int WriteZMode, int VerticalFlag, string FormatString);
		public static int DrawRotaFormatStringToHandleToZBuffer(int x, int y, double ExRateX, double ExRateY, double RotCenterX, double RotCenterY, double RotAngle, int FontHandle, int WriteZMode, int VerticalFlag, string FormatString) => dx_DrawRotaFormatStringToHandleToZBuffer(x, y, ExRateX, ExRateY, RotCenterX, RotCenterY, RotAngle, FontHandle, WriteZMode, VerticalFlag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiStringToHandleToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int FontHandle, int WriteZMode, int VerticalFlag, string String);
		public static int DrawModiStringToHandleToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int FontHandle, int WriteZMode, int VerticalFlag, string String) => dx_DrawModiStringToHandleToZBuffer(x1, y1, x2, y2, x3, y3, x4, y4, FontHandle, WriteZMode, VerticalFlag, String);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiNStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiNStringToHandleToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int FontHandle, int WriteZMode, int VerticalFlag, string String, ulong StringLength);
		public static int DrawModiNStringToHandleToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int FontHandle, int WriteZMode, int VerticalFlag, string String, ulong StringLength) => dx_DrawModiNStringToHandleToZBuffer(x1, y1, x2, y2, x3, y3, x4, y4, FontHandle, WriteZMode, VerticalFlag, String, StringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawModiFormatStringToHandleToZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawModiFormatStringToHandleToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int FontHandle, int WriteZMode, int VerticalFlag, string FormatString);
		public static int DrawModiFormatStringToHandleToZBuffer(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int FontHandle, int WriteZMode, int VerticalFlag, string FormatString) => dx_DrawModiFormatStringToHandleToZBuffer(x1, y1, x2, y2, x3, y3, x4, y4, FontHandle, WriteZMode, VerticalFlag, FormatString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvertMatrixFtoD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ConvertMatrixFtoD(out MATRIX_D Out, out MATRIX In);
		public static int ConvertMatrixFtoD(out MATRIX_D Out, out MATRIX In) => dx_ConvertMatrixFtoD(out Out, out In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvertMatrixDtoF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ConvertMatrixDtoF(out MATRIX Out, out MATRIX_D In);
		public static int ConvertMatrixDtoF(out MATRIX Out, out MATRIX_D In) => dx_ConvertMatrixDtoF(out Out, out In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateIdentityMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateIdentityMatrix(out MATRIX Out);
		public static int CreateIdentityMatrix(out MATRIX Out) => dx_CreateIdentityMatrix(out Out);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateIdentityMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateIdentityMatrixD(out MATRIX_D Out);
		public static int CreateIdentityMatrixD(out MATRIX_D Out) => dx_CreateIdentityMatrixD(out Out);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateLookAtMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateLookAtMatrix(out MATRIX Out, out VECTOR Eye, out VECTOR At, out VECTOR Up);
		public static int CreateLookAtMatrix(out MATRIX Out, out VECTOR Eye, out VECTOR At, out VECTOR Up) => dx_CreateLookAtMatrix(out Out, out Eye, out At, out Up);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateLookAtMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateLookAtMatrixD(out MATRIX_D Out, out VECTOR_D Eye, out VECTOR_D At, out VECTOR_D Up);
		public static int CreateLookAtMatrixD(out MATRIX_D Out, out VECTOR_D Eye, out VECTOR_D At, out VECTOR_D Up) => dx_CreateLookAtMatrixD(out Out, out Eye, out At, out Up);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateLookAtMatrix2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateLookAtMatrix2(out MATRIX Out, out VECTOR Eye, double XZAngle, double Oira);
		public static int CreateLookAtMatrix2(out MATRIX Out, out VECTOR Eye, double XZAngle, double Oira) => dx_CreateLookAtMatrix2(out Out, out Eye, XZAngle, Oira);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateLookAtMatrix2D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateLookAtMatrix2D(out MATRIX_D Out, out VECTOR_D Eye, double XZAngle, double Oira);
		public static int CreateLookAtMatrix2D(out MATRIX_D Out, out VECTOR_D Eye, double XZAngle, double Oira) => dx_CreateLookAtMatrix2D(out Out, out Eye, XZAngle, Oira);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateLookAtMatrixRH", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateLookAtMatrixRH(out MATRIX Out, out VECTOR Eye, out VECTOR At, out VECTOR Up);
		public static int CreateLookAtMatrixRH(out MATRIX Out, out VECTOR Eye, out VECTOR At, out VECTOR Up) => dx_CreateLookAtMatrixRH(out Out, out Eye, out At, out Up);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateLookAtMatrixRHD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateLookAtMatrixRHD(out MATRIX_D Out, out VECTOR_D Eye, out VECTOR_D At, out VECTOR_D Up);
		public static int CreateLookAtMatrixRHD(out MATRIX_D Out, out VECTOR_D Eye, out VECTOR_D At, out VECTOR_D Up) => dx_CreateLookAtMatrixRHD(out Out, out Eye, out At, out Up);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateMultiplyMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateMultiplyMatrix(out MATRIX Out, out MATRIX In1, out MATRIX In2);
		public static int CreateMultiplyMatrix(out MATRIX Out, out MATRIX In1, out MATRIX In2) => dx_CreateMultiplyMatrix(out Out, out In1, out In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateMultiplyMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateMultiplyMatrixD(out MATRIX_D Out, out MATRIX_D In1, out MATRIX_D In2);
		public static int CreateMultiplyMatrixD(out MATRIX_D Out, out MATRIX_D In1, out MATRIX_D In2) => dx_CreateMultiplyMatrixD(out Out, out In1, out In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreatePerspectiveFovMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreatePerspectiveFovMatrix(out MATRIX Out, float fov, float zn, float zf, float aspect);
		public static int CreatePerspectiveFovMatrix(out MATRIX Out, float fov, float zn, float zf, float aspect = default) => dx_CreatePerspectiveFovMatrix(out Out, fov, zn, zf, aspect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreatePerspectiveFovMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreatePerspectiveFovMatrixD(out MATRIX_D Out, double fov, double zn, double zf, double aspect);
		public static int CreatePerspectiveFovMatrixD(out MATRIX_D Out, double fov, double zn, double zf, double aspect = default) => dx_CreatePerspectiveFovMatrixD(out Out, fov, zn, zf, aspect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreatePerspectiveFovMatrixRH", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreatePerspectiveFovMatrixRH(out MATRIX Out, float fov, float zn, float zf, float aspect);
		public static int CreatePerspectiveFovMatrixRH(out MATRIX Out, float fov, float zn, float zf, float aspect = default) => dx_CreatePerspectiveFovMatrixRH(out Out, fov, zn, zf, aspect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreatePerspectiveFovMatrixRHD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreatePerspectiveFovMatrixRHD(out MATRIX_D Out, double fov, double zn, double zf, double aspect);
		public static int CreatePerspectiveFovMatrixRHD(out MATRIX_D Out, double fov, double zn, double zf, double aspect = default) => dx_CreatePerspectiveFovMatrixRHD(out Out, fov, zn, zf, aspect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateOrthoMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateOrthoMatrix(out MATRIX Out, float size, float zn, float zf, float aspect);
		public static int CreateOrthoMatrix(out MATRIX Out, float size, float zn, float zf, float aspect = default) => dx_CreateOrthoMatrix(out Out, size, zn, zf, aspect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateOrthoMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateOrthoMatrixD(out MATRIX_D Out, double size, double zn, double zf, double aspect);
		public static int CreateOrthoMatrixD(out MATRIX_D Out, double size, double zn, double zf, double aspect = default) => dx_CreateOrthoMatrixD(out Out, size, zn, zf, aspect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateOrthoMatrixRH", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateOrthoMatrixRH(out MATRIX Out, float size, float zn, float zf, float aspect);
		public static int CreateOrthoMatrixRH(out MATRIX Out, float size, float zn, float zf, float aspect = default) => dx_CreateOrthoMatrixRH(out Out, size, zn, zf, aspect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateOrthoMatrixRHD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateOrthoMatrixRHD(out MATRIX_D Out, double size, double zn, double zf, double aspect);
		public static int CreateOrthoMatrixRHD(out MATRIX_D Out, double size, double zn, double zf, double aspect = default) => dx_CreateOrthoMatrixRHD(out Out, size, zn, zf, aspect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateScalingMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateScalingMatrix(out MATRIX Out, float sx, float sy, float sz);
		public static int CreateScalingMatrix(out MATRIX Out, float sx, float sy, float sz) => dx_CreateScalingMatrix(out Out, sx, sy, sz);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateScalingMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateScalingMatrixD(out MATRIX_D Out, double sx, double sy, double sz);
		public static int CreateScalingMatrixD(out MATRIX_D Out, double sx, double sy, double sz) => dx_CreateScalingMatrixD(out Out, sx, sy, sz);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationXMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationXMatrix(out MATRIX Out, float Angle);
		public static int CreateRotationXMatrix(out MATRIX Out, float Angle) => dx_CreateRotationXMatrix(out Out, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationXMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationXMatrixD(out MATRIX_D Out, double Angle);
		public static int CreateRotationXMatrixD(out MATRIX_D Out, double Angle) => dx_CreateRotationXMatrixD(out Out, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationYMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationYMatrix(out MATRIX Out, float Angle);
		public static int CreateRotationYMatrix(out MATRIX Out, float Angle) => dx_CreateRotationYMatrix(out Out, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationYMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationYMatrixD(out MATRIX_D Out, double Angle);
		public static int CreateRotationYMatrixD(out MATRIX_D Out, double Angle) => dx_CreateRotationYMatrixD(out Out, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationZMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationZMatrix(out MATRIX Out, float Angle);
		public static int CreateRotationZMatrix(out MATRIX Out, float Angle) => dx_CreateRotationZMatrix(out Out, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationZMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationZMatrixD(out MATRIX_D Out, double Angle);
		public static int CreateRotationZMatrixD(out MATRIX_D Out, double Angle) => dx_CreateRotationZMatrixD(out Out, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateTranslationMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateTranslationMatrix(out MATRIX Out, float x, float y, float z);
		public static int CreateTranslationMatrix(out MATRIX Out, float x, float y, float z) => dx_CreateTranslationMatrix(out Out, x, y, z);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateTranslationMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateTranslationMatrixD(out MATRIX_D Out, double x, double y, double z);
		public static int CreateTranslationMatrixD(out MATRIX_D Out, double x, double y, double z) => dx_CreateTranslationMatrixD(out Out, x, y, z);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateTransposeMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateTransposeMatrix(out MATRIX Out, out MATRIX In);
		public static int CreateTransposeMatrix(out MATRIX Out, out MATRIX In) => dx_CreateTransposeMatrix(out Out, out In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateTransposeMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateTransposeMatrixD(out MATRIX_D Out, out MATRIX_D In);
		public static int CreateTransposeMatrixD(out MATRIX_D Out, out MATRIX_D In) => dx_CreateTransposeMatrixD(out Out, out In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateInverseMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateInverseMatrix(out MATRIX Out, out MATRIX In);
		public static int CreateInverseMatrix(out MATRIX Out, out MATRIX In) => dx_CreateInverseMatrix(out Out, out In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateInverseMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateInverseMatrixD(out MATRIX_D Out, out MATRIX_D In);
		public static int CreateInverseMatrixD(out MATRIX_D Out, out MATRIX_D In) => dx_CreateInverseMatrixD(out Out, out In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateViewportMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateViewportMatrix(out MATRIX Out, float CenterX, float CenterY, float Width, float Height);
		public static int CreateViewportMatrix(out MATRIX Out, float CenterX, float CenterY, float Width, float Height) => dx_CreateViewportMatrix(out Out, CenterX, CenterY, Width, Height);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateViewportMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateViewportMatrixD(out MATRIX_D Out, double CenterX, double CenterY, double Width, double Height);
		public static int CreateViewportMatrixD(out MATRIX_D Out, double CenterX, double CenterY, double Width, double Height) => dx_CreateViewportMatrixD(out Out, CenterX, CenterY, Width, Height);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationXYZMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationXYZMatrix(out MATRIX Out, float XRot, float YRot, float ZRot);
		public static int CreateRotationXYZMatrix(out MATRIX Out, float XRot, float YRot, float ZRot) => dx_CreateRotationXYZMatrix(out Out, XRot, YRot, ZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationXYZMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationXYZMatrixD(out MATRIX_D Out, double XRot, double YRot, double ZRot);
		public static int CreateRotationXYZMatrixD(out MATRIX_D Out, double XRot, double YRot, double ZRot) => dx_CreateRotationXYZMatrixD(out Out, XRot, YRot, ZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationXZYMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationXZYMatrix(out MATRIX Out, float XRot, float YRot, float ZRot);
		public static int CreateRotationXZYMatrix(out MATRIX Out, float XRot, float YRot, float ZRot) => dx_CreateRotationXZYMatrix(out Out, XRot, YRot, ZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationXZYMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationXZYMatrixD(out MATRIX_D Out, double XRot, double YRot, double ZRot);
		public static int CreateRotationXZYMatrixD(out MATRIX_D Out, double XRot, double YRot, double ZRot) => dx_CreateRotationXZYMatrixD(out Out, XRot, YRot, ZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationYXZMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationYXZMatrix(out MATRIX Out, float XRot, float YRot, float ZRot);
		public static int CreateRotationYXZMatrix(out MATRIX Out, float XRot, float YRot, float ZRot) => dx_CreateRotationYXZMatrix(out Out, XRot, YRot, ZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationYXZMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationYXZMatrixD(out MATRIX_D Out, double XRot, double YRot, double ZRot);
		public static int CreateRotationYXZMatrixD(out MATRIX_D Out, double XRot, double YRot, double ZRot) => dx_CreateRotationYXZMatrixD(out Out, XRot, YRot, ZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationYZXMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationYZXMatrix(out MATRIX Out, float XRot, float YRot, float ZRot);
		public static int CreateRotationYZXMatrix(out MATRIX Out, float XRot, float YRot, float ZRot) => dx_CreateRotationYZXMatrix(out Out, XRot, YRot, ZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationYZXMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationYZXMatrixD(out MATRIX_D Out, double XRot, double YRot, double ZRot);
		public static int CreateRotationYZXMatrixD(out MATRIX_D Out, double XRot, double YRot, double ZRot) => dx_CreateRotationYZXMatrixD(out Out, XRot, YRot, ZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationZXYMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationZXYMatrix(out MATRIX Out, float XRot, float YRot, float ZRot);
		public static int CreateRotationZXYMatrix(out MATRIX Out, float XRot, float YRot, float ZRot) => dx_CreateRotationZXYMatrix(out Out, XRot, YRot, ZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationZXYMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationZXYMatrixD(out MATRIX_D Out, double XRot, double YRot, double ZRot);
		public static int CreateRotationZXYMatrixD(out MATRIX_D Out, double XRot, double YRot, double ZRot) => dx_CreateRotationZXYMatrixD(out Out, XRot, YRot, ZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationZYXMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationZYXMatrix(out MATRIX Out, float XRot, float YRot, float ZRot);
		public static int CreateRotationZYXMatrix(out MATRIX Out, float XRot, float YRot, float ZRot) => dx_CreateRotationZYXMatrix(out Out, XRot, YRot, ZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRotationZYXMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateRotationZYXMatrixD(out MATRIX_D Out, double XRot, double YRot, double ZRot);
		public static int CreateRotationZYXMatrixD(out MATRIX_D Out, double XRot, double YRot, double ZRot) => dx_CreateRotationZYXMatrixD(out Out, XRot, YRot, ZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMatrixXYZRotation", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMatrixXYZRotation(out MATRIX In, out float OutXRot, out float OutYRot, out float OutZRot);
		public static int GetMatrixXYZRotation(out MATRIX In, out float OutXRot, out float OutYRot, out float OutZRot) => dx_GetMatrixXYZRotation(out In, out OutXRot, out OutYRot, out OutZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMatrixXYZRotationD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMatrixXYZRotationD(out MATRIX_D In, out double OutXRot, out double OutYRot, out double OutZRot);
		public static int GetMatrixXYZRotationD(out MATRIX_D In, out double OutXRot, out double OutYRot, out double OutZRot) => dx_GetMatrixXYZRotationD(out In, out OutXRot, out OutYRot, out OutZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMatrixXZYRotation", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMatrixXZYRotation(out MATRIX In, out float OutXRot, out float OutYRot, out float OutZRot);
		public static int GetMatrixXZYRotation(out MATRIX In, out float OutXRot, out float OutYRot, out float OutZRot) => dx_GetMatrixXZYRotation(out In, out OutXRot, out OutYRot, out OutZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMatrixXZYRotationD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMatrixXZYRotationD(out MATRIX_D In, out double OutXRot, out double OutYRot, out double OutZRot);
		public static int GetMatrixXZYRotationD(out MATRIX_D In, out double OutXRot, out double OutYRot, out double OutZRot) => dx_GetMatrixXZYRotationD(out In, out OutXRot, out OutYRot, out OutZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMatrixYXZRotation", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMatrixYXZRotation(out MATRIX In, out float OutXRot, out float OutYRot, out float OutZRot);
		public static int GetMatrixYXZRotation(out MATRIX In, out float OutXRot, out float OutYRot, out float OutZRot) => dx_GetMatrixYXZRotation(out In, out OutXRot, out OutYRot, out OutZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMatrixYXZRotationD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMatrixYXZRotationD(out MATRIX_D In, out double OutXRot, out double OutYRot, out double OutZRot);
		public static int GetMatrixYXZRotationD(out MATRIX_D In, out double OutXRot, out double OutYRot, out double OutZRot) => dx_GetMatrixYXZRotationD(out In, out OutXRot, out OutYRot, out OutZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMatrixYZXRotation", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMatrixYZXRotation(out MATRIX In, out float OutXRot, out float OutYRot, out float OutZRot);
		public static int GetMatrixYZXRotation(out MATRIX In, out float OutXRot, out float OutYRot, out float OutZRot) => dx_GetMatrixYZXRotation(out In, out OutXRot, out OutYRot, out OutZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMatrixYZXRotationD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMatrixYZXRotationD(out MATRIX_D In, out double OutXRot, out double OutYRot, out double OutZRot);
		public static int GetMatrixYZXRotationD(out MATRIX_D In, out double OutXRot, out double OutYRot, out double OutZRot) => dx_GetMatrixYZXRotationD(out In, out OutXRot, out OutYRot, out OutZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMatrixZXYRotation", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMatrixZXYRotation(out MATRIX In, out float OutXRot, out float OutYRot, out float OutZRot);
		public static int GetMatrixZXYRotation(out MATRIX In, out float OutXRot, out float OutYRot, out float OutZRot) => dx_GetMatrixZXYRotation(out In, out OutXRot, out OutYRot, out OutZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMatrixZXYRotationD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMatrixZXYRotationD(out MATRIX_D In, out double OutXRot, out double OutYRot, out double OutZRot);
		public static int GetMatrixZXYRotationD(out MATRIX_D In, out double OutXRot, out double OutYRot, out double OutZRot) => dx_GetMatrixZXYRotationD(out In, out OutXRot, out OutYRot, out OutZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMatrixZYXRotation", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMatrixZYXRotation(out MATRIX In, out float OutXRot, out float OutYRot, out float OutZRot);
		public static int GetMatrixZYXRotation(out MATRIX In, out float OutXRot, out float OutYRot, out float OutZRot) => dx_GetMatrixZYXRotation(out In, out OutXRot, out OutYRot, out OutZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMatrixZYXRotationD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMatrixZYXRotationD(out MATRIX_D In, out double OutXRot, out double OutYRot, out double OutZRot);
		public static int GetMatrixZYXRotationD(out MATRIX_D In, out double OutXRot, out double OutYRot, out double OutZRot) => dx_GetMatrixZYXRotationD(out In, out OutXRot, out OutYRot, out OutZRot);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorConvertFtoD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorConvertFtoD(out VECTOR_D Out, out VECTOR In);
		public static int VectorConvertFtoD(out VECTOR_D Out, out VECTOR In) => dx_VectorConvertFtoD(out Out, out In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorConvertDtoF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorConvertDtoF(out VECTOR Out, out VECTOR_D In);
		public static int VectorConvertDtoF(out VECTOR Out, out VECTOR_D In) => dx_VectorConvertDtoF(out Out, out In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorNormalize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorNormalize(out VECTOR Out, out VECTOR In);
		public static int VectorNormalize(out VECTOR Out, out VECTOR In) => dx_VectorNormalize(out Out, out In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorNormalizeD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorNormalizeD(out VECTOR_D Out, out VECTOR_D In);
		public static int VectorNormalizeD(out VECTOR_D Out, out VECTOR_D In) => dx_VectorNormalizeD(out Out, out In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorScale(out VECTOR Out, out VECTOR In, float Scale);
		public static int VectorScale(out VECTOR Out, out VECTOR In, float Scale) => dx_VectorScale(out Out, out In, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorScaleD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorScaleD(out VECTOR_D Out, out VECTOR_D In, double Scale);
		public static int VectorScaleD(out VECTOR_D Out, out VECTOR_D In, double Scale) => dx_VectorScaleD(out Out, out In, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorMultiply", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorMultiply(out VECTOR Out, out VECTOR In1, out VECTOR In2);
		public static int VectorMultiply(out VECTOR Out, out VECTOR In1, out VECTOR In2) => dx_VectorMultiply(out Out, out In1, out In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorMultiplyD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorMultiplyD(out VECTOR_D Out, out VECTOR_D In1, out VECTOR_D In2);
		public static int VectorMultiplyD(out VECTOR_D Out, out VECTOR_D In1, out VECTOR_D In2) => dx_VectorMultiplyD(out Out, out In1, out In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorSub", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorSub(out VECTOR Out, out VECTOR In1, out VECTOR In2);
		public static int VectorSub(out VECTOR Out, out VECTOR In1, out VECTOR In2) => dx_VectorSub(out Out, out In1, out In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorSubD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorSubD(out VECTOR_D Out, out VECTOR_D In1, out VECTOR_D In2);
		public static int VectorSubD(out VECTOR_D Out, out VECTOR_D In1, out VECTOR_D In2) => dx_VectorSubD(out Out, out In1, out In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorAdd", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorAdd(out VECTOR Out, out VECTOR In1, out VECTOR In2);
		public static int VectorAdd(out VECTOR Out, out VECTOR In1, out VECTOR In2) => dx_VectorAdd(out Out, out In1, out In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorAddD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorAddD(out VECTOR_D Out, out VECTOR_D In1, out VECTOR_D In2);
		public static int VectorAddD(out VECTOR_D Out, out VECTOR_D In1, out VECTOR_D In2) => dx_VectorAddD(out Out, out In1, out In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorOuterProduct", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorOuterProduct(out VECTOR Out, out VECTOR In1, out VECTOR In2);
		public static int VectorOuterProduct(out VECTOR Out, out VECTOR In1, out VECTOR In2) => dx_VectorOuterProduct(out Out, out In1, out In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorOuterProductD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorOuterProductD(out VECTOR_D Out, out VECTOR_D In1, out VECTOR_D In2);
		public static int VectorOuterProductD(out VECTOR_D Out, out VECTOR_D In1, out VECTOR_D In2) => dx_VectorOuterProductD(out Out, out In1, out In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorInnerProduct", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_VectorInnerProduct(out VECTOR In1, out VECTOR In2);
		public static float VectorInnerProduct(out VECTOR In1, out VECTOR In2) => dx_VectorInnerProduct(out In1, out In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorInnerProductD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_VectorInnerProductD(out VECTOR_D In1, out VECTOR_D In2);
		public static double VectorInnerProductD(out VECTOR_D In1, out VECTOR_D In2) => dx_VectorInnerProductD(out In1, out In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorRotationX", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorRotationX(out VECTOR Out, out VECTOR In, double Angle);
		public static int VectorRotationX(out VECTOR Out, out VECTOR In, double Angle) => dx_VectorRotationX(out Out, out In, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorRotationXD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorRotationXD(out VECTOR_D Out, out VECTOR_D In, double Angle);
		public static int VectorRotationXD(out VECTOR_D Out, out VECTOR_D In, double Angle) => dx_VectorRotationXD(out Out, out In, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorRotationY", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorRotationY(out VECTOR Out, out VECTOR In, double Angle);
		public static int VectorRotationY(out VECTOR Out, out VECTOR In, double Angle) => dx_VectorRotationY(out Out, out In, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorRotationYD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorRotationYD(out VECTOR_D Out, out VECTOR_D In, double Angle);
		public static int VectorRotationYD(out VECTOR_D Out, out VECTOR_D In, double Angle) => dx_VectorRotationYD(out Out, out In, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorRotationZ", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorRotationZ(out VECTOR Out, out VECTOR In, double Angle);
		public static int VectorRotationZ(out VECTOR Out, out VECTOR In, double Angle) => dx_VectorRotationZ(out Out, out In, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorRotationZD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorRotationZD(out VECTOR_D Out, out VECTOR_D In, double Angle);
		public static int VectorRotationZD(out VECTOR_D Out, out VECTOR_D In, double Angle) => dx_VectorRotationZD(out Out, out In, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorTransform", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorTransform(out VECTOR Out, out VECTOR InVec, out MATRIX InMatrix);
		public static int VectorTransform(out VECTOR Out, out VECTOR InVec, out MATRIX InMatrix) => dx_VectorTransform(out Out, out InVec, out InMatrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorTransformD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorTransformD(out VECTOR_D Out, out VECTOR_D InVec, out MATRIX_D InMatrix);
		public static int VectorTransformD(out VECTOR_D Out, out VECTOR_D InVec, out MATRIX_D InMatrix) => dx_VectorTransformD(out Out, out InVec, out InMatrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorTransformSR", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorTransformSR(out VECTOR Out, out VECTOR InVec, out MATRIX InMatrix);
		public static int VectorTransformSR(out VECTOR Out, out VECTOR InVec, out MATRIX InMatrix) => dx_VectorTransformSR(out Out, out InVec, out InMatrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorTransformSRD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorTransformSRD(out VECTOR_D Out, out VECTOR_D InVec, out MATRIX_D InMatrix);
		public static int VectorTransformSRD(out VECTOR_D Out, out VECTOR_D InVec, out MATRIX_D InMatrix) => dx_VectorTransformSRD(out Out, out InVec, out InMatrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorTransform4", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorTransform4(out VECTOR Out, out float V4Out, out VECTOR InVec, out float V4In, out MATRIX InMatrix);
		public static int VectorTransform4(out VECTOR Out, out float V4Out, out VECTOR InVec, out float V4In, out MATRIX InMatrix) => dx_VectorTransform4(out Out, out V4Out, out InVec, out V4In, out InMatrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VectorTransform4D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_VectorTransform4D(out VECTOR_D Out, out double V4Out, out VECTOR_D InVec, out double V4In, out MATRIX_D InMatrix);
		public static int VectorTransform4D(out VECTOR_D Out, out double V4Out, out VECTOR_D InVec, out double V4In, out MATRIX_D InMatrix) => dx_VectorTransform4D(out Out, out V4Out, out InVec, out V4In, out InMatrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Segment_Analyse", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Segment_Segment_Analyse(out VECTOR SegmentAPos1, out VECTOR SegmentAPos2, out VECTOR SegmentBPos1, out VECTOR SegmentBPos2, out SEGMENT_SEGMENT_RESULT Result);
		public static int Segment_Segment_Analyse(out VECTOR SegmentAPos1, out VECTOR SegmentAPos2, out VECTOR SegmentBPos1, out VECTOR SegmentBPos2, out SEGMENT_SEGMENT_RESULT Result) => dx_Segment_Segment_Analyse(out SegmentAPos1, out SegmentAPos2, out SegmentBPos1, out SegmentBPos2, out Result);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Segment_AnalyseD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Segment_Segment_AnalyseD(out VECTOR_D SegmentAPos1, out VECTOR_D SegmentAPos2, out VECTOR_D SegmentBPos1, out VECTOR_D SegmentBPos2, out SEGMENT_SEGMENT_RESULT_D Result);
		public static int Segment_Segment_AnalyseD(out VECTOR_D SegmentAPos1, out VECTOR_D SegmentAPos2, out VECTOR_D SegmentBPos1, out VECTOR_D SegmentBPos2, out SEGMENT_SEGMENT_RESULT_D Result) => dx_Segment_Segment_AnalyseD(out SegmentAPos1, out SegmentAPos2, out SegmentBPos1, out SegmentBPos2, out Result);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Point_Analyse", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Segment_Point_Analyse(out VECTOR SegmentPos1, out VECTOR SegmentPos2, out VECTOR PointPos, out SEGMENT_POINT_RESULT Result);
		public static int Segment_Point_Analyse(out VECTOR SegmentPos1, out VECTOR SegmentPos2, out VECTOR PointPos, out SEGMENT_POINT_RESULT Result) => dx_Segment_Point_Analyse(out SegmentPos1, out SegmentPos2, out PointPos, out Result);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Point_AnalyseD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Segment_Point_AnalyseD(out VECTOR_D SegmentPos1, out VECTOR_D SegmentPos2, out VECTOR_D PointPos, out SEGMENT_POINT_RESULT_D Result);
		public static int Segment_Point_AnalyseD(out VECTOR_D SegmentPos1, out VECTOR_D SegmentPos2, out VECTOR_D PointPos, out SEGMENT_POINT_RESULT_D Result) => dx_Segment_Point_AnalyseD(out SegmentPos1, out SegmentPos2, out PointPos, out Result);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Triangle_Analyse", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Segment_Triangle_Analyse(out VECTOR SegmentPos1, out VECTOR SegmentPos2, out VECTOR TrianglePos1, out VECTOR TrianglePos2, out VECTOR TrianglePos3, out SEGMENT_TRIANGLE_RESULT Result);
		public static int Segment_Triangle_Analyse(out VECTOR SegmentPos1, out VECTOR SegmentPos2, out VECTOR TrianglePos1, out VECTOR TrianglePos2, out VECTOR TrianglePos3, out SEGMENT_TRIANGLE_RESULT Result) => dx_Segment_Triangle_Analyse(out SegmentPos1, out SegmentPos2, out TrianglePos1, out TrianglePos2, out TrianglePos3, out Result);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Triangle_AnalyseD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Segment_Triangle_AnalyseD(out VECTOR_D SegmentPos1, out VECTOR_D SegmentPos2, out VECTOR_D TrianglePos1, out VECTOR_D TrianglePos2, out VECTOR_D TrianglePos3, out SEGMENT_TRIANGLE_RESULT_D Result);
		public static int Segment_Triangle_AnalyseD(out VECTOR_D SegmentPos1, out VECTOR_D SegmentPos2, out VECTOR_D TrianglePos1, out VECTOR_D TrianglePos2, out VECTOR_D TrianglePos3, out SEGMENT_TRIANGLE_RESULT_D Result) => dx_Segment_Triangle_AnalyseD(out SegmentPos1, out SegmentPos2, out TrianglePos1, out TrianglePos2, out TrianglePos3, out Result);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Triangle_Point_Analyse", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Triangle_Point_Analyse(out VECTOR TrianglePos1, out VECTOR TrianglePos2, out VECTOR TrianglePos3, out VECTOR PointPos, out TRIANGLE_POINT_RESULT Result);
		public static int Triangle_Point_Analyse(out VECTOR TrianglePos1, out VECTOR TrianglePos2, out VECTOR TrianglePos3, out VECTOR PointPos, out TRIANGLE_POINT_RESULT Result) => dx_Triangle_Point_Analyse(out TrianglePos1, out TrianglePos2, out TrianglePos3, out PointPos, out Result);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Triangle_Point_AnalyseD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Triangle_Point_AnalyseD(out VECTOR_D TrianglePos1, out VECTOR_D TrianglePos2, out VECTOR_D TrianglePos3, out VECTOR_D PointPos, out TRIANGLE_POINT_RESULT_D Result);
		public static int Triangle_Point_AnalyseD(out VECTOR_D TrianglePos1, out VECTOR_D TrianglePos2, out VECTOR_D TrianglePos3, out VECTOR_D PointPos, out TRIANGLE_POINT_RESULT_D Result) => dx_Triangle_Point_AnalyseD(out TrianglePos1, out TrianglePos2, out TrianglePos3, out PointPos, out Result);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Plane_Point_Analyse", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Plane_Point_Analyse(out VECTOR PlanePos, out VECTOR PlaneNormal, out VECTOR PointPos, out PLANE_POINT_RESULT Result);
		public static int Plane_Point_Analyse(out VECTOR PlanePos, out VECTOR PlaneNormal, out VECTOR PointPos, out PLANE_POINT_RESULT Result) => dx_Plane_Point_Analyse(out PlanePos, out PlaneNormal, out PointPos, out Result);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Plane_Point_AnalyseD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Plane_Point_AnalyseD(out VECTOR_D PlanePos, out VECTOR_D PlaneNormal, out VECTOR_D PointPos, out PLANE_POINT_RESULT_D Result);
		public static int Plane_Point_AnalyseD(out VECTOR_D PlanePos, out VECTOR_D PlaneNormal, out VECTOR_D PointPos, out PLANE_POINT_RESULT_D Result) => dx_Plane_Point_AnalyseD(out PlanePos, out PlaneNormal, out PointPos, out Result);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_TriangleBarycenter", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_TriangleBarycenter(VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3, VECTOR Position, out float TrianglePos1Weight, out float TrianglePos2Weight, out float TrianglePos3Weight);
		public static void TriangleBarycenter(VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3, VECTOR Position, out float TrianglePos1Weight, out float TrianglePos2Weight, out float TrianglePos3Weight) => dx_TriangleBarycenter(TrianglePos1, TrianglePos2, TrianglePos3, Position, out TrianglePos1Weight, out TrianglePos2Weight, out TrianglePos3Weight);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_TriangleBarycenterD", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_TriangleBarycenterD(VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3, VECTOR_D Position, out double TrianglePos1Weight, out double TrianglePos2Weight, out double TrianglePos3Weight);
		public static void TriangleBarycenterD(VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3, VECTOR_D Position, out double TrianglePos1Weight, out double TrianglePos2Weight, out double TrianglePos3Weight) => dx_TriangleBarycenterD(TrianglePos1, TrianglePos2, TrianglePos3, Position, out TrianglePos1Weight, out TrianglePos2Weight, out TrianglePos3Weight);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Segment_MinLength", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Segment_Segment_MinLength(VECTOR SegmentAPos1, VECTOR SegmentAPos2, VECTOR SegmentBPos1, VECTOR SegmentBPos2);
		public static float Segment_Segment_MinLength(VECTOR SegmentAPos1, VECTOR SegmentAPos2, VECTOR SegmentBPos1, VECTOR SegmentBPos2) => dx_Segment_Segment_MinLength(SegmentAPos1, SegmentAPos2, SegmentBPos1, SegmentBPos2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Segment_MinLengthD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_Segment_Segment_MinLengthD(VECTOR_D SegmentAPos1, VECTOR_D SegmentAPos2, VECTOR_D SegmentBPos1, VECTOR_D SegmentBPos2);
		public static double Segment_Segment_MinLengthD(VECTOR_D SegmentAPos1, VECTOR_D SegmentAPos2, VECTOR_D SegmentBPos1, VECTOR_D SegmentBPos2) => dx_Segment_Segment_MinLengthD(SegmentAPos1, SegmentAPos2, SegmentBPos1, SegmentBPos2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Segment_MinLength_Square", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Segment_Segment_MinLength_Square(VECTOR SegmentAPos1, VECTOR SegmentAPos2, VECTOR SegmentBPos1, VECTOR SegmentBPos2);
		public static float Segment_Segment_MinLength_Square(VECTOR SegmentAPos1, VECTOR SegmentAPos2, VECTOR SegmentBPos1, VECTOR SegmentBPos2) => dx_Segment_Segment_MinLength_Square(SegmentAPos1, SegmentAPos2, SegmentBPos1, SegmentBPos2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Segment_MinLength_SquareD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_Segment_Segment_MinLength_SquareD(VECTOR_D SegmentAPos1, VECTOR_D SegmentAPos2, VECTOR_D SegmentBPos1, VECTOR_D SegmentBPos2);
		public static double Segment_Segment_MinLength_SquareD(VECTOR_D SegmentAPos1, VECTOR_D SegmentAPos2, VECTOR_D SegmentBPos1, VECTOR_D SegmentBPos2) => dx_Segment_Segment_MinLength_SquareD(SegmentAPos1, SegmentAPos2, SegmentBPos1, SegmentBPos2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Triangle_MinLength", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Segment_Triangle_MinLength(VECTOR SegmentPos1, VECTOR SegmentPos2, VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3);
		public static float Segment_Triangle_MinLength(VECTOR SegmentPos1, VECTOR SegmentPos2, VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3) => dx_Segment_Triangle_MinLength(SegmentPos1, SegmentPos2, TrianglePos1, TrianglePos2, TrianglePos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Triangle_MinLengthD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_Segment_Triangle_MinLengthD(VECTOR_D SegmentPos1, VECTOR_D SegmentPos2, VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3);
		public static double Segment_Triangle_MinLengthD(VECTOR_D SegmentPos1, VECTOR_D SegmentPos2, VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3) => dx_Segment_Triangle_MinLengthD(SegmentPos1, SegmentPos2, TrianglePos1, TrianglePos2, TrianglePos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Triangle_MinLength_Square", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Segment_Triangle_MinLength_Square(VECTOR SegmentPos1, VECTOR SegmentPos2, VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3);
		public static float Segment_Triangle_MinLength_Square(VECTOR SegmentPos1, VECTOR SegmentPos2, VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3) => dx_Segment_Triangle_MinLength_Square(SegmentPos1, SegmentPos2, TrianglePos1, TrianglePos2, TrianglePos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Triangle_MinLength_SquareD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_Segment_Triangle_MinLength_SquareD(VECTOR_D SegmentPos1, VECTOR_D SegmentPos2, VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3);
		public static double Segment_Triangle_MinLength_SquareD(VECTOR_D SegmentPos1, VECTOR_D SegmentPos2, VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3) => dx_Segment_Triangle_MinLength_SquareD(SegmentPos1, SegmentPos2, TrianglePos1, TrianglePos2, TrianglePos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Point_MinLength", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Segment_Point_MinLength(VECTOR SegmentPos1, VECTOR SegmentPos2, VECTOR PointPos);
		public static float Segment_Point_MinLength(VECTOR SegmentPos1, VECTOR SegmentPos2, VECTOR PointPos) => dx_Segment_Point_MinLength(SegmentPos1, SegmentPos2, PointPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Point_MinLengthD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_Segment_Point_MinLengthD(VECTOR_D SegmentPos1, VECTOR_D SegmentPos2, VECTOR_D PointPos);
		public static double Segment_Point_MinLengthD(VECTOR_D SegmentPos1, VECTOR_D SegmentPos2, VECTOR_D PointPos) => dx_Segment_Point_MinLengthD(SegmentPos1, SegmentPos2, PointPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Point_MinLength_Square", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Segment_Point_MinLength_Square(VECTOR SegmentPos1, VECTOR SegmentPos2, VECTOR PointPos);
		public static float Segment_Point_MinLength_Square(VECTOR SegmentPos1, VECTOR SegmentPos2, VECTOR PointPos) => dx_Segment_Point_MinLength_Square(SegmentPos1, SegmentPos2, PointPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Segment_Point_MinLength_SquareD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_Segment_Point_MinLength_SquareD(VECTOR_D SegmentPos1, VECTOR_D SegmentPos2, VECTOR_D PointPos);
		public static double Segment_Point_MinLength_SquareD(VECTOR_D SegmentPos1, VECTOR_D SegmentPos2, VECTOR_D PointPos) => dx_Segment_Point_MinLength_SquareD(SegmentPos1, SegmentPos2, PointPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Triangle_Point_MinLength", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Triangle_Point_MinLength(VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3, VECTOR PointPos);
		public static float Triangle_Point_MinLength(VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3, VECTOR PointPos) => dx_Triangle_Point_MinLength(TrianglePos1, TrianglePos2, TrianglePos3, PointPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Triangle_Point_MinLengthD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_Triangle_Point_MinLengthD(VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3, VECTOR_D PointPos);
		public static double Triangle_Point_MinLengthD(VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3, VECTOR_D PointPos) => dx_Triangle_Point_MinLengthD(TrianglePos1, TrianglePos2, TrianglePos3, PointPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Triangle_Point_MinLength_Square", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Triangle_Point_MinLength_Square(VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3, VECTOR PointPos);
		public static float Triangle_Point_MinLength_Square(VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3, VECTOR PointPos) => dx_Triangle_Point_MinLength_Square(TrianglePos1, TrianglePos2, TrianglePos3, PointPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Triangle_Point_MinLength_SquareD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_Triangle_Point_MinLength_SquareD(VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3, VECTOR_D PointPos);
		public static double Triangle_Point_MinLength_SquareD(VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3, VECTOR_D PointPos) => dx_Triangle_Point_MinLength_SquareD(TrianglePos1, TrianglePos2, TrianglePos3, PointPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Triangle_Triangle_MinLength", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Triangle_Triangle_MinLength(VECTOR Triangle1Pos1, VECTOR Triangle1Pos2, VECTOR Triangle1Pos3, VECTOR Triangle2Pos1, VECTOR Triangle2Pos2, VECTOR Triangle2Pos3);
		public static float Triangle_Triangle_MinLength(VECTOR Triangle1Pos1, VECTOR Triangle1Pos2, VECTOR Triangle1Pos3, VECTOR Triangle2Pos1, VECTOR Triangle2Pos2, VECTOR Triangle2Pos3) => dx_Triangle_Triangle_MinLength(Triangle1Pos1, Triangle1Pos2, Triangle1Pos3, Triangle2Pos1, Triangle2Pos2, Triangle2Pos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Triangle_Triangle_MinLengthD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_Triangle_Triangle_MinLengthD(VECTOR_D Triangle1Pos1, VECTOR_D Triangle1Pos2, VECTOR_D Triangle1Pos3, VECTOR_D Triangle2Pos1, VECTOR_D Triangle2Pos2, VECTOR_D Triangle2Pos3);
		public static double Triangle_Triangle_MinLengthD(VECTOR_D Triangle1Pos1, VECTOR_D Triangle1Pos2, VECTOR_D Triangle1Pos3, VECTOR_D Triangle2Pos1, VECTOR_D Triangle2Pos2, VECTOR_D Triangle2Pos3) => dx_Triangle_Triangle_MinLengthD(Triangle1Pos1, Triangle1Pos2, Triangle1Pos3, Triangle2Pos1, Triangle2Pos2, Triangle2Pos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Triangle_Triangle_MinLength_Square", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Triangle_Triangle_MinLength_Square(VECTOR Triangle1Pos1, VECTOR Triangle1Pos2, VECTOR Triangle1Pos3, VECTOR Triangle2Pos1, VECTOR Triangle2Pos2, VECTOR Triangle2Pos3);
		public static float Triangle_Triangle_MinLength_Square(VECTOR Triangle1Pos1, VECTOR Triangle1Pos2, VECTOR Triangle1Pos3, VECTOR Triangle2Pos1, VECTOR Triangle2Pos2, VECTOR Triangle2Pos3) => dx_Triangle_Triangle_MinLength_Square(Triangle1Pos1, Triangle1Pos2, Triangle1Pos3, Triangle2Pos1, Triangle2Pos2, Triangle2Pos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Triangle_Triangle_MinLength_SquareD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_Triangle_Triangle_MinLength_SquareD(VECTOR_D Triangle1Pos1, VECTOR_D Triangle1Pos2, VECTOR_D Triangle1Pos3, VECTOR_D Triangle2Pos1, VECTOR_D Triangle2Pos2, VECTOR_D Triangle2Pos3);
		public static double Triangle_Triangle_MinLength_SquareD(VECTOR_D Triangle1Pos1, VECTOR_D Triangle1Pos2, VECTOR_D Triangle1Pos3, VECTOR_D Triangle2Pos1, VECTOR_D Triangle2Pos2, VECTOR_D Triangle2Pos3) => dx_Triangle_Triangle_MinLength_SquareD(Triangle1Pos1, Triangle1Pos2, Triangle1Pos3, Triangle2Pos1, Triangle2Pos2, Triangle2Pos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Plane_Point_MinLength_Position", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_Plane_Point_MinLength_Position(VECTOR PlanePos, VECTOR PlaneNormal, VECTOR PointPos);
		public static VECTOR Plane_Point_MinLength_Position(VECTOR PlanePos, VECTOR PlaneNormal, VECTOR PointPos) => dx_Plane_Point_MinLength_Position(PlanePos, PlaneNormal, PointPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Plane_Point_MinLength_PositionD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_Plane_Point_MinLength_PositionD(VECTOR_D PlanePos, VECTOR_D PlaneNormal, VECTOR_D PointPos);
		public static VECTOR_D Plane_Point_MinLength_PositionD(VECTOR_D PlanePos, VECTOR_D PlaneNormal, VECTOR_D PointPos) => dx_Plane_Point_MinLength_PositionD(PlanePos, PlaneNormal, PointPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Plane_Point_MinLength", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Plane_Point_MinLength(VECTOR PlanePos, VECTOR PlaneNormal, VECTOR PointPos);
		public static float Plane_Point_MinLength(VECTOR PlanePos, VECTOR PlaneNormal, VECTOR PointPos) => dx_Plane_Point_MinLength(PlanePos, PlaneNormal, PointPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Plane_Point_MinLengthD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_Plane_Point_MinLengthD(VECTOR_D PlanePos, VECTOR_D PlaneNormal, VECTOR_D PointPos);
		public static double Plane_Point_MinLengthD(VECTOR_D PlanePos, VECTOR_D PlaneNormal, VECTOR_D PointPos) => dx_Plane_Point_MinLengthD(PlanePos, PlaneNormal, PointPos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Line_Triangle", CallingConvention=CallingConvention.StdCall)]
		extern static HITRESULT_LINE dx_HitCheck_Line_Triangle(VECTOR LinePos1, VECTOR LinePos2, VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3);
		public static HITRESULT_LINE HitCheck_Line_Triangle(VECTOR LinePos1, VECTOR LinePos2, VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3) => dx_HitCheck_Line_Triangle(LinePos1, LinePos2, TrianglePos1, TrianglePos2, TrianglePos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Line_TriangleD", CallingConvention=CallingConvention.StdCall)]
		extern static HITRESULT_LINE_D dx_HitCheck_Line_TriangleD(VECTOR_D LinePos1, VECTOR_D LinePos2, VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3);
		public static HITRESULT_LINE_D HitCheck_Line_TriangleD(VECTOR_D LinePos1, VECTOR_D LinePos2, VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3) => dx_HitCheck_Line_TriangleD(LinePos1, LinePos2, TrianglePos1, TrianglePos2, TrianglePos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Triangle_Triangle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Triangle_Triangle(VECTOR Triangle1Pos1, VECTOR Triangle1Pos2, VECTOR Triangle1Pos3, VECTOR Triangle2Pos1, VECTOR Triangle2Pos2, VECTOR Triangle2Pos3);
		public static int HitCheck_Triangle_Triangle(VECTOR Triangle1Pos1, VECTOR Triangle1Pos2, VECTOR Triangle1Pos3, VECTOR Triangle2Pos1, VECTOR Triangle2Pos2, VECTOR Triangle2Pos3) => dx_HitCheck_Triangle_Triangle(Triangle1Pos1, Triangle1Pos2, Triangle1Pos3, Triangle2Pos1, Triangle2Pos2, Triangle2Pos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Triangle_TriangleD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Triangle_TriangleD(VECTOR_D Triangle1Pos1, VECTOR_D Triangle1Pos2, VECTOR_D Triangle1Pos3, VECTOR_D Triangle2Pos1, VECTOR_D Triangle2Pos2, VECTOR_D Triangle2Pos3);
		public static int HitCheck_Triangle_TriangleD(VECTOR_D Triangle1Pos1, VECTOR_D Triangle1Pos2, VECTOR_D Triangle1Pos3, VECTOR_D Triangle2Pos1, VECTOR_D Triangle2Pos2, VECTOR_D Triangle2Pos3) => dx_HitCheck_Triangle_TriangleD(Triangle1Pos1, Triangle1Pos2, Triangle1Pos3, Triangle2Pos1, Triangle2Pos2, Triangle2Pos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Triangle_Triangle_2D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Triangle_Triangle_2D(VECTOR Triangle1Pos1, VECTOR Triangle1Pos2, VECTOR Triangle1Pos3, VECTOR Triangle2Pos1, VECTOR Triangle2Pos2, VECTOR Triangle2Pos3);
		public static int HitCheck_Triangle_Triangle_2D(VECTOR Triangle1Pos1, VECTOR Triangle1Pos2, VECTOR Triangle1Pos3, VECTOR Triangle2Pos1, VECTOR Triangle2Pos2, VECTOR Triangle2Pos3) => dx_HitCheck_Triangle_Triangle_2D(Triangle1Pos1, Triangle1Pos2, Triangle1Pos3, Triangle2Pos1, Triangle2Pos2, Triangle2Pos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Triangle_TriangleD_2D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Triangle_TriangleD_2D(VECTOR_D Triangle1Pos1, VECTOR_D Triangle1Pos2, VECTOR_D Triangle1Pos3, VECTOR_D Triangle2Pos1, VECTOR_D Triangle2Pos2, VECTOR_D Triangle2Pos3);
		public static int HitCheck_Triangle_TriangleD_2D(VECTOR_D Triangle1Pos1, VECTOR_D Triangle1Pos2, VECTOR_D Triangle1Pos3, VECTOR_D Triangle2Pos1, VECTOR_D Triangle2Pos2, VECTOR_D Triangle2Pos3) => dx_HitCheck_Triangle_TriangleD_2D(Triangle1Pos1, Triangle1Pos2, Triangle1Pos3, Triangle2Pos1, Triangle2Pos2, Triangle2Pos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Line_Cube", CallingConvention=CallingConvention.StdCall)]
		extern static HITRESULT_LINE dx_HitCheck_Line_Cube(VECTOR LinePos1, VECTOR LinePos2, VECTOR CubePos1, VECTOR CubePos2);
		public static HITRESULT_LINE HitCheck_Line_Cube(VECTOR LinePos1, VECTOR LinePos2, VECTOR CubePos1, VECTOR CubePos2) => dx_HitCheck_Line_Cube(LinePos1, LinePos2, CubePos1, CubePos2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Line_CubeD", CallingConvention=CallingConvention.StdCall)]
		extern static HITRESULT_LINE_D dx_HitCheck_Line_CubeD(VECTOR_D LinePos1, VECTOR_D LinePos2, VECTOR_D CubePos1, VECTOR_D CubePos2);
		public static HITRESULT_LINE_D HitCheck_Line_CubeD(VECTOR_D LinePos1, VECTOR_D LinePos2, VECTOR_D CubePos1, VECTOR_D CubePos2) => dx_HitCheck_Line_CubeD(LinePos1, LinePos2, CubePos1, CubePos2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Point_Cone", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Point_Cone(VECTOR PointPos, VECTOR ConeTopPos, VECTOR ConeBottomPos, float ConeR);
		public static int HitCheck_Point_Cone(VECTOR PointPos, VECTOR ConeTopPos, VECTOR ConeBottomPos, float ConeR) => dx_HitCheck_Point_Cone(PointPos, ConeTopPos, ConeBottomPos, ConeR);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Point_ConeD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Point_ConeD(VECTOR_D PointPos, VECTOR_D ConeTopPos, VECTOR_D ConeBottomPos, double ConeR);
		public static int HitCheck_Point_ConeD(VECTOR_D PointPos, VECTOR_D ConeTopPos, VECTOR_D ConeBottomPos, double ConeR) => dx_HitCheck_Point_ConeD(PointPos, ConeTopPos, ConeBottomPos, ConeR);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Line_Sphere", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Line_Sphere(VECTOR LinePos1, VECTOR LinePos2, VECTOR SphereCenterPos, float SphereR);
		public static int HitCheck_Line_Sphere(VECTOR LinePos1, VECTOR LinePos2, VECTOR SphereCenterPos, float SphereR) => dx_HitCheck_Line_Sphere(LinePos1, LinePos2, SphereCenterPos, SphereR);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Line_SphereD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Line_SphereD(VECTOR_D LinePos1, VECTOR_D LinePos2, VECTOR_D SphereCenterPos, double SphereR);
		public static int HitCheck_Line_SphereD(VECTOR_D LinePos1, VECTOR_D LinePos2, VECTOR_D SphereCenterPos, double SphereR) => dx_HitCheck_Line_SphereD(LinePos1, LinePos2, SphereCenterPos, SphereR);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Sphere_Sphere", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Sphere_Sphere(VECTOR Sphere1CenterPos, float Sphere1R, VECTOR Sphere2CenterPos, float Sphere2R);
		public static int HitCheck_Sphere_Sphere(VECTOR Sphere1CenterPos, float Sphere1R, VECTOR Sphere2CenterPos, float Sphere2R) => dx_HitCheck_Sphere_Sphere(Sphere1CenterPos, Sphere1R, Sphere2CenterPos, Sphere2R);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Sphere_SphereD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Sphere_SphereD(VECTOR_D Sphere1CenterPos, double Sphere1R, VECTOR_D Sphere2CenterPos, double Sphere2R);
		public static int HitCheck_Sphere_SphereD(VECTOR_D Sphere1CenterPos, double Sphere1R, VECTOR_D Sphere2CenterPos, double Sphere2R) => dx_HitCheck_Sphere_SphereD(Sphere1CenterPos, Sphere1R, Sphere2CenterPos, Sphere2R);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Sphere_Capsule", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Sphere_Capsule(VECTOR SphereCenterPos, float SphereR, VECTOR CapPos1, VECTOR CapPos2, float CapR);
		public static int HitCheck_Sphere_Capsule(VECTOR SphereCenterPos, float SphereR, VECTOR CapPos1, VECTOR CapPos2, float CapR) => dx_HitCheck_Sphere_Capsule(SphereCenterPos, SphereR, CapPos1, CapPos2, CapR);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Sphere_CapsuleD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Sphere_CapsuleD(VECTOR_D SphereCenterPos, double SphereR, VECTOR_D CapPos1, VECTOR_D CapPos2, double CapR);
		public static int HitCheck_Sphere_CapsuleD(VECTOR_D SphereCenterPos, double SphereR, VECTOR_D CapPos1, VECTOR_D CapPos2, double CapR) => dx_HitCheck_Sphere_CapsuleD(SphereCenterPos, SphereR, CapPos1, CapPos2, CapR);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Sphere_Triangle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Sphere_Triangle(VECTOR SphereCenterPos, float SphereR, VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3);
		public static int HitCheck_Sphere_Triangle(VECTOR SphereCenterPos, float SphereR, VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3) => dx_HitCheck_Sphere_Triangle(SphereCenterPos, SphereR, TrianglePos1, TrianglePos2, TrianglePos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Sphere_TriangleD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Sphere_TriangleD(VECTOR_D SphereCenterPos, double SphereR, VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3);
		public static int HitCheck_Sphere_TriangleD(VECTOR_D SphereCenterPos, double SphereR, VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3) => dx_HitCheck_Sphere_TriangleD(SphereCenterPos, SphereR, TrianglePos1, TrianglePos2, TrianglePos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Capsule_Capsule", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Capsule_Capsule(VECTOR Cap1Pos1, VECTOR Cap1Pos2, float Cap1R, VECTOR Cap2Pos1, VECTOR Cap2Pos2, float Cap2R);
		public static int HitCheck_Capsule_Capsule(VECTOR Cap1Pos1, VECTOR Cap1Pos2, float Cap1R, VECTOR Cap2Pos1, VECTOR Cap2Pos2, float Cap2R) => dx_HitCheck_Capsule_Capsule(Cap1Pos1, Cap1Pos2, Cap1R, Cap2Pos1, Cap2Pos2, Cap2R);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Capsule_CapsuleD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Capsule_CapsuleD(VECTOR_D Cap1Pos1, VECTOR_D Cap1Pos2, double Cap1R, VECTOR_D Cap2Pos1, VECTOR_D Cap2Pos2, double Cap2R);
		public static int HitCheck_Capsule_CapsuleD(VECTOR_D Cap1Pos1, VECTOR_D Cap1Pos2, double Cap1R, VECTOR_D Cap2Pos1, VECTOR_D Cap2Pos2, double Cap2R) => dx_HitCheck_Capsule_CapsuleD(Cap1Pos1, Cap1Pos2, Cap1R, Cap2Pos1, Cap2Pos2, Cap2R);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Capsule_Triangle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Capsule_Triangle(VECTOR CapPos1, VECTOR CapPos2, float CapR, VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3);
		public static int HitCheck_Capsule_Triangle(VECTOR CapPos1, VECTOR CapPos2, float CapR, VECTOR TrianglePos1, VECTOR TrianglePos2, VECTOR TrianglePos3) => dx_HitCheck_Capsule_Triangle(CapPos1, CapPos2, CapR, TrianglePos1, TrianglePos2, TrianglePos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HitCheck_Capsule_TriangleD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_HitCheck_Capsule_TriangleD(VECTOR_D CapPos1, VECTOR_D CapPos2, double CapR, VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3);
		public static int HitCheck_Capsule_TriangleD(VECTOR_D CapPos1, VECTOR_D CapPos2, double CapR, VECTOR_D TrianglePos1, VECTOR_D TrianglePos2, VECTOR_D TrianglePos3) => dx_HitCheck_Capsule_TriangleD(CapPos1, CapPos2, CapR, TrianglePos1, TrianglePos2, TrianglePos3);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_RectClipping", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_RectClipping(out RECT Rect, out RECT ClippuRect);
		public static int RectClipping(out RECT Rect, out RECT ClippuRect) => dx_RectClipping(out Rect, out ClippuRect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_RectAdjust", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_RectAdjust(out RECT Rect);
		public static int RectAdjust(out RECT Rect) => dx_RectAdjust(out Rect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetRectSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetRectSize(out RECT Rect, out int Width, out int Height);
		public static int GetRectSize(out RECT Rect, out int Width, out int Height) => dx_GetRectSize(out Rect, out Width, out Height);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetIdent", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MGetIdent();
		public static MATRIX MGetIdent() => dx_MGetIdent();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetIdentD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MGetIdentD();
		public static MATRIX_D MGetIdentD() => dx_MGetIdentD();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MMult", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MMult(MATRIX In1, MATRIX In2);
		public static MATRIX MMult(MATRIX In1, MATRIX In2) => dx_MMult(In1, In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MMultD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MMultD(MATRIX_D In1, MATRIX_D In2);
		public static MATRIX_D MMultD(MATRIX_D In1, MATRIX_D In2) => dx_MMultD(In1, In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MScale", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MScale(MATRIX InM, float Scale);
		public static MATRIX MScale(MATRIX InM, float Scale) => dx_MScale(InM, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MScaleD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MScaleD(MATRIX_D InM, double Scale);
		public static MATRIX_D MScaleD(MATRIX_D InM, double Scale) => dx_MScaleD(InM, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MAdd", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MAdd(MATRIX In1, MATRIX In2);
		public static MATRIX MAdd(MATRIX In1, MATRIX In2) => dx_MAdd(In1, In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MAddD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MAddD(MATRIX_D In1, MATRIX_D In2);
		public static MATRIX_D MAddD(MATRIX_D In1, MATRIX_D In2) => dx_MAddD(In1, In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetScale", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MGetScale(VECTOR Scale);
		public static MATRIX MGetScale(VECTOR Scale) => dx_MGetScale(Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetScaleD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MGetScaleD(VECTOR_D Scale);
		public static MATRIX_D MGetScaleD(VECTOR_D Scale) => dx_MGetScaleD(Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetRotX", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MGetRotX(float XAxisRotate);
		public static MATRIX MGetRotX(float XAxisRotate) => dx_MGetRotX(XAxisRotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetRotXD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MGetRotXD(double XAxisRotate);
		public static MATRIX_D MGetRotXD(double XAxisRotate) => dx_MGetRotXD(XAxisRotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetRotY", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MGetRotY(float YAxisRotate);
		public static MATRIX MGetRotY(float YAxisRotate) => dx_MGetRotY(YAxisRotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetRotYD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MGetRotYD(double YAxisRotate);
		public static MATRIX_D MGetRotYD(double YAxisRotate) => dx_MGetRotYD(YAxisRotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetRotZ", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MGetRotZ(float ZAxisRotate);
		public static MATRIX MGetRotZ(float ZAxisRotate) => dx_MGetRotZ(ZAxisRotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetRotZD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MGetRotZD(double ZAxisRotate);
		public static MATRIX_D MGetRotZD(double ZAxisRotate) => dx_MGetRotZD(ZAxisRotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetRotAxis", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MGetRotAxis(VECTOR RotateAxis, float Rotate);
		public static MATRIX MGetRotAxis(VECTOR RotateAxis, float Rotate) => dx_MGetRotAxis(RotateAxis, Rotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetRotAxisD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MGetRotAxisD(VECTOR_D RotateAxis, double Rotate);
		public static MATRIX_D MGetRotAxisD(VECTOR_D RotateAxis, double Rotate) => dx_MGetRotAxisD(RotateAxis, Rotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetRotVec2", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MGetRotVec2(VECTOR In1, VECTOR In2);
		public static MATRIX MGetRotVec2(VECTOR In1, VECTOR In2) => dx_MGetRotVec2(In1, In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetRotVec2D", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MGetRotVec2D(VECTOR_D In1, VECTOR_D In2);
		public static MATRIX_D MGetRotVec2D(VECTOR_D In1, VECTOR_D In2) => dx_MGetRotVec2D(In1, In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetTranslate", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MGetTranslate(VECTOR Trans);
		public static MATRIX MGetTranslate(VECTOR Trans) => dx_MGetTranslate(Trans);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetTranslateD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MGetTranslateD(VECTOR_D Trans);
		public static MATRIX_D MGetTranslateD(VECTOR_D Trans) => dx_MGetTranslateD(Trans);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetAxis1", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MGetAxis1(VECTOR XAxis, VECTOR YAxis, VECTOR ZAxis, VECTOR Pos);
		public static MATRIX MGetAxis1(VECTOR XAxis, VECTOR YAxis, VECTOR ZAxis, VECTOR Pos) => dx_MGetAxis1(XAxis, YAxis, ZAxis, Pos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetAxis1D", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MGetAxis1D(VECTOR_D XAxis, VECTOR_D YAxis, VECTOR_D ZAxis, VECTOR_D Pos);
		public static MATRIX_D MGetAxis1D(VECTOR_D XAxis, VECTOR_D YAxis, VECTOR_D ZAxis, VECTOR_D Pos) => dx_MGetAxis1D(XAxis, YAxis, ZAxis, Pos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetAxis2", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MGetAxis2(VECTOR XAxis, VECTOR YAxis, VECTOR ZAxis, VECTOR Pos);
		public static MATRIX MGetAxis2(VECTOR XAxis, VECTOR YAxis, VECTOR ZAxis, VECTOR Pos) => dx_MGetAxis2(XAxis, YAxis, ZAxis, Pos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetAxis2D", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MGetAxis2D(VECTOR_D XAxis, VECTOR_D YAxis, VECTOR_D ZAxis, VECTOR_D Pos);
		public static MATRIX_D MGetAxis2D(VECTOR_D XAxis, VECTOR_D YAxis, VECTOR_D ZAxis, VECTOR_D Pos) => dx_MGetAxis2D(XAxis, YAxis, ZAxis, Pos);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MTranspose", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MTranspose(MATRIX InM);
		public static MATRIX MTranspose(MATRIX InM) => dx_MTranspose(InM);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MTransposeD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MTransposeD(MATRIX_D InM);
		public static MATRIX_D MTransposeD(MATRIX_D InM) => dx_MTransposeD(InM);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MInverse", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MInverse(MATRIX InM);
		public static MATRIX MInverse(MATRIX InM) => dx_MInverse(InM);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MInverseD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MInverseD(MATRIX_D InM);
		public static MATRIX_D MInverseD(MATRIX_D InM) => dx_MInverseD(InM);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetSize", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MGetSize(MATRIX InM);
		public static VECTOR MGetSize(MATRIX InM) => dx_MGetSize(InM);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetSizeD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_MGetSizeD(MATRIX_D InM);
		public static VECTOR_D MGetSizeD(MATRIX_D InM) => dx_MGetSizeD(InM);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetRotElem", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MGetRotElem(MATRIX InM);
		public static MATRIX MGetRotElem(MATRIX InM) => dx_MGetRotElem(InM);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MGetRotElemD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MGetRotElemD(MATRIX_D InM);
		public static MATRIX_D MGetRotElemD(MATRIX_D InM) => dx_MGetRotElemD(InM);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VNorm", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_VNorm(VECTOR In);
		public static VECTOR VNorm(VECTOR In) => dx_VNorm(In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VNormD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_VNormD(VECTOR_D In);
		public static VECTOR_D VNormD(VECTOR_D In) => dx_VNormD(In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VSize", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_VSize(VECTOR In);
		public static float VSize(VECTOR In) => dx_VSize(In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VSizeD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_VSizeD(VECTOR_D In);
		public static double VSizeD(VECTOR_D In) => dx_VSizeD(In);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VCos", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_VCos(VECTOR In1, VECTOR In2);
		public static float VCos(VECTOR In1, VECTOR In2) => dx_VCos(In1, In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VCosD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_VCosD(VECTOR_D In1, VECTOR_D In2);
		public static double VCosD(VECTOR_D In1, VECTOR_D In2) => dx_VCosD(In1, In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VRad", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_VRad(VECTOR In1, VECTOR In2);
		public static float VRad(VECTOR In1, VECTOR In2) => dx_VRad(In1, In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VRadD", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_VRadD(VECTOR_D In1, VECTOR_D In2);
		public static double VRadD(VECTOR_D In1, VECTOR_D In2) => dx_VRadD(In1, In2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_QTRot", CallingConvention=CallingConvention.StdCall)]
		extern static FLOAT4 dx_QTRot(VECTOR Axis, float Angle);
		public static FLOAT4 QTRot(VECTOR Axis, float Angle) => dx_QTRot(Axis, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_QTRotD", CallingConvention=CallingConvention.StdCall)]
		extern static DOUBLE4 dx_QTRotD(VECTOR_D Axis, double Angle);
		public static DOUBLE4 QTRotD(VECTOR_D Axis, double Angle) => dx_QTRotD(Axis, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VRotQ", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_VRotQ(VECTOR P, VECTOR Axis, float Angle);
		public static VECTOR VRotQ(VECTOR P, VECTOR Axis, float Angle) => dx_VRotQ(P, Axis, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_VRotQD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_VRotQD(VECTOR_D P, VECTOR_D Axis, double Angle);
		public static VECTOR_D VRotQD(VECTOR_D P, VECTOR_D Axis, double Angle) => dx_VRotQD(P, Axis, Angle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetImageSize_File", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetImageSize_File(string FileName, out int SizeX, out int SizeY);
		public static int GetImageSize_File(string FileName, out int SizeX, out int SizeY) => dx_GetImageSize_File(FileName, out SizeX, out SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetImageSize_FileWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetImageSize_FileWithStrLen(string FileName, ulong FileNameLength, out int SizeX, out int SizeY);
		public static int GetImageSize_FileWithStrLen(string FileName, ulong FileNameLength, out int SizeX, out int SizeY) => dx_GetImageSize_FileWithStrLen(FileName, FileNameLength, out SizeX, out SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetImageSize_Mem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetImageSize_Mem(System.IntPtr FileImage, int FileImageSize, out int SizeX, out int SizeY);
		public static int GetImageSize_Mem(System.IntPtr FileImage, int FileImageSize, out int SizeX, out int SizeY) => dx_GetImageSize_Mem(FileImage, FileImageSize, out SizeX, out SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseFastLoadFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseFastLoadFlag(int Flag);
		public static int SetUseFastLoadFlag(int Flag) => dx_SetUseFastLoadFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetGraphDataShavedMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetGraphDataShavedMode(int ShavedMode);
		public static int SetGraphDataShavedMode(int ShavedMode) => dx_SetGraphDataShavedMode(ShavedMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphDataShavedMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetGraphDataShavedMode();
		public static int GetGraphDataShavedMode() => dx_GetGraphDataShavedMode();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUsePremulAlphaConvertLoad", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUsePremulAlphaConvertLoad(int UseFlag);
		public static int SetUsePremulAlphaConvertLoad(int UseFlag) => dx_SetUsePremulAlphaConvertLoad(UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReadJpegExif", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReadJpegExif(string JpegFilePath, [In, Out] byte[] ExifBuffer_Array, ulong ExifBufferSize);
		public static int ReadJpegExif(string JpegFilePath, [In, Out] byte[] ExifBuffer_Array, ulong ExifBufferSize) => dx_ReadJpegExif(JpegFilePath, ExifBuffer_Array, ExifBufferSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReadJpegExifWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReadJpegExifWithStrLen(string JpegFilePath, ulong JpegFilePathLength, [In, Out] byte[] ExifBuffer_Array, ulong ExifBufferSize);
		public static int ReadJpegExifWithStrLen(string JpegFilePath, ulong JpegFilePathLength, [In, Out] byte[] ExifBuffer_Array, ulong ExifBufferSize) => dx_ReadJpegExifWithStrLen(JpegFilePath, JpegFilePathLength, ExifBuffer_Array, ExifBufferSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetColorF", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_GetColorF(float Red, float Green, float Blue, float Alpha);
		public static COLOR_F GetColorF(float Red, float Green, float Blue, float Alpha) => dx_GetColorF(Red, Green, Blue, Alpha);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetColorU8", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_U8 dx_GetColorU8(int Red, int Green, int Blue, int Alpha);
		public static COLOR_U8 GetColorU8(int Red, int Green, int Blue, int Alpha) => dx_GetColorU8(Red, Green, Blue, Alpha);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetColor", CallingConvention=CallingConvention.StdCall)]
		extern static uint dx_GetColor(int Red, int Green, int Blue);
		public static uint GetColor(int Red, int Green, int Blue) => dx_GetColor(Red, Green, Blue);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetColor2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetColor2(uint Color, out int Red, out int Green, out int Blue);
		public static int GetColor2(uint Color, out int Red, out int Green, out int Blue) => dx_GetColor2(Color, out Red, out Green, out Blue);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetColor3", CallingConvention=CallingConvention.StdCall)]
		extern static uint dx_GetColor3(uint ColorData, int Red, int Green, int Blue, int Alpha);
		public static uint GetColor3(uint ColorData, int Red, int Green, int Blue, int Alpha = 255) => dx_GetColor3(ColorData, Red, Green, Blue, Alpha);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetColor4", CallingConvention=CallingConvention.StdCall)]
		extern static uint dx_GetColor4(uint DestColorData, uint SrcColorData, uint SrcColor);
		public static uint GetColor4(uint DestColorData, uint SrcColorData, uint SrcColor) => dx_GetColor4(DestColorData, SrcColorData, SrcColor);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetColor5", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetColor5(uint ColorData, uint Color, out int Red, out int Green, out int Blue, out int Alpha);
		public static int GetColor5(uint ColorData, uint Color, out int Red, out int Green, out int Blue, out int Alpha) => dx_GetColor5(ColorData, Color, out Red, out Green, out Blue, out Alpha);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreatePaletteColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreatePaletteColorData(out COLORDATA ColorDataBuf);
		public static int CreatePaletteColorData(out COLORDATA ColorDataBuf) => dx_CreatePaletteColorData(out ColorDataBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateARGBF32ColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateARGBF32ColorData(out COLORDATA ColorDataBuf);
		public static int CreateARGBF32ColorData(out COLORDATA ColorDataBuf) => dx_CreateARGBF32ColorData(out ColorDataBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateARGBF16ColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateARGBF16ColorData(out COLORDATA ColorDataBuf);
		public static int CreateARGBF16ColorData(out COLORDATA ColorDataBuf) => dx_CreateARGBF16ColorData(out ColorDataBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateXRGB8ColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateXRGB8ColorData(out COLORDATA ColorDataBuf);
		public static int CreateXRGB8ColorData(out COLORDATA ColorDataBuf) => dx_CreateXRGB8ColorData(out ColorDataBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateARGB8ColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateARGB8ColorData(out COLORDATA ColorDataBuf);
		public static int CreateARGB8ColorData(out COLORDATA ColorDataBuf) => dx_CreateARGB8ColorData(out ColorDataBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateARGB4ColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateARGB4ColorData(out COLORDATA ColorDataBuf);
		public static int CreateARGB4ColorData(out COLORDATA ColorDataBuf) => dx_CreateARGB4ColorData(out ColorDataBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateA1R5G5B5ColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateA1R5G5B5ColorData(out COLORDATA ColorDataBuf);
		public static int CreateA1R5G5B5ColorData(out COLORDATA ColorDataBuf) => dx_CreateA1R5G5B5ColorData(out ColorDataBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateX1R5G5B5ColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateX1R5G5B5ColorData(out COLORDATA ColorDataBuf);
		public static int CreateX1R5G5B5ColorData(out COLORDATA ColorDataBuf) => dx_CreateX1R5G5B5ColorData(out ColorDataBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateR5G5B5A1ColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateR5G5B5A1ColorData(out COLORDATA ColorDataBuf);
		public static int CreateR5G5B5A1ColorData(out COLORDATA ColorDataBuf) => dx_CreateR5G5B5A1ColorData(out ColorDataBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateR5G6B5ColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateR5G6B5ColorData(out COLORDATA ColorDataBuf);
		public static int CreateR5G6B5ColorData(out COLORDATA ColorDataBuf) => dx_CreateR5G6B5ColorData(out ColorDataBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateFullColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateFullColorData(out COLORDATA ColorDataBuf);
		public static int CreateFullColorData(out COLORDATA ColorDataBuf) => dx_CreateFullColorData(out ColorDataBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateGrayColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateGrayColorData(out COLORDATA ColorDataBuf);
		public static int CreateGrayColorData(out COLORDATA ColorDataBuf) => dx_CreateGrayColorData(out ColorDataBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreatePal8ColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreatePal8ColorData(out COLORDATA ColorDataBuf, int UseAlpha);
		public static int CreatePal8ColorData(out COLORDATA ColorDataBuf, int UseAlpha = FALSE) => dx_CreatePal8ColorData(out ColorDataBuf, UseAlpha);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateColorData();
		public static int CreateColorData() => dx_CreateColorData();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetColorDataNoneMask", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_SetColorDataNoneMask(out COLORDATA ColorData);
		public static void SetColorDataNoneMask(out COLORDATA ColorData) => dx_SetColorDataNoneMask(out ColorData);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CmpColorData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CmpColorData(uint ColorData1, uint ColorData2);
		public static int CmpColorData(uint ColorData1, uint ColorData2) => dx_CmpColorData(ColorData1, ColorData2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitSoftImage();
		public static int InitSoftImage() => dx_InitSoftImage();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoftImage(string FileName);
		public static int LoadSoftImage(string FileName) => dx_LoadSoftImage(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoftImageWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoftImageWithStrLen(string FileName, ulong FileNameLength);
		public static int LoadSoftImageWithStrLen(string FileName, ulong FileNameLength) => dx_LoadSoftImageWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadARGB8ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadARGB8ColorSoftImage(string FileName);
		public static int LoadARGB8ColorSoftImage(string FileName) => dx_LoadARGB8ColorSoftImage(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadARGB8ColorSoftImageWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadARGB8ColorSoftImageWithStrLen(string FileName, ulong FileNameLength);
		public static int LoadARGB8ColorSoftImageWithStrLen(string FileName, ulong FileNameLength) => dx_LoadARGB8ColorSoftImageWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadXRGB8ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadXRGB8ColorSoftImage(string FileName);
		public static int LoadXRGB8ColorSoftImage(string FileName) => dx_LoadXRGB8ColorSoftImage(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadXRGB8ColorSoftImageWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadXRGB8ColorSoftImageWithStrLen(string FileName, ulong FileNameLength);
		public static int LoadXRGB8ColorSoftImageWithStrLen(string FileName, ulong FileNameLength) => dx_LoadXRGB8ColorSoftImageWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoftImageToMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoftImageToMem(System.IntPtr FileImage, int FileImageSize);
		public static int LoadSoftImageToMem(System.IntPtr FileImage, int FileImageSize) => dx_LoadSoftImageToMem(FileImage, FileImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadARGB8ColorSoftImageToMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadARGB8ColorSoftImageToMem(System.IntPtr FileImage, int FileImageSize);
		public static int LoadARGB8ColorSoftImageToMem(System.IntPtr FileImage, int FileImageSize) => dx_LoadARGB8ColorSoftImageToMem(FileImage, FileImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadXRGB8ColorSoftImageToMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadXRGB8ColorSoftImageToMem(System.IntPtr FileImage, int FileImageSize);
		public static int LoadXRGB8ColorSoftImageToMem(System.IntPtr FileImage, int FileImageSize) => dx_LoadXRGB8ColorSoftImageToMem(FileImage, FileImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftImage(int SizeX, int SizeY);
		public static int MakeSoftImage(int SizeX, int SizeY) => dx_MakeSoftImage(SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeARGBF32ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeARGBF32ColorSoftImage(int SizeX, int SizeY);
		public static int MakeARGBF32ColorSoftImage(int SizeX, int SizeY) => dx_MakeARGBF32ColorSoftImage(SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeARGBF16ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeARGBF16ColorSoftImage(int SizeX, int SizeY);
		public static int MakeARGBF16ColorSoftImage(int SizeX, int SizeY) => dx_MakeARGBF16ColorSoftImage(SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeARGB8ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeARGB8ColorSoftImage(int SizeX, int SizeY);
		public static int MakeARGB8ColorSoftImage(int SizeX, int SizeY) => dx_MakeARGB8ColorSoftImage(SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeXRGB8ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeXRGB8ColorSoftImage(int SizeX, int SizeY);
		public static int MakeXRGB8ColorSoftImage(int SizeX, int SizeY) => dx_MakeXRGB8ColorSoftImage(SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeARGB4ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeARGB4ColorSoftImage(int SizeX, int SizeY);
		public static int MakeARGB4ColorSoftImage(int SizeX, int SizeY) => dx_MakeARGB4ColorSoftImage(SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeA1R5G5B5ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeA1R5G5B5ColorSoftImage(int SizeX, int SizeY);
		public static int MakeA1R5G5B5ColorSoftImage(int SizeX, int SizeY) => dx_MakeA1R5G5B5ColorSoftImage(SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeX1R5G5B5ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeX1R5G5B5ColorSoftImage(int SizeX, int SizeY);
		public static int MakeX1R5G5B5ColorSoftImage(int SizeX, int SizeY) => dx_MakeX1R5G5B5ColorSoftImage(SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeR5G5B5A1ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeR5G5B5A1ColorSoftImage(int SizeX, int SizeY);
		public static int MakeR5G5B5A1ColorSoftImage(int SizeX, int SizeY) => dx_MakeR5G5B5A1ColorSoftImage(SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeR5G6B5ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeR5G6B5ColorSoftImage(int SizeX, int SizeY);
		public static int MakeR5G6B5ColorSoftImage(int SizeX, int SizeY) => dx_MakeR5G6B5ColorSoftImage(SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeRGB8ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeRGB8ColorSoftImage(int SizeX, int SizeY);
		public static int MakeRGB8ColorSoftImage(int SizeX, int SizeY) => dx_MakeRGB8ColorSoftImage(SizeX, SizeY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakePAL8ColorSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakePAL8ColorSoftImage(int SizeX, int SizeY, int UseAlpha);
		public static int MakePAL8ColorSoftImage(int SizeX, int SizeY, int UseAlpha = FALSE) => dx_MakePAL8ColorSoftImage(SizeX, SizeY, UseAlpha);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteSoftImage(int SIHandle);
		public static int DeleteSoftImage(int SIHandle) => dx_DeleteSoftImage(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetSoftImageSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetSoftImageSize(int SIHandle, out int Width, out int Height);
		public static int GetSoftImageSize(int SIHandle, out int Width, out int Height) => dx_GetSoftImageSize(SIHandle, out Width, out Height);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckPaletteSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckPaletteSoftImage(int SIHandle);
		public static int CheckPaletteSoftImage(int SIHandle) => dx_CheckPaletteSoftImage(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckAlphaSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckAlphaSoftImage(int SIHandle);
		public static int CheckAlphaSoftImage(int SIHandle) => dx_CheckAlphaSoftImage(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckPixelAlphaSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckPixelAlphaSoftImage(int SIHandle);
		public static int CheckPixelAlphaSoftImage(int SIHandle) => dx_CheckPixelAlphaSoftImage(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawScreenSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawScreenSoftImage(int x1, int y1, int x2, int y2, int SIHandle);
		public static int GetDrawScreenSoftImage(int x1, int y1, int x2, int y2, int SIHandle) => dx_GetDrawScreenSoftImage(x1, y1, x2, y2, SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDrawScreenSoftImageDestPos", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDrawScreenSoftImageDestPos(int x1, int y1, int x2, int y2, int SIHandle, int DestX, int DestY);
		public static int GetDrawScreenSoftImageDestPos(int x1, int y1, int x2, int y2, int SIHandle, int DestX, int DestY) => dx_GetDrawScreenSoftImageDestPos(x1, y1, x2, y2, SIHandle, DestX, DestY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_FillSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_FillSoftImage(int SIHandle, int r, int g, int b, int a);
		public static int FillSoftImage(int SIHandle, int r, int g, int b, int a) => dx_FillSoftImage(SIHandle, r, g, b, a);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ClearRectSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ClearRectSoftImage(int SIHandle, int x, int y, int w, int h);
		public static int ClearRectSoftImage(int SIHandle, int x, int y, int w, int h) => dx_ClearRectSoftImage(SIHandle, x, y, w, h);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPaletteSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPaletteSoftImage(int SIHandle, int PaletteNo, out int r, out int g, out int b, out int a);
		public static int GetPaletteSoftImage(int SIHandle, int PaletteNo, out int r, out int g, out int b, out int a) => dx_GetPaletteSoftImage(SIHandle, PaletteNo, out r, out g, out b, out a);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPaletteSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPaletteSoftImage(int SIHandle, int PaletteNo, int r, int g, int b, int a);
		public static int SetPaletteSoftImage(int SIHandle, int PaletteNo, int r, int g, int b, int a) => dx_SetPaletteSoftImage(SIHandle, PaletteNo, r, g, b, a);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPixelPalCodeSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPixelPalCodeSoftImage(int SIHandle, int x, int y, int palNo);
		public static int DrawPixelPalCodeSoftImage(int SIHandle, int x, int y, int palNo) => dx_DrawPixelPalCodeSoftImage(SIHandle, x, y, palNo);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPixelPalCodeSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPixelPalCodeSoftImage(int SIHandle, int x, int y);
		public static int GetPixelPalCodeSoftImage(int SIHandle, int x, int y) => dx_GetPixelPalCodeSoftImage(SIHandle, x, y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetImageAddressSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetImageAddressSoftImage(int SIHandle);
		public static System.IntPtr GetImageAddressSoftImage(int SIHandle) => dx_GetImageAddressSoftImage(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPitchSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPitchSoftImage(int SIHandle);
		public static int GetPitchSoftImage(int SIHandle) => dx_GetPitchSoftImage(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPixelSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPixelSoftImage(int SIHandle, int x, int y, int r, int g, int b, int a);
		public static int DrawPixelSoftImage(int SIHandle, int x, int y, int r, int g, int b, int a) => dx_DrawPixelSoftImage(SIHandle, x, y, r, g, b, a);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPixelSoftImageF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawPixelSoftImageF(int SIHandle, int x, int y, float r, float g, float b, float a);
		public static int DrawPixelSoftImageF(int SIHandle, int x, int y, float r, float g, float b, float a) => dx_DrawPixelSoftImageF(SIHandle, x, y, r, g, b, a);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPixelSoftImage_Unsafe_XRGB8", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_DrawPixelSoftImage_Unsafe_XRGB8(int SIHandle, int x, int y, int r, int g, int b);
		public static void DrawPixelSoftImage_Unsafe_XRGB8(int SIHandle, int x, int y, int r, int g, int b) => dx_DrawPixelSoftImage_Unsafe_XRGB8(SIHandle, x, y, r, g, b);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawPixelSoftImage_Unsafe_ARGB8", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_DrawPixelSoftImage_Unsafe_ARGB8(int SIHandle, int x, int y, int r, int g, int b, int a);
		public static void DrawPixelSoftImage_Unsafe_ARGB8(int SIHandle, int x, int y, int r, int g, int b, int a) => dx_DrawPixelSoftImage_Unsafe_ARGB8(SIHandle, x, y, r, g, b, a);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPixelSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPixelSoftImage(int SIHandle, int x, int y, out int r, out int g, out int b, out int a);
		public static int GetPixelSoftImage(int SIHandle, int x, int y, out int r, out int g, out int b, out int a) => dx_GetPixelSoftImage(SIHandle, x, y, out r, out g, out b, out a);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPixelSoftImageF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPixelSoftImageF(int SIHandle, int x, int y, out float r, out float g, out float b, out float a);
		public static int GetPixelSoftImageF(int SIHandle, int x, int y, out float r, out float g, out float b, out float a) => dx_GetPixelSoftImageF(SIHandle, x, y, out r, out g, out b, out a);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPixelSoftImage_Unsafe_XRGB8", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_GetPixelSoftImage_Unsafe_XRGB8(int SIHandle, int x, int y, out int r, out int g, out int b);
		public static void GetPixelSoftImage_Unsafe_XRGB8(int SIHandle, int x, int y, out int r, out int g, out int b) => dx_GetPixelSoftImage_Unsafe_XRGB8(SIHandle, x, y, out r, out g, out b);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPixelSoftImage_Unsafe_ARGB8", CallingConvention=CallingConvention.StdCall)]
		extern static void dx_GetPixelSoftImage_Unsafe_ARGB8(int SIHandle, int x, int y, out int r, out int g, out int b, out int a);
		public static void GetPixelSoftImage_Unsafe_ARGB8(int SIHandle, int x, int y, out int r, out int g, out int b, out int a) => dx_GetPixelSoftImage_Unsafe_ARGB8(SIHandle, x, y, out r, out g, out b, out a);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawLineSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawLineSoftImage(int SIHandle, int x1, int y1, int x2, int y2, int r, int g, int b, int a);
		public static int DrawLineSoftImage(int SIHandle, int x1, int y1, int x2, int y2, int r, int g, int b, int a) => dx_DrawLineSoftImage(SIHandle, x1, y1, x2, y2, r, g, b, a);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawCircleSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawCircleSoftImage(int SIHandle, int x, int y, int radius, int r, int g, int b, int a, int FillFlag);
		public static int DrawCircleSoftImage(int SIHandle, int x, int y, int radius, int r, int g, int b, int a, int FillFlag = TRUE) => dx_DrawCircleSoftImage(SIHandle, x, y, radius, r, g, b, a, FillFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_BltSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_BltSoftImage(int SrcX, int SrcY, int SrcSizeX, int SrcSizeY, int SrcSIHandle, int DestX, int DestY, int DestSIHandle);
		public static int BltSoftImage(int SrcX, int SrcY, int SrcSizeX, int SrcSizeY, int SrcSIHandle, int DestX, int DestY, int DestSIHandle) => dx_BltSoftImage(SrcX, SrcY, SrcSizeX, SrcSizeY, SrcSIHandle, DestX, DestY, DestSIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_BltSoftImageWithTransColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_BltSoftImageWithTransColor(int SrcX, int SrcY, int SrcSizeX, int SrcSizeY, int SrcSIHandle, int DestX, int DestY, int DestSIHandle, int Tr, int Tg, int Tb, int Ta);
		public static int BltSoftImageWithTransColor(int SrcX, int SrcY, int SrcSizeX, int SrcSizeY, int SrcSIHandle, int DestX, int DestY, int DestSIHandle, int Tr, int Tg, int Tb, int Ta) => dx_BltSoftImageWithTransColor(SrcX, SrcY, SrcSizeX, SrcSizeY, SrcSIHandle, DestX, DestY, DestSIHandle, Tr, Tg, Tb, Ta);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_BltSoftImageWithAlphaBlend", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_BltSoftImageWithAlphaBlend(int SrcX, int SrcY, int SrcSizeX, int SrcSizeY, int SrcSIHandle, int DestX, int DestY, int DestSIHandle, int Opacity);
		public static int BltSoftImageWithAlphaBlend(int SrcX, int SrcY, int SrcSizeX, int SrcSizeY, int SrcSIHandle, int DestX, int DestY, int DestSIHandle, int Opacity = 255) => dx_BltSoftImageWithAlphaBlend(SrcX, SrcY, SrcSizeX, SrcSizeY, SrcSIHandle, DestX, DestY, DestSIHandle, Opacity);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReverseSoftImageH", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReverseSoftImageH(int SIHandle);
		public static int ReverseSoftImageH(int SIHandle) => dx_ReverseSoftImageH(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReverseSoftImageV", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReverseSoftImageV(int SIHandle);
		public static int ReverseSoftImageV(int SIHandle) => dx_ReverseSoftImageV(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReverseSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReverseSoftImage(int SIHandle);
		public static int ReverseSoftImage(int SIHandle) => dx_ReverseSoftImage(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_BltStringSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_BltStringSoftImage(int x, int y, string StrData, int DestSIHandle, int DestEdgeSIHandle, int VerticalFlag);
		public static int BltStringSoftImage(int x, int y, string StrData, int DestSIHandle, int DestEdgeSIHandle = -1, int VerticalFlag = FALSE) => dx_BltStringSoftImage(x, y, StrData, DestSIHandle, DestEdgeSIHandle, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_BltStringSoftImageWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_BltStringSoftImageWithStrLen(int x, int y, string StrData, ulong StrDataLength, int DestSIHandle, int DestEdgeSIHandle, int VerticalFlag);
		public static int BltStringSoftImageWithStrLen(int x, int y, string StrData, ulong StrDataLength, int DestSIHandle, int DestEdgeSIHandle = -1, int VerticalFlag = FALSE) => dx_BltStringSoftImageWithStrLen(x, y, StrData, StrDataLength, DestSIHandle, DestEdgeSIHandle, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_BltStringSoftImageToHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_BltStringSoftImageToHandle(int x, int y, string StrData, int DestSIHandle, int DestEdgeSIHandle, int FontHandle, int VerticalFlag);
		public static int BltStringSoftImageToHandle(int x, int y, string StrData, int DestSIHandle, int DestEdgeSIHandle, int FontHandle, int VerticalFlag = FALSE) => dx_BltStringSoftImageToHandle(x, y, StrData, DestSIHandle, DestEdgeSIHandle, FontHandle, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_BltStringSoftImageToHandleWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_BltStringSoftImageToHandleWithStrLen(int x, int y, string StrData, ulong StrDataLength, int DestSIHandle, int DestEdgeSIHandle, int FontHandle, int VerticalFlag);
		public static int BltStringSoftImageToHandleWithStrLen(int x, int y, string StrData, ulong StrDataLength, int DestSIHandle, int DestEdgeSIHandle, int FontHandle, int VerticalFlag = FALSE) => dx_BltStringSoftImageToHandleWithStrLen(x, y, StrData, StrDataLength, DestSIHandle, DestEdgeSIHandle, FontHandle, VerticalFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DrawSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DrawSoftImage(int x, int y, int SIHandle);
		public static int DrawSoftImage(int x, int y, int SIHandle) => dx_DrawSoftImage(x, y, SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveSoftImageToBmp", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveSoftImageToBmp(string FilePath, int SIHandle);
		public static int SaveSoftImageToBmp(string FilePath, int SIHandle) => dx_SaveSoftImageToBmp(FilePath, SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveSoftImageToBmpWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveSoftImageToBmpWithStrLen(string FilePath, ulong FilePathLength, int SIHandle);
		public static int SaveSoftImageToBmpWithStrLen(string FilePath, ulong FilePathLength, int SIHandle) => dx_SaveSoftImageToBmpWithStrLen(FilePath, FilePathLength, SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveSoftImageToDds", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveSoftImageToDds(string FilePath, int SIHandle);
		public static int SaveSoftImageToDds(string FilePath, int SIHandle) => dx_SaveSoftImageToDds(FilePath, SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveSoftImageToDdsWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveSoftImageToDdsWithStrLen(string FilePath, ulong FilePathLength, int SIHandle);
		public static int SaveSoftImageToDdsWithStrLen(string FilePath, ulong FilePathLength, int SIHandle) => dx_SaveSoftImageToDdsWithStrLen(FilePath, FilePathLength, SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveSoftImageToPng", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveSoftImageToPng(string FilePath, int SIHandle, int CompressionLevel);
		public static int SaveSoftImageToPng(string FilePath, int SIHandle, int CompressionLevel) => dx_SaveSoftImageToPng(FilePath, SIHandle, CompressionLevel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveSoftImageToPngWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveSoftImageToPngWithStrLen(string FilePath, ulong FilePathLength, int SIHandle, int CompressionLevel);
		public static int SaveSoftImageToPngWithStrLen(string FilePath, ulong FilePathLength, int SIHandle, int CompressionLevel) => dx_SaveSoftImageToPngWithStrLen(FilePath, FilePathLength, SIHandle, CompressionLevel);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveSoftImageToJpeg", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveSoftImageToJpeg(string FilePath, int SIHandle, int Quality, int Sample2x1);
		public static int SaveSoftImageToJpeg(string FilePath, int SIHandle, int Quality, int Sample2x1) => dx_SaveSoftImageToJpeg(FilePath, SIHandle, Quality, Sample2x1);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveSoftImageToJpegWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveSoftImageToJpegWithStrLen(string FilePath, ulong FilePathLength, int SIHandle, int Quality, int Sample2x1);
		public static int SaveSoftImageToJpegWithStrLen(string FilePath, ulong FilePathLength, int SIHandle, int Quality, int Sample2x1) => dx_SaveSoftImageToJpegWithStrLen(FilePath, FilePathLength, SIHandle, Quality, Sample2x1);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitSoundMem(int LogOutFlag);
		public static int InitSoundMem(int LogOutFlag = FALSE) => dx_InitSoundMem(LogOutFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddSoundData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddSoundData(int Handle);
		public static int AddSoundData(int Handle = -1) => dx_AddSoundData(Handle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddStreamSoundMemToMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddStreamSoundMemToMem(System.IntPtr FileImage, ulong FileImageSize, int LoopNum, int SoundHandle, int StreamDataType, int UnionHandle);
		public static int AddStreamSoundMemToMem(System.IntPtr FileImage, ulong FileImageSize, int LoopNum, int SoundHandle, int StreamDataType, int UnionHandle = -1) => dx_AddStreamSoundMemToMem(FileImage, FileImageSize, LoopNum, SoundHandle, StreamDataType, UnionHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddStreamSoundMemToFile", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddStreamSoundMemToFile(string WaveFile, int LoopNum, int SoundHandle, int StreamDataType, int UnionHandle);
		public static int AddStreamSoundMemToFile(string WaveFile, int LoopNum, int SoundHandle, int StreamDataType, int UnionHandle = -1) => dx_AddStreamSoundMemToFile(WaveFile, LoopNum, SoundHandle, StreamDataType, UnionHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddStreamSoundMemToFileWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddStreamSoundMemToFileWithStrLen(string WaveFile, ulong WaveFilePathLength, int LoopNum, int SoundHandle, int StreamDataType, int UnionHandle);
		public static int AddStreamSoundMemToFileWithStrLen(string WaveFile, ulong WaveFilePathLength, int LoopNum, int SoundHandle, int StreamDataType, int UnionHandle = -1) => dx_AddStreamSoundMemToFileWithStrLen(WaveFile, WaveFilePathLength, LoopNum, SoundHandle, StreamDataType, UnionHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetupStreamSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetupStreamSoundMem(int SoundHandle);
		public static int SetupStreamSoundMem(int SoundHandle) => dx_SetupStreamSoundMem(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlayStreamSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlayStreamSoundMem(int SoundHandle, int PlayType, int TopPositionFlag);
		public static int PlayStreamSoundMem(int SoundHandle, int PlayType = DX_PLAYTYPE_LOOP, int TopPositionFlag = TRUE) => dx_PlayStreamSoundMem(SoundHandle, PlayType, TopPositionFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckStreamSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckStreamSoundMem(int SoundHandle);
		public static int CheckStreamSoundMem(int SoundHandle) => dx_CheckStreamSoundMem(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_StopStreamSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_StopStreamSoundMem(int SoundHandle);
		public static int StopStreamSoundMem(int SoundHandle) => dx_StopStreamSoundMem(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetStreamSoundCurrentPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetStreamSoundCurrentPosition(long Byte, int SoundHandle);
		public static int SetStreamSoundCurrentPosition(long Byte, int SoundHandle) => dx_SetStreamSoundCurrentPosition(Byte, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetStreamSoundCurrentPosition", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_GetStreamSoundCurrentPosition(int SoundHandle);
		public static long GetStreamSoundCurrentPosition(int SoundHandle) => dx_GetStreamSoundCurrentPosition(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetStreamSoundCurrentTime", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetStreamSoundCurrentTime(long Time, int SoundHandle);
		public static int SetStreamSoundCurrentTime(long Time, int SoundHandle) => dx_SetStreamSoundCurrentTime(Time, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetStreamSoundCurrentTime", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_GetStreamSoundCurrentTime(int SoundHandle);
		public static long GetStreamSoundCurrentTime(int SoundHandle) => dx_GetStreamSoundCurrentTime(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ProcessStreamSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ProcessStreamSoundMem(int SoundHandle);
		public static int ProcessStreamSoundMem(int SoundHandle) => dx_ProcessStreamSoundMem(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ProcessStreamSoundMemAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ProcessStreamSoundMemAll();
		public static int ProcessStreamSoundMemAll() => dx_ProcessStreamSoundMemAll();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMem2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMem2(string FileName1, string FileName2);
		public static int LoadSoundMem2(string FileName1, string FileName2) => dx_LoadSoundMem2(FileName1, FileName2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMem2WithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMem2WithStrLen(string FileName1, ulong FileName1Length, string FileName2, ulong FileName2Length);
		public static int LoadSoundMem2WithStrLen(string FileName1, ulong FileName1Length, string FileName2, ulong FileName2Length) => dx_LoadSoundMem2WithStrLen(FileName1, FileName1Length, FileName2, FileName2Length);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadBGM", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadBGM(string FileName);
		public static int LoadBGM(string FileName) => dx_LoadBGM(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadBGMWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadBGMWithStrLen(string FileName, ulong FileNameLength);
		public static int LoadBGMWithStrLen(string FileName, ulong FileNameLength) => dx_LoadBGMWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMemBase", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMemBase(string FileName, int BufferNum, int UnionHandle);
		public static int LoadSoundMemBase(string FileName, int BufferNum, int UnionHandle = -1) => dx_LoadSoundMemBase(FileName, BufferNum, UnionHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMemBaseWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMemBaseWithStrLen(string FileName, ulong FileNameLength, int BufferNum, int UnionHandle);
		public static int LoadSoundMemBaseWithStrLen(string FileName, ulong FileNameLength, int BufferNum, int UnionHandle = -1) => dx_LoadSoundMemBaseWithStrLen(FileName, FileNameLength, BufferNum, UnionHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMem(string FileName, int BufferNum, int UnionHandle);
		public static int LoadSoundMem(string FileName, int BufferNum = 3, int UnionHandle = -1) => dx_LoadSoundMem(FileName, BufferNum, UnionHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMemWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMemWithStrLen(string FileName, ulong FileNameLength, int BufferNum, int UnionHandle);
		public static int LoadSoundMemWithStrLen(string FileName, ulong FileNameLength, int BufferNum = 3, int UnionHandle = -1) => dx_LoadSoundMemWithStrLen(FileName, FileNameLength, BufferNum, UnionHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMemToBufNumSitei", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMemToBufNumSitei(string FileName, int BufferNum);
		public static int LoadSoundMemToBufNumSitei(string FileName, int BufferNum) => dx_LoadSoundMemToBufNumSitei(FileName, BufferNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMemToBufNumSiteiWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMemToBufNumSiteiWithStrLen(string FileName, ulong FileNameLength, int BufferNum);
		public static int LoadSoundMemToBufNumSiteiWithStrLen(string FileName, ulong FileNameLength, int BufferNum) => dx_LoadSoundMemToBufNumSiteiWithStrLen(FileName, FileNameLength, BufferNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DuplicateSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DuplicateSoundMem(int SrcSoundHandle, int BufferNum);
		public static int DuplicateSoundMem(int SrcSoundHandle, int BufferNum = 3) => dx_DuplicateSoundMem(SrcSoundHandle, BufferNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMemByMemImageBase", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMemByMemImageBase(System.IntPtr FileImage, ulong FileImageSize, int BufferNum, int UnionHandle);
		public static int LoadSoundMemByMemImageBase(System.IntPtr FileImage, ulong FileImageSize, int BufferNum, int UnionHandle = -1) => dx_LoadSoundMemByMemImageBase(FileImage, FileImageSize, BufferNum, UnionHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMemByMemImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMemByMemImage(System.IntPtr FileImage, ulong FileImageSize, int BufferNum, int UnionHandle);
		public static int LoadSoundMemByMemImage(System.IntPtr FileImage, ulong FileImageSize, int BufferNum = 3, int UnionHandle = -1) => dx_LoadSoundMemByMemImage(FileImage, FileImageSize, BufferNum, UnionHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMemByMemImageToBufNumSitei", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMemByMemImageToBufNumSitei(System.IntPtr FileImage, ulong FileImageSize, int BufferNum);
		public static int LoadSoundMemByMemImageToBufNumSitei(System.IntPtr FileImage, ulong FileImageSize, int BufferNum) => dx_LoadSoundMemByMemImageToBufNumSitei(FileImage, FileImageSize, BufferNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMem2ByMemImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMem2ByMemImage(System.IntPtr FileImage1, ulong FileImageSize1, System.IntPtr FileImage2, ulong FileImageSize2);
		public static int LoadSoundMem2ByMemImage(System.IntPtr FileImage1, ulong FileImageSize1, System.IntPtr FileImage2, ulong FileImageSize2) => dx_LoadSoundMem2ByMemImage(FileImage1, FileImageSize1, FileImage2, FileImageSize2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMemFromSoftSound", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMemFromSoftSound(int SoftSoundHandle, int BufferNum);
		public static int LoadSoundMemFromSoftSound(int SoftSoundHandle, int BufferNum = 3) => dx_LoadSoundMemFromSoftSound(SoftSoundHandle, BufferNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteSoundMem(int SoundHandle, int LogOutFlag);
		public static int DeleteSoundMem(int SoundHandle, int LogOutFlag = FALSE) => dx_DeleteSoundMem(SoundHandle, LogOutFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlaySoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlaySoundMem(int SoundHandle, int PlayType, int TopPositionFlag);
		public static int PlaySoundMem(int SoundHandle, int PlayType, int TopPositionFlag = TRUE) => dx_PlaySoundMem(SoundHandle, PlayType, TopPositionFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_StopSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_StopSoundMem(int SoundHandle);
		public static int StopSoundMem(int SoundHandle) => dx_StopSoundMem(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckSoundMem(int SoundHandle);
		public static int CheckSoundMem(int SoundHandle) => dx_CheckSoundMem(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPanSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPanSoundMem(int PanPal, int SoundHandle);
		public static int SetPanSoundMem(int PanPal, int SoundHandle) => dx_SetPanSoundMem(PanPal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangePanSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangePanSoundMem(int PanPal, int SoundHandle);
		public static int ChangePanSoundMem(int PanPal, int SoundHandle) => dx_ChangePanSoundMem(PanPal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPanSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPanSoundMem(int SoundHandle);
		public static int GetPanSoundMem(int SoundHandle) => dx_GetPanSoundMem(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVolumeSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVolumeSoundMem(int VolumePal, int SoundHandle);
		public static int SetVolumeSoundMem(int VolumePal, int SoundHandle) => dx_SetVolumeSoundMem(VolumePal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeVolumeSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeVolumeSoundMem(int VolumePal, int SoundHandle);
		public static int ChangeVolumeSoundMem(int VolumePal, int SoundHandle) => dx_ChangeVolumeSoundMem(VolumePal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetVolumeSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetVolumeSoundMem(int SoundHandle);
		public static int GetVolumeSoundMem(int SoundHandle) => dx_GetVolumeSoundMem(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetVolumeSoundMem2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetVolumeSoundMem2(int SoundHandle);
		public static int GetVolumeSoundMem2(int SoundHandle) => dx_GetVolumeSoundMem2(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetChannelVolumeSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetChannelVolumeSoundMem(int Channel, int VolumePal, int SoundHandle);
		public static int SetChannelVolumeSoundMem(int Channel, int VolumePal, int SoundHandle) => dx_SetChannelVolumeSoundMem(Channel, VolumePal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeChannelVolumeSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeChannelVolumeSoundMem(int Channel, int VolumePal, int SoundHandle);
		public static int ChangeChannelVolumeSoundMem(int Channel, int VolumePal, int SoundHandle) => dx_ChangeChannelVolumeSoundMem(Channel, VolumePal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetChannelVolumeSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetChannelVolumeSoundMem(int Channel, int SoundHandle);
		public static int GetChannelVolumeSoundMem(int Channel, int SoundHandle) => dx_GetChannelVolumeSoundMem(Channel, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetChannelVolumeSoundMem2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetChannelVolumeSoundMem2(int Channel, int SoundHandle);
		public static int GetChannelVolumeSoundMem2(int Channel, int SoundHandle) => dx_GetChannelVolumeSoundMem2(Channel, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetFrequencySoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetFrequencySoundMem(int FrequencyPal, int SoundHandle);
		public static int SetFrequencySoundMem(int FrequencyPal, int SoundHandle) => dx_SetFrequencySoundMem(FrequencyPal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFrequencySoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFrequencySoundMem(int SoundHandle);
		public static int GetFrequencySoundMem(int SoundHandle) => dx_GetFrequencySoundMem(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetFrequencySoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetFrequencySoundMem(int SoundHandle);
		public static int ResetFrequencySoundMem(int SoundHandle) => dx_ResetFrequencySoundMem(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNextPlayPanSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNextPlayPanSoundMem(int PanPal, int SoundHandle);
		public static int SetNextPlayPanSoundMem(int PanPal, int SoundHandle) => dx_SetNextPlayPanSoundMem(PanPal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeNextPlayPanSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeNextPlayPanSoundMem(int PanPal, int SoundHandle);
		public static int ChangeNextPlayPanSoundMem(int PanPal, int SoundHandle) => dx_ChangeNextPlayPanSoundMem(PanPal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNextPlayVolumeSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNextPlayVolumeSoundMem(int VolumePal, int SoundHandle);
		public static int SetNextPlayVolumeSoundMem(int VolumePal, int SoundHandle) => dx_SetNextPlayVolumeSoundMem(VolumePal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeNextPlayVolumeSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeNextPlayVolumeSoundMem(int VolumePal, int SoundHandle);
		public static int ChangeNextPlayVolumeSoundMem(int VolumePal, int SoundHandle) => dx_ChangeNextPlayVolumeSoundMem(VolumePal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNextPlayChannelVolumeSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNextPlayChannelVolumeSoundMem(int Channel, int VolumePal, int SoundHandle);
		public static int SetNextPlayChannelVolumeSoundMem(int Channel, int VolumePal, int SoundHandle) => dx_SetNextPlayChannelVolumeSoundMem(Channel, VolumePal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeNextPlayChannelVolumeSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeNextPlayChannelVolumeSoundMem(int Channel, int VolumePal, int SoundHandle);
		public static int ChangeNextPlayChannelVolumeSoundMem(int Channel, int VolumePal, int SoundHandle) => dx_ChangeNextPlayChannelVolumeSoundMem(Channel, VolumePal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNextPlayFrequencySoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNextPlayFrequencySoundMem(int FrequencyPal, int SoundHandle);
		public static int SetNextPlayFrequencySoundMem(int FrequencyPal, int SoundHandle) => dx_SetNextPlayFrequencySoundMem(FrequencyPal, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCurrentPositionSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCurrentPositionSoundMem(long SamplePosition, int SoundHandle);
		public static int SetCurrentPositionSoundMem(long SamplePosition, int SoundHandle) => dx_SetCurrentPositionSoundMem(SamplePosition, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCurrentPositionSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_GetCurrentPositionSoundMem(int SoundHandle);
		public static long GetCurrentPositionSoundMem(int SoundHandle) => dx_GetCurrentPositionSoundMem(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetSoundCurrentPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetSoundCurrentPosition(long Byte, int SoundHandle);
		public static int SetSoundCurrentPosition(long Byte, int SoundHandle) => dx_SetSoundCurrentPosition(Byte, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetSoundCurrentPosition", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_GetSoundCurrentPosition(int SoundHandle);
		public static long GetSoundCurrentPosition(int SoundHandle) => dx_GetSoundCurrentPosition(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetSoundCurrentTime", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetSoundCurrentTime(long Time, int SoundHandle);
		public static int SetSoundCurrentTime(long Time, int SoundHandle) => dx_SetSoundCurrentTime(Time, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetSoundCurrentTime", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_GetSoundCurrentTime(int SoundHandle);
		public static long GetSoundCurrentTime(int SoundHandle) => dx_GetSoundCurrentTime(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetSoundTotalSample", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_GetSoundTotalSample(int SoundHandle);
		public static long GetSoundTotalSample(int SoundHandle) => dx_GetSoundTotalSample(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetSoundTotalTime", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_GetSoundTotalTime(int SoundHandle);
		public static long GetSoundTotalTime(int SoundHandle) => dx_GetSoundTotalTime(SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLoopPosSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLoopPosSoundMem(long LoopTime, int SoundHandle);
		public static int SetLoopPosSoundMem(long LoopTime, int SoundHandle) => dx_SetLoopPosSoundMem(LoopTime, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLoopTimePosSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLoopTimePosSoundMem(long LoopTime, int SoundHandle);
		public static int SetLoopTimePosSoundMem(long LoopTime, int SoundHandle) => dx_SetLoopTimePosSoundMem(LoopTime, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLoopSamplePosSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLoopSamplePosSoundMem(long LoopSamplePosition, int SoundHandle);
		public static int SetLoopSamplePosSoundMem(long LoopSamplePosition, int SoundHandle) => dx_SetLoopSamplePosSoundMem(LoopSamplePosition, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLoopStartTimePosSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLoopStartTimePosSoundMem(long LoopStartTime, int SoundHandle);
		public static int SetLoopStartTimePosSoundMem(long LoopStartTime, int SoundHandle) => dx_SetLoopStartTimePosSoundMem(LoopStartTime, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLoopStartSamplePosSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLoopStartSamplePosSoundMem(long LoopStartSamplePosition, int SoundHandle);
		public static int SetLoopStartSamplePosSoundMem(long LoopStartSamplePosition, int SoundHandle) => dx_SetLoopStartSamplePosSoundMem(LoopStartSamplePosition, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLoopAreaTimePosSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLoopAreaTimePosSoundMem(long LoopStartTime, long LoopEndTime, int SoundHandle);
		public static int SetLoopAreaTimePosSoundMem(long LoopStartTime, long LoopEndTime, int SoundHandle) => dx_SetLoopAreaTimePosSoundMem(LoopStartTime, LoopEndTime, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLoopAreaTimePosSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLoopAreaTimePosSoundMem(out long LoopStartTime, out long LoopEndTime, int SoundHandle);
		public static int GetLoopAreaTimePosSoundMem(out long LoopStartTime, out long LoopEndTime, int SoundHandle) => dx_GetLoopAreaTimePosSoundMem(out LoopStartTime, out LoopEndTime, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetLoopAreaSamplePosSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetLoopAreaSamplePosSoundMem(long LoopStartSamplePosition, long LoopEndSamplePosition, int SoundHandle);
		public static int SetLoopAreaSamplePosSoundMem(long LoopStartSamplePosition, long LoopEndSamplePosition, int SoundHandle) => dx_SetLoopAreaSamplePosSoundMem(LoopStartSamplePosition, LoopEndSamplePosition, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetLoopAreaSamplePosSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetLoopAreaSamplePosSoundMem(out long LoopStartSamplePosition, out long LoopEndSamplePosition, int SoundHandle);
		public static int GetLoopAreaSamplePosSoundMem(out long LoopStartSamplePosition, out long LoopEndSamplePosition, int SoundHandle) => dx_GetLoopAreaSamplePosSoundMem(out LoopStartSamplePosition, out LoopEndSamplePosition, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetPlayFinishDeleteSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetPlayFinishDeleteSoundMem(int DeleteFlag, int SoundHandle);
		public static int SetPlayFinishDeleteSoundMem(int DeleteFlag, int SoundHandle) => dx_SetPlayFinishDeleteSoundMem(DeleteFlag, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DReverbParamSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DReverbParamSoundMem(out SOUND3D_REVERB_PARAM Param, int SoundHandle);
		public static int Set3DReverbParamSoundMem(out SOUND3D_REVERB_PARAM Param, int SoundHandle) => dx_Set3DReverbParamSoundMem(out Param, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DPresetReverbParamSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DPresetReverbParamSoundMem(int PresetNo, int SoundHandle);
		public static int Set3DPresetReverbParamSoundMem(int PresetNo, int SoundHandle) => dx_Set3DPresetReverbParamSoundMem(PresetNo, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DReverbParamSoundMemAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DReverbParamSoundMemAll(out SOUND3D_REVERB_PARAM Param, int PlaySoundOnly);
		public static int Set3DReverbParamSoundMemAll(out SOUND3D_REVERB_PARAM Param, int PlaySoundOnly = FALSE) => dx_Set3DReverbParamSoundMemAll(out Param, PlaySoundOnly);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DPresetReverbParamSoundMemAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DPresetReverbParamSoundMemAll(int PresetNo, int PlaySoundOnly);
		public static int Set3DPresetReverbParamSoundMemAll(int PresetNo, int PlaySoundOnly = FALSE) => dx_Set3DPresetReverbParamSoundMemAll(PresetNo, PlaySoundOnly);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Get3DReverbParamSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Get3DReverbParamSoundMem(out SOUND3D_REVERB_PARAM ParamBuffer, int SoundHandle);
		public static int Get3DReverbParamSoundMem(out SOUND3D_REVERB_PARAM ParamBuffer, int SoundHandle) => dx_Get3DReverbParamSoundMem(out ParamBuffer, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Get3DPresetReverbParamSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Get3DPresetReverbParamSoundMem(out SOUND3D_REVERB_PARAM ParamBuffer, int PresetNo);
		public static int Get3DPresetReverbParamSoundMem(out SOUND3D_REVERB_PARAM ParamBuffer, int PresetNo) => dx_Get3DPresetReverbParamSoundMem(out ParamBuffer, PresetNo);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DPositionSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DPositionSoundMem(VECTOR Position, int SoundHandle);
		public static int Set3DPositionSoundMem(VECTOR Position, int SoundHandle) => dx_Set3DPositionSoundMem(Position, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DRadiusSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DRadiusSoundMem(float Radius, int SoundHandle);
		public static int Set3DRadiusSoundMem(float Radius, int SoundHandle) => dx_Set3DRadiusSoundMem(Radius, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DVelocitySoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DVelocitySoundMem(VECTOR Velocity, int SoundHandle);
		public static int Set3DVelocitySoundMem(VECTOR Velocity, int SoundHandle) => dx_Set3DVelocitySoundMem(Velocity, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNextPlay3DPositionSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNextPlay3DPositionSoundMem(VECTOR Position, int SoundHandle);
		public static int SetNextPlay3DPositionSoundMem(VECTOR Position, int SoundHandle) => dx_SetNextPlay3DPositionSoundMem(Position, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNextPlay3DRadiusSoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNextPlay3DRadiusSoundMem(float Radius, int SoundHandle);
		public static int SetNextPlay3DRadiusSoundMem(float Radius, int SoundHandle) => dx_SetNextPlay3DRadiusSoundMem(Radius, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNextPlay3DVelocitySoundMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNextPlay3DVelocitySoundMem(VECTOR Velocity, int SoundHandle);
		public static int SetNextPlay3DVelocitySoundMem(VECTOR Velocity, int SoundHandle) => dx_SetNextPlay3DVelocitySoundMem(Velocity, SoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMP3TagInfo", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMP3TagInfo(string FileName, System.Text.StringBuilder TitleBuffer, ulong TitleBufferBytes, System.Text.StringBuilder ArtistBuffer, ulong ArtistBufferBytes, System.Text.StringBuilder AlbumBuffer, ulong AlbumBufferBytes, System.Text.StringBuilder YearBuffer, ulong YearBufferBytes, System.Text.StringBuilder CommentBuffer, ulong CommentBufferBytes, System.Text.StringBuilder TrackBuffer, ulong TrackBufferBytes, System.Text.StringBuilder GenreBuffer, ulong GenreBufferBytes, out int PictureGrHandle);
		public static int GetMP3TagInfo(string FileName, System.Text.StringBuilder TitleBuffer, ulong TitleBufferBytes, System.Text.StringBuilder ArtistBuffer, ulong ArtistBufferBytes, System.Text.StringBuilder AlbumBuffer, ulong AlbumBufferBytes, System.Text.StringBuilder YearBuffer, ulong YearBufferBytes, System.Text.StringBuilder CommentBuffer, ulong CommentBufferBytes, System.Text.StringBuilder TrackBuffer, ulong TrackBufferBytes, System.Text.StringBuilder GenreBuffer, ulong GenreBufferBytes, out int PictureGrHandle) => dx_GetMP3TagInfo(FileName, TitleBuffer, TitleBufferBytes, ArtistBuffer, ArtistBufferBytes, AlbumBuffer, AlbumBufferBytes, YearBuffer, YearBufferBytes, CommentBuffer, CommentBufferBytes, TrackBuffer, TrackBufferBytes, GenreBuffer, GenreBufferBytes, out PictureGrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMP3TagInfoWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMP3TagInfoWithStrLen(string FileName, ulong FileNameLength, System.Text.StringBuilder TitleBuffer, ulong TitleBufferBytes, System.Text.StringBuilder ArtistBuffer, ulong ArtistBufferBytes, System.Text.StringBuilder AlbumBuffer, ulong AlbumBufferBytes, System.Text.StringBuilder YearBuffer, ulong YearBufferBytes, System.Text.StringBuilder CommentBuffer, ulong CommentBufferBytes, System.Text.StringBuilder TrackBuffer, ulong TrackBufferBytes, System.Text.StringBuilder GenreBuffer, ulong GenreBufferBytes, out int PictureGrHandle);
		public static int GetMP3TagInfoWithStrLen(string FileName, ulong FileNameLength, System.Text.StringBuilder TitleBuffer, ulong TitleBufferBytes, System.Text.StringBuilder ArtistBuffer, ulong ArtistBufferBytes, System.Text.StringBuilder AlbumBuffer, ulong AlbumBufferBytes, System.Text.StringBuilder YearBuffer, ulong YearBufferBytes, System.Text.StringBuilder CommentBuffer, ulong CommentBufferBytes, System.Text.StringBuilder TrackBuffer, ulong TrackBufferBytes, System.Text.StringBuilder GenreBuffer, ulong GenreBufferBytes, out int PictureGrHandle) => dx_GetMP3TagInfoWithStrLen(FileName, FileNameLength, TitleBuffer, TitleBufferBytes, ArtistBuffer, ArtistBufferBytes, AlbumBuffer, AlbumBufferBytes, YearBuffer, YearBufferBytes, CommentBuffer, CommentBufferBytes, TrackBuffer, TrackBufferBytes, GenreBuffer, GenreBufferBytes, out PictureGrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetOggCommentNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetOggCommentNum(string FileName);
		public static int GetOggCommentNum(string FileName) => dx_GetOggCommentNum(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetOggCommentNumWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetOggCommentNumWithStrLen(string FileName, ulong FileNameLength);
		public static int GetOggCommentNumWithStrLen(string FileName, ulong FileNameLength) => dx_GetOggCommentNumWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetOggComment", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetOggComment(string FileName, int CommentIndex, System.Text.StringBuilder CommentNameBuffer, ulong CommentNameBufferBytes, System.Text.StringBuilder CommentBuffer, ulong CommentBufferBytes);
		public static int GetOggComment(string FileName, int CommentIndex, System.Text.StringBuilder CommentNameBuffer, ulong CommentNameBufferBytes, System.Text.StringBuilder CommentBuffer, ulong CommentBufferBytes) => dx_GetOggComment(FileName, CommentIndex, CommentNameBuffer, CommentNameBufferBytes, CommentBuffer, CommentBufferBytes);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetOggCommentWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetOggCommentWithStrLen(string FileName, ulong FileNameLength, int CommentIndex, System.Text.StringBuilder CommentNameBuffer, ulong CommentNameBufferBytes, System.Text.StringBuilder CommentBuffer, ulong CommentBufferBytes);
		public static int GetOggCommentWithStrLen(string FileName, ulong FileNameLength, int CommentIndex, System.Text.StringBuilder CommentNameBuffer, ulong CommentNameBufferBytes, System.Text.StringBuilder CommentBuffer, ulong CommentBufferBytes) => dx_GetOggCommentWithStrLen(FileName, FileNameLength, CommentIndex, CommentNameBuffer, CommentNameBufferBytes, CommentBuffer, CommentBufferBytes);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreateSoundDataType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreateSoundDataType(int SoundDataType);
		public static int SetCreateSoundDataType(int SoundDataType) => dx_SetCreateSoundDataType(SoundDataType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCreateSoundDataType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCreateSoundDataType();
		public static int GetCreateSoundDataType() => dx_GetCreateSoundDataType();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreateSoundPitchRate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreateSoundPitchRate(float Cents);
		public static int SetCreateSoundPitchRate(float Cents) => dx_SetCreateSoundPitchRate(Cents);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCreateSoundPitchRate", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetCreateSoundPitchRate();
		public static float GetCreateSoundPitchRate() => dx_GetCreateSoundPitchRate();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreateSoundTimeStretchRate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreateSoundTimeStretchRate(float Rate);
		public static int SetCreateSoundTimeStretchRate(float Rate) => dx_SetCreateSoundTimeStretchRate(Rate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCreateSoundTimeStretchRate", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_GetCreateSoundTimeStretchRate();
		public static float GetCreateSoundTimeStretchRate() => dx_GetCreateSoundTimeStretchRate();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreateSoundLoopAreaTimePos", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreateSoundLoopAreaTimePos(long LoopStartTime, long LoopEndTime);
		public static int SetCreateSoundLoopAreaTimePos(long LoopStartTime, long LoopEndTime) => dx_SetCreateSoundLoopAreaTimePos(LoopStartTime, LoopEndTime);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCreateSoundLoopAreaTimePos", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCreateSoundLoopAreaTimePos(out long LoopStartTime, out long LoopEndTime);
		public static int GetCreateSoundLoopAreaTimePos(out long LoopStartTime, out long LoopEndTime) => dx_GetCreateSoundLoopAreaTimePos(out LoopStartTime, out LoopEndTime);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreateSoundLoopAreaSamplePos", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreateSoundLoopAreaSamplePos(long LoopStartSamplePosition, long LoopEndSamplePosition);
		public static int SetCreateSoundLoopAreaSamplePos(long LoopStartSamplePosition, long LoopEndSamplePosition) => dx_SetCreateSoundLoopAreaSamplePos(LoopStartSamplePosition, LoopEndSamplePosition);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCreateSoundLoopAreaSamplePos", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCreateSoundLoopAreaSamplePos(out long LoopStartSamplePosition, out long LoopEndSamplePosition);
		public static int GetCreateSoundLoopAreaSamplePos(out long LoopStartSamplePosition, out long LoopEndSamplePosition) => dx_GetCreateSoundLoopAreaSamplePos(out LoopStartSamplePosition, out LoopEndSamplePosition);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreateSoundIgnoreLoopAreaInfo", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreateSoundIgnoreLoopAreaInfo(int IgnoreFlag);
		public static int SetCreateSoundIgnoreLoopAreaInfo(int IgnoreFlag) => dx_SetCreateSoundIgnoreLoopAreaInfo(IgnoreFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetCreateSoundIgnoreLoopAreaInfo", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetCreateSoundIgnoreLoopAreaInfo();
		public static int GetCreateSoundIgnoreLoopAreaInfo() => dx_GetCreateSoundIgnoreLoopAreaInfo();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDisableReadSoundFunctionMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDisableReadSoundFunctionMask(int Mask);
		public static int SetDisableReadSoundFunctionMask(int Mask) => dx_SetDisableReadSoundFunctionMask(Mask);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDisableReadSoundFunctionMask", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDisableReadSoundFunctionMask();
		public static int GetDisableReadSoundFunctionMask() => dx_GetDisableReadSoundFunctionMask();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetEnableSoundCaptureFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetEnableSoundCaptureFlag(int Flag);
		public static int SetEnableSoundCaptureFlag(int Flag) => dx_SetEnableSoundCaptureFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseOldVolumeCalcFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseOldVolumeCalcFlag(int Flag);
		public static int SetUseOldVolumeCalcFlag(int Flag) => dx_SetUseOldVolumeCalcFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetSoundCurrentTimeType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetSoundCurrentTimeType(int Type);
		public static int SetSoundCurrentTimeType(int Type) => dx_SetSoundCurrentTimeType(Type);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetSoundCurrentTimeType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetSoundCurrentTimeType();
		public static int GetSoundCurrentTimeType() => dx_GetSoundCurrentTimeType();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetCreate3DSoundFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetCreate3DSoundFlag(int Flag);
		public static int SetCreate3DSoundFlag(int Flag) => dx_SetCreate3DSoundFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DSoundOneMetre", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DSoundOneMetre(float Distance);
		public static int Set3DSoundOneMetre(float Distance) => dx_Set3DSoundOneMetre(Distance);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DSoundListenerPosAndFrontPos_UpVecY", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DSoundListenerPosAndFrontPos_UpVecY(VECTOR Position, VECTOR FrontPosition);
		public static int Set3DSoundListenerPosAndFrontPos_UpVecY(VECTOR Position, VECTOR FrontPosition) => dx_Set3DSoundListenerPosAndFrontPos_UpVecY(Position, FrontPosition);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DSoundListenerPosAndFrontPosAndUpVec", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DSoundListenerPosAndFrontPosAndUpVec(VECTOR Position, VECTOR FrontPosition, VECTOR UpVector);
		public static int Set3DSoundListenerPosAndFrontPosAndUpVec(VECTOR Position, VECTOR FrontPosition, VECTOR UpVector) => dx_Set3DSoundListenerPosAndFrontPosAndUpVec(Position, FrontPosition, UpVector);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DSoundListenerVelocity", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DSoundListenerVelocity(VECTOR Velocity);
		public static int Set3DSoundListenerVelocity(VECTOR Velocity) => dx_Set3DSoundListenerVelocity(Velocity);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DSoundListenerConeAngle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DSoundListenerConeAngle(float InnerAngle, float OuterAngle);
		public static int Set3DSoundListenerConeAngle(float InnerAngle, float OuterAngle) => dx_Set3DSoundListenerConeAngle(InnerAngle, OuterAngle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Set3DSoundListenerConeVolume", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Set3DSoundListenerConeVolume(float InnerAngleVolume, float OuterAngleVolume);
		public static int Set3DSoundListenerConeVolume(float InnerAngleVolume, float OuterAngleVolume) => dx_Set3DSoundListenerConeVolume(InnerAngleVolume, OuterAngleVolume);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlaySoundFile", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlaySoundFile(string FileName, int PlayType);
		public static int PlaySoundFile(string FileName, int PlayType) => dx_PlaySoundFile(FileName, PlayType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlaySoundFileWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlaySoundFileWithStrLen(string FileName, ulong FileNameLength, int PlayType);
		public static int PlaySoundFileWithStrLen(string FileName, ulong FileNameLength, int PlayType) => dx_PlaySoundFileWithStrLen(FileName, FileNameLength, PlayType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlaySound", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlaySound(string FileName, int PlayType);
		public static int PlaySound(string FileName, int PlayType) => dx_PlaySound(FileName, PlayType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlaySoundWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlaySoundWithStrLen(string FileName, ulong FileNameLength, int PlayType);
		public static int PlaySoundWithStrLen(string FileName, ulong FileNameLength, int PlayType) => dx_PlaySoundWithStrLen(FileName, FileNameLength, PlayType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckSoundFile", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckSoundFile();
		public static int CheckSoundFile() => dx_CheckSoundFile();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckSound", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckSound();
		public static int CheckSound() => dx_CheckSound();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_StopSoundFile", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_StopSoundFile();
		public static int StopSoundFile() => dx_StopSoundFile();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_StopSound", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_StopSound();
		public static int StopSound() => dx_StopSound();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVolumeSoundFile", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVolumeSoundFile(int VolumePal);
		public static int SetVolumeSoundFile(int VolumePal) => dx_SetVolumeSoundFile(VolumePal);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVolumeSound", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVolumeSound(int VolumePal);
		public static int SetVolumeSound(int VolumePal) => dx_SetVolumeSound(VolumePal);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitSoftSound", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitSoftSound();
		public static int InitSoftSound() => dx_InitSoftSound();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoftSound", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoftSound(string FileName);
		public static int LoadSoftSound(string FileName) => dx_LoadSoftSound(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoftSoundWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoftSoundWithStrLen(string FileName, ulong FileNameLength);
		public static int LoadSoftSoundWithStrLen(string FileName, ulong FileNameLength) => dx_LoadSoftSoundWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoftSoundFromMemImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoftSoundFromMemImage(System.IntPtr FileImage, ulong FileImageSize);
		public static int LoadSoftSoundFromMemImage(System.IntPtr FileImage, ulong FileImageSize) => dx_LoadSoftSoundFromMemImage(FileImage, FileImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSound", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSound(int UseFormat_SoftSoundHandle, long SampleNum);
		public static int MakeSoftSound(int UseFormat_SoftSoundHandle, long SampleNum) => dx_MakeSoftSound(UseFormat_SoftSoundHandle, SampleNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSound2Ch16Bit44KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSound2Ch16Bit44KHz(long SampleNum);
		public static int MakeSoftSound2Ch16Bit44KHz(long SampleNum) => dx_MakeSoftSound2Ch16Bit44KHz(SampleNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSound2Ch16Bit22KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSound2Ch16Bit22KHz(long SampleNum);
		public static int MakeSoftSound2Ch16Bit22KHz(long SampleNum) => dx_MakeSoftSound2Ch16Bit22KHz(SampleNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSound2Ch8Bit44KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSound2Ch8Bit44KHz(long SampleNum);
		public static int MakeSoftSound2Ch8Bit44KHz(long SampleNum) => dx_MakeSoftSound2Ch8Bit44KHz(SampleNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSound2Ch8Bit22KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSound2Ch8Bit22KHz(long SampleNum);
		public static int MakeSoftSound2Ch8Bit22KHz(long SampleNum) => dx_MakeSoftSound2Ch8Bit22KHz(SampleNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSound1Ch16Bit44KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSound1Ch16Bit44KHz(long SampleNum);
		public static int MakeSoftSound1Ch16Bit44KHz(long SampleNum) => dx_MakeSoftSound1Ch16Bit44KHz(SampleNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSound1Ch16Bit22KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSound1Ch16Bit22KHz(long SampleNum);
		public static int MakeSoftSound1Ch16Bit22KHz(long SampleNum) => dx_MakeSoftSound1Ch16Bit22KHz(SampleNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSound1Ch8Bit44KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSound1Ch8Bit44KHz(long SampleNum);
		public static int MakeSoftSound1Ch8Bit44KHz(long SampleNum) => dx_MakeSoftSound1Ch8Bit44KHz(SampleNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSound1Ch8Bit22KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSound1Ch8Bit22KHz(long SampleNum);
		public static int MakeSoftSound1Ch8Bit22KHz(long SampleNum) => dx_MakeSoftSound1Ch8Bit22KHz(SampleNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSoundCustom", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSoundCustom(int ChannelNum, int BitsPerSample, int SamplesPerSec, long SampleNum, int IsFloatType);
		public static int MakeSoftSoundCustom(int ChannelNum, int BitsPerSample, int SamplesPerSec, long SampleNum, int IsFloatType = 0) => dx_MakeSoftSoundCustom(ChannelNum, BitsPerSample, SamplesPerSec, SampleNum, IsFloatType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteSoftSound", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteSoftSound(int SoftSoundHandle);
		public static int DeleteSoftSound(int SoftSoundHandle) => dx_DeleteSoftSound(SoftSoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveSoftSound", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveSoftSound(int SoftSoundHandle, string FileName);
		public static int SaveSoftSound(int SoftSoundHandle, string FileName) => dx_SaveSoftSound(SoftSoundHandle, FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SaveSoftSoundWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SaveSoftSoundWithStrLen(int SoftSoundHandle, string FileName, ulong FileNameLength);
		public static int SaveSoftSoundWithStrLen(int SoftSoundHandle, string FileName, ulong FileNameLength) => dx_SaveSoftSoundWithStrLen(SoftSoundHandle, FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetSoftSoundSampleNum", CallingConvention=CallingConvention.StdCall)]
		extern static long dx_GetSoftSoundSampleNum(int SoftSoundHandle);
		public static long GetSoftSoundSampleNum(int SoftSoundHandle) => dx_GetSoftSoundSampleNum(SoftSoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetSoftSoundFormat", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetSoftSoundFormat(int SoftSoundHandle, out int Channels, out int BitsPerSample, out int SamplesPerSec, out int IsFloatType);
		public static int GetSoftSoundFormat(int SoftSoundHandle, out int Channels, out int BitsPerSample, out int SamplesPerSec, out int IsFloatType) => dx_GetSoftSoundFormat(SoftSoundHandle, out Channels, out BitsPerSample, out SamplesPerSec, out IsFloatType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReadSoftSoundData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReadSoftSoundData(int SoftSoundHandle, long SamplePosition, out int Channel1, out int Channel2);
		public static int ReadSoftSoundData(int SoftSoundHandle, long SamplePosition, out int Channel1, out int Channel2) => dx_ReadSoftSoundData(SoftSoundHandle, SamplePosition, out Channel1, out Channel2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ReadSoftSoundDataF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ReadSoftSoundDataF(int SoftSoundHandle, long SamplePosition, out float Channel1, out float Channel2);
		public static int ReadSoftSoundDataF(int SoftSoundHandle, long SamplePosition, out float Channel1, out float Channel2) => dx_ReadSoftSoundDataF(SoftSoundHandle, SamplePosition, out Channel1, out Channel2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_WriteSoftSoundData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_WriteSoftSoundData(int SoftSoundHandle, long SamplePosition, int Channel1, int Channel2);
		public static int WriteSoftSoundData(int SoftSoundHandle, long SamplePosition, int Channel1, int Channel2) => dx_WriteSoftSoundData(SoftSoundHandle, SamplePosition, Channel1, Channel2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_WriteSoftSoundDataF", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_WriteSoftSoundDataF(int SoftSoundHandle, long SamplePosition, float Channel1, float Channel2);
		public static int WriteSoftSoundDataF(int SoftSoundHandle, long SamplePosition, float Channel1, float Channel2) => dx_WriteSoftSoundDataF(SoftSoundHandle, SamplePosition, Channel1, Channel2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_WriteTimeStretchSoftSoundData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_WriteTimeStretchSoftSoundData(int SrcSoftSoundHandle, int DestSoftSoundHandle);
		public static int WriteTimeStretchSoftSoundData(int SrcSoftSoundHandle, int DestSoftSoundHandle) => dx_WriteTimeStretchSoftSoundData(SrcSoftSoundHandle, DestSoftSoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_WritePitchShiftSoftSoundData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_WritePitchShiftSoftSoundData(int SrcSoftSoundHandle, int DestSoftSoundHandle);
		public static int WritePitchShiftSoftSoundData(int SrcSoftSoundHandle, int DestSoftSoundHandle) => dx_WritePitchShiftSoftSoundData(SrcSoftSoundHandle, DestSoftSoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetSoftSoundDataImage", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetSoftSoundDataImage(int SoftSoundHandle);
		public static System.IntPtr GetSoftSoundDataImage(int SoftSoundHandle) => dx_GetSoftSoundDataImage(SoftSoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFFTVibrationSoftSound", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFFTVibrationSoftSound(int SoftSoundHandle, int Channel, long SamplePosition, int SampleNum, [In, Out] float[] Buffer_Array, int BufferLength);
		public static int GetFFTVibrationSoftSound(int SoftSoundHandle, int Channel, long SamplePosition, int SampleNum, [In, Out] float[] Buffer_Array, int BufferLength) => dx_GetFFTVibrationSoftSound(SoftSoundHandle, Channel, SamplePosition, SampleNum, Buffer_Array, BufferLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetFFTVibrationSoftSoundBase", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetFFTVibrationSoftSoundBase(int SoftSoundHandle, int Channel, long SamplePosition, int SampleNum, [In, Out] float[] RealBuffer_Array, [In, Out] float[] ImagBuffer_Array, int BufferLength);
		public static int GetFFTVibrationSoftSoundBase(int SoftSoundHandle, int Channel, long SamplePosition, int SampleNum, [In, Out] float[] RealBuffer_Array, [In, Out] float[] ImagBuffer_Array, int BufferLength) => dx_GetFFTVibrationSoftSoundBase(SoftSoundHandle, Channel, SamplePosition, SampleNum, RealBuffer_Array, ImagBuffer_Array, BufferLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitSoftSoundPlayer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitSoftSoundPlayer();
		public static int InitSoftSoundPlayer() => dx_InitSoftSoundPlayer();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSoundPlayer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSoundPlayer(int UseFormat_SoftSoundHandle);
		public static int MakeSoftSoundPlayer(int UseFormat_SoftSoundHandle) => dx_MakeSoftSoundPlayer(UseFormat_SoftSoundHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSoundPlayer2Ch16Bit44KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSoundPlayer2Ch16Bit44KHz();
		public static int MakeSoftSoundPlayer2Ch16Bit44KHz() => dx_MakeSoftSoundPlayer2Ch16Bit44KHz();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSoundPlayer2Ch16Bit22KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSoundPlayer2Ch16Bit22KHz();
		public static int MakeSoftSoundPlayer2Ch16Bit22KHz() => dx_MakeSoftSoundPlayer2Ch16Bit22KHz();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSoundPlayer2Ch8Bit44KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSoundPlayer2Ch8Bit44KHz();
		public static int MakeSoftSoundPlayer2Ch8Bit44KHz() => dx_MakeSoftSoundPlayer2Ch8Bit44KHz();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSoundPlayer2Ch8Bit22KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSoundPlayer2Ch8Bit22KHz();
		public static int MakeSoftSoundPlayer2Ch8Bit22KHz() => dx_MakeSoftSoundPlayer2Ch8Bit22KHz();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSoundPlayer1Ch16Bit44KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSoundPlayer1Ch16Bit44KHz();
		public static int MakeSoftSoundPlayer1Ch16Bit44KHz() => dx_MakeSoftSoundPlayer1Ch16Bit44KHz();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSoundPlayer1Ch16Bit22KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSoundPlayer1Ch16Bit22KHz();
		public static int MakeSoftSoundPlayer1Ch16Bit22KHz() => dx_MakeSoftSoundPlayer1Ch16Bit22KHz();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSoundPlayer1Ch8Bit44KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSoundPlayer1Ch8Bit44KHz();
		public static int MakeSoftSoundPlayer1Ch8Bit44KHz() => dx_MakeSoftSoundPlayer1Ch8Bit44KHz();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSoundPlayer1Ch8Bit22KHz", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSoundPlayer1Ch8Bit22KHz();
		public static int MakeSoftSoundPlayer1Ch8Bit22KHz() => dx_MakeSoftSoundPlayer1Ch8Bit22KHz();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MakeSoftSoundPlayerCustom", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MakeSoftSoundPlayerCustom(int ChannelNum, int BitsPerSample, int SamplesPerSec);
		public static int MakeSoftSoundPlayerCustom(int ChannelNum, int BitsPerSample, int SamplesPerSec) => dx_MakeSoftSoundPlayerCustom(ChannelNum, BitsPerSample, SamplesPerSec);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteSoftSoundPlayer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteSoftSoundPlayer(int SSoundPlayerHandle);
		public static int DeleteSoftSoundPlayer(int SSoundPlayerHandle) => dx_DeleteSoftSoundPlayer(SSoundPlayerHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddDataSoftSoundPlayer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddDataSoftSoundPlayer(int SSoundPlayerHandle, int SoftSoundHandle, long AddSamplePosition, int AddSampleNum);
		public static int AddDataSoftSoundPlayer(int SSoundPlayerHandle, int SoftSoundHandle, long AddSamplePosition, int AddSampleNum) => dx_AddDataSoftSoundPlayer(SSoundPlayerHandle, SoftSoundHandle, AddSamplePosition, AddSampleNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddDirectDataSoftSoundPlayer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddDirectDataSoftSoundPlayer(int SSoundPlayerHandle, System.IntPtr SoundData, int AddSampleNum);
		public static int AddDirectDataSoftSoundPlayer(int SSoundPlayerHandle, System.IntPtr SoundData, int AddSampleNum) => dx_AddDirectDataSoftSoundPlayer(SSoundPlayerHandle, SoundData, AddSampleNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddOneDataSoftSoundPlayer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddOneDataSoftSoundPlayer(int SSoundPlayerHandle, int Channel1, int Channel2);
		public static int AddOneDataSoftSoundPlayer(int SSoundPlayerHandle, int Channel1, int Channel2) => dx_AddOneDataSoftSoundPlayer(SSoundPlayerHandle, Channel1, Channel2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetSoftSoundPlayerFormat", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetSoftSoundPlayerFormat(int SSoundPlayerHandle, out int Channels, out int BitsPerSample, out int SamplesPerSec);
		public static int GetSoftSoundPlayerFormat(int SSoundPlayerHandle, out int Channels, out int BitsPerSample, out int SamplesPerSec) => dx_GetSoftSoundPlayerFormat(SSoundPlayerHandle, out Channels, out BitsPerSample, out SamplesPerSec);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_StartSoftSoundPlayer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_StartSoftSoundPlayer(int SSoundPlayerHandle);
		public static int StartSoftSoundPlayer(int SSoundPlayerHandle) => dx_StartSoftSoundPlayer(SSoundPlayerHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckStartSoftSoundPlayer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckStartSoftSoundPlayer(int SSoundPlayerHandle);
		public static int CheckStartSoftSoundPlayer(int SSoundPlayerHandle) => dx_CheckStartSoftSoundPlayer(SSoundPlayerHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_StopSoftSoundPlayer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_StopSoftSoundPlayer(int SSoundPlayerHandle);
		public static int StopSoftSoundPlayer(int SSoundPlayerHandle) => dx_StopSoftSoundPlayer(SSoundPlayerHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ResetSoftSoundPlayer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ResetSoftSoundPlayer(int SSoundPlayerHandle);
		public static int ResetSoftSoundPlayer(int SSoundPlayerHandle) => dx_ResetSoftSoundPlayer(SSoundPlayerHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetStockDataLengthSoftSoundPlayer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetStockDataLengthSoftSoundPlayer(int SSoundPlayerHandle);
		public static int GetStockDataLengthSoftSoundPlayer(int SSoundPlayerHandle) => dx_GetStockDataLengthSoftSoundPlayer(SSoundPlayerHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckSoftSoundPlayerNoneData", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckSoftSoundPlayerNoneData(int SSoundPlayerHandle);
		public static int CheckSoftSoundPlayerNoneData(int SSoundPlayerHandle) => dx_CheckSoftSoundPlayerNoneData(SSoundPlayerHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteMusicMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteMusicMem(int MusicHandle);
		public static int DeleteMusicMem(int MusicHandle) => dx_DeleteMusicMem(MusicHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadMusicMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadMusicMem(string FileName);
		public static int LoadMusicMem(string FileName) => dx_LoadMusicMem(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadMusicMemWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadMusicMemWithStrLen(string FileName, ulong FileNameLength);
		public static int LoadMusicMemWithStrLen(string FileName, ulong FileNameLength) => dx_LoadMusicMemWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadMusicMemByMemImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadMusicMemByMemImage(System.IntPtr FileImage, ulong FileImageSize);
		public static int LoadMusicMemByMemImage(System.IntPtr FileImage, ulong FileImageSize) => dx_LoadMusicMemByMemImage(FileImage, FileImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlayMusicMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlayMusicMem(int MusicHandle, int PlayType);
		public static int PlayMusicMem(int MusicHandle, int PlayType) => dx_PlayMusicMem(MusicHandle, PlayType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_StopMusicMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_StopMusicMem(int MusicHandle);
		public static int StopMusicMem(int MusicHandle) => dx_StopMusicMem(MusicHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckMusicMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckMusicMem(int MusicHandle);
		public static int CheckMusicMem(int MusicHandle) => dx_CheckMusicMem(MusicHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVolumeMusicMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVolumeMusicMem(int Volume, int MusicHandle);
		public static int SetVolumeMusicMem(int Volume, int MusicHandle) => dx_SetVolumeMusicMem(Volume, MusicHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMusicMemPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMusicMemPosition(int MusicHandle);
		public static int GetMusicMemPosition(int MusicHandle) => dx_GetMusicMemPosition(MusicHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InitMusicMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InitMusicMem();
		public static int InitMusicMem() => dx_InitMusicMem();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ProcessMusicMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ProcessMusicMem();
		public static int ProcessMusicMem() => dx_ProcessMusicMem();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlayMusic", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlayMusic(string FileName, int PlayType);
		public static int PlayMusic(string FileName, int PlayType) => dx_PlayMusic(FileName, PlayType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlayMusicWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlayMusicWithStrLen(string FileName, ulong FileNameLength, int PlayType);
		public static int PlayMusicWithStrLen(string FileName, ulong FileNameLength, int PlayType) => dx_PlayMusicWithStrLen(FileName, FileNameLength, PlayType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlayMusicByMemImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlayMusicByMemImage(System.IntPtr FileImage, ulong FileImageSize, int PlayType);
		public static int PlayMusicByMemImage(System.IntPtr FileImage, ulong FileImageSize, int PlayType) => dx_PlayMusicByMemImage(FileImage, FileImageSize, PlayType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetVolumeMusic", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetVolumeMusic(int Volume);
		public static int SetVolumeMusic(int Volume) => dx_SetVolumeMusic(Volume);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_StopMusic", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_StopMusic();
		public static int StopMusic() => dx_StopMusic();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckMusic", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckMusic();
		public static int CheckMusic() => dx_CheckMusic();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMusicPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMusicPosition();
		public static int GetMusicPosition() => dx_GetMusicPosition();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SelectMidiMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SelectMidiMode(int Mode);
		public static int SelectMidiMode(int Mode) => dx_SelectMidiMode(Mode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDXArchiveFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDXArchiveFlag(int Flag);
		public static int SetUseDXArchiveFlag(int Flag) => dx_SetUseDXArchiveFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDXArchivePriority", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDXArchivePriority(int Priority);
		public static int SetDXArchivePriority(int Priority = 0) => dx_SetDXArchivePriority(Priority);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDXArchiveExtension", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDXArchiveExtension(string Extension);
		public static int SetDXArchiveExtension(string Extension = default) => dx_SetDXArchiveExtension(Extension);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDXArchiveExtensionWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDXArchiveExtensionWithStrLen(string Extension, ulong ExtensionLength);
		public static int SetDXArchiveExtensionWithStrLen(string Extension = default, ulong ExtensionLength = 0) => dx_SetDXArchiveExtensionWithStrLen(Extension, ExtensionLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDXArchiveKeyString", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDXArchiveKeyString(string KeyString);
		public static int SetDXArchiveKeyString(string KeyString = default) => dx_SetDXArchiveKeyString(KeyString);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDXArchiveKeyStringWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDXArchiveKeyStringWithStrLen(string KeyString, ulong KeyStringLength);
		public static int SetDXArchiveKeyStringWithStrLen(string KeyString = default, ulong KeyStringLength = 0) => dx_SetDXArchiveKeyStringWithStrLen(KeyString, KeyStringLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DXArchivePreLoad", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DXArchivePreLoad(string FilePath, int ASync);
		public static int DXArchivePreLoad(string FilePath, int ASync = FALSE) => dx_DXArchivePreLoad(FilePath, ASync);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DXArchivePreLoadWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DXArchivePreLoadWithStrLen(string FilePath, ulong FilePathLength, int ASync);
		public static int DXArchivePreLoadWithStrLen(string FilePath, ulong FilePathLength, int ASync = FALSE) => dx_DXArchivePreLoadWithStrLen(FilePath, FilePathLength, ASync);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DXArchiveCheckIdle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DXArchiveCheckIdle(string FilePath);
		public static int DXArchiveCheckIdle(string FilePath) => dx_DXArchiveCheckIdle(FilePath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DXArchiveCheckIdleWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DXArchiveCheckIdleWithStrLen(string FilePath, ulong FilePathLength);
		public static int DXArchiveCheckIdleWithStrLen(string FilePath, ulong FilePathLength) => dx_DXArchiveCheckIdleWithStrLen(FilePath, FilePathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DXArchiveRelease", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DXArchiveRelease(string FilePath);
		public static int DXArchiveRelease(string FilePath) => dx_DXArchiveRelease(FilePath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DXArchiveReleaseWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DXArchiveReleaseWithStrLen(string FilePath, ulong FilePathLength);
		public static int DXArchiveReleaseWithStrLen(string FilePath, ulong FilePathLength) => dx_DXArchiveReleaseWithStrLen(FilePath, FilePathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DXArchiveCheckFile", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DXArchiveCheckFile(string FilePath, string TargetFilePath);
		public static int DXArchiveCheckFile(string FilePath, string TargetFilePath) => dx_DXArchiveCheckFile(FilePath, TargetFilePath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DXArchiveCheckFileWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DXArchiveCheckFileWithStrLen(string FilePath, ulong FilePathLength, string TargetFilePath, ulong TargetFilePathLength);
		public static int DXArchiveCheckFileWithStrLen(string FilePath, ulong FilePathLength, string TargetFilePath, ulong TargetFilePathLength) => dx_DXArchiveCheckFileWithStrLen(FilePath, FilePathLength, TargetFilePath, TargetFilePathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DXArchiveSetMemImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DXArchiveSetMemImage(System.IntPtr ArchiveImage, int ArchiveImageSize, string EmulateFilePath, int ArchiveImageCopyFlag, int ArchiveImageReadOnly);
		public static int DXArchiveSetMemImage(System.IntPtr ArchiveImage, int ArchiveImageSize, string EmulateFilePath, int ArchiveImageCopyFlag = FALSE, int ArchiveImageReadOnly = TRUE) => dx_DXArchiveSetMemImage(ArchiveImage, ArchiveImageSize, EmulateFilePath, ArchiveImageCopyFlag, ArchiveImageReadOnly);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DXArchiveSetMemImageWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DXArchiveSetMemImageWithStrLen(System.IntPtr ArchiveImage, int ArchiveImageSize, string EmulateFilePath, ulong EmulateFilePathLength, int ArchiveImageCopyFlag, int ArchiveImageReadOnly);
		public static int DXArchiveSetMemImageWithStrLen(System.IntPtr ArchiveImage, int ArchiveImageSize, string EmulateFilePath, ulong EmulateFilePathLength, int ArchiveImageCopyFlag = FALSE, int ArchiveImageReadOnly = TRUE) => dx_DXArchiveSetMemImageWithStrLen(ArchiveImage, ArchiveImageSize, EmulateFilePath, EmulateFilePathLength, ArchiveImageCopyFlag, ArchiveImageReadOnly);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DXArchiveReleaseMemImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DXArchiveReleaseMemImage(System.IntPtr ArchiveImage);
		public static int DXArchiveReleaseMemImage(System.IntPtr ArchiveImage) => dx_DXArchiveReleaseMemImage(ArchiveImage);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_HashCRC32", CallingConvention=CallingConvention.StdCall)]
		extern static uint dx_HashCRC32(System.IntPtr SrcData, ulong SrcDataSize);
		public static uint HashCRC32(System.IntPtr SrcData, ulong SrcDataSize) => dx_HashCRC32(SrcData, SrcDataSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1LoadModel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1LoadModel(string FileName);
		public static int MV1LoadModel(string FileName) => dx_MV1LoadModel(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1LoadModelWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1LoadModelWithStrLen(string FileName, ulong FileNameLength);
		public static int MV1LoadModelWithStrLen(string FileName, ulong FileNameLength) => dx_MV1LoadModelWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1DuplicateModel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1DuplicateModel(int SrcMHandle);
		public static int MV1DuplicateModel(int SrcMHandle) => dx_MV1DuplicateModel(SrcMHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1CreateCloneModel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1CreateCloneModel(int SrcMHandle);
		public static int MV1CreateCloneModel(int SrcMHandle) => dx_MV1CreateCloneModel(SrcMHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1DeleteModel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1DeleteModel(int MHandle);
		public static int MV1DeleteModel(int MHandle) => dx_MV1DeleteModel(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1InitModel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1InitModel();
		public static int MV1InitModel() => dx_MV1InitModel();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelReMakeNormal", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelReMakeNormal(int Flag);
		public static int MV1SetLoadModelReMakeNormal(int Flag) => dx_MV1SetLoadModelReMakeNormal(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelReMakeNormalSmoothingAngle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelReMakeNormalSmoothingAngle(float SmoothingAngle);
		public static int MV1SetLoadModelReMakeNormalSmoothingAngle(float SmoothingAngle = default) => dx_MV1SetLoadModelReMakeNormalSmoothingAngle(SmoothingAngle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelIgnoreScaling", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelIgnoreScaling(int Flag);
		public static int MV1SetLoadModelIgnoreScaling(int Flag) => dx_MV1SetLoadModelIgnoreScaling(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelPositionOptimize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelPositionOptimize(int Flag);
		public static int MV1SetLoadModelPositionOptimize(int Flag) => dx_MV1SetLoadModelPositionOptimize(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelNotEqNormalSide_AddZeroAreaPolygon", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelNotEqNormalSide_AddZeroAreaPolygon(int Flag);
		public static int MV1SetLoadModelNotEqNormalSide_AddZeroAreaPolygon(int Flag) => dx_MV1SetLoadModelNotEqNormalSide_AddZeroAreaPolygon(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelUsePhysicsMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelUsePhysicsMode(int PhysicsMode);
		public static int MV1SetLoadModelUsePhysicsMode(int PhysicsMode) => dx_MV1SetLoadModelUsePhysicsMode(PhysicsMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelPhysicsWorldGravity", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelPhysicsWorldGravity(float Gravity);
		public static int MV1SetLoadModelPhysicsWorldGravity(float Gravity) => dx_MV1SetLoadModelPhysicsWorldGravity(Gravity);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetLoadModelPhysicsWorldGravity", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetLoadModelPhysicsWorldGravity();
		public static float MV1GetLoadModelPhysicsWorldGravity() => dx_MV1GetLoadModelPhysicsWorldGravity();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadCalcPhysicsWorldGravity", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadCalcPhysicsWorldGravity(int GravityNo, VECTOR Gravity);
		public static int MV1SetLoadCalcPhysicsWorldGravity(int GravityNo, VECTOR Gravity) => dx_MV1SetLoadCalcPhysicsWorldGravity(GravityNo, Gravity);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetLoadCalcPhysicsWorldGravity", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetLoadCalcPhysicsWorldGravity(int GravityNo);
		public static VECTOR MV1GetLoadCalcPhysicsWorldGravity(int GravityNo) => dx_MV1GetLoadCalcPhysicsWorldGravity(GravityNo);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelPhysicsCalcPrecision", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelPhysicsCalcPrecision(int Precision);
		public static int MV1SetLoadModelPhysicsCalcPrecision(int Precision) => dx_MV1SetLoadModelPhysicsCalcPrecision(Precision);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModel_PMD_PMX_AnimationFPSMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModel_PMD_PMX_AnimationFPSMode(int FPSMode);
		public static int MV1SetLoadModel_PMD_PMX_AnimationFPSMode(int FPSMode) => dx_MV1SetLoadModel_PMD_PMX_AnimationFPSMode(FPSMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1AddLoadModelDisablePhysicsNameWord", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1AddLoadModelDisablePhysicsNameWord(string NameWord);
		public static int MV1AddLoadModelDisablePhysicsNameWord(string NameWord) => dx_MV1AddLoadModelDisablePhysicsNameWord(NameWord);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1AddLoadModelDisablePhysicsNameWordWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1AddLoadModelDisablePhysicsNameWordWithStrLen(string NameWord, ulong NameWordLength);
		public static int MV1AddLoadModelDisablePhysicsNameWordWithStrLen(string NameWord, ulong NameWordLength) => dx_MV1AddLoadModelDisablePhysicsNameWordWithStrLen(NameWord, NameWordLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1ResetLoadModelDisablePhysicsNameWord", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1ResetLoadModelDisablePhysicsNameWord();
		public static int MV1ResetLoadModelDisablePhysicsNameWord() => dx_MV1ResetLoadModelDisablePhysicsNameWord();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelDisablePhysicsNameWordMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelDisablePhysicsNameWordMode(int DisableNameWordMode);
		public static int MV1SetLoadModelDisablePhysicsNameWordMode(int DisableNameWordMode) => dx_MV1SetLoadModelDisablePhysicsNameWordMode(DisableNameWordMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelAnimFilePath", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelAnimFilePath(string FileName);
		public static int MV1SetLoadModelAnimFilePath(string FileName) => dx_MV1SetLoadModelAnimFilePath(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelAnimFilePathWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelAnimFilePathWithStrLen(string FileName, ulong FileNameLength);
		public static int MV1SetLoadModelAnimFilePathWithStrLen(string FileName, ulong FileNameLength) => dx_MV1SetLoadModelAnimFilePathWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelUsePackDraw", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelUsePackDraw(int Flag);
		public static int MV1SetLoadModelUsePackDraw(int Flag) => dx_MV1SetLoadModelUsePackDraw(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetLoadModelTriangleListUseMaxBoneNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetLoadModelTriangleListUseMaxBoneNum(int UseMaxBoneNum);
		public static int MV1SetLoadModelTriangleListUseMaxBoneNum(int UseMaxBoneNum) => dx_MV1SetLoadModelTriangleListUseMaxBoneNum(UseMaxBoneNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SaveModelToMV1File", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SaveModelToMV1File(int MHandle, string FileName, int SaveType, int AnimMHandle, int AnimNameCheck, int Normal8BitFlag, int Position16BitFlag, int Weight8BitFlag, int Anim16BitFlag);
		public static int MV1SaveModelToMV1File(int MHandle, string FileName, int SaveType = MV1_SAVETYPE_NORMAL, int AnimMHandle = -1, int AnimNameCheck = TRUE, int Normal8BitFlag = 1, int Position16BitFlag = 1, int Weight8BitFlag = 0, int Anim16BitFlag = 1) => dx_MV1SaveModelToMV1File(MHandle, FileName, SaveType, AnimMHandle, AnimNameCheck, Normal8BitFlag, Position16BitFlag, Weight8BitFlag, Anim16BitFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SaveModelToMV1FileWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SaveModelToMV1FileWithStrLen(int MHandle, string FileName, ulong FileNameLength, int SaveType, int AnimMHandle, int AnimNameCheck, int Normal8BitFlag, int Position16BitFlag, int Weight8BitFlag, int Anim16BitFlag);
		public static int MV1SaveModelToMV1FileWithStrLen(int MHandle, string FileName, ulong FileNameLength, int SaveType = MV1_SAVETYPE_NORMAL, int AnimMHandle = -1, int AnimNameCheck = TRUE, int Normal8BitFlag = 1, int Position16BitFlag = 1, int Weight8BitFlag = 0, int Anim16BitFlag = 1) => dx_MV1SaveModelToMV1FileWithStrLen(MHandle, FileName, FileNameLength, SaveType, AnimMHandle, AnimNameCheck, Normal8BitFlag, Position16BitFlag, Weight8BitFlag, Anim16BitFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SaveModelToXFile", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SaveModelToXFile(int MHandle, string FileName, int SaveType, int AnimMHandle, int AnimNameCheck);
		public static int MV1SaveModelToXFile(int MHandle, string FileName, int SaveType = MV1_SAVETYPE_NORMAL, int AnimMHandle = -1, int AnimNameCheck = TRUE) => dx_MV1SaveModelToXFile(MHandle, FileName, SaveType, AnimMHandle, AnimNameCheck);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SaveModelToXFileWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SaveModelToXFileWithStrLen(int MHandle, string FileName, ulong FileNameLength, int SaveType, int AnimMHandle, int AnimNameCheck);
		public static int MV1SaveModelToXFileWithStrLen(int MHandle, string FileName, ulong FileNameLength, int SaveType = MV1_SAVETYPE_NORMAL, int AnimMHandle = -1, int AnimNameCheck = TRUE) => dx_MV1SaveModelToXFileWithStrLen(MHandle, FileName, FileNameLength, SaveType, AnimMHandle, AnimNameCheck);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1DrawModel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1DrawModel(int MHandle);
		public static int MV1DrawModel(int MHandle) => dx_MV1DrawModel(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1DrawFrame", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1DrawFrame(int MHandle, int FrameIndex);
		public static int MV1DrawFrame(int MHandle, int FrameIndex) => dx_MV1DrawFrame(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1DrawMesh", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1DrawMesh(int MHandle, int MeshIndex);
		public static int MV1DrawMesh(int MHandle, int MeshIndex) => dx_MV1DrawMesh(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1DrawTriangleList", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1DrawTriangleList(int MHandle, int TriangleListIndex);
		public static int MV1DrawTriangleList(int MHandle, int TriangleListIndex) => dx_MV1DrawTriangleList(MHandle, TriangleListIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1DrawModelDebug", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1DrawModelDebug(int MHandle, uint Color, int IsNormalLine, float NormalLineLength, int IsPolyLine, int IsCollisionBox);
		public static int MV1DrawModelDebug(int MHandle, uint Color, int IsNormalLine, float NormalLineLength, int IsPolyLine, int IsCollisionBox) => dx_MV1DrawModelDebug(MHandle, Color, IsNormalLine, NormalLineLength, IsPolyLine, IsCollisionBox);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetUseOrigShader", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetUseOrigShader(int UseFlag);
		public static int MV1SetUseOrigShader(int UseFlag) => dx_MV1SetUseOrigShader(UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetSemiTransDrawMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetSemiTransDrawMode(int DrawMode);
		public static int MV1SetSemiTransDrawMode(int DrawMode) => dx_MV1SetSemiTransDrawMode(DrawMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetLocalWorldMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MV1GetLocalWorldMatrix(int MHandle);
		public static MATRIX MV1GetLocalWorldMatrix(int MHandle) => dx_MV1GetLocalWorldMatrix(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetLocalWorldMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MV1GetLocalWorldMatrixD(int MHandle);
		public static MATRIX_D MV1GetLocalWorldMatrixD(int MHandle) => dx_MV1GetLocalWorldMatrixD(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetPosition(int MHandle, VECTOR Position);
		public static int MV1SetPosition(int MHandle, VECTOR Position) => dx_MV1SetPosition(MHandle, Position);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetPositionD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetPositionD(int MHandle, VECTOR_D Position);
		public static int MV1SetPositionD(int MHandle, VECTOR_D Position) => dx_MV1SetPositionD(MHandle, Position);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetPosition", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetPosition(int MHandle);
		public static VECTOR MV1GetPosition(int MHandle) => dx_MV1GetPosition(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetPositionD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_MV1GetPositionD(int MHandle);
		public static VECTOR_D MV1GetPositionD(int MHandle) => dx_MV1GetPositionD(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetScale(int MHandle, VECTOR Scale);
		public static int MV1SetScale(int MHandle, VECTOR Scale) => dx_MV1SetScale(MHandle, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetScale", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetScale(int MHandle);
		public static VECTOR MV1GetScale(int MHandle) => dx_MV1GetScale(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetRotationXYZ", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetRotationXYZ(int MHandle, VECTOR Rotate);
		public static int MV1SetRotationXYZ(int MHandle, VECTOR Rotate) => dx_MV1SetRotationXYZ(MHandle, Rotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetRotationXYZ", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetRotationXYZ(int MHandle);
		public static VECTOR MV1GetRotationXYZ(int MHandle) => dx_MV1GetRotationXYZ(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetRotationZYAxis", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetRotationZYAxis(int MHandle, VECTOR ZAxisDirection, VECTOR YAxisDirection, float ZAxisTwistRotate);
		public static int MV1SetRotationZYAxis(int MHandle, VECTOR ZAxisDirection, VECTOR YAxisDirection, float ZAxisTwistRotate) => dx_MV1SetRotationZYAxis(MHandle, ZAxisDirection, YAxisDirection, ZAxisTwistRotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetRotationYUseDir", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetRotationYUseDir(int MHandle, VECTOR Direction, float OffsetYAngle);
		public static int MV1SetRotationYUseDir(int MHandle, VECTOR Direction, float OffsetYAngle) => dx_MV1SetRotationYUseDir(MHandle, Direction, OffsetYAngle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetRotationMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetRotationMatrix(int MHandle, MATRIX Matrix);
		public static int MV1SetRotationMatrix(int MHandle, MATRIX Matrix) => dx_MV1SetRotationMatrix(MHandle, Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetRotationMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MV1GetRotationMatrix(int MHandle);
		public static MATRIX MV1GetRotationMatrix(int MHandle) => dx_MV1GetRotationMatrix(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMatrix(int MHandle, MATRIX Matrix);
		public static int MV1SetMatrix(int MHandle, MATRIX Matrix) => dx_MV1SetMatrix(MHandle, Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMatrixD(int MHandle, MATRIX_D Matrix);
		public static int MV1SetMatrixD(int MHandle, MATRIX_D Matrix) => dx_MV1SetMatrixD(MHandle, Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MV1GetMatrix(int MHandle);
		public static MATRIX MV1GetMatrix(int MHandle) => dx_MV1GetMatrix(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MV1GetMatrixD(int MHandle);
		public static MATRIX_D MV1GetMatrixD(int MHandle) => dx_MV1GetMatrixD(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetVisible", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetVisible(int MHandle, int VisibleFlag);
		public static int MV1SetVisible(int MHandle, int VisibleFlag) => dx_MV1SetVisible(MHandle, VisibleFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetVisible", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetVisible(int MHandle);
		public static int MV1GetVisible(int MHandle) => dx_MV1GetVisible(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshCategoryVisible", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshCategoryVisible(int MHandle, int MeshCategory, int VisibleFlag);
		public static int MV1SetMeshCategoryVisible(int MHandle, int MeshCategory, int VisibleFlag) => dx_MV1SetMeshCategoryVisible(MHandle, MeshCategory, VisibleFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshCategoryVisible", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshCategoryVisible(int MHandle, int MeshCategory);
		public static int MV1GetMeshCategoryVisible(int MHandle, int MeshCategory) => dx_MV1GetMeshCategoryVisible(MHandle, MeshCategory);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetDifColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetDifColorScale(int MHandle, COLOR_F Scale);
		public static int MV1SetDifColorScale(int MHandle, COLOR_F Scale) => dx_MV1SetDifColorScale(MHandle, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetDifColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetDifColorScale(int MHandle);
		public static COLOR_F MV1GetDifColorScale(int MHandle) => dx_MV1GetDifColorScale(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetSpcColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetSpcColorScale(int MHandle, COLOR_F Scale);
		public static int MV1SetSpcColorScale(int MHandle, COLOR_F Scale) => dx_MV1SetSpcColorScale(MHandle, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetSpcColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetSpcColorScale(int MHandle);
		public static COLOR_F MV1GetSpcColorScale(int MHandle) => dx_MV1GetSpcColorScale(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetEmiColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetEmiColorScale(int MHandle, COLOR_F Scale);
		public static int MV1SetEmiColorScale(int MHandle, COLOR_F Scale) => dx_MV1SetEmiColorScale(MHandle, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetEmiColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetEmiColorScale(int MHandle);
		public static COLOR_F MV1GetEmiColorScale(int MHandle) => dx_MV1GetEmiColorScale(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetAmbColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetAmbColorScale(int MHandle, COLOR_F Scale);
		public static int MV1SetAmbColorScale(int MHandle, COLOR_F Scale) => dx_MV1SetAmbColorScale(MHandle, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAmbColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetAmbColorScale(int MHandle);
		public static COLOR_F MV1GetAmbColorScale(int MHandle) => dx_MV1GetAmbColorScale(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetSemiTransState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetSemiTransState(int MHandle);
		public static int MV1GetSemiTransState(int MHandle) => dx_MV1GetSemiTransState(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetOpacityRate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetOpacityRate(int MHandle, float Rate);
		public static int MV1SetOpacityRate(int MHandle, float Rate) => dx_MV1SetOpacityRate(MHandle, Rate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetOpacityRate", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetOpacityRate(int MHandle);
		public static float MV1GetOpacityRate(int MHandle) => dx_MV1GetOpacityRate(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetUseDrawMulAlphaColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetUseDrawMulAlphaColor(int MHandle, int Flag);
		public static int MV1SetUseDrawMulAlphaColor(int MHandle, int Flag) => dx_MV1SetUseDrawMulAlphaColor(MHandle, Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetUseDrawMulAlphaColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetUseDrawMulAlphaColor(int MHandle);
		public static int MV1GetUseDrawMulAlphaColor(int MHandle) => dx_MV1GetUseDrawMulAlphaColor(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetUseZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetUseZBuffer(int MHandle, int Flag);
		public static int MV1SetUseZBuffer(int MHandle, int Flag) => dx_MV1SetUseZBuffer(MHandle, Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetWriteZBuffer", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetWriteZBuffer(int MHandle, int Flag);
		public static int MV1SetWriteZBuffer(int MHandle, int Flag) => dx_MV1SetWriteZBuffer(MHandle, Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetZBufferCmpType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetZBufferCmpType(int MHandle, int CmpType);
		public static int MV1SetZBufferCmpType(int MHandle, int CmpType) => dx_MV1SetZBufferCmpType(MHandle, CmpType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetZBias", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetZBias(int MHandle, int Bias);
		public static int MV1SetZBias(int MHandle, int Bias) => dx_MV1SetZBias(MHandle, Bias);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetUseVertDifColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetUseVertDifColor(int MHandle, int UseFlag);
		public static int MV1SetUseVertDifColor(int MHandle, int UseFlag) => dx_MV1SetUseVertDifColor(MHandle, UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetUseVertSpcColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetUseVertSpcColor(int MHandle, int UseFlag);
		public static int MV1SetUseVertSpcColor(int MHandle, int UseFlag) => dx_MV1SetUseVertSpcColor(MHandle, UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetSampleFilterMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetSampleFilterMode(int MHandle, int FilterMode);
		public static int MV1SetSampleFilterMode(int MHandle, int FilterMode) => dx_MV1SetSampleFilterMode(MHandle, FilterMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaxAnisotropy", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaxAnisotropy(int MHandle, int MaxAnisotropy);
		public static int MV1SetMaxAnisotropy(int MHandle, int MaxAnisotropy) => dx_MV1SetMaxAnisotropy(MHandle, MaxAnisotropy);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetWireFrameDrawFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetWireFrameDrawFlag(int MHandle, int Flag);
		public static int MV1SetWireFrameDrawFlag(int MHandle, int Flag) => dx_MV1SetWireFrameDrawFlag(MHandle, Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1RefreshVertColorFromMaterial", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1RefreshVertColorFromMaterial(int MHandle);
		public static int MV1RefreshVertColorFromMaterial(int MHandle) => dx_MV1RefreshVertColorFromMaterial(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetPhysicsWorldGravity", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetPhysicsWorldGravity(int MHandle, VECTOR Gravity);
		public static int MV1SetPhysicsWorldGravity(int MHandle, VECTOR Gravity) => dx_MV1SetPhysicsWorldGravity(MHandle, Gravity);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1PhysicsCalculation", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1PhysicsCalculation(int MHandle, float MillisecondTime);
		public static int MV1PhysicsCalculation(int MHandle, float MillisecondTime) => dx_MV1PhysicsCalculation(MHandle, MillisecondTime);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1PhysicsResetState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1PhysicsResetState(int MHandle);
		public static int MV1PhysicsResetState(int MHandle) => dx_MV1PhysicsResetState(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetUseShapeFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetUseShapeFlag(int MHandle, int UseFlag);
		public static int MV1SetUseShapeFlag(int MHandle, int UseFlag) => dx_MV1SetUseShapeFlag(MHandle, UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialNumberOrderFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialNumberOrderFlag(int MHandle);
		public static int MV1GetMaterialNumberOrderFlag(int MHandle) => dx_MV1GetMaterialNumberOrderFlag(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1AttachAnim", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1AttachAnim(int MHandle, int AnimIndex, int AnimSrcMHandle, int NameCheck);
		public static int MV1AttachAnim(int MHandle, int AnimIndex, int AnimSrcMHandle = -1, int NameCheck = TRUE) => dx_MV1AttachAnim(MHandle, AnimIndex, AnimSrcMHandle, NameCheck);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1DetachAnim", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1DetachAnim(int MHandle, int AttachIndex);
		public static int MV1DetachAnim(int MHandle, int AttachIndex) => dx_MV1DetachAnim(MHandle, AttachIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetAttachAnimTime", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetAttachAnimTime(int MHandle, int AttachIndex, float Time);
		public static int MV1SetAttachAnimTime(int MHandle, int AttachIndex, float Time) => dx_MV1SetAttachAnimTime(MHandle, AttachIndex, Time);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAttachAnimTime", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetAttachAnimTime(int MHandle, int AttachIndex);
		public static float MV1GetAttachAnimTime(int MHandle, int AttachIndex) => dx_MV1GetAttachAnimTime(MHandle, AttachIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAttachAnimTotalTime", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetAttachAnimTotalTime(int MHandle, int AttachIndex);
		public static float MV1GetAttachAnimTotalTime(int MHandle, int AttachIndex) => dx_MV1GetAttachAnimTotalTime(MHandle, AttachIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetAttachAnimBlendRate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetAttachAnimBlendRate(int MHandle, int AttachIndex, float Rate);
		public static int MV1SetAttachAnimBlendRate(int MHandle, int AttachIndex, float Rate = default) => dx_MV1SetAttachAnimBlendRate(MHandle, AttachIndex, Rate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAttachAnimBlendRate", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetAttachAnimBlendRate(int MHandle, int AttachIndex);
		public static float MV1GetAttachAnimBlendRate(int MHandle, int AttachIndex) => dx_MV1GetAttachAnimBlendRate(MHandle, AttachIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetAttachAnimBlendRateToFrame", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetAttachAnimBlendRateToFrame(int MHandle, int AttachIndex, int FrameIndex, float Rate, int SetChild);
		public static int MV1SetAttachAnimBlendRateToFrame(int MHandle, int AttachIndex, int FrameIndex, float Rate, int SetChild = TRUE) => dx_MV1SetAttachAnimBlendRateToFrame(MHandle, AttachIndex, FrameIndex, Rate, SetChild);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAttachAnimBlendRateToFrame", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetAttachAnimBlendRateToFrame(int MHandle, int AttachIndex, int FrameIndex);
		public static float MV1GetAttachAnimBlendRateToFrame(int MHandle, int AttachIndex, int FrameIndex) => dx_MV1GetAttachAnimBlendRateToFrame(MHandle, AttachIndex, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAttachAnim", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAttachAnim(int MHandle, int AttachIndex);
		public static int MV1GetAttachAnim(int MHandle, int AttachIndex) => dx_MV1GetAttachAnim(MHandle, AttachIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetAttachAnimUseShapeFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetAttachAnimUseShapeFlag(int MHandle, int AttachIndex, int UseFlag);
		public static int MV1SetAttachAnimUseShapeFlag(int MHandle, int AttachIndex, int UseFlag) => dx_MV1SetAttachAnimUseShapeFlag(MHandle, AttachIndex, UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAttachAnimUseShapeFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAttachAnimUseShapeFlag(int MHandle, int AttachIndex);
		public static int MV1GetAttachAnimUseShapeFlag(int MHandle, int AttachIndex) => dx_MV1GetAttachAnimUseShapeFlag(MHandle, AttachIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAttachAnimFrameLocalPosition", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetAttachAnimFrameLocalPosition(int MHandle, int AttachIndex, int FrameIndex);
		public static VECTOR MV1GetAttachAnimFrameLocalPosition(int MHandle, int AttachIndex, int FrameIndex) => dx_MV1GetAttachAnimFrameLocalPosition(MHandle, AttachIndex, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAttachAnimFrameLocalMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MV1GetAttachAnimFrameLocalMatrix(int MHandle, int AttachIndex, int FrameIndex);
		public static MATRIX MV1GetAttachAnimFrameLocalMatrix(int MHandle, int AttachIndex, int FrameIndex) => dx_MV1GetAttachAnimFrameLocalMatrix(MHandle, AttachIndex, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimNum(int MHandle);
		public static int MV1GetAnimNum(int MHandle) => dx_MV1GetAnimNum(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_MV1GetAnimName(int MHandle, int AnimIndex);
		public static string MV1GetAnimName(int MHandle, int AnimIndex)
		{
			var resultIntPtr = dx_MV1GetAnimName(MHandle, AnimIndex);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetAnimName", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetAnimName(int MHandle, int AnimIndex, string AnimName);
		public static int MV1SetAnimName(int MHandle, int AnimIndex, string AnimName) => dx_MV1SetAnimName(MHandle, AnimIndex, AnimName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetAnimNameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetAnimNameWithStrLen(int MHandle, int AnimIndex, string AnimName, ulong AnimNameLength);
		public static int MV1SetAnimNameWithStrLen(int MHandle, int AnimIndex, string AnimName, ulong AnimNameLength) => dx_MV1SetAnimNameWithStrLen(MHandle, AnimIndex, AnimName, AnimNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimIndex", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimIndex(int MHandle, string AnimName);
		public static int MV1GetAnimIndex(int MHandle, string AnimName) => dx_MV1GetAnimIndex(MHandle, AnimName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimIndexWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimIndexWithStrLen(int MHandle, string AnimName, ulong AnimNameLength);
		public static int MV1GetAnimIndexWithStrLen(int MHandle, string AnimName, ulong AnimNameLength) => dx_MV1GetAnimIndexWithStrLen(MHandle, AnimName, AnimNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimTotalTime", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetAnimTotalTime(int MHandle, int AnimIndex);
		public static float MV1GetAnimTotalTime(int MHandle, int AnimIndex) => dx_MV1GetAnimTotalTime(MHandle, AnimIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimTargetFrameNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimTargetFrameNum(int MHandle, int AnimIndex);
		public static int MV1GetAnimTargetFrameNum(int MHandle, int AnimIndex) => dx_MV1GetAnimTargetFrameNum(MHandle, AnimIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimTargetFrameName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_MV1GetAnimTargetFrameName(int MHandle, int AnimIndex, int AnimFrameIndex);
		public static string MV1GetAnimTargetFrameName(int MHandle, int AnimIndex, int AnimFrameIndex)
		{
			var resultIntPtr = dx_MV1GetAnimTargetFrameName(MHandle, AnimIndex, AnimFrameIndex);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimTargetFrame", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimTargetFrame(int MHandle, int AnimIndex, int AnimFrameIndex);
		public static int MV1GetAnimTargetFrame(int MHandle, int AnimIndex, int AnimFrameIndex) => dx_MV1GetAnimTargetFrame(MHandle, AnimIndex, AnimFrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimTargetFrameKeySetNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimTargetFrameKeySetNum(int MHandle, int AnimIndex, int AnimFrameIndex);
		public static int MV1GetAnimTargetFrameKeySetNum(int MHandle, int AnimIndex, int AnimFrameIndex) => dx_MV1GetAnimTargetFrameKeySetNum(MHandle, AnimIndex, AnimFrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimTargetFrameKeySet", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimTargetFrameKeySet(int MHandle, int AnimIndex, int AnimFrameIndex, int Index);
		public static int MV1GetAnimTargetFrameKeySet(int MHandle, int AnimIndex, int AnimFrameIndex, int Index) => dx_MV1GetAnimTargetFrameKeySet(MHandle, AnimIndex, AnimFrameIndex, Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeySetNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimKeySetNum(int MHandle);
		public static int MV1GetAnimKeySetNum(int MHandle) => dx_MV1GetAnimKeySetNum(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeySetType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimKeySetType(int MHandle, int AnimKeySetIndex);
		public static int MV1GetAnimKeySetType(int MHandle, int AnimKeySetIndex) => dx_MV1GetAnimKeySetType(MHandle, AnimKeySetIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeySetDataType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimKeySetDataType(int MHandle, int AnimKeySetIndex);
		public static int MV1GetAnimKeySetDataType(int MHandle, int AnimKeySetIndex) => dx_MV1GetAnimKeySetDataType(MHandle, AnimKeySetIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeySetTimeType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimKeySetTimeType(int MHandle, int AnimKeySetIndex);
		public static int MV1GetAnimKeySetTimeType(int MHandle, int AnimKeySetIndex) => dx_MV1GetAnimKeySetTimeType(MHandle, AnimKeySetIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeySetDataNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimKeySetDataNum(int MHandle, int AnimKeySetIndex);
		public static int MV1GetAnimKeySetDataNum(int MHandle, int AnimKeySetIndex) => dx_MV1GetAnimKeySetDataNum(MHandle, AnimKeySetIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeyDataTime", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetAnimKeyDataTime(int MHandle, int AnimKeySetIndex, int Index);
		public static float MV1GetAnimKeyDataTime(int MHandle, int AnimKeySetIndex, int Index) => dx_MV1GetAnimKeyDataTime(MHandle, AnimKeySetIndex, Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeyDataIndexFromTime", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetAnimKeyDataIndexFromTime(int MHandle, int AnimKeySetIndex, float Time);
		public static int MV1GetAnimKeyDataIndexFromTime(int MHandle, int AnimKeySetIndex, float Time) => dx_MV1GetAnimKeyDataIndexFromTime(MHandle, AnimKeySetIndex, Time);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeyDataToQuaternion", CallingConvention=CallingConvention.StdCall)]
		extern static FLOAT4 dx_MV1GetAnimKeyDataToQuaternion(int MHandle, int AnimKeySetIndex, int Index);
		public static FLOAT4 MV1GetAnimKeyDataToQuaternion(int MHandle, int AnimKeySetIndex, int Index) => dx_MV1GetAnimKeyDataToQuaternion(MHandle, AnimKeySetIndex, Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeyDataToQuaternionFromTime", CallingConvention=CallingConvention.StdCall)]
		extern static FLOAT4 dx_MV1GetAnimKeyDataToQuaternionFromTime(int MHandle, int AnimKeySetIndex, float Time);
		public static FLOAT4 MV1GetAnimKeyDataToQuaternionFromTime(int MHandle, int AnimKeySetIndex, float Time) => dx_MV1GetAnimKeyDataToQuaternionFromTime(MHandle, AnimKeySetIndex, Time);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeyDataToVector", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetAnimKeyDataToVector(int MHandle, int AnimKeySetIndex, int Index);
		public static VECTOR MV1GetAnimKeyDataToVector(int MHandle, int AnimKeySetIndex, int Index) => dx_MV1GetAnimKeyDataToVector(MHandle, AnimKeySetIndex, Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeyDataToVectorFromTime", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetAnimKeyDataToVectorFromTime(int MHandle, int AnimKeySetIndex, float Time);
		public static VECTOR MV1GetAnimKeyDataToVectorFromTime(int MHandle, int AnimKeySetIndex, float Time) => dx_MV1GetAnimKeyDataToVectorFromTime(MHandle, AnimKeySetIndex, Time);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeyDataToMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MV1GetAnimKeyDataToMatrix(int MHandle, int AnimKeySetIndex, int Index);
		public static MATRIX MV1GetAnimKeyDataToMatrix(int MHandle, int AnimKeySetIndex, int Index) => dx_MV1GetAnimKeyDataToMatrix(MHandle, AnimKeySetIndex, Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeyDataToMatrixFromTime", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MV1GetAnimKeyDataToMatrixFromTime(int MHandle, int AnimKeySetIndex, float Time);
		public static MATRIX MV1GetAnimKeyDataToMatrixFromTime(int MHandle, int AnimKeySetIndex, float Time) => dx_MV1GetAnimKeyDataToMatrixFromTime(MHandle, AnimKeySetIndex, Time);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeyDataToFlat", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetAnimKeyDataToFlat(int MHandle, int AnimKeySetIndex, int Index);
		public static float MV1GetAnimKeyDataToFlat(int MHandle, int AnimKeySetIndex, int Index) => dx_MV1GetAnimKeyDataToFlat(MHandle, AnimKeySetIndex, Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeyDataToFlatFromTime", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetAnimKeyDataToFlatFromTime(int MHandle, int AnimKeySetIndex, float Time);
		public static float MV1GetAnimKeyDataToFlatFromTime(int MHandle, int AnimKeySetIndex, float Time) => dx_MV1GetAnimKeyDataToFlatFromTime(MHandle, AnimKeySetIndex, Time);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeyDataToLinear", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetAnimKeyDataToLinear(int MHandle, int AnimKeySetIndex, int Index);
		public static float MV1GetAnimKeyDataToLinear(int MHandle, int AnimKeySetIndex, int Index) => dx_MV1GetAnimKeyDataToLinear(MHandle, AnimKeySetIndex, Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetAnimKeyDataToLinearFromTime", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetAnimKeyDataToLinearFromTime(int MHandle, int AnimKeySetIndex, float Time);
		public static float MV1GetAnimKeyDataToLinearFromTime(int MHandle, int AnimKeySetIndex, float Time) => dx_MV1GetAnimKeyDataToLinearFromTime(MHandle, AnimKeySetIndex, Time);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialNum(int MHandle);
		public static int MV1GetMaterialNum(int MHandle) => dx_MV1GetMaterialNum(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_MV1GetMaterialName(int MHandle, int MaterialIndex);
		public static string MV1GetMaterialName(int MHandle, int MaterialIndex)
		{
			var resultIntPtr = dx_MV1GetMaterialName(MHandle, MaterialIndex);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialTypeAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialTypeAll(int MHandle, int Type);
		public static int MV1SetMaterialTypeAll(int MHandle, int Type) => dx_MV1SetMaterialTypeAll(MHandle, Type);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialType(int MHandle, int MaterialIndex, int Type);
		public static int MV1SetMaterialType(int MHandle, int MaterialIndex, int Type) => dx_MV1SetMaterialType(MHandle, MaterialIndex, Type);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialType(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialType(int MHandle, int MaterialIndex) => dx_MV1GetMaterialType(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialDifColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialDifColor(int MHandle, int MaterialIndex, COLOR_F Color);
		public static int MV1SetMaterialDifColor(int MHandle, int MaterialIndex, COLOR_F Color) => dx_MV1SetMaterialDifColor(MHandle, MaterialIndex, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialDifColor", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetMaterialDifColor(int MHandle, int MaterialIndex);
		public static COLOR_F MV1GetMaterialDifColor(int MHandle, int MaterialIndex) => dx_MV1GetMaterialDifColor(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialSpcColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialSpcColor(int MHandle, int MaterialIndex, COLOR_F Color);
		public static int MV1SetMaterialSpcColor(int MHandle, int MaterialIndex, COLOR_F Color) => dx_MV1SetMaterialSpcColor(MHandle, MaterialIndex, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialSpcColor", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetMaterialSpcColor(int MHandle, int MaterialIndex);
		public static COLOR_F MV1GetMaterialSpcColor(int MHandle, int MaterialIndex) => dx_MV1GetMaterialSpcColor(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialEmiColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialEmiColor(int MHandle, int MaterialIndex, COLOR_F Color);
		public static int MV1SetMaterialEmiColor(int MHandle, int MaterialIndex, COLOR_F Color) => dx_MV1SetMaterialEmiColor(MHandle, MaterialIndex, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialEmiColor", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetMaterialEmiColor(int MHandle, int MaterialIndex);
		public static COLOR_F MV1GetMaterialEmiColor(int MHandle, int MaterialIndex) => dx_MV1GetMaterialEmiColor(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialAmbColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialAmbColor(int MHandle, int MaterialIndex, COLOR_F Color);
		public static int MV1SetMaterialAmbColor(int MHandle, int MaterialIndex, COLOR_F Color) => dx_MV1SetMaterialAmbColor(MHandle, MaterialIndex, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialAmbColor", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetMaterialAmbColor(int MHandle, int MaterialIndex);
		public static COLOR_F MV1GetMaterialAmbColor(int MHandle, int MaterialIndex) => dx_MV1GetMaterialAmbColor(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialSpcPower", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialSpcPower(int MHandle, int MaterialIndex, float Power);
		public static int MV1SetMaterialSpcPower(int MHandle, int MaterialIndex, float Power) => dx_MV1SetMaterialSpcPower(MHandle, MaterialIndex, Power);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialSpcPower", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetMaterialSpcPower(int MHandle, int MaterialIndex);
		public static float MV1GetMaterialSpcPower(int MHandle, int MaterialIndex) => dx_MV1GetMaterialSpcPower(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialDifMapTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialDifMapTexture(int MHandle, int MaterialIndex, int TexIndex);
		public static int MV1SetMaterialDifMapTexture(int MHandle, int MaterialIndex, int TexIndex) => dx_MV1SetMaterialDifMapTexture(MHandle, MaterialIndex, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialDifMapTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialDifMapTexture(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialDifMapTexture(int MHandle, int MaterialIndex) => dx_MV1GetMaterialDifMapTexture(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialSubDifMapTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialSubDifMapTexture(int MHandle, int MaterialIndex, int TexIndex);
		public static int MV1SetMaterialSubDifMapTexture(int MHandle, int MaterialIndex, int TexIndex) => dx_MV1SetMaterialSubDifMapTexture(MHandle, MaterialIndex, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialSubDifMapTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialSubDifMapTexture(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialSubDifMapTexture(int MHandle, int MaterialIndex) => dx_MV1GetMaterialSubDifMapTexture(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialSpcMapTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialSpcMapTexture(int MHandle, int MaterialIndex, int TexIndex);
		public static int MV1SetMaterialSpcMapTexture(int MHandle, int MaterialIndex, int TexIndex) => dx_MV1SetMaterialSpcMapTexture(MHandle, MaterialIndex, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialSpcMapTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialSpcMapTexture(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialSpcMapTexture(int MHandle, int MaterialIndex) => dx_MV1GetMaterialSpcMapTexture(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialNormalMapTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialNormalMapTexture(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialNormalMapTexture(int MHandle, int MaterialIndex) => dx_MV1GetMaterialNormalMapTexture(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialDifGradTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialDifGradTexture(int MHandle, int MaterialIndex, int TexIndex);
		public static int MV1SetMaterialDifGradTexture(int MHandle, int MaterialIndex, int TexIndex) => dx_MV1SetMaterialDifGradTexture(MHandle, MaterialIndex, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialDifGradTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialDifGradTexture(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialDifGradTexture(int MHandle, int MaterialIndex) => dx_MV1GetMaterialDifGradTexture(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialSpcGradTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialSpcGradTexture(int MHandle, int MaterialIndex, int TexIndex);
		public static int MV1SetMaterialSpcGradTexture(int MHandle, int MaterialIndex, int TexIndex) => dx_MV1SetMaterialSpcGradTexture(MHandle, MaterialIndex, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialSpcGradTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialSpcGradTexture(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialSpcGradTexture(int MHandle, int MaterialIndex) => dx_MV1GetMaterialSpcGradTexture(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialSphereMapTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialSphereMapTexture(int MHandle, int MaterialIndex, int TexIndex);
		public static int MV1SetMaterialSphereMapTexture(int MHandle, int MaterialIndex, int TexIndex) => dx_MV1SetMaterialSphereMapTexture(MHandle, MaterialIndex, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialSphereMapTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialSphereMapTexture(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialSphereMapTexture(int MHandle, int MaterialIndex) => dx_MV1GetMaterialSphereMapTexture(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialDifGradBlendTypeAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialDifGradBlendTypeAll(int MHandle, int BlendType);
		public static int MV1SetMaterialDifGradBlendTypeAll(int MHandle, int BlendType) => dx_MV1SetMaterialDifGradBlendTypeAll(MHandle, BlendType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialDifGradBlendType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialDifGradBlendType(int MHandle, int MaterialIndex, int BlendType);
		public static int MV1SetMaterialDifGradBlendType(int MHandle, int MaterialIndex, int BlendType) => dx_MV1SetMaterialDifGradBlendType(MHandle, MaterialIndex, BlendType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialDifGradBlendType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialDifGradBlendType(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialDifGradBlendType(int MHandle, int MaterialIndex) => dx_MV1GetMaterialDifGradBlendType(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialSpcGradBlendTypeAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialSpcGradBlendTypeAll(int MHandle, int BlendType);
		public static int MV1SetMaterialSpcGradBlendTypeAll(int MHandle, int BlendType) => dx_MV1SetMaterialSpcGradBlendTypeAll(MHandle, BlendType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialSpcGradBlendType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialSpcGradBlendType(int MHandle, int MaterialIndex, int BlendType);
		public static int MV1SetMaterialSpcGradBlendType(int MHandle, int MaterialIndex, int BlendType) => dx_MV1SetMaterialSpcGradBlendType(MHandle, MaterialIndex, BlendType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialSpcGradBlendType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialSpcGradBlendType(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialSpcGradBlendType(int MHandle, int MaterialIndex) => dx_MV1GetMaterialSpcGradBlendType(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialSphereMapBlendTypeAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialSphereMapBlendTypeAll(int MHandle, int BlendType);
		public static int MV1SetMaterialSphereMapBlendTypeAll(int MHandle, int BlendType) => dx_MV1SetMaterialSphereMapBlendTypeAll(MHandle, BlendType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialSphereMapBlendType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialSphereMapBlendType(int MHandle, int MaterialIndex, int BlendType);
		public static int MV1SetMaterialSphereMapBlendType(int MHandle, int MaterialIndex, int BlendType) => dx_MV1SetMaterialSphereMapBlendType(MHandle, MaterialIndex, BlendType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialSphereMapBlendType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialSphereMapBlendType(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialSphereMapBlendType(int MHandle, int MaterialIndex) => dx_MV1GetMaterialSphereMapBlendType(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialOutLineWidthAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialOutLineWidthAll(int MHandle, float Width);
		public static int MV1SetMaterialOutLineWidthAll(int MHandle, float Width) => dx_MV1SetMaterialOutLineWidthAll(MHandle, Width);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialOutLineWidth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialOutLineWidth(int MHandle, int MaterialIndex, float Width);
		public static int MV1SetMaterialOutLineWidth(int MHandle, int MaterialIndex, float Width) => dx_MV1SetMaterialOutLineWidth(MHandle, MaterialIndex, Width);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialOutLineWidth", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetMaterialOutLineWidth(int MHandle, int MaterialIndex);
		public static float MV1GetMaterialOutLineWidth(int MHandle, int MaterialIndex) => dx_MV1GetMaterialOutLineWidth(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialOutLineDotWidthAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialOutLineDotWidthAll(int MHandle, float Width);
		public static int MV1SetMaterialOutLineDotWidthAll(int MHandle, float Width) => dx_MV1SetMaterialOutLineDotWidthAll(MHandle, Width);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialOutLineDotWidth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialOutLineDotWidth(int MHandle, int MaterialIndex, float Width);
		public static int MV1SetMaterialOutLineDotWidth(int MHandle, int MaterialIndex, float Width) => dx_MV1SetMaterialOutLineDotWidth(MHandle, MaterialIndex, Width);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialOutLineDotWidth", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetMaterialOutLineDotWidth(int MHandle, int MaterialIndex);
		public static float MV1GetMaterialOutLineDotWidth(int MHandle, int MaterialIndex) => dx_MV1GetMaterialOutLineDotWidth(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialOutLineColorAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialOutLineColorAll(int MHandle, COLOR_F Color);
		public static int MV1SetMaterialOutLineColorAll(int MHandle, COLOR_F Color) => dx_MV1SetMaterialOutLineColorAll(MHandle, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialOutLineColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialOutLineColor(int MHandle, int MaterialIndex, COLOR_F Color);
		public static int MV1SetMaterialOutLineColor(int MHandle, int MaterialIndex, COLOR_F Color) => dx_MV1SetMaterialOutLineColor(MHandle, MaterialIndex, Color);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialOutLineColor", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetMaterialOutLineColor(int MHandle, int MaterialIndex);
		public static COLOR_F MV1GetMaterialOutLineColor(int MHandle, int MaterialIndex) => dx_MV1GetMaterialOutLineColor(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialDrawBlendModeAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialDrawBlendModeAll(int MHandle, int BlendMode);
		public static int MV1SetMaterialDrawBlendModeAll(int MHandle, int BlendMode) => dx_MV1SetMaterialDrawBlendModeAll(MHandle, BlendMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialDrawBlendMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialDrawBlendMode(int MHandle, int MaterialIndex, int BlendMode);
		public static int MV1SetMaterialDrawBlendMode(int MHandle, int MaterialIndex, int BlendMode) => dx_MV1SetMaterialDrawBlendMode(MHandle, MaterialIndex, BlendMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialDrawBlendMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialDrawBlendMode(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialDrawBlendMode(int MHandle, int MaterialIndex) => dx_MV1GetMaterialDrawBlendMode(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialDrawBlendParamAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialDrawBlendParamAll(int MHandle, int BlendParam);
		public static int MV1SetMaterialDrawBlendParamAll(int MHandle, int BlendParam) => dx_MV1SetMaterialDrawBlendParamAll(MHandle, BlendParam);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialDrawBlendParam", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialDrawBlendParam(int MHandle, int MaterialIndex, int BlendParam);
		public static int MV1SetMaterialDrawBlendParam(int MHandle, int MaterialIndex, int BlendParam) => dx_MV1SetMaterialDrawBlendParam(MHandle, MaterialIndex, BlendParam);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialDrawBlendParam", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialDrawBlendParam(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialDrawBlendParam(int MHandle, int MaterialIndex) => dx_MV1GetMaterialDrawBlendParam(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialDrawAlphaTestAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialDrawAlphaTestAll(int MHandle, int Enable, int Mode, int Param);
		public static int MV1SetMaterialDrawAlphaTestAll(int MHandle, int Enable, int Mode, int Param) => dx_MV1SetMaterialDrawAlphaTestAll(MHandle, Enable, Mode, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMaterialDrawAlphaTest", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMaterialDrawAlphaTest(int MHandle, int MaterialIndex, int Enable, int Mode, int Param);
		public static int MV1SetMaterialDrawAlphaTest(int MHandle, int MaterialIndex, int Enable, int Mode, int Param) => dx_MV1SetMaterialDrawAlphaTest(MHandle, MaterialIndex, Enable, Mode, Param);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialDrawAlphaTestEnable", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialDrawAlphaTestEnable(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialDrawAlphaTestEnable(int MHandle, int MaterialIndex) => dx_MV1GetMaterialDrawAlphaTestEnable(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialDrawAlphaTestMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialDrawAlphaTestMode(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialDrawAlphaTestMode(int MHandle, int MaterialIndex) => dx_MV1GetMaterialDrawAlphaTestMode(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMaterialDrawAlphaTestParam", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMaterialDrawAlphaTestParam(int MHandle, int MaterialIndex);
		public static int MV1GetMaterialDrawAlphaTestParam(int MHandle, int MaterialIndex) => dx_MV1GetMaterialDrawAlphaTestParam(MHandle, MaterialIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTextureNum(int MHandle);
		public static int MV1GetTextureNum(int MHandle) => dx_MV1GetTextureNum(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_MV1GetTextureName(int MHandle, int TexIndex);
		public static string MV1GetTextureName(int MHandle, int TexIndex)
		{
			var resultIntPtr = dx_MV1GetTextureName(MHandle, TexIndex);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetTextureColorFilePath", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetTextureColorFilePath(int MHandle, int TexIndex, string FilePath);
		public static int MV1SetTextureColorFilePath(int MHandle, int TexIndex, string FilePath) => dx_MV1SetTextureColorFilePath(MHandle, TexIndex, FilePath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetTextureColorFilePathWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetTextureColorFilePathWithStrLen(int MHandle, int TexIndex, string FilePath, ulong FilePathLength);
		public static int MV1SetTextureColorFilePathWithStrLen(int MHandle, int TexIndex, string FilePath, ulong FilePathLength) => dx_MV1SetTextureColorFilePathWithStrLen(MHandle, TexIndex, FilePath, FilePathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureColorFilePath", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_MV1GetTextureColorFilePath(int MHandle, int TexIndex);
		public static string MV1GetTextureColorFilePath(int MHandle, int TexIndex)
		{
			var resultIntPtr = dx_MV1GetTextureColorFilePath(MHandle, TexIndex);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetTextureAlphaFilePath", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetTextureAlphaFilePath(int MHandle, int TexIndex, string FilePath);
		public static int MV1SetTextureAlphaFilePath(int MHandle, int TexIndex, string FilePath) => dx_MV1SetTextureAlphaFilePath(MHandle, TexIndex, FilePath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetTextureAlphaFilePathWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetTextureAlphaFilePathWithStrLen(int MHandle, int TexIndex, string FilePath, ulong FilePathLength);
		public static int MV1SetTextureAlphaFilePathWithStrLen(int MHandle, int TexIndex, string FilePath, ulong FilePathLength) => dx_MV1SetTextureAlphaFilePathWithStrLen(MHandle, TexIndex, FilePath, FilePathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureAlphaFilePath", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_MV1GetTextureAlphaFilePath(int MHandle, int TexIndex);
		public static string MV1GetTextureAlphaFilePath(int MHandle, int TexIndex)
		{
			var resultIntPtr = dx_MV1GetTextureAlphaFilePath(MHandle, TexIndex);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetTextureGraphHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetTextureGraphHandle(int MHandle, int TexIndex, int GrHandle, int SemiTransFlag);
		public static int MV1SetTextureGraphHandle(int MHandle, int TexIndex, int GrHandle, int SemiTransFlag) => dx_MV1SetTextureGraphHandle(MHandle, TexIndex, GrHandle, SemiTransFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureGraphHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTextureGraphHandle(int MHandle, int TexIndex);
		public static int MV1GetTextureGraphHandle(int MHandle, int TexIndex) => dx_MV1GetTextureGraphHandle(MHandle, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetTextureAddressMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetTextureAddressMode(int MHandle, int TexIndex, int AddrUMode, int AddrVMode);
		public static int MV1SetTextureAddressMode(int MHandle, int TexIndex, int AddrUMode, int AddrVMode) => dx_MV1SetTextureAddressMode(MHandle, TexIndex, AddrUMode, AddrVMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureAddressModeU", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTextureAddressModeU(int MHandle, int TexIndex);
		public static int MV1GetTextureAddressModeU(int MHandle, int TexIndex) => dx_MV1GetTextureAddressModeU(MHandle, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureAddressModeV", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTextureAddressModeV(int MHandle, int TexIndex);
		public static int MV1GetTextureAddressModeV(int MHandle, int TexIndex) => dx_MV1GetTextureAddressModeV(MHandle, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureWidth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTextureWidth(int MHandle, int TexIndex);
		public static int MV1GetTextureWidth(int MHandle, int TexIndex) => dx_MV1GetTextureWidth(MHandle, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureHeight", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTextureHeight(int MHandle, int TexIndex);
		public static int MV1GetTextureHeight(int MHandle, int TexIndex) => dx_MV1GetTextureHeight(MHandle, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureSemiTransState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTextureSemiTransState(int MHandle, int TexIndex);
		public static int MV1GetTextureSemiTransState(int MHandle, int TexIndex) => dx_MV1GetTextureSemiTransState(MHandle, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetTextureBumpImageFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetTextureBumpImageFlag(int MHandle, int TexIndex, int Flag);
		public static int MV1SetTextureBumpImageFlag(int MHandle, int TexIndex, int Flag) => dx_MV1SetTextureBumpImageFlag(MHandle, TexIndex, Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureBumpImageFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTextureBumpImageFlag(int MHandle, int TexIndex);
		public static int MV1GetTextureBumpImageFlag(int MHandle, int TexIndex) => dx_MV1GetTextureBumpImageFlag(MHandle, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetTextureBumpImageNextPixelLength", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetTextureBumpImageNextPixelLength(int MHandle, int TexIndex, float Length);
		public static int MV1SetTextureBumpImageNextPixelLength(int MHandle, int TexIndex, float Length) => dx_MV1SetTextureBumpImageNextPixelLength(MHandle, TexIndex, Length);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureBumpImageNextPixelLength", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetTextureBumpImageNextPixelLength(int MHandle, int TexIndex);
		public static float MV1GetTextureBumpImageNextPixelLength(int MHandle, int TexIndex) => dx_MV1GetTextureBumpImageNextPixelLength(MHandle, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetTextureSampleFilterMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetTextureSampleFilterMode(int MHandle, int TexIndex, int FilterMode);
		public static int MV1SetTextureSampleFilterMode(int MHandle, int TexIndex, int FilterMode) => dx_MV1SetTextureSampleFilterMode(MHandle, TexIndex, FilterMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTextureSampleFilterMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTextureSampleFilterMode(int MHandle, int TexIndex);
		public static int MV1GetTextureSampleFilterMode(int MHandle, int TexIndex) => dx_MV1GetTextureSampleFilterMode(MHandle, TexIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1LoadTexture", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1LoadTexture(string FilePath);
		public static int MV1LoadTexture(string FilePath) => dx_MV1LoadTexture(FilePath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1LoadTextureWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1LoadTextureWithStrLen(string FilePath, ulong FilePathLength);
		public static int MV1LoadTextureWithStrLen(string FilePath, ulong FilePathLength) => dx_MV1LoadTextureWithStrLen(FilePath, FilePathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetFrameNum(int MHandle);
		public static int MV1GetFrameNum(int MHandle) => dx_MV1GetFrameNum(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SearchFrame", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SearchFrame(int MHandle, string FrameName);
		public static int MV1SearchFrame(int MHandle, string FrameName) => dx_MV1SearchFrame(MHandle, FrameName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SearchFrameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SearchFrameWithStrLen(int MHandle, string FrameName, ulong FrameNameLength);
		public static int MV1SearchFrameWithStrLen(int MHandle, string FrameName, ulong FrameNameLength) => dx_MV1SearchFrameWithStrLen(MHandle, FrameName, FrameNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SearchFrameChild", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SearchFrameChild(int MHandle, int FrameIndex, string ChildName);
		public static int MV1SearchFrameChild(int MHandle, int FrameIndex = -1, string ChildName = default) => dx_MV1SearchFrameChild(MHandle, FrameIndex, ChildName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SearchFrameChildWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SearchFrameChildWithStrLen(int MHandle, int FrameIndex, string ChildName, ulong ChildNameLength);
		public static int MV1SearchFrameChildWithStrLen(int MHandle, int FrameIndex = -1, string ChildName = default, ulong ChildNameLength = 0) => dx_MV1SearchFrameChildWithStrLen(MHandle, FrameIndex, ChildName, ChildNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_MV1GetFrameName(int MHandle, int FrameIndex);
		public static string MV1GetFrameName(int MHandle, int FrameIndex)
		{
			var resultIntPtr = dx_MV1GetFrameName(MHandle, FrameIndex);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameName2", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetFrameName2(int MHandle, int FrameIndex, System.Text.StringBuilder StrBuffer);
		public static int MV1GetFrameName2(int MHandle, int FrameIndex, System.Text.StringBuilder StrBuffer) => dx_MV1GetFrameName2(MHandle, FrameIndex, StrBuffer);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameParent", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetFrameParent(int MHandle, int FrameIndex);
		public static int MV1GetFrameParent(int MHandle, int FrameIndex) => dx_MV1GetFrameParent(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameChildNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetFrameChildNum(int MHandle, int FrameIndex);
		public static int MV1GetFrameChildNum(int MHandle, int FrameIndex = -1) => dx_MV1GetFrameChildNum(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameChild", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetFrameChild(int MHandle, int FrameIndex, int ChildIndex);
		public static int MV1GetFrameChild(int MHandle, int FrameIndex = -1, int ChildIndex = 0) => dx_MV1GetFrameChild(MHandle, FrameIndex, ChildIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFramePosition", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetFramePosition(int MHandle, int FrameIndex);
		public static VECTOR MV1GetFramePosition(int MHandle, int FrameIndex) => dx_MV1GetFramePosition(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFramePositionD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_MV1GetFramePositionD(int MHandle, int FrameIndex);
		public static VECTOR_D MV1GetFramePositionD(int MHandle, int FrameIndex) => dx_MV1GetFramePositionD(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameBaseLocalMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MV1GetFrameBaseLocalMatrix(int MHandle, int FrameIndex);
		public static MATRIX MV1GetFrameBaseLocalMatrix(int MHandle, int FrameIndex) => dx_MV1GetFrameBaseLocalMatrix(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameBaseLocalMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MV1GetFrameBaseLocalMatrixD(int MHandle, int FrameIndex);
		public static MATRIX_D MV1GetFrameBaseLocalMatrixD(int MHandle, int FrameIndex) => dx_MV1GetFrameBaseLocalMatrixD(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameLocalMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MV1GetFrameLocalMatrix(int MHandle, int FrameIndex);
		public static MATRIX MV1GetFrameLocalMatrix(int MHandle, int FrameIndex) => dx_MV1GetFrameLocalMatrix(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameLocalMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MV1GetFrameLocalMatrixD(int MHandle, int FrameIndex);
		public static MATRIX_D MV1GetFrameLocalMatrixD(int MHandle, int FrameIndex) => dx_MV1GetFrameLocalMatrixD(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameLocalWorldMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MV1GetFrameLocalWorldMatrix(int MHandle, int FrameIndex);
		public static MATRIX MV1GetFrameLocalWorldMatrix(int MHandle, int FrameIndex) => dx_MV1GetFrameLocalWorldMatrix(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameLocalWorldMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX_D dx_MV1GetFrameLocalWorldMatrixD(int MHandle, int FrameIndex);
		public static MATRIX_D MV1GetFrameLocalWorldMatrixD(int MHandle, int FrameIndex) => dx_MV1GetFrameLocalWorldMatrixD(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameUserLocalMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameUserLocalMatrix(int MHandle, int FrameIndex, MATRIX Matrix);
		public static int MV1SetFrameUserLocalMatrix(int MHandle, int FrameIndex, MATRIX Matrix) => dx_MV1SetFrameUserLocalMatrix(MHandle, FrameIndex, Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameUserLocalMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameUserLocalMatrixD(int MHandle, int FrameIndex, MATRIX_D Matrix);
		public static int MV1SetFrameUserLocalMatrixD(int MHandle, int FrameIndex, MATRIX_D Matrix) => dx_MV1SetFrameUserLocalMatrixD(MHandle, FrameIndex, Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1ResetFrameUserLocalMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1ResetFrameUserLocalMatrix(int MHandle, int FrameIndex);
		public static int MV1ResetFrameUserLocalMatrix(int MHandle, int FrameIndex) => dx_MV1ResetFrameUserLocalMatrix(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameUserLocalWorldMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameUserLocalWorldMatrix(int MHandle, int FrameIndex, MATRIX Matrix);
		public static int MV1SetFrameUserLocalWorldMatrix(int MHandle, int FrameIndex, MATRIX Matrix) => dx_MV1SetFrameUserLocalWorldMatrix(MHandle, FrameIndex, Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameUserLocalWorldMatrixD", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameUserLocalWorldMatrixD(int MHandle, int FrameIndex, MATRIX_D Matrix);
		public static int MV1SetFrameUserLocalWorldMatrixD(int MHandle, int FrameIndex, MATRIX_D Matrix) => dx_MV1SetFrameUserLocalWorldMatrixD(MHandle, FrameIndex, Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1ResetFrameUserLocalWorldMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1ResetFrameUserLocalWorldMatrix(int MHandle, int FrameIndex);
		public static int MV1ResetFrameUserLocalWorldMatrix(int MHandle, int FrameIndex) => dx_MV1ResetFrameUserLocalWorldMatrix(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameMaxVertexLocalPosition", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetFrameMaxVertexLocalPosition(int MHandle, int FrameIndex);
		public static VECTOR MV1GetFrameMaxVertexLocalPosition(int MHandle, int FrameIndex) => dx_MV1GetFrameMaxVertexLocalPosition(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameMaxVertexLocalPositionD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_MV1GetFrameMaxVertexLocalPositionD(int MHandle, int FrameIndex);
		public static VECTOR_D MV1GetFrameMaxVertexLocalPositionD(int MHandle, int FrameIndex) => dx_MV1GetFrameMaxVertexLocalPositionD(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameMinVertexLocalPosition", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetFrameMinVertexLocalPosition(int MHandle, int FrameIndex);
		public static VECTOR MV1GetFrameMinVertexLocalPosition(int MHandle, int FrameIndex) => dx_MV1GetFrameMinVertexLocalPosition(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameMinVertexLocalPositionD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_MV1GetFrameMinVertexLocalPositionD(int MHandle, int FrameIndex);
		public static VECTOR_D MV1GetFrameMinVertexLocalPositionD(int MHandle, int FrameIndex) => dx_MV1GetFrameMinVertexLocalPositionD(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameAvgVertexLocalPosition", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetFrameAvgVertexLocalPosition(int MHandle, int FrameIndex);
		public static VECTOR MV1GetFrameAvgVertexLocalPosition(int MHandle, int FrameIndex) => dx_MV1GetFrameAvgVertexLocalPosition(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameAvgVertexLocalPositionD", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR_D dx_MV1GetFrameAvgVertexLocalPositionD(int MHandle, int FrameIndex);
		public static VECTOR_D MV1GetFrameAvgVertexLocalPositionD(int MHandle, int FrameIndex) => dx_MV1GetFrameAvgVertexLocalPositionD(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameVertexNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetFrameVertexNum(int MHandle, int FrameIndex);
		public static int MV1GetFrameVertexNum(int MHandle, int FrameIndex) => dx_MV1GetFrameVertexNum(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameTriangleNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetFrameTriangleNum(int MHandle, int FrameIndex);
		public static int MV1GetFrameTriangleNum(int MHandle, int FrameIndex) => dx_MV1GetFrameTriangleNum(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameMeshNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetFrameMeshNum(int MHandle, int FrameIndex);
		public static int MV1GetFrameMeshNum(int MHandle, int FrameIndex) => dx_MV1GetFrameMeshNum(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameMesh", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetFrameMesh(int MHandle, int FrameIndex, int Index);
		public static int MV1GetFrameMesh(int MHandle, int FrameIndex, int Index) => dx_MV1GetFrameMesh(MHandle, FrameIndex, Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameVisible", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameVisible(int MHandle, int FrameIndex, int VisibleFlag);
		public static int MV1SetFrameVisible(int MHandle, int FrameIndex, int VisibleFlag) => dx_MV1SetFrameVisible(MHandle, FrameIndex, VisibleFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameVisible", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetFrameVisible(int MHandle, int FrameIndex);
		public static int MV1GetFrameVisible(int MHandle, int FrameIndex) => dx_MV1GetFrameVisible(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameDifColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameDifColorScale(int MHandle, int FrameIndex, COLOR_F Scale);
		public static int MV1SetFrameDifColorScale(int MHandle, int FrameIndex, COLOR_F Scale) => dx_MV1SetFrameDifColorScale(MHandle, FrameIndex, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameSpcColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameSpcColorScale(int MHandle, int FrameIndex, COLOR_F Scale);
		public static int MV1SetFrameSpcColorScale(int MHandle, int FrameIndex, COLOR_F Scale) => dx_MV1SetFrameSpcColorScale(MHandle, FrameIndex, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameEmiColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameEmiColorScale(int MHandle, int FrameIndex, COLOR_F Scale);
		public static int MV1SetFrameEmiColorScale(int MHandle, int FrameIndex, COLOR_F Scale) => dx_MV1SetFrameEmiColorScale(MHandle, FrameIndex, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameAmbColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameAmbColorScale(int MHandle, int FrameIndex, COLOR_F Scale);
		public static int MV1SetFrameAmbColorScale(int MHandle, int FrameIndex, COLOR_F Scale) => dx_MV1SetFrameAmbColorScale(MHandle, FrameIndex, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameDifColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetFrameDifColorScale(int MHandle, int FrameIndex);
		public static COLOR_F MV1GetFrameDifColorScale(int MHandle, int FrameIndex) => dx_MV1GetFrameDifColorScale(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameSpcColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetFrameSpcColorScale(int MHandle, int FrameIndex);
		public static COLOR_F MV1GetFrameSpcColorScale(int MHandle, int FrameIndex) => dx_MV1GetFrameSpcColorScale(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameEmiColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetFrameEmiColorScale(int MHandle, int FrameIndex);
		public static COLOR_F MV1GetFrameEmiColorScale(int MHandle, int FrameIndex) => dx_MV1GetFrameEmiColorScale(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameAmbColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetFrameAmbColorScale(int MHandle, int FrameIndex);
		public static COLOR_F MV1GetFrameAmbColorScale(int MHandle, int FrameIndex) => dx_MV1GetFrameAmbColorScale(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameSemiTransState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetFrameSemiTransState(int MHandle, int FrameIndex);
		public static int MV1GetFrameSemiTransState(int MHandle, int FrameIndex) => dx_MV1GetFrameSemiTransState(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameOpacityRate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameOpacityRate(int MHandle, int FrameIndex, float Rate);
		public static int MV1SetFrameOpacityRate(int MHandle, int FrameIndex, float Rate) => dx_MV1SetFrameOpacityRate(MHandle, FrameIndex, Rate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameOpacityRate", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetFrameOpacityRate(int MHandle, int FrameIndex);
		public static float MV1GetFrameOpacityRate(int MHandle, int FrameIndex) => dx_MV1GetFrameOpacityRate(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameBaseVisible", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameBaseVisible(int MHandle, int FrameIndex, int VisibleFlag);
		public static int MV1SetFrameBaseVisible(int MHandle, int FrameIndex, int VisibleFlag) => dx_MV1SetFrameBaseVisible(MHandle, FrameIndex, VisibleFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetFrameBaseVisible", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetFrameBaseVisible(int MHandle, int FrameIndex);
		public static int MV1GetFrameBaseVisible(int MHandle, int FrameIndex) => dx_MV1GetFrameBaseVisible(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameTextureAddressTransform", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameTextureAddressTransform(int MHandle, int FrameIndex, float TransU, float TransV, float ScaleU, float ScaleV, float RotCenterU, float RotCenterV, float Rotate);
		public static int MV1SetFrameTextureAddressTransform(int MHandle, int FrameIndex, float TransU, float TransV, float ScaleU, float ScaleV, float RotCenterU, float RotCenterV, float Rotate) => dx_MV1SetFrameTextureAddressTransform(MHandle, FrameIndex, TransU, TransV, ScaleU, ScaleV, RotCenterU, RotCenterV, Rotate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetFrameTextureAddressTransformMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetFrameTextureAddressTransformMatrix(int MHandle, int FrameIndex, MATRIX Matrix);
		public static int MV1SetFrameTextureAddressTransformMatrix(int MHandle, int FrameIndex, MATRIX Matrix) => dx_MV1SetFrameTextureAddressTransformMatrix(MHandle, FrameIndex, Matrix);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1ResetFrameTextureAddressTransform", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1ResetFrameTextureAddressTransform(int MHandle, int FrameIndex);
		public static int MV1ResetFrameTextureAddressTransform(int MHandle, int FrameIndex) => dx_MV1ResetFrameTextureAddressTransform(MHandle, FrameIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshNum(int MHandle);
		public static int MV1GetMeshNum(int MHandle) => dx_MV1GetMeshNum(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshMaterial", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshMaterial(int MHandle, int MeshIndex);
		public static int MV1GetMeshMaterial(int MHandle, int MeshIndex) => dx_MV1GetMeshMaterial(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshVertexNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshVertexNum(int MHandle, int MeshIndex);
		public static int MV1GetMeshVertexNum(int MHandle, int MeshIndex) => dx_MV1GetMeshVertexNum(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshTriangleNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshTriangleNum(int MHandle, int MeshIndex);
		public static int MV1GetMeshTriangleNum(int MHandle, int MeshIndex) => dx_MV1GetMeshTriangleNum(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshVisible", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshVisible(int MHandle, int MeshIndex, int VisibleFlag);
		public static int MV1SetMeshVisible(int MHandle, int MeshIndex, int VisibleFlag) => dx_MV1SetMeshVisible(MHandle, MeshIndex, VisibleFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshVisible", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshVisible(int MHandle, int MeshIndex);
		public static int MV1GetMeshVisible(int MHandle, int MeshIndex) => dx_MV1GetMeshVisible(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshDifColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshDifColorScale(int MHandle, int MeshIndex, COLOR_F Scale);
		public static int MV1SetMeshDifColorScale(int MHandle, int MeshIndex, COLOR_F Scale) => dx_MV1SetMeshDifColorScale(MHandle, MeshIndex, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshSpcColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshSpcColorScale(int MHandle, int MeshIndex, COLOR_F Scale);
		public static int MV1SetMeshSpcColorScale(int MHandle, int MeshIndex, COLOR_F Scale) => dx_MV1SetMeshSpcColorScale(MHandle, MeshIndex, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshEmiColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshEmiColorScale(int MHandle, int MeshIndex, COLOR_F Scale);
		public static int MV1SetMeshEmiColorScale(int MHandle, int MeshIndex, COLOR_F Scale) => dx_MV1SetMeshEmiColorScale(MHandle, MeshIndex, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshAmbColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshAmbColorScale(int MHandle, int MeshIndex, COLOR_F Scale);
		public static int MV1SetMeshAmbColorScale(int MHandle, int MeshIndex, COLOR_F Scale) => dx_MV1SetMeshAmbColorScale(MHandle, MeshIndex, Scale);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshDifColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetMeshDifColorScale(int MHandle, int MeshIndex);
		public static COLOR_F MV1GetMeshDifColorScale(int MHandle, int MeshIndex) => dx_MV1GetMeshDifColorScale(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshSpcColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetMeshSpcColorScale(int MHandle, int MeshIndex);
		public static COLOR_F MV1GetMeshSpcColorScale(int MHandle, int MeshIndex) => dx_MV1GetMeshSpcColorScale(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshEmiColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetMeshEmiColorScale(int MHandle, int MeshIndex);
		public static COLOR_F MV1GetMeshEmiColorScale(int MHandle, int MeshIndex) => dx_MV1GetMeshEmiColorScale(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshAmbColorScale", CallingConvention=CallingConvention.StdCall)]
		extern static COLOR_F dx_MV1GetMeshAmbColorScale(int MHandle, int MeshIndex);
		public static COLOR_F MV1GetMeshAmbColorScale(int MHandle, int MeshIndex) => dx_MV1GetMeshAmbColorScale(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshOpacityRate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshOpacityRate(int MHandle, int MeshIndex, float Rate);
		public static int MV1SetMeshOpacityRate(int MHandle, int MeshIndex, float Rate) => dx_MV1SetMeshOpacityRate(MHandle, MeshIndex, Rate);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshOpacityRate", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetMeshOpacityRate(int MHandle, int MeshIndex);
		public static float MV1GetMeshOpacityRate(int MHandle, int MeshIndex) => dx_MV1GetMeshOpacityRate(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshDrawBlendMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshDrawBlendMode(int MHandle, int MeshIndex, int BlendMode);
		public static int MV1SetMeshDrawBlendMode(int MHandle, int MeshIndex, int BlendMode) => dx_MV1SetMeshDrawBlendMode(MHandle, MeshIndex, BlendMode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshDrawBlendParam", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshDrawBlendParam(int MHandle, int MeshIndex, int BlendParam);
		public static int MV1SetMeshDrawBlendParam(int MHandle, int MeshIndex, int BlendParam) => dx_MV1SetMeshDrawBlendParam(MHandle, MeshIndex, BlendParam);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshDrawBlendMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshDrawBlendMode(int MHandle, int MeshIndex);
		public static int MV1GetMeshDrawBlendMode(int MHandle, int MeshIndex) => dx_MV1GetMeshDrawBlendMode(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshDrawBlendParam", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshDrawBlendParam(int MHandle, int MeshIndex);
		public static int MV1GetMeshDrawBlendParam(int MHandle, int MeshIndex) => dx_MV1GetMeshDrawBlendParam(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshBaseVisible", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshBaseVisible(int MHandle, int MeshIndex, int VisibleFlag);
		public static int MV1SetMeshBaseVisible(int MHandle, int MeshIndex, int VisibleFlag) => dx_MV1SetMeshBaseVisible(MHandle, MeshIndex, VisibleFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshBaseVisible", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshBaseVisible(int MHandle, int MeshIndex);
		public static int MV1GetMeshBaseVisible(int MHandle, int MeshIndex) => dx_MV1GetMeshBaseVisible(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshBackCulling", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshBackCulling(int MHandle, int MeshIndex, int CullingFlag);
		public static int MV1SetMeshBackCulling(int MHandle, int MeshIndex, int CullingFlag) => dx_MV1SetMeshBackCulling(MHandle, MeshIndex, CullingFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshBackCulling", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshBackCulling(int MHandle, int MeshIndex);
		public static int MV1GetMeshBackCulling(int MHandle, int MeshIndex) => dx_MV1GetMeshBackCulling(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshMaxPosition", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetMeshMaxPosition(int MHandle, int MeshIndex);
		public static VECTOR MV1GetMeshMaxPosition(int MHandle, int MeshIndex) => dx_MV1GetMeshMaxPosition(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshMinPosition", CallingConvention=CallingConvention.StdCall)]
		extern static VECTOR dx_MV1GetMeshMinPosition(int MHandle, int MeshIndex);
		public static VECTOR MV1GetMeshMinPosition(int MHandle, int MeshIndex) => dx_MV1GetMeshMinPosition(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshTListNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshTListNum(int MHandle, int MeshIndex);
		public static int MV1GetMeshTListNum(int MHandle, int MeshIndex) => dx_MV1GetMeshTListNum(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshTList", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshTList(int MHandle, int MeshIndex, int Index);
		public static int MV1GetMeshTList(int MHandle, int MeshIndex, int Index) => dx_MV1GetMeshTList(MHandle, MeshIndex, Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshSemiTransState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshSemiTransState(int MHandle, int MeshIndex);
		public static int MV1GetMeshSemiTransState(int MHandle, int MeshIndex) => dx_MV1GetMeshSemiTransState(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshUseVertDifColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshUseVertDifColor(int MHandle, int MeshIndex, int UseFlag);
		public static int MV1SetMeshUseVertDifColor(int MHandle, int MeshIndex, int UseFlag) => dx_MV1SetMeshUseVertDifColor(MHandle, MeshIndex, UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetMeshUseVertSpcColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetMeshUseVertSpcColor(int MHandle, int MeshIndex, int UseFlag);
		public static int MV1SetMeshUseVertSpcColor(int MHandle, int MeshIndex, int UseFlag) => dx_MV1SetMeshUseVertSpcColor(MHandle, MeshIndex, UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshUseVertDifColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshUseVertDifColor(int MHandle, int MeshIndex);
		public static int MV1GetMeshUseVertDifColor(int MHandle, int MeshIndex) => dx_MV1GetMeshUseVertDifColor(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshUseVertSpcColor", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshUseVertSpcColor(int MHandle, int MeshIndex);
		public static int MV1GetMeshUseVertSpcColor(int MHandle, int MeshIndex) => dx_MV1GetMeshUseVertSpcColor(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetMeshShapeFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetMeshShapeFlag(int MHandle, int MeshIndex);
		public static int MV1GetMeshShapeFlag(int MHandle, int MeshIndex) => dx_MV1GetMeshShapeFlag(MHandle, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetShapeNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetShapeNum(int MHandle);
		public static int MV1GetShapeNum(int MHandle) => dx_MV1GetShapeNum(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SearchShape", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SearchShape(int MHandle, string ShapeName);
		public static int MV1SearchShape(int MHandle, string ShapeName) => dx_MV1SearchShape(MHandle, ShapeName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SearchShapeWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SearchShapeWithStrLen(int MHandle, string ShapeName, ulong ShapeNameLength);
		public static int MV1SearchShapeWithStrLen(int MHandle, string ShapeName, ulong ShapeNameLength) => dx_MV1SearchShapeWithStrLen(MHandle, ShapeName, ShapeNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetShapeName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_MV1GetShapeName(int MHandle, int ShapeIndex);
		public static string MV1GetShapeName(int MHandle, int ShapeIndex)
		{
			var resultIntPtr = dx_MV1GetShapeName(MHandle, ShapeIndex);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetShapeTargetMeshNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetShapeTargetMeshNum(int MHandle, int ShapeIndex);
		public static int MV1GetShapeTargetMeshNum(int MHandle, int ShapeIndex) => dx_MV1GetShapeTargetMeshNum(MHandle, ShapeIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetShapeTargetMesh", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetShapeTargetMesh(int MHandle, int ShapeIndex, int Index);
		public static int MV1GetShapeTargetMesh(int MHandle, int ShapeIndex, int Index) => dx_MV1GetShapeTargetMesh(MHandle, ShapeIndex, Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetShapeRate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetShapeRate(int MHandle, int ShapeIndex, float Rate, int Type);
		public static int MV1SetShapeRate(int MHandle, int ShapeIndex, float Rate, int Type = DX_MV1_SHAPERATE_ADD) => dx_MV1SetShapeRate(MHandle, ShapeIndex, Rate, Type);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetShapeRate", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetShapeRate(int MHandle, int ShapeIndex);
		public static float MV1GetShapeRate(int MHandle, int ShapeIndex) => dx_MV1GetShapeRate(MHandle, ShapeIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetShapeApplyRate", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_MV1GetShapeApplyRate(int MHandle, int ShapeIndex);
		public static float MV1GetShapeApplyRate(int MHandle, int ShapeIndex) => dx_MV1GetShapeApplyRate(MHandle, ShapeIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTriangleListNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTriangleListNum(int MHandle);
		public static int MV1GetTriangleListNum(int MHandle) => dx_MV1GetTriangleListNum(MHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTriangleListVertexType", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTriangleListVertexType(int MHandle, int TListIndex);
		public static int MV1GetTriangleListVertexType(int MHandle, int TListIndex) => dx_MV1GetTriangleListVertexType(MHandle, TListIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTriangleListPolygonNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTriangleListPolygonNum(int MHandle, int TListIndex);
		public static int MV1GetTriangleListPolygonNum(int MHandle, int TListIndex) => dx_MV1GetTriangleListPolygonNum(MHandle, TListIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTriangleListVertexNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTriangleListVertexNum(int MHandle, int TListIndex);
		public static int MV1GetTriangleListVertexNum(int MHandle, int TListIndex) => dx_MV1GetTriangleListVertexNum(MHandle, TListIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTriangleListLocalWorldMatrixNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTriangleListLocalWorldMatrixNum(int MHandle, int TListIndex);
		public static int MV1GetTriangleListLocalWorldMatrixNum(int MHandle, int TListIndex) => dx_MV1GetTriangleListLocalWorldMatrixNum(MHandle, TListIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTriangleListLocalWorldMatrix", CallingConvention=CallingConvention.StdCall)]
		extern static MATRIX dx_MV1GetTriangleListLocalWorldMatrix(int MHandle, int TListIndex, int LWMatrixIndex);
		public static MATRIX MV1GetTriangleListLocalWorldMatrix(int MHandle, int TListIndex, int LWMatrixIndex) => dx_MV1GetTriangleListLocalWorldMatrix(MHandle, TListIndex, LWMatrixIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTriangleListPolygonVertexPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTriangleListPolygonVertexPosition(int MHandle, int TListIndex, int PolygonIndex, [In, Out] VECTOR[] VertexPositionArray, [In, Out] float[] MatrixWeightArray);
		public static int MV1GetTriangleListPolygonVertexPosition(int MHandle, int TListIndex, int PolygonIndex, [In, Out] VECTOR[] VertexPositionArray, [In, Out] float[] MatrixWeightArray) => dx_MV1GetTriangleListPolygonVertexPosition(MHandle, TListIndex, PolygonIndex, VertexPositionArray, MatrixWeightArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetTriangleListUseMaterial", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1GetTriangleListUseMaterial(int MHandle, int TListIndex);
		public static int MV1GetTriangleListUseMaterial(int MHandle, int TListIndex) => dx_MV1GetTriangleListUseMaterial(MHandle, TListIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetupCollInfo", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetupCollInfo(int MHandle, int FrameIndex, int XDivNum, int YDivNum, int ZDivNum, int MeshIndex);
		public static int MV1SetupCollInfo(int MHandle, int FrameIndex = -1, int XDivNum = 32, int YDivNum = 8, int ZDivNum = 32, int MeshIndex = -1) => dx_MV1SetupCollInfo(MHandle, FrameIndex, XDivNum, YDivNum, ZDivNum, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1TerminateCollInfo", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1TerminateCollInfo(int MHandle, int FrameIndex, int MeshIndex);
		public static int MV1TerminateCollInfo(int MHandle, int FrameIndex = -1, int MeshIndex = -1) => dx_MV1TerminateCollInfo(MHandle, FrameIndex, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1RefreshCollInfo", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1RefreshCollInfo(int MHandle, int FrameIndex, int MeshIndex);
		public static int MV1RefreshCollInfo(int MHandle, int FrameIndex = -1, int MeshIndex = -1) => dx_MV1RefreshCollInfo(MHandle, FrameIndex, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1CollCheck_Line", CallingConvention=CallingConvention.StdCall)]
		extern static MV1_COLL_RESULT_POLY dx_MV1CollCheck_Line(int MHandle, int FrameIndex, VECTOR PosStart, VECTOR PosEnd, int MeshIndex);
		public static MV1_COLL_RESULT_POLY MV1CollCheck_Line(int MHandle, int FrameIndex, VECTOR PosStart, VECTOR PosEnd, int MeshIndex = -1) => dx_MV1CollCheck_Line(MHandle, FrameIndex, PosStart, PosEnd, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1CollCheck_LineDim", CallingConvention=CallingConvention.StdCall)]
		extern static MV1_COLL_RESULT_POLY_DIM dx_MV1CollCheck_LineDim(int MHandle, int FrameIndex, VECTOR PosStart, VECTOR PosEnd, int MeshIndex);
		public static MV1_COLL_RESULT_POLY_DIM MV1CollCheck_LineDim(int MHandle, int FrameIndex, VECTOR PosStart, VECTOR PosEnd, int MeshIndex = -1) => dx_MV1CollCheck_LineDim(MHandle, FrameIndex, PosStart, PosEnd, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1CollCheck_Sphere", CallingConvention=CallingConvention.StdCall)]
		extern static MV1_COLL_RESULT_POLY_DIM dx_MV1CollCheck_Sphere(int MHandle, int FrameIndex, VECTOR CenterPos, float r, int MeshIndex);
		public static MV1_COLL_RESULT_POLY_DIM MV1CollCheck_Sphere(int MHandle, int FrameIndex, VECTOR CenterPos, float r, int MeshIndex = -1) => dx_MV1CollCheck_Sphere(MHandle, FrameIndex, CenterPos, r, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1CollCheck_Capsule", CallingConvention=CallingConvention.StdCall)]
		extern static MV1_COLL_RESULT_POLY_DIM dx_MV1CollCheck_Capsule(int MHandle, int FrameIndex, VECTOR Pos1, VECTOR Pos2, float r, int MeshIndex);
		public static MV1_COLL_RESULT_POLY_DIM MV1CollCheck_Capsule(int MHandle, int FrameIndex, VECTOR Pos1, VECTOR Pos2, float r, int MeshIndex = -1) => dx_MV1CollCheck_Capsule(MHandle, FrameIndex, Pos1, Pos2, r, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1CollCheck_Triangle", CallingConvention=CallingConvention.StdCall)]
		extern static MV1_COLL_RESULT_POLY_DIM dx_MV1CollCheck_Triangle(int MHandle, int FrameIndex, VECTOR Pos1, VECTOR Pos2, VECTOR Pos3, int MeshIndex);
		public static MV1_COLL_RESULT_POLY_DIM MV1CollCheck_Triangle(int MHandle, int FrameIndex, VECTOR Pos1, VECTOR Pos2, VECTOR Pos3, int MeshIndex = -1) => dx_MV1CollCheck_Triangle(MHandle, FrameIndex, Pos1, Pos2, Pos3, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1CollCheck_GetResultPoly", CallingConvention=CallingConvention.StdCall)]
		extern static MV1_COLL_RESULT_POLY dx_MV1CollCheck_GetResultPoly(MV1_COLL_RESULT_POLY_DIM ResultPolyDim, int PolyNo);
		public static MV1_COLL_RESULT_POLY MV1CollCheck_GetResultPoly(MV1_COLL_RESULT_POLY_DIM ResultPolyDim, int PolyNo) => dx_MV1CollCheck_GetResultPoly(ResultPolyDim, PolyNo);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1CollResultPolyDimTerminate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1CollResultPolyDimTerminate(MV1_COLL_RESULT_POLY_DIM ResultPolyDim);
		public static int MV1CollResultPolyDimTerminate(MV1_COLL_RESULT_POLY_DIM ResultPolyDim) => dx_MV1CollResultPolyDimTerminate(ResultPolyDim);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1SetupReferenceMesh", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1SetupReferenceMesh(int MHandle, int FrameIndex, int IsTransform, int IsPositionOnly, int MeshIndex);
		public static int MV1SetupReferenceMesh(int MHandle, int FrameIndex, int IsTransform, int IsPositionOnly = FALSE, int MeshIndex = -1) => dx_MV1SetupReferenceMesh(MHandle, FrameIndex, IsTransform, IsPositionOnly, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1TerminateReferenceMesh", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1TerminateReferenceMesh(int MHandle, int FrameIndex, int IsTransform, int IsPositionOnly, int MeshIndex);
		public static int MV1TerminateReferenceMesh(int MHandle, int FrameIndex, int IsTransform, int IsPositionOnly = FALSE, int MeshIndex = -1) => dx_MV1TerminateReferenceMesh(MHandle, FrameIndex, IsTransform, IsPositionOnly, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1RefreshReferenceMesh", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_MV1RefreshReferenceMesh(int MHandle, int FrameIndex, int IsTransform, int IsPositionOnly, int MeshIndex);
		public static int MV1RefreshReferenceMesh(int MHandle, int FrameIndex, int IsTransform, int IsPositionOnly = FALSE, int MeshIndex = -1) => dx_MV1RefreshReferenceMesh(MHandle, FrameIndex, IsTransform, IsPositionOnly, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_MV1GetReferenceMesh", CallingConvention=CallingConvention.StdCall)]
		extern static MV1_REF_POLYGONLIST dx_MV1GetReferenceMesh(int MHandle, int FrameIndex, int IsTransform, int IsPositionOnly, int MeshIndex);
		public static MV1_REF_POLYGONLIST MV1GetReferenceMesh(int MHandle, int FrameIndex, int IsTransform, int IsPositionOnly = FALSE, int MeshIndex = -1) => dx_MV1GetReferenceMesh(MHandle, FrameIndex, IsTransform, IsPositionOnly, MeshIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_SetCubism4CoreDLLPath", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_SetCubism4CoreDLLPath(string CoreDLLFilePath);
		public static int Live2D_SetCubism4CoreDLLPath(string CoreDLLFilePath) => dx_Live2D_SetCubism4CoreDLLPath(CoreDLLFilePath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_SetCubism4CoreDLLPathWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_SetCubism4CoreDLLPathWithStrLen(string CoreDLLFilePath, ulong CoreDLLFilePathLength);
		public static int Live2D_SetCubism4CoreDLLPathWithStrLen(string CoreDLLFilePath, ulong CoreDLLFilePathLength) => dx_Live2D_SetCubism4CoreDLLPathWithStrLen(CoreDLLFilePath, CoreDLLFilePathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_SetCubism3CoreDLLPath", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_SetCubism3CoreDLLPath(string CoreDLLFilePath);
		public static int Live2D_SetCubism3CoreDLLPath(string CoreDLLFilePath) => dx_Live2D_SetCubism3CoreDLLPath(CoreDLLFilePath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_SetCubism3CoreDLLPathWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_SetCubism3CoreDLLPathWithStrLen(string CoreDLLFilePath, ulong CoreDLLFilePathLength);
		public static int Live2D_SetCubism3CoreDLLPathWithStrLen(string CoreDLLFilePath, ulong CoreDLLFilePathLength) => dx_Live2D_SetCubism3CoreDLLPathWithStrLen(CoreDLLFilePath, CoreDLLFilePathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_RenderBegin", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_RenderBegin();
		public static int Live2D_RenderBegin() => dx_Live2D_RenderBegin();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_RenderEnd", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_RenderEnd();
		public static int Live2D_RenderEnd() => dx_Live2D_RenderEnd();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_LoadModel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_LoadModel(string FilePath);
		public static int Live2D_LoadModel(string FilePath) => dx_Live2D_LoadModel(FilePath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_LoadModelWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_LoadModelWithStrLen(string FilePath, ulong FilePathLength);
		public static int Live2D_LoadModelWithStrLen(string FilePath, ulong FilePathLength) => dx_Live2D_LoadModelWithStrLen(FilePath, FilePathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_DeleteModel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_DeleteModel(int Live2DModelHandle);
		public static int Live2D_DeleteModel(int Live2DModelHandle) => dx_Live2D_DeleteModel(Live2DModelHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_InitModel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_InitModel();
		public static int Live2D_InitModel() => dx_Live2D_InitModel();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_Update", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_Update(int Live2DModelHandle, float DeltaTimeSeconds);
		public static int Live2D_Model_Update(int Live2DModelHandle, float DeltaTimeSeconds) => dx_Live2D_Model_Update(Live2DModelHandle, DeltaTimeSeconds);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_SetTranslate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_SetTranslate(int Live2DModelHandle, float x, float y);
		public static int Live2D_Model_SetTranslate(int Live2DModelHandle, float x, float y) => dx_Live2D_Model_SetTranslate(Live2DModelHandle, x, y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_SetExtendRate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_SetExtendRate(int Live2DModelHandle, float ExRateX, float ExRateY);
		public static int Live2D_Model_SetExtendRate(int Live2DModelHandle, float ExRateX, float ExRateY) => dx_Live2D_Model_SetExtendRate(Live2DModelHandle, ExRateX, ExRateY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_SetRotate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_SetRotate(int Live2DModelHandle, float RotAngle);
		public static int Live2D_Model_SetRotate(int Live2DModelHandle, float RotAngle) => dx_Live2D_Model_SetRotate(Live2DModelHandle, RotAngle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_Draw", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_Draw(int Live2DModelHandle);
		public static int Live2D_Model_Draw(int Live2DModelHandle) => dx_Live2D_Model_Draw(Live2DModelHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_StartMotion", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_StartMotion(int Live2DModelHandle, string group, int no);
		public static int Live2D_Model_StartMotion(int Live2DModelHandle, string group, int no) => dx_Live2D_Model_StartMotion(Live2DModelHandle, group, no);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_StartMotionWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_StartMotionWithStrLen(int Live2DModelHandle, string group, ulong groupLength, int no);
		public static int Live2D_Model_StartMotionWithStrLen(int Live2DModelHandle, string group, ulong groupLength, int no) => dx_Live2D_Model_StartMotionWithStrLen(Live2DModelHandle, group, groupLength, no);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_IsMotionFinished", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_IsMotionFinished(int Live2DModelHandle);
		public static int Live2D_Model_IsMotionFinished(int Live2DModelHandle) => dx_Live2D_Model_IsMotionFinished(Live2DModelHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_SetExpression", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_SetExpression(int Live2DModelHandle, string expressionID);
		public static int Live2D_Model_SetExpression(int Live2DModelHandle, string expressionID) => dx_Live2D_Model_SetExpression(Live2DModelHandle, expressionID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_SetExpressionWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_SetExpressionWithStrLen(int Live2DModelHandle, string expressionID, ulong expressionIDLength);
		public static int Live2D_Model_SetExpressionWithStrLen(int Live2DModelHandle, string expressionID, ulong expressionIDLength) => dx_Live2D_Model_SetExpressionWithStrLen(Live2DModelHandle, expressionID, expressionIDLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_HitTest", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_HitTest(int Live2DModelHandle, string hitAreaName, float x, float y);
		public static int Live2D_Model_HitTest(int Live2DModelHandle, string hitAreaName, float x, float y) => dx_Live2D_Model_HitTest(Live2DModelHandle, hitAreaName, x, y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_HitTestWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_HitTestWithStrLen(int Live2DModelHandle, string hitAreaName, ulong hitAreaNameLength, float x, float y);
		public static int Live2D_Model_HitTestWithStrLen(int Live2DModelHandle, string hitAreaName, ulong hitAreaNameLength, float x, float y) => dx_Live2D_Model_HitTestWithStrLen(Live2DModelHandle, hitAreaName, hitAreaNameLength, x, y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetParameterCount", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_GetParameterCount(int Live2DModelHandle);
		public static int Live2D_Model_GetParameterCount(int Live2DModelHandle) => dx_Live2D_Model_GetParameterCount(Live2DModelHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetParameterId", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetParameterId(int Live2DModelHandle, int index);
		public static string Live2D_Model_GetParameterId(int Live2DModelHandle, int index)
		{
			var resultIntPtr = dx_Live2D_Model_GetParameterId(Live2DModelHandle, index);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetParameterValue", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Live2D_Model_GetParameterValue(int Live2DModelHandle, string parameterId);
		public static float Live2D_Model_GetParameterValue(int Live2DModelHandle, string parameterId) => dx_Live2D_Model_GetParameterValue(Live2DModelHandle, parameterId);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetParameterValueWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Live2D_Model_GetParameterValueWithStrLen(int Live2DModelHandle, string parameterId, ulong parameterIdLength);
		public static float Live2D_Model_GetParameterValueWithStrLen(int Live2DModelHandle, string parameterId, ulong parameterIdLength) => dx_Live2D_Model_GetParameterValueWithStrLen(Live2DModelHandle, parameterId, parameterIdLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_SetParameterValue", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_SetParameterValue(int Live2DModelHandle, string parameterId, float value);
		public static int Live2D_Model_SetParameterValue(int Live2DModelHandle, string parameterId, float value) => dx_Live2D_Model_SetParameterValue(Live2DModelHandle, parameterId, value);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_SetParameterValueWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_SetParameterValueWithStrLen(int Live2DModelHandle, string parameterId, ulong parameterIdLength, float value);
		public static int Live2D_Model_SetParameterValueWithStrLen(int Live2DModelHandle, string parameterId, ulong parameterIdLength, float value) => dx_Live2D_Model_SetParameterValueWithStrLen(Live2DModelHandle, parameterId, parameterIdLength, value);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetHitAreasCount", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_GetHitAreasCount(int Live2DModelHandle);
		public static int Live2D_Model_GetHitAreasCount(int Live2DModelHandle) => dx_Live2D_Model_GetHitAreasCount(Live2DModelHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetHitAreaName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetHitAreaName(int Live2DModelHandle, int index);
		public static string Live2D_Model_GetHitAreaName(int Live2DModelHandle, int index)
		{
			var resultIntPtr = dx_Live2D_Model_GetHitAreaName(Live2DModelHandle, index);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetPhysicsFileName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetPhysicsFileName(int Live2DModelHandle);
		public static string Live2D_Model_GetPhysicsFileName(int Live2DModelHandle)
		{
			var resultIntPtr = dx_Live2D_Model_GetPhysicsFileName(Live2DModelHandle);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetPoseFileName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetPoseFileName(int Live2DModelHandle);
		public static string Live2D_Model_GetPoseFileName(int Live2DModelHandle)
		{
			var resultIntPtr = dx_Live2D_Model_GetPoseFileName(Live2DModelHandle);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetExpressionCount", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_GetExpressionCount(int Live2DModelHandle);
		public static int Live2D_Model_GetExpressionCount(int Live2DModelHandle) => dx_Live2D_Model_GetExpressionCount(Live2DModelHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetExpressionName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetExpressionName(int Live2DModelHandle, int index);
		public static string Live2D_Model_GetExpressionName(int Live2DModelHandle, int index)
		{
			var resultIntPtr = dx_Live2D_Model_GetExpressionName(Live2DModelHandle, index);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetExpressionFileName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetExpressionFileName(int Live2DModelHandle, int index);
		public static string Live2D_Model_GetExpressionFileName(int Live2DModelHandle, int index)
		{
			var resultIntPtr = dx_Live2D_Model_GetExpressionFileName(Live2DModelHandle, index);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetMotionGroupCount", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_GetMotionGroupCount(int Live2DModelHandle);
		public static int Live2D_Model_GetMotionGroupCount(int Live2DModelHandle) => dx_Live2D_Model_GetMotionGroupCount(Live2DModelHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetMotionGroupName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetMotionGroupName(int Live2DModelHandle, int index);
		public static string Live2D_Model_GetMotionGroupName(int Live2DModelHandle, int index)
		{
			var resultIntPtr = dx_Live2D_Model_GetMotionGroupName(Live2DModelHandle, index);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetMotionCount", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_GetMotionCount(int Live2DModelHandle, string groupName);
		public static int Live2D_Model_GetMotionCount(int Live2DModelHandle, string groupName) => dx_Live2D_Model_GetMotionCount(Live2DModelHandle, groupName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetMotionCountWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_GetMotionCountWithStrLen(int Live2DModelHandle, string groupName, ulong groupNameLength);
		public static int Live2D_Model_GetMotionCountWithStrLen(int Live2DModelHandle, string groupName, ulong groupNameLength) => dx_Live2D_Model_GetMotionCountWithStrLen(Live2DModelHandle, groupName, groupNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetMotionFileName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetMotionFileName(int Live2DModelHandle, string groupName, int index);
		public static string Live2D_Model_GetMotionFileName(int Live2DModelHandle, string groupName, int index)
		{
			var resultIntPtr = dx_Live2D_Model_GetMotionFileName(Live2DModelHandle, groupName, index);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetMotionFileNameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetMotionFileNameWithStrLen(int Live2DModelHandle, string groupName, ulong groupNameLength, int index);
		public static string Live2D_Model_GetMotionFileNameWithStrLen(int Live2DModelHandle, string groupName, ulong groupNameLength, int index)
		{
			var resultIntPtr = dx_Live2D_Model_GetMotionFileNameWithStrLen(Live2DModelHandle, groupName, groupNameLength, index);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetMotionSoundFileName", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetMotionSoundFileName(int Live2DModelHandle, string groupName, int index);
		public static string Live2D_Model_GetMotionSoundFileName(int Live2DModelHandle, string groupName, int index)
		{
			var resultIntPtr = dx_Live2D_Model_GetMotionSoundFileName(Live2DModelHandle, groupName, index);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetMotionSoundFileNameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetMotionSoundFileNameWithStrLen(int Live2DModelHandle, string groupName, ulong groupNameLength, int index);
		public static string Live2D_Model_GetMotionSoundFileNameWithStrLen(int Live2DModelHandle, string groupName, ulong groupNameLength, int index)
		{
			var resultIntPtr = dx_Live2D_Model_GetMotionSoundFileNameWithStrLen(Live2DModelHandle, groupName, groupNameLength, index);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetMotionFadeInTimeValue", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Live2D_Model_GetMotionFadeInTimeValue(int Live2DModelHandle, string groupName, int index);
		public static float Live2D_Model_GetMotionFadeInTimeValue(int Live2DModelHandle, string groupName, int index) => dx_Live2D_Model_GetMotionFadeInTimeValue(Live2DModelHandle, groupName, index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetMotionFadeInTimeValueWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Live2D_Model_GetMotionFadeInTimeValueWithStrLen(int Live2DModelHandle, string groupName, ulong groupNameLength, int index);
		public static float Live2D_Model_GetMotionFadeInTimeValueWithStrLen(int Live2DModelHandle, string groupName, ulong groupNameLength, int index) => dx_Live2D_Model_GetMotionFadeInTimeValueWithStrLen(Live2DModelHandle, groupName, groupNameLength, index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetMotionFadeOutTimeValue", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Live2D_Model_GetMotionFadeOutTimeValue(int Live2DModelHandle, string groupName, int index);
		public static float Live2D_Model_GetMotionFadeOutTimeValue(int Live2DModelHandle, string groupName, int index) => dx_Live2D_Model_GetMotionFadeOutTimeValue(Live2DModelHandle, groupName, index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetMotionFadeOutTimeValueWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static float dx_Live2D_Model_GetMotionFadeOutTimeValueWithStrLen(int Live2DModelHandle, string groupName, ulong groupNameLength, int index);
		public static float Live2D_Model_GetMotionFadeOutTimeValueWithStrLen(int Live2DModelHandle, string groupName, ulong groupNameLength, int index) => dx_Live2D_Model_GetMotionFadeOutTimeValueWithStrLen(Live2DModelHandle, groupName, groupNameLength, index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetUserDataFile", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetUserDataFile(int Live2DModelHandle);
		public static string Live2D_Model_GetUserDataFile(int Live2DModelHandle)
		{
			var resultIntPtr = dx_Live2D_Model_GetUserDataFile(Live2DModelHandle);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetEyeBlinkParameterCount", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_GetEyeBlinkParameterCount(int Live2DModelHandle);
		public static int Live2D_Model_GetEyeBlinkParameterCount(int Live2DModelHandle) => dx_Live2D_Model_GetEyeBlinkParameterCount(Live2DModelHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetEyeBlinkParameterId", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetEyeBlinkParameterId(int Live2DModelHandle, int index);
		public static string Live2D_Model_GetEyeBlinkParameterId(int Live2DModelHandle, int index)
		{
			var resultIntPtr = dx_Live2D_Model_GetEyeBlinkParameterId(Live2DModelHandle, index);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetLipSyncParameterCount", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_Live2D_Model_GetLipSyncParameterCount(int Live2DModelHandle);
		public static int Live2D_Model_GetLipSyncParameterCount(int Live2DModelHandle) => dx_Live2D_Model_GetLipSyncParameterCount(Live2DModelHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_Live2D_Model_GetLipSyncParameterId", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_Live2D_Model_GetLipSyncParameterId(int Live2DModelHandle, int index);
		public static string Live2D_Model_GetLipSyncParameterId(int Live2DModelHandle, int index)
		{
			var resultIntPtr = dx_Live2D_Model_GetLipSyncParameterId(Live2DModelHandle, index);
			
			return resultIntPtr != System.IntPtr.Zero ? System.Runtime.InteropServices.Marshal.PtrToStringAnsi(resultIntPtr) : string.Empty;
		}
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowCRect", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWindowCRect(out RECT RectBuf);
		public static int GetWindowCRect(out RECT RectBuf) => dx_GetWindowCRect(out RectBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowClientRect", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWindowClientRect(out RECT RectBuf);
		public static int GetWindowClientRect(out RECT RectBuf) => dx_GetWindowClientRect(out RectBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowFrameRect", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWindowFrameRect(out RECT RectBuf);
		public static int GetWindowFrameRect(out RECT RectBuf) => dx_GetWindowFrameRect(out RectBuf);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowActiveFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWindowActiveFlag();
		public static int GetWindowActiveFlag() => dx_GetWindowActiveFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowMinSizeFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWindowMinSizeFlag();
		public static int GetWindowMinSizeFlag() => dx_GetWindowMinSizeFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowMaxSizeFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWindowMaxSizeFlag();
		public static int GetWindowMaxSizeFlag() => dx_GetWindowMaxSizeFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetActiveFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetActiveFlag();
		public static int GetActiveFlag() => dx_GetActiveFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMainWindowHandle", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetMainWindowHandle();
		public static System.IntPtr GetMainWindowHandle() => dx_GetMainWindowHandle();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowModeFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWindowModeFlag();
		public static int GetWindowModeFlag() => dx_GetWindowModeFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDefaultState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDefaultState(out int SizeX, out int SizeY, out int ColorBitDepth, out int RefreshRate, out int LeftTopX, out int LeftTopY, out int PixelSizeX, out int PixelSizeY, out int XDpi, out int YDpi);
		public static int GetDefaultState(out int SizeX, out int SizeY, out int ColorBitDepth, out int RefreshRate, out int LeftTopX, out int LeftTopY, out int PixelSizeX, out int PixelSizeY, out int XDpi, out int YDpi) => dx_GetDefaultState(out SizeX, out SizeY, out ColorBitDepth, out RefreshRate, out LeftTopX, out LeftTopY, out PixelSizeX, out PixelSizeY, out XDpi, out YDpi);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMonitorDpi", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMonitorDpi(out int XDpi, out int YDpi, int MonitorIndex);
		public static int GetMonitorDpi(out int XDpi, out int YDpi, int MonitorIndex = -1) => dx_GetMonitorDpi(out XDpi, out YDpi, MonitorIndex);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetNoActiveState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetNoActiveState(int ResetFlag);
		public static int GetNoActiveState(int ResetFlag = TRUE) => dx_GetNoActiveState(ResetFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMouseDispFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMouseDispFlag();
		public static int GetMouseDispFlag() => dx_GetMouseDispFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetAlwaysRunFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetAlwaysRunFlag();
		public static int GetAlwaysRunFlag() => dx_GetAlwaysRunFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx__GetSystemInfo", CallingConvention=CallingConvention.StdCall)]
		extern static int dx__GetSystemInfo(out int DxLibVer, out int DirectXVer, out int WindowsVer);
		public static int _GetSystemInfo(out int DxLibVer, out int DirectXVer, out int WindowsVer) => dx__GetSystemInfo(out DxLibVer, out DirectXVer, out WindowsVer);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPcInfo", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPcInfo(System.Text.StringBuilder OSString, System.Text.StringBuilder DirectXString, System.Text.StringBuilder CPUString, out int CPUSpeed, out double FreeMemorySize, out double TotalMemorySize, System.Text.StringBuilder VideoDriverFileName, System.Text.StringBuilder VideoDriverString, out double FreeVideoMemorySize, out double TotalVideoMemorySize);
		public static int GetPcInfo(System.Text.StringBuilder OSString, System.Text.StringBuilder DirectXString, System.Text.StringBuilder CPUString, out int CPUSpeed, out double FreeMemorySize, out double TotalMemorySize, System.Text.StringBuilder VideoDriverFileName, System.Text.StringBuilder VideoDriverString, out double FreeVideoMemorySize, out double TotalVideoMemorySize) => dx_GetPcInfo(OSString, DirectXString, CPUString, out CPUSpeed, out FreeMemorySize, out TotalMemorySize, VideoDriverFileName, VideoDriverString, out FreeVideoMemorySize, out TotalVideoMemorySize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseMMXFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseMMXFlag();
		public static int GetUseMMXFlag() => dx_GetUseMMXFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseSSEFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseSSEFlag();
		public static int GetUseSSEFlag() => dx_GetUseSSEFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseSSE2Flag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseSSE2Flag();
		public static int GetUseSSE2Flag() => dx_GetUseSSE2Flag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowCloseFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWindowCloseFlag();
		public static int GetWindowCloseFlag() => dx_GetWindowCloseFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetTaskInstance", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetTaskInstance();
		public static System.IntPtr GetTaskInstance() => dx_GetTaskInstance();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseWindowRgnFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseWindowRgnFlag();
		public static int GetUseWindowRgnFlag() => dx_GetUseWindowRgnFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowSizeExtendRate", CallingConvention=CallingConvention.StdCall)]
		extern static double dx_GetWindowSizeExtendRate(out double ExRateX, out double ExRateY);
		public static double GetWindowSizeExtendRate(out double ExRateX, out double ExRateY) => dx_GetWindowSizeExtendRate(out ExRateX, out ExRateY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWindowSize(out int Width, out int Height);
		public static int GetWindowSize(out int Width, out int Height) => dx_GetWindowSize(out Width, out Height);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowEdgeWidth", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWindowEdgeWidth(out int LeftWidth, out int RightWidth, out int TopWidth, out int BottomWidth);
		public static int GetWindowEdgeWidth(out int LeftWidth, out int RightWidth, out int TopWidth, out int BottomWidth) => dx_GetWindowEdgeWidth(out LeftWidth, out RightWidth, out TopWidth, out BottomWidth);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWindowPosition(out int x, out int y);
		public static int GetWindowPosition(out int x, out int y) => dx_GetWindowPosition(out x, out y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWindowUserCloseFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWindowUserCloseFlag(int StateResetFlag);
		public static int GetWindowUserCloseFlag(int StateResetFlag = FALSE) => dx_GetWindowUserCloseFlag(StateResetFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckWindowMaximizeButtonInput", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckWindowMaximizeButtonInput(int StateResetFlag);
		public static int CheckWindowMaximizeButtonInput(int StateResetFlag = TRUE) => dx_CheckWindowMaximizeButtonInput(StateResetFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetNotDrawFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetNotDrawFlag();
		public static int GetNotDrawFlag() => dx_GetNotDrawFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetPaintMessageFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetPaintMessageFlag();
		public static int GetPaintMessageFlag() => dx_GetPaintMessageFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetValidHiPerformanceCounter", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetValidHiPerformanceCounter();
		public static int GetValidHiPerformanceCounter() => dx_GetValidHiPerformanceCounter();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetInputSystemChar", CallingConvention=CallingConvention.StdCall)]
		extern static byte dx_GetInputSystemChar(int DeleteFlag);
		public static byte GetInputSystemChar(int DeleteFlag) => dx_GetInputSystemChar(DeleteFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ChangeWindowMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ChangeWindowMode(int Flag);
		public static int ChangeWindowMode(int Flag) => dx_ChangeWindowMode(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseCharSet", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseCharSet(int CharSet);
		public static int SetUseCharSet(int CharSet) => dx_SetUseCharSet(CharSet);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadPauseGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadPauseGraph(string FileName);
		public static int LoadPauseGraph(string FileName) => dx_LoadPauseGraph(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadPauseGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadPauseGraphWithStrLen(string FileName, ulong FileNameLength);
		public static int LoadPauseGraphWithStrLen(string FileName, ulong FileNameLength) => dx_LoadPauseGraphWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadPauseGraphFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadPauseGraphFromMem(System.IntPtr MemImage, int MemImageSize);
		public static int LoadPauseGraphFromMem(System.IntPtr MemImage, int MemImageSize) => dx_LoadPauseGraphFromMem(MemImage, MemImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowText", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowText(string WindowText);
		public static int SetWindowText(string WindowText) => dx_SetWindowText(WindowText);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowTextWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowTextWithStrLen(string WindowText, ulong WindowTextLength);
		public static int SetWindowTextWithStrLen(string WindowText, ulong WindowTextLength) => dx_SetWindowTextWithStrLen(WindowText, WindowTextLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMainWindowText", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMainWindowText(string WindowText);
		public static int SetMainWindowText(string WindowText) => dx_SetMainWindowText(WindowText);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMainWindowTextWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMainWindowTextWithStrLen(string WindowText, ulong WindowTextLength);
		public static int SetMainWindowTextWithStrLen(string WindowText, ulong WindowTextLength) => dx_SetMainWindowTextWithStrLen(WindowText, WindowTextLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMainWindowClassName", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMainWindowClassName(string ClassName);
		public static int SetMainWindowClassName(string ClassName) => dx_SetMainWindowClassName(ClassName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMainWindowClassNameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMainWindowClassNameWithStrLen(string ClassName, ulong ClassNameLength);
		public static int SetMainWindowClassNameWithStrLen(string ClassName, ulong ClassNameLength) => dx_SetMainWindowClassNameWithStrLen(ClassName, ClassNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowIconID", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowIconID(int ID);
		public static int SetWindowIconID(int ID) => dx_SetWindowIconID(ID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowIconHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowIconHandle(System.IntPtr Icon);
		public static int SetWindowIconHandle(System.IntPtr Icon) => dx_SetWindowIconHandle(Icon);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowStyleMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowStyleMode(int Mode);
		public static int SetWindowStyleMode(int Mode) => dx_SetWindowStyleMode(Mode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowZOrder", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowZOrder(int ZType, int WindowActivateFlag);
		public static int SetWindowZOrder(int ZType, int WindowActivateFlag = TRUE) => dx_SetWindowZOrder(ZType, WindowActivateFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowSizeChangeEnableFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowSizeChangeEnableFlag(int Flag, int FitScreen);
		public static int SetWindowSizeChangeEnableFlag(int Flag, int FitScreen = TRUE) => dx_SetWindowSizeChangeEnableFlag(Flag, FitScreen);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowSizeExtendRate", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowSizeExtendRate(double ExRateX, double ExRateY);
		public static int SetWindowSizeExtendRate(double ExRateX, double ExRateY = default) => dx_SetWindowSizeExtendRate(ExRateX, ExRateY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowSize(int Width, int Height);
		public static int SetWindowSize(int Width, int Height) => dx_SetWindowSize(Width, Height);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowMaxSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowMaxSize(int MaxWidth, int MaxHeight);
		public static int SetWindowMaxSize(int MaxWidth, int MaxHeight) => dx_SetWindowMaxSize(MaxWidth, MaxHeight);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowMinSize", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowMinSize(int MinWidth, int MinHeight);
		public static int SetWindowMinSize(int MinWidth, int MinHeight) => dx_SetWindowMinSize(MinWidth, MinHeight);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowPosition(int x, int y);
		public static int SetWindowPosition(int x, int y) => dx_SetWindowPosition(x, y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetSysCommandOffFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetSysCommandOffFlag(int Flag, string HookDllPath);
		public static int SetSysCommandOffFlag(int Flag, string HookDllPath = default) => dx_SetSysCommandOffFlag(Flag, HookDllPath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetSysCommandOffFlagWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetSysCommandOffFlagWithStrLen(int Flag, string HookDllPath, ulong HookDllPathLength);
		public static int SetSysCommandOffFlagWithStrLen(int Flag, string HookDllPath = default, ulong HookDllPathLength = 0) => dx_SetSysCommandOffFlagWithStrLen(Flag, HookDllPath, HookDllPathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowMaximizeButtonBehavior", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowMaximizeButtonBehavior(int BehaviorType);
		public static int SetWindowMaximizeButtonBehavior(int BehaviorType) => dx_SetWindowMaximizeButtonBehavior(BehaviorType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseHookWinProcReturnValue", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseHookWinProcReturnValue(int UseFlag);
		public static int SetUseHookWinProcReturnValue(int UseFlag) => dx_SetUseHookWinProcReturnValue(UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDoubleStartValidFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDoubleStartValidFlag(int Flag);
		public static int SetDoubleStartValidFlag(int Flag) => dx_SetDoubleStartValidFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckDoubleStart", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckDoubleStart();
		public static int CheckDoubleStart() => dx_CheckDoubleStart();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddMessageTakeOverWindow", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddMessageTakeOverWindow(System.IntPtr Window);
		public static int AddMessageTakeOverWindow(System.IntPtr Window) => dx_AddMessageTakeOverWindow(Window);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SubMessageTakeOverWindow", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SubMessageTakeOverWindow(System.IntPtr Window);
		public static int SubMessageTakeOverWindow(System.IntPtr Window) => dx_SubMessageTakeOverWindow(Window);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowInitPosition", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowInitPosition(int x, int y);
		public static int SetWindowInitPosition(int x, int y) => dx_SetWindowInitPosition(x, y);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNotWinFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNotWinFlag(int Flag);
		public static int SetNotWinFlag(int Flag) => dx_SetNotWinFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNotDrawFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNotDrawFlag(int Flag);
		public static int SetNotDrawFlag(int Flag) => dx_SetNotDrawFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNotSoundFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNotSoundFlag(int Flag);
		public static int SetNotSoundFlag(int Flag) => dx_SetNotSoundFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetNotInputFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetNotInputFlag(int Flag);
		public static int SetNotInputFlag(int Flag) => dx_SetNotInputFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDialogBoxHandle", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDialogBoxHandle(System.IntPtr WindowHandle);
		public static int SetDialogBoxHandle(System.IntPtr WindowHandle) => dx_SetDialogBoxHandle(WindowHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowVisibleFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowVisibleFlag(int Flag);
		public static int SetWindowVisibleFlag(int Flag) => dx_SetWindowVisibleFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowMinimizeFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowMinimizeFlag(int Flag);
		public static int SetWindowMinimizeFlag(int Flag) => dx_SetWindowMinimizeFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowUserCloseEnableFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowUserCloseEnableFlag(int Flag);
		public static int SetWindowUserCloseEnableFlag(int Flag) => dx_SetWindowUserCloseEnableFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDxLibEndPostQuitMessageFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDxLibEndPostQuitMessageFlag(int Flag);
		public static int SetDxLibEndPostQuitMessageFlag(int Flag) => dx_SetDxLibEndPostQuitMessageFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUserWindow", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUserWindow(System.IntPtr WindowHandle);
		public static int SetUserWindow(System.IntPtr WindowHandle) => dx_SetUserWindow(WindowHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUserChildWindow", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUserChildWindow(System.IntPtr WindowHandle);
		public static int SetUserChildWindow(System.IntPtr WindowHandle) => dx_SetUserChildWindow(WindowHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUserWindowMessageProcessDXLibFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUserWindowMessageProcessDXLibFlag(int Flag);
		public static int SetUserWindowMessageProcessDXLibFlag(int Flag) => dx_SetUserWindowMessageProcessDXLibFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseFPUPreserveFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseFPUPreserveFlag(int Flag);
		public static int SetUseFPUPreserveFlag(int Flag) => dx_SetUseFPUPreserveFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetValidMousePointerWindowOutClientAreaMoveFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetValidMousePointerWindowOutClientAreaMoveFlag(int Flag);
		public static int SetValidMousePointerWindowOutClientAreaMoveFlag(int Flag) => dx_SetValidMousePointerWindowOutClientAreaMoveFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseBackBufferTransColorFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseBackBufferTransColorFlag(int Flag);
		public static int SetUseBackBufferTransColorFlag(int Flag) => dx_SetUseBackBufferTransColorFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseUpdateLayerdWindowFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseUpdateLayerdWindowFlag(int Flag);
		public static int SetUseUpdateLayerdWindowFlag(int Flag) => dx_SetUseUpdateLayerdWindowFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDxLibWM_PAINTProcess", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDxLibWM_PAINTProcess(int Flag);
		public static int SetUseDxLibWM_PAINTProcess(int Flag) => dx_SetUseDxLibWM_PAINTProcess(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindows10_WM_CHAR_CancelTime", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindows10_WM_CHAR_CancelTime(int MilliSecond);
		public static int SetWindows10_WM_CHAR_CancelTime(int MilliSecond) => dx_SetWindows10_WM_CHAR_CancelTime(MilliSecond);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDragFileValidFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDragFileValidFlag(int Flag);
		public static int SetDragFileValidFlag(int Flag) => dx_SetDragFileValidFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DragFileInfoClear", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DragFileInfoClear();
		public static int DragFileInfoClear() => dx_DragFileInfoClear();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDragFilePath", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDragFilePath(System.Text.StringBuilder FilePathBuffer);
		public static int GetDragFilePath(System.Text.StringBuilder FilePathBuffer) => dx_GetDragFilePath(FilePathBuffer);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDragFileNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDragFileNum();
		public static int GetDragFileNum() => dx_GetDragFileNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateRgnFromGraph", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_CreateRgnFromGraph(int Width, int Height, System.IntPtr MaskData, int Pitch, int Byte);
		public static System.IntPtr CreateRgnFromGraph(int Width, int Height, System.IntPtr MaskData, int Pitch, int Byte) => dx_CreateRgnFromGraph(Width, Height, MaskData, Pitch, Byte);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowRgnGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowRgnGraph(string FileName);
		public static int SetWindowRgnGraph(string FileName) => dx_SetWindowRgnGraph(FileName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetWindowRgnGraphWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetWindowRgnGraphWithStrLen(string FileName, ulong FileNameLength);
		public static int SetWindowRgnGraphWithStrLen(string FileName, ulong FileNameLength) => dx_SetWindowRgnGraphWithStrLen(FileName, FileNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_UpdateTransColorWindowRgn", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_UpdateTransColorWindowRgn();
		public static int UpdateTransColorWindowRgn() => dx_UpdateTransColorWindowRgn();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetupToolBar", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetupToolBar(string BitmapName, int DivNum, int ResourceID);
		public static int SetupToolBar(string BitmapName, int DivNum, int ResourceID = -1) => dx_SetupToolBar(BitmapName, DivNum, ResourceID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetupToolBarWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetupToolBarWithStrLen(string BitmapName, ulong BitmapNameLength, int DivNum, int ResourceID);
		public static int SetupToolBarWithStrLen(string BitmapName, ulong BitmapNameLength, int DivNum, int ResourceID = -1) => dx_SetupToolBarWithStrLen(BitmapName, BitmapNameLength, DivNum, ResourceID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddToolBarButton", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddToolBarButton(int Type, int State, int ImageIndex, int ID);
		public static int AddToolBarButton(int Type, int State, int ImageIndex, int ID) => dx_AddToolBarButton(Type, State, ImageIndex, ID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddToolBarSep", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddToolBarSep();
		public static int AddToolBarSep() => dx_AddToolBarSep();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetToolBarButtonState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetToolBarButtonState(int ID);
		public static int GetToolBarButtonState(int ID) => dx_GetToolBarButtonState(ID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetToolBarButtonState", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetToolBarButtonState(int ID, int State);
		public static int SetToolBarButtonState(int ID, int State) => dx_SetToolBarButtonState(ID, State);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteAllToolBarButton", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteAllToolBarButton();
		public static int DeleteAllToolBarButton() => dx_DeleteAllToolBarButton();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseMenuFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseMenuFlag(int Flag);
		public static int SetUseMenuFlag(int Flag) => dx_SetUseMenuFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseKeyAccelFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseKeyAccelFlag(int Flag);
		public static int SetUseKeyAccelFlag(int Flag) => dx_SetUseKeyAccelFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddKeyAccel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddKeyAccel(string ItemName, int ItemID, int KeyCode, int CtrlFlag, int AltFlag, int ShiftFlag);
		public static int AddKeyAccel(string ItemName, int ItemID, int KeyCode, int CtrlFlag, int AltFlag, int ShiftFlag) => dx_AddKeyAccel(ItemName, ItemID, KeyCode, CtrlFlag, AltFlag, ShiftFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddKeyAccelWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddKeyAccelWithStrLen(string ItemName, ulong ItemNameLength, int ItemID, int KeyCode, int CtrlFlag, int AltFlag, int ShiftFlag);
		public static int AddKeyAccelWithStrLen(string ItemName, ulong ItemNameLength, int ItemID, int KeyCode, int CtrlFlag, int AltFlag, int ShiftFlag) => dx_AddKeyAccelWithStrLen(ItemName, ItemNameLength, ItemID, KeyCode, CtrlFlag, AltFlag, ShiftFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddKeyAccel_Name", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddKeyAccel_Name(string ItemName, int KeyCode, int CtrlFlag, int AltFlag, int ShiftFlag);
		public static int AddKeyAccel_Name(string ItemName, int KeyCode, int CtrlFlag, int AltFlag, int ShiftFlag) => dx_AddKeyAccel_Name(ItemName, KeyCode, CtrlFlag, AltFlag, ShiftFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddKeyAccel_NameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddKeyAccel_NameWithStrLen(string ItemName, ulong ItemNameLength, int KeyCode, int CtrlFlag, int AltFlag, int ShiftFlag);
		public static int AddKeyAccel_NameWithStrLen(string ItemName, ulong ItemNameLength, int KeyCode, int CtrlFlag, int AltFlag, int ShiftFlag) => dx_AddKeyAccel_NameWithStrLen(ItemName, ItemNameLength, KeyCode, CtrlFlag, AltFlag, ShiftFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddKeyAccel_ID", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddKeyAccel_ID(int ItemID, int KeyCode, int CtrlFlag, int AltFlag, int ShiftFlag);
		public static int AddKeyAccel_ID(int ItemID, int KeyCode, int CtrlFlag, int AltFlag, int ShiftFlag) => dx_AddKeyAccel_ID(ItemID, KeyCode, CtrlFlag, AltFlag, ShiftFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ClearKeyAccel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ClearKeyAccel();
		public static int ClearKeyAccel() => dx_ClearKeyAccel();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddMenuItem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddMenuItem(int AddType, string ItemName, int ItemID, int SeparatorFlag, string NewItemName, int NewItemID);
		public static int AddMenuItem(int AddType, string ItemName, int ItemID, int SeparatorFlag, string NewItemName = default, int NewItemID = -1) => dx_AddMenuItem(AddType, ItemName, ItemID, SeparatorFlag, NewItemName, NewItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddMenuItemWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddMenuItemWithStrLen(int AddType, string ItemName, ulong ItemNameLength, int ItemID, int SeparatorFlag, string NewItemName, ulong NewItemNameLength, int NewItemID);
		public static int AddMenuItemWithStrLen(int AddType, string ItemName, ulong ItemNameLength, int ItemID, int SeparatorFlag, string NewItemName = default, ulong NewItemNameLength = 0, int NewItemID = -1) => dx_AddMenuItemWithStrLen(AddType, ItemName, ItemNameLength, ItemID, SeparatorFlag, NewItemName, NewItemNameLength, NewItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteMenuItem", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteMenuItem(string ItemName, int ItemID);
		public static int DeleteMenuItem(string ItemName, int ItemID) => dx_DeleteMenuItem(ItemName, ItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteMenuItemWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteMenuItemWithStrLen(string ItemName, ulong ItemNameLength, int ItemID);
		public static int DeleteMenuItemWithStrLen(string ItemName, ulong ItemNameLength, int ItemID) => dx_DeleteMenuItemWithStrLen(ItemName, ItemNameLength, ItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckMenuItemSelect", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckMenuItemSelect(string ItemName, int ItemID);
		public static int CheckMenuItemSelect(string ItemName, int ItemID) => dx_CheckMenuItemSelect(ItemName, ItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckMenuItemSelectWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckMenuItemSelectWithStrLen(string ItemName, ulong ItemNameLength, int ItemID);
		public static int CheckMenuItemSelectWithStrLen(string ItemName, ulong ItemNameLength, int ItemID) => dx_CheckMenuItemSelectWithStrLen(ItemName, ItemNameLength, ItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMenuItemEnable", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMenuItemEnable(string ItemName, int ItemID, int EnableFlag);
		public static int SetMenuItemEnable(string ItemName, int ItemID, int EnableFlag) => dx_SetMenuItemEnable(ItemName, ItemID, EnableFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMenuItemEnableWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMenuItemEnableWithStrLen(string ItemName, ulong ItemNameLength, int ItemID, int EnableFlag);
		public static int SetMenuItemEnableWithStrLen(string ItemName, ulong ItemNameLength, int ItemID, int EnableFlag) => dx_SetMenuItemEnableWithStrLen(ItemName, ItemNameLength, ItemID, EnableFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMenuItemMark", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMenuItemMark(string ItemName, int ItemID, int Mark);
		public static int SetMenuItemMark(string ItemName, int ItemID, int Mark) => dx_SetMenuItemMark(ItemName, ItemID, Mark);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMenuItemMarkWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMenuItemMarkWithStrLen(string ItemName, ulong ItemNameLength, int ItemID, int Mark);
		public static int SetMenuItemMarkWithStrLen(string ItemName, ulong ItemNameLength, int ItemID, int Mark) => dx_SetMenuItemMarkWithStrLen(ItemName, ItemNameLength, ItemID, Mark);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckMenuItemSelectAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckMenuItemSelectAll();
		public static int CheckMenuItemSelectAll() => dx_CheckMenuItemSelectAll();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddMenuItem_Name", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddMenuItem_Name(string ParentItemName, string NewItemName);
		public static int AddMenuItem_Name(string ParentItemName, string NewItemName) => dx_AddMenuItem_Name(ParentItemName, NewItemName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddMenuItem_NameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddMenuItem_NameWithStrLen(string ParentItemName, ulong ParentItemNameLength, string NewItemName, ulong NewItemNameLength);
		public static int AddMenuItem_NameWithStrLen(string ParentItemName, ulong ParentItemNameLength, string NewItemName, ulong NewItemNameLength) => dx_AddMenuItem_NameWithStrLen(ParentItemName, ParentItemNameLength, NewItemName, NewItemNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddMenuLine_Name", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddMenuLine_Name(string ParentItemName);
		public static int AddMenuLine_Name(string ParentItemName) => dx_AddMenuLine_Name(ParentItemName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddMenuLine_NameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddMenuLine_NameWithStrLen(string ParentItemName, ulong ParentItemNameLength);
		public static int AddMenuLine_NameWithStrLen(string ParentItemName, ulong ParentItemNameLength) => dx_AddMenuLine_NameWithStrLen(ParentItemName, ParentItemNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InsertMenuItem_Name", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InsertMenuItem_Name(string ItemName, string NewItemName);
		public static int InsertMenuItem_Name(string ItemName, string NewItemName) => dx_InsertMenuItem_Name(ItemName, NewItemName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InsertMenuItem_NameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InsertMenuItem_NameWithStrLen(string ItemName, ulong ItemNameLength, string NewItemName, ulong NewItemNameLength);
		public static int InsertMenuItem_NameWithStrLen(string ItemName, ulong ItemNameLength, string NewItemName, ulong NewItemNameLength) => dx_InsertMenuItem_NameWithStrLen(ItemName, ItemNameLength, NewItemName, NewItemNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InsertMenuLine_Name", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InsertMenuLine_Name(string ItemName);
		public static int InsertMenuLine_Name(string ItemName) => dx_InsertMenuLine_Name(ItemName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InsertMenuLine_NameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InsertMenuLine_NameWithStrLen(string ItemName, ulong ItemNameLength);
		public static int InsertMenuLine_NameWithStrLen(string ItemName, ulong ItemNameLength) => dx_InsertMenuLine_NameWithStrLen(ItemName, ItemNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteMenuItem_Name", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteMenuItem_Name(string ItemName);
		public static int DeleteMenuItem_Name(string ItemName) => dx_DeleteMenuItem_Name(ItemName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteMenuItem_NameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteMenuItem_NameWithStrLen(string ItemName, ulong ItemNameLength);
		public static int DeleteMenuItem_NameWithStrLen(string ItemName, ulong ItemNameLength) => dx_DeleteMenuItem_NameWithStrLen(ItemName, ItemNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckMenuItemSelect_Name", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckMenuItemSelect_Name(string ItemName);
		public static int CheckMenuItemSelect_Name(string ItemName) => dx_CheckMenuItemSelect_Name(ItemName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckMenuItemSelect_NameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckMenuItemSelect_NameWithStrLen(string ItemName, ulong ItemNameLength);
		public static int CheckMenuItemSelect_NameWithStrLen(string ItemName, ulong ItemNameLength) => dx_CheckMenuItemSelect_NameWithStrLen(ItemName, ItemNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMenuItemEnable_Name", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMenuItemEnable_Name(string ItemName, int EnableFlag);
		public static int SetMenuItemEnable_Name(string ItemName, int EnableFlag) => dx_SetMenuItemEnable_Name(ItemName, EnableFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMenuItemEnable_NameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMenuItemEnable_NameWithStrLen(string ItemName, ulong ItemNameLength, int EnableFlag);
		public static int SetMenuItemEnable_NameWithStrLen(string ItemName, ulong ItemNameLength, int EnableFlag) => dx_SetMenuItemEnable_NameWithStrLen(ItemName, ItemNameLength, EnableFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMenuItemMark_Name", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMenuItemMark_Name(string ItemName, int Mark);
		public static int SetMenuItemMark_Name(string ItemName, int Mark) => dx_SetMenuItemMark_Name(ItemName, Mark);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMenuItemMark_NameWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMenuItemMark_NameWithStrLen(string ItemName, ulong ItemNameLength, int Mark);
		public static int SetMenuItemMark_NameWithStrLen(string ItemName, ulong ItemNameLength, int Mark) => dx_SetMenuItemMark_NameWithStrLen(ItemName, ItemNameLength, Mark);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddMenuItem_ID", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddMenuItem_ID(int ParentItemID, string NewItemName, int NewItemID);
		public static int AddMenuItem_ID(int ParentItemID, string NewItemName, int NewItemID = -1) => dx_AddMenuItem_ID(ParentItemID, NewItemName, NewItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddMenuItem_IDWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddMenuItem_IDWithStrLen(int ParentItemID, string NewItemName, ulong NewItemNameLength, int NewItemID);
		public static int AddMenuItem_IDWithStrLen(int ParentItemID, string NewItemName, ulong NewItemNameLength, int NewItemID = -1) => dx_AddMenuItem_IDWithStrLen(ParentItemID, NewItemName, NewItemNameLength, NewItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddMenuLine_ID", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_AddMenuLine_ID(int ParentItemID);
		public static int AddMenuLine_ID(int ParentItemID) => dx_AddMenuLine_ID(ParentItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InsertMenuItem_ID", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InsertMenuItem_ID(int ItemID, int NewItemID);
		public static int InsertMenuItem_ID(int ItemID, int NewItemID) => dx_InsertMenuItem_ID(ItemID, NewItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_InsertMenuLine_ID", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_InsertMenuLine_ID(int ItemID, int NewItemID);
		public static int InsertMenuLine_ID(int ItemID, int NewItemID) => dx_InsertMenuLine_ID(ItemID, NewItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteMenuItem_ID", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteMenuItem_ID(int ItemID);
		public static int DeleteMenuItem_ID(int ItemID) => dx_DeleteMenuItem_ID(ItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CheckMenuItemSelect_ID", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CheckMenuItemSelect_ID(int ItemID);
		public static int CheckMenuItemSelect_ID(int ItemID) => dx_CheckMenuItemSelect_ID(ItemID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMenuItemEnable_ID", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMenuItemEnable_ID(int ItemID, int EnableFlag);
		public static int SetMenuItemEnable_ID(int ItemID, int EnableFlag) => dx_SetMenuItemEnable_ID(ItemID, EnableFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMenuItemMark_ID", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMenuItemMark_ID(int ItemID, int Mark);
		public static int SetMenuItemMark_ID(int ItemID, int Mark) => dx_SetMenuItemMark_ID(ItemID, Mark);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_DeleteMenuItemAll", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_DeleteMenuItemAll();
		public static int DeleteMenuItemAll() => dx_DeleteMenuItemAll();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ClearMenuItemSelect", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ClearMenuItemSelect();
		public static int ClearMenuItemSelect() => dx_ClearMenuItemSelect();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMenuItemID", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMenuItemID(string ItemName);
		public static int GetMenuItemID(string ItemName) => dx_GetMenuItemID(ItemName);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMenuItemIDWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMenuItemIDWithStrLen(string ItemName, ulong ItemNameLength);
		public static int GetMenuItemIDWithStrLen(string ItemName, ulong ItemNameLength) => dx_GetMenuItemIDWithStrLen(ItemName, ItemNameLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetMenuItemName", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetMenuItemName(int ItemID, System.Text.StringBuilder NameBuffer);
		public static int GetMenuItemName(int ItemID, System.Text.StringBuilder NameBuffer) => dx_GetMenuItemName(ItemID, NameBuffer);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadMenuResource", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadMenuResource(int MenuResourceID);
		public static int LoadMenuResource(int MenuResourceID) => dx_LoadMenuResource(MenuResourceID);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDisplayMenuFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDisplayMenuFlag(int Flag);
		public static int SetDisplayMenuFlag(int Flag) => dx_SetDisplayMenuFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDisplayMenuFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDisplayMenuFlag();
		public static int GetDisplayMenuFlag() => dx_GetDisplayMenuFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseMenuFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseMenuFlag();
		public static int GetUseMenuFlag() => dx_GetUseMenuFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetAutoMenuDisplayFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetAutoMenuDisplayFlag(int Flag);
		public static int SetAutoMenuDisplayFlag(int Flag) => dx_SetAutoMenuDisplayFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetWinSockLastError", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetWinSockLastError();
		public static int GetWinSockLastError() => dx_GetWinSockLastError();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseTSFFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseTSFFlag(int UseFlag);
		public static int SetUseTSFFlag(int UseFlag) => dx_SetUseTSFFlag(UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyExclusiveCooperativeLevelFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyExclusiveCooperativeLevelFlag(int Flag);
		public static int SetKeyExclusiveCooperativeLevelFlag(int Flag) => dx_SetKeyExclusiveCooperativeLevelFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetKeyboardNotDirectInputFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetKeyboardNotDirectInputFlag(int Flag);
		public static int SetKeyboardNotDirectInputFlag(int Flag) => dx_SetKeyboardNotDirectInputFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDirectInputFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDirectInputFlag(int UseFlag);
		public static int SetUseDirectInputFlag(int UseFlag) => dx_SetUseDirectInputFlag(UseFlag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDirectInputMouseMode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDirectInputMouseMode(int Mode);
		public static int SetDirectInputMouseMode(int Mode) => dx_SetDirectInputMouseMode(Mode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseXInputFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseXInputFlag(int Flag);
		public static int SetUseXInputFlag(int Flag) => dx_SetUseXInputFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseXboxControllerDirectInputFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseXboxControllerDirectInputFlag(int Flag);
		public static int SetUseXboxControllerDirectInputFlag(int Flag) => dx_SetUseXboxControllerDirectInputFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetJoypadName", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetJoypadName(int InputType, System.Text.StringBuilder InstanceNameBuffer, System.Text.StringBuilder ProductNameBuffer);
		public static int GetJoypadName(int InputType, System.Text.StringBuilder InstanceNameBuffer, System.Text.StringBuilder ProductNameBuffer) => dx_GetJoypadName(InputType, InstanceNameBuffer, ProductNameBuffer);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvertKeyCodeToVirtualKey", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ConvertKeyCodeToVirtualKey(int KeyCode);
		public static int ConvertKeyCodeToVirtualKey(int KeyCode) => dx_ConvertKeyCodeToVirtualKey(KeyCode);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ConvertVirtualKeyToKeyCode", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ConvertVirtualKeyToKeyCode(int VirtualKey);
		public static int ConvertVirtualKeyToKeyCode(int VirtualKey) => dx_ConvertVirtualKeyToKeyCode(VirtualKey);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivGraphToResource", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivGraphToResource(int ResourceID, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray);
		public static int LoadDivGraphToResource(int ResourceID, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray) => dx_LoadDivGraphToResource(ResourceID, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivGraphFToResource", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivGraphFToResource(int ResourceID, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray);
		public static int LoadDivGraphFToResource(int ResourceID, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray) => dx_LoadDivGraphFToResource(ResourceID, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadGraphToResourceWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadGraphToResourceWithStrLen(string ResourceName, ulong ResourceNameLength, string ResourceType, ulong ResourceTypeLength);
		public static int LoadGraphToResourceWithStrLen(string ResourceName, ulong ResourceNameLength, string ResourceType, ulong ResourceTypeLength) => dx_LoadGraphToResourceWithStrLen(ResourceName, ResourceNameLength, ResourceType, ResourceTypeLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivGraphToResource", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivGraphToResource(string ResourceName, string ResourceType, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray);
		public static int LoadDivGraphToResource(string ResourceName, string ResourceType, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray) => dx_LoadDivGraphToResource(ResourceName, ResourceType, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivGraphToResourceWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivGraphToResourceWithStrLen(string ResourceName, ulong ResourceNameLength, string ResourceType, ulong ResourceTypeLength, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray);
		public static int LoadDivGraphToResourceWithStrLen(string ResourceName, ulong ResourceNameLength, string ResourceType, ulong ResourceTypeLength, int AllNum, int XNum, int YNum, int XSize, int YSize, [In, Out] int[] HandleArray) => dx_LoadDivGraphToResourceWithStrLen(ResourceName, ResourceNameLength, ResourceType, ResourceTypeLength, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivGraphFToResource", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivGraphFToResource(string ResourceName, string ResourceType, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray);
		public static int LoadDivGraphFToResource(string ResourceName, string ResourceType, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray) => dx_LoadDivGraphFToResource(ResourceName, ResourceType, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadDivGraphFToResourceWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadDivGraphFToResourceWithStrLen(string ResourceName, ulong ResourceNameLength, string ResourceType, ulong ResourceTypeLength, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray);
		public static int LoadDivGraphFToResourceWithStrLen(string ResourceName, ulong ResourceNameLength, string ResourceType, ulong ResourceTypeLength, int AllNum, int XNum, int YNum, float XSize, float YSize, [In, Out] int[] HandleArray) => dx_LoadDivGraphFToResourceWithStrLen(ResourceName, ResourceNameLength, ResourceType, ResourceTypeLength, AllNum, XNum, YNum, XSize, YSize, HandleArray);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateGraphFromID3D11Texture2D", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateGraphFromID3D11Texture2D(System.IntPtr pID3D11Texture2D);
		public static int CreateGraphFromID3D11Texture2D(System.IntPtr pID3D11Texture2D) => dx_CreateGraphFromID3D11Texture2D(pID3D11Texture2D);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphID3D11Texture2D", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetGraphID3D11Texture2D(int GrHandle);
		public static System.IntPtr GetGraphID3D11Texture2D(int GrHandle) => dx_GetGraphID3D11Texture2D(GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphID3D11RenderTargetView", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetGraphID3D11RenderTargetView(int GrHandle);
		public static System.IntPtr GetGraphID3D11RenderTargetView(int GrHandle) => dx_GetGraphID3D11RenderTargetView(GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetGraphID3D11DepthStencilView", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetGraphID3D11DepthStencilView(int GrHandle);
		public static System.IntPtr GetGraphID3D11DepthStencilView(int GrHandle) => dx_GetGraphID3D11DepthStencilView(GrHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_BltBackScreenToWindow", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_BltBackScreenToWindow(System.IntPtr Window, int ClientX, int ClientY);
		public static int BltBackScreenToWindow(System.IntPtr Window, int ClientX, int ClientY) => dx_BltBackScreenToWindow(Window, ClientX, ClientY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_BltRectBackScreenToWindow", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_BltRectBackScreenToWindow(System.IntPtr Window, RECT BackScreenRect, RECT WindowClientRect);
		public static int BltRectBackScreenToWindow(System.IntPtr Window, RECT BackScreenRect, RECT WindowClientRect) => dx_BltRectBackScreenToWindow(Window, BackScreenRect, WindowClientRect);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetScreenFlipTargetWindow", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetScreenFlipTargetWindow(System.IntPtr TargetWindow, double ScaleX, double ScaleY);
		public static int SetScreenFlipTargetWindow(System.IntPtr TargetWindow, double ScaleX = default, double ScaleY = default) => dx_SetScreenFlipTargetWindow(TargetWindow, ScaleX, ScaleY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDesktopScreenGraph", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDesktopScreenGraph(int x1, int y1, int x2, int y2, int GrHandle, int DestX, int DestY);
		public static int GetDesktopScreenGraph(int x1, int y1, int x2, int y2, int GrHandle, int DestX = 0, int DestY = 0) => dx_GetDesktopScreenGraph(x1, y1, x2, y2, GrHandle, DestX, DestY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDesktopScreenGraphMemImage", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetDesktopScreenGraphMemImage(int x1, int y1, int x2, int y2, out int Width, out int Height, out int Stride, int ColorBitDepth);
		public static System.IntPtr GetDesktopScreenGraphMemImage(int x1, int y1, int x2, int y2, out int Width, out int Height, out int Stride, int ColorBitDepth = 32) => dx_GetDesktopScreenGraphMemImage(x1, y1, x2, y2, out Width, out Height, out Stride, ColorBitDepth);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetMultiThreadFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetMultiThreadFlag(int Flag);
		public static int SetMultiThreadFlag(int Flag) => dx_SetMultiThreadFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDirectDrawDeviceIndex", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDirectDrawDeviceIndex(int Index);
		public static int SetUseDirectDrawDeviceIndex(int Index) => dx_SetUseDirectDrawDeviceIndex(Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetAeroDisableFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetAeroDisableFlag(int Flag);
		public static int SetAeroDisableFlag(int Flag) => dx_SetAeroDisableFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDirect3D9Ex", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDirect3D9Ex(int Flag);
		public static int SetUseDirect3D9Ex(int Flag) => dx_SetUseDirect3D9Ex(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDirect3D11", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDirect3D11(int Flag);
		public static int SetUseDirect3D11(int Flag) => dx_SetUseDirect3D11(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDirect3D11MinFeatureLevel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDirect3D11MinFeatureLevel(int Level);
		public static int SetUseDirect3D11MinFeatureLevel(int Level) => dx_SetUseDirect3D11MinFeatureLevel(Level);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDirect3D11WARPDriver", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDirect3D11WARPDriver(int Flag);
		public static int SetUseDirect3D11WARPDriver(int Flag) => dx_SetUseDirect3D11WARPDriver(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDirect3DVersion", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDirect3DVersion(int Version);
		public static int SetUseDirect3DVersion(int Version) => dx_SetUseDirect3DVersion(Version);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseDirect3DVersion", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseDirect3DVersion();
		public static int GetUseDirect3DVersion() => dx_GetUseDirect3DVersion();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseDirect3D11FeatureLevel", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseDirect3D11FeatureLevel();
		public static int GetUseDirect3D11FeatureLevel() => dx_GetUseDirect3D11FeatureLevel();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDirect3D11AdapterIndex", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDirect3D11AdapterIndex(int Index);
		public static int SetUseDirect3D11AdapterIndex(int Index) => dx_SetUseDirect3D11AdapterIndex(Index);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseDirectDrawFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseDirectDrawFlag(int Flag);
		public static int SetUseDirectDrawFlag(int Flag) => dx_SetUseDirectDrawFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseGDIFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseGDIFlag(int Flag);
		public static int SetUseGDIFlag(int Flag) => dx_SetUseGDIFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseGDIFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetUseGDIFlag();
		public static int GetUseGDIFlag() => dx_GetUseGDIFlag();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDirectDrawDeviceDescription", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDirectDrawDeviceDescription(int Number, out char StringBuffer);
		public static int GetDirectDrawDeviceDescription(int Number, out char StringBuffer) => dx_GetDirectDrawDeviceDescription(Number, out StringBuffer);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDirectDrawDeviceNum", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDirectDrawDeviceNum();
		public static int GetDirectDrawDeviceNum() => dx_GetDirectDrawDeviceNum();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseDirect3DDevice9", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetUseDirect3DDevice9();
		public static System.IntPtr GetUseDirect3DDevice9() => dx_GetUseDirect3DDevice9();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseDirect3D9BackBufferSurface", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetUseDirect3D9BackBufferSurface();
		public static System.IntPtr GetUseDirect3D9BackBufferSurface() => dx_GetUseDirect3D9BackBufferSurface();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseDirect3D11Device", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetUseDirect3D11Device();
		public static System.IntPtr GetUseDirect3D11Device() => dx_GetUseDirect3D11Device();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseDirect3D11DeviceContext", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetUseDirect3D11DeviceContext();
		public static System.IntPtr GetUseDirect3D11DeviceContext() => dx_GetUseDirect3D11DeviceContext();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseDirect3D11BackBufferTexture2D", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetUseDirect3D11BackBufferTexture2D();
		public static System.IntPtr GetUseDirect3D11BackBufferTexture2D() => dx_GetUseDirect3D11BackBufferTexture2D();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseDirect3D11BackBufferRenderTargetView", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetUseDirect3D11BackBufferRenderTargetView();
		public static System.IntPtr GetUseDirect3D11BackBufferRenderTargetView() => dx_GetUseDirect3D11BackBufferRenderTargetView();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetUseDirect3D11DepthStencilTexture2D", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetUseDirect3D11DepthStencilTexture2D();
		public static System.IntPtr GetUseDirect3D11DepthStencilTexture2D() => dx_GetUseDirect3D11DepthStencilTexture2D();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetDrawScreen_ID3D11RenderTargetView", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetDrawScreen_ID3D11RenderTargetView(System.IntPtr pID3D11RenderTargetView, System.IntPtr pID3D11DepthStencilView);
		public static int SetDrawScreen_ID3D11RenderTargetView(System.IntPtr pID3D11RenderTargetView, System.IntPtr pID3D11DepthStencilView = default) => dx_SetDrawScreen_ID3D11RenderTargetView(pID3D11RenderTargetView, pID3D11DepthStencilView);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_RefreshDxLibDirect3DSetting", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_RefreshDxLibDirect3DSetting();
		public static int RefreshDxLibDirect3DSetting() => dx_RefreshDxLibDirect3DSetting();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseMediaFoundationFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseMediaFoundationFlag(int Flag);
		public static int SetUseMediaFoundationFlag(int Flag) => dx_SetUseMediaFoundationFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_ColorKaiseki", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_ColorKaiseki(System.IntPtr PixelData, out COLORDATA ColorData);
		public static int ColorKaiseki(System.IntPtr PixelData, out COLORDATA ColorData) => dx_ColorKaiseki(PixelData, out ColorData);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddFontFile", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_AddFontFile(string FontFilePath);
		public static System.IntPtr AddFontFile(string FontFilePath) => dx_AddFontFile(FontFilePath);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddFontFileWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_AddFontFileWithStrLen(string FontFilePath, ulong FontFilePathLength);
		public static System.IntPtr AddFontFileWithStrLen(string FontFilePath, ulong FontFilePathLength) => dx_AddFontFileWithStrLen(FontFilePath, FontFilePathLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_AddFontFileFromMem", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_AddFontFileFromMem(System.IntPtr FontFileImage, int FontFileImageSize);
		public static System.IntPtr AddFontFileFromMem(System.IntPtr FontFileImage, int FontFileImageSize) => dx_AddFontFileFromMem(FontFileImage, FontFileImageSize);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_RemoveFontFile", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_RemoveFontFile(System.IntPtr FontHandle);
		public static int RemoveFontFile(System.IntPtr FontHandle) => dx_RemoveFontFile(FontHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateFontDataFile", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateFontDataFile(string SaveFilePath, string FontName, int Size, int BitDepth, int Thick, int Italic, int CharSet, string SaveCharaList);
		public static int CreateFontDataFile(string SaveFilePath, string FontName, int Size, int BitDepth, int Thick, int Italic = FALSE, int CharSet = -1, string SaveCharaList = default) => dx_CreateFontDataFile(SaveFilePath, FontName, Size, BitDepth, Thick, Italic, CharSet, SaveCharaList);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_CreateFontDataFileWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_CreateFontDataFileWithStrLen(string SaveFilePath, ulong SaveFilePathLength, string FontName, ulong FontNameLength, int Size, int BitDepth, int Thick, int Italic, int CharSet, string SaveCharaList, ulong SaveCharaListLength);
		public static int CreateFontDataFileWithStrLen(string SaveFilePath, ulong SaveFilePathLength, string FontName, ulong FontNameLength, int Size, int BitDepth, int Thick, int Italic = FALSE, int CharSet = -1, string SaveCharaList = default, ulong SaveCharaListLength = 0) => dx_CreateFontDataFileWithStrLen(SaveFilePath, SaveFilePathLength, FontName, FontNameLength, Size, BitDepth, Thick, Italic, CharSet, SaveCharaList, SaveCharaListLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_UpdateLayerdWindowForSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_UpdateLayerdWindowForSoftImage(int SIHandle);
		public static int UpdateLayerdWindowForSoftImage(int SIHandle) => dx_UpdateLayerdWindowForSoftImage(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_UpdateLayerdWindowForSoftImageRect", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_UpdateLayerdWindowForSoftImageRect(int SIHandle, int x1, int y1, int x2, int y2);
		public static int UpdateLayerdWindowForSoftImageRect(int SIHandle, int x1, int y1, int x2, int y2) => dx_UpdateLayerdWindowForSoftImageRect(SIHandle, x1, y1, x2, y2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_UpdateLayerdWindowForPremultipliedAlphaSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_UpdateLayerdWindowForPremultipliedAlphaSoftImage(int SIHandle);
		public static int UpdateLayerdWindowForPremultipliedAlphaSoftImage(int SIHandle) => dx_UpdateLayerdWindowForPremultipliedAlphaSoftImage(SIHandle);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_UpdateLayerdWindowForPremultipliedAlphaSoftImageRect", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_UpdateLayerdWindowForPremultipliedAlphaSoftImageRect(int SIHandle, int x1, int y1, int x2, int y2);
		public static int UpdateLayerdWindowForPremultipliedAlphaSoftImageRect(int SIHandle, int x1, int y1, int x2, int y2) => dx_UpdateLayerdWindowForPremultipliedAlphaSoftImageRect(SIHandle, x1, y1, x2, y2);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDesktopScreenSoftImage", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_GetDesktopScreenSoftImage(int x1, int y1, int x2, int y2, int SIHandle, int DestX, int DestY);
		public static int GetDesktopScreenSoftImage(int x1, int y1, int x2, int y2, int SIHandle, int DestX, int DestY) => dx_GetDesktopScreenSoftImage(x1, y1, x2, y2, SIHandle, DestX, DestY);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMemByResource", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMemByResource(string ResourceName, string ResourceType, int BufferNum);
		public static int LoadSoundMemByResource(string ResourceName, string ResourceType, int BufferNum = 1) => dx_LoadSoundMemByResource(ResourceName, ResourceType, BufferNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadSoundMemByResourceWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadSoundMemByResourceWithStrLen(string ResourceName, ulong ResourceNameLength, string ResourceType, ulong ResourceTypeLength, int BufferNum);
		public static int LoadSoundMemByResourceWithStrLen(string ResourceName, ulong ResourceNameLength, string ResourceType, ulong ResourceTypeLength, int BufferNum = 1) => dx_LoadSoundMemByResourceWithStrLen(ResourceName, ResourceNameLength, ResourceType, ResourceTypeLength, BufferNum);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetUseSoftwareMixingSoundFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetUseSoftwareMixingSoundFlag(int Flag);
		public static int SetUseSoftwareMixingSoundFlag(int Flag) => dx_SetUseSoftwareMixingSoundFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetEnableXAudioFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetEnableXAudioFlag(int Flag);
		public static int SetEnableXAudioFlag(int Flag) => dx_SetEnableXAudioFlag(Flag);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetEnableWASAPIFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetEnableWASAPIFlag(int Flag, int IsExclusive, int DevicePeriod, int SamplePerSec);
		public static int SetEnableWASAPIFlag(int Flag, int IsExclusive = TRUE, int DevicePeriod = -1, int SamplePerSec = 44100) => dx_SetEnableWASAPIFlag(Flag, IsExclusive, DevicePeriod, SamplePerSec);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_SetEnableASIOFlag", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_SetEnableASIOFlag(int Flag, int BufferSize, int SamplePerSec);
		public static int SetEnableASIOFlag(int Flag, int BufferSize = -1, int SamplePerSec = 44100) => dx_SetEnableASIOFlag(Flag, BufferSize, SamplePerSec);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_GetDSoundObj", CallingConvention=CallingConvention.StdCall)]
		extern static System.IntPtr dx_GetDSoundObj();
		public static System.IntPtr GetDSoundObj() => dx_GetDSoundObj();
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadMusicMemByResource", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadMusicMemByResource(string ResourceName, string ResourceType);
		public static int LoadMusicMemByResource(string ResourceName, string ResourceType) => dx_LoadMusicMemByResource(ResourceName, ResourceType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_LoadMusicMemByResourceWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_LoadMusicMemByResourceWithStrLen(string ResourceName, ulong ResourceNameLength, string ResourceType, ulong ResourceTypeLength);
		public static int LoadMusicMemByResourceWithStrLen(string ResourceName, ulong ResourceNameLength, string ResourceType, ulong ResourceTypeLength) => dx_LoadMusicMemByResourceWithStrLen(ResourceName, ResourceNameLength, ResourceType, ResourceTypeLength);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlayMusicByResource", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlayMusicByResource(string ResourceName, string ResourceType, int PlayType);
		public static int PlayMusicByResource(string ResourceName, string ResourceType, int PlayType) => dx_PlayMusicByResource(ResourceName, ResourceType, PlayType);
		
		[DllImport(DxLibDLLFileName, EntryPoint="dx_PlayMusicByResourceWithStrLen", CallingConvention=CallingConvention.StdCall)]
		extern static int dx_PlayMusicByResourceWithStrLen(string ResourceName, ulong ResourceNameLength, string ResourceType, ulong ResourceTypeLength, int PlayType);
		public static int PlayMusicByResourceWithStrLen(string ResourceName, ulong ResourceNameLength, string ResourceType, ulong ResourceTypeLength, int PlayType) => dx_PlayMusicByResourceWithStrLen(ResourceName, ResourceNameLength, ResourceType, ResourceTypeLength, PlayType);
		
	}
}