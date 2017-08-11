using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.Users;

namespace Cams.Dal.Mappings
{
    public class UserGroupMap : ClassMap<UserGroup>
    {

        public UserGroupMap()
        {
            Table("UserGroups");
            LazyLoad();
            Id(x => x.UserGroupId).GeneratedBy.Identity().Column("UserGroupId");
            Map(x => x.UserGroupName).Column("UserGroupName").Length(255).Not.Nullable();
            Map(x => x.Description).Column("Description").Length(255);
            Map(x => x.CAId).Column("CAId").Nullable();
            Map(x => x.IsActive).Column("IsActive");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AllowEdit).Column("AllowEdit");
            Map(x => x.AllowDelete).Column("AllowDelete");
            Map(x => x.CreatedBy).Column("CreatedBy");
            Map(x => x.CreatedDate).Column("CreatedDate").CustomType("DateTime")
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
            //HasManyToMany(x => x.UsersInUserGroup)                
            //    .Table("UserUserGroups")
            //    .ParentKeyColumn("UserGroupId")
            //    //.Cascade.SaveUpdate()
            //    //.Inverse()
            //    .ChildKeyColumn("UserId");
            HasManyToMany(x => x.UsersInUserGroup)
                .Inverse()
                .LazyLoad()
                .Cascade.AllDeleteOrphan()
                .ParentKeyColumn("UserGroupId")
                .ChildKeyColumn("UserId")
                .Access.CamelCaseField(Prefix.Underscore);
            HasManyToMany(x => x.RolePermissionsInUserGroup)
                .Table("UserGroupRoles")
                .ParentKeyColumn("UserGroupId")
                .ChildKeyColumn("UserGroupRolePermissionId")
                .Cascade.SaveUpdate();            
        }

    }
}
