using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Survey
    {
        /// <summary>
        /// Number that uniquely identifies a Survey
        /// </summary>
        public int SurveyId { get; set; }

        /// <summary>
        /// Code that uniquely identifies a Park
        /// </summary>
        [Required(ErrorMessage ="Must select valid park.")]
        [Display(Name="Favorite National Park")]
        public string ParkCode { get; set; }

        /// <summary>
        /// Email Address of Surveyor
        /// </summary>
        [Required(ErrorMessage = "Must submit valid email address.")]
        [EmailAddress]
        [Display(Name = "Your email")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// State of residence of Surveyor
        /// </summary>
        [Required(ErrorMessage = "Must select a state.")]
        [Display(Name = "State of residence")]
        public string State { get; set; }

        /// <summary>
        /// Name of Surveyor
        /// </summary>
        [Required(ErrorMessage = "Must select an activity.")]
        [Display(Name = "Activity level")]
        public string ActivityLevel { get; set; }
    }
}
