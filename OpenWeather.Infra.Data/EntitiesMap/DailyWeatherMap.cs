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
    public class DailyWeatherMap : IEntityTypeConfiguration<DailyWeather>
    {
        public void Configure(EntityTypeBuilder<DailyWeather> builder)
        {
            builder.ToTable("DailyWeather");
            builder.HasKey(x => x.DailyWeatherId);

            builder.Property(x => x.DailyWeatherId).HasColumnType("int").UseIdentityColumn(1, 1).IsRequired();
            builder.Property(x => x.Main).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Icon).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            builder.HasOne(x => x.Daily)
                .WithMany(y => y.DailyWeathers)
                .HasForeignKey(x => x.DailyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
