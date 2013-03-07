using System;
using System.Collections.Generic;
using Loop.DatabaseConnection;
using Loop.Interfaces;
using LoopUI.Models;
using System.Data;
using System.Data.SqlClient;
using Loop.Enumerations;

namespace LoopUI.Controllers
{

	internal class UserActions : IUserActions
	{
		private IConnectToDB connection;

		//work collection of users to prevent frequent usage of db
		private List<IUser> UserCollection;

		internal UserActions(IConnectToDB connection)
		{
			this.connection = connection;
		}

		public List<IUser> GetAllUsers()
		{
			if (UserCollection != null)
				return UserCollection;
			try
			{
				connection.OpenConnection();
				DbCommand command = new DbCommand("select * from Users");
				command.Type = DbCommand.DbCommandType.SELECT;
				DataSet set = connection.ExecSelect(command);
				UserCollection = new List<IUser>();
				foreach (DataRow row in set.Tables[0].Rows)
				{
					UserCollection.Add(CreateUserModelInstance(row));
				}
			}
			catch (Exception e)
			{
				Logger.Instance.WriteToLog(e.Message);
				throw;
			}
			finally
			{
				connection.CloseConnection();
			}
			return UserCollection;
		}

		public List<IUser> GetActiveUsers()
		{
			if (UserCollection == null)
				GetAllUsers();
			if (UserCollection.Exists(x => x.IsActive == true))
			{
				return UserCollection.FindAll(x => x.IsActive == true);
			}
			else
				return new List<IUser>();
		}

		public void AddUser(IUser user)
		{
			try
			{
				connection.OpenConnection();
				DbCommand command = new DbCommand("INSERT INTO Users (Login, Password, Name, Surname, Email, IsActive, UserType) VALUES (@login, @password, @name, @surname, @email, @isactive, @usertype);");
				command.Parameters = new SqlParameter[7];
				command.Parameters[0] = new SqlParameter("login", user.Login);
				command.Parameters[1] = new SqlParameter("password", user.Password);
				command.Parameters[2] = new SqlParameter("name", user.Name);
				command.Parameters[3] = new SqlParameter("surname", user.Surname);
				command.Parameters[4] = new SqlParameter("email", user.Email);
				command.Parameters[5] = new SqlParameter("isactive", user.IsActive.ToString());
				command.Parameters[6] = new SqlParameter("usertype", (int)user.UserType);
				command.Type = DbCommand.DbCommandType.INSERT;
				connection.ExecNonQuery(command);
				if (UserCollection != null)
				{
					UserCollection.Add(user);
				}
			}
			catch (Exception e)
			{
				Logger.Instance.WriteToLog(e.Message);
				throw;
			}
			finally
			{
				connection.CloseConnection();
			}
		}

		public void DeleteUser(int id)
		{
			try
			{
				connection.OpenConnection();
				DbCommand command = new DbCommand("DELETE FROM Users WHERE Id = @id;");
				command.Parameters = new SqlParameter[1];
				command.Parameters[0] = new SqlParameter("id", id);
				command.Type = DbCommand.DbCommandType.DELETE;
				connection.ExecNonQuery(command);
				if (UserCollection != null)
				{
					UserCollection.Remove(UserCollection.Find(x => x.Id == id));
				}
			}
			catch (Exception e)
			{
				Logger.Instance.WriteToLog(e.Message);
				throw;
			}
			finally
			{
				connection.CloseConnection();
			}
		}

		public void EditUser(IUser user)
		{
			try
			{
				connection.OpenConnection();
				DbCommand command = new DbCommand("UPDATE Users SET Login = @login, Password = @password, Name = @name, Surname = @surname, Email = @email, IsActive = @isactive, UserType = @usertype WHERE Id = @id;");
				command.Parameters = new SqlParameter[8];
				command.Parameters[0] = new SqlParameter("id", user.Id);
				command.Parameters[1] = new SqlParameter("login", user.Login);
				command.Parameters[2] = new SqlParameter("password", user.Password);
				command.Parameters[3] = new SqlParameter("name", user.Name);
				command.Parameters[4] = new SqlParameter("surname", user.Surname);
				command.Parameters[5] = new SqlParameter("email", user.Email);
				command.Parameters[6] = new SqlParameter("isactive", user.IsActive.ToString());
				command.Parameters[7] = new SqlParameter("usertype", (int)user.UserType);
				command.Type = DbCommand.DbCommandType.UPDATE;
				connection.ExecNonQuery(command);
				if (UserCollection != null)
				{
					//update value in Collection
					UserCollection.Remove(UserCollection.Find(x => x.Id == user.Id));
					UserCollection.Add(user);
				}
			}
			catch (Exception e)
			{
				Logger.Instance.WriteToLog(e.Message);
				throw;
			}
			finally
			{
				connection.CloseConnection();
			}
		}

		public IUser GetUserById(int id)
		{
			if (UserCollection == null)
				GetAllUsers();
			if (UserCollection.Exists(x => x.Id == id))
			{
				return UserCollection.Find(x => x.Id == id);
			}
			else return null;
		}

		public bool IsExist(string login)
		{
			if (UserCollection == null)
				GetAllUsers();
			return UserCollection.Exists(x => x.Login == login);
		}

		private IUser CreateUserModelInstance(DataRow row)
		{
			User u = new User()
			{
				Id = Convert.ToInt32(row["Id"]),
				Login = row["Login"].ToString(),
				Password = row["Password"].ToString(),
				Name = row["Name"].ToString(),
				Surname = row["Surname"].ToString(),
				Email = row["Email"].ToString(),
				IsActive = Convert.ToBoolean(row["IsActive"]),
				UserType = (UserType)Enum.Parse(typeof(UserType), row["UserType"].ToString())
			};
			return u;
		}
	}
}