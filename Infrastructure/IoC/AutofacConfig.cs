using System;
using System.Reflection;
using Autofac;
using Domain.Repositories;
using Persistence.ModelPersistence;
using Autofac.Integration.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Infrastructure.Persistence.Mappings;

namespace Infrastructure.IoC
{
    public static class AutofacConfig
    {
        //Helper
        private static Assembly AssemblyOf<T>()
        {
            return typeof(T).Assembly;
        }

        //object extension Helper
        //TODO: move this to a common location
        private static bool Implements<T>(this object value)
            where T : class
        {
            if (value == null)
                return false;

            var type = value as Type ?? value.GetType();

            return typeof(T).IsAssignableFrom(type);
        }

        //Configure context to database
        private static void ConfigureDbContext(ContainerBuilder registry, string connectionString)
        {
            //configure nhibernate
            //TODO: clean this up. move it somewhere else
            if (connectionString.Contains("|DataDirectory|"))
            {
                //local SqlCe database
                registry.Register(c =>
                    Fluently
                        .Configure()
                        .Database(
                            MsSqlCeConfiguration.Standard.ConnectionString(connectionString))
                        .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<JewelryMap>())
                        .BuildSessionFactory())
                    .SingleInstance();
            }
            else
            {
                //Azure
                registry.Register(c =>
                    Fluently
                        .Configure()
                        .Database(
                            MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                        .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<JewelryMap>())
                        .BuildSessionFactory())
                    .SingleInstance();
            }

            //configure session
            registry.Register(c =>
                c.Resolve<ISessionFactory>()
                    .OpenSession())
                .InstancePerHttpRequest();
        }

        //Scan assemblies local to the Solution
        private static void ScanLocalTypes(ContainerBuilder registry)
        {
            registry.RegisterAssemblyTypes(
                AssemblyOf<JewelryPersistence>()
            ).AsImplementedInterfaces();

            //don't scan the Domain or Presentation assembly
        }

        private static void ConfigureRepositories(ContainerBuilder registry)
        {
            //In the Domain assembly, we want to limit our registry to Interfaces
            registry.RegisterAssemblyTypes(AssemblyOf<IJewelryRepository>())
                .Where(type => type.IsInterface)
                .AsImplementedInterfaces();
        }

        private static void ConfigureMvc(ContainerBuilder registry, Assembly controllerAssembly)
        {
            registry.RegisterControllers(controllerAssembly);
        }

        public static IContainer Configure(Assembly controllerAssembly, string connectionString)
        {
            //Configure Autofac
            var registry = new ContainerBuilder();

            ConfigureDbContext(registry, connectionString);
            ScanLocalTypes(registry);
            ConfigureRepositories(registry);
            ConfigureMvc(registry, controllerAssembly);

            return registry.Build();
        }
    }
}
