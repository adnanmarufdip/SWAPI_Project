using SWAPI_Project.Services;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;
using Business.Services.Services;

namespace SWAPI_Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Register the PeopleServiceProxy as a service
            var container = new UnityContainer();
            container.RegisterType<PeopleServiceProxy, PeopleServiceProxy>(new HierarchicalLifetimeManager());
            container.RegisterType<IPeopleService, PeopleServiceProxy>(new HierarchicalLifetimeManager());

            // Set the dependency resolver for MVC
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
