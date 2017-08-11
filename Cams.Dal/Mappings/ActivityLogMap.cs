using FluentNHibernate.Mapping;
using Cams.Domain.Entities;

namespace Cams.Dal.Mappings
{


    public class ActivityLogMap : ClassMap<ActivityLog>
    {
        public ActivityLogMap()
        {
            Table("ActivityLogs");
            LazyLoad();
            Id(x => x.LogId).GeneratedBy.Identity().Column("LogId");
            Map(x => x.LoggedBy).Column("LoggedBy").Not.Nullable().Length(255);
            Map(x => x.LoggedDate).Column("LoggedDate").CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime").Not.Nullable();
            Map(x => x.ActivityRelatedTo).Column("ActivityRelatedTo").Not.Nullable().Length(50);
            Map(x => x.Description).Column("Description");
            Map(x => x.CAId).Column("CAId");
            Map(x => x.ObjectId).Column("ObjectId");
        }
    }
}
