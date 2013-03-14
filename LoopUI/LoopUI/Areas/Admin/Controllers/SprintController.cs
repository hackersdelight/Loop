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

		SprintActions sprintActions = DataStorage.Instance.SprintActions as SprintActions;

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult GetSprints()
		{
			return Json(JSonHelper.GetJSonForSprints(CoreWrapper.Instance.GetAllSprints(), 1, 1, 1), JsonRequestBehavior.AllowGet);
		}

		public ActionResult SprintOperation(int id, string keyedname, string isactive, string oper)
		{
			if (oper == "edit")
			{
				Sprint s = sprintActions.GetSprintById(id) as Sprint;
				s.KeyedName = keyedname;
				return EditSprint(s);
			}
			else if (oper == "del")
			{
				return DeleteSprint(id);
			}
			else return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult AddSprint()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddSprint(Sprint sprint)
		{
			if (ModelState.IsValid)
			{
				sprintActions.AddSprint(sprint);
				return View("Index");
			}
			return View();
		}

		[HttpGet]
		public ActionResult EditSprint(int id)
		{
			return View(sprintActions.GetSprintById(id) as Sprint);
		}

		[HttpPost]
		public ActionResult EditSprint(Sprint sprint)
		{
			if (ModelState.IsValid)
			{
				sprintActions.EditSprint(sprint);
				return View("Index");
			}
			return View();
		}

		public ActionResult DeleteSprint(int id)
		{
			sprintActions.DeleteSprint(id);
			return View("Index");
		}
	}
}
