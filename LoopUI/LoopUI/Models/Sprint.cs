using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;

namespace LoopUI.Models
{
	public class Sprint : ISprint
	{
		public int Id
		{
			get;
			set;
		}

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