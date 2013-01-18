using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Core.Interfaces;

namespace LoopUI.Models
{
	public class Risk: IRisk
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
	}
}