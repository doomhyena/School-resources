using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MVC_SHOP_2024_B.App_Start
{
	public class WebApiConfig
	{
		public static void Register(HttpConfiguration configuration)
		{
			//configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
			//	 new { id = RouteParameter.Optional });
		}
	}
}