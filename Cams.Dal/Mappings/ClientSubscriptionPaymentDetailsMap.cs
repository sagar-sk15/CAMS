using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Dal.Mappings
{
    public class ClientSubscriptionPaymentDetailsMap:ClassMap<ClientSubscriptionPaymentDetails>
    {
        public ClientSubscriptionPaymentDetailsMap()
        {
			Table("ClientSubscriptionPaymentDetails");
			LazyLoad();
			Id(x => x.CASubscriptionPaymentDetailsId).GeneratedBy.Identity().Column("CASubscriptionPaymentDetailsId");			
			Map(x => x.PaymentMode).Column("PaymentMode").Nullable().Length(10);
			Map(x => x.Amount).Column("Amount").Not.Nullable();
            Map(x => x.IsRTGS).Column("IsRTGS").Not.Nullable();
            Map(x => x.IsStandardCheque).Column("IsStandardCheque").Not.Nullable();
            Map(x => x.IsNEFT).Column("IsNEFT").Not.Nullable(); 
            Map(x => x.ChequeDDTransationNo).Column("ChequeDDTransationNo").Nullable().Length(15); 
			Map(x => x.ChequeDDTransactionDate).Column("ChequeDDTransactionDate")
                .Nullable()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.ChequeDDClearanceDates).Column("ChequeDDClearanceDates")
                .Nullable()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");
            
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable()
                .Access.Property()
                .CustomType("DateTime")
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.ModifiedBy).Column("ModifiedBy").Not.Nullable();
            Map(x => x.ModifiedDate).Column("ModifiedDate").Not.Nullable()
                .Access.Property()
                .Generated.Always()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");


            References(x => x.BankBranch).Column("BranchId").Nullable().Cascade.SaveUpdate();
            //References(x => x.ClientSubscription).Column("ClientSubscriptionId").Not.Nullable().Cascade.SaveUpdate();
            HasManyToMany(x => x.ClientSubscription)
            .Table("ClientSubscriptionPayments")
            .ParentKeyColumn("CASubscriptionPaymentDetailsId")
            .ChildKeyColumn("ClientSubscriptionId")
            .Cascade.SaveUpdate();
        }
    }
}
