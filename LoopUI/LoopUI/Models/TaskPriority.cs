using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;

namespace LoopUI.Models
{
	public class TaskPriority: ITaskPriority
	{
		public int Id
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public int Value
		{
			get;
			set;
		}
	}
}