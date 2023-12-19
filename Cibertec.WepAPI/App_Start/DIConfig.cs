using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cibertec.WepAPI.App_Start
{
    public class DIConfig
    {
        public static void ConfigureInjector(HttpConfiguration pConfig)
        {
            var container = new Container();
            container.Options.ResolveUnregisteredConcreteTypes = true;
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<IUnitOfWork>(()=> new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["csNorthwindConnection"].ConnectionString));
            container.Verify();
            pConfig.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

    }
}