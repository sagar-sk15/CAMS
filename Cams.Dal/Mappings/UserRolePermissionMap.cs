using System;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.Users;

namespace Cams.Dal.Mappings
{
    public class UserRolePermissionMap : ClassMap<UserRolePermission>
    {

        public UserRolePermissionMap()
        {
            Table("UserRolePermissions");
            LazyLoad();
            Id(x => x.UserRolePermissionId).GeneratedBy.Identity().Column("UserRolePermissionId");           
            References(x => x.PermissionForRole).Column("RoleId").Not.Nullable().Cascade.SaveUpdate();            
            Map(x => x.AllowAdd).Column("AllowAdd").Not.Nullable();
            Map(x => x.AllowEdit).Column("AllowEdit").Not.Nullable();
            Map(x => x.AllowView).Column("AllowView").Not.Nullable();
            Map(x => x.AllowDelete).Column("AllowDelete").Not.Nullable();
            Map(x => x.AllowPrint).Column("AllowPrint").Not.Nullable();
            HasManyToMany(x => x.PermissionForUser)
              .Table("UserRoles")
              .ParentKeyColumn("UserRolePermissionId")
              .ChildKeyColumn("UserId")
              .Cascade.SaveUpdate()
              .Inverse();
        }
    }
}
