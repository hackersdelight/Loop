using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Interfaces
{
	public interface IDataProvider
	{
		List<ITask> ImportData();
	}
}
