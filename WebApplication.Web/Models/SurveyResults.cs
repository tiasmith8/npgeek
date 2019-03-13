using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class SurveyResults
    {
        /// <summary>
        /// Number of parks that are a favorite in the survey.
        /// </summary>
        public int ParksCount { get; set; }

        /// <summary>
        /// Name of the park that is a favorite.
        /// </summary>
        public string ParkName { get; set; }

        /// <summary>
        /// The code of the park to get a picture for the view
        /// </summary>
        public string ParkCode { get; set; }
    }
}
