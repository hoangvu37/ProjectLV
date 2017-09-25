using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using HealthAPI.Providers;
using Microsoft.Owin.Cors;
using System.Web;
using Swashbuckle.Application;
using Swashbuckle.SwaggerUi;
using Swashbuckle.Swagger;

[assembly: OwinStartup(typeof(HealthCareAPI.Startup))]
namespace HealthCareAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);
            app.UseCors(CorsOptions.AllowAll);
            WebApiConfig.Register(config);
            app.UseWebApi(config);
            app.MapSignalR();

            //LV.Poco.LVHubsHelper.RunSyncDB();
        }

    
        private static void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan =TimeSpan.FromMinutes(20000),
                Provider = new LVAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
        
    }
}
