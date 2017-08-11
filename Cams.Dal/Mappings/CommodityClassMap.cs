using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientMasters;

namespace Cams.Dal.Mappings
{
    public class CommodityClassMap: ClassMap<CommodityClass>
    {
        public CommodityClassMap()
        {
            Table("CommodityClasses");
            LazyLoad();
            Id(x => x.CommodityClassId).GeneratedBy.Identity().Column("CommodityClassId");
            Map(x => x.Name).Column("Name").Not.Nullable();
            Map(x => x.IsActive).Column("IsActive").Not.Nullable();
            HasMany(x => x.Commodities).KeyColumn("CommodityClassId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasManyToMany(x => x.CommoditiesofClients)
                .Table("ClientCommodities")
                .ParentKeyColumn("CommodityClassId")
                .ChildKeyColumn("CAId")
                .Cascade.SaveUpdate();
                
        }
    }
}
