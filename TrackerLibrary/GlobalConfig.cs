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
    }
}
