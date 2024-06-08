using OpenWeather.Application.Exceptions;
using OpenWeather.Application.Interfaces.ExternalServices;
using OpenWeather.Application.Interfaces.Repositories;
using OpenWeather.Application.Interfaces.Services;
using OpenWeather.Application.Models.Request;
using OpenWeather.Application.Models.Response;
using OpenWeather.Domain.Entities;
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

            result.Date = DateTime.Now;

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

            var entity = (WeatherForecast)result;
            await _weatherForecastRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            result.WeatherForecastId = entity.WeatherForecastId;

            return result;
        }

        public async Task<IEnumerable<WeatherForecastResponseDto>> GetWeatherForecastHistoryAsync()
        {
            var entities = await _weatherForecastRepository.GetAsync(x => x.WeatherForecastId, false);

            return entities.Select(x => (WeatherForecastResponseDto)x);
        }

        public async Task<WeatherForecastResponseDto> GetWeatherForecastHistoryByIdAsync(int weatherForecastId)
        {
            var entity = await _weatherForecastRepository.GetAsync(weatherForecastId);
            if (entity == null)
                throw new NotFoundException("Histórico de previsão do tempo não encontrado.");

            return (WeatherForecastResponseDto)entity;
        }
    }
}
