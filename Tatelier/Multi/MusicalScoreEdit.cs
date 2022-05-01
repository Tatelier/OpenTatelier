using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatelier.Multi
{
	class MusicalScoreEdit
	{


		public void Save(string filePath)
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("/// <summary>共通部</summary>");
			sb.AppendLine($"TITLE:{"aieuo"}");
			sb.AppendLine($"WAVE:{"aiueo.ogg"}");

			sb.AppendLine("/// <summary>演奏部</summary>");
			sb.AppendLine("/// <course>コース</course>");
			sb.AppendLine($"COURSE:{3}");
			sb.AppendLine($"LEVEL:{1}");
			sb.AppendLine($"#START");
			
			sb.AppendLine($"#END");
			File.WriteAllText(filePath, $"{sb}");
		}
	}
}
