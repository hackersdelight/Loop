using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;

namespace LoopUI.Models
{
	public class TaskStatus: ITaskStatus
	{
		public int Id
		{
			get;
			set;
		}

		public string Status
		{
			get;
			set;
		}
	}
}