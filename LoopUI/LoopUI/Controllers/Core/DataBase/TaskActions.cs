using System.Collections.Generic;
using Loop.Interfaces;
using Loop.DatabaseConnection;
using LoopUI.Models;
using Loop.Enumerations;
using System.Data;
using System;
using System.Data.SqlClient;

namespace LoopUI.Controllers
{
	internal class TaskActions : ITaskActions
	{
		private IConnectToDB connection;

		private List<ITaskPriority> TaskPrioritiesCollection;
		private List<ITaskStatus> TaskStatusesCollection;
		private List<ITask> TasksCollection;

		internal TaskActions(IConnectToDB connection)
		{
			this.connection = connection;
		}

		public List<ITask> GetAllTasks()
		{
			if (TasksCollection == null)
			{
				try
				{
					connection.OpenConnection();
					DbCommand command = new DbCommand("select * from Tasks");
					command.Type = DbCommand.DbCommandType.SELECT;
					DataSet set = connection.ExecSelect(command);
					TasksCollection = new List<ITask>();
					foreach (DataRow row in set.Tables[0].Rows)
					{
						TasksCollection.Add(CreateTaskInstance(row));
					}
				}
				catch (Exception e)
				{
					Logger.Instance.WriteToLog(e.StackTrace);
					throw;
				}
				finally
				{
					connection.CloseConnection();
				}
			}
			return TasksCollection;
		}

		public List<ITaskPriority> GetAllTaskPriorities()
		{
			if (TaskPrioritiesCollection == null)
			{
				try
				{
					connection.OpenConnection();
					DbCommand command = new DbCommand("select * from TaskPriorities");
					command.Type = DbCommand.DbCommandType.SELECT;
					DataSet set = connection.ExecSelect(command);
					TaskPrioritiesCollection = new List<ITaskPriority>();
					foreach (DataRow row in set.Tables[0].Rows)
					{
						TaskPrioritiesCollection.Add(CreateTaskPriorityInstance(row));
					}
				}
				catch (Exception e)
				{
					Logger.Instance.WriteToLog(e.StackTrace);
					throw;
				}
				finally
				{
					connection.CloseConnection();
				}
			}
			return TaskPrioritiesCollection;
		}

		public List<ITaskStatus> GetAllTaskStatuses()
		{
			if (TaskStatusesCollection == null)
			{
				try
				{
					connection.OpenConnection();
					DbCommand command = new DbCommand("select * from TaskStatuses");
					command.Type = DbCommand.DbCommandType.SELECT;
					DataSet set = connection.ExecSelect(command);
					TaskStatusesCollection = new List<ITaskStatus>();
					foreach (DataRow row in set.Tables[0].Rows)
					{
						TaskStatusesCollection.Add(CreateTaskStatusInstance(row));
					}
				}
				catch (Exception e)
				{
					Logger.Instance.WriteToLog(e.StackTrace);
					throw;
				}
				finally
				{
					connection.CloseConnection();
				}
			}
			return TaskStatusesCollection;
		}

		public void AddTask(ITask task)
		{
			try
			{
				connection.OpenConnection();
				connection.BeginTransaction();
				DbCommand command = new DbCommand("INSERT INTO Tasks (Title, Number, StatusId, PriorityId, Steps, [Description], Background, AssignmentId, Estimation, IsActive, [State]) VALUES (@title, @number, @statusid, @priorityid, @steps, @description, @background, @assignmentid, @estimation, @isactive, @state);");
				command.Parameters = new SqlParameter[11];
				command.Parameters[0] = new SqlParameter("title", task.Title);
				command.Parameters[1] = new SqlParameter("number", task.Number);
				command.Parameters[2] = new SqlParameter("statusid", task.Status.Id);
				command.Parameters[3] = new SqlParameter("priorityid", task.Prioroty.Id);
				command.Parameters[4] = new SqlParameter("steps", task.Steps);
				command.Parameters[5] = new SqlParameter("description", task.Description);
				command.Parameters[6] = new SqlParameter("background", task.Background);
				command.Parameters[7] = new SqlParameter("assignmentid", task.Assignment.Id);
				command.Parameters[8] = new SqlParameter("estimation", task.Estimation);
				command.Parameters[9] = new SqlParameter("isactive", task.IsActive.ToString());
				command.Parameters[10] = new SqlParameter("state", (int)task.State);
				command.Type = DbCommand.DbCommandType.INSERT;
				connection.ExecNonQuery(command);
				DbCommand addComments = new DbCommand("INSERT INTO Comments (Comment, TaskId) SELECT @comment, Id FROM Tasks where Number = @tasknumber;");
				addComments.Type = DbCommand.DbCommandType.INSERT;
				foreach (IComment comment in task.Comments)
				{
					addComments.Parameters = new SqlParameter[2];
					addComments.Parameters[0] = new SqlParameter("comment", comment.Value);
					addComments.Parameters[1] = new SqlParameter("tasknumber", task.Number);
					connection.ExecNonQuery(addComments);
				}
				connection.CommitTransaction();
				TasksCollection = null;
			}
			catch (Exception e)
			{
				connection.RollbackTransaction();
				Logger.Instance.WriteToLog(e.StackTrace);
				throw;
			}
			finally
			{
				connection.CloseConnection();
			}
		}

		public void DeleteTask(int id)
		{
			try
			{
				connection.OpenConnection();
				connection.BeginTransaction();
				DbCommand command = new DbCommand("DELETE FROM Tasks WHERE Id = @id;");
				command.Parameters = new SqlParameter[1];
				command.Parameters[0] = new SqlParameter("id", id);
				command.Type = DbCommand.DbCommandType.DELETE;
				connection.ExecNonQuery(command);

				DbCommand comments = new DbCommand("DELETE FROM Comments WHERE TaskId = @id;");
				comments.Parameters = new SqlParameter[1];
				comments.Parameters[0] = new SqlParameter("id", id);
				comments.Type = DbCommand.DbCommandType.DELETE;
				connection.ExecNonQuery(comments);
				connection.CommitTransaction();
				if (TasksCollection != null)
				{
					TasksCollection.Remove(TasksCollection.Find(x => x.Id == id));
				}
			}
			catch (Exception e)
			{
				connection.RollbackTransaction();
				Logger.Instance.WriteToLog(e.StackTrace);
				throw;
			}
			finally
			{
				connection.CloseConnection();
			}
		}

		public void EditTask(ITask task)
		{
			try
			{
				connection.OpenConnection();
				DbCommand command = new DbCommand("UPDATE Tasks SET Title = @title, Number = @number, StatusId = @statusid, PriorityId = @priorityid, Steps = @steps, [Description] = @description, Background = @background, AssignmentId = @assignmentid, Estimation = @estimation, IsActive = @isactive, [State] = @state WHERE Id = @id;");
				command.Parameters = new SqlParameter[12];
				command.Parameters[0] = new SqlParameter("title", task.Title);
				command.Parameters[1] = new SqlParameter("number", task.Number);
				command.Parameters[2] = new SqlParameter("statusid", task.Status.Id);
				command.Parameters[3] = new SqlParameter("priorityid", task.Prioroty.Id);
				command.Parameters[4] = new SqlParameter("steps", task.Steps);
				command.Parameters[5] = new SqlParameter("description", task.Description);
				command.Parameters[6] = new SqlParameter("background", task.Background);
				command.Parameters[7] = new SqlParameter("assignmentid", task.Assignment.Id);
				command.Parameters[8] = new SqlParameter("estimation", task.Estimation);
				command.Parameters[9] = new SqlParameter("isactive", task.IsActive.ToString());
				command.Parameters[10] = new SqlParameter("state", (int)task.State);
				command.Parameters[11] = new SqlParameter("id", (int)task.Id);
				command.Type = DbCommand.DbCommandType.UPDATE;
				connection.ExecNonQuery(command);
				if (TasksCollection != null)
				{
					//update value in Collection
					TasksCollection.Remove(TasksCollection.Find(x => x.Id == task.Id));
					TasksCollection.Add(task);
				}
			}
			catch (Exception e)
			{
				Logger.Instance.WriteToLog(e.StackTrace);
				throw;
			}
			finally
			{
				connection.CloseConnection();
			}
		}

		internal void EditComment(IComment comment)
		{
			try
			{
				connection.OpenConnection();
				DbCommand command = new DbCommand("UPDATE Comments SET Comment = @comment WHERE Id = @id;");
				command.Parameters = new SqlParameter[2];
				command.Parameters[0] = new SqlParameter("comment", comment.Value);
				command.Parameters[1] = new SqlParameter("id", comment.Id);
				command.Type = DbCommand.DbCommandType.UPDATE;
				connection.ExecNonQuery(command);
			}
			catch (Exception e)
			{
				Logger.Instance.WriteToLog(e.StackTrace);
				throw;
			}
			finally
			{
				connection.CloseConnection();
			}
		}

		internal void DeleteComment(int id)
		{
			try
			{
				connection.OpenConnection();
				DbCommand comments = new DbCommand("DELETE FROM Comments WHERE Id = @id;");
				comments.Parameters = new SqlParameter[1];
				comments.Parameters[0] = new SqlParameter("id", id);
				comments.Type = DbCommand.DbCommandType.DELETE;
				connection.ExecNonQuery(comments);
			}
			catch (Exception e)
			{
				Logger.Instance.WriteToLog(e.StackTrace);
				throw;
			}
			finally
			{
				connection.CloseConnection();
			}
		}

		internal void AddComment(int taskId, string comment)
		{
			try
			{
				connection.OpenConnection();
				DbCommand addComments = new DbCommand("INSERT INTO Comments (Comment, TaskId) VALUES (@comment, @taskid);");
				addComments.Type = DbCommand.DbCommandType.INSERT;
				addComments.Parameters = new SqlParameter[2];
				addComments.Parameters[0] = new SqlParameter("comment", comment);
				addComments.Parameters[1] = new SqlParameter("taskid", taskId);
				connection.ExecNonQuery(addComments);
			}
			catch (Exception e)
			{
				Logger.Instance.WriteToLog(e.StackTrace);
				throw;
			}
			finally
			{
				connection.CloseConnection();
			}
		}

		public ITask GetTaskById(int id)
		{
			if (TasksCollection == null)
				GetAllTasks();
			if (TasksCollection.Exists(x => x.Id == id))
			{
				return TasksCollection.Find(x => x.Id == id);
			}
			else return null;
		}

		private ITaskStatus GetTaskStatusById(int id)
		{
			if (TaskStatusesCollection == null)
				GetAllTaskStatuses();
			if (TaskStatusesCollection.Exists(x => x.Id == id))
			{
				return TaskStatusesCollection.Find(x => x.Id == id);
			}
			return null;
		}

		private ITaskPriority GetTaskPriorityById(int id)
		{
			if (TaskPrioritiesCollection == null)
				GetAllTaskPriorities();
			if (TaskPrioritiesCollection.Exists(x => x.Id == id))
			{
				return TaskPrioritiesCollection.Find(x => x.Id == id);
			}
			return null;
		}

		internal List<IComment> GetCommentsListByTaskId(int id)
		{
			List<IComment> result = new List<IComment>();
			try
			{
				connection.OpenConnection();
				DbCommand command = new DbCommand("select * from Comments where TaskId = @id");
				command.Parameters = new SqlParameter[1];
				command.Parameters[0] = new SqlParameter("id", id);
				command.Type = DbCommand.DbCommandType.SELECT;
				DataSet set = connection.ExecSelect(command);
				foreach (DataRow row in set.Tables[0].Rows)
				{
					result.Add(CreateCommentInstance(row));
				}
			}
			catch (Exception e)
			{
				Logger.Instance.WriteToLog(e.StackTrace);
				throw;
			}
			finally
			{
				connection.CloseConnection();
			}
			return result;
		}

		private ITaskPriority CreateTaskPriorityInstance(DataRow row)
		{
			TaskPriority t = new TaskPriority()
			{
				Id = Convert.ToInt32(row["Id"]),
				Title = row["Title"].ToString(),
				Value = Convert.ToInt32(row["Value"])
			};
			return t;
		}

		private IComment CreateCommentInstance(DataRow row)
		{
			Comment c = new Comment()
			{
				Id = Convert.ToInt32(row["Id"]),
				Value = row["Comment"].ToString()
			};
			return c;
		}

		private ITaskStatus CreateTaskStatusInstance(DataRow row)
		{
			TaskStatus t = new TaskStatus()
			{
				Id = Convert.ToInt32(row["Id"]),
				Title = row["Title"].ToString()
			};
			return t;
		}

		private ITask CreateTaskInstance(DataRow row)
		{
			Task t = new Task()
			{
				Id = Convert.ToInt32(row["Id"]),
				Title = row["Title"].ToString(),
				Number = row["Number"].ToString(),
				Steps = row["Steps"].ToString(),
				Background = row["Background"].ToString(),
				Description = row["Description"].ToString(),
				IsActive = Convert.ToBoolean(row["IsActive"]),
				Estimation = Convert.ToInt32(row["Estimation"]),
				Assignment = DataStorage.Instance.UserActions.GetUserById(Convert.ToInt32(row["AssignmentId"])),
				Status = GetTaskStatusById(Convert.ToInt32(row["StatusId"])),
				State = (StatusState)Convert.ToInt32(row["State"]),
				Prioroty = GetTaskPriorityById(Convert.ToInt32(row["PriorityId"])),
				Comments = GetCommentsListByTaskId(Convert.ToInt32(row["Id"]))
			};
			return t;
		}

	}
}