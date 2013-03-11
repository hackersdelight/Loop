using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;

namespace LoopUI.Models
{
	public class Comment: IComment
	{
		internal Comment()
		{ }

		internal Comment(int id, string comment)
		{
			this.Value = comment;
			this.Id = id;
		}

		internal Comment(string comment)
		{
			this.Value = comment;
		}

		public int Id
		{
			get;
			set;
		}

		public string Value
		{
			get;
			set;
		}
	}
}