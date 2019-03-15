using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    public class WeatherSqlDAOTests : NPSqlDAOTests
    {
        [TestMethod]
        public void GetWeatherShouldReturnFiveWeatherForecasts()
        {
            // Arrange
            WeatherSqlDAO dao = new WeatherSqlDAO(ConnectionString);

            // Act
            var forecast = dao.GetWeather("ABC");
            int actualRowCount = forecast.Count;

            // Assert
            Assert.AreEqual(actualRowCount, 5);
        }
    }
}
