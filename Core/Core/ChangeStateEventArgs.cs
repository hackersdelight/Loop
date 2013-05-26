using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loop.Enumerations;
using Loop.Interfaces;

namespace Loop
{
	public class ChangeStateEventArgs: EventArgs
	{
		public ChangeStateEventArgs(ITask task, StatusState state) 
		{
			Task = task;
			NewState = state;
		}
		public StatusState NewState { get; private set; } // readonly
		public ITask Task { get; private set; } // readonly
	}
}
