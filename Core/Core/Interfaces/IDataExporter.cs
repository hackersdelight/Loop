using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Interfaces
{
	public interface IDataExporter
	{
		void ExportData(List<ITask> tasks);
	}
}
