using System;
using Microsoft.Practices.Unity;
using StudentSuccessAnalytics.Infrastructure.Common;
using StudentSuccessAnalitycs.Infrastructure.Sql.Generic;

namespace StudentSuccess.WebAPI
{
    public static class UnityConfiguration
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() => {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer () {
            return Container.Value;
        }

        public static void RegisterTypes ( IUnityContainer container ) {
            container
                .RegisterType<IUnitOfWork, UnitOfWork>( new PerResolveLifetimeManager() );

        }
    }
}