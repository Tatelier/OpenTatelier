#include "hjson-ex.h"
#include "../Utility.h"
#include "hjson.h"
#include <Windows.h>
#include <filesystem>
#include <fstream>

Hjson::Value HjsonEx::Load(const std::string& path)
{
	using namespace std::filesystem;

	Hjson::Value result;

	if (!exists(path))
		return result;

	std::ifstream ifs(path);

	if (!ifs) {
		return result;
	}

	std::ostringstream buf;
	buf << ifs.rdbuf();

	std::string jsonText = ttleConvertToSjis(buf.str());

	result = Hjson::Unmarshal(jsonText);

	return result;
}

int HjsonEx::EQv(const Hjson::Value& hj_value, const std::string& key, Hjson::Value* result)
{
	return EQv(hj_value, key, result, Hjson::Value());
}

int HjsonEx::EQv(const Hjson::Value& hj_value, const std::string& key, Hjson::Value* result, const Hjson::Value& failure)
{
	if (hj_value.type() <= Hjson::Type::Null) {
		(*result) = failure;
		return 0;
	}
	(*result) = hj_value;

	std::string s;
	std::stringstream ss{ key }; // 入出力可能なsstreamに変換

	while (std::getline(ss, s, '.')) { // スペース（' '）で区切って，格納
		(*result) = (*result)[s];
		if (result->type() <= Hjson::Type::Null) {
			(*result) = failure;
			return 0;
		}
	}

	return 1;
}

int HjsonEx::EQa(const Hjson::Value& hj_value, const std::string& key, Hjson::Value* result)
{
	return EQa(hj_value, key, result, Hjson::Value());
}

int HjsonEx::EQa(const Hjson::Value& hj_value, const std::string& key, Hjson::Value* result, const Hjson::Value& failure)
{
	Hjson::Value v;
	EQv(hj_value, key, &v);

	if (v.type() == Hjson::Type::Vector) {
		(*result) = v;
		return 1;
	}
	else {
		(*result) = failure;
		return 0;
	}
}

int HjsonEx::EQs(const Hjson::Value& hj_value, const std::string& key, std::string* result)
{
	return EQs(hj_value, key, result, "");
}

int HjsonEx::EQs(const Hjson::Value& hj_value, const std::string& key, std::string* result, const std::string& failure)
{
	Hjson::Value v;

	EQv(hj_value, key, &v);

	if (v.type() == Hjson::Type::String) {
		(*result) = ttleConvertToSjis(v.to_string());
		return 1;
	}
	else {
		(*result) = failure;
		return 0;
	}
}

int HjsonEx::EQi(const Hjson::Value& hj_value, const std::string& key, int32_t* result)
{
	return EQi(hj_value, key, result, 0);
}

int HjsonEx::EQi(const Hjson::Value& hj_value, const std::string& key, int32_t* result, const int32_t& failure)
{
	Hjson::Value v;

	EQv(hj_value, key, &v);

	if (v.type() == Hjson::Type::Int64) {
		(*result) = (int)v.to_int64();
		return 1;
	}
	else {
		(*result) = failure;
		return 0;
	}
}