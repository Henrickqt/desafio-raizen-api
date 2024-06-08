using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Domain.Entities
{
    public class WeatherForecast
    {
        public int WeatherForecastId { get; set; }
        public DateTime Date { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Timezone { get; set; } = null!;
        public int TimezoneOffset { get; set; }
        public virtual ICollection<Hourly> Hourlies { get; set; } = null!;
        public virtual ICollection<Daily> Dailies { get; set; } = null!;
    }
}
