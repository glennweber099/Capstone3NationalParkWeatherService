using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAO
{
    public class DetailSQLDAO : IDetailDAO
    {
        private string connectionString;

        public DetailSQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
