using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Dal.Mappings
{
    public class ClientPartnerBankDetailsMap : ClassMap<ClientPartnerBankDetails>
    {
        public ClientPartnerBankDetailsMap()
        {
            Table("ClientPartnerBankDetails");
			LazyLoad();
            Id(x => x.ClientPartnerBankId).GeneratedBy.Identity().Column("ClientPartnerBankId");
            Map(x => x.Accounttype).Column("Accounttype").Nullable().Length(20);
            Map(x => x.AccountNo).Column("AccountNo").Nullable().Length(40);
            Map(x => x.StandingInstructions).Column("StandingInstructions").Nullable().Length(100);
            Map(x => x.BankContactPersonName).Column("BankContactPersonName").Nullable().Length(20);
            Map(x => x.Email1).Column("Email1").Nullable().Length(100);
            Map(x => x.Email2).Column("Email2").Nullable().Length(100);
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


            References(x => x.BranchOfClientPartner).Column("BranchId").Nullable().Cascade.SaveUpdate();
            References(x => x.BankContactPersonDesignation).Column("DesignationId").Nullable().Cascade.SaveUpdate();
            HasManyToMany(x => x.BankDetailsOfClient)
             .Table("ClientPartnerBanks")
             .ParentKeyColumn("ClientPartnerBankId")
             .ChildKeyColumn("PartnerId")
             .Cascade.SaveUpdate();
            HasManyToMany(x => x.BankContactPersonContacts)
               .Table("ClientPartnerBankContactPersonContacts")
               .ParentKeyColumn("ClientPartnerBankId")
               .ChildKeyColumn("ContactDetailsId")
               .Cascade.SaveUpdate();

        }
    }
}
