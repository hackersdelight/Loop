using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Interfaces
{
	public interface IUser
	{
		int Id { get; }
		string Login { get; }
		string Password { get; }

		string Name { get; }
		string Surname { get; }
		string Email { get; }
	}
}
