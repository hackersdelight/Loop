using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopUI.Models;
using LoopUI.Helpers;

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
			List<Task> result = new List<Task>();
			result.Add(new Task()
			{
				Id = 1,
				Number = "IR-1010100",
				Title = "Test",
				Status = new TaskStatus() { Id = 1, Title = "Planning" },
				Prioroty = new TaskPriority() {Id = 1, Title = "1", Value = 5},
				Assignment = new LoopUI.Models.User() {Id = 1, Name = "alexandra", Surname = "panaryna", Login ="sandra"},
				IsActive = true
			});
			//Json(JSonConverters.GetJsonForUsers(users, page, total, total / rows + 1), JsonRequestBehavior.AllowGet);
			return Json(JSonConverters.GetJSonForTasks(result, 1, 1, 1),JsonRequestBehavior.AllowGet);
		}
	}
}
