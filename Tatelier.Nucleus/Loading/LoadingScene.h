#pragma once

#include "../SceneBase.h"

namespace Loading {
	class LoadingScene : public SceneBase {
	public:
		static SceneBase* Create();
		static int Annihilate(SceneBase* scene);
		virtual void Start() override;
		virtual void Update() override;
		virtual void Draw() override;
		virtual void Finish() override;
	};

}
