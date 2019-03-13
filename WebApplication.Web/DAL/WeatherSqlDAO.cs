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
        public WeatherSqlDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private string ConnectionString;

        public IList<Weather> GetWeather(string parkId)
        {
            IList<Weather> forecast = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from weather where parkCode = @parkId", conn);
                    cmd.Parameters.AddWithValue("@parkId", parkId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather weather = ConvertReaderToWeather(reader);
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
