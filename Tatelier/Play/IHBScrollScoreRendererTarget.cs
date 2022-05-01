namespace Tatelier.Play
{
    /// <summary>
    /// HBSCROLL譜面描画の対象データ
    /// </summary>
    interface IHBScrollScoreRendererTarget
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

        /// <summary>
        /// 譜面描画開始X座標
        /// </summary>
        float StartDrawPointX { get; }

        /// <summary>
        /// 譜面描画終了X座標
        /// </summary>
        float FinishDrawPointX { get; }

        /// <summary>
        /// 演奏オプションスクロールスピード
        /// </summary>
        double PlayOptionScrollSpeed { get; }
    }
}