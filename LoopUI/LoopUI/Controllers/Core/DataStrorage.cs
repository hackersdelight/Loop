using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;
using Loop.DatabaseConnection;
using LoopUI.Models;
using Loop.Enumerations;

namespace LoopUI.Controllers
{
	internal class DataStorage : IDataStorage
	{
		private DataStorage()
		{
			connection = new ConnectToMsSql();
		}

		private ConnectToMsSql connection;

		private static DataStorage instance = new DataStorage();

		internal static DataStorage Instance
		{
			get
			{
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
			List<IRisk> result = new List<IRisk>();
			result.Add(new Risk() { Id = 1, Title = "Regression", Type = new RiskType() { Id = 1, Title = "Task" } });
			result.Add(new Risk() { Id = 2, Title = "Return", Type = new RiskType() { Id = 1, Title = "Task" } });
			result.Add(new Risk() { Id = 3, Title = "Requirements Change", Type = new RiskType() { Id = 2, Title = "Sprint" } });
			return result;
		}

		public List<ISprint> GetAllSprints()
		{
			List<ISprint> result = new List<ISprint>();
			result.Add(new Sprint() { Id = 1, IsActive = false, KeyedName = "Sp1" });
			result.Add(new Sprint() { Id = 2, IsActive = true, KeyedName = "Sp2" });
			result.Add(new Sprint() { Id = 3, IsActive = false, KeyedName = "Sp3" });
			return result;
		}

		public List<ITask> GetAllTasks()
		{
			List<ITask> result = new List<ITask>();
			result.Add(new Task()
			{
				Id = 1,
				Number = "IR-1010100",
				Title = "Test",
				Status = new TaskStatus() { Id = 1, Title = "Planning", State = StatusState.Pending },
				Prioroty = new TaskPriority() { Id = 1, Title = "1", Value = 5 },
				Assignment = new LoopUI.Models.User() { Id = 1, Name = "alexandra", Surname = "panaryna", Login = "sandra" },
				IsActive = true
			});
			return result;
		}

		public List<IUser> GetAllUsers()
		{
			List<IUser> result = new List<IUser>();
			result.Add(new User() { Id = 1, Login = "sandra", Name = "alexandra", Surname = "panaryna", Email = "777@informatics.by", Password = "1", IsActive = true });
			result.Add(new User() { Id = 2, Login = "god", Name = "Jesus", Surname = "christ", Email = "god@informatics.by", Password = "god", IsActive = true });
			result.Add(new User() { Id = 3, Login = "test", Name = "Alesha", Surname = "Popovich", Email = "pop@informatics.by", Password = "pop", IsActive = false });
			return result;
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

		internal bool UserExists(string login)
		{
			try
			{
				connection.OpenConnection();
				return false;
			}
			catch (Exception e)
			{
				Logger.Instance.WriteToLog(e.Message);
				return false;
			}
			finally
			{
				connection.CloseConnection();
			}
		}


		public List<IRiskType> GetAllRiskTypes()
		{
			List<IRiskType> result = new List<IRiskType>();
			result.Add(new RiskType() { Id = 1, Title = "Task" });
			result.Add(new RiskType() { Id = 2, Title = "Sprint" });
			return result;
		}

		public List<ITaskPriority> GetAllTaskPriorities()
		{
			List<ITaskPriority> result = new List<ITaskPriority>();
			result.Add(new TaskPriority() { Id = 1, Title = "1", Value = 5 });
			result.Add(new TaskPriority() { Id = 2, Title = "2", Value = 4 });
			result.Add(new TaskPriority() { Id = 3, Title = "3", Value = 3 });
			return result;
		}

		public List<ITaskStatus> GetAllTaskStatuses()
		{
			List<ITaskStatus> result = new List<ITaskStatus>();
			result.Add(new TaskStatus() { Id = 1, Title = "Planning", State = StatusState.Pending });
			result.Add(new TaskStatus() { Id = 2, Title = "Development", State = StatusState.InProgress });
			result.Add(new TaskStatus() { Id = 3, Title = "Closed", State = StatusState.Complete });
			return result;
		}

		public List<IUser> GetActiveUsers()
		{
			List<IUser> result = new List<IUser>();
			result.Add(new User() { Id = 1, Login = "sandra", Name = "alexandra", Surname = "panaryna", Email = "777@informatics.by", Password = "1", IsActive = true });
			result.Add(new User() { Id = 2, Login = "god", Name = "Jesus", Surname = "christ", Email = "god@informatics.by", Password = "god", IsActive = true });
			return result;
		}
	}
}