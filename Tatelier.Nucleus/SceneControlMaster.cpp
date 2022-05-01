#include "SceneControlMaster.h"

#include "Loading\LoadingScene.h"
#include "SongSelect\SongSelectScene.h"

SceneControlMaster& SceneControlMaster::GetInstance()
{
	static SceneControlMaster instance;
	return instance;
}

void SceneControlMaster::ChangeScene(const std::string& name)
{
}

void SceneControlMaster::SetLoadingEnabled(bool enabled)
{
	if (enabled) {
		loadingScene = Loading::LoadingScene::Create();
	}
	else {
		Loading::LoadingScene::Annihilate(loadingScene);
		loadingScene = nullptr;
	}
}

void SceneControlMaster::Start()
{
	nowScene = SongSelect::SongSelectScene::Create();
	nowScene->Start();
}

void SceneControlMaster::Update()
{
	nowScene->Update();
	if (loadingScene)
		loadingScene->Update();
}

void SceneControlMaster::Draw()
{
	nowScene->Draw();
	if (loadingScene)
		loadingScene->Draw();
}

void SceneControlMaster::Finish()
{
}
