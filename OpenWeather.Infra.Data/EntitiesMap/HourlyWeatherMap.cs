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
    public class HourlyWeatherMap : IEntityTypeConfiguration<HourlyWeather>
    {
        public void Configure(EntityTypeBuilder<HourlyWeather> builder)
        {
            builder.ToTable("HourlyWeather");
            builder.HasKey(x => x.HourlyWeatherId);

            builder.Property(x => x.HourlyWeatherId).HasColumnType("int").UseIdentityColumn(1, 1).IsRequired();
            builder.Property(x => x.Main).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Icon).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            builder.HasOne(x => x.Hourly)
                .WithMany(y => y.HourlyWeathers)
                .HasForeignKey(x => x.HourlyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
