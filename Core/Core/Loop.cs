using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loop.Core.Interfaces;

namespace Loop.Core
{
	public class Loop
	{
		private IDataStorage storage;
		public Loop(IDataStorage dataStorage)
		{
			storage = dataStorage;
		}
	}
}
