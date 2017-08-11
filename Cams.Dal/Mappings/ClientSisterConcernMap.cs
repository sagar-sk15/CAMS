using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientRegistration;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class ClientSisterConcernMap : ClassMap<ClientSisterConcern>
    {
        public ClientSisterConcernMap()
        {
            Table("ClientSisterConcern");
            LazyLoad();
            Id(x => x.ClientSisterConcernId).GeneratedBy.Identity().Column("ClientSisterConcernId");
            Map(x => x.BusinessRelation).Column("BusinessRelation").Length(30).Nullable();
            Map(x => x.ClientSisterConcerName).Column("ClientSisterConcerName").Nullable().Length(200);
            Map(x => x.RelationshipWithEntity).Column("RelationshipWithEntity").Nullable().Length(200);
            Map(x => x.EntityId).Column("EntityId").Nullable();
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.ModifiedBy).Column("ModifiedBy").Not.Nullable();
            Map(x => x.ModifiedDate).Column("ModifiedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Always()
                .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");

            HasManyToMany(x => x.SisterConcernOfClient)
              .Table("ClientSisterConcerns")
              .ParentKeyColumn("ClientSisterConcernId")
              .ChildKeyColumn("CAId")
              .Cascade.SaveUpdate();
        }
    }
}
