using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenWeather.Application.Interfaces.ExternalServices;
using OpenWeather.Application.Interfaces.Repositories;
using OpenWeather.Application.Interfaces.Services;
using OpenWeather.Application.Services;
using OpenWeather.Domain.Interfaces;
using OpenWeather.Infra.Data;
using OpenWeather.Infra.Data.Repositories;
using OpenWeather.Infra.ExternalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Infra.IoC
{
    public static class InjectorBootstrapper
    {
        public static void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OpenWeatherContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("Database"),
                    opt => opt.MigrationsAssembly("OpenWeather.Infra.Data"));
                options.UseLazyLoadingProxies();
            });
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
        }

        public static void RegisterHttpClients(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IOpenWeatherService, OpenWeatherService>(options =>
            {
                options.BaseAddress = new Uri(configuration["OpenWeatherBaseUrl"]);
                options.Timeout = TimeSpan.FromSeconds(30);
            });
        }
    }
}
