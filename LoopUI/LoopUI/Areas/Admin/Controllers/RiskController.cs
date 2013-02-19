using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopUI.Models;

namespace LoopUI.Areas.Admin.Controllers
{
	public class RiskController : Controller
	{
		//
		// GET: /Admin/Risk/

		public ActionResult Index()
		{
			return View(new List<Risk>());
		}

	}
}
