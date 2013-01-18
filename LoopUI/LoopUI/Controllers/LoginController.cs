using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace LoopUI.Controllers
{
	public class LoginController : Controller
	{
		//
		// GET: /Login/
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(User user, Captcha captcha)
		{
			//Sessin contains expected captcha value.
			if (captcha == null || Session["Captcha"] == null || Session["Captcha"].ToString() != captcha.CaptchaResult)
			{
				ModelState.AddModelError("Captcha", "Wrong captcha value. Try again.");
				//display error and generate a new captcha
				return View();
			}
			//check user here!
			//if (CoreWrapper.Instance.UserExists(user.Login))
			//{
				return RedirectToAction("Index", "Admin");
			//}
			//return View();
		}
	}
}
