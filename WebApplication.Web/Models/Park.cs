using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Park
    {
        /// <summary>
        /// Gets or sets code that uniquely identifies Park
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Gets or sets name of Park
        /// </summary>
        public string ParkName { get; set; }

        /// <summary>
        /// Gets or sets state within which the Park is located
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets total surface area of Park in acres
        /// </summary>
        public int Acreage { get; set; }

        /// <summary>
        /// Gets or sets average elevation above sea level of Park in feet
        /// </summary>
        public int ElevationInFeet { get; set; }

        /// <summary>
        /// Gets or sets total length of hiking trails in miles
        /// </summary>
        public double MilesOfTrail { get; set; }

        /// <summary>
        /// Gets or sets number of campsites within the Park
        /// </summary>
        public int NumberOfCampsites { get; set; }

        /// <summary>
        /// Gets or sets climate of Park
        /// </summary>
        public string Climate { get; set; }

        /// <summary>
        /// Gets or sets year in which the Park was founded
        /// </summary>
        public int YearFounded { get; set; }

        /// <summary>
        /// Gets or sets average annual visitors
        /// </summary>
        public int AnnualVisitorCount { get; set; }

        /// <summary>
        /// Gets or sets quote related to the Park
        /// </summary>
        public string InspirationalQuote { get; set; }

        /// <summary>
        /// Gets or sets source of Quote
        /// </summary>
        public string InspirationalQuoteSource { get; set; }

        /// <summary>
        /// Gets or sets short description of Park
        /// </summary>
        public string ParkDescription { get; set; }

        /// <summary>
        /// Gets or sets fee required for entry to Park
        /// </summary>
        public int EntryFee { get; set; }

        /// <summary>
        /// Gets or sets number of species native to Park
        /// </summary>
        public int NumberOfAnimalSpecies { get; set; }
    }
}
