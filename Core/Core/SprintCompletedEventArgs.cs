using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loop.Interfaces;

namespace Loop
{
	public class SprintCompletedEventArgs: EventArgs
	{
		public SprintCompletedEventArgs(ISprint sprint) 
		{
			Sprint = sprint;
		}
		public ISprint Sprint { get; private set; } // readonly
	}
}
