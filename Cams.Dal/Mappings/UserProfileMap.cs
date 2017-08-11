using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.Users;

namespace Cams.Dal.Mappings
{
    public class UserProfileMap : ClassMap<UserProfile>
    {
        public UserProfileMap()
        {
            Table("UserProfiles");
            LazyLoad();
            Id(x => x.UserProfileId).GeneratedBy.Identity().Column("UserProfileId");//.UnsavedValue(-1);
            Map(x => x.Gender).Column("Gender");
            Map(x => x.MaritalStatus).Column("MaritalStatus");
            Map(x => x.UID).Column("UID").Length(30);
            Map(x => x.PAN).Column("PAN").Length(20);
            Map(x => x.PassportNo).Column("PassportNo").Length(20);
            Map(x => x.PassportPlace).Column("PassportPlace").Length(255);
            Map(x => x.PassportValidFromDate).Column("PassportValidFromDate").CustomType("DateTime")
                //.Access.Property()
                //.Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.PassportValidToDate).Column("PassportValidToDate").CustomType("DateTime")
                //.Access.Property()
                //.Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.BloodGroup).Column("BloodGroup");
            Map(x => x.DateOfJoining).Column("DateOfJoining").CustomType("DateTime")
                //.Access.Property()
                //.Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.PFNo).Column("PFNo").Length(30);
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

            References(x => x.UserAddress).Column("AddressId").Cascade.SaveUpdate();
            References(x => x.UserEmergencyContactPerson).Column("UserEmergencyContactPersonId").Nullable().Cascade.SaveUpdate();            
            HasManyToMany(x => x.ContactNos)
                //.KeyColumn("UserProfileId")
                .Table("UserContacts")
                .ParentKeyColumn("UserProfileId")
                .ChildKeyColumn("ContactDetailsId")
                .Cascade.SaveUpdate();
            HasOne(x => x.ProfileOfUser).ForeignKey("UserId").Cascade.SaveUpdate();

            //References(x => x.User).Column("UserId").Nullable();
            //HasOne(x => x.UserAddress).Cascade.All();
            //HasOne(x => x.UserEmergencyContactPerson).Cascade.All();
        }
    }
}
