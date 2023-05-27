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
        public List<MatchUpEntryModel> Entries { get; set; }=new List<MatchUpEntryModel>();
        /// <summary>
        /// ID generated in DB to identify the winner in the matchup
        /// </summary>
        public int WinnerId { get; set; }
        /// <summary>
        /// Represents the winner in the matchup
        /// </summary>
        public TeamModel Winner { get; set; }
        /// <summary>
        /// Represents the match up round
        /// </summary>
        public int MatchupRound { get; set; }
        public string DisplayName
        {
            get
            {
                string output = "";
                foreach(MatchUpEntryModel me in Entries)
                {
                    if (me.TeamCompeting!=null)
                    {
                        if (output.Length == 0)
                        {
                            output = me.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += $" vs. {me.TeamCompeting.TeamName}";
                        }
                    }
                    else
                    {
                        output = "Matchup Not Yet Determined";
                        break;
                    }
                }
                return output;
            }
        }

    }
}
