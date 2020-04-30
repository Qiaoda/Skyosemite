using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyosemite.Sharding
{
    public class EntityMapBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : DB_Base
    {
        string _tableName;
        string _schema;
        protected EntityMapBase(string tableName, string schema)
            : base()
        {
            _tableName = tableName;
            _schema = schema;
            //MapTable();
            MapId();
            MapVersion();
            MapProperties();
            MapAssociations();
        }

        ///// <summary>
        ///// 映射表
        ///// </summary>
        //protected virtual void MapTable()
        //{
        //    ToTable(_tableName, _schema);
        //}

        /// <summary>
        /// 映射标识
        /// </summary>
        protected virtual void MapId()
        {
            //HasKey(t => t.BillNo);
        }

        /// <summary>
        /// 映射乐观离线锁
        /// </summary>
        protected virtual void MapVersion()
        {
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected virtual void MapProperties()
        {
        }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected virtual void MapAssociations()
        {
        }

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
           builder.ToTable(_tableName,_schema);
        }

        /// <summary>
        /// 将配置添加到管理器
        /// </summary>
        /// <param name="registrar">配置管理器</param>
        //public void AddTo(ConfigurationRegistrar registrar)
        //{
        //    registrar.Add(this);
        //}

    }
}
