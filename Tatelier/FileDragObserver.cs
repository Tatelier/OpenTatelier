using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;

namespace Tatelier
{
	class FileDropObserver
	{
		public static FileDropObserver Singleton { get; private set; } = new FileDropObserver();

		readonly StringBuilder sb = new StringBuilder(256);

		public List<string> FileList = new List<string>();

		public void Update()
		{
			if (GetDragFileNum() > 0)
			{
				int size = GetDragFileNum();
				while (GetDragFileNum() > 0)
				{
					if (GetDragFilePath(sb) == 0)
					{
						FileList.Add($"{sb}");
						sb.Clear();
					}
				}
				DragFileInfoClear();
				if (!MyMessageBox.Singleton.IsOpen)
				{
					Supervision.CommandSearchAndRun("drag & drop", FileList.ToArray());
				}
				FileList.Clear();
			}
		}
	}
}
