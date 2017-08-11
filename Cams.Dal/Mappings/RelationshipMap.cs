using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.Users;

namespace Cams.Dal.Mappings
{
    public class RelationshipMap : ClassMap<Relationship>
    {
        public RelationshipMap()
        {
            Table("RelationShips");
            LazyLoad();
            Id(x => x.RelationshipId).GeneratedBy.Identity().Column("RelationshipId");
            Map(x => x.Name).Column("Name").Length(255).Not.Nullable();
            Map(x => x.CAId).Column("CAId");
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime")
                .Not.Nullable();
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.ModifiedDate).Column("ModifiedDate").CustomType("DateTime")
                .Access.Property()
                .Generated.Always()
                .Default("getdate()")
                .CustomSqlType("datetime");
            
            HasMany(x => x.EmergencyContactPersonRelationshipWithUser).KeyColumn("RelationshipId").Cascade.SaveUpdate()
                .Inverse();
            HasMany(x => x.CPGuardianRelationshipWithClientPartner).KeyColumn("RelationshipId").Cascade.SaveUpdate()
                .Inverse();
            HasMany(x => x.NomineeRelationshipWithClientPartner).KeyColumn("RelationshipId").Cascade.SaveUpdate()
                .Inverse();
        }
    }
}
