using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientMasters;

namespace Cams.Dal.Mappings
{
    public class LabourChargeTypeMap : ClassMap<LabourChargeType>
    {
        public LabourChargeTypeMap()
        {
            Table("LabourChargeTypes");
            LazyLoad();
            Id(x => x.LabourChargeId).GeneratedBy.Identity().Column("LabourChargeId");
            Map(x => x.LabourCharge).Column("LabourCharge").Not.Nullable().Length(50);
            //Map(x => x.Derivative1).Column("Derivative1").Length(50);
            //Map(x => x.Derivative2).Column("Derivative2").Length(50);
            //Map(x => x.IsActive).Column("IsActive").Not.Nullable();
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
            //References(x => x.LabourChargesPayableTo).Column("LCPayableToId");
            //References(x => x.D1PayableTo).Column("D1PayableToId");
            //References(x => x.D2PayableTo).Column("D2PayableToId");
        }
    }
}
