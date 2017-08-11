using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientMasters;

namespace Cams.Dal.Mappings
{
    public class CommodityMap : ClassMap<Commodity>
    {
        public CommodityMap()
        {
            Table("Commodities");
            LazyLoad();
            Id(x => x.CommodityId).GeneratedBy.Identity().Column("CommodityId");
            Map(x => x.Name).Column("Name").Not.Nullable();
            Map(x => x.BotanicalName).Column("BotanicalName").Not.Nullable();
            Map(x => x.Image).Column("Image");
            Map(x => x.IsActive).Column("IsActive").Not.Nullable();
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate)
                .Column("CreatedDate")
                .CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime")
                .Not.Nullable();
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.ModifiedDate)
                .Column("ModifiedDate")
                .CustomType("DateTime")
                .Access.Property()
                .Generated.Always()
                .Default("getdate()")
                .CustomSqlType("datetime")
                .Nullable();
            References(x => x.CommoditiesInCommodityClass).Column("CommodityClassId");
        }
    }
}
