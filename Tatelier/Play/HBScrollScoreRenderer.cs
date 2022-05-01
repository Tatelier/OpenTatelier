using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.DxLibDLL;
using Tatelier.Score.Component;
using Tatelier.Score.Component.NoteSystem;
using Tatelier.Score.Play.Chart;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
    class HBScrollScoreRenderer
        : IScoreRenderer
    {
		IHBScrollScoreRendererTarget target;

		public bool IsNoteHide { get; set; }

		void DrawNoteIdForDebug(float noteX, float noteY, INote note)
		{
			if (MainConfig.Singleton.Debug)
			{
				DrawExtendStringF(noteX + 1, noteY + 1 - (80 + (note.Id % 2 == 0 ? 0 : 10)), 0.5, 0.5, $"{note.Id}", 0);
				DrawExtendStringF(noteX, noteY - (80 + (note.Id % 2 == 0 ? 0 : 10)), 0.5, 0.5, $"{note.Id}", 0xFFD400);
			}
		}

		HBScrollDrawDataItem[] b = new HBScrollDrawDataItem[2];

		void a(IReadOnlyList<HBScrollDrawDataItem> itemList, int nowTime, HBScrollDrawDataItem[] result)
		{
			for(int i = 0; i < b.Length; i++)
            {
				b[i] = null;
            }

			int index = 0;
			for (int i = itemList.Count - 1; i >= 0; i--)
			{
				var v = itemList[i];
				if (index == 0)
				{
					if (v.StartMillisec <= nowTime
						&& nowTime < v.FinishMillisec)
					{
						result[index] = v;
						index++;
						if (index >= result.Length)
						{
							return;
						}
					}
				}
                else
				{
					if (index >= result.Length)
					{
						return;
					}
				}
			}
		}
		void IScoreRenderer.DrawNoteBranchScore(BranchScore bscore, int nowTime)
		{
			var firstDrawDataItem = bscore.HBScrollDrawDataControl.ItemList.LastOrDefault(
				v => v.IsApplicable(nowTime));

			if(firstDrawDataItem == null
				&& nowTime < 0)
            {
				firstDrawDataItem = bscore.HBScrollDrawDataControl.ItemList.LastOrDefault(
				v => v.IsApplicable(0));
            }

			System.Diagnostics.Trace.WriteLine($"{(firstDrawDataItem != null ? $"Start:{firstDrawDataItem.StartMillisec}, Finish:{firstDrawDataItem.FinishMillisec}" : "null")}");

            double per = 0;

			// レイヤー層
			foreach (var layer in bscore.NoteList)
			{
				// セクション層(後ろから)
				foreach (var section in layer.Reverse())
				{
					// 音符層
					foreach (var note in section.Reverse())
					{
						if (note.Visible)
						{
							var reFirstDrawDataItem = firstDrawDataItem;

							// 音符がfirstDrawDataItemの時間範囲内の場合は、その音符の時間範囲内のデータで再構築する
							if ((reFirstDrawDataItem == null)
								|| (!reFirstDrawDataItem.IsDelay && reFirstDrawDataItem.IsApplicable(note)))
							{
								reFirstDrawDataItem = note.HBScrollDrawDataItem;
								//reFirstDrawDataItem = bscore.HBScrollDrawDataControl.ItemList.LastOrDefault(
								//	v => v.StartMillisec <= note.StartMillisec
								//	&& note.FinishMillisec < v.EndMillisec);

								if (reFirstDrawDataItem == null)
								{
									continue;
								}
							}

							per = reFirstDrawDataItem.GetElapsedRate(nowTime);
							int diffTime = note.StartMillisec - nowTime;
							float y = target.JudgeFramePoint.CY;

							switch (note.NoteType)
							{
								case NoteType.Don:
								case NoteType.Kat:
								case NoteType.DonBig:
								case NoteType.KatBig:
								case NoteType.Roll:
								case NoteType.RollBig:
									{
										int handle = target.NoteImageControl.GetImageHandle(note.NoteType);

										float x;

										if (diffTime < 0
											&& !reFirstDrawDataItem.IsDelay)
										{
											x = target.JudgeFramePoint.CX + (diffTime * note.MovementPerMillisec);
										}
										else
										{
											double hbscrollPivotX = reFirstDrawDataItem.GetHBScrollPivotX(per);
											x = (float)(target.JudgeFramePoint.CX + (note.HBScrollStartPointX - hbscrollPivotX) * note.ScrollSpeedInfo.Value * target.PlayOptionScrollSpeed);
										}

										if (target.FinishDrawPointX < x && x < target.StartDrawPointX)
										{
											if (!IsNoteHide)
											{
												DrawRotaGraphFastF(x, y, 1.0F, 0.0F, handle, DX_TRUE);
											}
											DrawNoteIdForDebug(x, y, note);
											using (DrawAreaGuard.Create())
											{
												target.NoteText.Draw(x, y, note.NoteTextType);
											}
										}
									}
									break;
								case NoteType.Balloon:
									{
										int handle = target.NoteImageControl.GetImageHandle(note.NoteType);
										float x;
										if (diffTime < 0
											&& !reFirstDrawDataItem.IsDelay)
										{
											var finishDiffMillisec = (note.FinishMillisec - nowTime);
											x = finishDiffMillisec < 0 ? target.JudgeFramePoint.CX + (finishDiffMillisec * note.MovementPerMillisec) : target.JudgeFramePoint.CX;
										}
										else
										{
											double hbscrollPivotX = reFirstDrawDataItem.GetHBScrollPivotX(per);
											x = (float)(target.JudgeFramePoint.CX + (note.HBScrollStartPointX - hbscrollPivotX) * note.ScrollSpeedInfo.Value * target.PlayOptionScrollSpeed);
										}

										if (target.FinishDrawPointX < x && x < target.StartDrawPointX)
										{
											if (!IsNoteHide)
											{
												DrawRotaGraphFastF(x, y, 1.0F, 0.0F, handle, DX_TRUE);
											}
											DrawNoteIdForDebug(x, y, note);

											using (DrawAreaGuard.Create())
											{
												target.NoteText.Draw(x, y, note.NoteTextType);
											}
										}
									}
									break;
								case NoteType.End:
									{
										// 前回音符によって処理を変える
										switch (note.PrevNote.NoteType)
										{
											case NoteType.Roll:
											case NoteType.RollBig:
												{
													int handle = target.NoteImageControl.GetContentNoteImageHandle(note.PrevNote.NoteType);
													GetGraphSizeF(handle, out float w, out float h);

													float hHalf = h / 2;
													float x;
													float prevT;
													float prevX;

													if (diffTime < 0
														&& !reFirstDrawDataItem.IsDelay)
													{
														x = target.JudgeFramePoint.CX + (diffTime * note.MovementPerMillisec);

														prevT = (note.PrevNote.StartMillisec - nowTime);
														prevX = target.JudgeFramePoint.CX + (prevT * note.PrevNote.MovementPerMillisec);
													}
													else
													{
														double hbscrollPivotX = reFirstDrawDataItem.GetHBScrollPivotX(per);
														x = (float)(target.JudgeFramePoint.CX + (note.HBScrollStartPointX - hbscrollPivotX) * note.ScrollSpeedInfo.Value * target.PlayOptionScrollSpeed);

														prevT = (note.PrevNote.StartMillisec - nowTime);
														if (prevT < 0)
														{
															prevX = target.JudgeFramePoint.CX + (prevT * note.PrevNote.MovementPerMillisec);
														}
														else
														{
															prevX = (float)(target.JudgeFramePoint.CX + (note.PrevNote.HBScrollStartPointX - hbscrollPivotX) * note.PrevNote.ScrollSpeedInfo.Value * target.PlayOptionScrollSpeed);
														}
													}
													if (!IsNoteHide)
													{
														DrawModiGraphF(prevX - 1, y - hHalf, x + 1, y - hHalf, x + 1, y + hHalf, prevX - 1, y + hHalf, handle, DX_TRUE);
														DrawRotaGraphFastF(x, y, 1.0F, 0.0F, target.NoteImageControl.GetEndNoteImageHandle(note.PrevNote.NoteType), DX_TRUE, note.ScrollSpeedInfo.Value < 0 ? 1 : 0);
													}
													DrawNoteIdForDebug(x, y, note);
												}
												break;
										}
									}
									break;
							}
						}
					}
				}
			}
		}

		void DrawMeasureIdForDebug(float noteX, float noteY, IMeasureLine measure)
		{
			if (MainConfig.Singleton.Debug)
			{
				DrawExtendStringF(noteX + 1, noteY + 1 + (60 + (measure.Id % 2 == 0 ? 0 : 10)), 0.5, 0.5, $"{measure.Id}", 0);
				DrawExtendStringF(noteX, noteY + (60 + (measure.Id % 2 == 0 ? 0 : 10)), 0.5, 0.5, $"{measure.Id}", 0x90c60f);
			}
		}

		void IScoreRenderer.DrawMeasureBranchScore(BranchScore bscore, int nowTime)
		{
			double per = 0;
			float x;
			float y = target.JudgeFramePoint.CY;

			var firstDrawDataItem = bscore.HBScrollDrawDataControl.ItemList.LastOrDefault(v => v.IsApplicable(nowTime));

			if (firstDrawDataItem == null
				&& nowTime < 0)
			{
				firstDrawDataItem = bscore.HBScrollDrawDataControl.ItemList.LastOrDefault(v => v.IsApplicable(0));
			}

			int diffTime;

			// レイヤー層
			foreach (var item in bscore.Measures)
			{
				if (item.Visible)
				{
					diffTime = item.StartMillisec - nowTime;

					var reFirstDrawDataItem = firstDrawDataItem;

					// 音符がfirstDrawDataItemの時間範囲内の場合は、その音符の時間範囲内のデータで再構築する
					if ((reFirstDrawDataItem == null)
						|| (!reFirstDrawDataItem.IsDelay && reFirstDrawDataItem.IsApplicable(item)))
					{
						reFirstDrawDataItem = item.HBScrollDrawDataItem;

						if (reFirstDrawDataItem == null)
						{
							continue;
						}
					}

					per = reFirstDrawDataItem.GetElapsedRate(nowTime);

					if (diffTime < 0
						&& !reFirstDrawDataItem.IsDelay)
					{
						x = target.JudgeFramePoint.CX + (diffTime * item.MovementPerMillisec);
					}
					else
					{
						double hbscrollPivotX = reFirstDrawDataItem.GetHBScrollPivotX(per);
						x = (float)(target.JudgeFramePoint.CX + (item.HBScrollStartPointX - hbscrollPivotX) * item.ScrollSpeedInfo.Value * target.PlayOptionScrollSpeed);
					}

					if (target.FinishDrawPointX < x && x < target.StartDrawPointX)
					{
						DrawRotaGraphFastF(x, y, 1.0F, 0.0F, target.BarLineImageControl.GetHandle(item.MeasureLineType), DX_TRUE);
						DrawMeasureIdForDebug(x, y, item);
					}
				}
			}
		}

        public HBScrollScoreRenderer(IHBScrollScoreRendererTarget target)
		{
			this.target = target;
		}
	}
}
