using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Tatelier.SongSelect
{
	/// <summary>
	/// 譜面概要
	/// </summary>
	class MusicalScore
	{
		/// <summary>
		/// ファイルの相対パス
		/// </summary>
		/// <remarks>
		/// Rootディレクトリからの相対パス
		/// </remarks>
		public string FilePathRelative = "";

		/// <summary>
		/// タイトル画面
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// サブタイトル
		/// </summary>
		public string SubTitle { get; set; } = "";

		/// <summary>
		/// かな
		/// </summary>
		public string Kana { get; set; } = "";

		/// <summary>
		/// ID
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// 歌詞ファイル名
		/// </summary>
		public string LyricFileName { get; set; } = "";

		/// <summary>
		/// ジャンル
		/// </summary>
		public string[] Genres { get; set; }

		/// <summary>
		/// 音源ファイル名
		/// </summary>
		public string WaveFilePath { get; set; } = "";

		/// <summary>
		/// 音源開始オフセット(ミリ秒)
		/// </summary>
		public int DemoStartMilliseconds { get; set; }

		/// <summary>
		/// コース
		/// </summary>
		public IReadOnlyList<Course> Courses => courses;

		List<Course> courses = new List<Course>();

		/// <summary>
		/// セーブデータ
		/// </summary>
		public List<MusicalScoreSaveData> SaveDataList;

		/// <summary>
		/// 最も簡単なコースの要素番号を取得する。
		/// </summary>
		/// <returns>Coursesの要素番号</returns>
		public int GetEasiestCourseIndex()
		{
			int result = 0;
			for (int i = 0; i < Courses.Count; i++)
			{
				if (Courses[i].Level != -1)
				{
					result = i;
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// 最も難しいコースの要素番号を取得する。
		/// </summary>
		/// <returns>Coursesの要素番号</returns>
		public int GetHardestCourseIndex()
		{
			int result = 0;
			for (int i = Courses.Count - 1; i >= 0; i--)
			{
				if (Courses[i].Level != -1)
				{
					result = i;
					break;
				}
			}

			return result;
		}

		public uint LoadFromFile(string currentFolder, string filePathRelative)
		{
			this.FilePathRelative = filePathRelative;

			return LoadFromFile(Path.Combine(currentFolder, filePathRelative));
		}

		public int LoadSaveData(string scoreRootFolder, IEnumerable<string> playerNameList, bool reload = false)
        {
			if (!reload && SaveDataList != null)
			{
				return 0;
			}

			var saveDataList = new List<MusicalScoreSaveData>();

			foreach (var name in playerNameList)
			{
				string filePath = MainConfig.Singleton.GetScoreSaveDataFilePath(name, Path.GetFullPath(Path.Combine(scoreRootFolder, FilePathRelative)));
				var saveData = new MusicalScoreSaveData();
				saveData.Load(filePath);
				saveDataList.Add(saveData);
			}

			SaveDataList = saveDataList;

			return 0;
        }

		public int UnloadSaveData()
        {
			SaveDataList = null;

			return 0;
		}

		uint LoadFromFile(string filePath)
		{
			try
			{
				var encoding = Utility.GetEncodingFromFile(filePath) ?? Encoding.UTF8;

				if (!File.Exists(filePath))
				{
					return 0x80010101;
				}

				using (var sr = new StreamReader(filePath, encoding))
				{
					var regex = new Regex(@"(\S+):(.+)");

					List<Course> courses = new List<Course>();

					Course course = new Course();

					while (!sr.EndOfStream)
					{
						var line = sr.ReadLine();

						for (int i = 0; i < line.Length; i++)
						{
							if (line[i] == '/'
								&& (i + 1 < line.Length)
								&& line[i + 1] == '/')
							{
								line = line.Substring(0, i);
							}
						}

						if (regex.IsMatch(line))
						{
							var match = regex.Match(line);
							var groups = match.Groups;
							switch (groups[1].Value.ToUpper())
							{
								case "TITLE":
									Title = groups[2].Value;
									break;
								case "KANA":
									Kana = groups[2].Value;
									break;
								case "SUBTITLE":
									{
										var text = groups[2].Value;
										if (text.StartsWith("--"))
										{
											text = text.Substring(2);
										}
										SubTitle = text;
									}
									break;
								case "ID":
									Id = groups[2].Value;
									break;
								case "GENRE":
									Genres = groups[2].Value.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
									break;
								case "LYRIC":
									LyricFileName = groups[2].Value;
									break;
								case "WAVE":
									WaveFilePath = groups[2].Value;
									break;
								case "DEMOSTART":
									double tempMillisec = 0.0F;
									if (!double.TryParse(groups[2].Value, out tempMillisec))
									{
										tempMillisec = 0.0F;
                                    }
									
									DemoStartMilliseconds = (int)(tempMillisec * 1000);
									break;
								case "COURSE":
									string name = Utility.GetCourse(groups[2].Value);
									course.OriginalName = name;
									break;
								case "LEVEL":
									course.Level = (int)float.Parse(groups[2].Value);
									break;
							}

						}
                        else if(line.StartsWith("#START"))
						{
							if (course.Level != -1)
							{
								courses.Add(course);
								course = new Course();
							}
						}
					}

					this.courses.Add(Course.GetOrCreateCourse(courses, "Easy"));
					this.courses.Add(Course.GetOrCreateCourse(courses, "Normal"));
					this.courses.Add(Course.GetOrCreateCourse(courses, "Hard"));
					this.courses.Add(Course.GetOrCreateCourse(courses, "Oni"));
					this.courses.Add(Course.GetOrCreateCourse(courses, "Edit"));
				}

				if (Title == null)
				{
					Title = "$$ TITLE not found. $$";
					SubTitle = $"Path: {filePath}";
				}

				return Error.SUCCESS;
			}
			catch
			{
				return Error.CODE_SCORE_EXCEPTION;
			}
		}


		/// <summary>
		/// 歌詞ファイルパスを取得する。
		/// </summary>
		/// <param name="dir">ディレクトリパス</param>
		/// <returns></returns>
		public string GetLyricFilePath(string dir)
		{
			if (LyricFileName?.Length > 0)
			{
				return Path.Combine(dir, LyricFileName);
			}
			else
			{
				var lyricFileName = Path.GetFileNameWithoutExtension(WaveFilePath) + ".lrc";
				return Path.Combine(dir, lyricFileName);
			}
		}
	}
}
