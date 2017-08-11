using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientRegistration;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class ClientPrimaryContactPersonMap : ClassMap<ClientPrimaryContactPerson>
    {
        public ClientPrimaryContactPersonMap()
        {
            Table("ClientPrimaryContactPerson");
            LazyLoad();
            Id(x => x.CAPrimaryContactPersonId).GeneratedBy.Identity().Column("CAPrimaryContactPersonId");
            Map(x => x.Title).Column("Title").Nullable().Length(5);
            Map(x => x.CAPrimaryConatactPersonName).Column("CAPrimaryConatactPersonName").Nullable().Length(255);
            Map(x => x.Gender).Column("Gender").Nullable().Length(5);
            Map(x => x.DateOfBirth)
                 .Column("DateOfBirth")
                 .Nullable()
                 .CustomType("DateTime")               
                 .Default("getdate()")
                 .CustomSqlType("datetime");
            Map(x => x.MothersMaidenName).Column("MothersMaidenName").Nullable().Length(255);
            Map(x => x.PAN).Column("PAN").Nullable().Length(20);
            Map(x => x.UID).Column("UID").Length(20);
            Map(x => x.Image).Column("Image").Length(255);
            Map(x => x.Email1).Column("Email1").Length(100);
            Map(x => x.Email2).Column("Email2").Length(100);
            Map(x => x.IsSameAsCompanyAddress).Column("IsSameAsCompanyAddress").Not.Nullable();
            Map(x => x.IsSameAsCompanyContact).Column("IsSameAsCompanyContact").Not.Nullable();
            Map(x => x.MobileNo).Column("MobileNo");
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .CustomType("DateTime")
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.ModifiedBy).Column("ModifiedBy").Not.Nullable();
            Map(x => x.ModifiedDate).Column("ModifiedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .CustomType("DateTime")
                .Generated.Always()
                .Default("getdate()")
                .CustomSqlType("datetime");

            References(x => x.ClientPrimaryContactPersonAddress).Column("AddressId").Cascade.SaveUpdate();
            References(x => x.ClientPrimaryContactPersonDesignation).Column("DesignationId").Cascade.SaveUpdate();
            HasManyToMany(x => x.ClientPrimaryContacts)
               .Table("ClientPrimaryContacts")
               .ParentKeyColumn("CAPrimaryContactPersonId")
               .ChildKeyColumn("ContactDetailsId")
               .Cascade.SaveUpdate();
            HasOne(x => x.PrimaryContactPersonofClient).ForeignKey("CAId").Cascade.SaveUpdate();
            
        }
    }
}
