using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class DetailViewModel
    {
        /// <summary>
        /// Park with all details to be shown on page
        /// </summary>
        public Park park { get; set; }

        /// <summary>
        /// 5-Day forecast for park to be displayed on page
        /// </summary>
        public IList<Weather> forecast { get; set; }
    }
}
