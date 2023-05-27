using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelper
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)//PrizeMode.csv
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();

        }
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();
            foreach(string line in lines)
            {
                string[] cols = line.Split(',');

                PrizeModel p = new PrizeModel();
                p.ID = Int32.Parse(cols[0]);
                p.PlaceNumber = Int32.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PriceAmount = Decimal.Parse(cols[3]);
                p.PricePercentage = Double.Parse(cols[4]);
                output.Add(p);
            }
            return output;
        }
        public static void SaveToPrizeFile(this List<PrizeModel> models,string fileName)
        {
            List<string> lines = new List<string>();
            foreach(PrizeModel p in models)
            {
                lines.Add($"{p.ID},{p.PlaceNumber},{p.PlaceName},{p.PriceAmount},{p.PricePercentage}");

            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
        public static List<PersonModel> ConvertToPersonModel(this List<string> lines) 
        {
            List<PersonModel> model = new List<PersonModel>();
            foreach(string line in lines)
            {
                string[] cols = line.Split(',');
                PersonModel p = new PersonModel();
                p.Id = Int32.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.Email = cols[3];
                p.CellPhoneNumber = cols[4];
                model.Add(p);
            }
            return model;
            
        }
        public static void SaveToPersonFile(this List<PersonModel> models,string fileName)
        {
            List<string> lines = new List<string>();
            foreach(PersonModel p in models)
            {
                lines.Add($"{ p.Id },{ p.FirstName },{ p.LastName },{ p.Email },{ p.CellPhoneNumber }");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static List<TeamModel> ConvertToTeamModel(this List<string> lines,string peopleFileName)
        {
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModel();
            foreach(string line in lines)
            {
                string[] cols = line.Split(',');
                TeamModel tm = new TeamModel();
                tm.Id = Int32.Parse(cols[0]);
                tm.TeamName = cols[1];
                string[] personIds = cols[2].Split('|');
                foreach(string id in personIds)
                {
                    tm.TeamMembers.Add(people.Where(x => x.Id == Int32.Parse(id)).FirstOrDefault());
                }
                output.Add(tm);
            }
            return output;
        }
        public static void SaveToTeamFile(this List<TeamModel> models,string fileName)
        {
            List<string> lines = new List<string>();
            foreach(TeamModel tm in models)
            {
                lines.Add($"{tm.Id },{ tm.TeamName }, { ConvertPeopleListToString(tm.TeamMembers)}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static List<TournamentModel> ConvertToTournamentModels(this List<string> lines,string fileName,string peopleFileName,string prizeFile)
        {
            //file will be saved like Id,TournamentName,EntryFee,Id|Id|Id - Team Entries, Rounds- Id^Id^Id|Id^Id^Id|Id^Id^Id
            List<TournamentModel> tournamentModels = new List<TournamentModel>();
            List<TeamModel> teams = fileName.FullFilePath().LoadFile().ConvertToTeamModel(peopleFileName);
            List<PrizeModel> prize = prizeFile.FullFilePath().LoadFile().ConvertToPrizeModels();
            List<MatchUpModel> matchUpModels = peopleFileName.FullFilePath().LoadFile().ConvertToMatchupModels();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                TournamentModel tm = new TournamentModel();
                tm.Id = Int32.Parse(cols[0]);
                tm.TournamentName=cols[1];
                tm.EntryFee = Decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split('|');
                foreach (string id in teamIds)
                {
                    tm.EnteredTeams.Add(teams.Where(x => x.Id == Int32.Parse(id)).FirstOrDefault());
                }
                string[] prizeIds = cols[4].Split('|');
                foreach(string id in prizeIds)
                {
                    tm.Prizes.Add(prize.Where(x=>x.ID== Int32.Parse(id)).FirstOrDefault());
                }

                //Capture Round Information
                string[] rounds = cols[5].Split('|');
                
                foreach(string round in rounds)
                {
                    string[] matchups = round.Split('^');
                    List<MatchUpModel> ms = new List<MatchUpModel>();
                    foreach (string id in matchups)
                    {
                        ms.Add(matchUpModels.Where(x => x.Id == Int32.Parse(id)).FirstOrDefault());
                    }
                    tm.Rounds.Add(ms);
                }
                tournamentModels.Add(tm);
            }
            return tournamentModels;
        }        
        public static void SaveToTournamentFile(this List<TournamentModel> models,string fileName)
        {
            List<string> lines = new List<string>();
            foreach (TournamentModel tm in models)
            {
                lines.Add($"{tm.Id},{tm.TournamentName},{ tm.EntryFee }, {ConvertTeamListToString(tm.EnteredTeams) },{ConvertPrizeListToString(tm.Prizes) },{ConvertRoundListToString(tm.Rounds)}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
        public static void SaveRoundsToFile(this TournamentModel model, string matchupFile, string matchupEntryFile)
        {
            //Loop through each round
            //Loop through each Matchup
            //Get the Id for the new matchup and save the records
            //Loop through each Entry, get the id, and save the entry

            foreach(List<MatchUpModel> round in model.Rounds)
            {
                foreach(MatchUpModel matchup in round)
                {
                    //Load all the matchup from file 
                    //Get the top Id and add one
                    //Store the Id
                    //Save the matchup record
                    matchup.SaveMatchupToFile(matchupFile, matchupEntryFile);
                    
                }
            }
        }
        private static List<MatchUpEntryModel> ConvertStringToMatchupEntryModel(string input)
        {
            string[] ids = input.Split('|');
            List<MatchUpEntryModel> output = new List<MatchUpEntryModel>();
            List<string> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile();

            List<string> matchingEntries = new List<string>();

            foreach(string id in ids)
            {
                foreach(string entry in entries)
                {
                    string[] cols = entry.Split(',');
                    if (cols[0] == id)
                    {
                        matchingEntries.Add(entry);
                    }
                }
            }
            output = matchingEntries.ConvertToMatchupEntryModels();
            return output;
        }
        private static TeamModel LookupTeamById(int id)
        {
            List<string> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile();

            foreach(string team in teams)
            {
                string[] cols = team.Split(',');
                if (cols[0] == id.ToString())
                {
                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                    return matchingTeams.ConvertToTeamModel(GlobalConfig.PeopleFile).First();

                }
            }
            return null;
        }
        private static MatchUpModel LookupMatchById(int id)
        {
            List<string> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile();

            foreach(string matchup in matchups)
            {
                string[] cols = matchup.Split(',');
                if (cols[0] == id.ToString())
                {
                    List<string> matchingMatchups = new List<string>();
                    matchingMatchups.Add(matchup);
                    return matchingMatchups.ConvertToMatchupModels().First();
                }
            }
            return null;
        }
        public static List<MatchUpModel> ConvertToMatchupModels(this List<string> lines)
        {
            List<MatchUpModel> output = new List<MatchUpModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                MatchUpModel p = new MatchUpModel();
                p.Id = Int32.Parse(cols[0]);
                p.Entries = ConvertStringToMatchupEntryModel(cols[1]);
                p.Winner = LookupTeamById(Int32.Parse(cols[2]));
                p.MatchupRound = Int32.Parse(cols[3]);
                
                output.Add(p);
            }
            return output;
        }
        public static void SaveMatchupToFile(this MatchUpModel matchup, string matchupFile, string matchupEntryFile)
        {
            List<MatchUpModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            int currentId = 0;
            if (matchups.Count > 0)
            {
                currentId = matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }
            matchup.Id = currentId;
            matchups.Add(matchup);

            foreach (MatchUpEntryModel entry in matchup.Entries)
            {
                entry.SaveEntryToFile(matchupEntryFile);
            }

            //save the file
            List<string> lines = new List<string>();
            foreach(MatchUpModel m in matchups)
            {
                string winner = (m.Winner != null) ? m.Winner.Id.ToString() : "";
                lines.Add($"{ m.Id },{ ConvertMatchupListToString(m.Entries) },{ winner },{m.MatchupRound}");
            }
            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);

        }
        private static string ConvertMatchupListToString(List<MatchUpEntryModel> entries)
        {
            string output = "";
            foreach (MatchUpEntryModel m in entries)
            {
                output += $"{m.Id} |";
            }
            output = (output != "") ? output.Substring(0, output.Length - 1) : "";
            return output;
        }

        public static List<MatchUpEntryModel> ConvertToMatchupEntryModels(this List<string> lines)
        {
            List<MatchUpEntryModel> output = new List<MatchUpEntryModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                MatchUpEntryModel p = new MatchUpEntryModel();
                p.Id = Int32.Parse(cols[0]);
                p.TeamCompeting = (cols[1].Length == 0) ? null : LookupTeamById(Int32.Parse(cols[1]));
                p.Score = Double.Parse(cols[2]);
                int parentId = 0;
                if (int.TryParse(cols[3],out parentId)){
                    p.ParentMatchUp = LookupMatchById(parentId);
                }
                else
                {
                    p.ParentMatchUp = null;
                }
                
                
                output.Add(p);
            }
            return output;
        }
        public static void SaveEntryToFile(this MatchUpEntryModel entry, string matchupEntryFile)
        {
            List<MatchUpEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

            int currentId = 1;

            if(entries.Count > 0)
            {
                currentId = entries.OrderByDescending(x => x.Id).First().Id + 1;
            }
            entry.Id = currentId;
            entries.Add(entry);
            //Save the file 
            List<string> lines = new List<string>();
            foreach (MatchUpEntryModel e in entries)
            {
                string parent = (e.ParentMatchUp != null) ? e.ParentMatchUp.Id.ToString() : "";
                string teamCompeting = (e.TeamCompeting != null) ? e.TeamCompeting.Id.ToString() : "";
                lines.Add($"{ e.Id },{teamCompeting}, { e.Score },{ parent }");
            }
            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);

        }
        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";
            foreach (PersonModel m in people)
            {
                output += $"{m.Id} |";
            }
            output = (output != "") ? output.Substring(0, output.Length - 1) : "";
            return output;
        }
        private static string ConvertTeamListToString(List<TeamModel> teams)
        {
            string output = "";
            foreach (TeamModel m in teams)
            {
                output += $"{m.Id} |";
            }
            output = (output != "") ? output.Substring(0, output.Length - 1) : "";
            return output;
        }
        private static string ConvertPrizeListToString(List<PrizeModel> prizes)
        {
            string output = "";
            foreach (PrizeModel m in prizes)
            {
                output += $"{m.ID} |";
            }
            output = (output != "") ? output.Substring(0, output.Length - 1) : "";
            return output;
        }
        private static string ConvertRoundListToString(List<List<MatchUpModel>> rounds)
        {
            string output = "";
            foreach (List<MatchUpModel> m in rounds)
            {
                output += $"{ConvertMatchupListToString(m)} |";
            }
            return output;
        }
        private static string ConvertMatchupListToString(List<MatchUpModel> matchUps)
        {
            string output = "";
            foreach (MatchUpModel m in matchUps)
            {
                output += $"{m.Id} ^";
            }
            output = (output != "") ? output.Substring(0, output.Length - 1) : "";
            return output;
        }
        
    }

}
