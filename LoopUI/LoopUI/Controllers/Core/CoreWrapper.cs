using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop;
using Loop.Interfaces;

namespace LoopUI.Controllers
{
	internal class CoreWrapper
	{
		private CoreWrapper()
		{ }

		private static Core instance;

		internal static Core Instance 
		{
			get
			{
				if (instance == null)
				{
					instance = new Core(DataStrorage.Instance);
				}
				return instance;
			}
		}
	}
}