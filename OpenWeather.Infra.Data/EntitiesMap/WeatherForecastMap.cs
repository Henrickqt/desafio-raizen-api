using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenWeather.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Infra.Data.EntitiesMap
{
    public class WeatherForecastMap : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.ToTable("WeatherForecast");
            builder.HasKey(x => x.WeatherForecastId);

            builder.Property(x => x.WeatherForecastId).HasColumnType("int").UseIdentityColumn(1, 1).IsRequired();
            builder.Property(x => x.Latitude).HasColumnType("decimal(12,7)").IsRequired();
            builder.Property(x => x.Longitude).HasColumnType("decimal(12,7)").IsRequired();
            builder.Property(x => x.Timezone).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.TimezoneOffset).HasColumnType("int").IsRequired();

            builder.HasMany(x => x.Hourlies)
                .WithOne(y => y.WeatherForecast)
                .HasForeignKey(y => y.WeatherForecastId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Dailies)
                .WithOne(y => y.WeatherForecast)
                .HasForeignKey(y => y.WeatherForecastId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
