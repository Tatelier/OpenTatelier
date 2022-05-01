#include <Windows.h>
#include <filesystem>

#include <istream>
#include <sstream>

#include "Utility.h"

#include <algorithm> // std::equal
#include <iterator> // std::rbegin, std::rend

bool ttleStartWith(const std::string& s, const std::string& prefix)
{
	auto size = prefix.size();
	if (s.size() < size)
		return false;
	return std::equal(std::begin(prefix), std::end(prefix), std::begin(s));
}

bool ttleEndWith(const std::string& s, const std::string& suffix)
{
	if (s.size() < suffix.size())
		return false;
	return std::equal(std::rbegin(suffix), std::rend(suffix), std::rbegin(s));
}

int ttleEndWithIndex(const std::string& s, const std::string& suffixSplit)
{

	std::stringstream ss{ suffixSplit };
	std::string buf;

	for (int i = 1; std::getline(ss, buf, '|'); i++) {
		if (ttleEndWith(s, buf)) {
			return i;
		}
	}

	return 0;
}

bool ttleGetFileNamesRecursive(const std::string& folderPath, std::vector<std::string>* file_names, std::function<bool(const std::string&)> filter)
{
	if (!std::filesystem::exists(folderPath))
		return true;

	std::filesystem::recursive_directory_iterator iter(folderPath), end;
	std::error_code err;

	for (; iter != end && !err; iter.increment(err)) {
		const std::filesystem::directory_entry entry = *iter;

		std::string path = entry.path().string();

		if (filter(path)) {
			file_names->push_back(path);
		}
	}

	if (err) {
		return false;
	}
	return true;
}

std::string ttleUTF8toSjis(const std::string& srcUTF8)
{
	//Unicodeへ変換後の文字列長を得る
	int lenghtUnicode = MultiByteToWideChar(CP_UTF8, 0, srcUTF8.c_str(), srcUTF8.size() + 1, NULL, 0);

	//必要な分だけUnicode文字列のバッファを確保
	wchar_t* bufUnicode = new wchar_t[lenghtUnicode];

	//UTF8からUnicodeへ変換
	MultiByteToWideChar(CP_UTF8, 0, srcUTF8.c_str(), srcUTF8.size() + 1, bufUnicode, lenghtUnicode);

	//ShiftJISへ変換後の文字列長を得る
	int lengthSJis = WideCharToMultiByte(CP_THREAD_ACP, 0, bufUnicode, -1, NULL, 0, NULL, NULL);

	//必要な分だけShiftJIS文字列のバッファを確保
	char* bufShiftJis = new char[lengthSJis];

	//UnicodeからShiftJISへ変換
	WideCharToMultiByte(CP_THREAD_ACP, 0, bufUnicode, lenghtUnicode + 1, bufShiftJis, lengthSJis, NULL, NULL);

	std::string strSJis(bufShiftJis);

	delete bufUnicode;
	delete bufShiftJis;

	return strSJis;
}

std::string ttleConvertToSjis(const std::string& text)
{
	EncodingType etype = ttleGetEncodingType(text);
	switch (etype) {
	case EncodingType::UTF8:
		return ttleUTF8toSjis(text);
	default:
		return text;
	}
}

EncodingType ttleGetEncodingType(const std::string& text)
{
	const char bEscape = 0x1B;
	const char bAt = 0x40;
	const char bDollar = 0x24;
	const char bAnd = 0x26;
	const char bOpen = 0x28; //'('
	const char bB = 0x42;
	const char bD = 0x44;
	const char bJ = 0x4A;
	const char bI = 0x49;

	int len = text.size();
	char b1, b2, b3, b4;

	//for (int i = 0; i < len - 2; i++)
	//{
	//	b1 = text[i];
	//	b2 = text[i + 1];
	//	b3 = text[i + 2];

	//	if (b1 == bEscape)
	//	{
	//		if (b2 == bDollar && b3 == bAt)
	//		{
	//			//JIS_0208 1978
	//			//JIS
	//			return EncodingType::Unknown; //System.Text.Encoding.GetEncoding(50220);
	//		}
	//		else if (b2 == bDollar && b3 == bB)
	//		{
	//			//JIS_0208 1983
	//			//JIS
	//			return EncodingType::Unknown; //System.Text.Encoding.GetEncoding(50220);
	//		}
	//		else if (b2 == bOpen && (b3 == bB || b3 == bJ))
	//		{
	//			//JIS_ASC
	//			//JIS
	//			return EncodingType::Unknown; //System.Text.Encoding.GetEncoding(50220);
	//		}
	//		else if (b2 == bOpen && b3 == bI)
	//		{
	//			//JIS_KANA
	//			//JIS
	//			return EncodingType::Unknown; //System.Text.Encoding.GetEncoding(50220);
	//		}
	//		if (i < len - 3)
	//		{
	//			b4 = text[i + 3];
	//			if (b2 == bDollar && b3 == bOpen && b4 == bD)
	//			{
	//				//JIS_0212
	//				//JIS
	//				return EncodingType::Unknown; //System.Text.Encoding.GetEncoding(50220);
	//			}
	//			if (i < len - 5 &&
	//				b2 == bAnd && b3 == bAt && b4 == bEscape &&
	//				text[i + 4] == bDollar && text[i + 5] == bB)
	//			{
	//				//JIS_0208 1990
	//				//JIS
	//				return EncodingType::Unknown; //System.Text.Encoding.GetEncoding(50220);
	//			}
	//		}
	//	}
	//}

	//should be euc|sjis|utf8
	//use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
	int sjis = 0;
	int euc = 0;
	int utf8 = 0;
	for (int i = 0; i < len - 1; i++) {
		b1 = text[i];
		b2 = text[i + 1];
		if ((((char)0x81 <= b1 && b1 <= (char)0x9F) || ((char)0xE0 <= b1 && b1 <= (char)0xFC)) && (((char)0x40 <= b2 && b2 <= (char)0x7E) || ((char)0x80 <= b2 && b2 <= (char)0xFC))) {
			//SJIS_C
			sjis += 2;
			i++;
		}
	}
	for (int i = 0; i < len - 1; i++) {
		b1 = text[i];
		b2 = text[i + 1];
		if ((((char)0xA1 <= b1 && b1 <= (char)0xFE) && ((char)0xA1 <= b2 && b2 <= (char)0xFE)) || (b1 == (char)0x8E && ((char)0xA1 <= b2 && b2 <= (char)0xDF))) {
			//EUC_C
			//EUC_KANA
			euc += 2;
			i++;
		}
		else if (i < len - 2) {
			b3 = text[i + 2];
			if (b1 == (char)0x8F && ((char)0xA1 <= b2 && b2 <= (char)0xFE) && ((char)0xA1 <= b3 && b3 <= (char)0xFE)) {
				//EUC_0212
				euc += 3;
				i += 2;
			}
		}
	}
	for (int i = 0; i < len - 1; i++) {
		b1 = text[i];
		b2 = text[i + 1];
		if (((char)0xC0 <= b1 && b1 <= (char)0xDF) && ((char)0x80 <= b2 && b2 <= (char)0xBF)) {
			//UTF8
			utf8 += 2;
			i++;
		}
		else if (i < len - 2) {
			b3 = text[i + 2];
			if (((char)0xE0 <= b1 && b1 <= (char)0xEF) && ((char)0x80 <= b2 && b2 <= (char)0xBF) && ((char)0x80 <= b3 && b3 <= (char)0xBF)) {
				//UTF8
				utf8 += 3;
				i += 2;
			}
		}
	}
	//M. Takahashi's suggestion
	//utf8 += utf8 / 2;

	if (euc > sjis && euc > utf8) {
		//EUC
		return EncodingType::EUC;
	}
	else if (sjis > euc && sjis > utf8) {
		//SJIS
		return EncodingType::ShiftJIS;
	}
	else if (utf8 > euc && utf8 > sjis) {
		//UTF8
		return EncodingType::UTF8;
	}

	return EncodingType::Unknown;
}