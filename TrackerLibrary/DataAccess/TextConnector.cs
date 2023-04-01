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
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModel.csv";
        private const string TeamFile = "TeamModel.csv";

        /// <summary>
        /// Saves the new prize data  to Text file
        /// </summary>
        /// <param name="model">prize information</param>
        /// <returns>prize informationa. including unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //Load text file. Convert the text to List<PrizeModel>.
            List<PrizeModel> prizes =  PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

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
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> persons = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();

            int currentId = 1;
            if (persons.Count > 0)
            {
                currentId = persons.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            persons.Add(model);
            persons.SaveToPersonFile(PeopleFile);
            return model;
        }

        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModel(PeopleFile);
            int currentId = 1;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            teams.Add(model);
            teams.SaveToTeamFile(TeamFile);
            return model;
        }

        public List<TeamModel> GetTeam_All()
        {
            return TeamFile.FullFilePath().LoadFile().ConvertToTeamModel(PeopleFile);
        }
    }
}
