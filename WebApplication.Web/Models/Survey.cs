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
        /// Gets or sets number that uniquely identifies a Survey
        /// </summary>
        public int SurveyId { get; set; }

        /// <summary>
        /// Gets or sets code that uniquely identifies a Park
        /// </summary>
        [Required(ErrorMessage ="Must select valid park.")]
        [Display(Name="Favorite National Park")]
        public string ParkCode { get; set; }

        /// <summary>
        /// Gets or sets email Address of Surveyor
        /// </summary>
        [Required(ErrorMessage = "Must submit valid email address.")]
        [EmailAddress]
        [Display(Name = "Your email")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets state of residence of Surveyor
        /// </summary>
        [Required(ErrorMessage = "Must select a state.")]
        [Display(Name = "State of residence")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets name of Surveyor
        /// </summary>
        [Required(ErrorMessage = "Must select an activity.")]
        [Display(Name = "Activity level")]
        public string ActivityLevel { get; set; }
    }
}
