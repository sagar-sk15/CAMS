using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Masters;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
        public class StateMap : ClassMap<State> {
        
        public StateMap() {
			Table("States");
			LazyLoad();
            Id(x => x.StateId).GeneratedBy.Identity().Column("StateId");
			Map(x => x.RegionType).Column("RegionType").Length(50).Not.Nullable();
			Map(x => x.RegionName).Column("RegionName").Length(50).Not.Nullable();
            References(x => x.StateInCountry).Column("CountryId");
            HasMany(x => x.DistrictsInState).KeyColumn("StateId").Inverse()
            .Cascade.All();

        }
    }
}

