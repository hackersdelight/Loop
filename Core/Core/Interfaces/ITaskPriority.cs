using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Interfaces
{
	public interface ITaskPriority
	{
		int Id { get; }
		//display name of the priority
		string Title { get; }
		//weight of the priority
		int Value { get; }
	}
}
