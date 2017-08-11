using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientMasters;

namespace Cams.Dal.Mappings
{
    public class ChargesPayableToMap : ClassMap<ChargesPayableTo>
    {
        public ChargesPayableToMap()
        {
            Table("ChargesPayableTo");
            LazyLoad();
            Id(x => x.ChargesPayableToId).GeneratedBy.Identity().Column("ChargesPayableToId");
            Map(x => x.PayableTo).Column("PayableTo").Not.Nullable().Length(30);
            Map(x => x.IsActive).Column("IsActive").Not.Nullable();
            //HasMany(x => x.LabourCharges).KeyColumn("LCPayableToId");
            //HasMany(x => x.D1LabourCharges).KeyColumn("D1PayableToId");
            //HasMany(x => x.D2LabourCharges).KeyColumn("D2PayableToId");
        }
    }
}
