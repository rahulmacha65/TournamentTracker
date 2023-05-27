using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public const string PrizesFile = "PrizeModels.csv";
        public const string PeopleFile = "PersonModel.csv";
        public const string TeamFile = "TeamModel.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchupEntryFile = "MatchupEntryModel.csv";
        public static IDataConnection Connection { get; private set; }
        public static void InitilizeConnections(DataBaseTypes db)
        {
            switch (db)
            {
                case DataBaseTypes.sql:
                    SqlConnector con = new SqlConnector();
                    Connection = con;
                    break;
                case DataBaseTypes.Textfile:
                    TextConnector text = new TextConnector();
                    Connection = text;
                    break;
            }
        }
        public static string CnnString(string cnnName)
        {
        
            return ConfigurationManager.ConnectionStrings[cnnName].ConnectionString;
            
        }

        public static string SenderEmail(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
