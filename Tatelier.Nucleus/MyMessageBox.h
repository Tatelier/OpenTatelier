#pragma once

#include <functional>
#include <memory>
#include <string>
#include <vector>

class Input;

enum class MyMessageType {
	Info,
	Warning,
	Error,
};

class MyMessageBoxItemInfo {
public:
	std::string Name = "‚Í‚¢";
	std::function<void()> Callback;
};

class MyMessageBoxInfo {
public:
	MyMessageType GetMessageType();
	void SsetMessageType(MyMessageType messageType);
	std::vector<MyMessageBoxItemInfo>& GetMyMessageItemList();
	void Add(const MyMessageBoxItemInfo& info);
	const std::string& GetText();
	void SetText(const std::string& text);

private:
	MyMessageType messageType;
	std::string text;
	std::vector<MyMessageBoxItemInfo> messageItemList;
};

class MyMessageBox {
public:
	static MyMessageBox& GetInstance()
	{
		static MyMessageBox instance;
		return instance;
	}
	void Start();
	void Update();
	void Draw();
	void Open(std::shared_ptr<MyMessageBoxInfo> info);
	void Close();
	void Finish();

private:
	const int WIDTH_2K = 1920;
	const int HEIGHT_2K = 1080;

	std::string moveWaveFilePath;

	std::shared_ptr<MyMessageBoxInfo> info;

	bool active;

	int abc = 0;

	Input* input = nullptr;

	bool isOpen = false;

	std::string header = "";
	std::string content = "";

	unsigned int color = 0xFFFFFF;
	unsigned int darkColor = 0xDDDDDD;
	unsigned int backColor = 0;

	const unsigned int WarningColor = 0xBBBB00;
	const unsigned int WarningDarkColor = 0x888800;
	const unsigned int ErrorColor = 0xFF8888;
	const unsigned int ErrorLightColor = 0xFF8888;
	const unsigned int ErrorDarkColor = 0xBB4444;

	const unsigned int InfoColor = 0x3089CC;
	const unsigned int InfoDarkColor = 0x2570A2;

	unsigned int buttonBackColor;
	unsigned int buttonBackDarkColor;

	int width;
	int height;

	int maxWidth = 1280;
	int maxHeight = 840;

	int maxInnerWidth = 1160;
	int maxInnerHeight = 620;

	int minInnerWidth = 1080;
	int minInnerHeight = 80;

	int innerWidth = maxInnerWidth;
	int innerHeight = maxInnerHeight;

	int buttomFrameHeight = 80;

	int margin = 15;

	int radius = 20;

	int innerFrameBorderWidth = 5;

	int fontHeaderHandle;
	int fontContentHandle;
	MyMessageBox() { }
	void DrawButtonOther(std::string text, int x, int y, uint32_t clr);
	void DrawButtonNowSelect(std::string text, int x, int y, uint32_t clr);
	void DrawAllBotton(int right, int bottom);
};