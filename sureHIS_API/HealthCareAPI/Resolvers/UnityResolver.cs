using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace HealthCareAPI.Resolvers
{
    public class UnityResolver : IDependencyResolver
    {
        public readonly IUnityContainer Container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            this.Container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.Container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.Container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()

        {
            var child = this.Container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            this.Container.Dispose();
        }
    }
}