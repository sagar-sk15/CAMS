using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.Users;

namespace Cams.Dal.Mappings
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.RoleId);
            Map(x => x.RoleName).Column("RoleName").Not.Nullable();
            Map(x => x.RoleGroup).Column("RoleGroup").Nullable();
            Map(x => x.IsApplicableForAckUsers).Column("IsApplicableForAckUsers");
            Map(x => x.IsAddApplicable).Column("IsAddApplicable");
            Map(x => x.IsEditApplicable).Column("IsEditApplicable");
            Map(x => x.IsViewApplicable).Column("IsViewApplicable");
            Map(x => x.IsDeleteApplicable).Column("IsDeleteApplicable");
            Map(x => x.IsPrintApplicable).Column("IsPrintApplicable");
            Table("Roles");
            HasManyToMany(x => x.RolesInUserRolePermissions)
                .Table("UserRolePermissions")
                .ParentKeyColumn("RoleId")
                .ChildKeyColumn("UserRolePermissionId")
                .Inverse();
            HasManyToMany(x => x.RolesInUserGroupRolePermissions)
                .Table("UserGroupRolePermissions")
                .ParentKeyColumn("RoleId")
                .ChildKeyColumn("UserGroupRolePermissionId")                
                .Inverse();
        }
    }
}
