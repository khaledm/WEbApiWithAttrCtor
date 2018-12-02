using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WEbApiWithAttrCtor.Models;
using WEbApiWithAttrCtor.Services;

namespace WEbApiWithAttrCtor.Windsor
{
    public class WebApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Install(FromAssembly.This());

            container.Register(Classes.FromThisAssembly()
                .BasedOn<IHttpController>()
                .LifestylePerWebRequest());

            container.Register(Classes.FromThisAssembly()
                .BasedOn(typeof(IRepository<>)).WithServiceAllInterfaces());

            container.Register(Classes.FromThisAssembly()
                .BasedOn<INeedInit>().WithServiceAllInterfaces());

            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IAuthorizationFilter)).WithServiceAllInterfaces());
        }
    }
}