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
			model.ActiveUsers = EnumerationHelper.GetActiveUsersEnumeration();
			model.TaskPriority = EnumerationHelper.GetTaskPriorityEnumeration();
			model.TaskStatus = EnumerationHelper.GetTaskStatusEnumeration();
			return View(model);
		}

		public ActionResult GetTasks()
		{
			List<ITask> result = DataStorage.Instance.GetAllTasks();
			//Json(JSonConverters.GetJsonForUsers(users, page, total, total / rows + 1), JsonRequestBehavior.AllowGet);
			return Json(JSonConverters.GetJSonForTasks(result, 1, 1, 1),JsonRequestBehavior.AllowGet);
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
			return RedirectToAction("Index");
		}

		public ActionResult AddTask()
		{
			return RedirectToAction("Index");
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
