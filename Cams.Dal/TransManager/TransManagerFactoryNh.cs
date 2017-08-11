using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities;
using Cams.Domain.TransManager;
using Cams.Dal.BootStrapper;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using log4net.Config;

namespace Cams.Dal.TransManager
{
    public class TransManagerFactoryNh : ITransFactory
    {

        private ISessionFactory SessionFactoryInstance;
        public string ConfigurationFileName { get; set; }
        private ISessionFactory SessionFactory
        {
            get
            {
                if (SessionFactoryInstance != null) return SessionFactoryInstance;
                SessionFactoryInstance = InitializeSessionFactory();
                return SessionFactoryInstance;
            }
        }

        #region Implementation of ITransFactory

        public ITransManager CreateManager()
        {
            return new TransManagerNh(SessionFactory.OpenSession());
        }

        #endregion

        #region Properties

        public string ConnectionString { get; set; }

        #endregion

        #region Session Factory Initialize

        private ISessionFactory InitializeSessionFactory()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();

                return Fluently.Configure()
                        .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008
                        .ConnectionString(ConnectionString).ShowSql())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mappings.UserMap>())
                        .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                Common.Logging.LoggingFactory.LogException("TransManagerFactoryNh.InitializeSessionFactory", ex);
                throw ex;
            }
        }

        #endregion
    }
}
