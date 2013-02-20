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
			return View();
		}

		public ActionResult GetTasks()
		{
			List<ITask> result = DataStorage.Instance.GetAllTasks();
			//Json(JSonConverters.GetJsonForUsers(users, page, total, total / rows + 1), JsonRequestBehavior.AllowGet);
			return Json(JSonConverters.GetJSonForTasks(result, 1, 1, 1),JsonRequestBehavior.AllowGet);
		}
	}
}
