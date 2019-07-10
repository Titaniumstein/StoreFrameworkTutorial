using Controllers;
using Controllers.Actions;
using Controllers.Controllers;
using Controllers.IViews;
using Controllers.Services;
using Infrastructure;
using Infrastructure.Abstractions.Store;
using SimpleInjector;
using StoreFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApp.Abstractions.Store;
using TestApp.Actions;
using Views;

namespace TestApp.IocInstallers
{
    public class Installer
    {
        public static void Register(Container _simpleContainer)
        {
            _simpleContainer.RegisterSingleton<IUserDb, UserDb>();
            _simpleContainer.RegisterSingleton(typeof(StoreWrapper<,>), typeof(StoreWrapper<,>));
            _simpleContainer.RegisterSingleton<IStoreManager, StoreManager>();
            _simpleContainer.RegisterSingleton<IStoreReader>(()=>_simpleContainer.GetInstance<IStoreManager>());

            _simpleContainer.Register(typeof(IActionHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            _simpleContainer.RegisterSingleton<IActionDispatcher, ActionDispatcher>();
            RegisterControllers(_simpleContainer);
            RegisterViews(_simpleContainer);

        }
        private static void RegisterServices(Container container)
        {
            var targetType = typeof(IService);
            var targetAssembly = targetType.Assembly;
            var registrations =
                from type in targetAssembly.GetExportedTypes()
                where type.GetInterfaces().Contains(targetType) && type.IsClass
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in registrations)
            {
                container.Register(reg.Implementation, reg.Implementation, Lifestyle.Singleton);
            }

        }

        private static void RegisterControllers(Container container)
        {
            var targetType = typeof(IController);
            var targetAssembly = targetType.Assembly;
            var registrations =
                from type in targetAssembly.GetExportedTypes()
                where type.GetInterfaces().Contains(targetType) && type.IsClass
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in registrations)
            {
                container.Register(reg.Implementation, reg.Implementation, Lifestyle.Singleton);
            }

        }


        //private static void RegisterControllers(Container container)
        //{

        //    var controllerAssembly = typeof(IController).Assembly;
        //    var controllerRegistrations =
        //        from type in controllerAssembly.GetExportedTypes()
        //        where type.GetInterfaces().Contains(typeof(IController)) && type.IsClass
        //        select new { Service = type.GetInterfaces().Single(), Implementation = type };

        //    foreach (var reg in controllerRegistrations)
        //    {
        //        container.Register(reg.Implementation, reg.Implementation, Lifestyle.Singleton);
        //    }

        //}

        private static void RegisterViews(Container container)
        {
            var viewContracts = typeof(IViewBase).Assembly
                .GetExportedTypes().Where(t => t.GetInterfaces().Contains(typeof(IViewBase)) && !t.IsGenericType);

            var viewAssembly = typeof(UserView).Assembly;
            foreach (var contract in viewContracts)
            {
                var viewType = viewAssembly.GetExportedTypes().Where(t => t.GetInterfaces().Contains(contract)).First();
                container.Register(contract, viewType, Lifestyle.Singleton);

            }
            //var viewAssembly = typeof(UserView).Assembly;
            //var viewTypes =
            //    from type in viewAssembly.GetExportedTypes()
            //    where type.GetInterfaces().Contains(typeof(IViewBase))
            //    select type;

            //foreach (var viewType in viewTypes)
            //{
            //    var service = GetViewService(viewType);
            //    container.Register(service, viewType, Lifestyle.Singleton);
            //}

        }



        private static Type GetViewService(Type viewType)
        {
            var service = viewType.GetInterfaces()
                .Where(i => i.GetInterfaces().Contains(typeof(IViewBase)) && i.IsGenericType == false).First();

            return service;

        }

    }
}
