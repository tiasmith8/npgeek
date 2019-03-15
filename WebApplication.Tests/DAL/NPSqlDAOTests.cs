using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using System.IO;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class NPSqlDAOTests
    {
        protected string ConnectionString { get; } = "Server=.\\SQLEXPRESS;Database=NPGeek;Trusted_Connection=True;";

        /// <summary>
        /// Holds the newly generated park id for test data.
        /// </summary>
        protected string NewParkId { get; private set; }

        /// <summary>
        /// Holds the newly generated survey id for integration test data.
        /// </summary>
        protected int NewSurveyId { get; private set; }

        /// <summary>
        /// The transaction for each test.
        /// </summary>
        private TransactionScope transaction;

        [TestInitialize]
        public void Setup()
        {
            // Begin the transaction
            transaction = new TransactionScope();

            // Get the SQL Script to run
            string sql = File.ReadAllText("test-script.sql");

            try
            {
                // Execute the setup script
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open(); // Open th connection
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // If there is a row to read
                    if (reader.Read())
                    {
                        // Store the id for the test data survey to be used in subclass
                        this.NewSurveyId = Convert.ToInt32(reader["newSurveyId"]);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Roll back the transaction
            transaction.Dispose();
        }

        /// <summary>
        /// Gets the row count for table.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        protected int GetRowCount(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open(); // Open the connection
                // Get a row count for the input table.
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
                // Store number of rows into count variable by executing query to pull from database.
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                // Return the number of rows in the requested table.
                return count;
            }
        }
    }
}
