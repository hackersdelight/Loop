using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Interfaces
{
	public interface ISprint
	{
		int Id { get; }
		string KeyedName { get; }
		bool IsActive { get; }
	}
}
