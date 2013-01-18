﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loop.Core.Interfaces
{
	public interface IDataStorage
	{
		void AddTask(ITask task);
		void DeleteTask(ITask task);
		void EditTask(ITask task);
		ITask GetTaskById(int id);

		void AddRisk(IRisk risk);
		void DeleteRisk(IRisk risk);
		void EditRisk(IRisk risk);
		IRisk GetRiskById(int id);

		void AddUser(IUser user);
		void DeleteUser(IUser user);
		void EditUser(IUser user);
		IUser GetUserById(int id);

		void AddSprint(ISprint sprint);
		void DeleteSprint(ISprint sprint);
		void EditSprint(ISprint sprint);
		ISprint GetSprintById(int id);
	}
}
