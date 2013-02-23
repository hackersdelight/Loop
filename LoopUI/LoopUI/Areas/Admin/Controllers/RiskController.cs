using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopUI.Models;
using LoopUI.Helpers;
using LoopUI.Controllers;
using Loop.Interfaces;

namespace LoopUI.Areas.Admin.Controllers
{
	public class RiskController : BaseController
	{
		//
		// GET: /Admin/Risk/

		public ActionResult Index()
		{
			EnumerationModel model = new EnumerationModel();
			model.RiskType = JSonHelper.GetAllRiskTypes();
			return View(model);
		}

		public ActionResult GetRisks()
		{
			return Json(JSonHelper.GetJSonForRisks(CoreWrapper.Instance.GetAllRisks(), 1, 1, 1), JsonRequestBehavior.AllowGet);
		}

	}
}
