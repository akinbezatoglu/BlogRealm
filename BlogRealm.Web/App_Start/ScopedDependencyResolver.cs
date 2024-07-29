using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogRealm.Web.App_Start
{
    public class ScopedDependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider _serviceProviderRoot;

        public ScopedDependencyResolver(IServiceProvider serviceProviderRoot)
        {
            _serviceProviderRoot = serviceProviderRoot;
        }

        public object GetService(Type serviceType)
        {
            return resolveServiceProvider().GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return resolveServiceProvider().GetServices(serviceType);
        }

        private IServiceProvider resolveServiceProvider()
        {
            if (HttpContext.Current == null)
            {
                Debug.WriteLine("Resolving services from root container !");
                return _serviceProviderRoot;
            }

            var scope = HttpContext.Current.Items[typeof(IServiceScope)] as IServiceScope;

            if (scope == null)
            {
                scope = _serviceProviderRoot.CreateScope();
                HttpContext.Current.Items[typeof(IServiceScope)] = scope;
            }
            return scope.ServiceProvider;
        }
    }
}