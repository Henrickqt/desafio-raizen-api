using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenWeather.Application.Exceptions;
using OpenWeather.Application.Interfaces.ExternalServices;
using OpenWeather.Application.Models.Request;
using OpenWeather.Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Infra.ExternalServices
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public OpenWeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WeatherForecastResponseDto> GetWeatherForecastAsync(WeatherForecastRequestDto requestDto)
        {
            try
            {
                var query = new StringBuilder(string.Empty);
                query.Append($"?lat={requestDto.Latitude.ToString()}");
                query.Append($"&lon={requestDto.Longitude.ToString()}");
                query.Append($"&appid={_configuration["OpenWeatherApiKey"]}");
                query.Append($"&exclude=current,minutely,alerts");
                query.Append($"&units=metric");
                query.Append($"&lang=pt_br");

                var response = await _httpClient.GetAsync($"data/3.0/onecall{query}");

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new OpenWeatherException($"Erro ao obter os dados da previsão do tempo.");

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<WeatherForecastResponseDto>(content);

                if (result == null)
                    throw new OpenWeatherException($"Erro ao obter os dados da previsão do tempo.");

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
