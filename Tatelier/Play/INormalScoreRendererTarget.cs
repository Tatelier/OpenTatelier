namespace Tatelier.Play
{
	/// <summary>
	/// 標準譜面描画の対象データ
	/// </summary>
	interface INormalScoreRendererTarget
	{
		/// <summary>
		/// 判定枠座標情報
		/// </summary>
		IJudgeFramePoint JudgeFramePoint { get; }

		/// <summary>
		/// 音符画像管理
		/// </summary>
		NoteImageControl NoteImageControl { get; }

		/// <summary>
		/// 小節線画像管理
		/// </summary>
		MeasureLineImageControl BarLineImageControl { get; }

		/// <summary>
		/// 音符文字描画
		/// </summary>
		INoteText NoteText { get; }
	}
}
