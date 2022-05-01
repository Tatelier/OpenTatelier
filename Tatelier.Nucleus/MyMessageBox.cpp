#include "MyMessageBox.h"

#include "DxLib.h"
#include "Guard.h"
#include "ThemeConfig.h"

#include "Input.h"

#include <filesystem>
#include <sstream> // std::ostringstream

#pragma comment(lib, "winmm")

#define RE_WIDTH(width) ((int)((double)ThemeConfig::GetInstance().GetDrawMode().Width / WIDTH_2K * width))
#define RE_HEIGHT(height) ((int)((double)ThemeConfig::GetInstance().GetDrawMode().Height / HEIGHT_2K * height))

void MyMessageBox::Start()
{
	fontHeaderHandle = CreateFontToHandle(GetFontName(), 40, 0, DX_FONTTYPE_ANTIALIASING_4X4);
	fontContentHandle = CreateFontToHandle(GetFontName(), 28, 0, DX_FONTTYPE_ANTIALIASING_4X4);
	auto& drawMode = ThemeConfig::GetInstance().GetDrawMode();

	// 描画サイズに合わせてサイズを調整
	maxWidth = RE_WIDTH(maxWidth);
	maxHeight = RE_HEIGHT(maxHeight);

	minInnerWidth = RE_WIDTH(minInnerWidth);
	minInnerHeight = RE_HEIGHT(minInnerHeight);

	maxInnerWidth = RE_WIDTH(maxInnerWidth);
	maxInnerHeight = RE_HEIGHT(maxInnerHeight);

	buttomFrameHeight = RE_HEIGHT(buttomFrameHeight);

	margin = RE_WIDTH(margin);

	radius = RE_WIDTH(radius);

	innerFrameBorderWidth = RE_WIDTH(innerFrameBorderWidth);

	header = "Undefined";
	content = "Undefined";

	std::filesystem::path path;
	char szEnv[256] = { '\0' };
	GetEnvironmentVariable("windir",
		szEnv,
		sizeof(szEnv) / sizeof(szEnv[0]));

	path /= szEnv;
	path /= "Media";
	path /= "Windows Battery Low.wav";
	moveWaveFilePath = path.string();

	input = &Input::GetInstance();
}

void MyMessageBox::Update()
{
	if (active) {
		if (input->GetKeyDown(KEY_INPUT_LEFT)) {
			SetVolumeSoundFile(8500);
			PlaySoundFile(moveWaveFilePath.c_str(), DX_PLAYTYPE_BACK);

			abc = (abc + 1) % info->GetMyMessageItemList().size();
		}
		if (input->GetKeyDown(KEY_INPUT_RIGHT)) {
			SetVolumeSoundFile(8500);
			PlaySoundFile(moveWaveFilePath.c_str(), DX_PLAYTYPE_BACK);

			abc = (abc + (info->GetMyMessageItemList().size() - 1)) % info->GetMyMessageItemList().size();
		}

		if (input->GetKeyDown(KEY_INPUT_SPACE)) {
			info->GetMyMessageItemList()[abc].Callback();
			Close();
		}

		if (input->GetKeyDown(KEY_INPUT_Q)) {
			info->GetMyMessageItemList()[0].Callback();
			Close();
		}
	}

	active = isOpen;
}

void MyMessageBox::Draw()
{
	if (!active)
		return;

	auto& drawMode = ThemeConfig::GetInstance().GetDrawMode();
	auto& drawModeHalf = ThemeConfig::GetInstance().GetDrawModeHalf();

	// 全体を暗くする
	{
		DrawBlendModeGuard guard;
		SetDrawBlendMode(DX_BLENDMODE_ALPHA, 191);
		DrawBox(0, 0, drawMode.Width, drawMode.Height, 0, TRUE);
	}

	// 全体枠
	{
		DrawBlendModeGuard blendGuard;

		SetDrawBlendMode(DX_BLENDMODE_ALPHA, 239);

		DrawRoundRectAA(
			drawModeHalf.Width - (width / 2), drawModeHalf.Height - (height / 2), drawModeHalf.Width + (width / 2), drawModeHalf.Height + (height / 2), radius, radius, radius / 2, 0x222e3f, TRUE);
	}

	// 内側の枠
	DrawRoundRectAA(
		drawModeHalf.Width - (width / 2) + margin, drawModeHalf.Height - (height / 2) + margin, drawModeHalf.Width + (width / 2) - margin, drawModeHalf.Height + (height / 2) - margin, radius, radius, radius / 2, 0x121e2f, FALSE, innerFrameBorderWidth);

	// ヘッダー
	{
		int x = drawModeHalf.Width - GetDrawStringWidthToHandle(header.c_str(), header.size(), fontHeaderHandle) / 2;
		int y = drawModeHalf.Height - (height / 2) + 40;

		DrawStringToHandle(x, y, header.c_str(), color, fontHeaderHandle);
	}

	int left = drawModeHalf.Width - (innerWidth / 2);
	int top = drawModeHalf.Height - height / 2 + 120;
	int right = left + innerWidth;
	int bottom = top + innerHeight;

	// 内容
	{
		DrawAreaGuard areaGuard;

		SetDrawArea(left, top, right, bottom);
		DrawObtainsString(0, 0, GetFontSizeToHandle(fontContentHandle) + 4, content.c_str(), 0xFFFFFF, 0x000000, fontContentHandle);
	}
	DrawAllBotton(right, bottom);
}

void MyMessageBox::Open(std::shared_ptr<MyMessageBoxInfo> info)
{
	this->info = info;

	if (info->GetMyMessageItemList().size() == 0) {
		auto itemInfo = MyMessageBoxItemInfo();
		itemInfo.Name = "OK";
		this->info->Add(itemInfo);
	}
	abc = 0;

	switch (info->GetMessageType()) {
	case MyMessageType::Info:
		color = InfoColor;
		header = "Info";
		buttonBackColor = InfoColor;
		buttonBackDarkColor = InfoDarkColor;
		break;
	case MyMessageType::Warning:
		color = WarningColor;
		header = "Warning";
		buttonBackColor = WarningColor;
		buttonBackDarkColor = WarningDarkColor;
		break;
	case MyMessageType::Error:
		color = ErrorColor;
		darkColor = ErrorLightColor;
		buttonBackColor = ErrorColor;
		buttonBackDarkColor = ErrorDarkColor;
		header = "Error";
		PlaySound("SystemHand", nullptr,
			SND_ALIAS | SND_NODEFAULT | SND_ASYNC);
		break;
	}

	backColor = buttonBackColor;

	content = info->GetText();

	std::vector<std::string> lines;
	std::stringstream ss(content);
	std::string buffer;
	while (std::getline(ss, buffer, '\n')) {
		lines.push_back(buffer);
	}

	int mW = 0;
	{
		int temp;
		for (auto& line : lines) {
			temp = GetDrawStringWidthToHandle(line.c_str(), line.size(), fontContentHandle);
			if (mW < temp) {
				mW = temp;
			}
		}
	}

	if (mW < minInnerWidth) {
		mW = minInnerWidth;
	}
	else if (mW > maxInnerWidth) {
		mW = maxInnerWidth;
	}

	int mH = 0;

	{
		for (auto& line : lines) {
			mH += ((GetDrawStringWidthToHandle(line.c_str(), line.size(), fontContentHandle) / mW) + 1) * (GetFontSizeToHandle(fontContentHandle) + 4);
		}
	}
	if (mH < minInnerHeight) {
		mH = minInnerHeight;
	}
	else if (mH > maxInnerHeight) {
		mH = maxInnerHeight;
	}

	innerWidth = mW;
	innerHeight = mH;

	isOpen = true;

	width = innerWidth + (maxWidth - maxInnerWidth);
	height = innerHeight + (maxHeight - maxInnerHeight) + buttomFrameHeight;
}

void MyMessageBox::Close()
{
	active = false;
	isOpen = false;
	//input->ChangePrevInput();
}

void MyMessageBox::Finish()
{
}

void MyMessageBox::DrawButtonOther(std::string text, int x, int y, uint32_t clr)
{
	int w = GetDrawStringWidthToHandle(text.c_str(), text.size(), fontContentHandle);

	int l = x;
	int t = y;

	//DrawRoundRectAA(
	//	l
	//	, t
	//	, l + w + 74
	//	, t + GetFontSizeToHandle(fontContentHandle) + 40
	//	, 30, 30
	//	, 10
	//	, clr, FALSE, 3);

	DrawStringToHandle(l + 37, t + 20, text.c_str(), clr, fontContentHandle);
}

void MyMessageBox::DrawButtonNowSelect(std::string text, int x, int y, uint32_t clr)
{
	int w = GetDrawStringWidthToHandle(text.c_str(), text.size(), fontContentHandle);

	int l = x;
	int t = y;

	DrawRoundRectAA(
		l, t, l + w + 74, t + GetFontSizeToHandle(fontContentHandle) + 40, 30, 30, 10, backColor, FALSE, 3);

	DrawRoundRectAA(
		l, t, l + w + 74, t + GetFontSizeToHandle(fontContentHandle) + 40, 30, 30, 10, backColor, TRUE, 3);

	DrawStringToHandle(l + 37, t + 20, text.c_str(), clr, fontContentHandle);
}
void MyMessageBox::DrawAllBotton(int right, int bottom)
{
	unsigned int clr = 0xFFFFFF;
	switch (info->GetMessageType()) {
	case MyMessageType::Info:
		clr = InfoColor;
		break;
	case MyMessageType::Warning:
		clr = WarningColor;
		break;
	case MyMessageType::Error:
		clr = ErrorColor;
		break;
	}

	int l = right;
	int t = bottom + 40 + 20;

	auto& itemList = info->GetMyMessageItemList();

	for (int i = 0; i < itemList.size(); i++) {
		auto text = itemList[i].Name;
		auto w = GetDrawStringWidthToHandle(itemList[i].Name.c_str(), itemList[i].Name.size(), fontContentHandle);

		l -= (w + 80);

		if (abc == i) {
			DrawButtonNowSelect(text, l, t, 0x222e3f);
		}
		else {
			DrawButtonOther(text, l, t, clr);
		}
	}
}

MyMessageType MyMessageBoxInfo::GetMessageType()
{
	return messageType;
}

void MyMessageBoxInfo::SsetMessageType(MyMessageType messageType)
{
	this->messageType = messageType;
}

std::vector<MyMessageBoxItemInfo>& MyMessageBoxInfo::GetMyMessageItemList()
{
	return messageItemList;
}

void MyMessageBoxInfo::Add(const MyMessageBoxItemInfo& info)
{
	messageItemList.push_back(info);
}

const std::string& MyMessageBoxInfo::GetText()
{
	return text;
}

void MyMessageBoxInfo::SetText(const std::string& text)
{
	this->text = text;
}
