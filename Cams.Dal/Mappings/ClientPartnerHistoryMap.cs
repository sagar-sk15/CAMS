using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Dal.Mappings
{
    public class ClientPartnerHistoryMap : ClassMap<ClientPartnerHistory>
    {
        public ClientPartnerHistoryMap()
        {
            Table("ClientPartnerHistory");
            LazyLoad();
            Id(x => x.ClientPartnerHistoryId).GeneratedBy.Identity().Column("ClientPartnerHistoryId");
            Map(x => x.PartnerId).Column("PartnerId").Not.Nullable();            
            Map(x => x.BusinessConstitutionId).Column("BusinessConstitutionId").Not.Nullable();
            Map(x => x.CAId).Column("CAId").Not.Nullable();
            Map(x => x.JoiningDate)
                .Column("JoiningDate")
                .Not.Nullable()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.RelievingDate)
                .Column("RelievingDate")
                .Nullable()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.IsActive).Column("IsActive").Not.Nullable();
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
