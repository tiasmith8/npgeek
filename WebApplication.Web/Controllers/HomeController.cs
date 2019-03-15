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
        private readonly IParkDAO parkDAO;
        private readonly IWeatherDAO weatherDAO;
        private readonly ISurveyDAO surveyDAO;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// Creates a new home controller using dependency injection to allow access to data
        /// </summary>
        /// <param name="parkDAO">An object able to receive Park data</param>
        /// <param name="weatherDAO">An object able to receive Weather data</param>
        /// <param name="surveyDAO">An object able to receive/report survey data</param>
        public HomeController(IParkDAO parkDAO, IWeatherDAO weatherDAO, ISurveyDAO surveyDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
            this.surveyDAO = surveyDAO;
        }

        // /Home/Index shows a list of parks with short descriptions
        public IActionResult Index()
        {
            IList<Park> parks = this.parkDAO.GetParks();

            return this.View(parks);
        }

        // /Home/Detail shows additional information for a particular park including a 5-day forecast
        [HttpGet]
        public IActionResult Detail(string parkCode)
        {
            DetailViewModel dvm = new DetailViewModel() { park = this.parkDAO.GetPark(parkCode), forecast = this.weatherDAO.GetWeather(parkCode) };

            return this.View(dvm);
        }

        // /Home/Survey Get gives a description of surveys and allows user to complete survey form
        [HttpGet]
        public IActionResult Survey()
        {
            // Get a list of park codes and names to send to the view to display in dropdown
            IList<Park> parks = this.parkDAO.GetParks();

            // Send the View a list of parks
            this.ViewData["ParkList"] = parks;

            // Pass in a list of parks
            return this.View();
        }

        // ?Home/Survey Post is called once a user submits a survey. Controller determines whether
        //              survey requirements are met and redirects user appropriately
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Survey(Survey survey)
        {
            // If the form was completely properly then Redirect user to the survey results page
            if (this.ModelState.IsValid)
            {
                // Pass in the survey user filled out to method to save data to database.
                bool surveySubmitSuccessful = this.surveyDAO.SubmitSurvey(survey);

                // Send to a survey results page with list of survey results
                return this.RedirectToAction("SurveyResults");
            }

            // Form is invalid, send user input back into the form with errors and have them try again
            else
            {
                // Get a list of park codes and names to send to the view to display in dropdown
                IList<Park> parks = this.parkDAO.GetParks();

                // Send the View a list of parks
                this.ViewData["ParkList"] = parks;

                return this.View(survey);
            }
        }

        // /Home/SurveyResults User is shown how many surveys are completed for each park that has completed surveys
        [HttpGet]
        public IActionResult SurveyResults()
        {
            IList<SurveyResults> surveys = this.surveyDAO.GetAllSurveys();
            return this.View(surveys);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
