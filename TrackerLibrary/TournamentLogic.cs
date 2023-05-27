using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        // Order the list randomly of teams
        // Check the it is find or need any byes
        // Create our first round of matchup
        // Create every round after that 

        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizeTeams = RandomizeTeamOrder(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizeTeams.Count);
            int byes = NoofByes(rounds,randomizeTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes, randomizeTeams));

            CreateOtherRounds(model, rounds);
        }
        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }
        private static int FindNumberOfRounds(int teamsCount)
        {
            int output = 1;
            int val = 2;
            while (val < teamsCount)
            {
                output+=1;
                val *= 2;
            }
            return output;
        }
        private static int NoofByes(int rounds,int numberOfTeams)
        {
            int output = 0;
            int totalTeams = 1;
            for (int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }
            output = totalTeams-numberOfTeams;
            return output;
        }
        private static List<MatchUpModel> CreateFirstRound(int numberofByes,List<TeamModel> teams)
        {
            List<MatchUpModel> output = new List<MatchUpModel>();
            MatchUpModel matchUpModel = new MatchUpModel();
            foreach (TeamModel team in teams)
            {   
                matchUpModel.Entries.Add(new MatchUpEntryModel() { TeamCompeting = team });
                if(numberofByes > 0 || matchUpModel.Entries.Count > 0)
                {
                    numberofByes=numberofByes > 0? numberofByes -= 1:numberofByes;
                    matchUpModel.MatchupRound = 1;
                    output.Add(matchUpModel);
                    matchUpModel = new MatchUpModel();
                }
            }
            return output;
        }
        private static void CreateOtherRounds(TournamentModel model,int rounds)
        {
            int round = 2;
            List<MatchUpModel> previousRound = model.Rounds[0];
            List<MatchUpModel> currRounds = new List<MatchUpModel>();
            MatchUpModel currMatchup = new MatchUpModel();
            while (round <= rounds)
            {
                foreach(MatchUpModel match in previousRound)
                {
                    currMatchup.Entries.Add(new MatchUpEntryModel { ParentMatchUp = match });
                    if(currMatchup.Entries.Count > 1)
                    { 
                        currMatchup.MatchupRound = round;
                        currRounds.Add(currMatchup);
                        currMatchup = new MatchUpModel();
                    }
                }
                model.Rounds.Add(currRounds);
                previousRound = currRounds;
                currRounds = new List<MatchUpModel>();
                round += 1;
            }

        }
        
    }
}
