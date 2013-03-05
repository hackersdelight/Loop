using System.Web.Mvc;
using LoopUI.Controllers;
using LoopUI.Helpers;
using System;
using Loop.Interfaces;

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
				LoopUI.Models.User u = DataStorage.Instance.UserActions.GetUserById(id) as LoopUI.Models.User;
				u.Name = name;
				u.Surname = surname;
				u.Email = email;
				u.IsActive = Convert.ToBoolean(isactive);
				return EditUser(u);
			}
			else if (oper == "del")
			{
				return DeleteUser(id);
			}
			else
				return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult EditUser(LoopUI.Models.User user)
		{
			if (ModelState.IsValid)
			{
				DataStorage.Instance.UserActions.EditUser(user);
				return View("Index");
			}
			else
			{
				return View();
			}
		}

		[HttpGet]
		public ActionResult EditUser(int id)
		{
			return View(DataStorage.Instance.UserActions.GetUserById(id) as LoopUI.Models.User);
		}

		public ActionResult DeleteUser(int id)
		{
			DataStorage.Instance.UserActions.DeleteUser(id);
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
			if (IsValidLogin(user.Login) && ModelState.IsValid)
			{
				DataStorage.Instance.UserActions.AddUser(user);
				return View("Index");
			}
			else
				return View();
		}

		private bool IsValidLogin(string login)
		{
			if (login == null)
				return true;
			if (DataStorage.Instance.UserActions.IsExist(login.ToString()))
			{
				return false;
			}
			else return true;
		}
	}
}
