using System;
using System.Collections.Generic;
using Loop.DatabaseConnection;
using Loop.Interfaces;
using LoopUI.Models;

namespace LoopUI.Controllers
{
	internal class DataStorage : IDataStorage
	{
		private DataStorage()
		{
			connection = new ConnectToMsSql();
			taskActions = new TaskActions(connection);
			userActions = new UserActions(connection);
			riskActions = new RiskActions(connection);
			sprintActions = new SprintActions(connection);
		}

		private ConnectToMsSql connection;
		private ITaskActions taskActions;
		private IUserActions userActions;
		private IRiskActions riskActions;
		private ISprintActions sprintActions;

		private static DataStorage instance = new DataStorage();

		internal static DataStorage Instance
		{
			get
			{
				return instance;
			}
		}

		public ITaskActions TaskActions
		{
			get { return taskActions; }
		}

		public IUserActions UserActions
		{
			get 
			{ 
				return userActions; 
			}
		}

		public IRiskActions RiskActions
		{
			get { return riskActions; }
		}

		public ISprintActions SprintActions
		{
			get { return sprintActions; }
		}
	}
}