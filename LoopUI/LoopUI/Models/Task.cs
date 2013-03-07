using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LoopUI.Models
{
	public class Task: ITask
	{
		public int Id
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Number is required")]
		[StringLength(20, ErrorMessage = "Number shouldn't be longer than 20 characters.")]
		public string Number
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Title is required")]
		[StringLength(64, ErrorMessage = "Title shouldn't be longer than 64 characters.")]
		public string Title
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Description is required")]
		public string Description
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Steps are required")]
		public string Steps
		{
			get;
			set;
		}

		public string Background
		{
			get;
			set;
		}

		public ITaskStatus Status
		{
			get;
			set;
		}

		public Loop.Enumerations.StatusState State
		{
			get;
			set;
		}

		public ITaskPriority Prioroty
		{
			get;
			set;
		}

		public IUser Assignment
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Description is required")]
		public int Estimation
		{
			get;
			set;
		}

		public List<string> Comments
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

	}
}