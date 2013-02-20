using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Interfaces
{
	public interface IRisk
	{
		int Id { get; }
		string Title { get; }
		IRiskType Type { get; }
	}
}
