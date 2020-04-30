using MySql.Data.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Skyosemite.Sharding
{
    public  class DbConfiguration :ConfigurationSection
    {
        public DbConfiguration()
        {
            
            
           this.WithUseRelationalNulls(false);
            this.AddInterceptor(new DBCommandInterceptor());
        }
    }
}
