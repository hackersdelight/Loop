using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Interfaces
{
	public interface IDataStorage
	{
		ITaskActions TaskActions { get; }
		IUserActions UserActions { get; }
		IRiskActions RiskActions { get; }
		ISprintActions SprintActions { get; }
	}

	public interface ITaskActions
	{
		void AddTask(ITask task);
		void DeleteTask(ITask task);
		void EditTask(ITask task);
		ITask GetTaskById(int id);
		List<ITask> GetAllTasks();

		List<ITaskPriority> GetAllTaskPriorities();
		List<ITaskStatus> GetAllTaskStatuses();
	}

	public interface ISprintActions
	{
		void AddSprint(ISprint sprint);
		void DeleteSprint(ISprint sprint);
		void EditSprint(ISprint sprint);
		ISprint GetSprintById(int id);
		List<ISprint> GetAllSprints();
		List<ITask> GetAllTasksForSprint(int sprintId);
	}

	public interface IRiskActions
	{
		void AddRisk(IRisk risk);
		void DeleteRisk(IRisk risk);
		void EditRisk(IRisk risk);
		IRisk GetRiskById(int id);
		List<IRisk> GetAllRisks();
		List<IRiskType> GetAllRiskTypes();
	}

	public interface IUserActions
	{
		void AddUser(IUser user);
		void DeleteUser(IUser user);
		void EditUser(IUser user);
		IUser GetUserById(int id);
		List<IUser> GetAllUsers();
		List<IUser> GetActiveUsers();
		bool IsExist(string login);
	}
}
