#pragma once
/**
 * @brief システムディレクトリを取得するクラス
 * @file SystemDirectory.Class.h
 * @date 2008/03/10
 */

#pragma once
#include <string>

 /**
   * @brief システムディレクトリを取得するクラス
   * @code
   * インスタンス化しないで、静的に使用する
   *
   * 例 1 :
   * // Windows ディレクトリを取得
   * std::string windir = SystemDirectory::windows();
   * @endcode
   */
class SystemDirectory {
public:
	static std::string windows();
	static std::string system();
	static std::string programFiles();
	static std::string programFilesCommon();
	static std::string profiles();
	static std::string font();
	static std::string resources();

private:
	static std::string getShellDirectory(int nFolder);
};