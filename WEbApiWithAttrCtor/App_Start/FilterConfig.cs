using System.Web.Http.Filters;

using Castle.Windsor;
using IAuthorizationFilter = System.Web.Http.Filters.IAuthorizationFilter;

namespace WEbApiWithAttrCtor
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(HttpFilterCollection filters, IWindsorContainer container)
        {
            filters.Add(container.Resolve<IAuthorizationFilter>());
        }
    }
}