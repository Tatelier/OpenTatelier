using System.IO;
using Tatelier.Play;
using Tatelier.Score;
using Tatelier.Score.Component.NoteSystem;

namespace Tatelier.Multi
{
    class MultiItem
		: INormalScoreRendererTarget
		, IHBScrollScoreRendererTarget
	{
		public string CourseName = "";

		public int Level = -1;

		public int CourseID = int.MinValue;

		/// <summary>
		/// 0:1人, 1:2人
		/// </summary>
		public int PlayStyle = 0;

		public Control.Toggle ToggleSEEnabled;

		public bool HasAttention { get; } = true;

		public bool IsOpen { get; set; } = true;

		public NoteImageControl NoteImageControl;
		public MeasureLineImageControl BarLineImageControl;


		public JudgeFramePoint JudgeFramePoint = new JudgeFramePoint();

		IJudgeFramePoint INormalScoreRendererTarget.JudgeFramePoint => JudgeFramePoint;
		NoteImageControl INormalScoreRendererTarget.NoteImageControl => NoteImageControl;
		MeasureLineImageControl INormalScoreRendererTarget.BarLineImageControl => BarLineImageControl;
		INoteText INormalScoreRendererTarget.NoteText => new NoteText();

        IJudgeFramePoint IHBScrollScoreRendererTarget.JudgeFramePoint => JudgeFramePoint;
        NoteImageControl IHBScrollScoreRendererTarget.NoteImageControl => NoteImageControl;
		MeasureLineImageControl IHBScrollScoreRendererTarget.BarLineImageControl => BarLineImageControl;
		INoteText IHBScrollScoreRendererTarget.NoteText => new NoteText();

		float IHBScrollScoreRendererTarget.StartDrawPointX => StartDrawPointX;
        float IHBScrollScoreRendererTarget.FinishDrawPointX => FinishDrawPointX;
		double IHBScrollScoreRendererTarget.PlayOptionScrollSpeed => 1.0;

        public int NoteFieldHeight = 180;
		public Tatelier.Score.Play.Chart.TJA.Score Score;

		public float StartDrawPointX;

		public float FinishDrawPointX;

		public IScoreRenderer NoteRenderer;

		public void Update()
		{
			ToggleSEEnabled.Update();
		}

		public MultiItem(Control control, MultiItemInfo info)
		{
			ToggleSEEnabled = control.CreateToggle(Path.Combine("Resources\\Theme\\System\\Edit", "SE.png"));
			CourseName = info.CourseName;
			Score = info.Score;
			if (Score.ScoreType == ScoreType.Normal)
			{
				NoteRenderer = new NormalScoreRenderer(this);
			}
            else if(Score.ScoreType == ScoreType.HBScroll)
			{
				NoteRenderer = new HBScrollScoreRenderer(this);
			}
		}
	}

	class JudgeFramePoint
		: IJudgeFramePoint
    {
		public float CX { get; set; }
		public float CY { get; set; }
    }

    class NoteText : INoteText
    {
        public void Draw(float xf, float yf, NoteTextType noteTextType)
        {
        }
    }
}
