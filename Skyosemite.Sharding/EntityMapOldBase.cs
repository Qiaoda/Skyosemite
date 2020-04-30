using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Skyosemite.Sharding
{
    public class EntityMapOldBase<OldTEntity> : IEntityTypeConfiguration<OldTEntity> where OldTEntity : class
    {
        public EntityMapOldBase() : base()
        {
        }

        public void Configure(EntityTypeBuilder<OldTEntity> builder)
        {
           
        }
    }
}
