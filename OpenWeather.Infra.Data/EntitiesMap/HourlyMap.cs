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
    public class HourlyMap : IEntityTypeConfiguration<Hourly>
    {
        public void Configure(EntityTypeBuilder<Hourly> builder)
        {
            builder.ToTable("Hourly");
            builder.HasKey(x => x.HourlyId);

            builder.Property(x => x.HourlyId).HasColumnType("int").UseIdentityColumn(1, 1).IsRequired();
            builder.Property(x => x.Time).HasColumnType("int").IsRequired();
            builder.Property(x => x.Temperature).HasColumnType("decimal(12,5)").IsRequired();
            builder.Property(x => x.Humidity).HasColumnType("int").IsRequired();
            builder.Property(x => x.WindSpeed).HasColumnType("decimal(12,5)").IsRequired();
            builder.Property(x => x.Precipitation).HasColumnType("decimal(12,5)").IsRequired();

            builder.HasMany(x => x.HourlyWeathers)
                .WithOne(y => y.Hourly)
                .HasForeignKey(y => y.HourlyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.WeatherForecast)
                .WithMany(y => y.Hourlies)
                .HasForeignKey(x => x.WeatherForecastId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
