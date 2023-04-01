using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TournamentModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Represents the TournamentName
        /// </summary>
        public string TournamentName { get; set; }
        /// <summary>
        /// Represents the Entry Fee of the tournament
        /// </summary>
        public decimal EntryFee { get; set; }
        /// <summary>
        /// Represents the List of Teams in the Tournament
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
        /// <summary>
        /// Represent the Prize of the Tournament winner
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        /// <summary>
        /// Represent the Matchups in each round
        /// </summary>
        public List<List<MatchUpModel>> Rounds { get; set; } = new List<List<MatchUpModel>>();
    }
}
