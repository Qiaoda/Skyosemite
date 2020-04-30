using Microsoft.EntityFrameworkCore;
using Skyosemite.Interface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using MySql.Data.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using Skyosemite.Util;

namespace Skyosemite.Sharding
{
    public class DBContextBuilder : DbContextOptions<ModelContext>, IDBContextBuilder
    {
        // 数据库客户端ProviderFactory
        private readonly DbProviderFactory _factory;
        // 连接字符串配置
        private readonly string _connection;
        private readonly string _schema;

        //延迟加载
        private bool _lazyLoadingEnabled;

        private string _storeId;
        private string _id;
        private int _kind;

        public static Assembly EntityAssembly { get; set; }

        public static ITableName ITableName { get; set; }

        public static IDataBaseCon IDataBaseCon { get; set; }

        protected virtual DatabaseInfo GetConInfo(string storeId, string kind)
        {
            return IDataBaseCon.GetConInfo(storeId, kind);
        }

        public DBContextBuilder(IMutableModel model)
        {


        }

        public DBContextBuilder(string storeId, DatabaseKind kind, string id = "", bool lazyLoadingEnabled = false)
        {
            _storeId = storeId;
            _id = id;
            _kind = (int)kind;
            var info = GetConInfo(storeId, ((int)kind).ToString());
            _connection = info.Connection;
            _schema = info.Schema;
            _factory = DbProviderFactories.GetFactory(info.ProviderName);
            _lazyLoadingEnabled = lazyLoadingEnabled;
        }

        #region Implementation of IDbContextBuilder<T>

        /// <summary>
        /// 组装DbContext
        /// </summary>
        /// <returns>DbContext</returns>
        public DbContext BuildDbContext()
        {
            // 关键代码
            var cn = _factory.CreateConnection();
            cn.ConnectionString = _connection;
            var entity = typeof(DBContextBuilder).GetMethod("Entity", new Type[] { });
            //DbCompiledModel compliedMode = null;
            Assembly assembly = EntityAssembly;
            var genericTypeList = assembly.GetTypes().Where(c =>
                !c.IsAbstract
                && c.BaseType != null
                && c.BaseType.IsGenericType
                && c.BaseType.GetGenericTypeDefinition() == typeof(EntityMapBase<>));
            var typeNameList = new List<string>();
            ///Map
            foreach (var type in genericTypeList)
            {
                string typeName = type.GetCustomAttribute<MapToAttribute>().TableName;
                typeNameList.Add(typeName);
                ///TODO:预留实现数据库分表策略,typeName,schema
                dynamic configurationInstance = Activator.CreateInstance(type, typeName, _schema);
                entity.MakeGenericMethod(type).Invoke(this, new object[] { });

            }
            ///MapOld
            foreach (var type in assembly.GetTypes().Where(c =>
                !c.IsAbstract
                && c.BaseType != null
                && c.BaseType.IsGenericType
                && c.BaseType.GetGenericTypeDefinition() == typeof(EntityMapOldBase<>))
            )
            {
                string typeName = type.GetCustomAttribute<MapToAttribute>().TableName;
                if (typeNameList.Contains(typeName))
                    continue;
                ///TODO:预留实现数据库分表策略,typeName,schema
                dynamic configurationInstance = Activator.CreateInstance(type, null);
                entity.MakeGenericMethod(type).Invoke(this, new object[] { });
            }
            return GenContext(this);
        }

        #endregion

        protected virtual DbContext GenContext(DbContextOptions<ModelContext> dbContextOptions)
        {
            return new ModelContext(dbContextOptions);
        }
      
    }
}
