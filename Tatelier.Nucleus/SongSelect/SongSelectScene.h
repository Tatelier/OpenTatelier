#pragma once
#include "../SceneBase.h"
#include <memory>

namespace SongSelect {

	class Background;
	class Demo;
	class CategoryControl;
	class SelectItemControl;

	/**
		 * @brief 選曲シーン
		 *
		 */
	class SongSelectScene : SceneBase {
		Background* background;
		Demo* demo;
		std::shared_ptr<CategoryControl> categoryControl;
		std::shared_ptr<SelectItemControl> selectItemControl;

	public:
		static SceneBase* Create()
		{
			return new SongSelectScene();
		}
		static int Annihilate(SceneBase* scene)
		{
			delete scene;

			return 0;
		}
		virtual void Start() override;
		virtual void Update() override;
		virtual void Draw() override;
		virtual void Finish() override;
		SongSelectScene();
		virtual ~SongSelectScene() override;
	};
}