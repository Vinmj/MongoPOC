using DatabaseAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Common.Util
{
    public class DatabaseContext
    {

        public DatabaseContext()
        {
        }

        public IBasicLookup BasicLookup
        {
            get;
            set;
        }

        public IDBAggregation AggregationLookup
        {
            get;
            set;
        }

        public IDBGraphLookup GraphLookup
        {
            get;
            set;
        }
    }
}
