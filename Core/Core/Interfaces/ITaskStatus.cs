using Loop.Enumerations;

namespace Loop.Interfaces
{
	public interface ITaskStatus
	{
		int Id { get; }
		string Title { get; }
	}
}
namespace Loop.Enumerations
{
	public enum StatusState
	{
		Pending = 1,
		InProgress = 2,
		Pause = 3,
		Complete = 4
	}
}