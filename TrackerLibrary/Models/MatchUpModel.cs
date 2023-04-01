using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchUpModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Represents the List of MatchUp Entries
        /// </summary>
        public List<MatchUpEntryModel> Entries { get; set; }
        /// <summary>
        /// Represents the winner in the matchup
        /// </summary>
        public TeamModel Winner { get; set; }
        /// <summary>
        /// Represents the match up round
        /// </summary>
        public int MatchupRound { get; set; }

    }
}
