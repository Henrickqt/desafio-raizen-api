using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Domain.Entities
{
    public class DailyWeather
    {
        public int DailyWeatherId { get; set; }
        public string Main { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Icon { get; set; } = null!;

        public int DailyId { get; set; }
        public virtual Daily Daily { get; set; } = null!;
    }
}
