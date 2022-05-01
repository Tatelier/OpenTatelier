#include "SongSelectScene.h"

#include <filesystem>

#include "../SceneControlMaster.h"

#include "../Error.h"

#include "../ThemeConfig.h"
#include "Background.h"
#include "CategoryControl.h"
#include "Demo.h"
#include "Item.h"
#include "ItemControl.h"
#include "SelectItem.h"
#include "SelectItemControl.h"

#include "../Input.h"

#include "../hjson/hjson-ex.h"
#include "../hjson/hjson.h"

#include "../MainConfig.h"

namespace SongSelect {

	int fontHandle;
	void SongSelectScene::Start()
	{
		background = new Background();
		demo = new Demo();

		std::filesystem::path path;
		path /= MainConfig::GetInstance().GetThemeFolderPath();
		path /= "SongSelect/SongSelectConfig.hjson";

		auto hjson = HjsonEx::Load(path.string());

		auto categoryControl = std::shared_ptr<CategoryControl>(CategoryControl::Create("Resources/Score/Score.hjson"));

		if (err.size() > 0) {
		}

		auto itemControl = std::shared_ptr<ItemControl>(ItemControl::Create("Resources/Score", categoryControl));

		if (err.size() > 0) {
		}

		selectItemControl = std::shared_ptr<SelectItemControl>(SelectItemControl::Create(itemControl, categoryControl->GetImageRootFolder()));

		if (err.size() > 0) {
		}

		Hjson::Value imageInfo;
		HjsonEx::EQa(hjson, "SelectItem.ImageInfo", &imageInfo);
		selectItemControl->SetThemeData(MainConfig::GetInstance().GetThemeFolderPath(), imageInfo);

		// ‘I‹È‰æ–Ê”wŒi‚ð‰Šú‰æ‘œ‚É•ÏX
		background->Change(
			selectItemControl->GetNowSelectItem()->GetBackgroundInfo(), 0);

		fontHandle = CreateFontToHandle("", 40, 0, DX_FONTTYPE_ANTIALIASING_EDGE, -1, 12, 0, -1);
	}

	void SongSelectScene::Update()
	{
		background->Update();
		auto& input = Input::GetInstance();
		if (input.GetKeyDown(KEY_INPUT_0)) {
			SceneControlMaster::GetInstance().SetLoadingEnabled(true);
		}
		if (input.GetKeyDown(KEY_INPUT_D)) {
			selectItemControl->Prev();
			// ‘I‹È‰æ–Ê”wŒi‚ð‰Šú‰æ‘œ‚É•ÏX
			background->Change(
				selectItemControl->GetNowSelectItem()->GetBackgroundInfo(), 0);
		}

		if (input.GetKeyDown(KEY_INPUT_K)) {
			selectItemControl->Next();
			// ‘I‹È‰æ–Ê”wŒi‚ð‰Šú‰æ‘œ‚É•ÏX
			background->Change(
				selectItemControl->GetNowSelectItem()->GetBackgroundInfo(), 0);
		}

		if (input.GetKeyDown(KEY_INPUT_F)) {
			selectItemControl->Open();
		}

		if (input.GetKeyDown(KEY_INPUT_Q)) {
			selectItemControl->Close();
		}
	}
	void SongSelectScene::Draw()
	{
		background->Draw();
		DrawStringF(960, 540, ("£" + selectItemControl->GetNowSelectItem()->GetMainTitle()).c_str(), 0xFFFFFF);
		auto item = selectItemControl->GetNowSelectItem();
		for (int i = 0; i < 5; i++) {
			item = item->GetNext();
			DrawStringF(960, 540 + (50 * (i + 1)), ("@" + item->GetMainTitle()).c_str(), 0xFFFFFF);
		}
		item = selectItemControl->GetNowSelectItem();
		for (int i = 0; i < 5; i++) {
			item = item->GetPrev();
			DrawStringF(960, 540 - (50 * (i + 1)), ("@" + item->GetMainTitle()).c_str(), 0xFFFFFF);
		}

		DrawStringFToHandle(0, 0, "‚ ‚¢‚¤‚¦‚¨", 0xFFFFFF, fontHandle, 0x000000);
	}
	void SongSelectScene::Finish()
	{
		delete background;
		delete demo;
	}
	SongSelectScene::SongSelectScene()
	{
	}
	SongSelectScene::~SongSelectScene()
	{
	}
}