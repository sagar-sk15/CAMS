using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientRegistration;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Table("Clients");
            LazyLoad();
            Id(x => x.CAId).GeneratedBy.Identity().Column("CAId");
            Map(x => x.DisplayClientId).Column("DisplayClientId").Length(30).Not.Nullable();
            Map(x => x.CompanyName).Column("CompanyName").Not.Nullable().Length(200);
            Map(x => x.RegistrationDate).Column("RegistrationDate")
                .Nullable()
                .CustomType("DateTime")
                //.Default("getdate()")
               .CustomSqlType("datetime");
            Map(x => x.Alias).Column("Alias").Nullable().Length(10);
            Map(x => x.Image).Column("Image").Length(255);
            Map(x => x.PAN).Column("PAN").Nullable().Length(20);
            Map(x => x.TAN).Column("TAN").Length(20);
            Map(x => x.Email1).Column("Email1").Length(100);
            Map(x => x.Email2).Column("Email2").Length(100);
            Map(x => x.Website).Column("Website").Length(100);
            Map(x => x.IsActive).Column("IsActive").Not.Nullable();
            Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
            Map(x => x.Status).Column("Status").Not.Nullable().Length(15);
            Map(x => x.AllowEdit).Column("AllowEdit").Not.Nullable();
            Map(x => x.APMCLicenseNo).Column("APMCLicenseNo").Nullable();
            Map(x => x.NoOfPartners).Column("NoOfPartners").Not.Nullable();
            Map(x => x.TDSOnSubscriptionPayment).Column("TDSOnSubscriptionPayment").Not.Nullable();
            Map(x => x.AdditionalInfoForSubscriptionPayment).Column("AdditionalInfoForSubscriptionPayment").Nullable().Length(255);
            Map(x => x.APMCLicenseValidUpTo)
               .Column("APMCLicenseValidUpTo")
               .Nullable()
               .CustomType("DateTime")
                //.Default("getdate()")
               .CustomSqlType("datetime");
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
            Map(x => x.AccountManagerId).Column("AccountManagerId").Not.Nullable();

            References(x => x.ClientAddress).Column("AddressId").Nullable().Cascade.SaveUpdate();
            References(x => x.ClientAPMC).Column("APMCId").Nullable().Cascade.SaveUpdate();
            References(x => x.ClientBusinessConstitution).Column("BusinessConstitutionId").Nullable().Cascade.SaveUpdate();
            References(x => x.ClientSubscription).Column("ClientSubscriptionId").Nullable().Cascade.SaveUpdate();
            //References(x => x.AccountManager).Columns("UserId").Cascade.SaveUpdate().Nullable().Not.Insert().Not.Update().ReadOnly();            
            References(x => x.ClientPhoneCharges).Column("ClientPhoneChargesId").Nullable().Cascade.SaveUpdate();
            References(x => x.ClientPrimaryContactPerson).Column("CAPrimaryContactPersonId").Nullable().Cascade.SaveUpdate();
            HasManyToMany(x => x.ClientContacts)
               .Table("ClientContacts")
               .ParentKeyColumn("CAId")
               .ChildKeyColumn("ContactDetailsId")
               .Cascade.SaveUpdate();
            HasManyToMany(x => x.ClientPartners)
               .Table("ClientPartners")
               .ParentKeyColumn("CAId")
               .ChildKeyColumn("PartnerId")
               .Cascade.SaveUpdate();
            HasManyToMany(x => x.ClientCommodities)
               .Table("ClientCommodities")
               .ParentKeyColumn("CAId")
               .ChildKeyColumn("CommodityClassId")
               .Cascade.SaveUpdate();
            HasManyToMany(x => x.ClientSisterConcerns)
              .Table("ClientSisterConcerns")
              .ParentKeyColumn("CAId")
              .ChildKeyColumn("ClientSisterConcernId")
              .Cascade.SaveUpdate();
            HasManyToMany(x => x.ClientTaxationAndLicenses)
             .Table("ClientTaxationAndLicenses")
             .ParentKeyColumn("CAId")
             .ChildKeyColumn("ClientTaxationAndLicensesId")
             .Cascade.SaveUpdate();
        }
    }
}
