using System;
using System.Collections.Generic;
using Loop.DatabaseConnection;
using Loop.Interfaces;
using LoopUI.Models;

namespace LoopUI.Controllers
{
	internal class SprintActions : ISprintActions
	{
		private IConnectToDB connection;

		internal SprintActions(IConnectToDB connection)
		{
			this.connection = connection;
		}

		public void AddSprint(ISprint sprint)
		{
			throw new NotImplementedException();
		}
		public List<ISprint> GetAllSprints()
		{
			List<ISprint> result = new List<ISprint>();
			result.Add(new Sprint() { Id = 1, IsActive = false, KeyedName = "Sp1" });
			result.Add(new Sprint() { Id = 2, IsActive = true, KeyedName = "Sp2" });
			result.Add(new Sprint() { Id = 3, IsActive = false, KeyedName = "Sp3" });
			return result;
		}


		public void DeleteSprint(ISprint sprint)
		{
			throw new NotImplementedException();
		}

		public void EditSprint(ISprint sprint)
		{
			throw new NotImplementedException();
		}

		public ISprint GetSprintById(int id)
		{
			throw new NotImplementedException();
		}
	}
}