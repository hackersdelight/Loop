using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Core.Interfaces
{
	public interface IDataProvider
	{
		List<ITask> ImportData();
	}
}
