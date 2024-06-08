using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Domain.Entities
{
    public class HourlyWeather
    {
        public int HourlyWeatherId { get; set; }
        public string Main { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Icon { get; set; } = null!;

        public int HourlyId { get; set; }
        public virtual Hourly Hourly { get; set; } = null!;
    }
}
