using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Dal.Mappings
{
    public class ClientBusinessConstitutionHistoryMap : ClassMap<ClientBusinessConstitutionHistory>
    {
        public ClientBusinessConstitutionHistoryMap()
        {
            Table("ClientBusinessConstitutionHistory");
            LazyLoad();
            Id(x => x.ClientBusinessConstitutionHistoryId).GeneratedBy.Identity().Column("ClientBusinessConstitutionHistoryId");
            Map(x => x.CAId).Column("CAId").Not.Nullable();
            Map(x => x.BusinessConstitutionId).Column("BusinessConstitutionId").Not.Nullable();
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
