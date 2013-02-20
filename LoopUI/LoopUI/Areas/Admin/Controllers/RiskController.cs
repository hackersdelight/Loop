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
			model.RiskType = EnumerationHelper.GetRiskTypeEnumeration();
			return View(model);
		}

		public ActionResult GetRisks()
		{
			List<IRisk> result = DataStorage.Instance.GetAllRisks();
			return Json(JSonConverters.GetJSonForRisks(result, 1, 1, 1), JsonRequestBehavior.AllowGet);
		}

	}
}
