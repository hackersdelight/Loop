using System.Collections.Generic;
using Loop.Interfaces;
using Loop.DatabaseConnection;
using LoopUI.Models;
using Loop.Enumerations;

namespace LoopUI.Controllers
{
	internal class TaskActions : ITaskActions
	{
		private IConnectToDB connection;
		internal TaskActions(IConnectToDB connection)
		{
			this.connection = connection;
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

		public void AddTask(ITask task)
		{
			throw new System.NotImplementedException();
		}

		public void DeleteTask(ITask task)
		{
			throw new System.NotImplementedException();
		}

		public void EditTask(ITask task)
		{
			throw new System.NotImplementedException();
		}

		public ITask GetTaskById(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}