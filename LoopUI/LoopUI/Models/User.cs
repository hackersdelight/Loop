using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;
using System.Web.Mvc;
using Loop.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace LoopUI.Models
{
	public class User : IUser
	{

		public int Id
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Login is required")]
		[StringLength(64, ErrorMessage = "Username shouldn't be longer than 64 characters.")]
		public string Login
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Password is required")]
		[StringLength(64, ErrorMessage = "Password shouldn't be longer than 64 characters.")]
		public string Password
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Email is required")]
		[StringLength(64, ErrorMessage = "Email must be under 64 characters")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Incorrect email format!")]
		public string Email
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Name is required")]
		[StringLength(64, ErrorMessage = "First name must be under 64 characters")]
		[RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Incorrect FirstName format.")]
		public string Name
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Surname is required")]
		[StringLength(64, ErrorMessage = "Surname must be under 64 characters")]
		[RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Incorrect Surname format.")]
		public string Surname
		{
			get;
			set;
		}

		public UserType UserType
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

	}
}