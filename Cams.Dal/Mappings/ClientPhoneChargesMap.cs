using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientRegistration;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class ClientPhoneChargesMap : ClassMap<ClientPhoneCharges>
    {
        public ClientPhoneChargesMap()
        {
            Table("ClientPhoneCharges");
            LazyLoad();
            Id(x => x.ClientPhoneChargesId).GeneratedBy.Identity().Column("ClientPhoneChargesId");
            Map(x => x.WithEffectFromDate).Column("WithEffectFromDate")
                .Nullable()
                .CustomType("DateTime")
                //.Default("getdate()")
               .CustomSqlType("datetime");
            Map(x => x.WSFarmerAmount).Column("WSFarmerAmount").Not.Nullable();
            Map(x => x.OSFarmerAmount).Column("OSFarmerAmount").Not.Nullable();
            Map(x => x.WSTraderAmount).Column("WSTraderAmount").Not.Nullable();
            Map(x => x.OSTraderAmount).Column("OSTraderAmount").Not.Nullable();
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

            HasOne(x => x.PhoneChargesOfClient).ForeignKey("CAId").Cascade.SaveUpdate();
        }
    }
}
