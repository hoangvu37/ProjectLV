using AutoMapper;
using HealthCareAPI.App_Start;
using HealthCareAPI.BO;
using HealthCareAPI.Resolvers;
using HealthCareAPI.Services;
using LV.Poco;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;

namespace HealthCareAPI
{
    public static class WebApiConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            LVHubsHelper.RunSyncDB();
            RegisterDependencyInjection(config);

        }


        private static void RegisterDependencyInjection(HttpConfiguration config)
        {
            var container = new UnityContainer();

            container.RegisterTypes(AllClasses.FromLoadedAssemblies(),
                                    WithMappings.FromMatchingInterface,
                                    WithName.Default);

            container.RegisterType<CommonBO, CommonBO>();
            container.RegisterType<CommonService, CommonService>();

           var mapperConfiguration = new MapperConfiguration(
               cfg => cfg.AddProfile<AutoMapperConfig.MappingProfile>());
            var mapper = mapperConfiguration.CreateMapper();
            container.RegisterInstance(mapper);

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
