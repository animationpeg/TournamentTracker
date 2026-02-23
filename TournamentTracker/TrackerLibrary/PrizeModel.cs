using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents the details of a prize awarded for a specific place in a competition or tournament.
    /// </summary>
    public class PrizeModel
    {
        /// <summary>
        /// Represents the place number that corresponds to the prize (e.g., 1 for first place, 2 for second place, etc.).
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// Represents the place name that corresponds to the prize (e.g., "First Place", "Runner's Up", etc.).
        /// </summary>
        public string PlaceName{ get; set; }

        /// <summary>
        /// Represents the amount of money awarded for this prize. This is used when the prize is a fixed amount.
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// Represents the percentage of the total prize pool awarded for this prize. This is used when the prize is a percentage of the total pool.
        /// </summary>
        public decimal PrizePercentage { get; set; }
    }
}
