using System;
using System.Collections.Generic;
using System.Text;

namespace Skyosemite.Interface
{
    /// <summary>
    /// 数据库链接信息
    /// </summary>
    public class DatabaseInfo
    {
        /// <summary>
        /// 数据库链接
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// 驱动
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string Schema { get; set; }
    }
}
