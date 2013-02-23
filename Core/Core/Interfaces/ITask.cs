﻿using System.Collections.Generic;

namespace Loop.Interfaces
{
	public interface ITask
	{
		int Id { get; }
		string Number { get;}
		string Title { get;}
		//Planning, Required, Fixed etc
		ITaskStatus Status { get; }
		ITaskPriority Prioroty { get; }
		string Description { get; }
		string Steps { get; }
		string Background { get; }
		bool IsActive { get; }
		IUser Assignment { get; }
		int Estimation { get; }
		List<string> Comments { get; }
	}

	public interface IRegression : ITask
	{
		//the task which caused the regression
		ITask ParentTask { get; }
	}
}
