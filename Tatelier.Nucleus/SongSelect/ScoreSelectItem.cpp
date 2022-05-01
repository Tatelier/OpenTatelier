#include "ScoreSelectItem.h"
#include "ScoreOverview.h"

#include "GenreSelectItem.h"

#include <memory>

namespace SongSelect {
	ScoreSelectItem::ScoreSelectItem(std::shared_ptr<ScoreOverview> item)
	{
		this->item = item;
	}
	ScoreSelectItem::~ScoreSelectItem()
	{
	}

	SongSelectItemType ScoreSelectItem::GetType()
	{
		return SongSelectItemType::Score;
	}

	const std::string& ScoreSelectItem::GetMainTitle()
	{
		return item->GetTitle();
	}

	std::shared_ptr<BackgroundInfo> ScoreSelectItem::GetBackgroundInfo()
	{
		return GetParentGenre()->GetBackgroundInfo();
	}
}