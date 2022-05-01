#pragma once

#include <stdint.h>

class SceneControlMaster;

class Supervision {
	Supervision(const Supervision& a) { }
	Supervision() { }
	SceneControlMaster* sceneControl;
	int64_t nowMicroSecTime;
	int32_t nowMillisecTime;

public:
	static Supervision& GetInstance();

	/**
	 * @brief コマンド検索&実行
	 */
	int32_t CommandSearchAndRun(const char* command, ...);

	/**
	 * @brief 初期化処理
	 */
	void Start();

	/**
	 * @brief 更新処理
	 * @detail 毎フレーム呼び出すこと
	 */
	void Update();

	/**
	 * @brief 描画処理
	 * @detail 毎フレーム呼び出すこと
	 */
	void Draw();
	/**
	 * @brief 現在のマイクロ秒
	 */
	int64_t GetNowMicroTime();
	/**
	 * @brief 現在のミリ秒
	 */
	int32_t GetNowMillisecTime();
};