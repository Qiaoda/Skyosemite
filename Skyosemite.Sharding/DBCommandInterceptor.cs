using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Skyosemite.Sharding
{
     public class DBCommandInterceptor:DbCommandInterceptor
    {

        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
           
            try
            {
                base.ReaderExecuting(command, eventData, result);
                return result;
            }
            catch (Exception ex)
            {
                //LogUtils.Error(command.CommandText, ex, "sqllog");
                throw ex;
            }
        }

        public override object ScalarExecuted(
            DbCommand command,
            CommandExecutedEventData eventData,
            object result)
        {
            try
            {
                base.ScalarExecuted(command, eventData, result);
                return "";
            }
            catch (Exception ex)
            {
                //LogUtils.Error(command.CommandText, ex, "sqllog");
                throw ex;
            }
        }

        public override InterceptionResult<int> NonQueryExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<int> result)
        {
            try
            {
                base.NonQueryExecuting(command, eventData, result);
                return result;
            }
            catch (Exception ex)
            {
                //LogUtils.Error(command.CommandText, ex, "sqllog");
                throw ex;
            }
        }

        public override int NonQueryExecuted(
            DbCommand command,
            CommandExecutedEventData eventData,
            int result)
        {
            try
            {
                base.NonQueryExecuted(command, eventData, result);
                return result;
            }
            catch (Exception ex)
            {
                //LogUtils.Error(command.CommandText, ex, "sqllog");
                throw ex;
            }
        }
        public override InterceptionResult<object> ScalarExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<object> result)
        {
           
            try
            {
                base.ScalarExecuting(command, eventData, result);
                return result;
            }
            catch (Exception ex)
            {
                //LogUtils.Error(command.CommandText, ex, "sqllog");
                throw ex;
            }
        }

        public override DbDataReader ReaderExecuted(
            DbCommand command,
            CommandExecutedEventData eventData,
            DbDataReader result)
        {
            try
            {
                base.ReaderExecuted(command, eventData, result);
                return result;
            }
            catch (Exception ex)
            {
                //LogUtils.Error(command.CommandText, ex, "sqllog");
                throw ex;
            }
        }
    }
}
