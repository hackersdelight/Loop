using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loop.Enumerations;

namespace Loop.Interfaces
{
	public interface ITaskStatus
	{
		int Id { get; }
		string Title { get; }
		StatusState State { get; }
	}
}
namespace Loop.Enumerations
{
	public enum StatusState
	{
		Pending = 1,
		InProgress = 2,
		Pause = 3,
		Complete = 4
	}
}