using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.WebHost;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace WebShop_2024_A
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
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
