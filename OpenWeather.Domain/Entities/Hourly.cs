using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Domain.Entities
{
    public class Hourly
    {
        public int HourlyId { get; set; }
        public int Time { get; set; }
        public decimal Temperature { get; set; }
        public int Humidity { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal Precipitation { get; set; }
        public virtual ICollection<HourlyWeather> HourlyWeathers { get; set; } = null!;

        public int WeatherForecastId { get; set; }
        public virtual WeatherForecast WeatherForecast { get; set; } = null!;
    }
}
