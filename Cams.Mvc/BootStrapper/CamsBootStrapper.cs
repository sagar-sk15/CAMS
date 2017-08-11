using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Cams.Common.DependencyInjection;
using Cams.Common.Configuration;
using Spring.Context.Support;

namespace Cams.Mvc.BootStrapper
{
    public class CamsBootStrapper
    {
        public static void Run()
        {
            InitialiseDependencies();
        }

        private static void InitialiseDependencies()
        {
            var spring = ApplicationSettingsFactory.SpringConfigFile;
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = @"file://" + Path.Combine(basePath, spring);
            DiContext.AppContext = new XmlApplicationContext(filePath);
        }
    }
}