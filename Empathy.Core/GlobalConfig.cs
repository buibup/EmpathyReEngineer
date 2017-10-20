using Empathy.Core.DataAccess;
using System.Configuration;

namespace Empathy.Core
{
    public class GlobalConfig
    {
        public static ICacheDataConnection CacheConnection { get; private set; }
        public static IPostgresDataConnection PostgresConnection { get; private set; }
        public static IMySqlDataConnection MySqlConnection { get; private set; }

        public static void DbConnections(DatabaseType db)
        {
            if(db == DatabaseType.Cache)
            {
                // TODO - Set up the Cache Connector properly
                CacheConnectorDapper cache = new CacheConnectorDapper();
                CacheConnection = cache;
            }
            else if(db == DatabaseType.Posgres)
            {
                // TODO - Set up the Postgres Connector properly
                PostgresDataConnector postgres = new PostgresDataConnector();
                PostgresConnection = postgres;
            }
            else if(db == DatabaseType.MySql)
            {
                // TODO - Set up the MySql Connector properly
                MySqlDataConnector mysql = new MySqlDataConnector();
                MySqlConnection = mysql;
            }
        }

        public static void InitializeConnectionsToDatabase(DatabaseAccess access)
        {
            if(access == DatabaseAccess.Dapper)
            {
                CacheConnectorDapper cache = new CacheConnectorDapper();
                CacheConnection = cache;
            }
            else if( access == DatabaseAccess.ADODotNet)
            {
                CacheConnectorADO cache = new CacheConnectorADO();
                CacheConnection = cache;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string AppString(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
