using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Email;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class ClientProfileChangeRequestFieldsMap : ClassMap<ClientProfileChangeRequestFields>
    {
        public ClientProfileChangeRequestFieldsMap()
        {
            Table("ClientProfileChangeRequestFields");
            LazyLoad();
            Id(x => x.ClientProfileCRFieldId).GeneratedBy.Identity().Column("ClientProfileCRFieldId");
            Map(x => x.FieldName).Column("FieldName").Length(100).Not.Nullable();
            Map(x => x.CurrentValue).Column("CurrentValue").Length(200).Not.Nullable();
            Map(x => x.NewValue).Column("NewValue").Length(200).Not.Nullable();
            Map(x => x.FieldOfValue).Column("FieldOfValue").Length(200).Not.Nullable();
            Map(x => x.ObjectNameInDomainEntity).Column("ObjectNameInDomainEntity").Length(200).Not.Nullable();
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                 .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");

            HasManyToMany(x => x.ClientProfileChangeRequests)
               .Table("ClientProfileChangeRequestsWithFields")
               .ParentKeyColumn("ClientProfileCRFieldId")
               .ChildKeyColumn("RequestId")
               .Cascade.SaveUpdate();
               
        }
    }
}
