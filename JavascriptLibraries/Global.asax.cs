using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace JavascriptLibraries
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}