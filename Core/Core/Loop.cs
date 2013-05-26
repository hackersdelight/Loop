using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loop.Interfaces;
using Loop.Enumerations;

namespace Loop
{
	public class Core
	{
		public delegate void ChangeStateEventHandler(object sender, ChangeStateEventArgs e);
		public event ChangeStateEventHandler ChangeStateEvent;

		public delegate void ChangeStatusEventHandler(object sender, ChangeStatusEventArgs e);
		public event ChangeStatusEventHandler ChangeStatusEvent;

		public delegate void SprintCompletedEventHandler(object sender, SprintCompletedEventArgs e);
		public event SprintCompletedEventHandler SprintCompletedEvent;

		private IDataStorage storage;
		private Core()
		{ }

		public Core(IDataStorage dataStorage)
		{
			storage = dataStorage;
		}

		public List<ITask> GetTasksFromBTS(IDataProvider provider)
		{
			return null;
		}

		public void ExportTasksToDocument(List<ITask> tasks, IDataExporter exporter)
		{ }

		public void PromoteTaskToNextStatus(ITask task)
		{ }

		public void ChangeTaskState(ITask task, StatusState state)
		{ }

		public List<ChartPoint> GetBurnDownChartForSprint(ISprint sprint)
		{
			return null;
		}

		public List<ITask> AssignActiveTasksForSprint(ISprint sprint)
		{ return null; }

		public List<ITask> GetTasksForSprintByTimeLimit(ISprint sprint, TimeSpan timeLimit)
		{ return null; }
	}

}
