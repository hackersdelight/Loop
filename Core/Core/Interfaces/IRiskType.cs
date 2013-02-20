using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Interfaces
{
	public interface IRiskType
	{
		int Id { get; }
		//per Sprint, per Task, per User etc
		string Title { get; }
	}
}
