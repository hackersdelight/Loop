using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoopUI.Controllers;
using Loop.Interfaces;

namespace LoopUI.Helpers
{
	internal class EnumerationHelper
	{
		internal static string GetRiskTypeEnumeration()
		{
			string result = "";
			List<IRiskType> list = DataStorage.Instance.GetAllRiskTypes();
			int count = list.Count;
			foreach (IRiskType r in list)
			{
				result += String.Format("{0}:{1}",r.Id, r.Title);
				count--;
				if (count != 0)
				{
					result += ";";
				}
			}
			return result;
		}

		internal static string GetTaskStatusEnumeration()
		{
			string result = "";
			List<ITaskStatus> list = DataStorage.Instance.GetAllTaskStatuses();
			int count = list.Count;
			foreach (ITaskStatus r in list)
			{
				result += String.Format("{0}:{1}", r.Id, r.Title);
				count--;
				if (count != 0)
				{
					result += ";";
				}
			}
			return result;
		}

		internal static string GetTaskPriorityEnumeration()
		{
			string result = "";
			List<ITaskPriority> list = DataStorage.Instance.GetAllTaskPriorities();
			int count = list.Count;
			foreach (ITaskPriority r in list)
			{
				result += String.Format("{0}:{1}", r.Id, r.Title);
				count--;
				if (count != 0)
				{
					result += ";";
				}
			}
			return result;
		}

		internal static string GetActiveUsersEnumeration()
		{
			string result = "";
			List<IUser> list = DataStorage.Instance.GetActiveUsers();
			int count = list.Count;
			foreach (IUser r in list)
			{
				result += String.Format("{0}:{1}", r.Id, r.Login);
				count--;
				if (count != 0)
				{
					result += ";";
				}
			}
			return result;
		}
	}
}