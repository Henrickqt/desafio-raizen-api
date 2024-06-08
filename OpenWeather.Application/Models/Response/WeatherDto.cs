using OpenWeather.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Application.Models.Response
{
    public class WeatherDto
    {
        public string Main { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Icon { get; set; } = null!;

        public static implicit operator WeatherDto(HourlyWeather entity) => new()
        {
            Main = entity.Main,
            Description = entity.Description,
            Icon = entity.Icon,
        };

        public static implicit operator HourlyWeather(WeatherDto dto) => new()
        {
            Main = dto.Main,
            Description = dto.Description,
            Icon = dto.Icon,
        };

        public static implicit operator WeatherDto(DailyWeather entity) => new()
        {
            Main = entity.Main,
            Description = entity.Description,
            Icon = entity.Icon,
        };

        public static implicit operator DailyWeather(WeatherDto dto) => new()
        {
            Main = dto.Main,
            Description = dto.Description,
            Icon = dto.Icon,
        };
    }
}
