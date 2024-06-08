using OpenWeather.Application.Interfaces.Repositories;
using OpenWeather.Domain.Entities;
using OpenWeather.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Infra.Data.Repositories
{
    public class WeatherForecastRepository : BaseRepository<WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(OpenWeatherContext context) : base(context)
        {
        }
    }
}
