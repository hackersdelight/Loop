using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopUI.Models;
using LoopUI.Helpers;

namespace LoopUI.Areas.Admin.Controllers
{
	public class RiskController : BaseController
	{
		//
		// GET: /Admin/Risk/

		public ActionResult Index()
		{
			return View(new List<Risk>());
		}

		public ActionResult GetRisks()
		{
			List<Risk> result = new List<Risk>();
			result.Add(new Risk()
			{
				Id = 1,
				Title = "Regression",
				Type = new RiskType() { Id = 1, Title ="Sprint"}
			});
			return Json(JSonConverters.GetJSonForRisks(result, 1, 1, 1), JsonRequestBehavior.AllowGet);
		}

	}
}
