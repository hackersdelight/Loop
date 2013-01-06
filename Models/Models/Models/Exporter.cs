using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loop.Interfaces;
using System.IO;

namespace Loop.Models
{
	public class Exporter: IExport
	{
		private DirectoryInfo directory;
		private string filename;
		public Exporter(string directory, string filename)
		{
			this.directory = new DirectoryInfo(directory);
			this.filename = filename;
		}

		public void ExportData(List<ITask> tasks)
		{
			TestExport(tasks);
		}

		private void TestExport(List<ITask> tasks)
		{
			using (StreamWriter sw = new StreamWriter(directory.Name + filename))
			{
				foreach (ITask task in tasks)
				{
					sw.WriteLine(task.title);
				}
			}
		}
	}
}
