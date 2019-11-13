using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAO
{
    public class FavoriteSQLDAO : IFavoriteDAO
    {
        private readonly string connectionString;

        public FavoriteSQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
