// Example header text. Can be configured in the options.
using System;
using System.Linq;
using Cams.Common.Configuration;
using Cams.Common.Message;
using Cams.Dal.BootStrapper;
using Cams.Dal.TransManager;
using Cams.Domain.AppServices;
using Cams.Domain.Repository;
using Cams.Domain.TransManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cams.UnitTests
{
    [TestClass]
    public abstract class CamsTestBase
    {
        [TestInitialize]
        public virtual void TestsInitialize()
        {
            InitialiseDatabase();
        }

        private static void InitialiseDatabase()
        {
            var nHFactory = GlobalContext.Instance().TransFactory as TransManagerFactoryNh;
            if (nHFactory == null)
            {
                return;
            }
            var nhBootStrapper = new NhBootStrapper { ConnectionString = ApplicationSettingsFactory.ConnectionString };
            bool CreateDatabase = bool.Parse(ApplicationSettingsFactory.CreateDB);
            if (CreateDatabase)
                nhBootStrapper.CamsSchemaExport();
        }

        [TestCleanup]
        public virtual void TestCleanUp()
        {
            ResetLocator();
        }

        private static void ResetLocator()
        { 
            using (ITransManager manager = GlobalContext.Instance().TransFactory.CreateManager())
            {
                manager.ExecuteCommand(locator =>
                {
                    var resetable = locator as IResetable;
                    if (resetable == null)
                    {
                        return null;
                    }
                    resetable.Reset();
                    return new DtoResponse();
                });
            }
        }
    }
}