using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Email;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class ClientProfileChangeRequestsMap : ClassMap<ClientProfileChangeRequests>
    {
        public ClientProfileChangeRequestsMap()
        {
            Table("ClientProfileChangeRequests");
            LazyLoad();
            Id(x => x.RequestId).GeneratedBy.Identity().Column("RequestId");
            Map(x => x.Reason).Column("Reason").Length(200).Not.Nullable();
            Map(x => x.CAId).Column("CAId").Not.Nullable();
            Map(x => x.ClientProfileChangeRequestStatus).Column("ClientProfileChangeRequestStatus").Not.Nullable();
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                 .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");

            References(x => x.ClientProfileChangeRequestEmailMessages).Column("EmailMessageId").Not.Nullable().Cascade.SaveUpdate();
            HasManyToMany(x => x.ClientProfileChangeRequestFields)
               .Table("ClientProfileChangeRequestsWithFields")
               .ParentKeyColumn("RequestId")
               .ChildKeyColumn("ClientProfileCRFieldId")
               .Cascade.SaveUpdate();
               
        }
    }
}
