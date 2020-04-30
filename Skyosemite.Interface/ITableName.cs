using System;
using System.Collections.Generic;
using System.Text;

namespace Skyosemite.Interface
{
    public interface ITableName
    {
        string[] GetTableName(string kind, string entityName, string hospitalId, string id);
    }
}
