using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Common.Util
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DBDocumentTypeName:Attribute
    {
        private string name;
        private string collectionName;

        public DBDocumentTypeName(string Name, string collectionName)
        {
            this.name = Name;
            this.collectionName = collectionName;
        }

        public virtual string Name
        {
            get { return name; }
        }

        public virtual string CollectionName
        {
            get { return collectionName; }
        }
    }
}
