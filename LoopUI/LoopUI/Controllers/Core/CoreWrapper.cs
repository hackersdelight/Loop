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
		private Core core;
		private static CoreWrapper instance;

		private CoreWrapper()
		{ }

		private CoreWrapper(Core c)
		{
			core = c;
		}

		internal static CoreWrapper Instance 
		{
			get
			{
				if (instance == null)
				{
					instance = new CoreWrapper(new Core(DataStrorage.Instance));
				}
				return instance;
			}
		}

		internal bool UserExists(string login)
		{
			return DataStrorage.Instance.UserExists(login);
		}
	}
}