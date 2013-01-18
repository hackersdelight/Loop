using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Core.Interfaces
{
	public interface ITask
	{
		string number { get;}
		string title { get;}
		TaskType type { get;}
		string description { get; }
		string steps { get; }
		string background { get; }
		List<string> comments { get; }
	}
}
namespace Loop.Core
{
	public enum TaskType
	{
		Bug,
		Regression,
		Enhancement
	}
}
