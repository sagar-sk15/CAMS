using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientMasters;

namespace Cams.Dal.Mappings
{
    public class MeasuringUnitMap : ClassMap<MeasuringUnit>
    {
        public MeasuringUnitMap()
        {
            Table("MeasuringUnit");
            LazyLoad();
            Id(x => x.UnitId).GeneratedBy.Identity().Column("UnitId");
            Map(x => x.UnitType).Column("UnitType").Not.Nullable().Length(20);
            Map(x => x.MeasurementUnit).Column("MeasurementUnit").Not.Nullable().Length(30);
            Map(x => x.EquivalentUnit).Column("EquivalentUnit").Not.Nullable().Length(30);
            Map(x => x.CAId).Column("CAId").Not.Nullable();
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
        }
    }
}
