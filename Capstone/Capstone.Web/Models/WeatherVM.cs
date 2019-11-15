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
    }
}
