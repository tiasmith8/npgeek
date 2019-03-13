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
