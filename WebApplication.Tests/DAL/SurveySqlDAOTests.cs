using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class SurveySqlDAOTests : NPSqlDAOTests
    {
        [TestMethod]
        public void GetAllSurveysShouldReturnOneSurvey()
        {
            // Arrange
            SurveySqlDAO dao = new SurveySqlDAO(ConnectionString);

            // Act - List of surveys should return 1 survey created in test data setup
            IList<SurveyResults> listOfSurveys = dao.GetAllSurveys();

            // Assert - should return one survey
            Assert.AreEqual(listOfSurveys.Count, 1);
        }
    }
}
