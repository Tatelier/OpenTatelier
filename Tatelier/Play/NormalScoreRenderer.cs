using System.Linq;
using Tatelier.DxLibDLL;
using Tatelier.Score.Component;
using Tatelier.Score.Component.NoteSystem;
using static DxLibDLL.DX;

namespace Tatelier.Play
{
    class NormalScoreRenderer : IScoreRenderer
	{
		readonly INormalScoreRendererTarget module;

		public bool IsNoteHide { get; set; }

		void DrawNoteIdForDebug(float noteX, float noteY, INote note)
		{
			if (MainConfig.Singleton.Debug)
			{
				DrawExtendStringF(noteX + 1, noteY + 1 - (80 + (note.Id % 2 == 0 ? 0 : 10)), 0.5, 0.5, $"{note.Id}", 0);
				DrawExtendStringF(noteX, noteY - (80 + (note.Id % 2 == 0 ? 0 : 10)), 0.5, 0.5, $"{note.Id}", 0xFFD400);
			}
		}

		void DrawNormalNote(INote note, int nowMillisec)
		{
			if (note.StartDrawMillisec <= nowMillisec
				&& nowMillisec < note.FinishDrawMillisec)
			{
				int diffMillisec = note.StartMillisec - nowMillisec;
				int handle = module.NoteImageControl.GetImageHandle(note.NoteType);
				float x = module.JudgeFramePoint.CX + (diffMillisec * note.MovementPerMillisec);
				float y = module.JudgeFramePoint.CY;

				if (!IsNoteHide)
				{
					DrawRotaGraphFastF(x, y, 1.0F, 0.0F, handle, DX_TRUE);
				}
				DrawNoteIdForDebug(x, y, note);

				using (DrawAreaGuard.Create())
				{
					module.NoteText.Draw(x, y, note.NoteTextType);
				}
			}
		}

		void DrawBalloonNote(INote note, int nowMillisec)
		{
			if (note.StartDrawMillisec <= nowMillisec
				&& nowMillisec < note.FinishDrawMillisec)
			{
				int diffMillisec = note.StartMillisec - nowMillisec;

				int handle = module.NoteImageControl.GetImageHandle(note.NoteType);

				float x;
				float y = module.JudgeFramePoint.CY;

				if (diffMillisec < 0)
				{
					var finishDiffMillisec = (note.FinishMillisec - nowMillisec);
					x = finishDiffMillisec < 0 ? module.JudgeFramePoint.CX + (finishDiffMillisec * note.MovementPerMillisec) : module.JudgeFramePoint.CX;
				}
				else
				{
					x = module.JudgeFramePoint.CX + (diffMillisec * note.MovementPerMillisec);
				}

				if (!IsNoteHide)
				{
					DrawRotaGraphFastF(x, y, 1.0F, 0.0F, handle, DX_TRUE);
				}
				DrawNoteIdForDebug(x, y, note);

				using (DrawAreaGuard.Create())
				{
					module.NoteText.Draw(x, y, note.NoteTextType);
				}
			}
		}

		void DrawRollNote(INote note, int nowMillisec)
		{
			var prevNote = note.PrevNote;

			// 前回音符によって処理を変える
			switch (prevNote.NoteType)
			{
				case NoteType.Roll:
				case NoteType.RollBig:
					{
						// 連打中身の描画
						if (prevNote.StartDrawMillisec <= nowMillisec
							&& nowMillisec < prevNote.FinishDrawMillisec)
						{
							int diffMillisec = note.StartMillisec - nowMillisec;

							int handle = module.NoteImageControl.GetContentNoteImageHandle(prevNote.NoteType);
							GetGraphSizeF(handle, out float w, out float h);

							float hHalf = h / 2;
							float x = module.JudgeFramePoint.CX + (diffMillisec * note.MovementPerMillisec);
							float y = module.JudgeFramePoint.CY;

							int prevDiffMillisec = (prevNote.StartMillisec - nowMillisec);
							float prevX = module.JudgeFramePoint.CX + (prevDiffMillisec * prevNote.MovementPerMillisec);

							using (DrawModeGuard.Create())
							{
								SetDrawMode(DX_DRAWMODE_NEAREST);

								if (!IsNoteHide)
								{
									DrawModiGraphF(prevX - 1, y - hHalf, x + 1, y - hHalf, x + 1, y + hHalf, prevX - 1, y + hHalf, handle, DX_TRUE);
								}
							}

							// 終端音符の描画
							if (note.StartDrawMillisec <= nowMillisec
								&& nowMillisec < note.FinishDrawMillisec)
							{
								if (!IsNoteHide)
								{
									DrawRotaGraphFastF(x, y, 1.0F, 0.0F, module.NoteImageControl.GetEndNoteImageHandle(prevNote.NoteType), DX_TRUE, note.ScrollSpeedInfo.Value < 0 ? 1 : 0);
								}
								DrawNoteIdForDebug(x, y, note);
							}
						}
					}
					break;
			}
		}


		void IScoreRenderer.DrawMeasureBranchScore(BranchScore bscore, int nowTime)
		{
			// 小節線処理・描画
			foreach (var item in bscore.Measures.Reverse<IMeasureLine>().Where(v => v.Visible))
			{
				float x = module.JudgeFramePoint.CX + ((item.StartMillisec - nowTime) * item.MovementPerMillisec);
				float y = module.JudgeFramePoint.CY;

				DrawRotaGraphFastF(x, y, 1.0F, 0.0F, module.BarLineImageControl.GetHandle(item.MeasureLineType), DX_TRUE);
				DrawMeasureIdForDebug(x, y, item);
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

		void IScoreRenderer.DrawNoteBranchScore(BranchScore bscore, int nowTime)
		{
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
							switch (note.NoteType)
							{
								case NoteType.Don:
								case NoteType.Kat:
								case NoteType.DonBig:
								case NoteType.KatBig:
								case NoteType.Roll:
								case NoteType.RollBig:
									DrawNormalNote(note, nowTime);
									break;
								case NoteType.Balloon:
									DrawBalloonNote(note, nowTime);
									break;
								case NoteType.End:
									DrawRollNote(note, nowTime);
									break;
							}
						}
					}
				}
			}
		}

		public NormalScoreRenderer(INormalScoreRendererTarget module)
		{
			this.module = module;
		}
	}
}
