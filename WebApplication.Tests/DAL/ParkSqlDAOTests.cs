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

            // int endingRowCount = GetRowCount("park");
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

            // Assert
            Assert.AreEqual("Kings Dominion", park.ParkName);
        }
    }
}
