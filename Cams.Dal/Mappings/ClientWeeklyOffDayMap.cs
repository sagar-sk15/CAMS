using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientRegistration;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class ClientWeeklyOffDayMap : ClassMap<ClientWeeklyOffDay>
    {
        public ClientWeeklyOffDayMap()
        {
            Table("ClientWeeklyOffDay");
            LazyLoad();
            Id(x => x.ClientWeeklyOffDayId).GeneratedBy.Identity().Column("ClientWeeklyOffDayId");
            Map(x => x.IsMonday).Column("IsMonday");
            Map(x => x.IsTuesday).Column("IsTuesday");
            Map(x => x.IsWednesday).Column("IsWednesday");
            Map(x => x.IsThursday).Column("IsThursday");
            Map(x => x.IsFriday).Column("IsFriday");
            Map(x => x.IsSaturday).Column("IsSaturday");
            Map(x => x.IsSunday).Column("IsSunday");
            Map(x => x.WithEffectFromDate).Column("WithEffectFromDate")
               .Not.Nullable()
               .CustomType("DateTime")
                //.Default("getdate()")
              .CustomSqlType("datetime");
            Map(x => x.WithEffectToDate).Column("WithEffectToDate")
               .Not.Nullable()
               .CustomType("DateTime")
                //.Default("getdate()")
              .CustomSqlType("datetime");
            Map(x => x.CAId).Column("CAId").Not.Nullable();
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                 .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.ModifiedBy).Column("ModifiedBy").Not.Nullable();
            Map(x => x.ModifiedDate).Column("ModifiedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Always()
                 .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");
        }
    }
}
