using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Infra.IoC
{
    public static class DIConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            InjectorBootstrapper.RegisterDbContext(services, configuration);
            InjectorBootstrapper.RegisterServices(services);
            InjectorBootstrapper.RegisterRepositories(services);
            InjectorBootstrapper.RegisterHttpClients(services, configuration);
        }
    }
}
