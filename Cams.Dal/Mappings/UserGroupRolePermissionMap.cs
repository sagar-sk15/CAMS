using System;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.Users;

namespace Cams.Dal.Mappings
{
    public class UserGroupRolePermissionMap : ClassMap<UserGroupRolePermission> 
    {
        
        public UserGroupRolePermissionMap() 
        {
			Table("UserGroupRolePermissions");
			LazyLoad();
            Id(x => x.UserGroupRolePermissionId).GeneratedBy.Identity().Column("UserGroupRolePermissionId");
			//References(x => x.PermissionForUserGroup).Column("UserGroupId");
            References(x => x.PermissionForRole).Column("RoleId").Not.Nullable().Cascade.SaveUpdate();
			Map(x => x.AllowAdd).Column("AllowAdd").Not.Nullable();
			Map(x => x.AllowEdit).Column("AllowEdit").Not.Nullable();
			Map(x => x.AllowView).Column("AllowView").Not.Nullable();
			Map(x => x.AllowDelete).Column("AllowDelete").Not.Nullable();
			Map(x => x.AllowPrint).Column("AllowPrint").Not.Nullable();
            HasManyToMany(x => x.PermissionForUserGroup)
              .Table("UserGroupRoles")
              .ParentKeyColumn("UserGroupRolePermissionId")
              .ChildKeyColumn("UserGroupId")
              .Cascade.SaveUpdate()
              .Inverse();
        }
    }
}
