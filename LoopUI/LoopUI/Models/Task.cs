using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;

namespace Models
{
	public class Task: ITask
	{
		public IUser Assignment
		{
			get;
			set;
		}

		public string Background
		{
			get;
			set;
		}

		public List<string> Comments
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public int Estimation
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

		public string Number
		{
			get;
			set;
		}

		public string Steps
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public Loop.TaskType Type
		{
			get;
			set;
		}
	}
}