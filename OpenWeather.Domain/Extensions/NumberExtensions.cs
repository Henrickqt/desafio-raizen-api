using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Domain.Extensions
{
    public static class NumberExtensions
    {
        public static decimal ConvertMsToKmh(this decimal value)
        {
            return value * (60 * 60) / 1000;
        }
    }
}
