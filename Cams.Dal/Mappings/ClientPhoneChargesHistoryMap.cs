using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientRegistration;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class ClientPhoneChargesHistoryMap : ClassMap<ClientPhoneChargesHistory>
    {
        public ClientPhoneChargesHistoryMap()
        {
            Table("ClientPhoneChargesHistory");
            LazyLoad();
            Id(x => x.ClientPhoneChargesHistoryId).GeneratedBy.Identity().Column("ClientPhoneChargesHistoryId");
            Map(x => x.ClientPhoneChargesId).Column("ClientPhoneChargesId").Not.Nullable();
            Map(x => x.CAId).Column("CAId").Not.Nullable();
            Map(x => x.WithEffectFromDate).Column("WithEffectFromDate")
                .Nullable()
                .CustomType("DateTime")
                //.Default("getdate()")
               .CustomSqlType("datetime");
            Map(x => x.WithEffectToDate).Column("WithEffectToDate")
                .Nullable()
                .CustomType("DateTime")
                //.Default("getdate()")
               .CustomSqlType("datetime");
            Map(x => x.WSFarmerAmount).Column("WSFarmerAmount").Not.Nullable();
            Map(x => x.OSFarmerAmount).Column("OSFarmerAmount").Not.Nullable();
            Map(x => x.WSTraderAmount).Column("WSTraderAmount").Not.Nullable();
            Map(x => x.OSTraderAmount).Column("OSTraderAmount").Not.Nullable();            
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
