using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.Masters;

namespace Cams.Dal.Mappings
{
    public class CityVillageMap: ClassMap<CityVillage>
    {
        public CityVillageMap()
        {
            Table("CityVillages");
            LazyLoad();
            Id(x => x.CityVillageId).GeneratedBy.Identity().Column("CityVillageId");
            Map(x => x.Name).Column("Name").Length(255).Not.Nullable();
            Map(x => x.CityOrVillage).Column("CityOrVillage").Not.Nullable();
            Map(x => x.STDCode).Column("STDCode").Length(30);
            Map(x => x.CAId).Column("CAId").Nullable();
            Map(x => x.BaseCityVillageId).Column("BaseCityVillageId").Nullable();
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
            References(x => x.DistrictOfCityVillage).Column("DistrictId");
            HasMany(x => x.Addresses).KeyColumn("CityVillageId").Inverse();
        }
    }
}
