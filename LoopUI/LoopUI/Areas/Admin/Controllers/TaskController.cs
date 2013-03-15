using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopUI.Models;
using LoopUI.Helpers;
using Loop.Interfaces;
using LoopUI.Controllers;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Web.Routing;

namespace LoopUI.Areas.Admin.Controllers
{
	public class TaskController : BaseController
	{
		//
		// GET: /Admin/Task/

		private TaskActions taskActions = DataStorage.Instance.TaskActions as TaskActions;

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
			return Json(JSonHelper.GetJSonForTasks(CoreWrapper.Instance.GetAllTasks(), 1, 1, 1), JsonRequestBehavior.AllowGet);
		}

		public ActionResult GetTaskComments(int id)
		{
			return Json(JSonHelper.GetJSonForComments(taskActions.GetCommentsListByTaskId(id), 1, 1, 1), JsonRequestBehavior.AllowGet);
		}

		public ActionResult CommentOperation(int? id, string comment, string oper)
		{
			if (oper == "edit")
			{
				Comment c = new Comment(Convert.ToInt32(id), comment);
				return EditComment(c);
			}
			else if (oper == "del")
			{
				return DeleteComment(Convert.ToInt32(id));
			}
			else if (oper == "add")
			{
				return AddComment(Convert.ToInt32(RouteData.Values["id"]), comment);
			}
			else return RedirectToAction("EditTask");
		}

		public ActionResult TaskOperation(int id, string title, int? priority, int? assignment, string isactive, string oper)
		{
			if (oper == "edit")
			{
				Task t = taskActions.GetTaskById(id) as Models.Task;
				t.Title = title;
				t.Prioroty =  new TaskPriority() { Id = Convert.ToInt32(priority) };
				t.Assignment = new LoopUI.Models.User() { Id = Convert.ToInt32(assignment) };
				return EditTask(t);
			}
			else if (oper == "del")
			{
				return DeleteTask(id);
			}
			else
				return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult EditTask(int id)
		{
			ViewBag.TaskPriority = CoreWrapper.Instance.GetTaskPriorityList();
			ViewBag.TaskStatus = CoreWrapper.Instance.GetTaskStatusList();
			ViewBag.ActiveUsers = CoreWrapper.Instance.GetActiveUsers();
			return View(taskActions.GetTaskById(id) as Task);
		}

		[HttpPost]
		public ActionResult EditTask(Task task)
		{
			if (ModelState.IsValid)
			{
				taskActions.EditTask(task);
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}

		[HttpPost]
		public ActionResult EditComment(Comment comment)
		{
			taskActions.EditComment(comment);
			return View("EditTask");
		}

		public ActionResult DeleteComment(int id)
		{
			taskActions.DeleteComment(id);
			return View("EditTask");
		}

		public ActionResult AddComment(int taskId, string comment)
		{
			taskActions.AddComment(Convert.ToInt32(taskId), Convert.ToString(comment));
			return View("EditTask");
		}

		public ActionResult DeleteTask(int id)
		{
			taskActions.DeleteTask(id);
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
					task.Comments = new List<IComment>();
					task.Comments.Add(new Comment(comment));
				}
				taskActions.AddTask(task);
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
