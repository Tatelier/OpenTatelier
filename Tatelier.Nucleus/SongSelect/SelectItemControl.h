#pragma once

#include "../hjson/hjson.h"
#include <memory>
#include <string>
#include <vector>

namespace SongSelect {
	class Item;
	class ItemControl;
	class SelectItem;

	/**
		 * @brief 選択項目管理クラス
		 */
	class SelectItemControl {
	public:
		/**
			 * @brief インスタンスを生成する
			 *
			 * @param itemControl 項目管理クラス
			 * @param imageRootFolder 画像ルートフォルダ
			 * @return SelectItemControl* インスタンスポインタ
			 */
		static SelectItemControl* Create(std::shared_ptr<ItemControl> itemControl, const std::string& imageRootFolder);
		/**
			 * @brief 選択中の項目
			 * @return std::shared_ptr<SelectItem> 選択中の項目
			 */
		std::shared_ptr<SelectItem> GetNowSelectItem();
		/**
			 * @brief 前の項目に移動する
			 */
		void Prev();
		/**
			 * @brief 次の項目に移動する
			 */
		void Next();
		/**
			 * @brief 項目を開く。
			 *
			 * @return true
			 * @return false
			 */
		bool Open();
		/**
			 * @brief 項目を閉じる
			 *
			 * @return true 成功
			 * @return false 失敗
			 */
		bool Close();

		void SetThemeData(std::string themeFolder, const Hjson::Value& data);

	private:
		std::shared_ptr<SelectItem> nowSelectItem;
		std::vector<std::shared_ptr<SelectItem>> rootSelectItem;
		SelectItemControl();
		std::string folder;
		std::string imageRootFolder;
		std::shared_ptr<std::vector<std::shared_ptr<Item>>> itemList;
		void Init(std::shared_ptr<ItemControl> itemControl, const std::string& imageRootFolder);
		void Set();
	};
}