using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Interfaces
{
	public interface ITaskStatus
	{
		int Id { get; }
		string Status { get; }
	}
}
