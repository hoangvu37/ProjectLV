using System.Configuration;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HealthCareAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //if (ConfigurationManager.AppSettings["EnableLogging"] == "true")
            //{
            //    GlobalConfiguration.Configuration.MessageHandlers.Add(New LoggingHandler());
            //}
            log4net.Config.XmlConfigurator.Configure();
            GlobalConfiguration.Configuration.Formatters.Add(new System.Net.Http.Formatting.JsonMediaTypeFormatter());
        }
    }
}
