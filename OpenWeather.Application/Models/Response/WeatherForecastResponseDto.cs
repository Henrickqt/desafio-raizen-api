using Newtonsoft.Json;
using OpenWeather.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Application.Models.Response
{
    public class WeatherForecastResponseDto
    {
        [JsonProperty("lat")]
        public decimal Latitude { get; set; }

        [JsonProperty("lon")]
        public decimal Longitude { get; set; }
        
        public string Timezone { get; set; } = null!;
        
        [JsonProperty("timezone_offset")]
        public int TimezoneOffset { get; set; }
        
        public IEnumerable<HourlyDto> Hourly { get; set; } = null!;
        
        public IEnumerable<DailyDto> Daily { get; set; } = null!;

        public static implicit operator WeatherForecastResponseDto(WeatherForecast entity) => new()
        {
            Latitude = entity.Latitude,
            Longitude = entity.Longitude,
            Timezone = entity.Timezone,
            TimezoneOffset = entity.TimezoneOffset,
            Hourly = entity.Hourlies.Select(x => (HourlyDto)x).ToList(),
            Daily = entity.Dailies.Select(x => (DailyDto)x).ToList(),
        };

        public static implicit operator WeatherForecast(WeatherForecastResponseDto dto) => new()
        {
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            Timezone = dto.Timezone,
            TimezoneOffset = dto.TimezoneOffset,
            Hourlies = dto.Hourly.Select(x => (Hourly)x).ToList(),
            Dailies = dto.Daily.Select(x => (Daily)x).ToList(),
        };
    }
}
