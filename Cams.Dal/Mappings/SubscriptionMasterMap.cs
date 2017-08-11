using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Dal.Mappings
{
    public class SubscriptionMasterMap:ClassMap<SubscriptionMaster>
    {
        public SubscriptionMasterMap()
        {
            Table("SubscriptionMaster");
            LazyLoad();
            Id(x => x.SubscriptionId).GeneratedBy.Identity().Column("SubscriptionId");
            Map(x => x.SubscriptionType).Column("SubscriptionType").Not.Nullable().Length(15);
            Map(x => x.TotalNoOfUsers).Column("TotalNoOfUsers").Not.Nullable();
            Map(x => x.NoOfEmployees).Column("NoOfEmployees").Not.Nullable();
            Map(x => x.NoOfAuditors).Column("NoOfAuditors").Not.Nullable();
            Map(x => x.NoOfAssociates).Column("NoOfAssociates").Not.Nullable();
            Map(x => x.SubscriptionFees).Column("SubscriptionFees").Not.Nullable();
            Map(x => x.RenewalFeesPerAnnum).Column("RenewalFeesPerAnnum").Not.Nullable();
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.ModifiedBy).Column("ModifiedBy").Not.Nullable();
            Map(x => x.ModifiedDate).Column("ModifiedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Always()
                .Default("getdate()")
                .CustomSqlType("datetime");
            HasMany(x => x.ClientSubscriptions).KeyColumn("SubscriptionId")
                .Cascade.SaveUpdate()
                .Inverse();
        }
    }
}
