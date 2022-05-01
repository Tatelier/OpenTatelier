using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tatelier.Empty.Play;
using Tatelier.Interface.Play;
using static DxLibDLL.DX;
using HjsonEx;
using Tatelier.Score.Component.NoteSystem;

namespace Tatelier.Play
{

    class NoteFlyEffectInfo
	{
		public int DonImageHandle = -1;

		public int KatImageHandle = -1;

		public int DonBigImageHandle = -1;

		public int KatBigImageHandle = -1;

		public int StartY = 384;

		public int MidY = 0;

		public int EndY = 0;
	}

	class NoteFlyEffectItem
	{
		/// <summary>
		/// 表示有無
		/// </summary>
		public bool Visible = false;

		/// <summary>
		/// 開始時間(ms)
		/// </summary>
		public int StartTime;

		/// <summary>
		/// 画像ハンドル
		/// </summary>
		public int Handle = -1;

		/// <summary>
		/// エフェクトデータをセットする
		/// </summary>
		/// <param name="startTime">開始時間(ms)</param>
		/// <param name="handle">画像ハンドル</param>
		public void Set(int startTime, int handle)
		{
			this.StartTime = startTime;
			this.Handle = handle;
			Visible = true;
		}
	}

	/// <summary>
	/// 音符飛翔演出クラス
	/// </summary>
	class NoteFlyEffect : INoteFlyEffect
	{
		public static INoteFlyEffect Create(NoteFlyEffectInfo info, XElement elem) => elem != null ? new NoteFlyEffect(info, elem) : (INoteFlyEffect)new NoteFlyEffectEmpty();

		int don;
		int kat;
		int donBig;
		int katBig;

		int nowIndex = 0;

		/// <summary>
		/// 音符エフェクトリスト
		/// </summary>
		NoteFlyEffectItem[] noteFlyEffectItems = new NoteFlyEffectItem[64];

		/// <summary>
		/// 開始位置X
		/// </summary>
		float startX = 618;

		/// <summary>
		/// 開始位置Y
		/// </summary>
		float startY = 384;

		/// <summary>
		/// 終了位置X
		/// </summary>
		float endX = 1834;

		/// <summary>
		/// 終了位置Y
		/// </summary>
		float endY = 244;

		/// <summary>
		/// 中間点 X
		/// </summary>
		float midX;

		/// <summary>
		/// 中間点 Y
		/// </summary>
		float midY;

		/// <summary>
		/// 半径
		/// </summary>
		double radius;
		/// <summary>
		/// 始点角度
		/// </summary>
		float startRot;

		/// <summary>
		/// 終点角度
		/// </summary>
		float endRot;

		/// <summary>
		/// 音符を飛ばす
		/// </summary>
		/// <param name="noteType">音符種別</param>
		/// <param name="startTime">開始時間(ms)</param>
		public void Fly(NoteType noteType, int startTime)
		{
			int s = startTime;
			switch (noteType)
			{
				case NoteType.Don:
					noteFlyEffectItems[nowIndex].Set(startTime, don);
					break;
				case NoteType.Kat:
					noteFlyEffectItems[nowIndex].Set(startTime, kat);
					break;
				case NoteType.DonBig:
					noteFlyEffectItems[nowIndex].Set(startTime, donBig);
					break;
				case NoteType.KatBig:
					noteFlyEffectItems[nowIndex].Set(startTime, katBig);
					break;
			}
			nowIndex = (nowIndex + 1) % noteFlyEffectItems.Length;
		}

		/// <summary>
		/// データリセット
		/// </summary>
		public void Reset()
		{
			for (int i = 0; i < noteFlyEffectItems.Length; i++)
			{
				noteFlyEffectItems[i].StartTime = 0;
				noteFlyEffectItems[i].Handle = -1;
			}
		}

		/// <summary>
		/// 描画
		/// </summary>
		/// <param name="index">要素番号</param>
		/// <param name="nowTime">時間(ms)</param>
		void DrawItem(int index, int nowTime)
		{
			var item = noteFlyEffectItems[index];

			// 表示状態のときは位置を計算する
			if (item.Visible)
			{
				float diff = (nowTime - item.StartTime) / 600.0F;

				if (diff > 1)
				{
					if ((nowTime - item.StartTime) / 900.0F < 1)
					{
						diff = 1.0F;
					}
					else
					{
						item.Visible = false;
					}
				}

				// 改めて表示状態を確認して描画する
				if (item.Visible)
				{
					var rad = (startRot + (endRot - startRot) * diff) * Math.PI / 180;
					float bx = (float)(midX + Math.Cos(rad) * radius);
					float by = (float)(midY + Math.Sin(rad) * radius);
					DrawRotaGraphF(bx, by, 1.0, 0.0, item.Handle, DX_TRUE);
				}
			}
		}

		/// <summary>
		/// 描画
		/// </summary>
		/// <param name="nowTime">現在時刻(ms)</param>
		public void Draw(int nowTime)
		{
			DrawItem(nowIndex, nowTime);

			int temp = (nowIndex + 1) % noteFlyEffectItems.Length;

			while (temp != nowIndex)
			{
				DrawItem(temp, nowTime);
				temp = (temp + 1) % noteFlyEffectItems.Length;
			}
		}


		public NoteFlyEffect(XElement elem)
		{
		}

		public NoteFlyEffect(string folder, XElement elem)
		{
			startX = (float?)elem.Attribute("StartPointX") ?? startX;
			startY = (float?)elem.Attribute("StartPointY") ?? startY;

			midX = (float?)elem.Attribute("MiddlePointX") ?? midX;
			midY = (float?)elem.Attribute("MiddlePointY") ?? midY;

			endX = (float?)elem.Attribute("EndPointX") ?? endX;
			endY = (float?)elem.Attribute("EndPointY") ?? endY;

			double x1 = startX;
			double y1 = startY;

			double x2 = midX;
			double y2 = midY;

			double x3 = endX;
			double y3 = endY;

			// 何でgなのかわからないがスコープ内でしか使わないため、ひとまずこのまま
			double g = (y2 * x1 - y1 * x2 + y3 * x2 - y2 * x3 + y1 * x3 - y3 * x1);

			// 円運動の中心x,y
			midX = (float)(((x1 * x1 + y1 * y1) * (y2 - y3) + (x2 * x2 + y2 * y2) * (y3 - y1) + (x3 * x3 + y3 * y3) * (y1 - y2)) / (2 * g));
			midY = -(float)(((x1 * x1 + y1 * y1) * (x2 - x3) + (x2 * x2 + y2 * y2) * (x3 - x1) + (x3 * x3 + y3 * y3) * (x1 - x2)) / (2 * g));

			// 半径radius
			radius = Math.Sqrt((x1 - midX) * (x1 - midX) + (y1 - midY) * (y1 - midY));

			// 始点角度
			startRot = (float)(Math.Atan2(midY - y1, midX - x1) * 180 / Math.PI) + 180;

			// 終点角度
			endRot = (float)(Math.Atan2(midY - y3, midX - x3) * 180 / Math.PI) + 180;
		}

		public NoteFlyEffect(NoteFlyEffectInfo info, Hjson.JsonValue json)
		{
			don = info.DonImageHandle;
			kat = info.KatImageHandle;
			donBig = info.DonBigImageHandle;
			katBig = info.KatBigImageHandle;

			for (int i = 0; i < noteFlyEffectItems.Length; i++)
			{
				noteFlyEffectItems[i] = new NoteFlyEffectItem
				{
					Handle = -1
				};
			}

			startX = json.EQf("Start.PointX") ?? startX;
			startY = json.EQf("Start.PointY") ?? startY;

			midX = json.EQf("Middle.PointX") ?? midX;
			midY = json.EQf("Middle.PointY") ?? midY;

			endX = json.EQf("End.PointX") ?? endX;
			endY = json.EQf("End.PointY") ?? endY;

			double x1 = startX;
			double y1 = startY;

			double x2 = midX;
			double y2 = midY;

			double x3 = endX;
			double y3 = endY;

			// 何でgなのかわからないがスコープ内でしか使わないため、ひとまずこのまま
			double g = (y2 * x1 - y1 * x2 + y3 * x2 - y2 * x3 + y1 * x3 - y3 * x1);

			// 円運動の中心x,y
			midX = (float)(((x1 * x1 + y1 * y1) * (y2 - y3) + (x2 * x2 + y2 * y2) * (y3 - y1) + (x3 * x3 + y3 * y3) * (y1 - y2)) / (2 * g));
			midY = -(float)(((x1 * x1 + y1 * y1) * (x2 - x3) + (x2 * x2 + y2 * y2) * (x3 - x1) + (x3 * x3 + y3 * y3) * (x1 - x2)) / (2 * g));

			// 半径radius
			radius = Math.Sqrt((x1 - midX) * (x1 - midX) + (y1 - midY) * (y1 - midY));

			// 始点角度
			startRot = (float)(Math.Atan2(midY - y1, midX - x1) * 180 / Math.PI) + 180;

			// 終点角度
			endRot = (float)(Math.Atan2(midY - y3, midX - x3) * 180 / Math.PI) + 180;
		}
		NoteFlyEffect(NoteFlyEffectInfo info, XElement elem)
		{
			don = info.DonImageHandle;
			kat = info.KatImageHandle;
			donBig = info.DonBigImageHandle;
			katBig = info.KatBigImageHandle;

			for (int i = 0; i < noteFlyEffectItems.Length; i++)
			{
				noteFlyEffectItems[i] = new NoteFlyEffectItem
				{
					Handle = -1
				};
			}

			startX = (float?)elem.Attribute("StartPointX") ?? startX;
			startY = (float?)elem.Attribute("StartPointY") ?? startY;

			midX = (float?)elem.Attribute("MiddlePointX") ?? midX;
			midY = (float?)elem.Attribute("MiddlePointY") ?? midY;

			endX = (float?)elem.Attribute("EndPointX") ?? endX;
			endY = (float?)elem.Attribute("EndPointY") ?? endY;

			double x1 = startX;
			double y1 = startY;

			double x2 = midX;
			double y2 = midY;

			double x3 = endX;
			double y3 = endY;

			// 何でgなのかわからないがスコープ内でしか使わないため、ひとまずこのまま
			double g = (y2 * x1 - y1 * x2 + y3 * x2 - y2 * x3 + y1 * x3 - y3 * x1);

			// 円運動の中心x,y
			midX = (float)(((x1 * x1 + y1 * y1) * (y2 - y3) + (x2 * x2 + y2 * y2) * (y3 - y1) + (x3 * x3 + y3 * y3) * (y1 - y2)) / (2 * g));
			midY = -(float)(((x1 * x1 + y1 * y1) * (x2 - x3) + (x2 * x2 + y2 * y2) * (x3 - x1) + (x3 * x3 + y3 * y3) * (x1 - x2)) / (2 * g));

			// 半径radius
			radius = Math.Sqrt((x1 - midX) * (x1 - midX) + (y1 - midY) * (y1 - midY));

			// 始点角度
			startRot = (float)(Math.Atan2(midY - y1, midX - x1) * 180 / Math.PI) + 180;

			// 終点角度
			endRot = (float)(Math.Atan2(midY - y3, midX - x3) * 180 / Math.PI) + 180;
		}
	}
}
