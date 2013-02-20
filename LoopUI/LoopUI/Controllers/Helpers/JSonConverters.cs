using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoopUI.Models;

namespace LoopUI.Helpers
{
	internal class JSonConverters
	{
		internal static object GetJSonForTasks(IEnumerable<Task> tasks, int page, int count, int pageCount)
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
							x.Status.Title,
							x.Prioroty.Title,
							x.Assignment.Login,
							x.IsActive.ToString()
					}
				})
			};
			return result;
		}

		internal static object GetJSonForRisks(IEnumerable<Risk> risks, int page, int count, int pageCount)
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
	}
}