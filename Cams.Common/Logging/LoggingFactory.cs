using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Configuration;
using log4net;
using log4net.Config;

namespace Cams.Common.Logging
{
    /// <summary>
    /// This static class provides methods to log at various levels
    /// </summary>
    public static class LoggingFactory
    {
        #region Public Methods
        /// <summary>
        /// This method configers log4net and returns the Ilog object
        /// </summary>
        /// <param name="LoggerName">Logger name is wrt the config settings</param>
        /// <returns>Return an object of ILog which provides the different log methods</returns>
        private static ILog GetLogger(string LoggerName)
        {
            XmlConfigurator.Configure();
            return LogManager.GetLogger(LoggerName);
        }

        public static void LogInfo(string message)
        {
            GetLogger(ApplicationSettingsFactory.LoggerName).Info(message);
        }

        public static void LogException(string message, Exception exception)
        {
            GetLogger(ApplicationSettingsFactory.ExceptionLoggerName).Error(message, exception);
        }

        public static void LogWarning(string message)
        {
            GetLogger(ApplicationSettingsFactory.LoggerName).Warn(message);
        }

        public static void LogDebug(string message)
        {
            GetLogger(ApplicationSettingsFactory.LoggerName).Debug(message);
        }

        public static void LogError(string message)
        {
            GetLogger(ApplicationSettingsFactory.LoggerName).Error(message);
        }

        public static void LogFatal(string message)
        {
            GetLogger(ApplicationSettingsFactory.LoggerName).Fatal(message);
        }
        #endregion
    }
}
