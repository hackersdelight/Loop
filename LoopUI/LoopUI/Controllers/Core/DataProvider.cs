using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;

namespace LoopUI.Controllers
{
	internal class DataProvider: IDataProvider
	{
		private DataProvider()
		{}

		private static DataProvider instance;

		internal static DataProvider Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DataProvider();
				}
				return instance;
			}
		}

		public List<ITask> ImportData()
		{
			throw new NotImplementedException();
		}
	}
}