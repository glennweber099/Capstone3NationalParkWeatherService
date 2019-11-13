using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class _ParkModelVM
    {
        public class ParkModel
        {
            public string ParkCode { get; set; }
            public string ParkName { get; set; }
            public string State { get; set; }
            public int Acreage { get; set; }
            public int ElevationInFeet { get; set; }
            public int MilesOfTrail { get; set; }
            public int NumberOfCampsites { get; set; }
            public string Climate { get; set; }
            public DateTime YearFounded { get; set; }
            public int AnnualVisitorCount { get; set; }
            public string InspirationalQuote { get; set; }
            public string InspirationalQuoteSource { get; set; }
            public string ParkDescription { get; set; }
            public decimal EntryFee { get; set; }
            public int NumberOfAnimalSpecies { get; set; }
            public int Day { get; set; }
            public int Low { get; set; }
            public int High { get; set; }
            public string Forecast { get; set; }
            public IList<ParkModel> Parks { get; set; }
        }
    }
}
