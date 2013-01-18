using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loop.Core.Interfaces;

namespace Loop.Core
{
	public class Loop
	{
		private IDataStorage storage;
		private Loop()
		{ }

		public Loop(IDataStorage dataStorage)
		{
			storage = dataStorage;
		}

		public List<ITask> GetAllTasks()
		{
			return storage.GetAllTasks();
		}

		public List<IRisk> GetAllRisks()
		{
			return storage.GetAllRisks();
		}

		public List<ISprint> GetAllSprints()
		{
			return storage.GetAllSprints();
		}
	}
}
