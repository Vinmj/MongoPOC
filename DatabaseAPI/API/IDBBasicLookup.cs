using System;
using System.Collections.Generic;

namespace DatabaseAPI
{
    public interface IBasicLookup
    {

        void Connect();

        void InsertMultipleRecords<T>(IList<T> inputList);

        void InsertSingleRecord<T>(T input);

        T GetRecordFromID<T>(string id);


    }
}
