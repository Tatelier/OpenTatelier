#include "LoadingScene.h"
#include "../Guard.h"
#include "DxLib.h"
#include <cmath>

#include "../ThemeControl.h"

namespace Loading {
	SceneBase* LoadingScene::Create()
	{
		static LoadingScene scene;
		return &scene;
	}
	int LoadingScene::Annihilate(SceneBase* scene)
	{
		return 0;
	}

	int loadingCircle;

	bool isStartOK = 0;
	float mag;

	void LoadingScene::Start()
	{
	}
	float v = 0;

	void LoadingScene::Update()
	{
		if (!isStartOK) {
			mag = ThemeControl::GetInstance().GetNowTheme()->GetMagnification();
			int cell = (int)(120 * mag);
			loadingCircle = MakeScreen(cell, cell, TRUE);
			{
				DrawScreenGuard guard;
				SetDrawScreen(loadingCircle);

				DrawCircleAA(60 * mag, 60 * mag, 45 * mag, 32 * mag, 0x000000, FALSE, 16 * mag);
				DrawCircleAA(60 * mag, 60 * mag, 40 * mag, 32 * mag, 0xFFFFFF, FALSE, 16 * mag);
			}
			isStartOK = true;
		}

		v += 1.6;
		if (v > 100) {
			v = fmod(v, 100);
		}
	}

	void LoadingScene::Draw()
	{
		{
			DrawBlendModeGuard guard;
			SetDrawBlendMode(DX_BLENDMODE_ALPHA, 63);
			DrawCircleGaugeF(1800 * mag, 960 * mag, v, loadingCircle, v - 80);
		}
	}

	void LoadingScene::Finish()
	{
	}

}
