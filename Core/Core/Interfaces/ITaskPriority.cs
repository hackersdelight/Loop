
namespace Loop.Interfaces
{
	public interface ITaskPriority
	{
		int Id { get; }
		//display name of the priority
		string Title { get; }
		//weight of the priority
		int Value { get; }
	}
}
