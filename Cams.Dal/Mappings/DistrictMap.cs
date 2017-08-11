using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.Masters;

namespace Cams.Dal.Mappings
{
    public class DistrictMap : ClassMap<District>
    {
        public DistrictMap()
        {
            Table("Districts");
            LazyLoad();
            Id(x => x.DistrictId).GeneratedBy.Identity().Column("DistrictId");
            Map(x => x.DistrictName).Column("DistrictName").Length(255).Not.Nullable();
            References(x => x.StateOfDistrict).Column("StateId");
            HasMany(x => x.CitiesOrVillages).KeyColumn("DistrictId");
            //.Cascade.SaveUpdate()
            //.Inverse();
        }
    }
}
