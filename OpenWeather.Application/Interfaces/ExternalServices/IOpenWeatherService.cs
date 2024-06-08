using OpenWeather.Application.Models.Request;
using OpenWeather.Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Application.Interfaces.ExternalServices
{
    public interface IOpenWeatherService
    {
        Task<WeatherForecastResponseDto> GetWeatherForecastAsync(WeatherForecastRequestDto requestDto);
    }
}
