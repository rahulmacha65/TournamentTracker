using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PersonModel
    {
        /// <summary>
        /// Represents the Uniquely Generated Id for Person.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Represents the FirstName of TeamMember
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Represents the LastName of TeamMember
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Represents the Email of TeamMember
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Represents the PhoneNumber of TeamMember
        /// </summary>
        public string  CellPhoneNumber { get; set; }
        public string FullName
        {
            get {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
