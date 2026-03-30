using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }


        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.Sql)
            {
                // TODO - Set up the SQL Connector properly
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if (db == DatabaseType.TextFile)
            {
                // TODO - Set up the Text File Connection properly
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        // TODO - Make this method to return the correct connection string based on the name provided.
        public static string ConnectionString { get; set; }
    }
}
