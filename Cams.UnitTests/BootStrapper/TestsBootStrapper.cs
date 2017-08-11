using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using Cams.Common.DependencyInjection;
using Cams.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Context.Support;
using Cams.Common.Configuration;

namespace Cams.UnitTests.BootStrapper
{
    
    [TestClass]
    public class TestsBootStrapper
    {
        [AssemblyInitialize]
        public static void Run(TestContext context)
        {
            InitialiseDependencies(context);
            InstallAutoMapperDefinitions();
        }

        private static void InstallAutoMapperDefinitions()
        {
            AutoMapperConfigurator.Install();
        }

        private static void InitialiseDependencies(TestContext context)
        {

            var spring = ApplicationSettingsFactory.SpringConfigFile;
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var filePath = @"file://" + Path.Combine(basePath, spring);
                DiContext.AppContext = new XmlApplicationContext(filePath);
        }
    }
}
