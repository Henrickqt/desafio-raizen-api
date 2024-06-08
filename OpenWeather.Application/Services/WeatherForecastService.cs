using OpenWeather.Application.Interfaces.ExternalServices;
using OpenWeather.Application.Interfaces.Repositories;
using OpenWeather.Application.Interfaces.Services;
using OpenWeather.Application.Models.Request;
using OpenWeather.Application.Models.Response;
using OpenWeather.Domain.Extensions;
using OpenWeather.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly IOpenWeatherService _openWeatherService;

        public WeatherForecastService(
            IUnitOfWork unitOfWork,
            IWeatherForecastRepository weatherForecastRepository,
            IOpenWeatherService openWeatherService)
        {
            _unitOfWork = unitOfWork;
            _weatherForecastRepository = weatherForecastRepository;
            _openWeatherService = openWeatherService;
        }

        public async Task<WeatherForecastResponseDto> GetWeatherForecastAsync(WeatherForecastRequestDto requestDto)
        {
            var result = await _openWeatherService.GetWeatherForecastAsync(requestDto);

            foreach (var item in result.Hourly)
            {
                item.WindSpeed = item.WindSpeed.ConvertMsToKmh();
                item.Precipitation *= 100;
            }

            foreach (var item in result.Daily)
            {
                item.WindSpeed = item.WindSpeed.ConvertMsToKmh();
                item.Precipitation *= 100;
            }

            return result;
        }

        public async Task<IEnumerable<WeatherForecastResponseDto>> GetWeatherForecastHistoryAsync()
        {
            throw new NotImplementedException();
        }
    }
}
