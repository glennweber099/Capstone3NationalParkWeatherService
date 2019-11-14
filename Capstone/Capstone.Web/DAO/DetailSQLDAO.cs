using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAO
{
    public class DetailSQLDAO : IDetailDAO
    {
        private string connectionString;

        public DetailSQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ParkModel GetPark(string parkCode)
        {
            ParkModel output = new ParkModel();
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = "SELECT * from park WHERE park.parkCode = @parkCode";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (String.IsNullOrEmpty(parkCode))
                    {
                        cmd.Parameters.AddWithValue("@parkCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    }
                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        output = RowToObject(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;

        }

        public IList<ParkModel> GetParksIndex()
        {
            List<ParkModel> parks = new List<ParkModel>();
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = "select distinct parkCode, * from park";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        ParkModel output = RowToObject(reader);
                        parks.Add(output);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return parks;

        }

        private ParkModel RowToObject(SqlDataReader reader)
        {
            ParkModel park = new ParkModel();
            park.ParkCode = Convert.ToString(reader["parkCode"]);
            park.ParkName = Convert.ToString(reader["parkName"]);
            park.State = Convert.ToString(reader["state"]);
            park.Acreage = Convert.ToInt32(reader["acreage"]);
            park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
            park.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
            park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
            park.Climate = Convert.ToString(reader["climate"]);
            park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
            park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
            park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
            park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
            park.ParkDescription = Convert.ToString(reader["parkDescription"]);
            park.EntryFee = Convert.ToDecimal(reader["entryFee"]); 
            park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

            return park;
        }

        public IList<Weather> GetWeather(string parkCode)
        {
            List<Weather> list = new List<Weather>();
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = "select * from weather where parkCode = @parkCode";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    if (String.IsNullOrEmpty(parkCode))
                    {
                        cmd.Parameters.AddWithValue("@parkCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    }

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                 
                        list.Add(RowTooObject(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return list;

        }

        private Weather RowTooObject(SqlDataReader row)
        {

            return new Weather()
            {
                ParkCode = Convert.ToString(row["parkCode"]),
                Day = Convert.ToInt32(row["fiveDayForecastValue"]),
                Low = Convert.ToInt32(row["low"]),
                High = Convert.ToInt32(row["high"]),
                Forecast = Convert.ToString(row["forecast"]),
            };
        }
    }
}
