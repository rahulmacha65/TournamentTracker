using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchUpEntryModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Represents a Team in the MatchUp
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// Represents the score of the team
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// Represents the Match up that this team came as winner
        /// </summary>
        public MatchUpModel  ParentMatchUp { get; set; }
    }
}
