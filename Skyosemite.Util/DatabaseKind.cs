using System;
using System.Collections.Generic;
using System.Text;

namespace Skyosemite.Util
{
    /// <summary>
    /// 数据库业务类型
    /// </summary>
    public enum DatabaseKind
    {
        /// <summary>
        /// 默认数据库链接类型(兼容老链接,主库)
        /// </summary>
        EntityContext = 0,
        /// <summary>
        /// 入库业务数据库（预留）
        /// </summary>
        ReceiveSheet = 1,
        /// <summary>
        /// 调拨业务数据库（预留）
        /// </summary>
        Allocation = 2,
        /// <summary>
        /// 调整单业务数据库（预留）
        /// </summary>
        ChangeStock = 3,
        /// <summary>
        /// 盘点业务数据库（预留）
        /// </summary>
        Inventory = 4,
        /// <summary>
        /// 只读库一
        /// </summary>
        DbReadOne = 5,
        /// <summary>
        /// 只读库二
        /// </summary>
        DbReadTwo = 6,
    }
}
