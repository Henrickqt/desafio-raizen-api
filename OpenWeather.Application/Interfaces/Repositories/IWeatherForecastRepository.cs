using OpenWeather.Domain.Entities;
using OpenWeather.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Application.Interfaces.Repositories
{
    public interface IWeatherForecastRepository : IBaseRepository<WeatherForecast>
    {
    }
}
