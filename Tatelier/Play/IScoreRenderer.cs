using Tatelier.Score.Component;

namespace Tatelier.Play
{
    internal interface IScoreRenderer
    {
        bool IsNoteHide { get; set; }

        /// <summary>
        /// 小節線描画処理
        /// </summary>
        /// <param name="bscore">譜面</param>
        /// <param name="nowMillisec">現在時間(ms)</param>
        void DrawMeasureBranchScore(BranchScore bscore, int nowMillisec);

        /// <summary>
        /// 音符描画クラス
        /// </summary>
        /// <param name="bscore">譜面</param>
        /// <param name="nowMillisec">現在時刻(ms)</param>
        void DrawNoteBranchScore(BranchScore bscore, int nowMillisec);
    }
}