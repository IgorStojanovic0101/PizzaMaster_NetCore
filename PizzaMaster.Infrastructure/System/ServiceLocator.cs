using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Infrastructure.System
{
    public static class ServiceLocator
    {
        private static IServiceProvider _serviceProvider = null!;
        private static IEnumerable<ServiceDescriptor> _serviceDescriptions = null!;

        public static void Initialize(IServiceCollection services)
        {
            _serviceProvider = services.BuildServiceProvider();
            _serviceDescriptions = services.AsEnumerable();
        }
        public static string GetLifecicle<T>()
        {
            string serviceLifetime = "None";

            foreach (var desc in _serviceDescriptions)
            {
                if (desc.ServiceType == typeof(T))
                {
                    serviceLifetime = desc.Lifetime.ToString();
                }
            }



            return serviceLifetime;


        }

        public static IServiceProvider ServiceProvider { get { return _serviceProvider; } }

        public static T GetRequiredService<T>() where T : class => _serviceProvider.GetRequiredService<T>();
    }
}
