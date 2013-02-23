using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loop.Interfaces;

namespace Loop
{
	public class Core
	{
		private IDataStorage storage;
		private Core()
		{ }

		public Core(IDataStorage dataStorage)
		{
			storage = dataStorage;
		}

		//promote task
		//return task
		//select active tasks
		//count metrics
		//calculate optimized assignment
		//etc.
	}
}
