#pragma once

#include "SelectItem.h"

namespace SongSelect {
	class ScoreOverview;
	class ScoreSelectItem : public SelectItem {
	public:
		ScoreSelectItem(std::shared_ptr<ScoreOverview> item);

		virtual ~ScoreSelectItem() override;

	private:
		std::shared_ptr<ScoreOverview> item;

		// SelectItem ‚ğ‰î‚µ‚ÄŒp³‚³‚ê‚Ü‚µ‚½
		virtual SongSelectItemType GetType() override;
		virtual const std::string& GetMainTitle() override;

		// SelectItem ‚ğ‰î‚µ‚ÄŒp³‚³‚ê‚Ü‚µ‚½
		virtual std::shared_ptr<BackgroundInfo> GetBackgroundInfo() override;
	};

}
