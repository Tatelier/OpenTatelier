using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.Common.Play;

namespace Tatelier.Sample
{
    class ScoreUpdateSample
    {
        // 
        TJA tja;
        int startCount;

        // 不可判定領域
        int bad1 = -65;
        int bad2 = 65;

        // 可判定領域
        int good1 = -50;
        int good2 = 50;

        // 良判定領域
        int great1 = -30;
        int great2 = 30;

        void UpdateScore(IEnumerable<BranchScore> bsc2)
        {

        }

        void Start()
        {
            startCount = Supervision.NowMilliSec;
        }

        void Update()
        {
            // 現在時間
            int nowTime = Supervision.NowMilliSec - startCount;

            // ↓ループ内で可変な変数
            // ジャスト判定との時間差
            int diffTime = 0;

            // 判定枠に最も近い音符
            Note nearNote = null;

            // 
            foreach (var score in tja.Scores)
            {
                // 分岐毎に別れた譜面で処理をする
                foreach(var bscore in score.BranchScoreControl2.GetBranchScoreList())
                {
                    // 各音符を処理する
                    foreach (var item in bscore.Notes)
                    {
                        // すでにヒットしている場合は次に進む
                        if (item.Hit) continue;

                        // (音符の開始時間 - 現在時間)
                        // を計算し、ジャスト判定との時間差を取得する
                        diffTime = item.StartTimeMillisec - nowTime;

                        // 音符の時間が現在時間より250ミリ秒後の場合は、以降の音符の処理をしない
                        if (item.NoteType != NoteType.End && diffTime > 250) break;

                        // すでに判定で使う音符が【特殊音符以外で確定】していたら以降の音符処理はしない
                        if (nearNote != null)
                        {
                            bool isContinue = false;
                            switch (nearNote.NoteType)
                            {
                                // 以下の4つは通常音符
                                case NoteType.Don:
                                case NoteType.DonBig:
                                case NoteType.Kat:
                                case NoteType.KatBig:
                                    isContinue = true;
                                    break;
                            }
                            if (isContinue) continue;
                        }

                        // 過ぎ去った不可はさよなら
                        if (diffTime <= bad1)
                        {
                            switch (item.NoteType)
                            {
                                case NoteType.Don:
                                case NoteType.DonBig:
                                case NoteType.Kat:
                                case NoteType.KatBig:
                                    item.Hit = true;
                                    //player.ResultData.AddCount(JudgeType.Bad);
                                    //player.BranchCondition.AddCount(JudgeType.Bad);
                                    //player.SoulGauge.Add(JudgeType.Bad);
                                    break;
                            }
                        }
                        // 過ぎ去った可
                        else if (diffTime <= good1)
                        {
                            //if (don)
                            //{
                            //    switch (item.NoteType)
                            //    {
                            //        case NoteType.Don:
                            //        case NoteType.DonBig:
                            //            nearNote = item;
                            //            judgeType = JudgeType.Good;
                            //            player.HitImageControl.Set(nowTime, item.NoteType, JudgeType.Good);
                            //            break;
                            //    }
                            //}
                            //if (kat)
                            //{
                            //    switch (item.NoteType)
                            //    {
                            //        case NoteType.Kat:
                            //        case NoteType.KatBig:
                            //            nearNote = item;
                            //            judgeType = JudgeType.Good;
                            //            player.HitImageControl.Set(nowTime, item.NoteType, JudgeType.Good);
                            //            break;
                            //    }
                            //}
                        }
                        // 良の範囲
                        else if (-30 <= diffTime && diffTime <= 30)
                        {
                            //if (don)
                            //{
                            //    switch (item.NoteType)
                            //    {
                            //        case NoteType.Don:
                            //        case NoteType.DonBig:
                            //            nearNote = item;
                            //            judgeType = JudgeType.Great;
                            //            player.HitImageControl.Set(nowTime, item.NoteType, JudgeType.Great);
                            //            break;
                            //    }
                            //}
                            //if (kat)
                            //{
                            //    switch (item.NoteType)
                            //    {
                            //        case NoteType.Kat:
                            //        case NoteType.KatBig:
                            //            nearNote = item;
                            //            judgeType = JudgeType.Great;
                            //            player.HitImageControl.Set(nowTime, item.NoteType, JudgeType.Great);
                            //            break;
                            //    }
                            //}
                        }
                        // 手前の可
                        else if (diffTime <= 50)
                        {
                            //if (don)
                            //{
                            //    switch (item.NoteType)
                            //    {
                            //        case NoteType.Don:
                            //        case NoteType.DonBig:
                            //            nearNote = item;
                            //            judgeType = JudgeType.Good;
                            //            player.HitImageControl.Set(nowTime, item.NoteType, JudgeType.Good);
                            //            break;
                            //    }
                            //}
                            //if (kat)
                            //{
                            //    switch (item.NoteType)
                            //    {
                            //        case NoteType.Kat:
                            //        case NoteType.KatBig:
                            //            nearNote = item;
                            //            judgeType = JudgeType.Good;
                            //            player.HitImageControl.Set(nowTime, item.NoteType, JudgeType.Good);
                            //            break;
                            //    }
                            //}
                        }
                        // 手前の不可
                        else if (diffTime <= 65)
                        {
                            //if (don)
                            //{
                            //    switch (item.NoteType)
                            //    {
                            //        case NoteType.Don:
                            //        case NoteType.DonBig:
                            //            nearNote = item;
                            //            judgeType = JudgeType.Bad;
                            //            break;
                            //    }
                            //}
                            //if (kat)
                            //{
                            //    switch (item.NoteType)
                            //    {
                            //        case NoteType.Kat:
                            //        case NoteType.KatBig:
                            //            nearNote = item;
                            //            judgeType = JudgeType.Bad;
                            //            break;
                            //    }
                            //}
                        }

                        // 特殊音符処理
                        if (diffTime < 0)
                        {
                            switch (item.NoteType)
                            {
                                case NoteType.Roll:
                                case NoteType.RollBig:
                                case NoteType.Balloon:
                                case NoteType.Dull:
                                    nearNote = item;
                                    //judgeType = JudgeType.None;
                                    break;
                                case NoteType.End:
                                    if (!item.PrevNote.Hit)
                                    {
                                        //player.BalloonControl.Next();
                                        //player.BalloonNumberImageControl.NowBalloon = false;
                                    }
                                    item.PrevNote.Hit = true;
                                    item.Hit = true;
                                    //player.RollNumberImageControl.NowRoll = false;
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
