using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.Users;

namespace Cams.Dal.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            LazyLoad();
            Id(x => x.UserId).GeneratedBy.Identity().Column("UserId");
            References(x => x.UserDesignation).Column("DesignationId").Nullable().Cascade.SaveUpdate();
            Map(x => x.Username).Column("Username").Length(255).Not.Nullable();
            Map(x => x.Title).Column("Title").Not.Nullable().Length(5);
            Map(x => x.Name).Column("Name").Not.Nullable().Length(255);
            Map(x => x.Email).Column("Email").Not.Nullable().Length(255);
            Map(x => x.MobileNo).Column("MobileNo").Not.Nullable().Length(255);
            Map(x => x.Password).Column("Password").Not.Nullable().Length(255);
            Map(x => x.MothersMaidenName).Column("MothersMaidenName").Not.Nullable().Length(255);
            Map(x => x.CAId).Column("CAId");
            Map(x => x.CountryCode).Column("CountryCode").Not.Nullable().Length(255);
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate)
                .Column("CreatedDate")
                .CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime")
                .Not.Nullable();
            Map(x => x.DateOfBirth)
                .Column("DateOfBirth")
                .Not.Nullable()
                .CustomType("DateTime")
                //.Access.Property()
                //.Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.FailedPasswordAttemptCount).Column("FailedPasswordAttemptCount");
            Map(x => x.FailedPasswordAttemptWindowStart)
                .Column("FailedPasswordAttemptWindowStart")
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.IsActive).Column("IsActive").Not.Nullable();
            Map(x => x.IsLockedOut).Column("IsLockedOut").Not.Nullable();
            Map(x => x.IsOnLine).Column("IsOnLine").Not.Nullable();
            Map(x => x.LastActivityDate)
                .Column("LastActivityDate")
                .CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.LastLockedOutDate)
                .Column("LastLockedOutDate")
                .CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.LastLoginDate).
                Column("LastLoginDate")
                .CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.LastPasswordChangedDate)
                .Column("LastPasswordChangedDate")
                .CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.ModifiedDate)
                .Column("ModifiedDate")
                .CustomType("DateTime")
                .Access.Property()
                .Generated.Always()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.LastPassword).Column("LastPassword").Length(255);
            Map(x => x.SecondLastPassword).Column("SecondLastPassword").Length(255);
            Map(x => x.SecondLastPasswordChangedDate)
                .Column("SecondLastPasswordChangedDate")
                .Access.Property()
                .Generated.Always()
                .Default("getdate()")
                .CustomSqlType("datetime"); ;
            Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
            Map(x => x.AllowEdit).Column("AllowEdit").Not.Nullable();
            Map(x => x.AllowDelete).Column("AllowDelete").Not.Nullable();
            Map(x => x.Image).Column("Image");
            Map(x => x.UserType).Column("UserType").Length(15);
            HasManyToMany(x => x.UserWithRolePermissions)
                .Table("UserRoles")
                .ParentKeyColumn("UserId")
                .ChildKeyColumn("UserRolePermissionId")
                .Cascade.SaveUpdate();
            //.Inverse();
            HasManyToMany(x => x.UserWithUserGroups)
                   .Table("UserUserGroups")
                   .ParentKeyColumn("UserId")
                //.Cascade.SaveUpdate()
                   .ChildKeyColumn("UserGroupId");
            References(x => x.UserProfile).Column("UserProfileId").Nullable().Cascade.SaveUpdate();
            //References(x => x.UserOfClient).Column("CAId").Nullable().Cascade.SaveUpdate();
            HasMany(x => x.ViewOfUserUserGroupRolePermissions)
                .Inverse()
                .LazyLoad()
                .Cascade.AllDeleteOrphan()
                .KeyColumn("UserId")
                .Access.CamelCaseField(Prefix.Underscore);
            //HasMany(x => x.AccountManagerOfClients).KeyColumn("UserId")
            //    .Cascade.SaveUpdate()
            //    .Inverse();            
            
        }
    }
}
