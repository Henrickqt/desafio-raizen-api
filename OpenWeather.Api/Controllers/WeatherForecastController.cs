using Microsoft.AspNetCore.Mvc;
using OpenWeather.Application.Interfaces.Services;
using OpenWeather.Application.Models.Request;
using OpenWeather.Application.Models.Response;
using System.Net;

namespace OpenWeather.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecastResponseDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetWeatherForecast([FromQuery] WeatherForecastRequestDto requestDto)
        {
            var result = await _weatherForecastService.GetWeatherForecastAsync(requestDto);
            return Ok(result);
        }

        [HttpGet("history")]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecastResponseDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetWeatherForecastHistory()
        {
            var result = await _weatherForecastService.GetWeatherForecastHistoryAsync();
            return Ok(result);
        }

        [HttpGet("history/{weatherForecastId}")]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecastResponseDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetWeatherForecastHistoryById([FromRoute] int weatherForecastId)
        {
            var result = await _weatherForecastService.GetWeatherForecastHistoryByIdAsync(weatherForecastId);
            return Ok(result);
        }
    }
}
