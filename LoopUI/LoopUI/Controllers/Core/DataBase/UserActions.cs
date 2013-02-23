using System;
using System.Collections.Generic;
using Loop.DatabaseConnection;
using Loop.Interfaces;
using LoopUI.Models;

namespace LoopUI.Controllers
{

	internal class UserActions : IUserActions
	{
		private IConnectToDB connection;

		internal UserActions(IConnectToDB connection)
		{
			this.connection = connection;
		}

		public List<IUser> GetAllUsers()
		{
			List<IUser> result = new List<IUser>();
			result.Add(new User() { Id = 1, Login = "sandra", Name = "alexandra", Surname = "panaryna", Email = "777@informatics.by", Password = "1", IsActive = true });
			result.Add(new User() { Id = 2, Login = "god", Name = "Jesus", Surname = "christ", Email = "god@informatics.by", Password = "god", IsActive = true });
			result.Add(new User() { Id = 3, Login = "test", Name = "Alesha", Surname = "Popovich", Email = "pop@informatics.by", Password = "pop", IsActive = false });
			return result;
		}

		public List<IUser> GetActiveUsers()
		{
			List<IUser> result = new List<IUser>();
			result.Add(new User() { Id = 1, Login = "sandra", Name = "alexandra", Surname = "panaryna", Email = "777@informatics.by", Password = "1", IsActive = true });
			result.Add(new User() { Id = 2, Login = "god", Name = "Jesus", Surname = "christ", Email = "god@informatics.by", Password = "god", IsActive = true });
			return result;
		}

		public void AddUser(IUser user)
		{
			throw new NotImplementedException();
		}

		public void DeleteUser(IUser user)
		{
			throw new NotImplementedException();
		}

		public void EditUser(IUser user)
		{
			throw new NotImplementedException();
		}

		public IUser GetUserById(int id)
		{
			throw new NotImplementedException();
		}
	}
}