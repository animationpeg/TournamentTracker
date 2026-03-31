using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one person.
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// The unique identifier of the person.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// The first name of the person.
        /// </summary>
        public string FirstName{ get; set; }

        /// <summary>
        /// The last name of the person.
        /// </summary>
        public string LastName{ get; set; }

        /// <summary>
        /// The primary email address of the person.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The primary phone number of the person.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
