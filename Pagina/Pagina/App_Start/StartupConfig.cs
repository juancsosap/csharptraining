using Pagina.Models;
using Pagina.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Pagina.App_Start
{
    public class StartupConfig
    {
        public static void configure()
        {
            IUnityContainer container = new UnityContainer();

            registerServices(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void registerServices(IUnityContainer container)
        {
            container.RegisterType<DAO<Persona>, DAOMemoryPersona>();
        }
    }

    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (Exception)
            {
                return new List<Object>();
            }
        }
    }
}