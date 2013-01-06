using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loop.Interfaces;

namespace Loop.Models
{
	public class Task : ITask
	{
		public string number { get; private set; }
		public string title { get; private set; }
		public TaskType type { get; private set; }
		public string description { get; private set; }
		public string steps { get; private set; }
		public string background { get; private set; }
		public List<string> comments { get; private set; }

		public Task(string number, string title, TaskType type, string descr, string steps, string bg, List<string> comments)
		{
			this.number = number;
			this.title = title;
			this.type = type;
			this.description = descr;
			this.steps = steps;
			this.background = bg;
			this.comments = comments;
		}

		public string GetTaskTitle()
		{
			return this.number + " - " + this.title;
		}

		public string GetTaskComments()
		{
			string result = "";
			foreach (string comment in comments)
			{
				result += comment + "\n";
			}
			return result;
		}
	}
}
