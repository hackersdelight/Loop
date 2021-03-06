﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Loop.Interfaces;
using LoopUI.Models;

namespace LoopUI
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
					"Default", // Route name
					"{controller}/{action}/{id}", // URL with parameters
					new { controller = "Login", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
					new[] { "LoopUI.Controllers" }
			);

		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			ModelBinders.Binders.Add(typeof(ITaskStatus), new TaskStatusBinder());
			ModelBinders.Binders.Add(typeof(ITaskPriority), new TaskPriorityBinder());
			ModelBinders.Binders.Add(typeof(IUser), new UserBinder());
			ModelBinders.Binders.Add(typeof(IRiskType), new RiskTypeBinder());
			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		/*protected void Application_Error()
		{
			var exception = Server.GetLastError();
			var httpException = exception as HttpException;
			Response.Clear();
			Server.ClearError();
			var routeData = new RouteData();
			routeData.Values["controller"] = "Error";
			routeData.Values["action"] = "General";
			routeData.Values["exception"] = exception;
			Response.StatusCode = 500;
			if (httpException != null)
			{
				Response.StatusCode = httpException.GetHttpCode();
				switch (Response.StatusCode)
				{
					case 404:
						routeData.Values["action"] = "Http404";
						break;
					case 500:
						routeData.Values["action"] = "Http500";
						routeData.Values["exception"] = exception;
						break;
				}
			}

			Response.TrySkipIisCustomErrors = true;
			IController errorsController = new ErrorController();
			HttpContextWrapper wrapper = new HttpContextWrapper(Context);
			var rc = new RequestContext(wrapper, routeData);
			errorsController.Execute(rc);
		}*/
	}
}