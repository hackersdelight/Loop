using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoopUI
{
	//[RequireHttps]
	public class BaseController : Controller
	{
		public ActionResult RedirectToInternalError()
		{
			return RedirectToAction("Http500", "Error");
		}

		public ActionResult RedirectToLogin()
		{
			return RedirectToAction("LogOff", "Login");
		}
	}
}
