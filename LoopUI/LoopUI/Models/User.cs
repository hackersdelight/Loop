using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;
using System.Web.Mvc;
using Loop.Enumerations;
using System.ComponentModel.DataAnnotations;
using LoopUI.Models.Validators;

namespace LoopUI.Models
{
	public class User : IUser
	{
		[Required(ErrorMessage = "Email is required")]
		[StringLength(64, ErrorMessage = "Email must be under 64 characters")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Incorrect email format!")]
		public string Email
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		[UniqueUsername(ErrorMessage = "Username already exists. Create a new one.")]
		[StringLength(64, ErrorMessage = "Username shouldn't be longer than 64 characters.")]
		public string Login
		{
			get;
			set;
		}

		[StringLength(64, ErrorMessage = "First name must be under 64 characters")]
		[RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Incorrect FirstName format.")]
		public string Name
		{
			get;
			set;
		}

		[StringLength(64, ErrorMessage = "Password shouldn't be longer than 64 characters.")]
		public string Password
		{
			get;
			set;
		}

		[StringLength(64, ErrorMessage = "Surname must be under 64 characters")]
		[RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Incorrect Surname format.")]
		public string Surname
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}


		public UserType UserType
		{
			get;
			set;
		}
	}
}