using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop;
using Loop.Interfaces;
using System.Web.Mvc;
using System.ComponentModel;

namespace LoopUI.Controllers
{
	//Class provides all functions that are needed for LoopUI
	internal class CoreWrapper
	{
		private Core core;
		private static CoreWrapper instance = new CoreWrapper(new Core(DataStorage.Instance));

		private CoreWrapper()
		{ }

		private CoreWrapper(Core c)
		{
			core = c;
		}

		internal static CoreWrapper Instance
		{
			get
			{
				return instance;
			}
		}

		/// <summary>
		/// returns List of all risks
		/// </summary>
		/// <returns></returns>
		internal List<IRisk> GetAllRisks()
		{
			return DataStorage.Instance.RiskActions.GetAllRisks();
		}

		/// <summary>
		/// return List of all tasks
		/// </summary>
		/// <returns></returns>
		internal List<ITask> GetAllTasks()
		{
			return DataStorage.Instance.TaskActions.GetAllTasks();
		}

		/// <summary>
		/// return List of all users
		/// </summary>
		/// <returns></returns>
		internal List<IUser> GetAllUsers()
		{
			return DataStorage.Instance.UserActions.GetAllUsers();
		}

		/// <summary>
		/// return List of all sprints
		/// </summary>
		/// <returns></returns>
		internal List<ISprint> GetAllSprints()
		{
			return DataStorage.Instance.SprintActions.GetAllSprints();
		}
	}
	public static class EnumExtensions
	{
		public static IEnumerable<SelectListItem> ToSelectList(this Enum enumValue)
		{
			return from Enum e in Enum.GetValues(enumValue.GetType())
						 select new SelectListItem
						 {
							 Selected = e.Equals(enumValue),
							 Text = e.ToDescription(),
							 Value = e.ToString()
						 };
		}

		public static string ToDescription(this Enum value)
		{
			var attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
			return attributes.Length > 0 ? attributes[0].Description : value.ToString();
		}
	}
}