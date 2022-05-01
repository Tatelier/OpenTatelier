using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Score;
using Tatelier.Score.Component;

namespace Tatelier.Play
{
    class Player
		: INormalScoreRendererTarget, IHBScrollScoreRendererTarget
	{
		public bool CanBeSaved = true;
		PlayStyle playStyle;
		public PlayStyle PlayStyle
		{
			get => playStyle;
			set
			{
				playStyle = value;

				if (playStyle != PlayStyle.Yourself)
				{
					CanBeSaved = false;
				}
			}
		}
		public PlayerInfo PlayerInfo;
		public string ScoreId = "a";
		public int CourseId => Utility.GetCourseID(Score.CourseName);

        IJudgeFramePoint INormalScoreRendererTarget.JudgeFramePoint => NoteFieldControl;
        NoteImageControl INormalScoreRendererTarget.NoteImageControl => NoteImageControl;
		MeasureLineImageControl INormalScoreRendererTarget.BarLineImageControl => BarLineImageControl;
		INoteText INormalScoreRendererTarget.NoteText => NoteText;

        IJudgeFramePoint IHBScrollScoreRendererTarget.JudgeFramePoint => NoteFieldControl;
		NoteImageControl IHBScrollScoreRendererTarget.NoteImageControl => NoteImageControl;
		MeasureLineImageControl IHBScrollScoreRendererTarget.BarLineImageControl => BarLineImageControl;
		INoteText IHBScrollScoreRendererTarget.NoteText => NoteText;

        float IHBScrollScoreRendererTarget.StartDrawPointX => StartDrawPointX;
        float IHBScrollScoreRendererTarget.FinishDrawPointX => FinishDrawPointX;
        double IHBScrollScoreRendererTarget.PlayOptionScrollSpeed => PlayOptionScrollSpeed;

        public float StartDrawPointX = -500;
		public float FinishDrawPointX = 1920;

		public double PlayOptionScrollSpeed = 1.0;

        public InputControlItemPlay Input;
		public BranchCondition BranchCondition;
		public GogoCondition GogoCondition;
		public BalloonControl BalloonControl;
		public BPMStatusControl BPMStatusControl;
		public Chara Chara;
		public NoteImageControl NoteImageControl;
		public MeasureLineImageControl BarLineImageControl;
		public NoteText NoteText;
		public BranchScoreControl BranchScoreControl;
		public HitImageControl HitImageControl;
		public Tatelier.Interface.Play.INoteFlyEffect NoteFlyEffect;
		public NoteFieldControl NoteFieldControl;
		public IScoreRenderer NoteRenderer;
		public Tatelier.Score.Play.Chart.HBScrollDrawDataItem CurrentHBScrollDrawDataItem = null;
		public JudgeFrame JudgeFrame;
		public JudgeImageControl JudgeImageControl;
		public Tatelier.Result.ResultData ResultData;
		public SoulGauge SoulGauge;
		public TaikoImageControl TaikoImageControl;
		public ScoreNumberImageControl ScoreNumberImageControl;
		public TaikoSEControl TaikoSEControl;
		public Tatelier.Score.Play.Chart.TJA.Score Score;
		public ComboNumberImageControl ComboNumberImageControl;
		public RollNumberImageControl RollNumberImageControl;
		public BalloonNumberImageControl BalloonNumberImageControl;
		public PlayInputItemControl PlayInputItemControl;
		public Background3 Background3;
		public UpdateState State;
		public JudgeType JudgeType;
	}

}
