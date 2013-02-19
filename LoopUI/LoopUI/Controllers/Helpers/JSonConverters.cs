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
							x.Status.Status,
							x.IsActive.ToString()
					}
				})
			};
			return result;
		}
	}
}