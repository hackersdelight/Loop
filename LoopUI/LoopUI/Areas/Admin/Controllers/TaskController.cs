using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace LoopUI.Areas.Admin.Controllers
{
	public class TaskController : Controller
	{
		//
		// GET: /Admin/Task/

		public ActionResult Index()
		{
			List<Task> result = new List<Task>();
			result.Add(new Task()
			{
				Id = 1,
				Number = "IR-1010100",
				Title = "Test",
				Status = new TaskStatus() { Id = 1, Status = "Planning" },
				IsActive = false
				//todo: add assignment here
			});
			return View(result);
		}
	}
}
