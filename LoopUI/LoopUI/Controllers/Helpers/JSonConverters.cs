using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoopUI.Models;
using Loop.Interfaces;

namespace LoopUI.Helpers
{
	internal class JSonConverters
	{
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
	}
}