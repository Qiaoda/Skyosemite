using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyosemite.Sharding
{
    //[DbConfigurationType(typeof(DBConfiguration))]
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
            //options.GetExtension <>
            //this.Configuration.UseDatabaseNullSemantics = false;
            //this.Database.Log = (sqlString) =>
            //{
            //    LogUtils.Debug(sqlString, "sqllog");
            //};
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=10.1.4.86;user id=dev;password=hotwind@2015;persistsecurityinfo=True;database=swmsunit")
            .AddInterceptors(new DBCommandInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
