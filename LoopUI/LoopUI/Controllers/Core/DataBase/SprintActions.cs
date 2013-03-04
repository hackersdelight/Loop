using System;
using System.Collections.Generic;
using Loop.DatabaseConnection;
using Loop.Interfaces;
using LoopUI.Models;
using System.Data;
using System.Data.SqlClient;

namespace LoopUI.Controllers
{
	internal class SprintActions : ISprintActions
	{
		private IConnectToDB connection;

		private List<ISprint> SprintsCollection;

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
			if (SprintsCollection == null)
			{
				try
				{
					connection.OpenConnection();
					DbCommand command = new DbCommand("select * from Sprints");
					command.Type = DbCommand.DbCommandType.SELECT;
					DataSet set = connection.ExecSelect(command);
					SprintsCollection = new List<ISprint>();
					foreach (DataRow row in set.Tables[0].Rows)
					{
						SprintsCollection.Add(CreateSprintInstance(row));
					}
				}
				finally
				{
					connection.CloseConnection();
				}
			}
			return SprintsCollection;
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
			if (SprintsCollection == null)
				GetAllSprints();
			if (SprintsCollection.Exists(x => x.Id == id))
			{
				return SprintsCollection.Find(x => x.Id == id);
			}
			else return null;
		}

		public List<ITask> GetAllTasksForSprint(int sprintId)
		{
			List<ITask> tasks = new List<ITask>();
			try
			{
				connection.OpenConnection();
				DbCommand command = new DbCommand("select Id from Tasks where Id in (select TaskId from SprintTaskRelationships where SprintId = @id);");
				command.Parameters = new SqlParameter[1];
				command.Parameters[0] = new SqlParameter("id", sprintId);
				command.Type = DbCommand.DbCommandType.SELECT;
				DataSet set = connection.ExecSelect(command);
				foreach (DataRow row in set.Tables[0].Rows)
				{
					tasks.Add(DataStorage.Instance.TaskActions.GetTaskById(Convert.ToInt32(row["Id"])));
				}
			}
			finally
			{
				connection.CloseConnection();
			}
			return tasks;
		}

		private ISprint CreateSprintInstance(DataRow row)
		{
			Sprint s = new Sprint()
			{
				Id = Convert.ToInt32(row["Id"]),
				KeyedName = row["KeyedName"].ToString(),
				IsActive = Convert.ToBoolean(row["IsActive"])
			};
			return s;
		}
	}
}