using System;
using System.Collections.Generic;

namespace Multiton
{
    public class DbPoolConnection
    {
        // static memory to save instances
        private static Dictionary<int, DbPoolConnection> instances = new Dictionary<int, DbPoolConnection>();
        private DbConnection dbConnection;
        public const string defaultConnectionString = "Standard-Connection-String";

        private DbPoolConnection()
        {
            dbConnection = new DbConnection(defaultConnectionString);
            dbConnection.Open();
        }

        public DbConnection getDatabaseConnection()
        {
            return dbConnection;
        }

        // retrieve instance of DbPoolConnection
        public static DbPoolConnection getInstance(int key)
        {
            lock (instances)
            {
                DbPoolConnection instance = null;
                if(!instances.ContainsKey(key))
                {
                    instance = new DbPoolConnection();
                    instances.Add(key, instance);
                }
                else
                {
                    instance = instances[key];
                }
                return instance;
            }
        }
    }
}
