using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;
using Loop.DatabaseConnection;

namespace LoopUI.Controllers
{
	internal class DataStrorage:IDataStorage
	{
		private DataStrorage()
		{
			connection = new ConnectToMsSql();
		}

		private ConnectToMsSql connection;

		private static DataStrorage instance;

		internal static DataStrorage Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DataStrorage();
				}
				return instance;
			}
		}

		public void AddRisk(IRisk risk)
		{
			connection.OpenConnection();
			//query execution is here;
			connection.CloseConnection();
			throw new NotImplementedException();
		}

		public void AddSprint(ISprint sprint)
		{
			throw new NotImplementedException();
		}

		public void AddTask(ITask task)
		{
			throw new NotImplementedException();
		}

		public void AddUser(IUser user)
		{
			throw new NotImplementedException();
		}

		public void DeleteRisk(IRisk risk)
		{
			throw new NotImplementedException();
		}

		public void DeleteSprint(ISprint sprint)
		{
			throw new NotImplementedException();
		}

		public void DeleteTask(ITask task)
		{
			throw new NotImplementedException();
		}

		public void DeleteUser(IUser user)
		{
			throw new NotImplementedException();
		}

		public void EditRisk(IRisk risk)
		{
			throw new NotImplementedException();
		}

		public void EditSprint(ISprint sprint)
		{
			throw new NotImplementedException();
		}

		public void EditTask(ITask task)
		{
			throw new NotImplementedException();
		}

		public void EditUser(IUser user)
		{
			throw new NotImplementedException();
		}

		public List<IRisk> GetAllRisks()
		{
			throw new NotImplementedException();
		}

		public List<ISprint> GetAllSprints()
		{
			throw new NotImplementedException();
		}

		public List<ITask> GetAllTasks()
		{
			throw new NotImplementedException();
		}

		public List<IUser> GetAllUsers()
		{
			throw new NotImplementedException();
		}

		public IRisk GetRiskById(int id)
		{
			throw new NotImplementedException();
		}

		public ISprint GetSprintById(int id)
		{
			throw new NotImplementedException();
		}

		public ITask GetTaskById(int id)
		{
			throw new NotImplementedException();
		}

		public IUser GetUserById(int id)
		{
			throw new NotImplementedException();
		}
	}
}