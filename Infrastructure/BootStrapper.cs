using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Infrastructure.IoC;

namespace Infrastructure
{
    public static class BootStrapper
    {
        private static bool _isInitialized;
        private static IContainer _container;

        private static readonly object Lock = new object();

        public static IContainer Initialize(Assembly controllerAssembly, string connectionString)
        {
            if (_isInitialized)
                return _container;

            lock (Lock)
            {
                if (_isInitialized)
                    return _container;

                //Configure the global IoC container
                _container = AutofacConfig.Configure(controllerAssembly, connectionString);

                //Tell the ASP.NET MVC Dependency Resolver to use the global IoC container
                DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));

                _isInitialized = true;

                return _container;
            }
        }        
    }
}
