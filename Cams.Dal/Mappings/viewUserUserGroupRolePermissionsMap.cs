using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Users;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class viewUserUserGroupRolePermissionsMap : ClassMap<viewUserUserGroupRolePermissions>
    {
        public viewUserUserGroupRolePermissionsMap()
        {
            Table("vwUserUserGroupRolePermissions");
            LazyLoad();

            CompositeId().KeyReference(x => x.PermissionForRole, "RoleId")
                .KeyReference(x => x.RolePermissionsOfUser, "UserId");
            Map(x => x.AllowAdd).Column("AllowAdd").Nullable();
            Map(x => x.AllowEdit).Column("AllowEdit").Nullable();
            Map(x => x.AllowView).Column("AllowView").Nullable();
            Map(x => x.AllowDelete).Column("AllowDelete").Nullable();
            Map(x => x.AllowPrint).Column("AllowPrint").Nullable();
        }
    }
}
