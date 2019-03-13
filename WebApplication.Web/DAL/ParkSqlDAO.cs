using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        public ParkSqlDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private string ConnectionString;

        public Park GetPark(int parkId)
        {
            Park park = new Park();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from park where parkCode = @parkId", conn);
                    cmd.Parameters.AddWithValue("@parkId", parkId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        park = ConvertReaderToPark(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return park;

        }

        public IList<Park> GetParks()
        {
            IList<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from park", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = ConvertReaderToPark(reader);
                        parks.Add(park);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return parks;
        }

        private Park ConvertReaderToPark(SqlDataReader reader)
        {
            Park park = new Park()
            {
                ParkCode = Convert.ToString(reader["parkcode"]),
                ParkName = Convert.ToString(reader["parkname"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                ElevationInFeet = Convert.ToInt32(reader["elevationinfeet"]),
                MilesOfTrail = Convert.ToDouble(reader["milesoftrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberofcampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearfounded"]),
                AnnualVisitorCount = Convert.ToInt32(reader["annualvisitorcount"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalquote"]),
                InspirationalQuoteSource = Convert.ToString(reader["inspirationalquotesource"]),
                ParkDescription = Convert.ToString(reader["parkdescription"]),
                EntryFee = Convert.ToInt32(reader["entryfee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberofanimalspecies"])
            };

            return park;
        }
    }
}
