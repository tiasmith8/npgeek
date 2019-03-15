using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Weather
    {
        /// <summary>
        /// Code which uniquely identifies a Park
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// The forecast day. Today is 1, tomorrow is 2, etc.
        /// </summary>
        public int FiveDayForecastValue { get; set; }

        /// <summary>
        /// The expected low temperature in degrees Fahrenheit
        /// </summary>
        public int Low { get; set; }

        /// <summary>
        /// The expected hight temperature in degrees Fahrenheit
        /// </summary>
        public int High { get; set; }

        /// <summary>
        /// The expected weather. Possible values are: sunny, partly cloudy, cloudy, rain, thunderstorms, snow
        /// </summary>
        public string Forecast { get; set; }
    }
}
