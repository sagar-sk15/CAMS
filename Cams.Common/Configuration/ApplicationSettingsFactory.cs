using System;
using System.Linq;
using System.Configuration;

namespace Cams.Common.Configuration
{
    /// <summary>
    /// This class is used to get the Application Settings from the Config file (App.config/web.config)
    /// </summary>
    public class ApplicationSettingsFactory
    {
        #region Private Methods
        private static string GetConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        #endregion

        #region Common Application Settings
        
        public static string LoggerName
        {
            get { return GetConfigValue(ConfigConstants.LoggerName); }
        }

        public static string ExceptionLoggerName
        {
            get { return GetConfigValue(ConfigConstants.ExceptionLoggerName); }
        }

        public static string SpringConfigFile
        {
            get { return GetConfigValue(ConfigConstants.SpringConfigFile); }
        }

        public static string ConnectionString
        {
            get { return GetConfigValue(ConfigConstants.ConnectionString); }
        }

        public static string ErrorMessageResourceFileName 
        {
            get { return GetConfigValue(ConfigConstants.ErrorMessageResourceFileName); }
        }

        public static string ErrorMessageResourceAssemblyName
        {
            get { return GetConfigValue(ConfigConstants.ErrorMessageResourceAssemblyName); }
        }
        #endregion

        #region UnitTest Specific AppSettings
        public static string CreateDB
        {
            get { return GetConfigValue(ConfigConstants.CreateDB); }
        }
        #endregion

        #region Web Specific AppSettings
        
        public static int NumberOfResultsPerPage
        {
            get { return int.Parse(GetConfigValue(ConfigConstants.NumberOfResultsPerPage)); }
        }

        #endregion
    }   
}
