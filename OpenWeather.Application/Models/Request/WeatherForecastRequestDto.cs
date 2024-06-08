using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Application.Models.Request
{
    public class WeatherForecastRequestDto
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
