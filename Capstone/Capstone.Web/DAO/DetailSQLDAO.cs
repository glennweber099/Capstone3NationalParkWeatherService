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

                    string sql = "SELECT * from park JOIN weather ON weather.parkCode = park.parkCode WHERE park.parkCode = @parkCode";
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
                        output = RowTooObject(reader);
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

                    string sql = "select distinct park.parkCode, park.parkName, park.state, park.acreage, park.elevationInFeet, park.milesOfTrail, park.numberOfCampsites, park.climate, park.yearFounded, park.annualVisitorCount, park.inspirationalQuote, park.inspirationalQuoteSource, park.parkDescription, park.entryFee, park.numberOfAnimalSpecies from park join weather on park.parkCode = weather.parkCode group by park.parkCode, weather.parkCode, park.parkName, park.state, park.acreage, park.elevationInFeet, park.milesOfTrail, park.numberOfCampsites, park.climate, park.yearFounded, park.annualVisitorCount, park.inspirationalQuote, park.inspirationalQuoteSource, park.parkDescription, park.entryFee, park.numberOfAnimalSpecies, weather.fiveDayForecastValue, weather.low, weather.high, weather.forecast";
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

        private ParkModel RowTooObject(SqlDataReader reader)
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
            park.Day = Convert.ToInt32(reader["fiveDayForecastValue"]);
            park.Low = Convert.ToInt32(reader["low"]);
            park.High = Convert.ToInt32(reader["high"]);
            park.Forecast = Convert.ToString(reader["forecast"]);

            return park;
        }
    }
}
