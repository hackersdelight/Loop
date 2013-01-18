using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Core.Interfaces;

namespace LoopUI.Models
{
	public class User: IUser
	{
		public string Email
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public string Login
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public string Surname
		{
			get;
			set;
		}
	}
}