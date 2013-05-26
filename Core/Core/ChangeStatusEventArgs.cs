using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loop.Interfaces;

namespace Loop
{
	public class ChangeStatusEventArgs: EventArgs
	{
		public ChangeStatusEventArgs(ITask task, ITaskStatus status) 
		{
			Task = task;
			NewStatus = status;
		}
		public ITaskStatus NewStatus { get; private set; } // readonly
		public ITask Task { get; private set; } // readonly
	}
}
