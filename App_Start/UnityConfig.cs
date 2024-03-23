using Business.Services.Services;
using SWAPI_Project.Services;
using System;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace SWAPI_Project
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer Container => container.Value;

        private static void RegisterTypes(IUnityContainer container)
        {
            // Register your types here
            container.RegisterType<PeopleServiceProxy, PeopleServiceProxy>(new HierarchicalLifetimeManager());
            container.RegisterType<IPeopleService, PeopleServiceProxy>(new HierarchicalLifetimeManager());
        }
    }
}