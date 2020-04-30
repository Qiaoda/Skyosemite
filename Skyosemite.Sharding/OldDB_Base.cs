using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Skyosemite.Sharding
{
    public class OldDB_Base<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
           
        }
    }
}
