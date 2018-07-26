using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Common.Util
{
    public interface IDbDocument
    {
        object Id
        {
            get;
            set;
        }

        string type
        {
            get;
            set;
        }

    }
}
