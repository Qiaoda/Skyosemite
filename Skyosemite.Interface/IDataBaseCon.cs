using System;
using System.Collections.Generic;
using System.Text;
using Skyosemite.Util;

namespace Skyosemite.Interface
{
    public interface IDataBaseCon
    {
        /// <summary>
        /// 获取数据库连接信息
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        DatabaseInfo GetConInfo(string storeId, string kind);
    }
}
