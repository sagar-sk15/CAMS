using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Dal.Mappings
{
    public class ClientPartnerDetailsMap:ClassMap<ClientPartnerDetails>
    {
        public ClientPartnerDetailsMap()
        {
			Table("ClientPartnerDetails");
			LazyLoad();
            Id(x => x.PartnerId).GeneratedBy.Identity().Column("PartnerId");
            Map(x => x.Title).Column("Title").Nullable().Length(10);
            Map(x => x.PartnerName).Column("PartnerName").Nullable().Length(255);
            Map(x => x.Gender).Column("Gender").Nullable().Length(5);
            Map(x => x.DateOfBirth)
                .Column("DateOfBirth")
                .Nullable()
                .CustomType("DateTime")                
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.PAN).Column("PAN").Nullable().Length(20);
            Map(x => x.UID).Column("UID").Nullable().Length(20);
            Map(x => x.Image).Column("Image").Nullable().Length(255);
            Map(x => x.Email1).Column("Email1").Nullable().Length(100);
            Map(x => x.Email2).Column("Email2").Nullable().Length(100);
            Map(x => x.JoiningDate)
                .Column("JoiningDate")
                .Nullable()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.RelievingDate)
                .Column("RelievingDate")
                .Nullable()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");

            Map(x => x.PartnerDisplayId).Column("PartnerDisplayId").Nullable().Length(30);
            Map(x => x.MaritialStatus).Column("MaritialStatus").Nullable().Length(10);
            Map(x => x.PassportNo).Column("PassportNo").Nullable().Length(30);
            Map(x => x.Place).Column("Place").Nullable().Length(100);
            Map(x => x.IssuedOn)
                .Column("IssuedOn")
                .Nullable()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.ValidUpTo)
                .Column("ValidUpTo")
                .Nullable()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.PartnerType).Column("PartnerType").Nullable().Length(10);
            Map(x => x.CapitalRatio).Column("CapitalRatio").Not.Nullable();
            Map(x => x.ProfitRatio).Column("ProfitRatio").Not.Nullable();
            Map(x => x.SalaryRatio).Column("SalaryRatio").Not.Nullable();
            Map(x => x.LossRatio).Column("LossRatio").Not.Nullable();
            Map(x => x.OpeningBalance).Column("OpeningBalance").Not.Nullable();
            Map(x => x.BalanceType).Column("BalanceType").Nullable().Length(5);
            Map(x => x.AsOnDate)
                .Column("AsOndate")
                .Nullable()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");

            Map(x => x.IsActive).Column("IsActive").Not.Nullable();
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

            References(x => x.ClientPartnerAddress).Column("AddressId").Cascade.SaveUpdate();
            References(x => x.ClientPartnerDesignation).Column("DesignationId").Cascade.SaveUpdate();
            References(x => x.ClientPartnerGuardian).Column("ClientPartnerGuardianId").Nullable().Cascade.SaveUpdate();
            References(x => x.ClientPartnerNominee).Column("ClientPartnerNomineeId").Nullable().Cascade.SaveUpdate();
            HasManyToMany(x => x.ClientPartnerContacts)
               .Table("ClientPartnerContacts")
               .ParentKeyColumn("PartnerId")
               .ChildKeyColumn("ContactDetailsId")
               .Cascade.SaveUpdate();
            HasManyToMany(x => x.ClientPartners)
               .Table("ClientPartners")
               .ParentKeyColumn("PartnerId")
               .ChildKeyColumn("CAId")
               .Cascade.SaveUpdate();
            HasManyToMany(x => x.ClientPartnerBanks)
             .Table("ClientPartnerBanks")
             .ParentKeyColumn("PartnerId")
             .ChildKeyColumn("ClientPartnerBankId")
             .Cascade.SaveUpdate();
        }
    }
}
