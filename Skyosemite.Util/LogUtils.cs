using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Skyosemite.Util
{
     /// <summary>
    /// 日志信息分级别操作
    /// </summary>
    public class LogUtils
    {
        /// <summary>
        /// 配置文件名
        /// </summary>
        public static string Configfilename = @"skyosemite.cfg.xml";

        /// <summary>
        /// 获得运行环境下的配置文件全路径
        /// </summary>
        /// <returns>运行环境下的配置文件全路径</returns>
        public static string GetConfigFileName() { return AppDomain.CurrentDomain.BaseDirectory + "\\" + Configfilename; }

        /// <summary>
        /// Log类所需要的配置文件里的节点名称
        /// </summary> 
        public static string Logconfigtag = @"log4net";
        /// <summary>
        /// 构造函数，从配置文件里读取相关信息
        /// </summary>
        static LogUtils()
        {
            var doc = new XmlDocument();
            var sXmlConfig = GetConfigFileName();
            if (System.IO.File.Exists(sXmlConfig))
            {
                doc.Load(sXmlConfig);
                var node = doc.SelectSingleNode("//" + Logconfigtag);
                if (node != null)
                    log4net.Config.XmlConfigurator.Configure((XmlElement)node);
                else
                    log4net.Config.XmlConfigurator.Configure();
            }
            else
                log4net.Config.XmlConfigurator.Configure();
        }
        /// <summary>
        /// 一般信息.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logger">logger名称,默认为"loginfo"</param>
        public static void Info(object message, string logger = "loginfo")
        {
            var log = LogManager.GetLogger(logger);

            log.Info(message);
        }
        /// <summary>
        /// 一般信息.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="logger">logger名称,默认为"loginfo"</param>
        public static void Info(object message, Exception exception, string logger = "loginfo")
        {
            var log = LogManager.GetLogger(logger);

            log.Info(message, exception);
        }
        /// <summary>
        /// 一般错误.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logger">logger名称,默认为"logerror"</param>
        public static void Error(object message, string logger = "logerror")
        {
            var log = LogManager.GetLogger(logger);

            log.Error(message);
        }
        /// <summary>
        /// 一般错误.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="logger">logger名称,默认为"logerror"</param>
        public static void Error(object message, Exception exception, string logger = "logerror")
        {
            var log = LogManager.GetLogger(logger);

            log.Error(message, exception);
        }
        /// <summary>
        /// 警告.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logger">logger名称,默认为"logwarn"</param>
        public static void Warn(object message, string logger = "logwarn")
        {
            var log = LogManager.GetLogger(logger);

            log.Warn(message);
        }
        /// <summary>
        /// 警告.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="logger">logger名称,默认为"logwarn"</param>
        public static void Warn(object message, Exception exception, string logger = "logwarn")
        {
            var log = LogManager.GetLogger(logger);

            log.Warn(message, exception);
        }
        /// <summary>
        /// 调试信息.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logger">logger名称,默认为"logdebug"</param>
        public static void Debug(object message, string logger = "logdebug")
        {
            var log = LogManager.GetLogger(logger);

            log.Debug(message);
        }
        /// <summary>
        /// 调试信息.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="logger">logger名称,默认为"logdebug"</param>
        public static void Debug(object message, Exception exception, string logger = "logdebug")
        {
            var log = LogManager.GetLogger(logger);

            log.Debug(message, exception);
        }

        /// <summary>
        /// 致命错误.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logger">logger名称,默认为"logfatal"</param>
        public static void Fatal(object message, string logger = "logfatal")
        {
            var log = LogManager.GetLogger(logger);

            log.Fatal(message);
        }
        /// <summary>
        /// 致命错误.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="logger">logger名称,默认为"logfatal"</param>
        public static void Fatal(object message, Exception exception, string logger = "logfatal")
        {
            var log = LogManager.GetLogger(logger);

            log.Fatal(message, exception);
        }
    }
}
