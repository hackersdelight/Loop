using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LoopUI.Models
{
	public class Sprint : ISprint
	{
		public int Id
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Keyed name is required")]
		[StringLength(64, ErrorMessage = "Keyed name shouldn't be longer than 64 characters.")]
		public string KeyedName
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