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
        public void AddNewParkShouldReturnThePark()
        {
            //Arrange - Create a new park to test.
            Park park = new Park();
            park.ParkName = "Wild World";
            park.YearFounded = 1982;
            park.State = "MD";
            park.ParkDescription = "A really cool park.";
            park.ParkCode = "WWP";
            park.NumberOfCampsites = 0;
            park.NumberOfAnimalSpecies = 0;
            park.MilesOfTrail = 12;
            park.InspirationalQuote = "Once you do it, then it's done!";
            park.InspirationalQuoteSource = "A wise person";
            park.EntryFee = 25;
            park.ElevationInFeet = 25;
            park.Climate = "Awesome";
            park.AnnualVisitorCount = 2;
            park.Acreage = 12;

            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);
            int startingRowCount = GetRowCount("park");

            //Act - get the newly created park by ID.
            dao.GetPark("WWP");
            int endingRowCout = GetRowCount("park");

            //Assert
            Assert.AreEqual(startingRowCount + 1, endingRowCout);

        }
    }
}
