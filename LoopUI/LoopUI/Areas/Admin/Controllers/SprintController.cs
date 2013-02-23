﻿using System;
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
			return Json(JSonHelper.GetJSonForSprints(CoreWrapper.Instance.GetAllSprints(), 1, 1, 1), JsonRequestBehavior.AllowGet);
		}

	}
}
