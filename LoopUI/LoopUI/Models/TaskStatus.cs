using Loop.Interfaces;

namespace LoopUI.Models
{
	public class TaskStatus: ITaskStatus
	{
		public int Id
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}
	}
}