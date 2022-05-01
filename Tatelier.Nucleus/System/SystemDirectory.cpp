#include "SystemDirectory.h"

#include <Lmcons.h>
#include <shlobj.h>
#include <userenv.h>
#include <windows.h>

// ------------------------------------------------------------------
// リンクするライブラリ
// ------------------------------------------------------------------
#pragma comment(lib, "userenv.lib")

// ------------------------------------------------------------------
// マクロ
// ------------------------------------------------------------------
/**
 * @brief ディレクトリ操作メソッド用の最大パス文字数
 *
 * MAX_PATH は 260 バイト分しかないので、足りない場合に備えて
 * 4096 バイトに拡張
 */
#define SYSTEMDIRECTORY_MAX_PATH (4096)

 // ------------------------------------------------------------------
 // プライベートメソッド
 // ------------------------------------------------------------------
std::string SystemDirectory::getShellDirectory(int nFolder)
{
	HRESULT result;
	LPITEMIDLIST pidl;
	std::string str;
	IMalloc* pMalloc;

	SHGetMalloc(&pMalloc);
	result = ::SHGetSpecialFolderLocation(NULL,
		nFolder,
		&pidl);

	if (FAILED(result)) {
		pMalloc->Release();
		str.assign("\0", 1);
		return str;
	}

	str.assign("\0", SYSTEMDIRECTORY_MAX_PATH + 1);
	::SHGetPathFromIDList(pidl, (LPTSTR)str.c_str());

	pMalloc->Free(pidl);
	pMalloc->Release();

	return str;
}

// ------------------------------------------------------------------
// パブリックメソッド
// ------------------------------------------------------------------

/**
 * @brief Windows ディレクトリのフルパスを取得
 *
 * @code
 * // 出力例 (終端に \ は含まない)
 * C:\WINDOWS
 * @endcode
 *
 * @return Windows ディレクトリのパス
 * @note 失敗した時は空の文字列を返す
 */
std::string SystemDirectory::windows()
{
	unsigned int result;
	std::string str;

	str.assign("\0", SYSTEMDIRECTORY_MAX_PATH + 1);
	result = ::GetSystemWindowsDirectory((LPTSTR)str.c_str(),
		SYSTEMDIRECTORY_MAX_PATH);

	return str;
}

/**
 * @brief システムファイルのディレクトリのフルパスを取得
 *
 * @code
 * // 出力例 (終端に \ は含まない)
 * C:\WINDOWS\system32
 * @endcode
 *
 * @attention IE5 以降または Windows 2000 以降
 * @return システムファイルのディレクトリのパス
 * @note 失敗した時は空の文字列を返す
 */
std::string SystemDirectory::system()
{
	return getShellDirectory(CSIDL_SYSTEM);
}

/**
 * @brief Program Files のディレクトリをフルパスで取得
 *
 * @code
 * // 出力例 (終端に \ は含まない)
 * C:\Program Files
 * @endcode
 *
 * @attention IE5 以降または Windows 2000 以降
 * @return Program Files のディレクトリ
 * @note 失敗した時は空文字列を返す
 */
std::string SystemDirectory::programFiles()
{
	return getShellDirectory(CSIDL_PROGRAM_FILES);
}

/**
 * @brief Program Files\\Common Files のディレクトリをフルパスで取得
 *
 * @code
 * // 出力例 (終端に \ は含まない)
 * C:\Program Files\Common Files
 * @endcode
 *
 * @attention Windows Me 以外で IE5 以降 (NT, 2000, XP)
 * @return Program Files\Common Files のディレクトリ
 * @note 失敗した時は空文字列を返す
 */
std::string SystemDirectory::programFilesCommon()
{
	return getShellDirectory(CSIDL_PROGRAM_FILES_COMMON);
}

/**
 * @brief Documents and Settings のディレクトリをフルパスで取得
 *
 * @code
 * // 出力例 (終端に \ は含まない)
 * C:\Documents and Settings
 * @endcode
 *
 * @return Documents and Settings のディレクトリ
 * @note 失敗した時は空文字列を返す
 */
std::string SystemDirectory::profiles()
{
	BOOL result;
	DWORD size;

	std::string str;
	str.assign("\0", SYSTEMDIRECTORY_MAX_PATH + 1);
	size = SYSTEMDIRECTORY_MAX_PATH;

	result = ::GetProfilesDirectory((LPTSTR)str.c_str(), &size);

	if (result == 0)
		str.assign("\0", 1);

	return str;
}

/**
 * @brief フォントのディレクトリをフルパスで取得
 *
 * @code
 * // 出力例 (終端に \ は含まない)
 * C:\WINDOWS\Fonts
 * @endcode
 *
 * @return アプリケーションデータのディレクトリ
 * @note 失敗した時は空文字列を返す
 */
std::string SystemDirectory::font()
{
	return getShellDirectory(CSIDL_FONTS);
}

/**
 * @brief リソースファイルのディレクトリをフルパスで取得
 *
 * このディレクトリには、デスクトップテーマ等が入るようです。
 *
 * @code
 * // 出力例 (終端に \ は含まない)
 * C:\Windows\Resources
 * @endcode
 *
 * @attention Windows Vista 以降
 * @return リソースファイルのディレクトリ
 * @note 失敗した時は空文字列を返す
 */
std::string SystemDirectory::resources()
{
	return getShellDirectory(CSIDL_RESOURCES);
}