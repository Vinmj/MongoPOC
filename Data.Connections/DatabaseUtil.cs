using DataAccess;
using DatabaseAPI;
using DB.Common.Util;
using System;

namespace Data.Connections
{
    public class DatabaseUtil //Singleton
    {
        //Singleton class to handle connections.

        public DatabaseContext GetDBContext(string tenantID)
        {
            IBasicLookup result = new BasicLookupAPI();
            result.Connect();
            DatabaseContext provider = new DatabaseContext();
            provider.BasicLookup = result;
            provider.GraphLookup = new GraphLookup();
            provider.AggregationLookup = new AggregationLookup();
            return (provider);
        }
    }
}
