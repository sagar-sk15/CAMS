using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class ParentChildMenuMap : ClassMap<ParentChildMenu>
    {
        public ParentChildMenuMap()
        {
            Table("ParentChildMenus");
            LazyLoad();
            CompositeId().KeyReference(x => x.ParentMenu, "MenuId").KeyReference
                (x => x.ChildMenu, "MenuId");
            References(x => x.ParentMenu).Column("ParentMenuId");
            References(x => x.ChildMenu).Column("ChildMenuId");
            Map(x => x.MenuOrder).Column("MenuOrder").Not.Nullable();
        }
    }
}
