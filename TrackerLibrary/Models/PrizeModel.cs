using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        /// <summary>
        /// The unique Identifier for prize
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Represents the Place Number like 1st ,2nd
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// Represents the PlaceName like champion, 1st runnerup
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// Represents the prize money for winners and other runnerups
        /// </summary>
        public decimal PriceAmount { get; set; }
        /// <summary>
        /// Represents the Percentage of the price to give winners and other runnerups
        /// </summary>
        public double PricePercentage { get; set; }
    }
}
