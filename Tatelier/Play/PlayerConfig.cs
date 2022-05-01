using HjsonEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Play
{
	class PlayerConfigInfo
	{
		public Hjson.JsonValue Json;
		public int PlayerNum = 1;
		public Dictionary<string, Action<int>> DrawActionMap;
		public Dictionary<string, Action<int>> UpdateActionMap;
	}

	class PlayerConfig
	{
		public class MapKey
		{
			public const string Background = "Background";
			public const string BackgroundUpper = "Background.Upper";
			public const string BackgroundLower = "Background.Lower";
			public const string BackgroundStage = "Background.Stage";
			public const string BalloonNumber = "BalloonNumber";
			public const string Chara = "Chara";
			public const string ComboNumber = "ComboNumber";
			public const string Dancer = "Dancer";
			public const string DetailInfo = "DetailInfo";
			public const string JudgeFrame = "JudgeFrame";
			public const string JudgeText = "JudgeText";
			public const string KeyConfig = "KeyConfig";
			public const string Lyric = "Lyric";
			public const string Measure = "Measure";
			public const string Note = "Note";
			public const string NoteHit = "Note.Hit";
			public const string NoteField = "NoteField";
			public const string NoteFieldEffect = "NoteField.Effect";
			public const string NoteFieldBranch = "NoteField.Branch";
			public const string NoteFieldGogo = "NoteField.Gogo";
			public const string NoteFlyEffect = "NoteFlyEffect";
			public const string NoteText = "NoteText";
			public const string Other = "Other";
			public const string RollNumber = "RollNumber";
			public const string ScoreNumber = "ScoreNumber";
			public const string SoulGauge = "SoulGauge";
			public const string SoundEffect = "SoundEffect";
			public const string Taiko = "Taiko";
			public const string Title = "Title";

		}

		public enum Type : int
		{
			KeyConfig,
			Background,
			BackgroundUpper,
			BackgroundLower,
			BackgroundStage,
			BalloonNumber,
			NoteFieldControl,
			NoteFieldEffect,
			NoteFieldBranch,
			NoteFieldGogo,
			TaikoImageControl,
			TitleControl,
			SoulGaugeList,
			ScoreNumberImageControl,
			ComboNumberImageControl,
			JudgeFrame,
			JudgeText,
			Lyric,
			NoteFlyEffect,
			Chara,
			Dancer,
			DetailInfo,
			Measure,
			Note,
			NoteHit,
			NoteText,
			Other,
			RollNumber,
			SoundEffect,
			Length,
		}

		List<Hjson.JsonValue>[] itemList;

		public Tatelier.Play.Player[] Players;

		public (int PlayerNumbrt, Action<int> Act)[] DrawActList;
		public (int PlayerNumbrt, Action<int> Act)[] UpdateActList;

		public List<Hjson.JsonValue> Get(Type type) => itemList[(int)type];

		/// <summary>
		/// プレイヤー設定ファイルの存在をチェック
		/// </summary>
		/// <param name="num"></param>
		/// <returns></returns>
		public static bool Exists(int num)
		{
			var path = MainConfig.Singleton.GetThemePath($@"Play\PlayConfig\Player{num:000}.hjson");

			return File.Exists(path);
		}
		public static int TryLoad(PlayerConfigInfo info, out PlayerConfig config)
		{
			try
			{
				config = new PlayerConfig(info);
				return 0;
			}
			catch
			{
				config = null;
				return 2;
			}
		}

		public PlayerConfig(PlayerConfigInfo info)
		{
			itemList = new List<Hjson.JsonValue>[(int)Type.Length];

			for (int i = 0; i < (int)Type.Length; i++)
			{
				itemList[i] = new List<Hjson.JsonValue>();
			}



			var map = new Dictionary<string, Type>()
			{
				{ MapKey.Background, Type.Background },
				{ MapKey.BackgroundUpper, Type.BackgroundUpper },
				{ MapKey.BackgroundLower, Type.BackgroundLower },
				{ MapKey.BackgroundStage, Type.BackgroundStage },
				{ MapKey.BalloonNumber, Type.BalloonNumber },
				{ MapKey.Chara, Type.Chara },
				{ MapKey.ComboNumber, Type.ComboNumberImageControl },
				{ MapKey.Dancer, Type.Dancer },
				{ MapKey.JudgeFrame, Type.JudgeFrame },
				{ MapKey.JudgeText, Type.JudgeText },
				{ MapKey.KeyConfig, Type.KeyConfig },
				{ MapKey.Lyric, Type.Lyric },
				{ MapKey.Measure, Type.Measure },
				{ MapKey.Note, Type.Note },
				{ MapKey.NoteHit, Type.NoteHit },
				{ MapKey.NoteField, Type.NoteFieldControl },
				{ MapKey.NoteFieldEffect, Type.NoteFieldEffect },
				{ MapKey.NoteFieldBranch, Type.NoteFieldBranch },
				{ MapKey.NoteFieldGogo, Type.NoteFieldGogo },
				{ MapKey.NoteFlyEffect, Type.NoteFlyEffect },
				{ MapKey.NoteText, Type.NoteText },
				{ MapKey.Other, Type.Other },
				{ MapKey.RollNumber, Type.RollNumber },
				{ MapKey.ScoreNumber, Type.ScoreNumberImageControl },
				{ MapKey.SoulGauge, Type.SoulGaugeList },
				{ MapKey.SoundEffect, Type.SoundEffect },
				{ MapKey.Taiko, Type.TaikoImageControl },
				{ MapKey.Title, Type.TitleControl },
			};

			var drawActList = new List<(int, Action<int>)>();
			var updateActList = new List<(int, Action<int>)>();

			foreach (var item in info.Json.EQa("Elements"))
			{
				var name = item.EQs("Name").Replace("::", ".");

				info.DrawActionMap.TryGetValue(name, out var drawAct);
				info.UpdateActionMap.TryGetValue(name, out var updateAct);

				if (map.TryGetValue(name, out var t))
				{
					itemList[(int)t].Add(item);
				}
				else
				{
					continue;
				}

				int num = (item.EQi("Player") ?? 1) - 1;

				if (drawAct != null)
				{
					drawActList.Add((num, drawAct));
				}

				if (updateAct != null)
				{
					updateActList.Add((num, updateAct));
				}
			}

			DrawActList = drawActList.ToArray();
			UpdateActList = updateActList.ToArray();
			Players = new Play.Player[info.PlayerNum];
		}
	}
}
