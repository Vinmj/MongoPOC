﻿using DatabaseAPI;
using DB.Common.Util;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;



namespace DataAccess
{
    public class AggregationLookup : IDBAggregation
    {
        private readonly string connectionString = "";
        private readonly string dbName = "test";
        private IMongoDatabase database = null;


        public void SampleMethod1<T>(string input)
        {

        }
    }
}
