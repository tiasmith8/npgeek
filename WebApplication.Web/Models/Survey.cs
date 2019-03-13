using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }

        [Required]
        [Display(Name="Favorite National Park")]
        public string ParkCode { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Your Name")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "State of residence")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Activity level")]
        public string ActivityLevel { get; set; }
    }
}
