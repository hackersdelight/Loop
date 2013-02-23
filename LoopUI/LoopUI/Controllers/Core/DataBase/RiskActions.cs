using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;
using Loop.DatabaseConnection;
using LoopUI.Models;

namespace LoopUI.Controllers
{
	internal class RiskActions : IRiskActions
	{
		private IConnectToDB connection;

		internal RiskActions(IConnectToDB connection)
		{
			this.connection = connection;
		}

		public void AddRisk(IRisk risk)
		{
			connection.OpenConnection();
			//query execution is here;
			connection.CloseConnection();
			throw new NotImplementedException();
		}

		public List<IRisk> GetAllRisks()
		{
			List<IRisk> result = new List<IRisk>();
			result.Add(new Risk() { Id = 1, Title = "Regression", Type = new RiskType() { Id = 1, Title = "Task" } });
			result.Add(new Risk() { Id = 2, Title = "Return", Type = new RiskType() { Id = 1, Title = "Task" } });
			result.Add(new Risk() { Id = 3, Title = "Requirements Change", Type = new RiskType() { Id = 2, Title = "Sprint" } });
			return result;
		}

		public List<IRiskType> GetAllRiskTypes()
		{
			List<IRiskType> result = new List<IRiskType>();
			result.Add(new RiskType() { Id = 1, Title = "Task" });
			result.Add(new RiskType() { Id = 2, Title = "Sprint" });
			return result;
		}


		public void DeleteRisk(IRisk risk)
		{
			throw new NotImplementedException();
		}

		public void EditRisk(IRisk risk)
		{
			throw new NotImplementedException();
		}

		public IRisk GetRiskById(int id)
		{
			throw new NotImplementedException();
		}
	}
}