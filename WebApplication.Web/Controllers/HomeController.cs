using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IParkDAO parkDAO, IWeatherDAO weatherDAO, ISurveyDAO surveyDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
            this.surveyDAO = surveyDAO;
        }

        private IParkDAO parkDAO;
        private IWeatherDAO weatherDAO;
        private ISurveyDAO surveyDAO;

        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetParks();

            return View(parks);
        }       

        [HttpGet]
        public IActionResult Detail(string parkCode)
        {
            DetailViewModel dvm = new DetailViewModel() { park = parkDAO.GetPark(parkCode), forecast = weatherDAO.GetWeather(parkCode) };

            return View(dvm);
        }

        [HttpGet]
        public IActionResult Survey()
        {
            // Get a list of park codes and names to send to the view to display in dropdown
            IList<Park> parks = parkDAO.GetParks();

            // Send the View a list of parks
            ViewData["ParkList"] = parks;

            // Pass in a list of parks
            return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
