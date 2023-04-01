using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
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
        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";
            foreach(PersonModel m in people)
            {
                output += $"{m.Id} |";
            }
            output = (output!="")?output.Substring(0, output.Length - 1):"";
            return output;
        }
    }

}
