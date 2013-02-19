using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopUI.Models;

namespace LoopUI.Areas.Admin.Controllers
{
	public class SprintController : BaseController
	{
		//
		// GET: /Admin/Sprint/

		public ActionResult Index()
		{
			return View(new List<Sprint>());
		}

	}
}
