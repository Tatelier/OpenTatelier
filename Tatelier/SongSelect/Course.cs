using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.SongSelect
{
	/// <summary>
	/// コース
	/// </summary>
	class Course
	{
		string originalName = "Oni";

		CourseType GetCourseType(string name)
        {
			CourseType result = CourseType.VeryHardA;

			switch (name.ToUpper())
			{
				case "EASY":
				case "0":
					result = CourseType.Easy;
					break;
				case "NORMAL":
				case "1":
					result = CourseType.Normal;
					break;
				case "HARD":
				case "2":
					result = CourseType.Hard;
					break;
				case "VERYHARDA":
				case "3":
				case "ONI":
					result = CourseType.VeryHardA;
					break;
				case "VERYHARDB":
				case "4":
				case "URA":
				case "EDIT":
					result = CourseType.VeryHardB;
					break;
			}

            return result;
        }

		/// <summary>
		/// 難易度名
		/// </summary>
		public string OriginalName
        {
            get
            {
				return originalName;
            }
            set
            {
				originalName = value;

			}
        }

		public CourseType CourseType { get; private set; }

		/// <summary>
		/// 難易度
		/// </summary>
		public double Level = -1;

        /// <summary>
        /// 分岐有無
        /// </summary>
        public bool HasBranch { get; set; } = false;


        /// <summary>
        /// HBSCROLL有無
        /// </summary>
        public bool HasHBSCROLL { get; set; } = false;

		public static Course GetOrCreateCourse(IEnumerable<Course> courses, string name)
		{
			if (!courses.Any(v => v.OriginalName == name))
			{
				return new Course { OriginalName = name, Level = -1 };
			}
			else
			{
				return courses.First(v => v.OriginalName == name);
			}
		}
	}
}
