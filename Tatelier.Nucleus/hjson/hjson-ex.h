#pragma once

#include <iostream>
#include <sstream>

namespace Hjson {
	class Value;
}

namespace HjsonEx {

	Hjson::Value Load(const std::string& path);

	int EQv(const Hjson::Value& hj_value, const std::string& key, Hjson::Value* result);
	int EQv(const Hjson::Value& hj_value, const std::string& key, Hjson::Value* result, const Hjson::Value& failure);

	int EQa(const Hjson::Value& hj_value, const std::string& key, Hjson::Value* result);
	int EQa(const Hjson::Value& hj_value, const std::string& key, Hjson::Value* result, const Hjson::Value& failure);

	/**
		 * @brief 文字列を取得
		 */
	int EQs(const Hjson::Value& hj_value, const std::string& key, std::string* result);
	int EQs(const Hjson::Value& hj_value, const std::string& key, std::string* result, const std::string& failure);

	/**
		 * @brief int32型の値を取得 ※失敗時は0
		 */
	int EQi(const Hjson::Value& hj_value, const std::string& key, int32_t* result);

	/**
		 * @brief int32型の値を取得
		 */
	int EQi(const Hjson::Value& hj_value, const std::string& key, int32_t* result, const int32_t& failure);
}