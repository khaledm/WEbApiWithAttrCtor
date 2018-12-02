using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using WEbApiWithAttrCtor.Windsor;

namespace WEbApiWithAttrCtor
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigureWindsor(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalConfiguration.Configuration.Filters, _container);
        }

        private static void ConfigureWindsor(HttpConfiguration configuration)
        {
            _container = new WindsorContainer();
            _container.Install(new WebApiInstaller());

            configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new CompositionRoot(_container));

            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));
        }
    }
}
