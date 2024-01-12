using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentWeatherChecker
{
    // Модель погодных данных
    public class WeatherData
    {
        public double Temperature { get; set; }
        public string Description { get; set; }
        public double WindSpeed { get; set; }
        public class Main
        {
            public double Temp { get; set; }
        }
        public class Weather
        {
            public string Description { get; set; }
        }
        public class Wind
        {
            public double Speed { get; set; }
        }
    }
}
