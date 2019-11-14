using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class FavoriteModel
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public int Votes { get; set; }
        IList<FavoriteModel> Favorites { get; set; }
    }
}
