using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopUI.Models;
using Loop.Interfaces;
using LoopUI.Controllers;
using LoopUI.Helpers;

namespace LoopUI.Areas.Admin.Controllers
{
	public class SprintController : BaseController
	{
		//
		// GET: /Admin/Sprint/

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult GetSprints()
		{
			List<ISprint> result = DataStorage.Instance.GetAllSprints();
			return Json(JSonConverters.GetJSonForSprints(result, 1, 1, 1), JsonRequestBehavior.AllowGet);
		}

	}
}
