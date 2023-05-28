using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelper;

namespace TrackerLibrary
{
    public class TextConnector : IDataConnection
    {
        
        /// <summary>
        /// Saves the new prize data  to Text file
        /// </summary>
        /// <param name="model">prize information</param>
        /// <returns>prize informationa. including unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //Load text file. Convert the text to List<PrizeModel>.
            List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            //Find the MAX ID Add the new record with the new ID(MAX+1)
            int currentId = 1;
            if (prizes.Count>0)
            {
               currentId = prizes.OrderByDescending(x => x.ID).First().ID + 1;
            }
            model.ID= currentId;

            prizes.Add(model);

            //Convert the prizes to list<string>.
            //Save the List<string> to the Text File.
            prizes.SaveToPrizeFile(GlobalConfig.PrizesFile);

            return model;
        }

        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> persons = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();

            int currentId = 1;
            if (persons.Count > 0)
            {
                currentId = persons.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            persons.Add(model);
            persons.SaveToPersonFile(GlobalConfig.PeopleFile);
            return model;
        }

        public List<PersonModel> GetPerson_All()
        {
            return GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModel(GlobalConfig.PeopleFile);
            int currentId = 1;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            teams.Add(model);
            teams.SaveToTeamFile(GlobalConfig.TeamFile);
            return model;
        }

        public List<TeamModel> GetTeam_All()
        {
            return GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModel(GlobalConfig.PeopleFile);
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels(GlobalConfig.TeamFile, GlobalConfig.PeopleFile, GlobalConfig.PrizesFile);
            int currentId = 0;
            if(tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            model.SaveRoundsToFile(GlobalConfig.MatchupFile, GlobalConfig.MatchupEntryFile);

            tournaments.Add(model);
            tournaments.SaveToTournamentFile(GlobalConfig.TournamentFile);
            return model;
        }

        public List<TournamentModel> GetTournament_All()
        {
            return GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels(GlobalConfig.TeamFile, GlobalConfig.PeopleFile, GlobalConfig.PrizesFile);
        }

        public void UpdateMatchUpModel(MatchUpModel model)
        {
            throw new NotImplementedException();
        }

        public void CompleteTournament(TournamentModel model)
        {
            throw new NotImplementedException();
        }
    }
}
