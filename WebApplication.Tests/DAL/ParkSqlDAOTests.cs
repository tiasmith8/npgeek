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
            //Arrange
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);

            // Should return just the park created in setting up test data
            IList<Park> NumOfParks = dao.GetParks();
            //int endingRowCount = GetRowCount("park");
            int actualRowCount = NumOfParks.Count;

            //Assert
            Assert.AreEqual(actualRowCount, 1);
        }
    }
}
