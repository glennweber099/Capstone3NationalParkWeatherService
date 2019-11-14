using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAO
{
    public class FavoriteSQLDAO : IFavoriteDAO
    {
        private readonly string connectionString;

        public FavoriteSQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<FavoriteModel> GetFavorites()
        {
            List<FavoriteModel> output = new List<FavoriteModel>();
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = "select survey_result.parkCode, park.parkName, Count(survey_result.parkCode) AS 'Count' from survey_result join park on park.parkCode = survey_result.parkCode group by survey_result.parkCode, park.parkName order by count(survey_result.parkCode) desc, park.parkName";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FavoriteModel favorite = RowToObject(reader);
                        output.Add(favorite);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;

        }
        public bool SaveNewSurvey(SurveyModel survey)
        {
            {
                try
                {
                    // Create a new connection object
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        // Open the connection
                        conn.Open();

                        string sql = "insert into survey_result(parkCode, emailAddress, state, activityLevel) Values(@parkcode, @email, @state, @activitylevel)";

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@email", survey.Email);
                        cmd.Parameters.AddWithValue("@state", survey.State);
                        cmd.Parameters.AddWithValue("@parkcode", survey.ParkCode);
                        cmd.Parameters.AddWithValue("@activitylevel", survey.ActivityLevel);
                        // Execute the command
                        SqlDataReader reader = cmd.ExecuteReader();
                        int id = 0;
                        while (reader.Read())
                        {
                            id = Convert.ToInt32(reader["surveyId"]);
                        }
                        return id > 0;
                    }
                }
                catch (SqlException ex)
                {
                    return false;
                }
            }
        }
        private FavoriteModel RowToObject(SqlDataReader reader)
        {
            FavoriteModel favorite = new FavoriteModel();
            favorite.ParkCode = Convert.ToString(reader["parkCode"]);
            favorite.ParkName = Convert.ToString(reader["parkName"]);
            favorite.Votes = Convert.ToInt32(reader["Count"]);

            return favorite;
        }
    }
}
