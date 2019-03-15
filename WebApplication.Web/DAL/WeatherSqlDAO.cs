using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherSqlDAO"/> class.
        /// Creates a new WeatherSqlDAO
        /// </summary>
        /// <param name="connectionString">Location of data</param>
        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Reads data source and returns 5-day forecast for Park identified by parkId
        /// </summary>
        /// <param name="parkId">Uniquely identifies a Park</param>
        /// <returns>5-Day Weather forecast</returns>
        public IList<Weather> GetWeather(string parkId)
        {
            IList<Weather> forecast = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from weather where parkCode = @parkId", conn);
                    cmd.Parameters.AddWithValue("@parkId", parkId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather weather = this.ConvertReaderToWeather(reader);
                        forecast.Add(weather);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return forecast;
        }

        /// <summary>
        /// Uses an SqlDataReader to convert Sql results into Weather object
        /// </summary>
        /// <param name="reader">SqlDataReader containing Sql results</param>
        /// <returns>A Weather object</returns>
        private Weather ConvertReaderToWeather(SqlDataReader reader)
        {
            Weather weather = new Weather()
            {
                ParkCode = Convert.ToString(reader["parkcode"]),
                FiveDayForecastValue = Convert.ToInt32(reader["fivedayforecastvalue"]),
                Low = Convert.ToInt32(reader["low"]),
                High = Convert.ToInt32(reader["high"]),
                Forecast = Convert.ToString(reader["forecast"])
            };

            return weather;
        }
    }
}
