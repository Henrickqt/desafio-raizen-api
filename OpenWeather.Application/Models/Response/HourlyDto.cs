using Newtonsoft.Json;
using OpenWeather.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Application.Models.Response
{
    public class HourlyDto
    {
        [JsonProperty("dt")]
        public int Time { get; set; }

        [JsonProperty("temp")]
        public decimal Temperature { get; set; }

        public int Humidity { get; set; }

        [JsonProperty("wind_speed")]
        public decimal WindSpeed { get; set; }

        [JsonProperty("pop")]
        public decimal Precipitation { get; set; }

        public IEnumerable<WeatherDto> Weather { get; set; } = null!;

        public static implicit operator HourlyDto(Hourly entity) => new()
        {
            Time = entity.Time,
            Temperature = entity.Temperature,
            Humidity = entity.Humidity,
            WindSpeed = entity.WindSpeed,
            Precipitation = entity.Precipitation,
            Weather = entity.HourlyWeathers.Select(x => (WeatherDto)x).ToList(),
        };

        public static implicit operator Hourly(HourlyDto dto) => new()
        {
            Time = dto.Time,
            Temperature = dto.Temperature,
            Humidity = dto.Humidity,
            WindSpeed = dto.WindSpeed,
            Precipitation = dto.Precipitation,
            HourlyWeathers = dto.Weather.Select(x => (HourlyWeather)x).ToList(),
        };
    }
}
