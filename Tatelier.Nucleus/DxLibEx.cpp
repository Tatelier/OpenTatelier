#include "DxLibEx.h"

#include "Guard.h"
#include <math.h>

int DrawTileGraph(float x1, float y1, float x2, float y2, float txf, float tyf, int GrHandle)
{

	if (GrHandle == -1) {
		return -1;
	}

	{
		DrawModeGuard drawModeGuard;
		DrawAreaGuard drawAreaGuard;

		SetDrawMode(DX_DRAWMODE_BILINEAR);

		int img_w;
		int img_h;

		// ‰æ‘œ‚ÌƒTƒCƒY‚ð“¾‚é
		GetGraphSize(GrHandle, &img_w, &img_h);
		if (img_w == 0 || img_h == 0)
			return -1;

		txf = fmod(txf, img_w);
		tyf = fmod(tyf, img_h);

		int scr_w;
		int scr_h;

		GetDrawScreenSize(&scr_w, &scr_h);

		SetDrawArea((int)x1, (int)y1, (int)x2, (int)y2);
		for (int y = -1; y < scr_h / img_h + 2; y++) {
			for (int x = -1; x < scr_w / img_w + 2; x++) {
				DrawGraphF(x * img_w + txf, y * img_h + tyf, GrHandle, TRUE);
			}
		}
	}
	return 0;
}
