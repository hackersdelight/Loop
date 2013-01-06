using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Interfaces
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
namespace Loop
{
	public enum TaskType
	{
		Bug,
		Regression,
		Enhancement
	}
}
