#include "SelectItem.h"
#include "../hjson/hjson.h"
#include "GenreSelectItem.h"

namespace SongSelect {
	std::shared_ptr<SelectItem> SelectItem::GetPrev()
	{
		return prev;
	}
	void SelectItem::SetPrev(std::shared_ptr<SelectItem> prev)
	{
		this->prev = prev;
	}
	std::shared_ptr<SelectItem> SelectItem::GetNext()
	{
		return next;
	}
	void SelectItem::SetNext(std::shared_ptr<SelectItem> next)
	{
		this->next = next;
	}
	std::shared_ptr<GenreSelectItem> SelectItem::GetParentGenre()
	{
		return parentGenre;
	}
	void SelectItem::SetParentGenre(std::shared_ptr<GenreSelectItem> parent)
	{
		parentGenre = parent;
	}

	int SelectItem::SetThemeData(std::string imageFolder, const Hjson::Value& data)
	{
		return 0;
	}

	SelectItem::~SelectItem()
	{
	}
	SelectItem::SelectItem()
	{
	}
}