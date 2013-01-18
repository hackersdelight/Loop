using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Core.Interfaces
{
	public interface ITask
	{
		int Id { get; }
		string Number { get;}
		string Title { get;}
		TaskType Type { get;}
		string Description { get; }
		string Steps { get; }
		string Background { get; }
		bool IsActive { get; }
		IUser Assignment { get; }
		int Estimation { get; }
		List<string> Comments { get; }
	}
}
namespace Loop.Core
{
	public enum TaskType
	{
		Bug,
		Regression
	}
}
