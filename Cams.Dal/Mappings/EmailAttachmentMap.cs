using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Email;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class EmailAttachmentMap : ClassMap<EmailAttachment>
    {
        public EmailAttachmentMap()
        {
            Table("EmailAttachments");
            LazyLoad();
            Id(x => x.EmailAttachmentId).GeneratedBy.Identity().Column("EmailAttachmentId");
            Map(x => x.Attachmentname).Column("Attachmentname").Length(100).Nullable();
            Map(x => x.AttachmentLocation).Column("AttachmentLocation").Length(100).Nullable();
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

            References(x => x.EmailMessages).Column("EmailMessageId").Not.Nullable().Cascade.SaveUpdate();
        }
    }
}
