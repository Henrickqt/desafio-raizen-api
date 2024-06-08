using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Domain.Entities
{
    public class Daily
    {
        public int DailyId { get; set; }
        public int Time { get; set; }
        public int Humidity { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal Precipitation { get; set; }
        public decimal TemperatureMin { get; set; }
        public decimal TemperatureMax { get; set; }
        public virtual ICollection<DailyWeather> DailyWeathers { get; set; } = null!;

        public int WeatherForecastId { get; set; }
        public virtual WeatherForecast WeatherForecast { get; set; } = null!;
    }
}
