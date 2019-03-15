using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class ParkSqlDAOTests : NPSqlDAOTests
    {

        [TestMethod]
        public void GetAllParksShouldReturnOnePark()
        {
            // Arrange
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);

            // Act - Should return just the park created in setting up test data
            IList<Park> NumOfParks = dao.GetParks();
            int actualRowCount = NumOfParks.Count;

            // Assert
            Assert.AreEqual(actualRowCount, 1);
        }

        [TestMethod]
        public void GetParkByIdShouldReturnCreatedPark()
        {
            // Arrange
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);

            // Act - Get the park created in test data
            Park park = dao.GetPark("ABC");

            // Assert - The park name should be the same as what was created in test-script.sql
            Assert.AreEqual("Kings Dominion", park.ParkName, "Park name returned should be Kings Dominion.");

            // The rest of the data should returned same as test data in test-script.sql
            Assert.AreEqual("VA", park.State, "State returned should be VA.");
            Assert.AreEqual(1982, park.YearFounded, "Year founded should return 1982.");
            Assert.AreEqual(12, park.AnnualVisitorCount, "Annual Visitor count should be returned as 12.");
        }
    }
}
