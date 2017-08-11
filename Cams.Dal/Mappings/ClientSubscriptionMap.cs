using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Dal.Mappings
{
    public class ClientSubscriptionMap:ClassMap<ClientSubscription>
    {
        public ClientSubscriptionMap()
        {
            Table("ClientSubscriptions");
            LazyLoad();
            Id(x => x.ClientSubscriptionId).GeneratedBy.Identity().Column("ClientSubscriptionId");            
            Map(x => x.SubscriptionPeriod).Column("SubscriptionPeriod").Nullable();
            Map(x => x.SubscriptionPeriodFromDate).Column("SubscriptionPeriodFromDate")
                .Nullable()
                .CustomType("DateTime")                
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.SubscriptionPeriodToDate).Column("SubscriptionPeriodToDate")
                .Nullable()
                .CustomType("DateTime")                
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.AdditionalNoOfEmployees).Column("AdditionalNoOfEmployees").Not.Nullable();
            Map(x => x.AdditionalNoOfAuditors).Column("AdditionalNoOfAuditors").Not.Nullable();
            Map(x => x.AdditionalNoOfAssociates).Column("AdditionalNoOfAssociates").Not.Nullable();
            Map(x => x.AdditionalCostForEmployees).Column("AdditionalCostForEmployees").Not.Nullable();
            Map(x => x.AdditionalCostForAuditors).Column("AdditionalCostForAuditors").Not.Nullable();
            Map(x => x.AdditionalCostForAssociates).Column("AdditionalCostForAssociates").Not.Nullable();
            Map(x => x.DiscountInPercentage).Column("DiscountInPercentage").Not.Nullable();
            Map(x => x.DiscountInRupees).Column("DiscountInRupees").Not.Nullable();
            Map(x => x.ServiceTax).Column("ServiceTax").Not.Nullable();
            Map(x => x.OtherTax).Column("OtherTax").Not.Nullable();
            Map(x => x.Status).Column("Status").Not.Nullable().Length(15);
            Map(x => x.AdditionalInfo).Column("AdditionalInfo").Nullable().Length(255);
            Map(x => x.ActivationDate).Column("ActivationDate")
               .Nullable()
               .CustomType("DateTime")
               .Default("getdate()")
               .CustomSqlType("datetime");
            Map(x => x.AllowEdit).Column("AllowEdit").Not.Nullable();
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomType("DateTime")
                .CustomSqlType("datetime");
            Map(x => x.ModifiedBy).Column("ModifiedBy").Not.Nullable();
            Map(x => x.ModifiedDate).Column("ModifiedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .CustomType("DateTime")
                .Generated.Always()
                .Default("getdate()")
                .CustomSqlType("datetime");

            References(x => x.SubscriptionMaster).Column("SubscriptionId").Nullable().Cascade.SaveUpdate();
            //HasMany(x => x.ClientSubscriptionPaymentDetails).KeyColumn("ClientSubscriptionId")
            //   .Cascade.SaveUpdate()
            //   .Inverse();
            HasManyToMany(x => x.ClientSubscriptionPaymentDetails)
               .Table("ClientSubscriptionPayments")
               .ParentKeyColumn("ClientSubscriptionId")
               .ChildKeyColumn("CASubscriptionPaymentDetailsId")
               .Cascade.SaveUpdate();
        }
    }
}
