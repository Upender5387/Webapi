using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPIDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            config.EnableCors();
            // Web API configuration and services
            //config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();
            
            //config.EnableCors(new EnableCorsAttribute("*"));
            config.Routes.MapHttpRoute(
                name: "Get",
                routeTemplate: "api/home/Get",
                defaults: new { Controller = "home", Action = "Get" }
            );
            config.Routes.MapHttpRoute(
               name: "insert",
                routeTemplate: "api/home/insert",
                defaults: new { Controller = "home", Action = "insert" }
            );
            config.Routes.MapHttpRoute(
              name: "Update",
               routeTemplate: "api/home/Update",
               defaults: new { Controller = "home", Action = "Update" }
           );
            config.Routes.MapHttpRoute(
                name: "Get2",
                routeTemplate: "api/Class2/Get2",
                defaults: new { Controller = "Class2", Action = "Get2" }
            );
            config.Routes.MapHttpRoute(
               name: "insert1",
                routeTemplate: "api/Class2/insert1",
                defaults: new { Controller = "Class2", Action = "insert1" }
            );
            config.Routes.MapHttpRoute(
              name: "Update1",
               routeTemplate: "api/Class2/Update1",
               defaults: new { Controller = "Class2", Action = "Update1" }
           );
            config.Routes.MapHttpRoute(
             name: "Delete",
              routeTemplate: "api/Class2/Delete",
              defaults: new { Controller = "Class2", Action = "Delete" }
          );
            config.Routes.MapHttpRoute(
             name: "Login",
              routeTemplate: "api/Class2/Login",
              defaults: new { Controller = "Class2", Action = "Login" }
          );
        }
    }
}
