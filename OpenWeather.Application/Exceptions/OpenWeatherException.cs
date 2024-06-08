using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Application.Exceptions
{
    public class OpenWeatherException : Exception
    {
        public OpenWeatherException(string message) : base(message)
        {
        }
    }
}
