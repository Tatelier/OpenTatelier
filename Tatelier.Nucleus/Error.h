#pragma once

#include <string>
#include <vector>

struct ErrorItem {
	unsigned int ErrorCode = 0x80000000;
	std::string Text = "Undefined";
};

class Error : public std::vector<ErrorItem> {
public:
};

/**
 * @brief ƒGƒ‰[Ši”[•Ï”
 */
extern thread_local Error err;