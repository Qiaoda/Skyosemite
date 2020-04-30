using System;
using System.Collections.Generic;
using System.Text;

namespace Skyosemite.Sharding
{
    [AttributeUsage(AttributeTargets.Class)]
    public  class MapToAttribute : Attribute
    {
        public string TableName { get; set; }

        public MapToAttribute(string tableName)
        {
            TableName = tableName;
        }
    }
}
