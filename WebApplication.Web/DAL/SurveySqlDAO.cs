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
        public SurveySqlDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private string ConnectionString;

        // Return a list of all surveys completed
        public IList<SurveyResults> GetAllSurveys()
        {
            // Parameter to store what's returned
            IList<SurveyResults> surveys = new List<SurveyResults>();

            // Open a connection to database
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    //string sql = "SELECT * FROM survey_result;";
                    string sql = "select p.parkName as parkname, count(*) as parkscount from survey_result sr " +
                        "JOIN park p ON sr.parkCode = p.parkCode GROUP BY p.parkName ORDER BY count(*) DESC;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read in the survey result rows and store them in a list
                    while(reader.Read())
                    {
                        SurveyResults results = new SurveyResults();
                        results.ParksCount = Convert.ToInt32(reader["parkscount"]);
                        results.ParkName = Convert.ToString(reader["parkname"]);

                        surveys.Add(results);
                    }
                }

                // Return the list of all surveys
                return surveys;
            }
            catch(SqlException ex)
            {
                throw;
            }

        }



        // Return a list of surveys based on parkcode
        public IList<Survey> GetSurveys(string parkId)
        {
            IList<Survey> surveys = new List<Survey>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from survey_result where parkCode = @parkId", conn);
                    cmd.Parameters.AddWithValue("@parkId", parkId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Survey survey = ConvertReaderToSurvey(reader);
                        surveys.Add(survey);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return surveys;
        }

        private Survey ConvertReaderToSurvey(SqlDataReader reader)
        {
            Survey survey = new Survey()
            {
                SurveyId = Convert.ToInt32(reader["surveyid"]),
                ParkCode = Convert.ToString(reader["parkcode"]),
                EmailAddress = Convert.ToString(reader["emailaddress"]),
                State = Convert.ToString(reader["state"]),
                ActivityLevel = Convert.ToString(reader["activitylevel"])
            };

            return survey;
        }

        public bool SubmitSurvey(Survey survey)
        {
            bool isAdded;

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("insert into survey_result values (@parkId, @email, @state, @activity)", conn);
                    cmd.Parameters.AddWithValue("@parkId", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@email", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activity", survey.ActivityLevel);

                    isAdded = (cmd.ExecuteNonQuery() == 1);
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
