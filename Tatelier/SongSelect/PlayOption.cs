using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
    public class PlayOption
    {
        public PlayOptionScrollSpeed ScrollSpeed { get; private set; }

        public PlayOptionNote Note { get; private set; }

        public PlayOptionHitSE HitSE { get; private set; }

        public PlayOptionSpecial Special { get; private set; }

        public PlayOptionNoteHide NoteHide { get; private set; }

        string SeedText { get; set; }

        public IList<IPlayOptionItem> PlayOptionItemList;

        public void SetDefault()
        {
            ScrollSpeed = new PlayOptionScrollSpeed();
            Note = new PlayOptionNote();
            HitSE = new PlayOptionHitSE();
            Special = new PlayOptionSpecial();
            NoteHide = new PlayOptionNoteHide();

            SeedText = string.Join("", "abcdef0123456789".OrderBy(v => Guid.NewGuid()).ToArray());

            PlayOptionItemList = new IPlayOptionItem[]
            {
                ScrollSpeed,
                NoteHide,
                Note,
                Special,
            };
        }

        public PlayOption()
        {
            SetDefault();
        }

        public interface IPlayOptionItem
        {
            object Header { get; }

            string ValueFormat { get; }

            object RawValue { get; }

            void Next();

            void Prev();
        }

        public class PlayOptionScrollSpeed
            : IPlayOptionItem
        {
            readonly static double[] speedList = new double[]
            {
                2.0,
                3.0,
                4.0
            };

            public object Header { get; } = "はやさ";

            public double Value { get; set; } = 1.0;

            public string ValueFormat { get; set; } = "x{0:0.0}";

            string IPlayOptionItem.ValueFormat => ValueFormat;
            object IPlayOptionItem.RawValue => Value;

            public void Next()
            {
                if (Value < 1.0)
                {
                    Value = 1.0;
                }
                else if (Value > speedList[speedList.Length - 1])
                {
                    Value = 1.0;
                }
                else
                {
                    for (int i = 0; i < speedList.Length; i++)
                    {
                        if (Value < speedList[i])
                        {
                            Value = speedList[i];
                            return;
                        }
                    }
                    Value = 1.0;
                }

                return;
            }

            public void Prev()
            {
                if (Value < 1.0)
                {
                    Value = 1.0;
                }
                else if (Value == 1.0)
                {
                    Value = speedList[speedList.Length - 1];
                }
                else
                {
                    for (int i = speedList.Length - 1; i >= 0; i--)
                    {
                        if (Value > speedList[i])
                        {
                            Value = speedList[i];
                            return;
                        }
                    }
                    Value = 1.0;
                }
            }
        }

        public class PlayOptionNote
            : IPlayOptionItem
        {
            public object Header { get; } = "モード";

            public string ValueFormat
            {
                get
                {
                    switch (Value)
                    {
                        case PlayOptionNoteType.Normal:
                        default:
                            return "標準";
                        case PlayOptionNoteType.Inverse:
                            return "あべこべ";
                        case PlayOptionNoteType.LowRandom:
                            return "きまぐれ";
                        case PlayOptionNoteType.HighRandom:
                            return "でたらめ";
                        case PlayOptionNoteType.SeedRandom:
                            return "シード";
                    }
                }
            }

            PlayOptionNoteType[] list;

            int index = 0;

            public PlayOptionNoteType Value
            {
                get
                {
                    return list[index];
                }
                set
                {
                    index = Array.IndexOf(list, value);
                }
            }

            public PlayOptionNote()
            {
                list = new PlayOptionNoteType[]
                {
                    PlayOptionNoteType.Normal,
                    PlayOptionNoteType.LowRandom,
                    PlayOptionNoteType.HighRandom,
                };
            }

            object IPlayOptionItem.RawValue => Value;

            public bool IsRandom
            {
                get
                {
                    switch (Value)
                    {
                        case PlayOptionNoteType.LowRandom:
                        case PlayOptionNoteType.HighRandom:
                        case PlayOptionNoteType.SeedRandom:
                            return true;
                        default:
                            return false;
                    }
                }
            }

            public int RandomRatio
            {
                get
                {
                    switch (Value)
                    {
                        case PlayOptionNoteType.Normal:
                        default:
                            return 0;
                        case PlayOptionNoteType.Inverse:
                            return 100;
                        case PlayOptionNoteType.LowRandom:
                            return 30;
                        case PlayOptionNoteType.HighRandom:
                            return 70;
                        case PlayOptionNoteType.SeedRandom:
                            return -1;
                    }
                }
            }

            public void Next()
            {
                index = (index + 1) % list.Length;
            }

            public void Prev()
            {
                index = (index + (list.Length - 1)) % list.Length;
            }
        }

        public class PlayOptionSpecial
            : IPlayOptionItem
        {
            public object Header { get; } = "特殊";

            public string ValueFormat
            {
                get
                {
                    switch(Value)
                    {
                        case PlayOptionSpecialType.Auto:
                            return "オート";
                        case PlayOptionSpecialType.Normal:
                        default:
                            return "なし";
                    }
                }
            }

            public PlayOptionSpecialType Value;

            object IPlayOptionItem.RawValue => Value;

            public void Next()
            {
                if(Value == PlayOptionSpecialType.Normal)
                {
                    Value = PlayOptionSpecialType.Auto;
                }
                else if(Value == PlayOptionSpecialType.Auto)
                {
                    Value = PlayOptionSpecialType.Normal;
                }
            }

            public void Prev()
            {
                if (Value == PlayOptionSpecialType.Auto)
                {
                    Value = PlayOptionSpecialType.Normal;
                }
                else if(Value == PlayOptionSpecialType.Normal)
                {
                    Value = PlayOptionSpecialType.Auto;
                }                
            }
        }

        public class PlayOptionHitSE
            : IPlayOptionItem
        {
            public object Header { get; } = "音色";

            public string ValueFormat => "ピアノ";

            public object RawValue => null;

            public void Next()
            {

            }

            public void Prev()
            {

            }
        }

        public class PlayOptionNoteHide
            : IPlayOptionItem
        {
            public object Header { get; } = "ドロン";

            public string ValueFormat
            {
                get
                {
                    if (IsNoteHide)
                    {
                        return "する";
                    }
                    else
                    {
                        return "しない";
                    }
                }
            }

            public object RawValue => null;

            public bool IsNoteHide = false;

            public void Next()
            {
                IsNoteHide = !IsNoteHide;
            }

            public void Prev()
            {
                IsNoteHide = !IsNoteHide;
            }
        }
    }
}
