using HjsonEx;
using System;
using System.Collections.Generic;
using Tatelier.DxLibDLL;
using static DxLibDLL.DX;

namespace Tatelier.SongSelect
{
	class ItemImageInfo
	{
		public List<SplitImageInfo> infoList = new List<SplitImageInfo>();
		public int TitleImageHandle;

		public Common.Transform Transform = new Common.Transform();

		public float TitleX;
		public float TitleY;
		public int ContentAlpha = 255;
		public void Draw()
		{
			foreach (var info in infoList)
			{
				info.Draw(Transform.X, Transform.Y);
			}

			using (DrawModeGuard.Create())
			using (DrawBlendModeGuard.Create())
			{
				SetDrawMode(DX_DRAWMODE_BILINEAR);
				SetDrawBlendMode(DX_BLENDMODE_ALPHA, ContentAlpha);
				DrawRotaGraphF(TitleX + Transform.X, TitleY + Transform.Y, 1.0, 0.0, TitleImageHandle, DX_TRUE);
			}
		}

		public ItemImageInfo(Hjson.JsonArray array)
		{
			foreach (var item in array)
			{
				infoList.Add(new SplitImageInfo(item.EQv("SplitOption")));
			}
		}
	}
}
