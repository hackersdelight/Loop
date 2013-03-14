using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LoopUI.Models
{
	public class Risk: IRisk
	{
		public int Id
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

		public IRiskType Type
		{
			get;
			set;
		}
	}
}