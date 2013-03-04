using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using LoopUI.Controllers;

namespace LoopUI.Models.Validators
{
	public class UniqueUsername:ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value == null)
				return true;
			if (DataStorage.Instance.UserActions.IsExist(value.ToString()))
			{
				return false;
			}
			else return true;
		}
	}
}