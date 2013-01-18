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
