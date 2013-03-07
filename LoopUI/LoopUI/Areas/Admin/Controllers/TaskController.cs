using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopUI.Models;
using LoopUI.Helpers;
using Loop.Interfaces;
using LoopUI.Controllers;

namespace LoopUI.Areas.Admin.Controllers
{
	public class TaskController : BaseController
	{
		//
		// GET: /Admin/Task/

		public ActionResult Index()
		{
			EnumerationModel model = new EnumerationModel();
			model.ActiveUsers = JSonHelper.GetAllActiveUsers();
			model.TaskPriority = JSonHelper.GetAllTaskPriorities();
			model.TaskStatus = JSonHelper.GetAllTaskStatuses();
			return View(model);
		}

		public ActionResult GetTasks()
		{
			//Json(JSonConverters.GetJsonForUsers(users, page, total, total / rows + 1), JsonRequestBehavior.AllowGet);
			return Json(JSonHelper.GetJSonForTasks(CoreWrapper.Instance.GetAllTasks(), 1, 1, 1),JsonRequestBehavior.AllowGet);
		}

		public ActionResult TaskOperation(int id, string title, string priority, string assignment, string isactive, string oper)
		{
			if (oper == "edit")
			{
				return EditTask(id, title, priority, assignment, isactive);
			}
			else if (oper == "del")
			{
				return DeleteTask(id);
			}
			else
				return RedirectToAction("Index");
		}

		public ActionResult EditTask(int id, string title, string priority, string assignment, string isactive)
		{
			return RedirectToAction("Index");
		}

		public ActionResult DeleteTask(int id)
		{
			DataStorage.Instance.TaskActions.DeleteTask(id);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult AddTask()
		{
			ViewBag.TaskPriority = CoreWrapper.Instance.GetTaskPriorityList();
			ViewBag.TaskStatus = CoreWrapper.Instance.GetTaskStatusList();
			ViewBag.ActiveUsers = CoreWrapper.Instance.GetActiveUsers();
			Task t = new Task();
			t.Status = new TaskStatus();
			t.Prioroty = new TaskPriority();
			return View();
		}

		[HttpPost]
		public ActionResult AddTask(Task task, string comment)
		{
			//validation
			//adding of new task
			if (ModelState.IsValid)
			{
				if (!String.IsNullOrEmpty(comment))
				{
					task.Comments = new List<string>();
					task.Comments.Add(comment);
				}
				DataStorage.Instance.TaskActions.AddTask(task);
				return RedirectToAction("Index");
			}
			else return AddTask();
		}

		public ActionResult StartTask(int id)
		{
			return RedirectToAction("Index");
		}

		public ActionResult PauseTask(int id)
		{
			return RedirectToAction("Index");
		}

		public ActionResult PromoteTask(int id)
		{
			return RedirectToAction("Index");
		}

		public ActionResult ReturnTask(int id)
		{
			return RedirectToAction("Index");
		}
	}
}
