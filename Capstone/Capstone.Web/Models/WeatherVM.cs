using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class WeatherVM
    {
        public IList<Weather> Weathers { get; set; }
        public Weather weather { get; set; }
        public string ParkCode { get; set; }
        public int Day { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
    }
}
