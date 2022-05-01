using Hjson;
using HjsonEx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
    [DebuggerDisplay("Course: {CourseID}, Latest: {LatestResultList[0].PlayDateTime} - {LatestResultList[0].ScorePoint}")]
    class MusicalScoreSaveDataCourse
    {
        const int TopListSize = 3;
        const int LastListSize = 3;

        [DebuggerDisplay("[{ClearType}] {PlayDateTime} - {ScorePoint}")]
        public class Result
        {
            public class JudgeRange
            {
                public int Great = -1;
                public int Good = -1;
                public int Bad = -1;

                public void InputJson(Hjson.JsonValue json)
                {
                    Great = json.EQi(nameof(Great)) ?? -1;
                    Good = json.EQi(nameof(Good)) ?? -1;
                    Bad = json.EQi(nameof(Bad)) ?? -1;
                }

                public Hjson.JsonValue OutputJson()
                {
                    var json = new Hjson.JsonObject()
                    {
                        { nameof(Great), Great },
                        { nameof(Good), Good },
                        { nameof(Bad), Bad },
                    };

                    return json;
                }
            }

            /// <summary>
            /// 演奏日時
            /// </summary>
            public DateTime PlayDateTime = DateTime.MinValue;

            public ClearType ClearType { get; set; } = ClearType.None;

            public int ScorePoint = 0;

            public int Great = 0;
            public int Good = 0;
            public int Bad = 0;

            public int Roll = 0;

            public int MaxCombo = 0;

            public JudgeRange Judge = new JudgeRange();

            public int InputJson(Hjson.JsonValue json)
            {
                PlayDateTime = DateTime.Parse(json[nameof(PlayDateTime)]);
                ClearType = (ClearType)json.EQl(nameof(ClearType));
                ScorePoint = json[nameof(ScorePoint)].Qi();
                Great = json[nameof(Great)].Qi();
                Good = json[nameof(Good)].Qi();
                Bad = json[nameof(Bad)].Qi();
                Roll = json[nameof(Roll)].Qi();
                MaxCombo = json.EQi(nameof(MaxCombo)) ?? 0;
                Judge.InputJson(json?.EQv(nameof(Judge)) ?? new JsonObject());

                return 0;
            }

            public Hjson.JsonValue OutputJson()
            {
                var json = new Hjson.JsonObject()
                {
                    { nameof(PlayDateTime), $"{PlayDateTime}" },
                    { nameof(ClearType), (long)ClearType },
                    { nameof(ScorePoint), ScorePoint },
                    { nameof(Great), Great },
                    { nameof(Good), Good },
                    { nameof(Bad), Bad },
                    { nameof(Roll), Roll },
                    { nameof(MaxCombo), MaxCombo },
                    { nameof(Judge), Judge.OutputJson() },
                };

                return json;
            }
        }

        public int CourseID = int.MinValue;

        public ClearType ClearType = ClearType.None;

        public Result BestResult => TopResultList?.FirstOrDefault();

        /// <summary>
        /// 成績トップ3の結果リスト
        /// </summary>
        public Result[] TopResultList;

        /// <summary>
        /// 直近3回の結果リスト
        /// </summary>
        public Result[] LatestResultList;

        public int InputJson(JsonValue json)
        {
            CourseID = json[nameof(CourseID)].Qi();
            ClearType = (ClearType)json.EQl(nameof(ClearType));

            TopResultList = (json[nameof(TopResultList)] as Hjson.JsonArray).Select(v =>
            {
                var r = new Result();
                r.InputJson(v);
                return r;
            }).ToArray();

            LatestResultList = (json[nameof(LatestResultList)] as Hjson.JsonArray).Select(v =>
            {
                var r = new Result();
                r.InputJson(v);
                return r;
            }).ToArray();

            return 0;
        }

        public Hjson.JsonValue OutputJson()
        {
            Hjson.JsonObject json = new Hjson.JsonObject();

            json[nameof(CourseID)] = CourseID;
            json[nameof(ClearType)] = (long)ClearType;

            //
            var tops = new Hjson.JsonArray();            
            for(int i = 0; i < TopResultList.Length; i++)
            {
                tops.Add(TopResultList[i].OutputJson());
            }
            json[nameof(TopResultList)] = tops;

            //
            var latests = new Hjson.JsonArray();
            for (int i = 0; i < LatestResultList.Length; i++)
            {
                latests.Add(LatestResultList[i].OutputJson());
            }
            json[nameof(LatestResultList)] = latests;

            return json;
        }

        public void Regist(Tatelier.Result.ResultData resultData)
		{
            ClearType |= resultData.ClearType;

            Result r = new Result();
            r.PlayDateTime = resultData.PlayStartDateTime;
            r.Great = resultData.GreatCount;
            r.Good = resultData.GoodCount;
            r.Bad = resultData.BadCount;
            r.ScorePoint = resultData.ScorePoint;
            r.MaxCombo = resultData.MaxCombo;

            // TODO: 
            r.ClearType = resultData.ClearType;

            // 直近3件
            LatestResultList[2] = LatestResultList[1];
            LatestResultList[1] = LatestResultList[0];
            LatestResultList[0] = r;

            // 最高成績3件
            for (int i = 0; i < TopResultList.Length; i++)
            {
                if(r.ScorePoint > TopResultList[i].ScorePoint)
				{
                    var temp = TopResultList[i].ScorePoint;
                    for(int j = TopResultList.Length - 1; j >= i + 1; j--)
					{
                        TopResultList[j] = TopResultList[j - 1];
					}
                    TopResultList[i] = r;
                    break;
				}
            }
        }

        public MusicalScoreSaveDataCourse()
        {
            TopResultList = new Result[TopListSize];
            LatestResultList = new Result[LastListSize];

            for(int i = 0; i < TopListSize; i++)
            {
                TopResultList[i] = new Result();
                LatestResultList[i] = new Result();
            }
        }
    }
}
