using System.Web.Mvc;
using LoopUI.Controllers;
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

		public ActionResult UserOperation(int id, string name, string surname, string email, string isactive, string oper)
		{
			if (oper == "edit")
			{
				return EditUser(id, name, surname, email, isactive);
			}
			else if (oper == "del")
			{
				return DeleteUser(id);
			}
			else
				return RedirectToAction("Index");
		}

		public ActionResult EditUser(int id, string name, string surname, string email, string isactive)
		{
			return View("Index");
		}

		public ActionResult DeleteUser(int id)
		{
			return View("Index");
		}

		[HttpGet]
		public ActionResult AddUser()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddUser(LoopUI.Models.User user)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			//DataStorage.Instance.UserActions.AddUser(user);
			return View();
		}
	}
}
