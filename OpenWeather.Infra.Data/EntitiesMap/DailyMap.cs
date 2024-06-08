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
    public class DailyMap : IEntityTypeConfiguration<Daily>
    {
        public void Configure(EntityTypeBuilder<Daily> builder)
        {
            builder.ToTable("Daily");
            builder.HasKey(x => x.DailyId);

            builder.Property(x => x.DailyId).HasColumnType("int").UseIdentityColumn(1, 1).IsRequired();
            builder.Property(x => x.Time).HasColumnType("int").IsRequired();
            builder.Property(x => x.Humidity).HasColumnType("int").IsRequired();
            builder.Property(x => x.WindSpeed).HasColumnType("decimal(12,5)").IsRequired();
            builder.Property(x => x.Precipitation).HasColumnType("decimal(12,5)").IsRequired();
            builder.Property(x => x.TemperatureMin).HasColumnType("decimal(12,5)").IsRequired();
            builder.Property(x => x.TemperatureMax).HasColumnType("decimal(12,5)").IsRequired();

            builder.HasMany(x => x.DailyWeathers)
                .WithOne(y => y.Daily)
                .HasForeignKey(y => y.DailyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.WeatherForecast)
                .WithMany(y => y.Dailies)
                .HasForeignKey(x => x.WeatherForecastId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
