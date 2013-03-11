using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoopUI.Controllers;
using Loop.Interfaces;

namespace LoopUI.Helpers
{
	/// <summary>
	/// contains methods related to json and jqgrid
	/// </summary>
	internal class JSonHelper
	{
		private JSonHelper() { }

		/// <summary>
		/// returns enumeration of risk types for jqgrid
		/// </summary>
		/// <returns></returns>
		internal static string GetAllRiskTypes()
		{
			string result = "";
			List<IRiskType> list = DataStorage.Instance.RiskActions.GetAllRiskTypes();
			int count = list.Count;
			foreach (IRiskType r in list)
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

		/// <summary>
		/// returns enumeration of all active users for jqgrid
		/// </summary>
		/// <returns></returns>
		internal static string GetAllActiveUsers()
		{
			string result = "";
			List<IUser> list = DataStorage.Instance.UserActions.GetActiveUsers();
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

		/// <summary>
		/// returns enumeration of task priorities for jqgrid
		/// </summary>
		/// <returns></returns>
		internal static string GetAllTaskPriorities()
		{
			string result = "";
			List<ITaskPriority> list = DataStorage.Instance.TaskActions.GetAllTaskPriorities();
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

		/// <summary>
		/// returns enumeration of task Statuses for jqgrid
		/// </summary>
		/// <returns></returns>
		internal static string GetAllTaskStatuses()
		{
			string result = "";
			List<ITaskStatus> list = DataStorage.Instance.TaskActions.GetAllTaskStatuses();
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

		internal static object GetJSonForTasks(IEnumerable<ITask> tasks, int page, int count, int pageCount)
		{
			var result = new
			{
				total = pageCount,
				page,
				records = count,
				rows = tasks.Select(x => new
				{
					id = x.Id,
					cell = new[]
					{
							x.Number,
							x.Title,
							x.Status.Id.ToString(),
							x.Prioroty.Id.ToString(),
							x.Assignment.Id.ToString(),
							x.IsActive.ToString()
					}
				})
			};
			return result;
		}

		internal static object GetJSonForRisks(IEnumerable<IRisk> risks, int page, int count, int pageCount)
		{
			var result = new
			{
				total = pageCount,
				page,
				records = count,
				rows = risks.Select(x => new
				{
					id = x.Id,
					cell = new[]
					{
							x.Title,
							x.Type.Title
					}
				})
			};
			return result;
		}

		internal static object GetJSonForSprints(IEnumerable<ISprint> sprints, int page, int count, int pageCount)
		{
			var result = new
			{
				total = pageCount,
				page,
				records = count,
				rows = sprints.Select(x => new
				{
					id = x.Id,
					cell = new[]
					{
							x.KeyedName,
							x.IsActive.ToString()
					}
				})
			};
			return result;
		}

		internal static object GetJSonForUsers(IEnumerable<IUser> users, int page, int count, int pageCount)
		{
			var result = new
			{
				total = pageCount,
				page,
				records = count,
				rows = users.Select(x => new
				{
					id = x.Id,
					cell = new[]
					{
							x.Name,
							x.Surname,
							x.Email,
							x.IsActive.ToString()
					}
				})
			};
			return result;
		}

		internal static object GetJSonForComments(IEnumerable<IComment> comments, int page, int count, int pageCount)
		{
			var result = new
			{
				total = pageCount,
				page,
				records = count,
				rows = comments.Select(x => new
				{
					id = x.Id,
					cell = new[]
					{
							x.Value
					}
				})
			};
			return result;
		}
	}
}