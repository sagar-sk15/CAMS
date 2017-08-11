using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Dal.Mappings
{
    public class ClientCommoditiesHistoryMap:ClassMap<ClientCommoditiesHistory>
    {
        public ClientCommoditiesHistoryMap()
        {
            Table("ClientCommoditiesHistory");
            LazyLoad();
            Id(x => x.ClientCommoditiesHistoryId).GeneratedBy.Identity().Column("ClientCommoditiesHistoryId");
            Map(x => x.CAId).Column("CAId").Not.Nullable();
            Map(x => x.CommodityClassId).Column("CommodityClassId").Not.Nullable();
            Map(x => x.ModifiedBy).Column("ModifiedBy").Not.Nullable();
            Map(x => x.ModifiedDate).Column("ModifiedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Always()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");
        } 
    }
}
