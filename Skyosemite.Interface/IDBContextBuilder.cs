using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Skyosemite.Util;

namespace Skyosemite.Interface
{
    public interface IDBContextBuilder
    {
        /// <summary>
        /// 组装DbContext
        /// </summary>
        /// <returns>DbContext</returns>
        DbContext BuildDbContext();
    }
}
