using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Park
    {
        /// <summary>
        /// Code that uniquely identifies Park
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Name of Park
        /// </summary>
        public string ParkName { get; set; }

        /// <summary>
        /// State within which the Park is located
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Total surface area of Park in acres
        /// </summary>
        public int Acreage { get; set; }

        /// <summary>
        /// Average elevation above sea level of Park in feet
        /// </summary>
        public int ElevationInFeet { get; set; }

        /// <summary>
        /// Total length of hiking trails in miles
        /// </summary>
        public double MilesOfTrail { get; set; }

        /// <summary>
        /// Number of campsites within the Park
        /// </summary>
        public int NumberOfCampsites { get; set; }

        /// <summary>
        /// Climate of Park
        /// </summary>
        public string Climate { get; set; }

        /// <summary>
        /// Year in which the Park was founded
        /// </summary>
        public int YearFounded { get; set; }

        /// <summary>
        /// Average annual visitors
        /// </summary>
        public int AnnualVisitorCount { get; set; }

        /// <summary>
        /// Quote related to the Park
        /// </summary>
        public string InspirationalQuote { get; set; }

        /// <summary>
        /// Source of Quote
        /// </summary>
        public string InspirationalQuoteSource { get; set; }

        /// <summary>
        /// Short description of Park
        /// </summary>
        public string ParkDescription { get; set; }

        /// <summary>
        /// Fee required for entry to Park
        /// </summary>
        public int EntryFee { get; set; }

        /// <summary>
        /// Number of species native to Park
        /// </summary>
        public int NumberOfAnimalSpecies { get; set; }
    }
}
