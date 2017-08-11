using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.Users;

namespace Cams.Dal.Mappings
{
    public class UserEmergencyContactPersonMap : ClassMap<UserEmergencyContactPerson>
    {
        public UserEmergencyContactPersonMap()
        {
            Table("UsersEmergencyContactPerson");
            LazyLoad();
            Id(x => x.UserEmergencyContactPersonId).GeneratedBy.Identity().Column("UserEmergencyContactPersonId"); //.UnsavedValue(-1);
            Map(x => x.Name).Column("Name").Length(255).Not.Nullable();
            Map(x => x.Email1).Column("Email1").Length(100);
            Map(x => x.Email2).Column("Email2").Length(100);
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.ModifiedDate).Column("ModifiedDate").CustomType("DateTime")
                .Access.Property()
                .Generated.Always()
                .Default("getdate()")
                .CustomSqlType("datetime");

            References(x => x.ContactPersonAddress).Column("AddressId").Cascade.SaveUpdate();
            References(x => x.ContactPersonRelationshipWithUser).Column("RelationshipId").Nullable()
                .Cascade.SaveUpdate();
            //HasMany(x => x.Contacts).KeyColumn("UserEmergencyContactPersonId")
            //    .Cascade.SaveUpdate()
            //    .Inverse();
            HasManyToMany(x => x.Contacts)
                .Table("UserEmergencyContacts")
                .ParentKeyColumn("UserEmergencyContactPersonId")
                .ChildKeyColumn("ContactDetailsId")
                .Cascade.SaveUpdate();
            HasOne(x => x.ContactPersonOfUser).ForeignKey("UserProfileId").Cascade.SaveUpdate();
        }
    }
}
