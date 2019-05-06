using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Agl.Mvc.Ui.Controllers;
using Agl.Services;
using Autofac;
using Autofac.Integration.Mvc;
using System.Configuration;

namespace Agl.Mvc.Ui
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureDIContainer();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);           
        }

        private void ConfigureDIContainer()
        {
            var url = ConfigurationManager.AppSettings["jsonUrl"];
            var builder = new ContainerBuilder();
            
            // Register controller
            builder.RegisterType<HomeController>().InstancePerRequest();
            // register service 
            builder.RegisterType<PetOwnerService>().As<IPetOwnerService>();
            builder.Register(c => new WebClientService(url)).As<IWebClientService>();
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

    }
}
