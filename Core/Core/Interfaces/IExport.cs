using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Core.Interfaces
{
	interface IExport
	{
		void ExportData(List<ITask> tasks);
	}
}
