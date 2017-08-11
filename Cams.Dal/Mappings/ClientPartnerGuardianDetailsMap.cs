using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Dal.Mappings
{
    public class ClientPartnerGuardianDetailsMap : ClassMap<ClientPartnerGuardianDetails>
    {
        public ClientPartnerGuardianDetailsMap()
        {
            Table("ClientPartnerGuardianDetails");
            LazyLoad();
            Id(x => x.ClientPartnerGuardianId).GeneratedBy.Identity().Column("ClientPartnerGuardianId");
            Map(x => x.Title).Column("Title").Nullable().Length(10);
            Map(x => x.GuardianName).Column("GuardianName").Nullable().Length(255);
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

            References(x => x.ClientPartnerGuardianAddress).Column("AddressId").Cascade.SaveUpdate();
            References(x => x.GuardianRelationshipWithClientPartner).Column("RelationshipId").Nullable().Cascade.SaveUpdate();
            HasManyToMany(x => x.ClientPartnerGuardianContacts)
               .Table("ClientPartnerGuardianContacts")
               .ParentKeyColumn("ClientPartnerGuardianId")
               .ChildKeyColumn("ContactDetailsId")
               .Cascade.SaveUpdate();
            HasOne(x => x.GuardianofClientPartner).ForeignKey("PartnerId").Cascade.SaveUpdate();
        }
    }
}
