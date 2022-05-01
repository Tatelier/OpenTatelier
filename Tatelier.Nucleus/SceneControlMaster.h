#pragma once

#include <functional>
#include <unordered_map>
class SceneBase;

struct SceneFunctionTable {
	std::function<SceneBase* ()> Create;
};

class SceneControlMaster {
	std::unordered_map<std::string, SceneFunctionTable> sceneCreateMap;
	SceneBase* nowScene;
	SceneBase* loadingScene = nullptr;

public:
	static SceneControlMaster& GetInstance();
	void ChangeScene(const std::string& name);
	void SetLoadingEnabled(bool enabled);
	void Start();
	void Update();
	void Draw();
	void Finish();
};
