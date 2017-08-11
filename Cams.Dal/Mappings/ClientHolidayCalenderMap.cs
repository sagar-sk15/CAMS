using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientRegistration;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class ClientHolidayCalenderMap : ClassMap<ClientHolidayCalender>
    {
        public ClientHolidayCalenderMap()
        {
            Table("ClientHolidayCalender");
            LazyLoad();
            Id(x => x.ClientHolidayCalenderId).GeneratedBy.Identity().Column("ClientHolidayCalenderId");
            Map(x => x.CAId).Column("CAId").Not.Nullable();
            Map(x => x.HolidayFromDate).Column("HolidayFromDate")
              .Not.Nullable()
              .CustomType("DateTime")
                //.Default("getdate()")
             .CustomSqlType("datetime");
            Map(x => x.HolidayToDate).Column("HolidayToDate")
               .Nullable()
               .CustomType("DateTime")
                //.Default("getdate()")
              .CustomSqlType("datetime");
            Map(x => x.Reason).Column("Reason").Not.Nullable().Length(100);
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
