using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoopUI.Areas.Admin.Controllers
{
	public class FeedbackController : BaseController
	{
		//
		// GET: /Admin/Feedback/

		public ActionResult Index()
		{
			return View();
		}

	}
}
