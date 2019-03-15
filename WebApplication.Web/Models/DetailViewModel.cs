using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class DetailViewModel
    {
        /// <summary>
        /// Gets or sets Park with all details to be shown on page
        /// </summary>
        public Park Park { get; set; }

        /// <summary>
        /// Gets or sets 5-Day forecast for park to be displayed on page
        /// </summary>
        public IList<Weather> Forecast { get; set; }
    }
}
