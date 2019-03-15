using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class SurveySqlDAO : ISurveyDAO
    {
        private readonly string connectionString;

        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Return a list of all surveys completed
        public IList<SurveyResults> GetAllSurveys()
        {
            // Parameter to store what's returned
            IList<SurveyResults> surveys = new List<SurveyResults>();

            // Open a connection to database
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create query to pull back survey results ordered by number of votes then park name
                    string sql = "select p.parkName as parkname, p.parkCode as parkcode, count(*) as parkscount from survey_result sr " +
                        "JOIN park p ON sr.parkCode = p.parkCode GROUP BY p.parkName, p.parkCode ORDER BY count(*) DESC, p.parkName ASC;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read in the survey result rows and store them in a list
                    while (reader.Read())
                    {
                        // Loop through all of the survey results returned
                        SurveyResults results = new SurveyResults
                        {
                            ParksCount = Convert.ToInt32(reader["parkscount"]),
                            ParkName = Convert.ToString(reader["parkname"]),
                            ParkCode = Convert.ToString(reader["parkcode"])
                        };

                        // Save all surveys to a list of SurveyResults
                        surveys.Add(results);
                    }
                }

                // Return the list of all surveys
                return surveys;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds a completed survey into data
        /// </summary>
        /// <param name="survey">A completed Survey</param>
        /// <returns>True if a survey is added correctly</returns>
        public bool SubmitSurvey(Survey survey)
        {
            bool isAdded;

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("insert into survey_result values (@parkId, @email, @state, @activity)", conn);
                    cmd.Parameters.AddWithValue("@parkId", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@email", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activity", survey.ActivityLevel);

                    isAdded = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return isAdded;
        }
    }
}
