using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.Unity;
using StudentSuccessAnalitycs.Infrastructure.Sql.Generic;
using StudentSuccessAnalytics.Infrastructure.Common;

namespace StudentSuccessAnalytics.IoC {
    public class UnityConfiguration {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() => {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer () {
            return Container.Value;
        }

        public static IEnumerable<Type> GetTypesWithCustomAttribute<T> ( Assembly[] assemblies ) {
            foreach ( var assembly in assemblies ) {
                foreach ( var type in assembly.GetTypes() ) {
                    if ( type.GetCustomAttributes(typeof(T), true).Length > 0 ) {
                        yield return type;
                    }
                }
            }
        }

        public static void RegisterTypes ( IUnityContainer container ) {
            container
                .RegisterType<IUnitOfWork, UnitOfWork>( new PerRequestLifetimeManager() );
        }
    }
}