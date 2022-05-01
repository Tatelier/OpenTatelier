using HjsonEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	enum AnimateType
	{
		Point,
		Size,
		CourseAlpha,
		Action,
		Content,
		Wait
	}
	interface IAnimateItem
	{
		AnimateType Type { get; }
	}

	/// <summary>
	/// 透明度アニメーション
	/// </summary>
	class AnimateAlpha : IAnimateItem
	{
		public AnimateType Type { get; }
		public int StartAlpha;
		public int EndAlpha;
		public int During = 0;

		public AnimateAlpha(SelectItemRendererItem item, AnimateType type) : this(type)
		{
			StartAlpha = item.StartCourseAlpha;
			EndAlpha = item.StartCourseAlpha;
		}
		public AnimateAlpha(AnimateType type) { Type = type; }
	}

	/// <summary>
	/// 指定されたアクションを実行する
	/// </summary>
	class AnimateAction : IAnimateItem
	{
		public AnimateType Type => AnimateType.Action;
		public Action Action;
	}

	/// <summary>
	/// サイズ変更アニメーション
	/// </summary>
	class AnimateSizeItem : IAnimateItem
	{
		public AnimateType Type => AnimateType.Size;

		public Common.EasingType EasingType = Common.EasingType.None;

		public float StartWidth;
		public float StartHeight;

		public float EndWidth;
		public float EndHeight;

		public int StartWaitTime = 0;
		public float During = 0.001F;

		public AnimateSizeItem() { }

		public AnimateSizeItem(SelectItemRendererItem item)
		{
			StartWidth = item.StartWidth;
			StartHeight = item.StartHeight;
			EndWidth = item.StartWidth;
			EndHeight = item.StartHeight;
		}
	}

	/// <summary>
	/// 座標変更アニメーション
	/// </summary>
	class AnimatePointItem : IAnimateItem
	{
		public AnimateType Type => AnimateType.Point;

		public Common.EasingType EasingType = Common.EasingType.None;

		public float StartX = 0;
		public float StartY = 0;

		public float EndX = 0;
		public float EndY = 0;

		public int During = 0;

		public AnimatePointItem()
		{

		}

		public AnimatePointItem(SelectItemRendererItem item)
		{
			StartX = item.StartCXf;
			StartY = item.StartCYf;
			EndX = item.StartCXf;
			EndY = item.StartCYf;
		}
	}

	/// <summary>
	/// 待機アニメーション
	/// </summary>
	class AnimateWait : IAnimateItem
	{
		public AnimateType Type => AnimateType.Wait;
		public int During = 0;
	}

	[DebuggerDisplay("cxf = {CXf}, cyf = {CYf}")]
	class SelectItemRendererItem
	{
		public float StartCXf { get; private set; }
		public float StartCYf { get; private set; }

		public float StartWidth { get; private set; } = 100;
		public float StartHeight { get; private set; } = 100;

		public float CurrentlySelectedHeight = 316;

		public float CXf { get; set; }
		public float CYf { get; set; }

		public float PerForSize = 0;
		public float PerForPoint = 0;

		public float Width = 100;
		public float Height = 100;

		public int StartCourseAlpha { get; }
		public int CourseAlpha = 255;

		public int StartContentAlpha { get; }
		public int ContentAlpha = 255;

		IEnumerable<IEnumerator> iteratorList;

		IEnumerator GetIterator(IEnumerable<IAnimateItem> itemList)
		{
			foreach (var item in itemList)
			{
				switch (item.Type)
				{
					case AnimateType.Point:
						#region 座標アニメーション
						{
							var anim = item as AnimatePointItem;

							CXf = anim.StartX;
							CYf = anim.StartY;

							float tempX = anim.EndX - anim.StartX;
							float tempY = anim.EndY - anim.StartY;

							int during = anim.During;
							int start = Supervision.NowMilliSec;

							float per = 0.0F;
							while (per < 1)
							{
								per = (Supervision.NowMilliSec - start) / (float)during;
								if (per > 1)
								{
									break;
								}

								per = Common.Easing.GetEasingValue(per, anim.EasingType);

								CXf = anim.StartX + tempX * per;
								CYf = anim.StartY + tempY * per;
								yield return null;
							}
							CXf = anim.EndX;
							CYf = anim.EndY;
						}
						#endregion
						break;
					case AnimateType.Size:
						#region サイズ変更アニメーション
						{
							var anim = item as AnimateSizeItem;

							Width = anim.StartWidth;
							Height = anim.StartHeight;

							float tempX = anim.EndWidth - anim.StartWidth;
							float tempY = anim.EndHeight - anim.StartHeight;

							float during = anim.During;

							int start = Supervision.NowMilliSec;

							float per = 0.0F;
							while (per < 1)
							{
								per = (Supervision.NowMilliSec - start) / during;
								if (per > 1)
								{
									break;
								}

								per = Common.Easing.GetEasingValue(per, anim.EasingType);

								Width = anim.StartWidth + tempX * per;
								Height = anim.StartHeight + tempY * per;
								yield return null;
							}
							Width = anim.EndWidth;
							Height = anim.EndHeight;
						}
						#endregion
						break;
					case AnimateType.Action:
						#region 処理実行
						{
							var anim = item as AnimateAction;
							anim.Action();
						}
						#endregion
						break;
					case AnimateType.Wait:
						#region ウェイト
						{
							var anim = item as AnimateWait;
							int end = Supervision.NowMilliSec + anim.During;

							while (end > Supervision.NowMilliSec) yield return null;
						}
						#endregion
						break;
					case AnimateType.CourseAlpha:
						#region コース透明度
						{
							var anim = item as AnimateAlpha;

							CourseAlpha = anim.StartAlpha;

							float tempX = anim.EndAlpha - anim.StartAlpha;

							int during = anim.During;

							int start = Supervision.NowMilliSec;

							float per = 0.0F;
							while (per < 1)
							{
								per = (Supervision.NowMilliSec - start) / (float)during;
								if (per > 1)
								{
									break;
								}

								CourseAlpha = anim.StartAlpha + (int)(tempX * per);

								yield return null;
							}
							CourseAlpha = anim.EndAlpha;
						}
						#endregion
						break;
					case AnimateType.Content:
						#region 内容の透明度
						{
							var anim = item as AnimateAlpha;

							ContentAlpha = anim.StartAlpha;

							float tempX = anim.EndAlpha - anim.StartAlpha;

							int during = anim.During;

							int start = Supervision.NowMilliSec;

							float per = 0.0F;
							while (per < 1)
							{
								per = (Supervision.NowMilliSec - start) / (float)during;
								if (per > 1)
								{
									break;
								}

								ContentAlpha = anim.StartAlpha + (int)(tempX * per);

								yield return null;
							}
							ContentAlpha = anim.EndAlpha;
						}
						#endregion
						break;
				}
			}
		}

		public void SetAnimate(params IEnumerable<IAnimateItem>[] itemList)
		{
			iteratorList = itemList.Select(v => GetIterator(v)).ToArray();
		}

		public void SetAnimate(IEnumerable<IEnumerable<IAnimateItem>> itemList)
		{
			iteratorList = itemList.Select(v => GetIterator(v)).ToArray();
		}

		public void Update()
		{
			foreach (var item in iteratorList)
			{
				item.MoveNext();
			}
		}

		public SelectItemRendererItem(Hjson.JsonValue json, Dictionary<string, float> dic) : this()
		{
			StartCXf = Common.Utility.CalcFromString(json.EQs("Point.CX"), dic);
			StartCYf = Common.Utility.CalcFromString(json.EQs("Point.CY"), dic);
			CXf = StartCXf;
			CYf = StartCYf;

			StartWidth = json.EQf("Width") ?? Width;
			StartHeight = json.EQf("Height") ?? Height;
			Width = StartWidth;
			Height = StartHeight;

			CourseAlpha = 255;
			StartCourseAlpha = CourseAlpha;
		}

		public SelectItemRendererItem()
		{
			iteratorList = Array.Empty<IEnumerator>();
		}
	}
}
