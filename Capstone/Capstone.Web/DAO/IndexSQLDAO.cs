using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAO
{
    public class IndexSQLDAO : IIndexDAO
    {
        private string connectionString;

        public IndexSQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
