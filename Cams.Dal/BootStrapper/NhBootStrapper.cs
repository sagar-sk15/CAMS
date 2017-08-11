using System;
using System.Linq;
using FluentNHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Cams.Dal.BootStrapper
{
    public class NhBootStrapper
    {
        public string ConnectionString { get; set; }

        private FluentConfiguration fnhConfiguration;
        public FluentConfiguration FNhConfiguration
        {
            get
            {
                fnhConfiguration = Fluently.Configure()
                                           .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008
                                           .ConnectionString(ConnectionString)
                                           .ShowSql())                                           
                                           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Cams.Dal.Mappings.UserMap>());
                return fnhConfiguration;
            }
        }

        public void CamsSchemaExport()
        {
            FNhConfiguration.ExposeConfiguration(cfg =>
            {
                new SchemaExport(cfg).Create(true, true);
            })
                            .BuildSessionFactory();
        }
    }
}