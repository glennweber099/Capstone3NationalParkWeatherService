using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int Day { get; set; }
        public int LowF { get; set; }
        public int LowC
        {
            get
            {
                return (LowF - 32) * (5 / 9); 
            }
        }
        public int HighF { get; set; }
        public int HighC
        {
            get
            {
                return (HighF - 32) * (5 / 9);
            }
        }
        public string UnitSelection { get; set; }
        public string Forecast { get; set; } 
    }
}
