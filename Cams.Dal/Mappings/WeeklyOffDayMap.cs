using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities;

namespace Cams.Dal.Mappings
{
    public class WeeklyOffDayMap:ClassMap<WeeklyOffDays>
    {
        public WeeklyOffDayMap()
        {
            Table("BankBranchWeeklyOffs");
            LazyLoad();
            Id(x => x.WeeklyOffDayId).GeneratedBy.Identity().Column("WeeklyOffDayId");
            Map(x => x.IsMonday).Column("IsMonday");
            Map(x => x.IsTuesday).Column("IsTuesday");
            Map(x => x.IsWednesday).Column("IsWednesday");
            Map(x => x.IsThursday).Column("IsThursday");
            Map(x => x.IsFriday).Column("IsFriday");
            Map(x => x.IsSaturday).Column("IsSaturday");
            Map(x => x.IsSunday).Column("IsSunday");
            HasOne(x => x.WeeklyOffDayOfBranch).ForeignKey("WeeklyOffDayId").Cascade.SaveUpdate(); 
        }
    }
}
