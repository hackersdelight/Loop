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
		RiskActions riskActions = DataStorage.Instance.RiskActions as RiskActions;

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

		public ActionResult RiskOperation(int id, string title, int type, string oper)
		{
			if (oper == "edit")
			{
				Risk s = riskActions.GetRiskById(id) as Risk;
				s.Title = title;
				s.Type = new RiskType() { Id = id };
				return EditRisk(s);
			}
			else if (oper == "del")
			{
				return DeleteRisk(id);
			}
			else return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult AddRisk()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddRisk(Risk risk)
		{
			if (ModelState.IsValid)
			{
				riskActions.AddRisk(risk);
				return View("Index");
			}
			return View();
		}

		[HttpGet]
		public ActionResult EditRisk(int id)
		{
			return View(riskActions.GetRiskById(id) as Risk);
		}

		[HttpPost]
		public ActionResult EditRisk(Risk risk)
		{
			if (ModelState.IsValid)
			{
				riskActions.EditRisk(risk);
				return View("Index");
			}
			return View();
		}

		public ActionResult DeleteRisk(int id)
		{
			riskActions.DeleteRisk(id);
			return View("Index");
		}
	}
}
