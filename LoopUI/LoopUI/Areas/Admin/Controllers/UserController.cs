using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopUI.Models;
using LoopUI.Controllers;
using Loop.Interfaces;
using LoopUI.Helpers;

namespace LoopUI.Areas.Admin.Controllers
{
	public class UserController : BaseController
	{
		//
		// GET: /Admin/User/

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult GetUsers()
		{
			return Json(JSonHelper.GetJSonForUsers(CoreWrapper.Instance.GetAllUsers(), 1, 1, 1), JsonRequestBehavior.AllowGet);
		}

	}
}
