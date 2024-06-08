using Newtonsoft.Json;
using OpenWeather.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Application.Models.Response
{
    public class DailyDto
    {
        [JsonProperty("dt")]
        public int Time { get; set; }

        public int Humidity { get; set; }
        
        [JsonProperty("wind_speed")]
        public decimal WindSpeed { get; set; }
        
        [JsonProperty("pop")]
        public decimal Precipitation { get; set; }
        
        [JsonProperty("temp")]
        public TemperatureDto Temperature { get; set; } = null!;
        
        public IEnumerable<WeatherDto> Weather { get; set; } = null!;

        public static implicit operator DailyDto(Daily entity) => new()
        {
            Time = entity.Time,
            Humidity = entity.Humidity,
            WindSpeed = entity.WindSpeed,
            Precipitation = entity.Precipitation,
            Temperature = new TemperatureDto
            {
                Min = entity.TemperatureMin,
                Max = entity.TemperatureMax,
            },
            Weather = entity.DailyWeathers.Select(x => (WeatherDto)x).ToList(),
        };

        public static implicit operator Daily(DailyDto dto) => new()
        {
            Time = dto.Time,
            Humidity = dto.Humidity,
            WindSpeed = dto.WindSpeed,
            Precipitation = dto.Precipitation,
            TemperatureMin = dto.Temperature.Min,
            TemperatureMax = dto.Temperature.Max,
            DailyWeathers = dto.Weather.Select(x => (DailyWeather)x).ToList(),
        };
    }
}
