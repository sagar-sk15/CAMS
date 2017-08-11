using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{

    public class MenuMap : ClassMap<Menus>
    {
        public MenuMap()
        {
            Table("Menus");
            LazyLoad();
            Id(x => x.MenuId).GeneratedBy.Identity().Column("MenuId");            
            Map(x => x.MenuName).Column("MenuName").Not.Nullable().Length(50);
            Map(x => x.MenuDescription).Column("MenuDescription");
            Map(x => x.IsMenuActive).Column("IsMenuActive").Not.Nullable();
            Map(x => x.IsackUser).Column("IsackUser").Not.Nullable(); 
            HasMany(x => x.ParentMenus).KeyColumn("ParentMenuId");
            HasMany(x => x.ChildMenus).KeyColumn("ChildMenuId");
        }
    }

}
