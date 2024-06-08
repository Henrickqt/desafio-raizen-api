using OpenWeather.Application.Models.Request;
using OpenWeather.Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Application.Interfaces.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecastResponseDto> GetWeatherForecastAsync(WeatherForecastRequestDto requestDto);
        Task<IEnumerable<WeatherForecastResponseDto>> GetWeatherForecastHistoryAsync();
        Task<WeatherForecastResponseDto> GetWeatherForecastHistoryByIdAsync(int weatherForecastId);
    }
}
