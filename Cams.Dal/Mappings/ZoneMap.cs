using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.Masters;

namespace Cams.Dal.Mappings
{
    public class ZoneMap:ClassMap<Zone>
    {
        public ZoneMap()
        {
            Table("Zones");
            LazyLoad();
            Id(x => x.ZoneId).GeneratedBy.Identity().Column("ZoneId");
            Map(x => x.ZoneFor).Column("ZoneFor").Not.Nullable().Length(20);
            Map(x => x.Name).Column("Name").Not.Nullable().Length(255);
            Map(x => x.IsActive).Column("IsActive").Not.Nullable();
            Map(x => x.CAId).Column("CAId").Not.Nullable();
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();           
            Map(x => x.CreatedDate)
                .Column("CreatedDate")
                .CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime")
                .Not.Nullable();            
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.ModifiedDate)
                .Column("ModifiedDate")
                .CustomType("DateTime")
                .Access.Property()
                .Generated.Always()
                .Default("getdate()")
                .CustomSqlType("datetime")
                .Nullable();
        }
    }
}
