using Microsoft.EntityFrameworkCore;
using OpenWeather.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Infra.Data
{
    public class OpenWeatherContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecast { get; set; } = null!;
        public DbSet<Hourly> Hourly { get; set; } = null!;
        public DbSet<HourlyWeather> HourlyWeather { get; set; } = null!;
        public DbSet<Daily> Daily { get; set; } = null!;
        public DbSet<DailyWeather> DailyWeather { get; set; } = null!;

        public OpenWeatherContext(DbContextOptions<OpenWeatherContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OpenWeatherContext).Assembly);
        }
    }
}
