using System.Web.Http;
using WebActivatorEx;
using HealthCareAPI;
using Swashbuckle.Application;
using System;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace HealthCareAPI
{
    public class SwaggerConfig
    {
        /// <summary>
        /// Config Swaager
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "HealthCareAPI");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi();
        }

        private static string GetXmlCommentsPath()
        {
            return String.Format(@"{0}\App_Data\XmlDocument.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }

    }
}
