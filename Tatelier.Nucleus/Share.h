#pragma once
class Share {
	static Share instance;
	Share() { }
	Share(const Share& a) { }

public:
	Share& GetInstance()
	{
		return instance;
	}
	void Reset()
	{
		instance = Share();
	}
	~Share()
	{
	}
};
