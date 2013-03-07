using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopUI.Controllers;
using Loop.Interfaces;

namespace LoopUI.Models
{
	public class TaskStatusBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext,
				ModelBindingContext bindingContext)
		{
			int id = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Status.Id").AttemptedValue);
			ITaskStatus state = DataStorage.Instance.TaskActions.GetAllTaskStatuses().Find(x => x.Id == id);
			return state;
		}
	}

	public class TaskPriorityBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext,
				ModelBindingContext bindingContext)
		{
			int id = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Prioroty.Id").AttemptedValue);
			ITaskPriority prior = DataStorage.Instance.TaskActions.GetAllTaskPriorities().Find(x => x.Id == id);
			return prior;
		}
	}

	public class UserBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext,
				ModelBindingContext bindingContext)
		{
			int id = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Assignment.Id").AttemptedValue);
			IUser user = DataStorage.Instance.UserActions.GetUserById(id);
			return user;
		}
	}
}