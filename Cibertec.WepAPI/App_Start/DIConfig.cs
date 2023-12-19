using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using log4net;
using log4net.Core;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Configuration;
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

            container.RegisterConditional(typeof(ILog), c => typeof(log4NetAdapter<>).MakeGenericType(c.Consumer.ImplementationType), Lifestyle.Singleton, c => true);

            container.Verify();
            pConfig.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }

    public sealed class log4NetAdapter<T> : LogImpl
    {
        public log4NetAdapter() : base(LogManager.GetLogger(typeof(T)).Logger) { }
    }

}