using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using MVC_SHOP_2024_B.App_Start;
using System.Web.Http.WebHost;
using System.Web.SessionState;

namespace MVC_SHOP_2024_B
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			WebApiConfig.Register(GlobalConfiguration.Configuration);
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			GlobalConfiguration
				.Configuration
				.Formatters
				.JsonFormatter
				.MediaTypeMappings
				.Add(new System.Net.Http.Formatting.RequestHeaderMapping(
					"Accept",
					"text/html",
					StringComparison.InvariantCultureIgnoreCase,
					true,
					"application/json"
					));
		}
	}

	public class SessionHttpControllerHandler : HttpControllerHandler, IRequiresSessionState
	{
		public SessionHttpControllerHandler(RouteData routeData)
			 : base(routeData)
		{
		}
	}
	public class SessionHttpControllerRouteHandler : HttpControllerRouteHandler
	{
		protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			return new SessionHttpControllerHandler(requestContext.RouteData);
		}
	}
}
