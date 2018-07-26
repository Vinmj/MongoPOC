using DatabaseAPI;
using DB.Common.Util;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;



namespace DataAccess
{
    public class BasicLookupAPI: IBasicLookup
    {
        private readonly string connectionString = "";
        private readonly string dbName = "test";
        private IMongoDatabase database = null;


        public BasicLookupAPI()
        {
            connectionString = "mongodb://gijomon:Tech*Blr1@cluster0-shard-00-00-ej4jh.mongodb.net:27017,cluster0-shard-00-01-ej4jh.mongodb.net:27017,cluster0-shard-00-02-ej4jh.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true";
        }

        public void Connect()
        {
            MongoClient mc = new MongoClient(connectionString);
            this.database = mc.GetDatabase(dbName);
            
            Console.WriteLine("Database connected");
        }

        public void InsertMultipleRecords<T>(IList<T> inputList)
        {
            string entityType = "";
            string collectionName = null;
            ReadDBMetadata<T>(out collectionName, out entityType);

            IMongoCollection<dynamic> collection = database.GetCollection<dynamic>(collectionName);
            for (int index = 0; index < inputList.Count; index++)
            {
                T param = inputList[index];
                IDbDocument item = (IDbDocument)param;
                item.type = entityType;
                collection.InsertOne(param);
            }
        }

        public void InsertSingleRecord<T>(T input)
        {
            string entityType = "";
            string collectionName = null;
            ReadDBMetadata<T>(out collectionName, out entityType);
            IDbDocument item = (IDbDocument)input;
            item.type = entityType;

            IMongoCollection<dynamic> collection = database.GetCollection<dynamic>(collectionName);
            collection.InsertOne(input);
        }

        public T GetRecordFromID<T>(string id)
        {

            T output = default(T);

            string entityType = "";
            string collectionName = null;
            ReadDBMetadata<T>(out collectionName, out entityType);
            
            BsonDocument filter = new BsonDocument("_t", entityType);
            IMongoCollection<BsonDocument> col = database.GetCollection<BsonDocument>(collectionName);
            List<BsonDocument> list = col.Find(filter).ToList();
            if (list == null || list.Count <= 0)
            {
                return (output);
            }
            output = BsonSerializer.Deserialize<T>(list[0]);
            return (output);
        }

        private void ReadDBMetadata<T>(out string collectionName, out string entityType)
        {
            collectionName = null;
            entityType = null;

            System.Reflection.MemberInfo info = typeof(T);
            foreach (DBDocumentTypeName attrib in info.GetCustomAttributes(true))
            {
                entityType = attrib.Name;
                collectionName = attrib.CollectionName;
                break;
            }

            if (collectionName==null|| entityType == null)
            {
                throw (new Exception("Undefined Collection name or Entity type"));
            }
        }

    }
}
